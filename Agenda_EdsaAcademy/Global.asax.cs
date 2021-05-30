using Agenda.Entity;
using Agenda.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Agenda_EdsaAcademy
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            List<Contacto> listaContactos = new List<Contacto>();

            listaContactos.Add(new Contacto { apellidoYnombre = "Mauro Porzio", id = 1, localidad = "Mar del Plata", fechaIngreso = DateTime.ParseExact("07/05/2002", "dd/MM/yyyy", null), activo = "Si", area = "Operaciones", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Jorge Lopez", id = 2, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("09/10/2004", "dd/MM/yyyy", null), activo = "Si", area = "RRHH", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Ana Benitez", id = 3, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("10/08/2007", "dd/MM/yyyy", null), activo = "No", area = "Marketing", contactoInterno = "Si", organizacion = "Empresa s.a" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Maria Rodriguez", id = 4, localidad = "Mar del Plata", fechaIngreso = DateTime.ParseExact("05/09/2001", "dd/MM/yyyy", null), activo = "Si", area = "Marketing", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Pablo Ramirez", id = 5, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("03/11/2006", "dd/MM/yyyy", null), activo = "Si", area = "RRHH", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Belen Martinez", id = 6, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("13/07/2007", "dd/MM/yyyy", null), activo = "No", area = "Operaciones", contactoInterno = "Si", organizacion = "Empresa s.a" });

            AgendaContactos agendaContactos = new AgendaContactos(listaContactos);

            Application["AgendaContactos"] = agendaContactos;

            List<String> paisesDropDownTODOS = new List<string>() {"TODOS","Argentina", "Francia", "Brasil", "Uruguay"};

            Application["listaPaisesTODOS"] = paisesDropDownTODOS;

            List<String> areaDropDownTODOS = new List<string>() {"TODOS","Marketing", "Finanzas", "RRHH", "Operaicones" };

            Application["listaAreasTODOS"] = areaDropDownTODOS;

            List<String> paisesDropDown = new List<string>() { "Argentina", "Francia", "Brasil", "Uruguay" };

            Application["listaPaises"] = paisesDropDown;

            List<String> areaDropDown = new List<string>() { "Marketing", "Finanzas", "RRHH", "Operaicones" };

            Application["listaAreas"] = areaDropDown;
        }
    }
}