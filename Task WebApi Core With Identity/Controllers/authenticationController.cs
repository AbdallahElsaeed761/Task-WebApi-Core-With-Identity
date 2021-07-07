using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task_WebApi_Core_With_Identity.Models;
using Task_WebApi_Core_With_Identity.Services;
using Task_WebApi_Core_With_Identity.ViewModel;

namespace Task_WebApi_Core_With_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly AuthenticationRep _authentication;

        public authenticationController(UserManager<ApplicationUser> userManager, AuthenticationRep authentication)
        {
            this.userManager = userManager;
            _authentication = authentication;
        }
        // sign up customer 

        [HttpPost]
        [Route("register-customer")]

        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authentication.RegisterCustomerAsync(model);
                
                return Ok(result);
            }
            return BadRequest(ModelState);
        }

        // sign up Author
        [HttpPost]
        [Route("register-emplyee")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAuthor([FromBody] RegisterAuthorViewModel model)
        {

            if (ModelState.IsValid)
            {
               
                    var result = await _authentication.RegisterAuthorAsync(model);
                   
                
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
        //register Admin
        [HttpPost]
        [Route("register-admin")]

        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authentication.RegisterAdminAsync(model);
               
                return Ok(result);
            }
            return BadRequest(ModelState);
        }
    }

}
