using Agenda.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.BLL
{
    public class AgendaContactos : IAgendaContactos
    {
        public List<Contacto> listaContactos;
        public AgendaContactos(List<Contacto> listaContactos)
        {
            this.listaContactos = listaContactos;
        }
        public Contacto getContactoById(Contacto contactoBuscar)
        {
            return this.listaContactos.Single(p => p.id.Equals(contactoBuscar.id));
        }
        public List<Contacto> getlistaContactosPorFiltro(List<FiltroContacto> listaFiltros)
        {
            if (listaFiltros.Count != 0)
            {
                List<Contacto> listaFiltrar = copiarLista(this.listaContactos).OrderBy(p => p.apellidoYnombre).ToList(); // SE COPIA LA LISTA PARA QUE LOS CAMBIOS FUTUROS NO AFECTEN A LA LISTA ORIGINAL.

                foreach (FiltroContacto filtroContacto in listaFiltros)
                {
                    switch (filtroContacto.idFiltro)
                    {
                        case (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE:
                            listaFiltrar =  listaFiltrar.FindAll(p => p.apellidoYnombre.Contains(filtroContacto.valorFiltro));
                            break;

                        case (int)OPCIONES_FILTRO.LOCALIDAD:
                            listaFiltrar = listaFiltrar.FindAll(p => p.localidad.Contains(filtroContacto.valorFiltro));
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE:
                            listaFiltrar = listaFiltrar.FindAll(p => p.fechaIngreso >= filtroContacto.valorFiltroDate);
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA:
                            listaFiltrar = listaFiltrar.FindAll(p => p.fechaIngreso <= filtroContacto.valorFiltroDate);
                            break;

                        case (int)OPCIONES_FILTRO.CONTACTO_INTERNO:
                            listaFiltrar = listaFiltrar.FindAll(p => p.contactoInterno.Contains(filtroContacto.valorFiltro));
                            break;

                        case (int)OPCIONES_FILTRO.ORGANIZACION:
                            listaFiltrar = listaFiltrar.FindAll(p => p.organizacion.Contains(filtroContacto.valorFiltro));
                            break;

                        case (int)OPCIONES_FILTRO.AREA:
                            listaFiltrar = listaFiltrar.FindAll(p => p.area.Contains(filtroContacto.valorFiltro));
                            break;

                        case (int)OPCIONES_FILTRO.ACTIVO:
                            listaFiltrar = listaFiltrar.FindAll(p => p.activo.Contains(filtroContacto.valorFiltro));
                            break;
                        case (int)OPCIONES_FILTRO.PAIS:
                            listaFiltrar = listaFiltrar.FindAll(p => p.pais.Contains(filtroContacto.valorFiltro));
                            break;
                        default:
                            break;
                    }
                }
                return listaFiltrar;
            }
            else
            {
                return this.listaContactos.OrderBy(p => p.apellidoYnombre).ToList();
            }
        } // SEGUN LA LISTA DE FILTROS QUE LLEGUE POR PARAMETRO, SE FILTRA POR UNO, LUEGO SE GUARDA LA LISTA RESULTANTE, Y SE CONTINUA FILTRANDO POR TODO EL ARRAY DE FILTROS. (SE UTILIZA UN ENUM PARA EL CASE SWITCH).
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
        private List<Contacto> copiarLista(List<Contacto> listaCopiar)
        {
            List<Contacto> listaCopiada = new List<Contacto>();

            foreach(Contacto contactoCopiar in listaCopiar)
            {
                listaCopiada.Add(contactoCopiar);
            }

            return listaCopiada;
        }// FUNCION UTILIZADA PARA HACER LA COPIA DE LA LISTA Y QUE LOS CAMBIOS FUTUROS NO AFECTEN A LA LISTA ORIGINAL.
    }
}
