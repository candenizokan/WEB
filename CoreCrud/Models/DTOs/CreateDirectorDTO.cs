using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models.DTOs
{
    public class CreateDirectorDTO
    {
        // oluşturduğumuz DTO larla iş yaparken bazı kurallar koyup çalıştırdığımız dto nun bizim için geçerli (validate) olmasını istriz. Bunun için daha bilgileri frontta yani ön yüzü kontrol eden, arkaya hemen göndermeyen DataAnnotations kütüphanesini kullanarak bu kütüphanenin attributelerinden faydalanabiliriz.

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")] // boş bırakılamaz
        [MinLength(2, ErrorMessage = "İsim en az 2 karakter olmalı")] //min karakter sayısı
        [MaxLength(20, ErrorMessage = "İsim en fazla 20 karakter olmalı")]//max karakter sayısı
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")] // boş bırakılamaz
        [MinLength(2), MaxLength(30)] 
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen tarih giriniz")]
        public DateTime? BirthDate { get; set; }
    }
}
