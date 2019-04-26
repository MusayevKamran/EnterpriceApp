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
        INotificationHandler<SellerCreateEvent>,
        INotificationHandler<SellerRemoveEvent>,
        INotificationHandler<SellerUpdateEvent>
    {
        public Task Handle(SellerCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SellerRemoveEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(SellerUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
