using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APP_PARCIAL.Models;
using System.Web.Helpers;
using System.Data.Entity;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;



namespace APP_PARCIAL.Controllers
{
    public class VendedorController : Controller
    {
        // GET: Vendedor

        FUENTE_SODAEntities db = new FUENTE_SODAEntities();

        public ActionResult obtenerImagen(int id)
        {
            VENDEDOR persona = db.VENDEDOR.Find(id);
            byte[] byteImagen = persona.FOTO;

            MemoryStream memoria = new MemoryStream(byteImagen);
            Image imagen = Image.FromStream(memoria);

            memoria = new MemoryStream();
            imagen.Save(memoria, ImageFormat.Jpeg);
            memoria.Position = 0;

            return File(memoria, "image/jpg");

        }

        public ActionResult Index()
        {
            return View(db.VENDEDOR.ToList());
        }

        public ActionResult Create()
        {
            return View(new VENDEDOR() );
        }

        [HttpPost]
        public ActionResult Create(VENDEDOR obj)
        {
            HttpPostedFileBase archivo = Request.Files[0];

            if (archivo.ContentLength ==0)
            {
                ModelState.AddModelError("foto", "¡Es necesario subir una imagen!");
                return View(obj);
            }
            else
            {
                if (archivo.FileName.EndsWith(".jpg"))
                {
                    WebImage imagen = new WebImage(archivo.InputStream);
                    obj.FOTO = imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("foto", "¡Solo formato JPG!");
                    return View(obj);
                }
            }

            

            db.VENDEDOR.Add(obj);
            db.SaveChanges();
            return RedirectToAction("Index");


        }


        public ActionResult Edit(int? id)
        {
            VENDEDOR persona = db.VENDEDOR.Find(id);

            return View(persona);
        }
    
        [HttpPost]
        public ActionResult Edit(VENDEDOR obj)
        {
            VENDEDOR _persona = new VENDEDOR();

            HttpPostedFileBase archivo = Request.Files[0];
            if (archivo.ContentLength==0)
            {
                _persona = db.VENDEDOR.Find(obj.IDE_VEN);
                obj.FOTO = _persona.FOTO;
            }
            else
            {
                if (archivo.FileName.EndsWith(".jpg"))
                {

                    WebImage imagen = new WebImage(archivo.InputStream);
                    obj.FOTO = imagen.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("foto", "¡Solo formato JPG!");
                    return View(db.VENDEDOR.Find(obj.IDE_VEN));
                }
            }

            

            if (ModelState.IsValid)
            {
                db.Entry(_persona).State = EntityState.Detached;
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public ActionResult Details(int ? id)
        {
            VENDEDOR persona = db.VENDEDOR.Find(id);
            return View(persona);
        }

        public ActionResult Delete(int ? id)
        {
            VENDEDOR persona = db.VENDEDOR.Find(id);

            db.VENDEDOR.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}