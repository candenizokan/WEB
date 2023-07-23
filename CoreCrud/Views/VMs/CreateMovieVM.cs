using CoreCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Views.VMs
{
    public class CreateMovieVM
    {
        //MOVİE--film için iki input açarım kullanıcının yazdığını alırım

        [Required(ErrorMessage ="İsimsiz film olamaz.")]
        public string Name { get; set; } // kullanıcıdan almam gerek. bu durumda validasyon gerekiyor.

        [Required(ErrorMessage = "Çıkış tarihi boş olamaz.")]
        public DateTime PublishDate { get; set; } // kullanıcıdan almam gerek. bu durumda validasyon gerekiyor.

        //DIRECTOR-- bir filmin bir directorunu seçmeli. on tanesini götüreyim taşıyım o içinden bir tane seçsin. o seçileneni almam için DirectorID lazım
        [Required(ErrorMessage = "Yönetmen Seçiniz")]
        public int DirectorID { get; set; }
        public List<SelectListItem> Directors { get; set; } // bütün directorleri çağır selectlistitem nesnesi yarat

        //ACTOR--birden fazla actoru olabilir. o yüzden actorID tutmadım. aktörleri aktör olarak gönderme Actor sınıfını traşla yani dto yap. onu göster

        public List<ActorDTO> Actors { get; set; }
    }
}
