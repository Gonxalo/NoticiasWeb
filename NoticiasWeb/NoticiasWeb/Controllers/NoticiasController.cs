﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoticiasWeb.Controllers
{
    public class NoticiasController : Controller
    {
        //
        // GET: /Noticias/
        public ActionResult Index()
        {
            return View();
        }
	}
}