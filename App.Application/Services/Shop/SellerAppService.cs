using App.Application.EventSourcedNormalizers.Shop.Seller;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Seller;
using App.Domain.Core.Bus;
using App.Domain.Interfaces.Shop;
using App.Infrastructure.Data.Repository.EventSourcing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Application.Services.Shop
{
    public class SellerAppService : ISellerAppService
    {
        private readonly IMapper _mapper;
        private readonly ISellerRepository _sellerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public SellerAppService(IMapper mapper,
                                  ISellerRepository sellerRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _sellerRepository = sellerRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<SellerViewModel> GetAll()
        {
            return _sellerRepository.GetAll().ProjectTo<SellerViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<SellerHistoryData> GetAllHistory(int id)
        {
            return SellerHistory.ToJavaScriptSellerHistory(_eventStoreRepository.All(id));
        }

        public SellerViewModel GetById(int id)
        {
            return _mapper.Map<SellerViewModel>(_sellerRepository.GetById(id));
        }

        public void Create(SellerViewModel sellerViewModel)
        {
            var createCommand = _mapper.Map<CreateNewSellerCommand>(sellerViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveSellerCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(SellerViewModel sellerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateSellerCommand>(sellerViewModel);
            Bus.SendCommand(updateCommand);
        }

        public IEnumerable<SellerViewModel> GetFilteredList(Expression<Func<SellerViewModel, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
