using Agenda.Entity;
using Agenda.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_EdsaAcademy
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DropDownListPais.DataSource = Application["listaPaises"];
                DropDownListPais.DataBind();

                DropDownActivo.DataSource = new List<String> { "TODOS", "Si", "No" };
                DropDownActivo.DataBind();

                DropDownArea.DataSource = Application["listaAreas"];
                DropDownArea.DataBind();

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
                DateTime fechaHasta = DateTime.Parse(textFechaDeIngresoHasta.Text);
                fecha.IsValid = DateTime.Parse(fecha.Value) <= fechaHasta;
            }
        }

        public void esContactoInterno(object source, EventArgs e)
        {
            if (DropDownContactoInterno.SelectedValue.Equals("Si"))
            {
                TextBoxOrganizacion.Text = "";
                TextBoxOrganizacion.Enabled = false;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

                DropDownArea.Enabled = false;
                DropDownArea.BackColor = System.Drawing.Color.LightGray;
            }
            else
            {
                TextBoxOrganizacion.Text = "";
                TextBoxOrganizacion.Enabled = true;
                TextBoxOrganizacion.BackColor = System.Drawing.Color.Empty;
                TextBoxOrganizacion.BorderColor = System.Drawing.Color.Empty;

                DropDownArea.SelectedValue = "TODOS";
                DropDownArea.Enabled = true;
                DropDownArea.BackColor = System.Drawing.Color.Empty;
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
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE, valorFiltro = textFechaDeIngresoDesde.Text });
            }

            if (textFechaDeIngresoHasta.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA, valorFiltro = textFechaDeIngresoHasta.Text });
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

            ViewState.Add("listaContactosResultadoConsulta",new AgendaContactos((List<Contacto>)Application["listaContactos"]).getlistaContactosPorFiltro(listaFiltrosUsados));

            GridViewResultadosConsulta.DataSource = ViewState["listaContactosResultadoConsulta"];
            GridViewResultadosConsulta.DataBind();
        }
    }
}