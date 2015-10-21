using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticiasWeb.Models;

namespace NoticiasWeb.Controllers
{
    public class SeccionController : Controller
    {
        private Contexto context = null; //nos enlaza a la cadena conexion
        public SeccionController()   
        {
            context = new Contexto();
        }
        public ActionResult Index()
        {
            List<Seccion> secciones = context.seccion.ToList();
            return View(secciones);
        }

        public JsonResult Eliminar(int id=0)
        {
            Seccion seccion = context.seccion.Find(id);

            if (seccion != null)
            {
                context.seccion.Remove(seccion);
                context.SaveChanges();
                return Json(seccion, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json("Fallo", JsonRequestBehavior.AllowGet);
                }
        }
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(Seccion seccion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.seccion.Add(seccion);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Fail", ex.Message);
                return View();
            }
            
        }

        public ActionResult Baja(int id)
        {
            Seccion seccion = context.seccion.Find(id);
            if (seccion != null)
                return View(seccion);
            else
                return View();
        }

        [HttpPost, ActionName("Baja")]
        public ActionResult ConfirmarBaja(int id)
        {
            try
            {
                Seccion seccion = context.seccion.Find(id);
                context.seccion.Remove(seccion);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
            
        }

        public ActionResult Detalle()
        {
           return View();
        }

        public ActionResult Editar(int id)
        {
            Seccion seccion = context.seccion.Find(id);
            if (seccion != null)
                return View(seccion);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Seccion seccion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(seccion).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
	}
}