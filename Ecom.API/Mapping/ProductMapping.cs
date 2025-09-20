using AutoMapper;
using Ecom.core.DTOs;
using Ecom.core.Entities.Product;

namespace Ecom.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(p => p.CategoryName,
                    op => op.MapFrom(src => src.Category.Name))
                .ReverseMap();

            CreateMap<Photo, PhotoDTO>().ReverseMap();

            CreateMap<AddProductDTO, Product>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore()).ReverseMap();

            CreateMap<UpdateProductDTO, Product>()
                .ForMember(dest => dest.Photos, opt => opt.Ignore()).ReverseMap();
                
        }
    }

}
