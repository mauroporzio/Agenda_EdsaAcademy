using Agenda.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.BLL
{
    public class AgendaContactos : IAgendaContactos
    {
        enum OPCIONES_FILTRO // enum de filtros disponibles.
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

        public List<Contacto> listaContactos;

        public AgendaContactos(List<Contacto> listaContactos)
        {
            this.listaContactos = listaContactos;
        }
        public Contacto getContactoById(Contacto contactoBuscar)
        {
            return this.listaContactos.Single(p => p.id.Equals(contactoBuscar.id));
        }
        public List<Contacto> getlistaContactosPorFiltro(FiltroContacto filtro)
        {
            if (!string.IsNullOrEmpty(filtro.valorFiltro))
            {
                switch (filtro.idFiltro)
                {
                    case (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE:
                        return this.listaContactos.FindAll(p => p.apellidoYnombre.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.LOCALIDAD:
                        return this.listaContactos.FindAll(p => p.localidad.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE:
                        return this.listaContactos.FindAll(p => p.fechaIngresoDesde.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA:
                        return this.listaContactos.FindAll(p => p.fechaIngresoHasta.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.CONTACTO_INTERNO:
                        return this.listaContactos.FindAll(p => p.contactoInterno.Equals(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.ORGANIZACION:
                        return this.listaContactos.FindAll(p => p.organizacion.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.AREA:
                        return this.listaContactos.FindAll(p => p.area.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    case (int)OPCIONES_FILTRO.ACTIVO:
                        return this.listaContactos.FindAll(p => p.activo.Equals(filtro.valorFiltro)).OrderBy(p => p.id).ToList();

                    default:
                        return this.listaContactos.OrderBy(p => p.id).ToList();
                }
            }
            else
            {
                return this.listaContactos.OrderBy(p => p.id).ToList();
            }
        } // SEGUN QUE ID DE FILTRO LLEGUE, SE FILTRA POR ESE PARAMETRO. SE UTILIZA UN ENUM PARA EL CASE SWITCH.
        public Contacto insertarContacto(Contacto contactoInsertar)
        {
            int maxIdAcutal = this.listaContactos.OrderByDescending(p => p.id).First().id;
            contactoInsertar.id = maxIdAcutal + 1;

            this.listaContactos.Add(contactoInsertar);

            return contactoInsertar;
        }
        public void modificarContacto(Contacto contactoModificar) //LLEGA EL CONTACTO YA MODIFICADO PERO MANTIENE EL ID, ENTONCES BORRA EL CONTACTO VIEJO Y ALMACENA EL MODIFICADO.
        {
            this.eliminarContacto(contactoModificar);
            this.insertarContacto(contactoModificar);
        }
        public void eliminarContacto(Contacto contactoEliminar)
        {
            this.listaContactos.Remove(this.listaContactos.Single(p => p.id.Equals(contactoEliminar.id)));
        }
    }
}
