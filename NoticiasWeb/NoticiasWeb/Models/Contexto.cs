using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NoticiasWeb.Models
{
    public class Contexto:DbContext
    {
        public Contexto() : base("name=CadenaConexion") { }

        public DbSet<Noticias> noticias { get; set; }

        public DbSet<Usuario> usuario { get; set; }

        public DbSet<Categoria> categoria { get; set; }

        public DbSet<Seccion> seccion { get; set; }


    }
}