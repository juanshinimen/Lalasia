using Lalasia.Data;
using Lalasia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Lalasia.Controllers
{
    public class HomeController : Controller
    {
        
        private LalasiaContext db = new LalasiaContext();
        private ShowContext dbs = new ShowContext();

        public ActionResult Index()
        {
            var shows = dbs.Shows.ToList(); // Getting data from the database for the Show model
            return View(shows); // Passing data to the view
        }
        public ActionResult Product(string keyword = "", string category = "",string sortOrder = "asc", int page = 1)
        {
            //keyword is data in the search box
            //category is type
            //sortOrder is price sorting
            int pageSize = 5;
            var query = db.Furnitures.AsQueryable();
            //determine the type
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Type == category);
            }
            //determine the name
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder == "asc")//low to high
                {
                    query = query.OrderBy(p => p.Prices);
                }
                else                  //high to low
                {
                    query = query.OrderByDescending(p => p.Prices);
                }
            }
            //Paging Functions
            
            int recordCount = query.Count();
            var list = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pageNum = Math.Ceiling((Convert.ToDecimal(recordCount)) / (Convert.ToDecimal(pageSize)));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_ProductList", list);
            }
            else
            {
                return View(list);
            }
        }

        //Accepting data from the home page search box
        [HttpPost]
        public ActionResult Product(string keyword,int page = 1)
        {
            int pageSize = 5;
            var query = db.Furnitures.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            query = query.OrderBy(p => p.Prices);
           
            int recordCount = query.Count();
            var list = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewBag.pageNum = Math.Ceiling((Convert.ToDecimal(recordCount)) / (Convert.ToDecimal(pageSize)));
            return View(list);
        }
        public ActionResult Service()
        {
            return View();
        }
    }
}