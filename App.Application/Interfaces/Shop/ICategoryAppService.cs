using App.Application.EventSourcedNormalizers.Shop.Category;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface ICategoryAppService : IAppService<CategoryViewModel, CategoryHistoryData>
    { }
}
