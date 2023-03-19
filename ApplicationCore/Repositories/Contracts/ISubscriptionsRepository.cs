using ApplicationCore.Models.Entities;

namespace ApplicationCore.Repositories.Contracts
{
    public interface ISubscriptionsRepository
    {
        Task<IEnumerable<Subscription>> GetAll();
        Task Add(Subscription subscription);
    }
}
