using ApplicationCore.Models.Notifications;
using ApplicationCore.Services.Contracts;
using MediatR;

namespace ApplicationCore.Handlers
{
    public class OnCreateNotificationHandler : INotificationHandler<OnCreateNotification>
    {
        private readonly ISubscriptionsService _subscriptionsService;
        private readonly IEmailService _emailService;

        public OnCreateNotificationHandler(ISubscriptionsService subscriptionsService, IEmailService emailService)
        {
            _subscriptionsService = subscriptionsService;
            _emailService = emailService;
        }

        public async Task Handle(OnCreateNotification notification, CancellationToken cancellationToken)
        {
            // Get all subscriptions
            var subscriptions = await _subscriptionsService.GetAllSubscriptions();

            // If no subscriptions, do not allocate and return
            if (!subscriptions.Any())
                return;

            // Create a list of tasks
            var emailTasks = new List<Task>();

            // Add a task for each subscription
            foreach (var subscription in subscriptions)
            {
                emailTasks.Add(_emailService.SendEmail(subscription.UserName, subscription.UserEmail, notification.NewModel, notification.Engine, notification.Price));
            }

            // Send all emails simultaneously
            await Task.WhenAll(emailTasks);
        }
    }
}
