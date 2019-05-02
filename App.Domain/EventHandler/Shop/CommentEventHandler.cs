using App.Domain.Events.Shop.Comment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.EventHandler.Shop
{
    public class CommentEventHandler :
        INotificationHandler<CommentCreatedEvent>,
        INotificationHandler<CommentRemovedEvent>,
        INotificationHandler<CommentUpdatedEvent>
    {
        public Task Handle(CommentCreatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CommentRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CommentUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
