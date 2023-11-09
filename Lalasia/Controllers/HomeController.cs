using Lalasia.Data;
using Lalasia.Models;
using System;
using System.Collections.Generic;
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
            var shows = dbs.Shows.ToList(); // 从数据库中获取Show模型的数据
            return View(shows); // 将数据传递给视图
        }
        public ActionResult Product(string keyword = "", string category = "",string sortOrder = "asc", int page = 1)
        {
            int pageSize = 5;
            var query = db.Furnitures.AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Type == category);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder == "asc")
                {
                    query = query.OrderBy(p => p.Prices);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Prices);
                }
            }

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

        [HttpPost]
        public ActionResult Product(string keyword,int page = 1)
        {
            string category = "";
            string sortOrder = "asc";
            int pageSize = 5;
            var query = db.Furnitures.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Type == category);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (sortOrder == "asc")
                {
                    query = query.OrderBy(p => p.Prices);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Prices);
                }
            }

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


        ////Page是页码数默认是第一页
        //public ActionResult Product(string keyword = "", int page = 1)
        //{
        //    //名字搜素
        //    int pageSize = 5;
        //    IEnumerable<Furniture> list = db.Furnitures.Where(p => p.Name.Contains(keyword)).ToList();
        //    //分页核心代码
        //    int recordCount = list.Count();
        //    list = list.Skip((page - 1) * pageSize).Take(pageSize);
        //    ViewBag.pageNum = Math.Ceiling((Convert.ToDecimal(recordCount)) / (Convert.ToDecimal(pageSize)));
        //    return View(list);
        //}
        public ActionResult Service()
        {
            return View();
        }
    }
}