using App.Domain.Events.Shop.Image;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class ImageEventHandler :
        INotificationHandler<ImageCreateEvent>,
        INotificationHandler<ImageRemoveEvent>,
        INotificationHandler<ImageUpdateEvent>
    {
        public Task Handle(ImageCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ImageRemoveEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ImageUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
