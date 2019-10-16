using App.Application.EventSourcedNormalizers.Shop.Product;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Product;
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
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ProductAppService(IMapper mapper,
                                  IProductRepository productRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll().ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<ProductHistoryData> GetAllHistory(int id)
        {
            return ProductHistory.ToJavaScriptProductHistory(_eventStoreRepository.All(id));
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<ProductViewModel>(_productRepository.GetById(id));
        }

        public void Create(ProductViewModel categoryViewModel)
        {
            var createCommand = _mapper.Map<CreateNewProductCommand>(categoryViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveProductCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(ProductViewModel categoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProductCommand>(categoryViewModel);
            Bus.SendCommand(updateCommand);
        }

        public IEnumerable<ProductViewModel> GetFilteredList(Expression<Func<ProductViewModel, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
