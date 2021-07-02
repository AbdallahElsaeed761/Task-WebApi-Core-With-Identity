using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class Book
    {
        
        public int  Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
