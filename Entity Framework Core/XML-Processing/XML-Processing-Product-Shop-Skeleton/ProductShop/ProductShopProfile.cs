using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<UsersInputDto, User>();
            CreateMap<ProductsInputDto, Product>();
            CreateMap<CategoriesInputDto, Category>();
            CreateMap<CategoriesProductsInputDto, CategoryProduct>();

            CreateMap<Product, ProductsExportDto>();
        }
    }
}
