using App.Application.EventSourcedNormalizers.Shop.Category;
using App.Application.ViewModels.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface ICategoryAppService : IDisposable
    {
        void Create(CategoryViewModel categoryViewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetById(Guid id);
        void Update(CategoryViewModel categoryViewModel);
        void Remove(Guid id);
        IList<CategoryHistoryData> GetAllHistory(Guid id);
    }
}
