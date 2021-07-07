using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class ShoppingBasketBook
    {
        public int ID { get; set; }
        public int Count { get; set; }
        //forignKey Customer & Book
        public virtual List<Book> Books { get; set; }
        [ForeignKey("Customer")]
        public string CustomerID { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
