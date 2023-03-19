using ApplicationCore.Models.Entities;

namespace ApplicationCore.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<IEnumerable<Motorcycle>> Add(Motorcycle motorcycle);
        Task<Motorcycle> Get(Guid id);
        Task<IEnumerable<Motorcycle>> GetAll();
        Task<IEnumerable<Motorcycle>> Remove(Guid id);
        Task<IEnumerable<Motorcycle>> Update(Motorcycle motorcycle);
    }
}
