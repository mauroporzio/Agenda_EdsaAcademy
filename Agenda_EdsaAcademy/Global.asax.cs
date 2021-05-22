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

            listaContactos.Add(new Contacto { apellidoYnombre = "Mauro Porzio", id = 1, localidad = "Mar del Plata" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Jorge Lopez", id = 2, localidad = "Buenos Aires" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Mario Benitez", id = 3, localidad = "Buenos Aires" });

            Application["listaContactos"] = listaContactos;
        }
    }
}