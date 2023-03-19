using ApplicationCore.Models.Entities;

namespace ApplicationCore.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<IEnumerable<Motorcycle>> Add(Motorcycle motorcycle);
        Task<IEnumerable<Motorcycle>> Update(Motorcycle motorcycle);
        Task<IEnumerable<Motorcycle>> Remove(Guid id);
        Task<Motorcycle> Get(Guid id);
        Task<IEnumerable<Motorcycle>> GetAll();
    }
}
