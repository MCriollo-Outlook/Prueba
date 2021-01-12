using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prueba.Entity.Entities
{
    public class DeportistaModalidad
    {
        [Key]
        public int IdDeportistaModalidad { get; set; }

        public int IdDeportista { get; set; }

        public int IdModalidad { get; set; }

        public int Peso { get; set; }
    }
}
