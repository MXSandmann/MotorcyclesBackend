using MediatR;

namespace ApplicationCore.Models.Notifications
{
    public class OnCreateNotification : INotification
    {
        public OnCreateNotification(string newModel, int engine, double price)
        {
            NewModel = newModel;
            Engine = engine;
            Price = price;
        }

        public string NewModel { get; init; } = string.Empty;
        public int Engine { get; init; }
        public double Price { get; init; }
    }
}
