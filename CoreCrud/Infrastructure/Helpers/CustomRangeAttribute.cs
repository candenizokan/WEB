using System;
using System.ComponentModel.DataAnnotations;

namespace CoreCrud.Infrastructure.Helpers
{
    public class CustomRangeAttribute : RangeAttribute
    {

        //yönetmen kişim 18-110 yaş aralığında olabilir.
        public CustomRangeAttribute() : base(typeof(DateTime),DateTime.Now.AddYears(-110).ToString(),DateTime.Now.AddYears(-18).ToString())
        {
        }
    }
}
