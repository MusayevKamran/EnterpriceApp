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
        INotificationHandler<CommentCreateEvent>,
        INotificationHandler<CommentRemoveEvent>,
        INotificationHandler<CommentUpdateEvent>
    {
        public Task Handle(CommentCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CommentRemoveEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CommentUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
