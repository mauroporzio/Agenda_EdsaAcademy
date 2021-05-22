using System.Collections.Generic;
using Agenda.Entity;

namespace Agenda.BLL
{
    public interface IAgendaContactos 
    {
        Contacto getContactoById(Contacto contactoBuscar); // retorna un solo contacto correspondiente al id que se busca.
        List<Contacto> getlistaContactosPorFiltro(FiltroContacto filtro); // recibe un obj FiltroContacto que espeficia que campo se usara para filtrar y retorna una lista con todos los contactos matching.
        void modificarContacto(Contacto contactoModificar);
        Contacto insertarContacto(Contacto contactoInsertar);
        void eliminarContacto(Contacto contactoEliminar);
    }
}
