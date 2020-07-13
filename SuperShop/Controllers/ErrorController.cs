using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SuperShop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        [Route("Error/{statusCode}")]
        public IActionResult HttpRequest(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "404 Page not found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Content Not Found";
                    break;

            }
            return View("NotFound");
        }
    }
}
