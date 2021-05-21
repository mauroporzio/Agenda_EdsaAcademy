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

        private string nombre;
        private string apellido;
        private string localidad;
        private string fechaIngresoDesde;
        private string fechaIngresoHasta;
        private string contactoInterno; // TODOS (DEF), SI, NO.
        private string organizacion;
        private string area; //TODOS (DEF), Marketing, Finanzas, RRHH, Operaciones.
        private string activo; // TODOS (DEF), SI, NO.
    }
}
