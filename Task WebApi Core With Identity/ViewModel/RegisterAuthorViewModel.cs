using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.ViewModel
{
    public class RegisterAuthorViewModel:RegisterViewModel
    {
        public DateTime PublishDate { get; set; }

        [Required]
        public float SalaryOfBook { get; set; }

    }
}
