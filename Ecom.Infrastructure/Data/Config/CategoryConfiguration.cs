using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Description).IsRequired();

            //seed data only if it is empty
            builder.HasData(
                new Category { Id = 1, Description = "test", Name = "Test" }
               );
        }
    }
}
