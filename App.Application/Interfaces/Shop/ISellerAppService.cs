using App.Application.EventSourcedNormalizers.Shop.Seller;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface ISellerAppService : IAppService<SellerViewModel, SellerHistoryData>
    {
    }
}
