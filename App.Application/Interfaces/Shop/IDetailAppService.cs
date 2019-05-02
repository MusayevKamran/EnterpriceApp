using App.Application.EventSourcedNormalizers.Shop.Detail;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface IDetailAppService : IAppService<DetailViewModel, DetailHistoryData>
    {
    }
}
