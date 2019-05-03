using App.Application.EventSourcedNormalizers.Shop.Comment;
using App.Application.Interfaces.Shop;
using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Comment;
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
    public class CommentAppService : ICommentAppService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public CommentAppService(IMapper mapper,
                                  ICommentRepository commentRepository,
                                  IMediatorHandler bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<CommentViewModel> GetAll()
        {
            return _commentRepository.GetAll().ProjectTo<CommentViewModel>(_mapper.ConfigurationProvider);
        }

        public IList<CommentHistoryData> GetAllHistory(int id)
        {
            return CommentHistory.ToJavaScriptCommentHistory(_eventStoreRepository.All(id));
        }

        public CommentViewModel GetById(int id)
        {
            return _mapper.Map<CommentViewModel>(_commentRepository.GetById(id));
        }

        public void Create(CommentViewModel commentViewModel)
        {
            var createCommand= _mapper.Map<CreateNewCommentCommand>(commentViewModel);
            Bus.SendCommand(createCommand);
        }

        public void Remove(int id)
        {
            var removeCommand = new RemoveCommentCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Update(CommentViewModel commentViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCommentCommand>(commentViewModel);
            Bus.SendCommand(updateCommand);
        }
    }
}
