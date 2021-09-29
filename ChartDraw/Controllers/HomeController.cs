using ChartDraw.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ChartDraw.Controllers
{
    public class HomeController : Controller
    {
        masterEntities context = new masterEntities();
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult GetData()
        {
            int male = context.HighCharts.Where(x => x.gender == "erkek").Count();
            int female = context.HighCharts.Where(x => x.gender == "kadın").Count();
            int other = context.HighCharts.Where(x => x.gender == "diğer").Count();
            Ratio ratio = new Ratio();
            ratio.Male = male;
            ratio.Female = female;
            ratio.Other = other;
            return Json(ratio,JsonRequestBehavior.AllowGet);
        }
        public class Ratio
        {
            public int Male { get; set; }
            public int Female { get; set; }
            public int Other { get; set; }
        }

    }
}