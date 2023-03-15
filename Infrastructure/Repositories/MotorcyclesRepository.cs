using ApplicationCore.Models.Entities;
using ApplicationCore.Repositories.Contracts;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MotorcyclesRepository : IMotorcyclesRepository
    {
        private readonly MotorcycleDataContext _dataContext;

        public MotorcyclesRepository(MotorcycleDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> Add(Motorcycle motorcycle)
        {
            await _dataContext.Motorcycles.AddAsync(motorcycle);
            await _dataContext.SaveChangesAsync();
            return motorcycle.Id;

        }

        public async Task<Motorcycle> Get(Guid id)
        {
            var motorcycle =  await _dataContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(motorcycle);
            return motorcycle;
        }

        public async Task<IEnumerable<Motorcycle>> GetAll()
        {
            return await _dataContext.Motorcycles.ToListAsync();
        }

        public async Task Remove(Motorcycle motorcycle)
        {
            _dataContext.Motorcycles.Remove(motorcycle);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Motorcycle> Update(Motorcycle motorcycle)
        {
            _dataContext.Update(motorcycle);
            await _dataContext.SaveChangesAsync();
            var updated = await _dataContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == motorcycle.Id);
            ArgumentNullException.ThrowIfNull(updated);
            return updated;
        }
    }
}
