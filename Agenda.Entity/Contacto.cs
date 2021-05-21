using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class Contacto
    {
        public const string contactoInternoDefault = "TODOS";
        public const string areaDefault = "TODOS";
        public const string activoDefault = "TODOS";

        private int id { get; set; } // ID de contacto
        private string apellidoYnombre { get; set; }
        private string localidad { get; set; }
        private string fechaIngresoDesde { get; set; }
        private string fechaIngresoHasta { get; set; }
        private string contactoInterno { get; set; } // TODOS (DEF), SI, NO.
        private string organizacion { get; set; }
        private string area { get; set; } //TODOS (DEF), Marketing, Finanzas, RRHH, Operaciones.
        private string activo { get; set; } // TODOS (DEF), SI, NO.
    }
}
