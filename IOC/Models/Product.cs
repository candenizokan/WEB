namespace IOC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
