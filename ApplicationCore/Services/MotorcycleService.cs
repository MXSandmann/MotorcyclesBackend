using ApplicationCore.Models.Entities;
using ApplicationCore.Repositories.Contracts;
using ApplicationCore.Services.Contracts;

namespace ApplicationCore.Services
{
    public class MotorcycleService : IMotorcyclesService
    {
        private readonly IMotorcyclesRepository _repository;

        public MotorcycleService(IMotorcyclesRepository repository)
        {
            _repository = repository;
        }

        public async Task<Motorcycle> Add(Motorcycle motorcycle)
        {
            var newMotorcycleId = await _repository.Add(motorcycle);
            return await _repository.Get(newMotorcycleId);

        }

        public async Task<Motorcycle> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<Motorcycle>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Remove(Guid id)
        {
            var toRemove = await _repository.Get(id);
            await _repository.Remove(toRemove);
        }

        public async Task<Motorcycle> Update(Motorcycle motorcycle)
        {
            return await _repository.Update(motorcycle);            
        }
    }
}
