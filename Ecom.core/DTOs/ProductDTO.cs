using Ecom.core.Entities.Product;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecom.core.DTOs
{
    public record ProductDTO
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public decimal price { get; set; }

        public string CategoryName { get; set; }
       
        public List<PhotoDTO> Photos { get; set; }


    }
     
    public record PhotoDTO
    {
        public string ImageName { get; set; }

        public int ProductId { get; set; }
    }

    public record AddProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }

        public int CategoryId { get; set; }

        public IFormFileCollection Photos { get; set; }
    }

    public record UpdateProductDTO: AddProductDTO
    {
        public int Id { get; set; }
      
    }
}
