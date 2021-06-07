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
    public partial class ConsultaRedireccionConMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDropDownLists();

                cargarControlesPorRedireccion();
            }
        }
        public void cargarDropDownLists() // SE CARGAN EN EL PAGE LOAD LAS DROP DOWN LISTS.
        {
            using (PaisDropDownList pais = new PaisDropDownList()) // SE RECIBE DE LA CAPA BLL LA LISTA DE PAISES PROVENIENTE DE LA BASE DE DATOS.
            {
                DropDownListPais.DataSource = pais.getListaPaises();
                DropDownListPais.DataBind();
            }

            DropDownListActivo.DataSource = (List<String>)Application["listaSiNoTODOS"];
            DropDownListActivo.DataBind();

            using (AreaDropDownList area = new AreaDropDownList())// SE RECIBE DE LA CAPA BLL LA LISTA DE AREAS PROVENIENTE DE LA BASE DE DATOS.
            {
                DropDownListArea.DataSource = area.getListaAreas();
                DropDownListArea.DataBind();
            }

            DropDownListActivo.DataSource = (List<String>)Application["listaSiNo"];
            DropDownListActivo.DataBind();

            DropDownListContactoInterno.DataSource = (List<String>)Application["listaSiNo"];
            DropDownListContactoInterno.DataBind();

            DropDownListGenero.DataSource = (List<String>)Application["listaGenero"];
            DropDownListGenero.DataBind();
        }
        public void cargarControlesPorRedireccion() // SE CARGAN DE MANERA PARTICULAR A CADA CASO DE REDIRECCION, SE HABILITAN Y RESTRINGEN CAMPOS SEGUN SEA NECESARIO.
        {
            if (Application["controlesACargar"].Equals("Nuevo Contacto"))
            {
                Labeltitulo.Text = "Nuevo Contacto";

                DropDownListContactoInterno.SelectedValue = "Si";

                textBoxOrganizacion.Text = "";
                textBoxOrganizacion.Enabled = false;
                textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
                RequiredFieldValidatorOrganizacion.Enabled = false;

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
                DropDownListContactoInterno.SelectedValue = contactoAbierto.contactoInterno;
                DropDownListArea.SelectedValue = contactoAbierto.area;

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

                Contacto contactoEditar = (Contacto)Application["contactoEditar"];

                textBoxApellidoNombre.Text = contactoEditar.apellidoYnombre;
                textBoxDireccion.Text = contactoEditar.direccion;
                textBoxLocalidad.Text = contactoEditar.localidad;

                textBoxEmail.Text = contactoEditar.eMail;
                textBoxSkype.Text = contactoEditar.cuentaSkype;
                textBoxTelefonoCelular.Text = contactoEditar.telefonoCelular;
                textBoxOrganizacion.Text = contactoEditar.organizacion;
                textBoxTelefonoFijoInterno.Text = contactoEditar.telefonoFijoInterno;

                DropDownListGenero.SelectedValue = contactoEditar.genero;
                DropDownListPais.SelectedValue = contactoEditar.pais;
                DropDownListContactoInterno.SelectedValue = contactoEditar.contactoInterno;
                DropDownListArea.SelectedValue = contactoEditar.area;


                if (contactoEditar.contactoInterno.Equals("Si"))
                {
                    textBoxOrganizacion.Text = "";
                    textBoxOrganizacion.Enabled = false;
                    textBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;
                    RequiredFieldValidatorOrganizacion.Enabled = false;

                    DropDownListArea.SelectedValue = contactoEditar.area;
                }
                else
                {
                    DropDownListArea.DataSource = new List<String>() { "" };
                    DropDownListArea.SelectedValue = "";
                    DropDownListArea.DataBind();
                    DropDownListArea.Enabled = false;
                    DropDownListArea.BackColor = System.Drawing.Color.LightGray;

                    textBoxOrganizacion.Text = contactoEditar.organizacion;
                }

                Button2.OnClientClick = "return validateEditarContacto()";

            }
        }
        public void esContactoInterno(object source, EventArgs e) // METODO ENCARGADO DE MANEJAR SEGUN EN QUE ESTADO SE ENCUENTRE EL CAMPO DE CONTACTO INTERNO, SE HABILITAN O RESTRINGEN DIFERENTES CAMPOS.
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
            Response.Redirect("ConsultaConMaster.aspx");
        }// METODO ENCARGADO DE REDIRECCIONAR A LA PAGINA DE CONSULTA SI SE CANCELA LA OPERACION EN CURSO.
        public void guardarContacto(object sender, EventArgs e)
        {
            Contacto contacto = new Contacto()
            {
                apellidoYnombre = textBoxApellidoNombre.Text,
                cuentaSkype = textBoxSkype.Text,
                eMail = textBoxEmail.Text,
                genero = DropDownListGenero.SelectedValue,
                pais = DropDownListPais.SelectedValue,
                telefonoCelular = textBoxTelefonoCelular.Text,
                telefonoFijoInterno = textBoxTelefonoFijoInterno.Text,
                contactoInterno = DropDownListContactoInterno.SelectedValue,
                activo = DropDownListActivo.SelectedValue
            };

            if (textBoxLocalidad.Text.Length > 0)
            {
                contacto.localidad = textBoxLocalidad.Text;
            }
            else
            {
                contacto.localidad = null;
            }

            if (textBoxDireccion.Text.Length > 0)
            {
                contacto.direccion = textBoxDireccion.Text;
            }
            else
            {
                contacto.direccion = null;
            }

            if (textBoxOrganizacion.Text.Length > 0)
            {
                contacto.organizacion = textBoxOrganizacion.Text;
            }
            else
            {
                contacto.organizacion = null;
            }

            if (DropDownListArea.SelectedValue.Length > 0)
            {
                contacto.area = DropDownListArea.SelectedValue;
            }
            else
            {
                contacto.area = null;
            }

            if (Application["controlesACargar"].Equals("Nuevo Contacto"))
            {
                using (IAgendaContactos agendaContacto = new AgendaContactos())
                {
                    agendaContacto.insertarContacto(contacto);
                }
            }
            else
            {
                Contacto contactoEditar = (Contacto)Application["contactoEditar"];

                contacto.id = contactoEditar.id;
                contacto.fechaIngreso = contactoEditar.fechaIngreso;

                using (IAgendaContactos agendaContacto = new AgendaContactos())
                {
                    agendaContacto.modificarContacto(contacto);
                }
            }
            Response.Redirect("ConsultaConMaster.aspx");
        }// METODO ENCARGADO DE REGISTRAR LOS CAMBIAS Y PASARLOS A LA BLL EN FORMA DE CONTACTO,YA SEA NUEVO O EDITADO.
    }
}