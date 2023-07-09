﻿using CoreCrud.Models.Abstract;
using System;
using System.Collections.Generic;

namespace CoreCrud.Models.Concrete
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }

        //navigation property

        //1 filmin 1 yönetmeni vardır

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        //1 filmin çokça oyuncusu vardır
        public List<MovieActor> MovieActor { get; set; }
    }
}
