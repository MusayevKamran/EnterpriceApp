using App.Domain.Events.Shop.Detail;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class DetailEventHandler :
        INotificationHandler<DetailCreatedEvent>,
        INotificationHandler<DetailRemovedEvent>,
        INotificationHandler<DetailUpdatedEvent>
    {
        public Task Handle(DetailCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DetailRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DetailUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
