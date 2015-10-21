using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticiasWeb.Models;

namespace NoticiasWeb.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/
        private Contexto context = null;
        private List<Categoria> categoria;
        public CategoriaController()
        {
            context = new Contexto();
        }
        public ActionResult Index()
        {
            categoria = context.categoria.ToList();
            return View(categoria);
        }
        [HttpGet]
        public JsonResult Eliminar(int id = 0)
        {
            
                Categoria categoria = context.categoria.Find(id);
                if (categoria != null)
                {
                    context.categoria.Remove(categoria);
                    context.SaveChanges();
                    return Json(categoria, JsonRequestBehavior.AllowGet);
                }
                else
                    return Json("fallo",JsonRequestBehavior.AllowGet);
           
        }
        
        public ActionResult Alta()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Alta(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.categoria.Add(categoria);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("fail", ex.Message);
                return View();
            }
        }
        public ActionResult Baja(int id)
        {
            Categoria categoria = context.categoria.Find(id);
            if (categoria != null)
                return PartialView(categoria);
            else
                return PartialView();
        }
        [HttpPost, ActionName("Baja")]
        public ActionResult ConfirmaBaja(Categoria cat)
        {
            try
            {
                Categoria categoria = context.categoria.Find(cat.Categoria_Id);
                context.categoria.Remove(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult Editar(int id=0)
        {
            Categoria EditCat = context.categoria.Find(id);
            if (EditCat != null)
                return View(EditCat);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Editar(Categoria EditCat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(EditCat).State = System.Data.Entity.EntityState.Modified;
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