using ApplicationCore.Models.Entities;

namespace ApplicationCore.Services.Contracts
{
    public interface IMotorcyclesService
    {
        Task<Motorcycle> Add(Motorcycle motorcycle);
        Task<Motorcycle> Update(Motorcycle motorcycle);
        Task Remove(Guid id);
        Task<Motorcycle> Get(Guid id);
        Task<IEnumerable<Motorcycle>> GetAll();
    }
}
