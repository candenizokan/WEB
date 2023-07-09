using CoreCrud.Models.Abstract;
using System;
using System.Collections.Generic;

namespace CoreCrud.Models.Concrete
{
    public class Actor : BaseEntity
    {
        public Actor()
        {
            MovieActors = new List<MovieActor>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }//nullable olabilir.

        public string FullName => FirstName + " " + LastName;

        //navigation property

        //1 oyuncunun çokça filmi olabilir
        public virtual List<MovieActor> MovieActors { get; set; }
    }
}
