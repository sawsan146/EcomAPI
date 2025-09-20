using AutoMapper;
using Ecom.core.DTOs;
using Ecom.API.Helper;
using Ecom.core.Entities.Product;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products= await unitOfWork.ProductRepository
                    .GetAllAsync(x=>x.Category,x=>x.Photos);

                if (products is null) return BadRequest(new ResponseAPI(400));
                var result = mapper.Map<List<ProductDTO>>(products);
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var Product = await unitOfWork.ProductRepository.GetByIdAsync(id,x=>x.Category,x=>x.Photos);
                if (Product is null) return BadRequest(new ResponseAPI(400));

                var result=mapper.Map<ProductDTO>(Product);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }

        [HttpPost("Add Product")]
        public async Task<IActionResult> Add(AddProductDTO productDTO )
        {
            try
            {
                await unitOfWork.ProductRepository.AddAsync(productDTO);
             
                return Ok(new ResponseAPI(200,"Product Added"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400,ex.Message));
            }
        }



        [HttpPut("Update Product")]
        public async Task<IActionResult> Update(UpdateProductDTO updateProductDTO)
        {
            try
            {
                await unitOfWork.ProductRepository.UpdateAsync(updateProductDTO);
          
                return Ok(new ResponseAPI(200, "Item has been Updated"));


            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        [HttpDelete("Delete Product")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await unitOfWork.ProductRepository.GetByIdAsync(id, p => p.Photos, p => p.Category);
                if (product is null) return BadRequest(new ResponseAPI(400, "Item Not Found"));
                await unitOfWork.ProductRepository.DeleteAsync(product);

                return Ok(new ResponseAPI(200, "Item has been Deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));

            }

        }


    }
}
