using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prueba.Entity
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }

        public string Name { get; set; } 
    }
}
