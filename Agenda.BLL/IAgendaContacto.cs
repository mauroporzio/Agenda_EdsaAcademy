using System.Collections.Generic;
using Agenda.Entity;

namespace Agenda.BLL
{
    interface IAgendaContactos
    {
        Contacto getContacto(Contacto contactoBuscar);
    }
}
