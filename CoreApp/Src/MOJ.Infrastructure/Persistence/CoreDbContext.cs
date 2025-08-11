using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MOJ.Domain.Entities;
using MOJ.SharedKernel.Abstractions.Persistence;
using MOJ.SharedKernel.Extensions;

namespace MOJ.Infrastructure.Persistence
{
    public sealed class CoreDbContext(
        DbContextOptions<CoreDbContext> options,
        IMediator mediator
    ) : DbContext(options), IUnitOfWork
    {
        #region Entities
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureCustomRules(this);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoreDbContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.ConfigureCustomConventions();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await this.PublishDomainEvents(mediator);

            return result;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.CommitTransactionAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Database.RollbackTransactionAsync(cancellationToken);
        }

    }
}