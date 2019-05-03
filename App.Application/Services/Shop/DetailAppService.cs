using App.Application.EventSourcedNormalizers.Shop.Detail;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Detail;
using App.Domain.Core.Bus;
using App.Domain.Interfaces.Shop;
using App.Infrastructure.Data.Repository.EventSourcing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Services.Shop
{
    public class DetailAppService : IDetailAppService
    {
        private readonly IMapper _mapper;
        private readonly IDetailRepository _detailRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public DetailAppService(IMapper mapper,
                                  IDetailRepository detailRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _detailRepository = detailRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<DetailViewModel> GetAll()
        {
            return _detailRepository.GetAll().ProjectTo<DetailViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<DetailHistoryData> GetAllHistory(int id)
        {
            return DetailHistory.ToJavaScriptDetailHistory(_eventStoreRepository.All(id));
        }

        public DetailViewModel GetById(int id)
        {
            return _mapper.Map<DetailViewModel>(_detailRepository.GetById(id));
        }

        public void Create(DetailViewModel detailViewModel)
        {
            var createCommand = _mapper.Map<CreateNewDetailCommand>(detailViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveDetailCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(DetailViewModel detailViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDetailCommand>(detailViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
