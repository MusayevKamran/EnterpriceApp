using App.Application.EventSourcedNormalizers;
using App.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces
{
    public interface IStudentAppService : IDisposable
    {
        void Register(StudentViewModel studentViewModel);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(Guid id);
        void Update(StudentViewModel studentViewModel);
        void Remove(Guid id);
        IList<StudentHistoryData> GetAllHistory(Guid id);
    }
}
