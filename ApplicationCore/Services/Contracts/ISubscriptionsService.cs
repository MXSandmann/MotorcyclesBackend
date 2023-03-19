using ApplicationCore.Models.Entities;

namespace ApplicationCore.Services.Contracts
{
    public interface ISubscriptionsService
    {
        Task AddSubscription(Subscription subscription);
        Task<IEnumerable<Subscription>> GetAllSubscriptions();
    }
}
