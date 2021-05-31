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
                cargarCamposFiltrosyResultados();

                cargarDropDownLists();
            }
        }
        public void cargarCamposFiltrosyResultados()
        {
            List<FiltroContacto> listaFiltrosReCarga = (List<FiltroContacto>)Application["listaFiltrosUsados"];

            if (listaFiltrosReCarga != null)
            {
                foreach (FiltroContacto filtroContacto in listaFiltrosReCarga)
                {
                    switch (filtroContacto.idFiltro)
                    {
                        case (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE:
                            textBoxApellidoNombre.Text = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.LOCALIDAD:
                            textBoxLocalidad.Text = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE:
                            textFechaDeIngresoDesde.Text = filtroContacto.valorFiltroDate.ToString();
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA:
                            textFechaDeIngresoHasta.Text = filtroContacto.valorFiltroDate.ToString();
                            break;

                        case (int)OPCIONES_FILTRO.CONTACTO_INTERNO:
                            DropDownContactoInterno.SelectedValue = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.ORGANIZACION:
                            TextBoxOrganizacion.Text = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.AREA:
                            DropDownArea.SelectedValue = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.ACTIVO:
                            DropDownActivo.SelectedValue = filtroContacto.valorFiltro;
                            break;
                        case (int)OPCIONES_FILTRO.PAIS:
                            DropDownListPais.SelectedValue = filtroContacto.valorFiltro;
                            break;
                        default:
                            break;
                    }
                }

                AgendaContactos agendaContactos = (AgendaContactos)Application["AgendaContactos"];

                GridViewResultadosConsulta.DataSource = agendaContactos.getlistaContactosPorFiltro(listaFiltrosReCarga);
                GridViewResultadosConsulta.DataBind();

            }
            else
            {
                GridViewResultadosConsulta.DataSource = Application["listaContactosResultadoConsulta"];
                GridViewResultadosConsulta.DataBind();
            }
        }
        public void cargarDropDownLists()
        {
            List<String> listaPaises = (List<String>)Application["listaPaisesTODOS"];
            DropDownListPais.DataSource = listaPaises;
            DropDownListPais.DataBind();

            DropDownActivo.DataSource = (List<String>)Application["listaSiNoTODOS"];
            DropDownActivo.DataBind();

            List<String> listaAreas = (List<string>)Application["listaAreasTODOS"];
            DropDownArea.DataSource = listaAreas;
            DropDownArea.DataBind();
            DropDownArea.SelectedValue = "TODOS";
            DropDownArea.Enabled = false;
            DropDownArea.BackColor = System.Drawing.Color.LightGray;

            TextBoxOrganizacion.Enabled = false;
            TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

            DropDownContactoInterno.DataSource = (List<String>)Application["listaSiNoTODOS"];
            DropDownContactoInterno.DataBind();
        }
        public void cambiarIndicePagina(object sender, GridViewPageEventArgs e)
        {
            GridViewResultadosConsulta.DataSource = Application["listaContactosResultadoConsulta"];
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

            DropDownArea.SelectedValue = "TODOS";
            DropDownArea.Enabled = false;
            DropDownArea.BackColor = System.Drawing.Color.LightGray;

            TextBoxOrganizacion.Enabled = false;
            TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

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
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE, valorFiltroDate = DateTime.ParseExact(textFechaDeIngresoDesde.Text, new string[] { "dd/MM/yyyy", "d/M/yyyy", "yyyy" }, null, DateTimeStyles.AssumeLocal) });
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

            Application["listaFiltrosUsados"] = listaFiltrosUsados;

            Application["listaContactosResultadoConsulta"] = agendaContactos.getlistaContactosPorFiltro(listaFiltrosUsados);

            GridViewResultadosConsulta.DataSource = Application["listaContactosResultadoConsulta"];
            GridViewResultadosConsulta.DataBind();
        }
        public void botonesGridViewResultadosConsulta(object sender, GridViewCommandEventArgs e)
        {
            AgendaContactos agendaContactos = (AgendaContactos)Application["AgendaContactos"]; // recibo la lista de contactos que voy a utilizar.

            if (e.CommandName.Equals("eliminarContacto"))
            {
                agendaContactos.eliminarContacto(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });
            }
            else if (e.CommandName.Equals("activarDesactivarContacto"))
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
            else if (e.CommandName.Equals("abrirContacto"))
            {
                Application["controlesACargar"] = "Abrir Contacto";

                Application["contactoAbrir"] = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });

                Response.Redirect("ConsultaRedireccion.aspx");
            }

            else if (e.CommandName.Equals("editarContacto"))
            {
                Application["controlesACargar"] = "Editar Contacto";

                Application["contactoEditar"] = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });

                Response.Redirect("ConsultaRedireccion.aspx");
            }

            Application["AgendaContactos"] = agendaContactos; // guardo los cambios.

            buscarPorFiltro(sender, e);
        }
        public void nuevoContacto(object sender, EventArgs e)
        {
            Application["controlesACargar"] = "Nuevo Contacto";

            Response.Redirect("ConsultaRedireccion.aspx");
        }
    }

}