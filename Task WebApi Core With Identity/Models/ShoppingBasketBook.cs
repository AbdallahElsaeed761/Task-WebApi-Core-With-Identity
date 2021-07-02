using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class ShoppingBasketBook
    {
        public int ID { get; set; }
        public int Count { get; set; }
        //forignKey Customer & Book
    }
}
