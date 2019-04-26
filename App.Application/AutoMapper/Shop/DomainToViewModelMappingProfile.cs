using App.Application.ViewModels.Shop;
using App.Domain.Models.Shop;
using AutoMapper;


namespace App.Application.AutoMapper.Shop
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
