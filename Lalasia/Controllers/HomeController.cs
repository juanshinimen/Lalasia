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

        public ActionResult Index()
        {
            return View();
        }
        //Page是页码数默认是第一页
        public ActionResult Product(string keyword = "",int page = 1)
        {
            //名字搜素
            int pageSize = 5;
            IEnumerable<Furniture> list = db.Furnitures.Where(p => p.Name.Contains(keyword)).ToList();
            //分页核心代码
            int recordCount = list.Count();
            list = list.Skip((page - 1) * pageSize).Take(pageSize);
            ViewBag.pageNum = Math.Ceiling((Convert.ToDecimal(recordCount)) / (Convert.ToDecimal(pageSize)));
            return View(list);
            //return View(db.Furnitures.Where(p=>p.Name.Contains(keyword)).ToList());
        }
        //public ActionResult Index(int? page)
        //{
        //    int pageSize = 5; // 每页显示的记录数
        //    int pageNumber = (page ?? 1); // 当前页码

        //    var model = db.Furnitures.OrderBy(p => p.Id)
        //                           .Skip((pageNumber - 1) * pageSize)
        //                           .Take(pageSize)
        //                           .ToList();

        //    ViewBag.TotalCount = db.Furnitures.Count(); // 总记录数
        //    ViewBag.PageSize = pageSize; // 每页显示的记录数
        //    ViewBag.PageNumber = pageNumber; // 当前页码

        //    return View(model);
        //}

        public ActionResult Service()
        {
            return View();
        }
    }
}