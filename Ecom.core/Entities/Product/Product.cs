using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.Entities.Product
{
    public class Product:BaseEntity<int>
    {
        public string  Name { get; set; }
        public string Description { get; set; }

        public decimal price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        // virtual:
        // - في Navigation Properties: بتسمح للـ EF Core يعمل Proxy → 
        //   ضرورية لو عايزين Lazy Loading.
        public virtual Category Category { get; set; }

        public virtual List<Photo> Photos { get; set; }


    }
}
