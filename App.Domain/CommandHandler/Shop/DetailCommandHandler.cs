using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using App.Domain.Commands.Shop.Detail;
using App.Domain.Core.Bus;
using App.Domain.Core.Notifications;
using App.Domain.Events.Shop.Detail;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Shop;
using App.Domain.Models.Shop;
using MediatR;

namespace App.Domain.CommandHandler.Shop
{
    public class DetailCommandHandler : CommandHandler,
        IRequestHandler<CreateNewDetailCommand, bool>,
        IRequestHandler<UpdateDetailCommand, bool>,
        IRequestHandler<RemoveDetailCommand, bool>
    {
        public readonly IDetailRepository _detailRepository;
        public readonly IMediatorHandler _bus;

        public DetailCommandHandler(
            IDetailRepository detailRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _detailRepository = detailRepository;
            _bus = bus;
        }

        public Task<bool> Handle(CreateNewDetailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var detail = new Detail(request.DetailId, request.DetailName, request.DetailFeature, request.Category);
            if (_detailRepository.GetById(detail.DetailId) != null)
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The detail has already been created."));
                return Task.FromResult(false);
            }
            _detailRepository.Add(detail);

            if (Commit())
            {
                _bus.RaiseEvent(new DetailCreatedEvent(detail.DetailId, detail.DetailName, detail.DetailFeature, detail.Category));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateDetailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                Task.FromResult(false);
            }
            var detail = new Detail(request.DetailId, request.DetailName, request.DetailFeature, request.Category);
            var existingDetail = _detailRepository.GetById(detail.DetailId);

            if (existingDetail != null && existingDetail.DetailId == detail.DetailId)
            {
                if (!existingDetail.Equals(detail))
                {
                    _bus.RaiseEvent(new DomainNotification(request.MessageType, "The detail has already been created."));
                    return Task.FromResult(false);
                }
            }
            _detailRepository.Update(detail);
            if (Commit())
            {
                _bus.RaiseEvent(new DetailUpdatedEvent(detail.DetailId, detail.DetailName, detail.DetailFeature, detail.Category));
            }
            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveDetailCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _detailRepository.Remove(request.DetailId);
            if (Commit())
            {
                _bus.RaiseEvent(new DetailRemovedEvent(request.DetailId));
            }
            return Task.FromResult(true);
        }
        public void Dispose()
        {
            _detailRepository.Dispose();
        }
    }
}
