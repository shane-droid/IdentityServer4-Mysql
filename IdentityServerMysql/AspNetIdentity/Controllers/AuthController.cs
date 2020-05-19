using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServerMysql.AspNetIdentity.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Index(string returnUrl) //collects the incomming Url from the customer
        {
            return View(new LoginViewModelASpid { ReturnUrl = returnUrl });// takes the url, passes it to the model, 
                                                                            //and then passes the model to the view
                                                                            //and returns the view to customer
        }

        [HttpPost]
        public IActionResult Login(LoginViewModelASpid Vm)
        {
            return View();
        }
    }
}