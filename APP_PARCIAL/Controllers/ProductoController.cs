using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_PARCIAL.Models;


namespace APP_PARCIAL.Controllers
{
    public class ProductoController : Controller
    {

        FUENTE_SODAEntities2 db = new FUENTE_SODAEntities2();
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.PRODUCTO.ToList().OrderBy(x=>x.DES_PRO));
        }
    }
}