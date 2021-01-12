using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prueba.Entity.Entities
{
    public class Deportista
    {
        [Key]
        public int IdDeportista { get; set; }

        public string Name { get; set; }
    }
}
