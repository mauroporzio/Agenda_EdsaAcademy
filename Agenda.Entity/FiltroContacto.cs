using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Entity
{
    public class FiltroContacto
    {
        public int idFiltro { get; set; } // UN INT PARA CADA CAMPO DE CONTACTO. ESTE VALOR LE LLEGA A LA FUNCION DE FILTRAR Y SEGUN QUE VALOR TIENE FILTRA POR ESE CAMPO. EL VALOR SE ASIGNA EN LA LOGICA DE LA INTERFAZ, CUANDO SE SELECCIONA QUE CAMPO SE DESEA BUSACAR.
        public String valorFiltro { get; set; }
    }
}
