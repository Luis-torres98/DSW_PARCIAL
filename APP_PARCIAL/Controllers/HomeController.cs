using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;



namespace APP_PARCIAL.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase imagen)
        {
            if (imagen!=null && imagen.ContentLength>0)
            {
                var filename = Path.GetFileName(imagen.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Imagenes"), filename);
                imagen.SaveAs(path);
            }
            return RedirectToAction("Index");
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