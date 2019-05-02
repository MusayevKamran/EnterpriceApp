using App.Domain.Events.Shop.Seller;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class SellerEventHandler :
        INotificationHandler<SellerCreatedEvent>,
        INotificationHandler<SellerRemovedEvent>,
        INotificationHandler<SellerUpdatedEvent>
    {
        public Task Handle(SellerCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SellerRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SellerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
