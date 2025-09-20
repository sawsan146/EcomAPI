using Ecom.core.DTOs;
using Ecom.core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Interfaces
{
    public interface IProductRepository:IGenericRepository<Product>
    {
       Task<bool> AddAsync(AddProductDTO productDTO);
       Task<bool> UpdateAsync(UpdateProductDTO productDTO);
       Task<bool> DeleteAsync(Product product);

    }
}
