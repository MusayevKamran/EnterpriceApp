using App.Application.EventSourcedNormalizers.Shop.Comment;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface ICommentAppService : IAppService<CommentViewModel, CommentHistoryData>
    {
    }
}
