using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NoticiasWeb.Models
{
    public class Noticias
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Titulo { get; set; }

        [Required]
        public string Cuerpo { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int CreadoPor { get; set; }

        [Required]
        [MaxLength(20)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string FechaCreacion { get; set; }

        [Required]
        public int EditadoPor { get; set; }

        public virtual Usuario usuario { get; set; }

        public virtual Categoria categoria { get; set; }

        public virtual Seccion seccion { get; set; }
    }
}