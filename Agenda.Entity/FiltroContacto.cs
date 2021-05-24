using System;

namespace Agenda.Entity
{
    public enum OPCIONES_FILTRO // enum de filtros disponibles.
    {
        APELLIDO_Y_NOMBRE,
        LOCALIDAD,
        FECHA_DE_INGRESO_DESDE,
        FECHA_DE_INGRESO_HASTA,
        CONTACTO_INTERNO,
        ORGANIZACION,
        AREA,
        ACTIVO
    }
    public class FiltroContacto
    {
        public int idFiltro { get; set; } // UN INT PARA CADA CAMPO DE CONTACTO. ESTE VALOR LE LLEGA A LA FUNCION DE FILTRAR Y SEGUN QUE VALOR TIENE FILTRA POR ESE CAMPO. EL VALOR SE ASIGNA EN LA LOGICA DE LA INTERFAZ, CUANDO SE SELECCIONA QUE CAMPO SE DESEA BUSACAR.
        public String valorFiltro { get; set; }
    }
}
