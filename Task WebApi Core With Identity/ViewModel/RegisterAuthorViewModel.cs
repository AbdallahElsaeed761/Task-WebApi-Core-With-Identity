using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.ViewModel
{
    public class RegisterAuthorViewModel
    {
        [Required]
        [RegularExpression("^01[0125][0-9]{8}$")]
        public string PhoneNumber { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string StoreName { get; set; }

    }
}
