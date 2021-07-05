using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class Book
    {

        public int BookId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string BookName { get; set; }

        [Required]
        [Range(5, maximum: 100000)]
        public float Price { get; set; }


        /// <summary>   start  update one   /// </summary>

        public double? Discount { get; set; }

        

        [Required]
        [StringLength(maximumLength: 1000, MinimumLength = 50)]
        public string Description { get; set; }
        //[ForeignKey("Customer")]
        //public int CustomerId { get; set; }


        //public virtual Customer Customer { get; set; }
        [ForeignKey("Author")]
        public string authorId { get; set; }


        public virtual Author Author { get; set; }
        [ForeignKey("ShoppingBasketBook")]
        public int ShoppingBasketBookID { get; set; }


        public virtual ShoppingBasketBook ShoppingBasketBook { get; set; }


    }
}
