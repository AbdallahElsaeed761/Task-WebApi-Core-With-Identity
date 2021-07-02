using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gmail { get; set; }
        [Required]
       

        public int  Phone { get; set; }
        public string Address { get; set; }
    }
}
