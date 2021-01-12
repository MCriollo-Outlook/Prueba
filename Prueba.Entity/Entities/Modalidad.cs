using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prueba.Entity.Entities
{
    public class Modalidad
    {
        [Key]
        public int IdModalidad { get; set; } 

        public string Name { get; set; }
    }
}
