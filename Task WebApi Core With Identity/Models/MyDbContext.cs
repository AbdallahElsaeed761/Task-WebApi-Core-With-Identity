using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task_WebApi_Core_With_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Fname { get; set; }



        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Lname { get; set; }



        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Address { get; set; }


        [StringLength(maximumLength: 6, MinimumLength = 1)]
        public string Gender { get; set; }


        [Range(18, 100, ErrorMessage = "you should more than or equal 18")]
        public byte Age { get; set; }


    }
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {

        public ApplicationUserStore() : base(new MyDbContext())
        {

        }
        public ApplicationUserStore(DbContext db) : base(db)
        {

        }
    }
    public class MyDbContext:IdentityDbContext<ApplicationUser>
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
        public MyDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }


        //public DbContext() : base("Data Source=DESKTOP-GF4P384\ABDALLAHSQL;Initial Catalog=EmployeeForEF;Integrated Security=True")
        //{

        //}
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<ShoppingBasketBook> ShoppingBasketBooks { get; set; }

    }
   
}
