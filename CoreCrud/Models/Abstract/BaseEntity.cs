using System;

namespace CoreCrud.Models.Abstract
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private bool _isActive=true;//defaultta hepsi true. silmek aslında burada activitesini false yapmak

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive= value; }
        }

    }
}
