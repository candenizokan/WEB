using CoreCrud.Infrastructure.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models.DTOs
{
    public class UpdateDirectorDTO
    {
        public int ID { get; set; } //kullanıcı görmez, değiştiremez. sadece posta düştüğünde kimin güncelleneceğinin bilinmesi gerekiyordu bu yüzden posta taşıdık

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")] // boş bırakılamaz
        [MinLength(2, ErrorMessage = "İsim en az 2 karakter olmalı")] //min karakter sayısı
        [MaxLength(20, ErrorMessage = "İsim en fazla 20 karakter olmalı")]//max karakter sayısı
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")] // boş bırakılamaz
        [MinLength(2), MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen tarih giriniz")]
        [CustomRangeAttribute(ErrorMessage = "girilen tarih 18 yıl ve 110 yıl öncesinde olmalıdır.")]
        public DateTime? BirthDate { get; set; }
    }
}
