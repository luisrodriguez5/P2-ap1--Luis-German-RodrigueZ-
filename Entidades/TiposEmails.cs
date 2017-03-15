﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TiposEmails
    {
        [Key]
        public int TipoId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<EmpleadosEmails> Relacion { get; set; }

        public TiposEmails()
        {
            this.Relacion = new HashSet<EmpleadosEmails>();
        }
    }
}
