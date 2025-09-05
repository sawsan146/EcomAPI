﻿using Ecom.core.Interfaces;
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

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPhotoRepository PhotoRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepository=new CategoryRepository(context);
            ProductRepository=new ProductRepository(context);
            PhotoRepository=new PhotoRepository(context);
        }
    }
}
