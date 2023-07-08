using System.Collections.Generic;

namespace IOC.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }

        //navigation property
        public ICollection<Product> Products { get; set; }
    }
}