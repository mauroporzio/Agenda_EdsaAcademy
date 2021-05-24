﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Contacto : IContacto
    {
        public int id { get; set; } // ID de contacto
        public string apellidoYnombre { get; set; }
        public string localidad { get; set; }
        public string fechaIngresoDesde { get; set; }
        public string fechaIngresoHasta { get; set; }
        public Boolean contactoInterno { get; set; } // TODOS (DEF), SI, NO.
        public string organizacion { get; set; }
        public string area { get; set; } //TODOS (DEF), Marketing, Finanzas, RRHH, Operaciones.
        public Boolean activo { get; set; } // TODOS (DEF), SI, NO.

        public void activarContacto()
        {
            if (!this.activo)
            {
                this.activo = true;
            }
        }
        public void DesactivarContacto()
        {
            if (this.activo)
            {
                this.activo = false;
            }
        }
    }
}
