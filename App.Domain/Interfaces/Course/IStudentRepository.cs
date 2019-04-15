using App.Domain.Models.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Interfaces.Course
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByEmail(string email);
    }
}
