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

            listaContactos.Add(new Contacto { apellidoYnombre = "Mauro Porzio", id = 1, localidad = "Mar del Plata", fechaIngresoDesde = "02/12/2000", activo = "Si", area = "Operaciones", fechaIngresoHasta = "22/05/2021", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Jorge Lopez", id = 2, localidad = "Buenos Aires", fechaIngresoDesde = "09/10/2004", activo = "Si", area = "RRHH", fechaIngresoHasta = "21/04/2020", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Ana Benitez", id = 3, localidad = "Buenos Aires", fechaIngresoDesde = "10/08/2007", activo = "No", area = "Marketing", fechaIngresoHasta = "12/02/2019", contactoInterno = "Si", organizacion = "Empresa s.a" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Maria Rodriguez", id = 4, localidad = "Mar del Plata", fechaIngresoDesde = "05/09/2001", activo = "Si", area = "Marketing", fechaIngresoHasta = "22/05/2021", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Pablo Ramirez", id = 5, localidad = "Buenos Aires", fechaIngresoDesde = "03/11/2006", activo = "Si", area = "RRHH", fechaIngresoHasta = "21/04/2020", contactoInterno = "Si", organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Belen Martinez", id = 6, localidad = "Buenos Aires", fechaIngresoDesde = "13/07/2007", activo = "No", area = "Operaciones", fechaIngresoHasta = "12/02/2019", contactoInterno = "Si", organizacion = "Empresa s.a" });

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