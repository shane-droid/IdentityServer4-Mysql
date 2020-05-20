using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServerMysql.AspNetIdentity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerMysql.AspNetIdentity.Controllers
{
    public class AuthController : Controller
    {   
        // AspNetId SignInManager : deals out cookies ataches clamims to it, etc
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthController(SignInManager<ApplicationUser> _signInManager)
        {
            signInManager = _signInManager;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl) //collects the incomming Url from the customer
        {
            return View("~/AspNetIdentity/Views/Auth/Login.cshtml",new LoginViewModelASpid { ReturnUrl = returnUrl });// takes the url, passes it to the model, 
                                                                            //and then passes the model to the view
                                                                            //and returns the view to customer
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModelASpid Vm)
        {
            //check if model is valid, if not , do other stuff


            //if model is valid
           var result =  await signInManager.PasswordSignInAsync(Vm.Username, Vm.Password, false, false);  // ******set lockout on failure to true in production
                                                                                        // isPersistant: persists the cookie in the browser after closer
            if(result.Succeeded) // a valid cookie was created
            {
                return Redirect(Vm.ReturnUrl);
                
            }
            else if(result.IsLockedOut) // might send an email to user if account is locked out
            {
                return Redirect("www.google.com"); 
            }
            
            return View("~/AspNetIdentity/Views/Auth/Login.cshtml");
        }
    }
}