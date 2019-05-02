using App.Domain.Commands.Shop.Image;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Image;
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
    public class ImageCommandHandler : CommandHandler,
        IRequestHandler<CreateNewImageCommand, bool>,
        IRequestHandler<UpdateImageCommand, bool>,
        IRequestHandler<RemoveImageCommand, bool>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMediatorHandler _bus;

        public ImageCommandHandler(
            IImageRepository imageRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(uow, bus, notifications)
        {
            _imageRepository = imageRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewImageCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var image = new Image(request.ImageId, request.ImageLink, request.ProfileImage, request.Product);

            if (_imageRepository.GetById(image.ImageId) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The image has already been created."));
                return Task.FromResult(false);
            }

            _imageRepository.Add(image);

            if (Commit())
            {
                _bus.RaiseEvent(new ImageCreatedEvent(image.ImageId, image.ImageLink, request.ProfileImage, request.Product));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var image = new Image(request.ImageId, request.ImageLink, request.ProfileImage, request.Product);
            var existingImage = _imageRepository.GetById(image.ImageId);

            if (existingImage != null && existingImage.ImageId == image.ImageId)
            {
                if (!existingImage.Equals(image))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The image has already been created."));
                    return Task.FromResult(false);
                }
            }
            _imageRepository.Update(image);
            if (Commit())
            {
                _bus.RaiseEvent(new ImageUpdatedEvent(image.ImageId, image.ImageLink, image.ProfileImage, image.Product));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(RemoveImageCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _imageRepository.Remove(request.ImageId);
            if (Commit())
            {
                _bus.RaiseEvent(new ImageRemovedEvent(request.ImageId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _imageRepository.Dispose();
        }
    }
}