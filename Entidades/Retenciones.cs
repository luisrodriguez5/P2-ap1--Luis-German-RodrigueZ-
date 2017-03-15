﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Retenciones
    {
        [Key]
        public int RetencionId { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }

        public virtual List<Entidades.Empleados> Empleados { get; set; }

        public Retenciones()
        {
            Empleados = new List<Entidades.Empleados>();
        }
    }
}
