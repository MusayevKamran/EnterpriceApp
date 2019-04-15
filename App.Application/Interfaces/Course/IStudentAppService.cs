using App.Application.EventSourcedNormalizers.Course;
using App.Application.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Application.Interfaces.Course
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
