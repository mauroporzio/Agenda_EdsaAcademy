<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="Agenda_EdsaAcademy.WebForm1" %>

<link href="Estilo.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="TituloEspaciado">
                <asp:Label ID ="titulo" runat ="server" Text="Consulta de Agenda" CssClass ="Titulo"></asp:Label>
            </div>
            <div class ="CamposConsulta">
                 <table width="100%" id ="TablaConsulta" runat ="server" class="TablaConsulta">
                    <tr>
                        <td>
                            <asp:Label ID="lableApellidoNombre" runat ="server" Text ="Apellido y nombre" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxApellidoNombre" runat="server"></asp:TextBox>

                            <asp:Label ID="LablePais" runat ="server" Text ="Pais" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListPais" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelLocalidad" runat ="server" Text ="Localidad" Width="10%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxLocalidad" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="LabelFechaDeIngresoDesde" runat ="server" Text ="Fecha De Ingreso Desde" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textFechaDeIngresoDesde" runat="server"></asp:TextBox>

                            <asp:Label ID="LabelFechaDeIngresoHasta" runat ="server" Text ="Fecha De Ingreso Hasta" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textFechaDeIngresoHasta" runat="server" Width="10%"></asp:TextBox>


                            <asp:Label ID="LabelContactoInterno" runat ="server" Text ="Contacto Interno" Width="10%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownContactoInterno" runat="server" AutoPostBack="true" Width="10%" OnSelectedIndexChanged="esContactoInterno"></asp:DropDownList>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label ID="LabelOrganizacion" runat ="server" Text ="Organizacion" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="TextBoxOrganizacion" runat="server"></asp:TextBox>

                            <asp:Label ID="LabelArea" runat ="server" Text ="Area" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownArea" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelActivo" runat ="server" Text ="Activo" Width="10%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownActivo" runat="server" Width="10%"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:CustomValidator ID="ValidatorFechas" runat="server" OnServerValidate="validarFechas" ErrorMessage="*Fecha de Ingreso Desde debe ser anterior o igual que Fecha de Ingreso Hasta*" ForeColor ="Red" ControlToValidate="textFechaDeIngresoDesde"></asp:CustomValidator>
                </div>
                <div>
                    <asp:ImageButton ID="ImageButtonLimpiarCampos" runat="server" ImageUrl="Imagenes Botones\clearFilter.png" CssClass="botonLimiarCampos" OnClick="limpiarFiltros"/>

                    <asp:Button ID="ButtonNuevoContacto" runat="server" Text="Nuevo Contacto" CssClass="botonNuevoContacto" />

                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="botonConsulta" OnClick="buscarPorFiltro"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
