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

        public ActionResult Product(string keyword = "")
        {
            //名字搜素
            return View(db.Furnitures.Where(p=>p.Name.Contains(keyword)).ToList());
        }

        public ActionResult Service()
        {
            return View();
        }
    }
}