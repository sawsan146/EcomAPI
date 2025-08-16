using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions) 
        {
            
        }
        // - في DbSet داخل DbContext: ملهاش علاقة بالـ Lazy Loading، 
        //   لكن بتفيد في Unit Testing (Mocking/Overriding).
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Explain
            // ApplyConfigurationsFromAssembly:
            // - Extension Method من EF Core بتسجل أوتوماتيك كل الكلاسات
            //   اللي بتطبق IEntityTypeConfiguration<T>.
            // - Assembly.GetExecutingAssembly(): من .NET Reflection 
            //   معناها هات الـ Assembly (المشروع) الحالي اللي الكود بيتنفذ منه.
            // - الهدف: بدل ما نكتب ApplyConfiguration لكل Entity واحدة واحدة،
            //   السطر ده بيجمعهم كلهم مرة واحدة. 
            #endregion

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }





    }
}
