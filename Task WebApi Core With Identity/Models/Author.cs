using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class Author
    {
        [ForeignKey("ApplicationUser")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AuthorID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
       
        public virtual List<Book> Books { get; set; }
    }
}
