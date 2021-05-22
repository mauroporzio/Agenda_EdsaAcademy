using Agenda.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.BLL;
using Agenda.Entity;

namespace Agenda_EdsaAcademy
{
    public partial class Default : Page
    {
        public void print(List<Contacto> listaContactos)
        {
            foreach(Contacto contacto in listaContactos)
            {
                Response.Write(string.Concat("Contacto => ID: ", contacto.id.ToString(), " | Nombre y Apellido: ", contacto.apellidoYnombre.ToString(), " | Localidad: ", contacto.localidad.ToString()));
                Response.Write("<BR/>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IAgendaContactos AgendaBuisness = new AgendaContactos((List<Contacto>)Application["listaContactos"]);

            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("PRUEBA DE FUNCIONALIDADES DE AGENDA");
            Response.Write("<BR/>");
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

            //TESTE DE ELEMENTOS CARGADOS.

            Contacto contacto = AgendaBuisness.getContactoById(new Contacto { id = 1 });
            Response.Write(string.Concat("Contacto => ID: ", contacto.id.ToString(), " | Nombre y Apellido: ", contacto.apellidoYnombre.ToString()));
            Response.Write("<BR/>");

            //TEST DE BUSQUEDA POR FILTRO
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test filtro por localidad");
            Response.Write("<BR/>");
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto {idFiltro = 2,valorFiltro = "Buenos Aires" }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

            //TEST DE INSERT UN CONTACTO
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test insertar un contacto y mostrar toda la lista");
            Response.Write("<BR/>");
            Contacto nuevoContacto = AgendaBuisness.insertarContacto(new Contacto() { apellidoYnombre = "Natalia Natalia", localidad = "no se sabe" });
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto { }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

        }
    }
}