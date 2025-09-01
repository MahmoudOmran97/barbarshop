using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace el_shabander
{  
    public class recpeipt
    {
       // public int id { get; set; }
        public string productname { get; set; }
       // [Display(Name = "اسم المادة")]
        public double price { get; set; }
       // [Display(Name = "سعر الوحدة")]
        public double qt { get; set; }
        //[Display(Name = "الكمية")]
        public double tprice { get; set; }
        //[Display(Name = "السعر الكلى")]

    }
}
