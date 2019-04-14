using App.Domain.Interfaces;
using App.Infrastructure.Data.Context;

namespace App.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
