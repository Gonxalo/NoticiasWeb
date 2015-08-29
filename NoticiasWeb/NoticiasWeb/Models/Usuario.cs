using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NoticiasWeb.Models
{
    public class Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidoPaterno { get; set; }

        [Required]
        [MaxLength(50)]
        public string ApellidoMaterno { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FechaNaciemiento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Noticias> noticia { get; set; }
    }
}