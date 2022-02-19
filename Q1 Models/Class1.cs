using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DotNetExam.Models
{
    public class Class1
    {
        [Key]
        public int ProductId { get; set; }
        
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        
        public decimal Rate { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

    }
}