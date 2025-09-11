using AutoMapper;
using Ecom.API.DTOs;
using Ecom.core.Entities.Product;

namespace Ecom.API.Mapping
{
    public class CategoryMapping :Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDto,Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }

    }
}
