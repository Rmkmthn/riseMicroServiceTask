using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Data;
using System.Threading.Tasks;

namespace IntegrationEventLogEF
{
    public class IntegrationEventLogContext : DbContext
    {
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;
                
        public IntegrationEventLogContext(DbContextOptions<IntegrationEventLogContext> options) : base(options)
        {
        }

        public DbSet<IntegrationEventLogEntry> IntegrationEventLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<IntegrationEventLogEntry>(ConfigureIntegrationEventLogEntry);
            builder.ApplyConfiguration(new IntegrationEventLogEntryConfig());
        }
        public class IntegrationEventLogEntryConfig : IEntityTypeConfiguration<IntegrationEventLogEntry>
        {
            public void Configure(EntityTypeBuilder<IntegrationEventLogEntry> entity)
            {
                entity.ToTable("IntegrationEventLog");

                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventId)
                    .IsRequired();

                entity.Property(e => e.Content)
                    .IsRequired();

                entity.Property(e => e.CreationTime)
                    .IsRequired();

                entity.Property(e => e.State)
                    .IsRequired();

                entity.Property(e => e.TimesSent)
                    .IsRequired();

                entity.Property(e => e.EventTypeName)
                    .IsRequired();
            }
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;

            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
