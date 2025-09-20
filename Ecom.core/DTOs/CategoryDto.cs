namespace Ecom.core.DTOs
{
    public record CategoryDto
    (string Name,string Description);
    public record UpdateCategoryDto
   (string Name, string Description,int id);
     
}
