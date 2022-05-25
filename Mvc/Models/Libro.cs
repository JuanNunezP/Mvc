﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Mvc.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0}  debe ser almenos {2} y máximo{1}", MinimumLength = 3)]
        [Display(Name = "Título")]

        public string Titulo { get; set; }


        [Required(ErrorMessage = "La descripción es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0}  debe ser almenos {2} y máximo{1}", MinimumLength = 3)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }



        [Required(ErrorMessage = "La fecha es obligatorio")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Lanzamiento")]
        public  DateTime FechaLanzamiento { get; set; }

        [Required(ErrorMessage = "El  autor es obligatorio")]
        public string Autor { get; set; }



        [Required(ErrorMessage = "El precio es obligatorio")]
        public int precio { get; set; }
    }
}
