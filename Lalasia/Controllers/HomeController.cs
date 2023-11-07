using Lalasia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lalasia.Controllers
{
    public class HomeController : Controller
    {
        private LalasiaContext db = new LalasiaContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View(db.Furnitures.ToList());
        }

        public ActionResult Service()
        {
            return View();
        }
    }
}