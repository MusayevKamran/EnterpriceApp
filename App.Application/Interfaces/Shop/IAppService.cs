using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface IAppService<TViewModel, THistoryData> : IDisposable
    {
        void Create(TViewModel viewModel);
        IEnumerable<TViewModel> GetAll();
        IEnumerable<TViewModel> GetFilteredList(Expression<Func<TViewModel, bool>> filter);
        TViewModel GetById(int id);
        void Update(TViewModel viewModel);
        void Remove(int id);
        IList<THistoryData> GetAllHistory(int id);
    }
}
