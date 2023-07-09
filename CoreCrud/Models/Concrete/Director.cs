using CoreCrud.Models.Abstract;
using System;
using System.Collections.Generic;

namespace CoreCrud.Models.Concrete
{
    public class Director:BaseEntity
    {

        // bir sınıfın içinde başka sınıfın elemanlarını taşıyorsam ctorda çağırayım
        public Director()
        {
            Movies = new List<Movie>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }//nullable olabilir.

        public string FullName => FirstName + " " + LastName;

        //navigation property

        //1 yönetmenin çokça filmi olabilir
        public virtual List<Movie> Movies { get; set; }
    }
}