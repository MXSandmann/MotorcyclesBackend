using ApplicationCore.Models.Entities;
using ApplicationCore.Models.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext
{
    public class MotorcycleDataContext : DbContext
    {
        private readonly IMediator _mediator;
        public MotorcycleDataContext(DbContextOptions<MotorcycleDataContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotorcycleDataContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Motorcycle>();
            foreach (var entry in entries)
            {
                if (entry.State is EntityState.Added)
                    await _mediator.Publish(new OnCreateNotification($"{entry.Entity.ModelName} from company {entry.Entity.Company}", entry.Entity.EnginePower, entry.Entity.Price), cancellationToken);
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
