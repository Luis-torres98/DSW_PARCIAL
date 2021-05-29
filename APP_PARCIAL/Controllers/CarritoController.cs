using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_PARCIAL.Models;


namespace APP_PARCIAL.Controllers
{
    public class CarritoController : Controller
    {
        FUENTE_SODAEntities2 db = new FUENTE_SODAEntities2();

        private int getIndice( int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.IDE_PRO == id)
                    return i;
                
               
            }
            return -1;
        }
     
       
      
        public ActionResult AgregarCarrito(int id , int cat )
        {
            if (Session["carrito"]==null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.PRODUCTO.Find(id),cat));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndiceExistente = getIndice(id);
                if (IndiceExistente == -1)
                {
                    compras.Add(new CarritoItem(db.PRODUCTO.Find(id), cat));
                }
                else
                {
                    compras[IndiceExistente].Cantidad+=cat;

                }
                Session["carrito"] = compras;
            }
            return View();
           
         }

       

        public ActionResult delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndice(id));
            return View("AgregarCarrito");
        }

        public ActionResult FinalizarCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];

            if (compras!=null && compras.Count > 0)
            {
                VENTA nuevaVenta = new VENTA();
                nuevaVenta.DIA_VEN = DateTime.Now;
                nuevaVenta.SUB_TOT = compras.Sum(x => x.Producto.PRE_PRO * x.Cantidad);
                nuevaVenta.IVA = nuevaVenta.SUB_TOT * Convert.ToDecimal(0.18);
                nuevaVenta.TOTAL = nuevaVenta.SUB_TOT + nuevaVenta.IVA;
                
                nuevaVenta.LISTAVENTA = (from PRODUCTO in compras
                                         select new LISTAVENTA
                                         {
                                             ID_PRO = PRODUCTO.Producto.IDE_PRO,
                                             CAN_LIS_VEN = PRODUCTO.Cantidad,
                                             TOTAL = PRODUCTO.Cantidad * PRODUCTO.Producto.PRE_PRO
                                         }).ToList();
                db.VENTA.Add(nuevaVenta);
                db.SaveChanges();
                Session["carrito"] = new List<CarritoItem>();
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}