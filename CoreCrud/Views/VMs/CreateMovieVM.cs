using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CoreCrud.Views.VMs
{
    public class CreateMovieVM
    {
        //MOVİE--film için iki input açarım kullanıcının yazdığını alırım
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }

        //DIRECTOR-- bir filmin bir directorunu seçmeli. on tanesini götüreyim taşıyım o içinden bir tane seçsin. o seçileneni almam için DirectorID lazım
        public int DirectorID { get; set; }
        public List<SelectListItem> Directors { get; set; }

        //ACTOR--birden fazla actoru olabilir. o yüzden actorID tutmadım. aktörleri aktör olarak gönderme Actor sınıfını traşla yani dto yap. onu göster

        public List<ActorDTO> Actors { get; set; }
    }
}
