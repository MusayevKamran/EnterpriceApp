using App.Domain.Events.Shop.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryCreatedEvent>,
        INotificationHandler<CategoryRemovedEvent>,
        INotificationHandler<CategoryUpdatedEvent>
    {
        public Task Handle(CategoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CategoryRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CategoryUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
