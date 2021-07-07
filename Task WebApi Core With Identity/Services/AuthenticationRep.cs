using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Helper;
using Task_WebApi_Core_With_Identity.Models;
using Task_WebApi_Core_With_Identity.ViewModel;

namespace Task_WebApi_Core_With_Identity.Services
{
    public class AuthenticationRep
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MyDbContext _db;
        private ManageRole _manageRoles;
        
        

        public AuthenticationRep(UserManager<ApplicationUser> userManager, ManageRole manageRoles,MyDbContext db)
        {
            _db = db;
            _manageRoles = manageRoles;
            _userManager = userManager;
           
           


        }
        //register As Customer
        public async Task<ResponseAuth> RegisterCustomerAsync(RegisterViewModel model)
        {
            string username = model.Email.Split('@')[0];

            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return new ResponseAuth { Message = "Email is already Exist" };

            if (await _userManager.FindByNameAsync(username) != null)
                return new ResponseAuth { Message = "Username is already Exist" };

            ApplicationUser user = new ApplicationUser()
            {
                Fname = model.Fname,
                Lname = model.Lname,
                Address = model.Address,
                Email = model.Email,
                UserName = username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}";
                }
                return new ResponseAuth { Message = errors };

            }

            // _customerRepo.AddCustomerId(user.Id);
            _db.Customers.Add(new Customer());
            _db.SaveChanges();

            await _manageRoles.AddToCustomerRole(user);
            //var token = await CreateJwtToken(user);
            return new ResponseAuth
            {
                Email = user.Email,
                UserName = username,
                Role = "Customer",
             

            };



        }
        public async Task<ResponseAuth> RegisterAuthorAsync(RegisterAuthorViewModel model)
        {
            string username = model.Email.Split('@')[0];

            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return new ResponseAuth { Message = "Email is already Exist" };

            if (await _userManager.FindByNameAsync(username) != null)
                return new ResponseAuth { Message = "Username is already Exist" };

            ApplicationUser user = new ApplicationUser()
            {
                Fname = model.Fname,
                Lname = model.Lname,
                Address = model.Address,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}";
                }
                return new ResponseAuth { Message = errors };

            }


            await _manageRoles.AddToAuthorRole(user);
            
            return new ResponseAuth
            {
                Email = user.Email,
                UserName = username,
                Role = "Author",


            };
            

        }

        //register Admin
        public async Task<ResponseAuth> RegisterAdminAsync(RegisterViewModel model)
        {
            string username = model.Email.Split('@')[0];
            if (await _userManager.FindByEmailAsync(model.Email) != null)
                return new ResponseAuth { Message = "Email is already Exist" };

            if (await _userManager.FindByNameAsync(username) != null)
                return new ResponseAuth { Message = "Username is already Exist" };

            ApplicationUser user = new ApplicationUser()
            {
                Fname = model.Fname,
                Lname = model.Lname,
                Address = model.Address,
                Email = model.Email,
                UserName = username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = "";
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description}";
                }
                return new ResponseAuth { Message = errors };

            }

            await _manageRoles.AddToSAdminRole(user);
            
            return new ResponseAuth
            {
                Email = user.Email,
                UserName = username,
                Role = "Admin",
               

            };
        }
    }
}
