using App.Application.EventSourcedNormalizers.Shop.Image;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Image;
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
    public class ImageAppService : IImageAppService
    {
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ImageAppService(IMapper mapper,
                                  IImageRepository imageRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _imageRepository = imageRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ImageViewModel> GetAll()
        {
            return _imageRepository.GetAll().ProjectTo<ImageViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<ImageHistoryData> GetAllHistory(int id)
        {
            return ImageHistory.ToJavaScriptImageHistory(_eventStoreRepository.All(id));
        }

        public ImageViewModel GetById(int id)
        {
            return _mapper.Map<ImageViewModel>(_imageRepository.GetById(id));
        }

        public void Create(ImageViewModel imageViewModel)
        {
            var createCommand = _mapper.Map<CreateNewImageCommand>(imageViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveImageCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(ImageViewModel imageViewModel)
        {
            var updateCommand = _mapper.Map<UpdateImageCommand>(imageViewModel);
            Bus.SendCommand(updateCommand);
        }

        public IEnumerable<ImageViewModel> GetFilteredList(Expression<Func<ImageViewModel, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
