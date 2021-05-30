using System;
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

        public void cancelarCreacion(object sender, EventArgs e)
        {
            Response.Redirect("Consulta.aspx");
        }

        public void guardarContacto(object sender, EventArgs e)
        {


            Response.Redirect("Consulta.aspx");
        }
    }
}