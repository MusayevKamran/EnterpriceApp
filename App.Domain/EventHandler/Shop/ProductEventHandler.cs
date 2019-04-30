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
        INotificationHandler<ProductCreatedEvent>,
        INotificationHandler<ProductRemovedEvent>,
        INotificationHandler<ProductUpdatedEvent>
    {
        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
