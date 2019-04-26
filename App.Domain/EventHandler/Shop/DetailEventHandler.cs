using App.Domain.Events.Shop.Detail;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class DetailEventHandler :
        INotificationHandler<DetailCreateEvent>,
        INotificationHandler<DetailRemoveEvent>,
        INotificationHandler<DetailUpdateEvent>
    {
        public Task Handle(DetailCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DetailRemoveEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DetailUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
