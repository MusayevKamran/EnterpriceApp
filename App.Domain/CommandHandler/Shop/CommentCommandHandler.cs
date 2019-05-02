using App.Domain.Commands.Shop.Comment;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Comment;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Shop;
using App.Domain.Models.Shop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.CommandHandler.Shop
{
    public class CommentCommandHandler : CommandHandler,
        IRequestHandler<CreateNewCommentCommand, bool>,
        IRequestHandler<UpdateCommentCommand, bool>,
        IRequestHandler<RemoveCommentCommand, bool>
    {
        public readonly ICommentRepository _commentRepository;
        public readonly IMediatorHandler _bus;
        public CommentCommandHandler(
            ICommentRepository commentRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _commentRepository = commentRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewCommentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var comment = new Comment(request.CommentId, request.CommentContent, request.Product, request.UserId);

            //if (_commentRepository.GetById(comment.CommentId) != null)
            //{
            //    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The comment has already been created."));
            //    return Task.FromResult(false);
            //}
            _commentRepository.Add(comment);

            if (Commit())
            {
                _bus.RaiseEvent(new CommentCreatedEvent(comment.CommentId, comment.CommentContent, comment.Product, comment.UserId));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var comment = new Comment(request.CommentId, request.CommentContent, request.Product, request.UserId);
            var existingComment = _commentRepository.GetById(comment.CommentId);

            if (existingComment != null && existingComment.CommentId == comment.CommentId)
            {
                if (!existingComment.Equals(comment))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The comment has already been created."));
                    return Task.FromResult(false);
                }
            }
            _commentRepository.Update(comment);
            if (Commit())
            {
                _bus.RaiseEvent(new CommentUpdatedEvent(comment.CommentId, comment.CommentContent, comment.Product, comment.UserId));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _commentRepository.Remove(request.CommentId);
            if (Commit())
            {
                _bus.RaiseEvent(new CommentRemovedEvent(request.CommentId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _commentRepository.Dispose();
        }
    }
}
