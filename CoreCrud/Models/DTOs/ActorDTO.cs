namespace CoreCrud.Models.DTOs
{
    public class ActorDTO
    {
        //kullanıcıya has validasyon kontrolüne gerek yok. saten dolu olarak viewa gidecek bunlar yapıldı.

        public string FullName { get; set; }//kullanıcıya göstemek için
        public int ActorID { get; set; }//arka planda almak için ıd sini alıyorum
        public bool IsSelected { get; set; }//seçilip seçilmediğini almak için
    }
}
