using App.Domain.Models.Shop;


namespace App.Domain.Interfaces.Shop
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        Category GetByIdNoTracking(int id);
    }
}
