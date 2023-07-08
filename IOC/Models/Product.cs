namespace IOC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        // navigation prop => bu sınıfın başka sınıflarla olan ilişkisini veritabanında açıklamk için kullanılan proplar.
        public int? CategoryId { get; set; } // ? anlamı şudur buradaki property nullable oluşur
        public Category Category { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        // iki şekilde veri çekebilirim. LAZY LOADING ve EAGER LOAFING
        // defaultta yukarıdaki gibi yaparsam EAGER yapar.
        // LAZY olmasını isterse VIRTUAL keyword eklenmeli ve proxy paketi eklenmelidir
    }
}
