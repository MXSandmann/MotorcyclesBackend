using ApplicationCore.Models.Entities;
using ApplicationCore.Repositories.Contracts;
using ApplicationCore.Services.Contracts;

namespace ApplicationCore.Services
{
    public class SubscriptionsService : ISubscriptionsService
    {
        private readonly ISubscriptionsRepository _repository;

        public SubscriptionsService(ISubscriptionsRepository repository)
        {
            _repository = repository;
        }

        public async Task AddSubscription(Subscription subscription)
        {
            await _repository.Add(subscription);
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptions()
        {
            return await _repository.GetAll();
        }        
    }
}
