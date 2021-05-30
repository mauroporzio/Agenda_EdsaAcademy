using System;
using Agenda.Entity;
using Agenda.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda_EdsaAcademy
{
    public partial class ConsultaRedireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<String> listaPaises = (List<string>)Application["listaPaises"];
                DropDownListPais.DataSource = listaPaises;
                DropDownListPais.DataBind();

                DropDownListActivo.DataSource = new List<String> { "Si", "No" };
                DropDownListActivo.DataBind();

                List<String> listaAreas = (List<string>)Application["listaAreas"];
                DropDownListArea.DataSource = listaAreas;
                DropDownListArea.DataBind();

                DropDownListContactoInterno.DataSource = new List<String> { "Si", "No" };
                DropDownListContactoInterno.DataBind();

                DropDownListContactoInterno.SelectedValue = "Si";
                textBoxOrganizacion.Text = "";
                textBoxOrganizacion.Enabled = false;
                textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
                RequiredFieldValidatorOrganizacion.Enabled = false;


                DropDownListGenero.DataSource = new List<String> { "Masculino", "Femenino" };
                DropDownListGenero.DataBind();
            }
        }
        public void validacionComunicacion(object source, ServerValidateEventArgs e)
        {
            Boolean hayTelFijoInterno = LabelTelefonoFijoInterno.Text.Length > 0;
            Boolean hayTelCelular = LabelTelefonoCelular.Text.Length > 0;
            Boolean haySkype = LabelSkype.Text.Length > 0;

            e.IsValid = hayTelCelular || hayTelFijoInterno || haySkype;
        }
        public void esContactoInterno(object source, EventArgs e)
        {
            if (DropDownListContactoInterno.SelectedValue.Equals("Si"))
            {
                textBoxOrganizacion.Text = "";
                textBoxOrganizacion.Enabled = false;
                textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
                RequiredFieldValidatorOrganizacion.Enabled = false;

                DropDownListArea.DataSource = (List<string>)Application["listaAreas"];
                DropDownListArea.DataBind();
                DropDownListArea.Enabled = true;
                DropDownListArea.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                textBoxOrganizacion.Text = "";
                textBoxOrganizacion.Enabled = true;
                textBoxOrganizacion.BackColor = System.Drawing.Color.Empty;
                textBoxOrganizacion.BorderColor = System.Drawing.Color.Empty;
                RequiredFieldValidatorOrganizacion.Enabled = true;

                DropDownListArea.Enabled = false;
                DropDownListArea.BackColor = System.Drawing.Color.LightGray;
                DropDownListArea.DataSource = new List<String>();
                DropDownListArea.DataBind();
            }
        }
        public void cancelarCreacion(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }
        public void guardarContacto(object sender, EventArgs e)
        {
            AgendaContactos agendaContactos = (AgendaContactos)Application["AgendaContactos"];

            agendaContactos.insertarContacto(new Contacto()
            {
                id = agendaContactos.listaContactos.Count,
                apellidoYnombre = textBoxApellidoNombre.Text,
                activo = DropDownListActivo.SelectedValue,
                area = DropDownListArea.SelectedValue,
                contactoInterno = DropDownListContactoInterno.SelectedValue,
                cuentaSkype = textBoxSkype.Text,
                direccion = textBoxDireccion.Text,
                eMail = textBoxEmail.Text,
                genero = DropDownListGenero.SelectedValue,
                localidad = textBoxLocalidad.Text,
                organizacion = textBoxOrganizacion.Text,
                pais = DropDownListPais.SelectedValue,
                telefonoCelular = textBoxTelefonoCelular.Text,
                telefonoFijoInterno = textBoxTelefonoFijoInterno.Text,
                fechaIngresoDesde = DateTime.Now.ToShortDateString()
            });



            Response.Redirect("Consulta.aspx");
        }
    }
}