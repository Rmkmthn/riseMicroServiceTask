using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rise.ReportCore;
using Rise.ReportCore.Business;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void ConfigureServices(IServiceCollection services)
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
        }
    }
}
