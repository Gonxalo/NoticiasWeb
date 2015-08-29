using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace NoticiasWeb.Models
{
    public class Categoria
    {
        [Key]
        public int Categoria_Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string NombreCategoria { get; set; }

        [MaxLength(300)]
        public string DescripcionCategoria { get; set; }

        public virtual ICollection<Noticias> noticia { get; set; }
    }
}