using App.Domain.Interfaces;
using App.Infrastructure.Data.Context;

namespace App.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ShopDbContext _context;
        public UnitOfWork(ShopDbContext context)
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
