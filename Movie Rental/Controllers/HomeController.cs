using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Movie_Rental.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

    }
}