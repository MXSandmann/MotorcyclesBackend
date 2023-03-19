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

        public async Task<IEnumerable<Motorcycle>> Add(Motorcycle motorcycle)
        {
            return await _repository.Add(motorcycle);
        }

        public async Task<Motorcycle> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<Motorcycle>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Motorcycle>> Remove(Guid id)
        {
            return await _repository.Remove(id);
        }

        public async Task<IEnumerable<Motorcycle>> Update(Motorcycle motorcycle)
        {
            return await _repository.Update(motorcycle);
        }
    }
}
