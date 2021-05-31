using Agenda.Entity;
using Agenda.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace Agenda_EdsaAcademy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<String> listaPaises = (List<String>)Application["listaPaisesTODOS"];
                DropDownListPais.DataSource = listaPaises;
                DropDownListPais.DataBind();

                DropDownActivo.DataSource = new List<String> { "TODOS", "Si", "No" };
                DropDownActivo.DataBind();

                List<String> listaAreas = (List<string>)Application["listaAreasTODOS"];
                DropDownArea.DataSource = listaAreas;
                DropDownArea.DataBind();
                DropDownArea.SelectedValue = "TODOS";
                DropDownArea.Enabled = false;
                DropDownArea.BackColor = System.Drawing.Color.LightGray;

                TextBoxOrganizacion.Enabled = false;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

                DropDownContactoInterno.DataSource = new List<String> { "TODOS", "Si", "No" };
                DropDownContactoInterno.DataBind();
            }
        }

        public void cambiarIndicePagina(object sender, GridViewPageEventArgs e)
        {
            GridViewResultadosConsulta.DataSource = ViewState["listaContactosResultadoConsulta"];
            GridViewResultadosConsulta.PageIndex = e.NewPageIndex;
            GridViewResultadosConsulta.DataBind();
        }

        public void limpiarFiltros(object sender, ImageClickEventArgs e)
        {
            textBoxApellidoNombre.Text = "";
            textBoxLocalidad.Text = "";
            textFechaDeIngresoDesde.Text = "";
            textFechaDeIngresoHasta.Text = "";
            TextBoxOrganizacion.Text = "";

            DropDownActivo.SelectedValue = "TODOS";
            DropDownArea.SelectedValue = "TODOS";
            DropDownListPais.SelectedValue = "TODOS";
            DropDownContactoInterno.SelectedValue = "TODOS";

            TextBoxOrganizacion.Enabled = true;
            TextBoxOrganizacion.BackColor = System.Drawing.Color.Empty;
            TextBoxOrganizacion.BorderColor = System.Drawing.Color.Empty;

            DropDownArea.Enabled = true;
            DropDownArea.BackColor = System.Drawing.Color.Empty;

            GridViewResultadosConsulta.DataSource = null;
            GridViewResultadosConsulta.DataBind();

        }

        public void validarFechas(object source, ServerValidateEventArgs fecha)
        {
            if (textFechaDeIngresoHasta.Text.Length > 0)
            {
                DateTime fechaHasta = DateTime.ParseExact(textFechaDeIngresoHasta.Text, new string[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy" }, null, DateTimeStyles.AssumeLocal);
                fecha.IsValid = DateTime.ParseExact(fecha.Value, new string[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy" }, null, DateTimeStyles.AssumeLocal) <= fechaHasta;
                
            }
        }

        public void esContactoInterno(object source, EventArgs e)
        {
            if (DropDownContactoInterno.SelectedValue.Equals("Si"))
            {
                TextBoxOrganizacion.Text = "";
                TextBoxOrganizacion.Enabled = false;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

                DropDownArea.Enabled = true;
                DropDownArea.BackColor = System.Drawing.Color.Empty;
            }
            else if (DropDownContactoInterno.SelectedValue.Equals("No"))
            {
                TextBoxOrganizacion.Text = "";
                TextBoxOrganizacion.Enabled = true;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.Empty;
                TextBoxOrganizacion.BorderColor = System.Drawing.Color.Empty;

                DropDownArea.SelectedValue = "TODOS";
                DropDownArea.Enabled = false;
                DropDownArea.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                TextBoxOrganizacion.Text = "";
                TextBoxOrganizacion.Enabled = false;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.Empty;
                TextBoxOrganizacion.BorderColor = System.Drawing.Color.Empty;

                DropDownArea.SelectedValue = "TODOS";
                DropDownArea.Enabled = false;
                DropDownArea.BackColor = System.Drawing.Color.LightGray;
            }
        }

        public void buscarPorFiltro(object sender, EventArgs e)
        {
            List<FiltroContacto> listaFiltrosUsados = new List<FiltroContacto>();

            if (textBoxApellidoNombre.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE, valorFiltro = textBoxApellidoNombre.Text });
            }

            if (!DropDownListPais.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.PAIS, valorFiltro = DropDownListPais.SelectedValue });
            }

            if (textBoxLocalidad.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.LOCALIDAD, valorFiltro = textBoxLocalidad.Text });
            }

            if (textFechaDeIngresoDesde.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE, valorFiltroDate = DateTime.ParseExact(textFechaDeIngresoDesde.Text, new string[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy" } , null, DateTimeStyles.AssumeLocal) });
            }

            if (textFechaDeIngresoHasta.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA, valorFiltroDate = DateTime.ParseExact(textFechaDeIngresoHasta.Text, new string[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy" }, null, DateTimeStyles.AssumeLocal) });
            }

            if (!DropDownContactoInterno.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.CONTACTO_INTERNO, valorFiltro = DropDownContactoInterno.SelectedValue });
            }

            if (TextBoxOrganizacion.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ORGANIZACION, valorFiltro = TextBoxOrganizacion.Text });
            }

            if (!DropDownArea.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.AREA, valorFiltro = DropDownArea.SelectedValue });
            }

            if (!DropDownActivo.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ACTIVO, valorFiltro = DropDownActivo.SelectedValue });
            }

            AgendaContactos agendaContactos = (AgendaContactos)Application["AgendaContactos"];

            ViewState.Add("listaContactosResultadoConsulta", agendaContactos.getlistaContactosPorFiltro(listaFiltrosUsados));

            GridViewResultadosConsulta.DataSource = ViewState["listaContactosResultadoConsulta"];
            GridViewResultadosConsulta.DataBind();
        }

        public void botonesGridViewResultadosConsulta(object sender, GridViewCommandEventArgs e)
        {
            AgendaContactos agendaContactos = (AgendaContactos)Application["AgendaContactos"]; // recibo la lista que voy a modificar.

            if (e.CommandName.Equals("eliminarContacto"))
            {
                agendaContactos.eliminarContacto(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });
            }
            else if(e.CommandName.Equals("activarDesactivarContacto"))
            {
                ImageButton boton = (ImageButton)e.CommandSource;

                Contacto contactoCambioEstado = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });

                contactoCambioEstado.activarDesactivarContacto();

                if (contactoCambioEstado.activo.Equals("Si"))
                {
                    //boton.ImageUrl = "/Imagenes Botones/play_pause.png";

                    /*
                    boton.Attributes.Remove("ImageUrl");
                    boton.Attributes.Add("ImageUrl", "Imagenes Botones/anular.png");
                    */
                }
                else
                {
                    //boton.ImageUrl = "/Imagenes Botones/anular.png";

                    /*
                    boton.Attributes.Remove("ImageUrl");
                    boton.Attributes.Add("ImageUrl", "Imagenes Botones/play_pause.png");
                    */
                }
            }
            Application["AgendaContactos"] = agendaContactos; // guardo los cambios.

            buscarPorFiltro(sender, e);
        }
        
        public void nuevoContacto(object sender, EventArgs e)
        {
            Response.Redirect("ConsultaRedireccion.aspx");
        }
    }
}