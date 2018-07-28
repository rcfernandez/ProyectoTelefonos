using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTelefonos.Controllers
{
    public class HomeController : Controller
    {

        ModelDB db = new ModelDB();


        public ActionResult Index()
        {


            return View(db.Interno.ToList());
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}