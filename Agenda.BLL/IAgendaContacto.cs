using System.Collections.Generic;
using Agenda.Entity;

namespace Agenda.BLL
{
    interface IAgendaContacto 
    {
        Contacto getContactoById(Contacto contactoBuscar);
        List<Contacto> getlistaContactosPorFiltro(string idFiltro); // recibe un string que espeficia que campo se usara para filtrar.
        void modificarContacto();
        void insertarContacto();
        void eliminarContacto();


    }
}
