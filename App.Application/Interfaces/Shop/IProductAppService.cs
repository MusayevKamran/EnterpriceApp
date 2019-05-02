using App.Application.EventSourcedNormalizers.Shop.Product;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface IProductAppService : IAppService<ProductViewModel, ProductHistoryData>
    { }
}
