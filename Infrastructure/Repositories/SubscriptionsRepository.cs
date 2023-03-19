using ApplicationCore.Models.Entities;
using ApplicationCore.Repositories.Contracts;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly MotorcycleDataContext _context;

        public SubscriptionsRepository(MotorcycleDataContext context)
        {
            _context = context;
        }

        public async Task Add(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Subscription>> GetAll()
        {
            return await _context.Subscriptions.ToListAsync();
        }
    }
}
