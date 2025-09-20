using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data.Config
{
    /* IEntityTypeConfiguration<T>:
     - Interface من EF Core بنستخدمه عشان نعمل Configuration للـ Entity.
     - بيجبرنا نكتب method Configure(EntityTypeBuilder<T> builder).
     - جواها بنحط rules زي HasKey, Property, Relationships.
     - الهدف: فصل القواعد (Fluent API) عن DbContext عشان الكود يبقى منظم.*/

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.NewPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(p=>p.OldPrice).HasColumnType("decimal(18,2)");

            builder.HasData(
                new Product { Id = 1, Name = "Test", CategoryId = 1, Description = "Test", NewPrice = 2000 });
        }
    }
}
