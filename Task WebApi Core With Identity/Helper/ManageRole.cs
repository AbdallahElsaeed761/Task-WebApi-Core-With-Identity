using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Models;

namespace Task_WebApi_Core_With_Identity.Helper
{
    public class ManageRole
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;


        public ManageRole(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        // add to customer 

        public async Task<bool> AddToCustomerRole(ApplicationUser user)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync("Customer"))
                    await roleManager.CreateAsync(new IdentityRole("Customer"));

                if (await roleManager.RoleExistsAsync("Customer"))
                {
                    await userManager.AddToRoleAsync(user, "Customer");

                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


       

        // add to  Author

        public async Task<bool> AddToAuthorRole(ApplicationUser user)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync("Author"))
                    await roleManager.CreateAsync(new IdentityRole("Author"));

                if (await roleManager.RoleExistsAsync("Author"))
                {
                    await userManager.AddToRoleAsync(user, "Author");

                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }



        // add to  admin

        public async Task<bool> AddToSAdminRole(ApplicationUser user)
        {
            try
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                if (await roleManager.RoleExistsAsync("Admin"))
                {
                    await userManager.AddToRoleAsync(user, "Admin");

                }
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}
