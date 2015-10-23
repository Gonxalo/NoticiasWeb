using NoticiasWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NoticiasWeb.ViewModels
{
    public class NoticiasViewModel
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
        [Required]
        public int CategoriaId { get; set; }
        [Required]
        public int SeccionId { get; set; }

        public virtual Usuario usuario { get; set; }
        public virtual List<Categoria> categoria { get; set; }
        public virtual List<Seccion> seccion { get; set; }
    }
}