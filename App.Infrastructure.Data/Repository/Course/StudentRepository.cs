using App.Domain.Interfaces.Course;
using App.Domain.Models.Course;
using App.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infrastructure.Data.Repository.Course
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDbContext context) : base(context)
        { }

        public Student GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }
    }
}
