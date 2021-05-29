using System;

namespace Agenda.Entity
{
    public class Contacto : IContacto
    {
        public int id { get; set; } // ID de contacto
        public string apellidoYnombre { get; set; }
        public string localidad { get; set; }
        public string pais { get; set; }
        public DateTime fechaIngresoDesde { get; set; }
        public DateTime fechaIngresoHasta { get; set; }
        public Boolean contactoInterno { get; set; } // TODOS (DEF), SI, NO.
        public string organizacion { get; set; }
        public string area { get; set; } //TODOS (DEF), Marketing, etc.
        public Boolean activo { get; set; } // TODOS (DEF), SI, NO.
        public string direccion { get; set; }
        public string telefonoFijoInterno { get; set; }
        public string telefonoCelular { get; set; }
        public string eMail { get; set; }
        public string cuentaSkype { get; set; }

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
