using AutoMapper;
using Ecom.core.Interfaces;
using Ecom.core.Services;
using Ecom.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _context;
        private readonly IMapper mapper;
        private readonly IImageManagementalService imageManagementalService;

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public UnitOfWork(AppDbContext context, IMapper mapper, IImageManagementalService imageManagementalService)
        {
            _context = context;
            this.mapper = mapper;
            this.imageManagementalService = imageManagementalService;
            CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context,mapper,imageManagementalService);
            PhotoRepository = new PhotoRepository(context);
         
        }
    }
}
