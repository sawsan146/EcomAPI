using AutoMapper;
using Ecom.core.DTOs;
using Ecom.core.Entities.Product;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {

        private readonly AppDbContext AppDbContext;
        private readonly IMapper mapper;
        private readonly IImageManagementalService imageManagementalService;


        public ProductRepository(AppDbContext appDbContext, IMapper mapper, IImageManagementalService imageManagementalService) : base(appDbContext)
        {
            AppDbContext = appDbContext;
            this.mapper = mapper;
            this.imageManagementalService = imageManagementalService;
        }


        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO is null) return false;

            var product = mapper.Map<Product>(productDTO);

            await AppDbContext.Products.AddAsync(product);

           await AppDbContext.SaveChangesAsync();

            var imgPath = await imageManagementalService.AddImgAsync(productDTO.Photos, productDTO.Name);
            var photo = imgPath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id,

            }).ToList();

            await AppDbContext.Photos.AddRangeAsync(photo);
            await AppDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(UpdateProductDTO productDTO)
        {
            if (productDTO is null) return false;

            var product = await AppDbContext.Products
                .Include(p => p.Photos)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Id == productDTO.Id);

            if (product is null) return false;

            mapper.Map(productDTO, product);

            var oldPhotos = await AppDbContext.Photos
                .Where(p => p.ProductId == productDTO.Id)
                .ToListAsync();

            foreach (var item in oldPhotos)
            {
                imageManagementalService.DeleteImgAsync(item.ImageName);
            }

            AppDbContext.Photos.RemoveRange(oldPhotos);

            if (productDTO.Photos is not null && productDTO.Photos.Count > 0)
            {
                var imgPath = await imageManagementalService.AddImgAsync(productDTO.Photos, productDTO.Name);

                var newPhotos = imgPath.Select(path => new Photo
                {
                    ImageName = path,
                    ProductId = product.Id,
                }).ToList();

                await AppDbContext.Photos.AddRangeAsync(newPhotos);
            }

            await AppDbContext.SaveChangesAsync();

            return true;
        }

        
        public async Task<bool> DeleteAsync(Product product)
        {
            if (product is null) return false;

            var photos = await AppDbContext.Photos
                .Where(p => p.ProductId == product.Id)
                .ToListAsync();

            foreach (var item in photos)
            {
                imageManagementalService.DeleteImgAsync(item.ImageName);
            }

            //AppDbContext.Photos.RemoveRange(photos);

            AppDbContext.Products.Remove(product);

            await AppDbContext.SaveChangesAsync();
            return true;
        }

    }
}
