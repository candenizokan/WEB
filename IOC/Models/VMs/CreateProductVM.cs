using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IOC.Models.VMs
{
    public class CreateProductVM
    {
        //1 tane product nesne

        public Product Product { get; set; }

        //tüm kategoriler

        public List<SelectListItem> Categories { get; set; }

        //tüm tedarikçileri
        public List<SelectListItem> Suppliers { get; set; }
    }
}
