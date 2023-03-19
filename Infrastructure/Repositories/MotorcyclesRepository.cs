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

        public async Task<IEnumerable<Motorcycle>> Add(Motorcycle motorcycle)
        {
            await _dataContext.Motorcycles.AddAsync(motorcycle);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Motorcycles.ToListAsync();

        }

        public async Task<Motorcycle> Get(Guid id)
        {
            var motorcycle = await _dataContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(motorcycle);
            return motorcycle;
        }

        public async Task<IEnumerable<Motorcycle>> GetAll()
        {
            return await _dataContext.Motorcycles.ToListAsync();
        }

        public async Task<IEnumerable<Motorcycle>> Remove(Guid id)
        {
            var toRemove = await _dataContext.Motorcycles.FirstOrDefaultAsync(x => x.Id == id);
            ArgumentNullException.ThrowIfNull(toRemove);
            _dataContext.Motorcycles.Remove(toRemove);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Motorcycles.ToListAsync();
        }

        public async Task<IEnumerable<Motorcycle>> Update(Motorcycle motorcycle)
        {
            _dataContext.Update(motorcycle);
            await _dataContext.SaveChangesAsync();
            return await _dataContext.Motorcycles.ToListAsync();
        }
    }
}
