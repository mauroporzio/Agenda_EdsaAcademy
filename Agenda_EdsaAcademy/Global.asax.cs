using Agenda.Entity;
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

            listaContactos.Add(new Contacto { apellidoYnombre = "Mauro Porzio", id = 1, localidad = "Mar del Plata", fechaIngresoDesde = DateTime.Parse("02/12/2000"), activo = true, area = "Programacion", fechaIngresoHasta = DateTime.Parse("22/05/2021"), contactoInterno = true, organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Jorge Lopez", id = 2, localidad = "Buenos Aires", fechaIngresoDesde = DateTime.Parse("09/10/2004"), activo = false, area = "RRHH", fechaIngresoHasta = DateTime.Parse("21/04/2020"), contactoInterno = true, organizacion = "EDSA" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Mario Benitez", id = 3, localidad = "Buenos Aires", fechaIngresoDesde = DateTime.Parse("10/08/2007"), activo = true, area = "Cliente", fechaIngresoHasta = DateTime.Parse("12/02/2019"), contactoInterno = false, organizacion = "Empresa s.a" });

            Application["listaContactos"] = listaContactos;

            List<String> paisesDropDown = new List<string>() {"TODOS","Argentina", "Francia", "Brasil", "Uruguay"};

            Application["listaPaises"] = paisesDropDown;

            List<String> areaDropDown = new List<string>() { "TODOS", "Marketing", "Finanzas", "RRHH", "Operaicones" };

            Application["listaAreas"] = areaDropDown;
        }
    }
}