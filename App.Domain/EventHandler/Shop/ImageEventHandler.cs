using App.Domain.Events.Shop.Image;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class ImageEventHandler :
        INotificationHandler<ImageCreatedEvent>,
        INotificationHandler<ImageRemovedEvent>,
        INotificationHandler<ImageUpdatedEvent>
    {
        public Task Handle(ImageCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ImageRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ImageUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
