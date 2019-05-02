using App.Domain.Commands.Shop.Seller;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Seller;
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
    public class SellerCommandHandler : CommandHandler,
        IRequestHandler<CreateNewSellerCommand, bool>,
        IRequestHandler<UpdateSellerCommand, bool>,
        IRequestHandler<RemoveSellerCommand, bool>
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMediatorHandler _bus;

        public SellerCommandHandler(
            ISellerRepository sellerRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(uow, bus, notifications)
        {
            _sellerRepository = sellerRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewSellerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var seller = new Seller(request.SellerId, request.Name, request.Email, request.PhoneNumber);

            if (_sellerRepository.GetById(seller.SellerId) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The seller has already been created."));
                return Task.FromResult(false);
            }

            _sellerRepository.Add(seller);

            if (Commit())
            {
                _bus.RaiseEvent(new SellerCreatedEvent(seller.SellerId, seller.Name, seller.Email, seller.PhoneNumber));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var seller = new Seller(request.SellerId, request.Name, request.Email, request.PhoneNumber);
            var existingSeller = _sellerRepository.GetById(seller.SellerId);

            if (existingSeller != null && existingSeller.SellerId == seller.SellerId)
            {
                if (!existingSeller.Equals(seller))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The seller has already been created."));
                    return Task.FromResult(false);
                }
            }
            _sellerRepository.Update(seller);
            if (Commit())
            {
                _bus.RaiseEvent(new SellerUpdatedEvent(seller.SellerId, seller.Name, seller.Email, seller.PhoneNumber));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(RemoveSellerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _sellerRepository.Remove(request.SellerId);
            if (Commit())
            {
                _bus.RaiseEvent(new SellerRemovedEvent(request.SellerId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _sellerRepository.Dispose();
        }
    }
}