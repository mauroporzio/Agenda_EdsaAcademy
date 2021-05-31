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
                cargarDropDownLists();

                cargarControlesPorRedireccion();
            }
        }
        public void cargarDropDownLists()
        {
            DropDownListPais.DataSource = (List<string>)Application["listaPaises"];
            DropDownListPais.DataBind();

            DropDownListActivo.DataSource = (List<String>)Application["listaSiNo"];
            DropDownListActivo.DataBind();

            DropDownListArea.DataSource = (List<string>)Application["listaAreas"]; ;
            DropDownListArea.DataBind();

            DropDownListContactoInterno.DataSource = (List<String>)Application["listaSiNo"];
            DropDownListContactoInterno.DataBind();

            DropDownListGenero.DataSource = (List<String>)Application["listaGenero"];
            DropDownListGenero.DataBind();

            DropDownListContactoInterno.SelectedValue = "Si";

            textBoxOrganizacion.Text = "";
            textBoxOrganizacion.Enabled = false;
            textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
            RequiredFieldValidatorOrganizacion.Enabled = false;
        }
        public void cargarControlesPorRedireccion()
        {
            if (Application["controlesACargar"].Equals("Nuevo Contacto"))
            {
                Labeltitulo.Text = "Nuevo Contacto";

                Button2.OnClientClick = "return validateNuevoContacto()";

            }
            else if (Application["controlesACargar"].Equals("Abrir Contacto"))
            {
                Labeltitulo.Text = "Consulta Contacto";

                Button2.Visible = false;
                Button2.Enabled = false;

                Button1.Text = "Salir";

                Contacto contactoAbierto = (Contacto)Application["contactoAbrir"];

                textBoxApellidoNombre.Text = contactoAbierto.apellidoYnombre;
                textBoxDireccion.Text = contactoAbierto.direccion;
                textBoxLocalidad.Text = contactoAbierto.localidad;
                textBoxOrganizacion.Text = contactoAbierto.organizacion;
                textBoxEmail.Text = contactoAbierto.eMail;
                textBoxSkype.Text = contactoAbierto.cuentaSkype;
                textBoxTelefonoCelular.Text = contactoAbierto.telefonoCelular;
                textBoxTelefonoFijoInterno.Text = contactoAbierto.telefonoFijoInterno;

                DropDownListGenero.SelectedValue = contactoAbierto.genero;
                DropDownListPais.SelectedValue = contactoAbierto.pais;
                DropDownListActivo.SelectedValue = contactoAbierto.activo;
                DropDownListArea.SelectedValue = contactoAbierto.area;
                DropDownListContactoInterno.SelectedValue = contactoAbierto.contactoInterno;

                textBoxApellidoNombre.BackColor = System.Drawing.Color.LightGray;
                textBoxDireccion.BackColor = System.Drawing.Color.LightGray;
                textBoxLocalidad.BackColor = System.Drawing.Color.LightGray;
                textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
                textBoxEmail.BackColor = System.Drawing.Color.LightGray;
                textBoxSkype.BackColor = System.Drawing.Color.LightGray;
                textBoxTelefonoCelular.BackColor = System.Drawing.Color.LightGray;
                textBoxTelefonoFijoInterno.BackColor = System.Drawing.Color.LightGray;

                DropDownListGenero.BackColor = System.Drawing.Color.LightGray;
                DropDownListPais.BackColor = System.Drawing.Color.LightGray;
                DropDownListActivo.BackColor = System.Drawing.Color.LightGray;
                DropDownListArea.BackColor = System.Drawing.Color.LightGray;
                DropDownListContactoInterno.BackColor = System.Drawing.Color.LightGray;

                textBoxApellidoNombre.Enabled = false;
                textBoxDireccion.Enabled = false;
                textBoxLocalidad.Enabled = false;
                textBoxOrganizacion.Enabled = false;
                textBoxEmail.Enabled = false;
                textBoxSkype.Enabled = false;
                textBoxTelefonoCelular.Enabled = false;
                textBoxTelefonoFijoInterno.Enabled = false;

                DropDownListGenero.Enabled = false;
                DropDownListPais.Enabled = false;
                DropDownListActivo.Enabled = false;
                DropDownListArea.Enabled = false;
                DropDownListContactoInterno.Enabled = false;
            }
            else
            {
                Labeltitulo.Text = "Editar Contacto";

                Button2.OnClientClick = "return validateEditarContacto()";
                
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

            Contacto contacto = new Contacto()
            {
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
                telefonoFijoInterno = textBoxTelefonoFijoInterno.Text
            };

            if (Application["controlesACargar"].Equals("Nuevo Contacto"))
            {
                contacto.id = agendaContactos.listaContactos.Count + 1;
                contacto.fechaIngreso = DateTime.Today;

                agendaContactos.insertarContacto(contacto);
            }
            else
            {
                Contacto contactoEditar = (Contacto)Application["contactoEditar"];

                contacto.id = contactoEditar.id;
                contacto.fechaIngreso = contactoEditar.fechaIngreso;

                agendaContactos.modificarContacto(contacto);
            }
            Response.Redirect("Consulta.aspx");
        }
    }
}