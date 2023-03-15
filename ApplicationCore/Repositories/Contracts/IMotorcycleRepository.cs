using ApplicationCore.Models.Entities;

namespace ApplicationCore.Repositories.Contracts
{
    public interface IMotorcyclesRepository
    {
        Task<Guid> Add(Motorcycle motorcycle);
        Task<Motorcycle> Get(Guid id);
        Task<IEnumerable<Motorcycle>> GetAll();
        Task Remove(Motorcycle motorcycle);
        Task<Motorcycle> Update(Motorcycle motorcycle);        
    }
}
