<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaRedireccion.aspx.cs" Inherits="Agenda_EdsaAcademy.ConsultaRedireccion" %>

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
                <asp:Label ID ="Labeltitulo" runat ="server" CssClass ="Titulo"></asp:Label>
             </div>
            <div class="CamposConsulta">
                <table width="100%" id ="TablaRedireccion" runat ="server" class="TablaConsulta">
                    <tr>
                        <td>
                            <asp:Label ID="lableApellidoNombre" runat ="server" Text ="Apellido y nombre *" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxApellidoNombre" runat="server"></asp:TextBox>                            

                            <asp:Label ID="LabelGenero" runat ="server" Text ="Genero *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListGenero" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LablePais" runat ="server" Text ="Pais *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListPais" runat="server" Width="10%"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelLocalidad" runat ="server" Text ="Localidad" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxLocalidad" runat="server"></asp:TextBox>

                            <asp:Label ID="LabelContactoInterno" runat ="server" Text ="Contacto Interno *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListContactoInterno" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelOrganizacion" runat ="server" Text ="Organizacion *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxOrganizacion" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelArea" runat ="server" Text ="Area" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:DropDownList ID="DropDownListArea" runat="server" Width="9.3%"></asp:DropDownList>

                            <asp:Label ID="LabelActivo" runat ="server" Text ="Activo *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListActivo" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelDireccion" runat ="server" Text ="Direccion" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxDireccion" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelTelefonoFijoInterno" runat ="server" Text ="Telefono Fijo - Interno" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxTelefonoFijoInterno" runat="server" Width="9.3%"></asp:TextBox>

                            <asp:Label ID="LabelTelefonoCelular" runat ="server" Text ="Telefono Celular" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxTelefonoCelular" runat="server" Width="10%"></asp:TextBox>

                            <asp:Label ID="LabelEmail" runat ="server" Text ="E-Mail *" Width="14%" CssClass ="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxEmail" runat="server" Width="10%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="textBoxEmail" 
                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Formato incorrecto" 
                                                            ForeColor="Red">
                            </asp:RegularExpressionValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelSkype" runat ="server" Text ="Skype" Width="14%" CssClass ="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxSkype" runat="server" Width="9.3%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="validationSummaryCamposRequeridos" runat="server" DisplayMode="BulletList" HeaderText="Existen campos requeridos no completados" CssClass="validationSummaryCampos"/>

                            <asp:RequiredFieldValidator ID="validatorApellidoYNombre" runat="server" 
                                                        ErrorMessage="" ControlToValidate="textBoxApellidoNombre">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrganizacion" runat="server" 
                                                        ErrorMessage="" ControlToValidate="textBoxOrganizacion">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                                                        ErrorMessage="" ControlToValidate="textBoxEmail">
                            </asp:RequiredFieldValidator>

                            

                            <asp:CustomValidator ID="ValidatorSkype" runat="server" OnServerValidate="validacionComunicacion" ValidationGroup="GrupocamposRequeridos"></asp:CustomValidator>
                            <asp:CustomValidator ID="ValidatorTelFijo" runat="server" OnServerValidate="validacionComunicacion" ValidationGroup="GrupocamposRequeridos"></asp:CustomValidator>
                            <asp:CustomValidator ID="ValidatorTelCel" runat="server" OnServerValidate="validacionComunicacion" ValidationGroup="GrupocamposRequeridos"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="cancelar" CssClass="botonNuevoContacto" OnClick="cancelarCreacion" CausesValidation="False"/>

                            <asp:Button ID="Button2" runat="server" text="guardar" CssClass="botonConsulta" OnClick="guardarContacto"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
