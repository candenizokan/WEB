using CoreCrud.Models.Abstract;
using System;

namespace CoreCrud.Models.Concrete
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }//nullable olabilir.

        public string FullName => FirstName + " " + LastName;
    }
}
