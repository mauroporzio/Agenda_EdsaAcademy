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

            // mock data. Que se utilizaba para la pagina aspx de testeo al comienzo del desarrollo.

            /*
            List<Contacto> listaContactos = new List<Contacto>();

            listaContactos.Add(new Contacto { apellidoYnombre = "Mauro Porzio", id = 1, localidad = "Mar del Plata", fechaIngreso = DateTime.ParseExact("07/05/2002", "dd/MM/yyyy", null), activo = "Si", area = "Operaciones", contactoInterno = "Si", direccion = "calle 123", eMail = "email1@direc.com", cuentaSkype = "cuentaSkype1", genero = "Masculino", pais = "Argentina", telefonoCelular = "223345456" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Jorge Lopez", id = 2, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("09/10/2004", "dd/MM/yyyy", null), activo = "Si", area = "RRHH", contactoInterno = "Si", direccion = "calle2 111", eMail = "email2@direc.com", cuentaSkype = "cuentaSkype2", genero = "Masculino", pais = "Argentina", telefonoCelular = "223453667" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Ana Benitez", id = 3, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("10/08/2007", "dd/MM/yyyy", null), activo = "No", contactoInterno = "No", organizacion = "Empresa s.a", direccion = "calle1 089", eMail = "email123@direc.com", cuentaSkype = "cuentaSkype123", genero = "Femenino", pais = "Argentina", telefonoCelular = "2233445687" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Maria Rodriguez", id = 4, localidad = "Santiago de Chile", fechaIngreso = DateTime.ParseExact("05/09/2001", "dd/MM/yyyy", null), activo = "Si", contactoInterno = "No", organizacion = "Empresa2 s.a", direccion = "calle8 190", eMail = "email980@direc.com", cuentaSkype = "cuentaSkype908", genero = "Femenino", pais = "Chile", telefonoCelular = "132457435" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Pablo Ramirez", id = 5, localidad = "San Pablo", fechaIngreso = DateTime.ParseExact("03/11/2006", "dd/MM/yyyy", null), activo = "Si", area = "RRHH", contactoInterno = "Si", direccion = "calle34 165", eMail = "email1345@direc.com", cuentaSkype = "cuentaSkype1543", genero = "Masculino", pais = "Brasil", telefonoCelular = "3243456334" });
            listaContactos.Add(new Contacto { apellidoYnombre = "Belen Martinez", id = 6, localidad = "Buenos Aires", fechaIngreso = DateTime.ParseExact("13/07/2007", "dd/MM/yyyy", null), activo = "No", area = "Operaciones", contactoInterno = "Si", direccion = "calle345 1546", eMail = "email1345@direc.com", cuentaSkype = "cuentaSkype134", genero = "Femenino", pais = "Argentina", telefonoCelular = "223987656" });

            AgendaContactos agendaContactos = new AgendaContactos(listaContactos);

            Application["AgendaContactos"] = agendaContactos;

            */

            using (PaisDropDownList pais = new PaisDropDownList())// SE RECIBE DE LA CAPA BLL LA LISTA DE PAISES PROVENIENTE DE LA BASE DE DATOS.
            {
                Application["listaPaises"] = pais.getListaPaises();// LISTA CON SOLO LOS PAISES PARA LOS DROPDOWN DE NUEVO CONTACTO, ABRIR CONTACTO Y EDITAR CONTACTO.

                List<String> listaPaisesTODOS = pais.getListaPaises();
                listaPaisesTODOS.Insert(0, "TODOS");
                Application["listaPaisesTODOS"] = listaPaisesTODOS; // LISTA DE PAISES CON EL AGREGADO DE 'TODOS' PARA LA PANTALLA DE CONSULTA
            }

            using (AreaDropDownList area = new AreaDropDownList())// SE RECIBE DE LA CAPA BLL LA LISTA DE AREAS PROVENIENTE DE LA BASE DE DATOS.
            {
                Application["listaAreas"] = area.getListaAreas();// LISTA CON SOLO LAS AREAS PARA LOS DROPDOWN DE NUEVO CONTACTO, ABRIR CONTACTO Y EDITAR CONTACTO.

                List<String> listaAreasTODOS = area.getListaAreas();
                listaAreasTODOS.Insert(0, "TODOS");
                Application["listaAreasTODOS"] = listaAreasTODOS; // LISTA DE PAISES CON EL AGREGADO DE 'TODOS' PARA LA PANTALLA DE CONSULTA
            }

            List<String> DropDownSiNoTODOS = new List<String> { "TODOS", "Si", "No" };

            Application["listaSiNoTODOS"] = DropDownSiNoTODOS;

            List<String> DropDownSiNo = new List<String> { "Si", "No" };

            Application["listaSiNo"] = DropDownSiNo;

            List<String> dropDownGenero = new List<string> { "Masculino", "Femenino" };

            Application["listaGenero"] = dropDownGenero;
        }
    }
}