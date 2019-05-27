using App.Application.EventSourcedNormalizers.Shop.Category;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Category;
using App.Domain.Core.Bus;
using App.Domain.Interfaces.Shop;
using App.Infrastructure.Data.Repository.EventSourcing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace App.Application.Services.Shop
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CategoryAppService(IMapper mapper,
                                  ICategoryRepository categoryRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }
        public IEnumerable<CategoryViewModel> GetFilteredList(Expression<Func<CategoryViewModel, bool>> filter)
        {
            return filter == null
               ? _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider)
               : _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider).Where(filter);
        }
        public IList<CategoryHistoryData> GetAllHistory(int id)
        {
            return CategoryHistory.ToJavaScriptCategoryHistory(_eventStoreRepository.All(id));
        }

        public CategoryViewModel GetById(int id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public void Create(CategoryViewModel categoryViewModel)
        {
            var createCommand = _mapper.Map<CreateNewCategoryCommand>(categoryViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveCategoryCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
