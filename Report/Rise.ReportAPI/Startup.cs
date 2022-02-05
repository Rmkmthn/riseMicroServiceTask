using Autofac;
using Autofac.Extensions.DependencyInjection;
using EventBus;
using EventBus.Abstractions;
using EventBus.Events;
using EventBusRabbitMQ;
using IntegrationEventLogEF;
using IntegrationEventLogEF.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using Rise.ReportAPI.Handlers;
using Rise.ReportAPI.Services;
using Rise.ReportCore;
using Rise.ReportCore.Business;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rise.ReportAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(x =>
                                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rise.ReportAPI", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("BaseConnection"), b => b.MigrationsAssembly("Rise.ReportCore")));
            services.AddScoped<DbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddTransient<IReportService>(cs =>
            {
                var oDbContext = cs.GetRequiredService<ApplicationDbContext>();

                return new ReportService(oDbContext);
            });
            services.AddTransient<IReportConstService>(cs =>
            {
                var oDbContext = cs.GetRequiredService<ApplicationDbContext>();

                return new ConstService(oDbContext);
            });
            AddCustomDbContext(services, Configuration);
            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };

                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            RegisterEventBus(services);


            var container = new ContainerBuilder();
            container.Populate(services);
            return new AutofacServiceProvider(container.Build());
        }
        public void AddCustomDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<IntegrationEventLogContext>(options => options.UseNpgsql(Configuration.GetConnectionString("IntegrationConnectionString"), b => b.MigrationsAssembly("IntegrationEventLogEF")));

            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));
        }
        private void RegisterEventBus(IServiceCollection services)
        {
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddSingleton<IEventBus, EventBusRabbitMQ.EventBusRabbitMQ>(sp =>
            {
                var subscriptionClientName = Configuration["SubscriptionClientName"];
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ.EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ.EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddTransient<ReportRequestedIntegrationEventHandler>();
            //services.AddTransient<UserUpdatedIntegrationEventHandler>();
            services.AddTransient<IReportIntegrationEventService, ReportIntegrationEventService>();

        }
        public class ApplicationDbContextDesign : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("BaseConnection");
                builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("Rise.ReportCore"));
                return new ApplicationDbContext(builder.Options);
            }
        }

        public class IntegrationEventLogContextDesign : IDesignTimeDbContextFactory<IntegrationEventLogContext>
        {
            public IntegrationEventLogContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<IntegrationEventLogContext>();
                var connectionString = configuration.GetConnectionString("IntegrationConnectionString");
                builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("IntegrationEventLogEF"));
                return new IntegrationEventLogContext(builder.Options);
            }
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rise.ReportAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ReportRequestedIntegrationEvent, ReportRequestedIntegrationEventHandler>();
        }
    }
}
