using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Category;
using AutoMapper;

namespace App.Application.AutoMapper.Shop
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, CreateNewCategoryCommand>()
                .ConstructUsing(c => new CreateNewCategoryCommand(c.CategoryId, c.CategoryName));
            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(c.CategoryId, c.CategoryName));
        }
    }
}
