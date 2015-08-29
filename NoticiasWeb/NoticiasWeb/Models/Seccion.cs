using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace NoticiasWeb.Models
{
    public class Seccion
    {
        [Key]
        public int Seccion_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreSeccion { get; set; }

        [MaxLength(50)]
        public string DescripcionSeccion { get; set; }

        public virtual ICollection<Noticias> noticia { get; set; }
    }
}