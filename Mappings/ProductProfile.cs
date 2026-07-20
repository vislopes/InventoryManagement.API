using AutoMapper;
using InventoryManagement.API.DTOs.Products;
using InventoryManagement.API.Entities;
using InventoryManagement.API;

namespace InventoryManagement.API.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponseDto>()
            .ForMember(
                dest => dest.Category,
                opt => opt.MapFrom(src => src.Category.Name)
            )
            .ForMember(
                dest => dest.Supplier,
                opt => opt.MapFrom(src => src.Supplier.Name)
            );

        CreateMap<CreateProductDto, Product>();

        CreateMap<UpdateProductDto, Product>();
    }
}