using App.Application.ViewModels.Shop;
using App.Domain.Commands.Shop.Category;
using App.Domain.Commands.Shop.Comment;
using App.Domain.Commands.Shop.Detail;
using App.Domain.Commands.Shop.Image;
using App.Domain.Commands.Shop.Product;
using App.Domain.Commands.Shop.Seller;
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

            CreateMap<CommentViewModel, CreateNewCommentCommand>()
                .ConstructUsing(c => new CreateNewCommentCommand(c.CommentId, c.CommentContent, c.Product, c.UserId));
            CreateMap<CommentViewModel, UpdateCommentCommand>()
                .ConstructUsing(c => new UpdateCommentCommand(c.CommentId, c.CommentContent, c.Product, c.UserId));

            CreateMap<DetailViewModel, CreateNewDetailCommand>()
                .ConstructUsing(c => new CreateNewDetailCommand(c.DetailId, c.DetailName, c.DetailFeature, c.Category));
            CreateMap<DetailViewModel, UpdateDetailCommand>()
                .ConstructUsing(c => new UpdateDetailCommand(c.DetailId, c.DetailName, c.DetailFeature, c.Category));

            CreateMap<ImageViewModel, CreateNewImageCommand>()
                .ConstructUsing(c => new CreateNewImageCommand(c.ImageId, c.ImageLink, c.ProfileImage, c.Product));
            CreateMap<ImageViewModel, UpdateImageCommand>()
                .ConstructUsing(c => new UpdateImageCommand(c.ImageId, c.ImageLink, c.ProfileImage, c.Product));

            CreateMap<ProductViewModel, CreateNewProductCommand>()
                .ConstructUsing(c => new CreateNewProductCommand(c.ProductId, c.ProductName, c.Category, c.Detail, c.Seller, c.Image));
            CreateMap<ProductViewModel, UpdateProductCommand>()
                .ConstructUsing(c => new UpdateProductCommand(c.ProductId, c.ProductName, c.Category, c.Detail, c.Seller, c.Image));

            CreateMap<SellerViewModel, CreateNewSellerCommand>()
                .ConstructUsing(c => new CreateNewSellerCommand(c.SellerId, c.Name, c.Email, c.PhoneNumber));
            CreateMap<SellerViewModel, UpdateSellerCommand>()
                .ConstructUsing(c => new UpdateSellerCommand(c.SellerId, c.Name, c.Email, c.PhoneNumber));

        }
    }
}
