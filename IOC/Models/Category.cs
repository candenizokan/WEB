using System.Collections.Generic;

namespace IOC.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //bir kategorinin çokça ürünü olur. çokluk yapısını koleksiyon yapısında tutarım

        public ICollection<Product> Products { get; set; }
    }
}