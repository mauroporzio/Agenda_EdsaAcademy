using System;

namespace Agenda.Entity
{
    [Serializable]
    public class Contacto
    {
        public int id { get; set; } // ID de contacto
        public string apellidoYnombre { get; set; }
        public string localidad { get; set; }
        public string pais { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string contactoInterno { get; set; } // TODOS (DEF), SI, NO.
        public string organizacion { get; set; }
        public string area { get; set; } //TODOS (DEF), Marketing, etc.
        public string activo { get; set; } // TODOS (DEF), SI, NO.
        public string direccion { get; set; }
        public string telefonoFijoInterno { get; set; }
        public string telefonoCelular { get; set; }
        public string eMail { get; set; }
        public string cuentaSkype { get; set; }
        public string genero { get; set; }
        public string cuil { get; set; }
    }
}
