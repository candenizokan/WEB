using CoreCrud.Models.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Models.VMs
{
    public class UpdateMovieVM
    {
        //Movie

        //sıfırdan film yaratmı9yorum. ilgili nesnenin id sine gerek var burada. kimi güncelleyeceğimi bilmem için id lazım onu getirmem lazım. 
        public int MovieID { get; set; }//post'a düşüldüğünde hangi filmi güncelleyeceğini bilmeliyim

        [Required(ErrorMessage = "İsimsiz film olamaz.")]
        public string Name { get; set; } // kullanıcıdan almam gerek. bu durumda validasyon gerekiyor.

        [Required(ErrorMessage = "Çıkış tarihi boş olamaz.")]
        public DateTime PublishDate { get; set; } // kullanıcıdan almam gerek. bu durumda validasyon gerekiyor.


        //Directors

        //yönetmenin id si lazım ve bu benim için gerekli
        [Required(ErrorMessage = "lütfen yönetmen seç")]
        public int DirectorID { get; set; }

        //sahip olduum tüm yönetmenleri götürmeliyim

        public List<SelectListItem> Directors { get; set; }//bir tanesini seçtirim oda benim directorid olur

        //Actors

        //list yapısı içinde actorDto ile alabilirim

        public List<ActorDTO> Actors { get; set; }
    }
}
