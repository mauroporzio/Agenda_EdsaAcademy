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
        public const int idFiltroPorApellidoYnombre = 1;
        public const int idFiltroPorLocalidad = 2;
        public const int idFiltroPorFechaDeIngresoDesde = 3;
        public const int idFiltroPorFechaDeIngresoHasta = 4;
        public const int idFiltroPorContactoInterno = 5;
        public const int idFiltroPorOrganizacion = 6;
        public const int idFiltroPorArea = 7;
       // public const int idFiltroPorEstadoActivo = 8;

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
                if (filtro.idFiltro == idFiltroPorApellidoYnombre)
                {
                    return this.listaContactos.FindAll(p => p.apellidoYnombre.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorLocalidad)
                {
                    return this.listaContactos.FindAll(p => p.localidad.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorFechaDeIngresoDesde)
                {
                    return this.listaContactos.FindAll(p => p.fechaIngresoDesde.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorFechaDeIngresoHasta)
                {
                    return this.listaContactos.FindAll(p => p.fechaIngresoHasta.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorContactoInterno)
                {
                    return this.listaContactos.FindAll(p => p.contactoInterno.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorOrganizacion)
                {
                    return this.listaContactos.FindAll(p => p.organizacion.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else if (filtro.idFiltro == idFiltroPorArea)
                {
                    return this.listaContactos.FindAll(p => p.area.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
                else
                {
                    return this.listaContactos.FindAll(p => p.activo.Contains(filtro.valorFiltro)).OrderBy(p => p.id).ToList();
                }
            }
            else
            {
                return this.listaContactos.OrderBy(p => p.id).ToList();
            }
        }
        public Contacto insertarContacto(Contacto contactoInsertar)
        {
            int maxIdAcutal = this.listaContactos.OrderByDescending(p => p.id).First().id;
            contactoInsertar.id = maxIdAcutal + 1;

            this.listaContactos.Add(contactoInsertar);

            return contactoInsertar;
        }
        public void modificarContacto(Contacto contactoModificar)
        {
            
        }
        public void eliminarContacto(Contacto contactoEliminar)
        {
            
        }

        public void eliminarContacto(Contacto contactoEliminar, FiltroContacto filtroBusquedaEditar)
        {
            throw new NotImplementedException();
        }
    }
}
