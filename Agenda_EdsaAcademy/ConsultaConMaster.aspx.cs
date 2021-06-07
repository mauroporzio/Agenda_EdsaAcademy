using Agenda.Entity;
using Agenda.BLL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace Agenda_EdsaAcademy
{
    public partial class ConsultaConMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCamposFiltrosyResultados();

                cargarDropDownLists();
            }
        }
        public void cargarCamposFiltrosyResultados() // CARGA LOS CAMPOS, FILTROS Y RESULTADOS SEGUN SI ES PA PRIMERA CARGA O NO.
        {
            List<FiltroContacto> listaFiltrosReCarga = (List<FiltroContacto>)Application["listaFiltrosUsados"];

            textFechaDeIngresoDesde.Attributes.Add("readonly", "readonly"); // SE ASIGNA QUE LAS TEXTBOX DE FECHAS SOLO SEAN READONLY.
            textFechaDeIngresoHasta.Attributes.Add("readonly", "readonly");

            if (listaFiltrosReCarga != null)// SI LA LISTA DE FILTROS NO ESTA VACIA.
            {
                foreach (FiltroContacto filtroContacto in listaFiltrosReCarga)
                {
                    switch (filtroContacto.idFiltro)// CARGO LOS FILTROS EN PANTALLA
                    {
                        case (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE:
                            textBoxApellidoNombre.Text = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.LOCALIDAD:
                            textBoxLocalidad.Text = filtroContacto.valorFiltro;
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE:
                            if (filtroContacto.valorFiltroDate.Equals(DateTime.ParseExact("01/01/1754", "dd/MM/yyyy", null, DateTimeStyles.AssumeLocal)))
                            {
                                textFechaDeIngresoDesde.Text = "";
                            }
                            else
                            {
                                textFechaDeIngresoDesde.Text = filtroContacto.valorFiltroDate.ToShortDateString();
                            }
                            break;

                        case (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA:
                            if (filtroContacto.valorFiltroDate.Equals(DateTime.ParseExact("01/01/9998", "dd/MM/yyyy", null, DateTimeStyles.AssumeLocal)))
                            {
                                textFechaDeIngresoDesde.Text = "";
                            }
                            else
                            {
                                textFechaDeIngresoHasta.Text = filtroContacto.valorFiltroDate.ToShortDateString();
                            }
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

                using (AgendaContactos agendaContacto = new AgendaContactos())
                {
                    List<Contacto> listaContactos = agendaContacto.getlistaContactosPorFiltro(listaFiltrosReCarga);

                    if (listaContactos != null)
                    {
                        listaContactos.OrderBy(Contacto => Contacto.apellidoYnombre).ToList();// ORDENO LOS RESULTADOS ALFABETICAMENTE SI ES QUE LOS HAY.
                    }

                    GridViewResultadosConsulta.DataSource = listaContactos; // CARGO LOS RESULTADOS.
                    GridViewResultadosConsulta.DataBind();
                }

            }
            else
            {
                using (AgendaContactos agendaContacto = new AgendaContactos())
                {
                    List<Contacto> listaContactos = agendaContacto.getlistaContactosPorFiltro(new List<FiltroContacto>()).OrderBy(Contacto => Contacto.apellidoYnombre).ToList();
                    GridViewResultadosConsulta.DataSource = listaContactos; // SI NO TENIA FILTROS CARGO TODA LA LISTA DE CONTACTOS EN ORDEN ALFABETICO.
                    GridViewResultadosConsulta.DataBind();
                }
            }
        }
        public void cargarDropDownLists() // SE CARGAN LAS LISTAS DE DROP DOWN. Y SE "GRISEAN" LOS CAMPOS NECESARIOS PARA COMENZAR A UTILIZAR LA AGENDA.
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
        public void cambiarIndicePagina(object sender, GridViewPageEventArgs e) // METODO ENCARGADO DE EL MANEJO DE LAS PAGINAS DE LA GRID VIEW.
        {
            using (IAgendaContactos agendaContactos = new AgendaContactos())
            {
                GridViewResultadosConsulta.DataSource = agendaContactos.getlistaContactosPorFiltro((List<FiltroContacto>)Application["listaFiltrosUsados"]).OrderBy(Contacto => Contacto.apellidoYnombre).ToList();
                GridViewResultadosConsulta.PageIndex = e.NewPageIndex;
                GridViewResultadosConsulta.DataBind();
            }
        }
        public void limpiarFiltros(object sender, ImageClickEventArgs e) // METODO ENCARGADO DE RESTABLECER LOS CAMPOS DE FILTRADO.
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


            using (AgendaContactos agendaContacto = new AgendaContactos())
            {
                GridViewResultadosConsulta.DataSource = agendaContacto.getlistaContactosPorFiltro(new List<FiltroContacto>()).OrderBy(Contacto => Contacto.apellidoYnombre).ToList();
                GridViewResultadosConsulta.DataBind();
            }

            DropDownArea.SelectedValue = "TODOS";
            DropDownArea.Enabled = false;
            DropDownArea.BackColor = System.Drawing.Color.LightGray;

            TextBoxOrganizacion.Enabled = false;
            TextBoxOrganizacion.BackColor = System.Drawing.Color.LightGray;

            Application["listaFiltrosUsados"] = new List<FiltroContacto>();

        }
        public void validarFechas(object source, ServerValidateEventArgs fecha) // METODO UTILIZADO PARA EL CUSTOM VALIDATOR DE LAS FECHAS.
        {
            if (textFechaDeIngresoHasta.Text.Length > 0 && textFechaDeIngresoDesde.Text.Length > 0)
            {
                DateTime fechaHasta = DateTime.ParseExact(textFechaDeIngresoHasta.Text, "dd/MM/yyyy", null, DateTimeStyles.AssumeLocal);
                fecha.IsValid = DateTime.Parse(textFechaDeIngresoDesde.Text) <= fechaHasta;
            }
            else
            {
                fecha.IsValid = true;
            }
        }
        public void esContactoInterno(object source, EventArgs e) // METODO ENCARGADO DE HABILITAR LOS CAMPOS Y RESTRINGIR OTROS CUANDO EL CONTACTO ES O NO INTERNO.
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
        public void buscarPorFiltro(object sender, EventArgs e) // METODO ENCARGADO DE LEVANTAR LOS FILTROS INGRESADOS POR EL USUARIO Y COMUNICARLO A LA CABA BLL COMO LISTA. PARA LUEGO ASIGNARLA AL GRID.
        {
            List<FiltroContacto> listaFiltrosUsados = new List<FiltroContacto>();

            if (textBoxApellidoNombre.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE, valorFiltro = textBoxApellidoNombre.Text });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.APELLIDO_Y_NOMBRE, valorFiltro = null });
            }

            if (!DropDownListPais.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.PAIS, valorFiltro = DropDownListPais.SelectedValue });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.PAIS, valorFiltro = null });
            }

            if (textBoxLocalidad.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.LOCALIDAD, valorFiltro = textBoxLocalidad.Text });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.LOCALIDAD, valorFiltro = null });
            }

            if (textFechaDeIngresoDesde.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE, valorFiltroDate = DateTime.ParseExact(textFechaDeIngresoDesde.Text, new string[] { "dd/MM/yyyy" }, null, DateTimeStyles.AssumeLocal) });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_DESDE, valorFiltroDate = DateTime.ParseExact("01/01/1754", new string[] { "dd/MM/yyyy" }, null, DateTimeStyles.AssumeLocal) });
            }

            if (textFechaDeIngresoHasta.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA, valorFiltroDate = DateTime.ParseExact(textFechaDeIngresoHasta.Text, new string[] { "dd/MM/yyyy" }, null, DateTimeStyles.AssumeLocal) });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.FECHA_DE_INGRESO_HASTA, valorFiltroDate = DateTime.ParseExact("01/01/9998", new string[] { "dd/MM/yyyy" }, null, DateTimeStyles.AssumeLocal) });
            }

            if (!DropDownContactoInterno.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.CONTACTO_INTERNO, valorFiltro = DropDownContactoInterno.SelectedValue });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.CONTACTO_INTERNO, valorFiltro = null });
            }

            if (TextBoxOrganizacion.Text.Length > 0)
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ORGANIZACION, valorFiltro = TextBoxOrganizacion.Text });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ORGANIZACION, valorFiltro = null });
            }

            if (!DropDownArea.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.AREA, valorFiltro = DropDownArea.SelectedValue });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.AREA, valorFiltro = null });
            }

            if (!DropDownActivo.SelectedValue.Equals("TODOS"))
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ACTIVO, valorFiltro = DropDownActivo.SelectedValue });
            }
            else
            {
                listaFiltrosUsados.Add(new FiltroContacto { idFiltro = (int)OPCIONES_FILTRO.ACTIVO, valorFiltro = null });
            }

            using (AgendaContactos agendaContactos = new AgendaContactos())
            {
                Application["listaFiltrosUsados"] = listaFiltrosUsados;

                List<Contacto> listaContactos = agendaContactos.getlistaContactosPorFiltro(listaFiltrosUsados);

                if (listaContactos != null)
                {
                    listaContactos = listaContactos.OrderBy(Contacto => Contacto.apellidoYnombre).ToList();
                }

                GridViewResultadosConsulta.DataSource = listaContactos;
                GridViewResultadosConsulta.DataBind();
            }
        }
        public void botonesGridViewResultadosConsulta(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName.Equals("eliminarContacto"))
            {
                using (AgendaContactos agendaContactos = new AgendaContactos())
                {
                    agendaContactos.eliminarContacto(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });
                }
            }
            else if (e.CommandName.Equals("activarDesactivarContacto"))
            {
                using (AgendaContactos agendaContactos = new AgendaContactos())
                {
                    Contacto contactoCambioEstado = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });

                    if (contactoCambioEstado.activo.Equals("Si"))
                    {
                        contactoCambioEstado.activo = "No";
                        agendaContactos.modificarContacto(contactoCambioEstado);
                    }
                    else
                    {
                        contactoCambioEstado.activo = "Si";
                        agendaContactos.modificarContacto(contactoCambioEstado);
                    }
                }
            }
            else if (e.CommandName.Equals("abrirContacto"))
            {
                using (AgendaContactos agendaContactos = new AgendaContactos())
                {
                    Application["controlesACargar"] = "Abrir Contacto";

                    Application["contactoAbrir"] = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });



                    Response.Redirect("ConsultaRedireccionConMaster.aspx");
                }
            }
            else if (e.CommandName.Equals("editarContacto"))
            {
                using (AgendaContactos agendaContactos = new AgendaContactos())
                {
                    Application["controlesACargar"] = "Editar Contacto";

                    Application["contactoEditar"] = agendaContactos.getContactoById(new Contacto() { id = Int32.Parse(e.CommandArgument.ToString()) });

                    Response.Redirect("ConsultaRedireccionConMaster.aspx");
                }
            }

            buscarPorFiltro(sender, e);
        }// METODO ENCARGADO DE MANEJAR LAS REDIRECCIONES Y OPERACIONES DE LOS BOTONES POR CONTACTO DEL GRID VIEW CON SUS COMMAND NAME.
        public void nuevoContacto(object sender, EventArgs e) // METODO UTILIZADO PARA LA REDIRECCION HACIA OTRA PAGINA ASPX PARA CARGAR UN NUEVO CONTACTO.
        {
            Application["controlesACargar"] = "Nuevo Contacto";

            Response.Redirect("ConsultaRedireccionConMaster.aspx");
        }
    }
}