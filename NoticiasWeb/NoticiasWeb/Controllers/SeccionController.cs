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
        //
        // GET: /Seccion/
        public ActionResult Index()
        {
           Contexto context = new Contexto();
          List<Seccion> secciones = context.seccion.ToList();
          return View(secciones);
        }
        public ActionResult Alta()
        {
            return View();
        }
        public ActionResult Baja()
        {
            return View();
        }
        public ActionResult Detalle()
        {
           
            return View();
        }
	}
}