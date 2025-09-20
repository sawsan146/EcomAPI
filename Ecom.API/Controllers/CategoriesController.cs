using AutoMapper;
using Ecom.core.DTOs;
using Ecom.API.Helper;
using Ecom.core.Entities.Product;
using Ecom.core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecom.API.Helper;

namespace Ecom.API.Controllers
{

    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet("Get-All")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categories = await unitOfWork.CategoryRepository.GetAllAsync();
                if (categories is null)
                    return BadRequest(new ResponseAPI(400));

                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var categories= await unitOfWork.CategoryRepository.GetByIdAsync(id);  
                if(categories is null) return BadRequest(new ResponseAPI(400));

                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }

        }

        [HttpPost("Add Category")]
        public async Task<IActionResult> Add(CategoryDto categoryDto)
        {
            try
            {
                var category =mapper.Map<Category>(categoryDto);

                await unitOfWork.CategoryRepository.AddAsync(category);
                return Ok(new ResponseAPI(200,  "Item has been added"));


            }
            catch(Exception ex) 
            {
                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        
        [HttpPut("Update Category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDTO)
        {
            try
            {
                var category =mapper.Map<Category>(categoryDTO);
                await unitOfWork.CategoryRepository.UpdateAsync(category);
                return Ok(new ResponseAPI(200, "Item has been Updated"));


            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));
            }
        }


        [HttpDelete("Delete Category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await unitOfWork.CategoryRepository.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been Deleted"));


            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseAPI(400, ex.Message));

            }

        }


    }
}
