<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaRedireccionConMaster.aspx.cs" Inherits="Agenda_EdsaAcademy.ConsultaRedireccionConMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
        <div>
            <div class="TituloEspaciado">
                <asp:Label ID="Labeltitulo"  style="font-size:16pt" runat="server" CssClass="Titulo"></asp:Label>
            </div>
            <div class="CamposConsulta">
                <table width="100%" id="TablaRedireccion" runat="server" class="TablaConsulta">
                    <tr>
                        <td>
                            <asp:Label ID="lableApellidoNombre" runat="server" Text="Apellido y Nombre *" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxApellidoNombre" runat="server" OnTextChanged="obtenerCuil" AutoPostBack="true"></asp:TextBox>

                            <asp:Label ID="LabelGenero" runat="server" Text="Género *" Width="16%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListGenero" runat="server" Width="10%" OnSelectedIndexChanged ="obtenerCuil" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="LablePais" runat="server" Text="País *" Width="14%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListPais" runat="server" Width="10%"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxLocalidad" runat="server"></asp:TextBox>

                            <asp:Label ID="LabelContactoInterno" runat="server" Text="Contacto interno *" Width="16%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListContactoInterno" runat="server" Width="10%" OnSelectedIndexChanged="esContactoInterno" AutoPostBack="true"></asp:DropDownList>

                            <asp:Label ID="LabelOrganizacion" runat="server" Text="Organización *" Width="14%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxOrganizacion" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelArea" runat="server" Text="Área" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:DropDownList ID="DropDownListArea" runat="server" Width="9.3%"></asp:DropDownList>

                            <asp:Label ID="LabelActivo" runat="server" Text="Activo *" Width="16%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListActivo" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelDireccion" runat="server" Text="Dirección" Width="14%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxDireccion" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelTelefonoFijoInterno" runat="server" Text="Teléfono fijo - Interno" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxTelefonoFijoInterno" runat="server" Width="9.3%"></asp:TextBox>

                            <asp:Label ID="LabelTelefonoCelular" runat="server" Text="Teléfono Celular" Width="16%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxTelefonoCelular" runat="server" Width="10%"></asp:TextBox>

                            <asp:Label ID="LabelEmail" runat="server" Text="E-Mail *" Width="14%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxEmail" runat="server" Width="10%"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="textBoxEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Formato incorrecto"
                                CssClass="validationSummaryCampos">
                            </asp:RegularExpressionValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelSkype" runat="server" Text="Skype" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxSkype" runat="server" Width="9.3%"></asp:TextBox>

                            <asp:Label ID="LabelCuil" runat="server" Text="CUIL" Width="16%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxCuil" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ValidationSummary ID="validationSummaryCamposRequeridos" runat="server" DisplayMode="BulletList" HeaderText="Existen campos requeridos no completados" CssClass="validationSummaryCampos" />

                            <asp:RequiredFieldValidator ID="validatorApellidoYNombre" runat="server"
                                ErrorMessage="" ControlToValidate="textBoxApellidoNombre">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrganizacion" runat="server"
                                ErrorMessage="" ControlToValidate="textBoxOrganizacion">
                            </asp:RequiredFieldValidator>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                                ErrorMessage="" ControlToValidate="textBoxEmail">
                            </asp:RequiredFieldValidator>

                            <asp:CustomValidator ID="ValidatorCamposComunicacion" runat="server"
                                ErrorMessage="" ValidateEmptyText="true" ClientValidationFunction="validarComunicacion">
                            </asp:CustomValidator>

                            <script>
                                function validarComunicacion(source, args) {

                                    args.IsValid = false;

                                    if (document.getElementById('<% =textBoxSkype.ClientID %>').value.length > 0) {
                                        args.IsValid = true;
                                    }
                                    if (document.getElementById('<% =textBoxTelefonoCelular.ClientID %>').value.length > 0) {
                                        args.IsValid = true;
                                    }
                                    if (document.getElementById('<% =textBoxTelefonoFijoInterno.ClientID %>').value.length > 0) {
                                        args.IsValid = true;
                                    }
                                }
                            </script>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Cancelar" CssClass="botonNuevoContacto" OnClick="cancelarCreacion" CausesValidation="False" />


                            <asp:Button ID="Button2" runat="server" Text="Guardar" CssClass="botonConsulta" OnClick="guardarContacto" />

                            <script>
                                function validateNuevoContacto() {
                                    if (Page_ClientValidate()) {
                                        if (confirm('¿Desea dar de alta el nuevo contacto?')) {
                                            return alert("Contacto Guardado!"); true;
                                        }
                                        else {
                                            return false;
                                        }
                                    }
                                }

                                function validateEditarContacto() {
                                    if (Page_ClientValidate()) {
                                        if (confirm('¿Desea confirmarlos cambios realizados al contacto ?')) {
                                            return alert("Cambios Guardados!"); true;
                                        }
                                        else {
                                            return false;
                                        }
                                    }
                                }

                            </script>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</body>
</html>

</asp:Content>
