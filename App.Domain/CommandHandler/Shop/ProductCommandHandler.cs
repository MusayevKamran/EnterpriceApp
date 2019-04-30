using App.Domain.Commands.Shop.Product;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Product;
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
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<CreateNewProductCommand, bool>,
        IRequestHandler<UpdateProductCommand, bool>,
        IRequestHandler<RemoveProductCommand, bool>
    {
        public readonly IProductRepository _productRepository;
        public readonly IMediatorHandler _bus;
        public ProductCommandHandler(
            IProductRepository productRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(uow, bus, notifications)
        {
            _productRepository = productRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var product = new Product(request.ProductId, request.ProductName, request.Category, request.Detail, request.Seller, request.Images);

            if (_productRepository.GetById(product.ProductId) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The product has already been created."));
                return Task.FromResult(false);
            }
            _productRepository.Add(product);

            if (Commit())
            {
                _bus.RaiseEvent(new ProductCreatedEvent(product.ProductId, product.ProductName, product.Category, product.Detail, product.Seller, product.Images));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var product = new Product(request.ProductId, request.ProductName, request.Category, request.Detail, request.Seller, request.Images);
            var existingCategory = _productRepository.GetById(product.ProductId);

            if (existingCategory != null && existingCategory.ProductId == product.ProductId)
            {
                if (!existingCategory.Equals(product))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The product has already been created."));
                    return Task.FromResult(false);
                }
            }
            _productRepository.Update(product);
            if (Commit())
            {
                _bus.RaiseEvent(new ProductUpdatedEvent(product.ProductId, product.ProductName, product.Category, product.Detail, product.Seller, product.Images));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _productRepository.Remove(request.ProductId);
            if (Commit())
            {
                _bus.RaiseEvent(new ProductRemovedEvent(request.ProductId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}
