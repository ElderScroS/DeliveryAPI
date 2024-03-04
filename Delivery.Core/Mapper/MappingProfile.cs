using AutoMapper;
using Delivery.Core.Domain.Entities;
using Delivery.Core.DTO;
using Type = System.Type;

namespace Delivery.Core.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, GetCategoryMiniDto>()
            .ForMember(dest => dest.ProductsQuantity, opt => opt.MapFrom(src => src.Products.Count));

        CreateMap<Category, GetCategoryDto>();

        CreateMap<Product, GetProductMiniDto>()
            .ForMember(dest => dest.ProductImageUrl, opt => opt.MapFrom(src => src.ImageUrls[0]))
            .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => src.ProductType.Name));

        CreateMap<Product, GetProductDto>()
            .ForMember(dest => dest.ProductTypeName, opt => opt.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));


        CreateMap<ProductType, GetProductTypeDto>()
            .ForMember(dest => dest.ProductsQuantity, opt => opt.MapFrom(src => src.Products.Count));

    }
}