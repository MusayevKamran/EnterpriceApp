using App.Application.EventSourcedNormalizers.Shop.Image;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface IImageAppService : IAppService<ImageViewModel, ImageHistoryData>
    {
    }
}
