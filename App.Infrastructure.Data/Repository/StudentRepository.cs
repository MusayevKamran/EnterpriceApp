using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace App.Infrastructure.Data.Repository
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
