using App.Domain.Events.Shop.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class ProductEventHandler :
        INotificationHandler<ProductCreateEvent>,
        INotificationHandler<ProductRemoveEvent>,
        INotificationHandler<ProductUpdateEvent>
    {
        public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductRemoveEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
