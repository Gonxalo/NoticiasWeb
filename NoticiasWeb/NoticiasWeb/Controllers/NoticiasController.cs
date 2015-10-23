using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticiasWeb.Models;
using NoticiasWeb.ViewModels;

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
            NoticiasViewModel noticias = new NoticiasViewModel()
            {
                categoria = context.categoria.ToList(),
                seccion = context.seccion.ToList(),
                usuario = context.usuario.FirstOrDefault(),
                FechaCreacion = DateTime.Today.ToShortDateString(),
                CreadoPor = context.usuario.First().Usuario_Id,
                EditadoPor = context.usuario.First().Usuario_Id,
            };
            return View(noticias);
        }
        [HttpPost]
        public ActionResult Alta(NoticiasViewModel noticias)
        {
            try
            {
                
                Noticias noticiaModel = new Noticias()
                {
                    Activo = noticias.Activo,
                    CreadoPor = noticias.CreadoPor,
                    Cuerpo = noticias.Cuerpo,
                    EditadoPor = noticias.EditadoPor,
                    FechaCreacion = noticias.FechaCreacion,
                    Titulo = noticias.Titulo,
                    usuario = noticias.usuario,
                    seccion = context.seccion.Where(x => x.Seccion_Id == noticias.CategoriaId).First(),
                    categoria = context.categoria.Where(x => x.Categoria_Id == noticias.CategoriaId).First()
                };
                if(ModelState.IsValid)
                {
                    context.noticias.Add(noticiaModel);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    noticias.seccion = context.seccion.ToList();
                    noticias.categoria = context.categoria.ToList();

                    return View(noticias);
                }
                
            }
            catch (Exception)
            {
                return View(noticias);
            }
        }
        public ActionResult Baja()
        {

            return View();
        }
	}
}