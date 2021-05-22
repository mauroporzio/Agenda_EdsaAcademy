﻿using Agenda.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Agenda.Entity;
using System.Text;

namespace Agenda_EdsaAcademy
{
    public partial class Default : Page
    {
        public void print(List<Contacto> listaContactos)
        {
            StringBuilder strBld = new StringBuilder();

            foreach(Contacto contacto in listaContactos)
            {
                Response.Write("-------------------------------------------------------------------------------------");
                Response.Write(string.Concat("CONTACTO => ", contacto.apellidoYnombre.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Localidad: ", contacto.localidad.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Area: ", contacto.area.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Organizacion: ", contacto.organizacion.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Fecha de ingreso desde: ", contacto.fechaIngresoDesde.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Fecha de ingreso hasta: ", contacto.fechaIngresoHasta.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Activo: ", contacto.activo.ToString()));
                Response.Write("<BR/>");
                Response.Write(string.Concat("Contacto interno: ", contacto.contactoInterno.ToString()));
                Response.Write("<BR/>");
                Response.Write("-------------------------------------------------------------------------------------");
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

            //TEST DE ELEMENTOS CARGADOS.

            Contacto contacto = AgendaBuisness.getContactoById(new Contacto { id = 1 });
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto() { valorFiltro = "Mauro Porzio", idFiltro = 0 }));

            //TEST DE BUSQUEDA POR FILTRO
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test filtro por localidad");
            Response.Write("<BR/>");
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto {idFiltro = 1,valorFiltro = "Buenos Aires" }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

            //TEST DE INSERT UN CONTACTO
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test insertar un contacto y mostrar toda la lista");
            Response.Write("<BR/>");
            Contacto nuevoContacto = AgendaBuisness.insertarContacto(new Contacto() { apellidoYnombre = "Sebastian Ramirez", localidad = "Mar del Plata", fechaIngresoDesde = "12/09/2008", activo = true, area = "Programacion", fechaIngresoHasta = "21/04/2020", contactoInterno = true, organizacion = "EDSA" });
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto { }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

            //TEST DE ELIMINAR CONTACTO

            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test eliminar un contacto y mostrar toda la lista");
            Response.Write("<BR/>");
            AgendaBuisness.eliminarContacto(new Contacto() { id = 2 });
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto { }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

            // TEST MODIFICAR CONTACTO

            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");
            Response.Write("Test modificar un contacto y mostrarlo");
            Response.Write("<BR/>");
            AgendaBuisness.modificarContacto(new Contacto() { id = 1, apellidoYnombre = "Mauro Porzio", localidad = "Rosario", fechaIngresoDesde = "02/12/2000", activo = true, area = "Programacion", fechaIngresoHasta = "22/05/2021", contactoInterno = true, organizacion = "EDSA" });
            print(AgendaBuisness.getlistaContactosPorFiltro(new FiltroContacto { }));
            Response.Write("-------------------------------------------------------------------------------------");
            Response.Write("<BR/>");

        }
    }
}