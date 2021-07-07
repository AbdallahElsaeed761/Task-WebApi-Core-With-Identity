using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Helper
{
    public class ResponseAuth
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
       
    }
}
