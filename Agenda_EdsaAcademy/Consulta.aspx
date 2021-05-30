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
                    <asp:CustomValidator ID="ValidatorFechas" runat="server" OnServerValidate="validarFechas" 
                                         ErrorMessage="*Fecha de Ingreso Desde debe ser anterior o igual que Fecha de Ingreso Hasta*" 
                                         ForeColor ="Red" ControlToValidate="textFechaDeIngresoDesde">
                    </asp:CustomValidator>
                </div>
                <div>
                    <asp:ImageButton ID="ImageButtonLimpiarCampos" runat="server" ImageUrl="Imagenes Botones\clearFilter.png" 
                                     CssClass="botonLimiarCampos" OnClick="limpiarFiltros"/>

                    <asp:Button ID="ButtonNuevoContacto" runat="server" Text="Nuevo Contacto" CssClass="botonNuevoContacto" onClick="nuevoContacto"/>

                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="botonConsulta" OnClick="buscarPorFiltro"/>
                </div>
                <div>
                    <asp:GridView ID="GridViewResultadosConsulta" runat="server" Width ="100%" OnRowCommand="botonesGridViewResultadosConsulta" AutoGenerateColumns ="false" RowStyle-HorizontalAlign ="Center" GridLines ="Horizontal" AllowPaging="true" PageSize="5" OnPageIndexChanging="cambiarIndicePagina">
                        <Columns>
                            <asp:BoundField DataField="apellidoYnombre" HeaderText="Apellido y Nombre" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="genero" HeaderText="Genero" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="pais" HeaderText="Pais" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="localidad" HeaderText="Localidad" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="contactoInterno" HeaderText="Contacto Interno" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="organizacion" HeaderText="Organizacion" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="area" HeaderText="Area" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha de Ingreso" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="activo" HeaderText="Activo" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="telefonoFijoInterno" HeaderText="Tel. Fijo Interno" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="telefonoCelular" HeaderText="Tel. Celular" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="eMail" HeaderText="E-Mail" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:BoundField DataField="cuentaSkype" HeaderText="Cuenta Skype" HeaderStyle-CssClass ="HeaderResultadoConsulta"/>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonBorrarContacto" runat="server" ImageUrl="Imagenes Botones/delete.png" CommandArgument='<%# Eval("id") %>' CommandName="eliminarContacto" OnClientClick="return confirm('Estas Seguro que desea eliminar este contacto?')" />
                                    <asp:ImageButton ID="ImageButtonAbrirContacto" runat="server" ImageUrl="Imagenes Botones/zoom.png" />
                                    <asp:ImageButton ID="ImageButtonEditarContacto" runat="server" ImageUrl="Imagenes Botones/edit.png" />
                                    <asp:ImageButton ID="ImageButtonActivarDesactivarContacto" runat="server" ImageUrl="Imagenes Botones/play_pause.png" CommandArgument='<%# Eval("id") %>' CommandName="activarDesactivarContacto"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" CssClass="botonesPagerGridView" />
                        <PagerSettings Mode="NextPreviousFirstLast" 
                                       PageButtonCount="1" NextPageImageUrl="Imagenes Botones/arrow-right.svg" 
                                       PreviousPageImageUrl="Imagenes Botones/arrow-left.svg" Position="Bottom" 
                                       FirstPageImageUrl="Imagenes Botones/chevron-bar-left.svg" 
                                       LastPageImageUrl="Imagenes Botones/chevron-bar-right.svg"/>
                        <RowStyle CssClass="HeaderResultadoConsulta"/>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
