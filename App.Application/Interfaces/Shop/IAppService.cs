using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Shop
{
    public interface IAppService<ViewModel, HistoryData> : IDisposable
    {
        void Create(ViewModel viewModel);
        IEnumerable<ViewModel> GetAll();
        ViewModel GetById(int id);
        void Update(ViewModel viewModel);
        void Remove(int id);
        IList<HistoryData> GetAllHistory(int id);
    }
}
