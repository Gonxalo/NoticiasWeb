using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticiasWeb.Models;

namespace NoticiasWeb.Controllers
{
    public class NoticiasController : Controller
    {
        //
        // GET: /Noticias/

        private Contexto context = null;
        private List<Noticias> noticia;
        public NoticiasController()
        {
            context =  new Contexto();
        }

        public ActionResult Index()
        {
            noticia = context.noticias.ToList();
            return View(noticia);
        }

        public ActionResult Alta()
        {
            Noticias notice = new Noticias();
            notice.categoria = context.categoria.ToList();
            notice.seccion = context.seccion.ToList();
            notice.FechaCreacion = DateTime.Today.ToShortDateString();
            return View(notice);
        }
        [HttpPost]
        public ActionResult Alta(Noticias noticia)
        {
            if (ModelState.IsValid)
            {
                context.noticias.Add(noticia);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Noticias notice = new Noticias();
                notice.categoria = context.categoria.ToList();
                notice.seccion = context.seccion.ToList();
                notice.FechaCreacion = DateTime.Today.ToShortDateString();
                return View();
            }
        }
        public ActionResult Baja()
        {

            return View();
        }
	}
}