using System;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Commands.Shop.Category;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Category;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Shop;
using App.Domain.Models.Shop;
using MediatR;

namespace App.Domain.CommandHandler.Shop
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<CreateNewCategoryCommand, bool>,
         IRequestHandler<UpdateCategoryCommand, bool>,
        IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _bus;

        public CategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(uow, bus, notifications)
        {
            _categoryRepository = categoryRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var category = new Category(request.CategoryId, request.CategoryName, request.SubCategory);

            if (_categoryRepository.GetById(category.CategoryId) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The category has already been created."));
                return Task.FromResult(false);
            }

            _categoryRepository.Add(category);

            if (Commit())
            {
                _bus.RaiseEvent(new CategoryCreatedEvent(category.CategoryId, category.CategoryName, category.SubCategory));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var category = new Category(request.CategoryId, request.CategoryName, request.SubCategory);
            var existingCategory = _categoryRepository.GetById(category.CategoryId);

            if (existingCategory != null && existingCategory.CategoryId == category.CategoryId)
            {
                if (!existingCategory.Equals(category))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The category has already been created."));
                    return Task.FromResult(false);
                }
            }
            _categoryRepository.Update(category);
            if (Commit())
            {
                _bus.RaiseEvent(new CategoryUpdatedEvent(category.CategoryId, category.CategoryName, category.SubCategory));
            }
            return Task.FromResult(true);
        }
        public Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _categoryRepository.Remove(request.CategoryId);
            if (Commit())
            {
                _bus.RaiseEvent(new CategoryRemovedEvent(request.CategoryId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}
