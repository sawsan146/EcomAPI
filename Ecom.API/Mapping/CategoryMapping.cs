using AutoMapper;
using Ecom.core.DTOs;
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
