﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EmpleadoRetenciones
    {
         [Key]
         public int Id { get; set; }
         public int EmpleadoId { get; set; }
         public int RetencionId { get; set; }
        
    }
}
