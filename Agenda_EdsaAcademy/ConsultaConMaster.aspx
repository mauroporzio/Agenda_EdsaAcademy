<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaConMaster.aspx.cs" Inherits="Agenda_EdsaAcademy.ConsultaConMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Estilo.css" rel="stylesheet" type="text/css" />

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
        <div>
            <div class="TituloEspaciado">
                <asp:Label ID="titulo" style="font-size:16pt" runat="server" Text="Consulta de Agenda" CssClass="Titulo"></asp:Label>
            </div>
            <div class="CamposConsulta">
                <asp:ScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ScriptManager>
                <table width="100%" id="TablaConsulta" runat="server" class="TablaConsulta">
                    <tr>
                        <td>
                            <asp:Label ID="lableApellidoNombre" runat="server" Text="Apellido y Nombre" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textBoxApellidoNombre" runat="server"></asp:TextBox>

                            <asp:Label ID="LablePais" runat="server" Text="País" Width="19%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownListPais" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad" Width="15%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textBoxLocalidad" runat="server" Width="10%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelFechaDeIngresoDesde" runat="server" Text="Fecha de ingreso desde" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="textFechaDeIngresoDesde" runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderDesde" runat="server" TargetControlID="textFechaDeIngresoDesde" Format="dd/MM/yyyy" />

                            <asp:Label ID="LabelFechaDeIngresoHasta" runat="server" Text="Fecha de ingreso hasta" Width="19%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:TextBox ID="textFechaDeIngresoHasta" runat="server" Width="10%"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtenderHasta" runat="server" TargetControlID="textFechaDeIngresoHasta" Format="dd/MM/yyyy"/>

                            <asp:Label ID="LabelContactoInterno" runat="server" Text="Contacto interno" Width="15%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownContactoInterno" runat="server" AutoPostBack="true" Width="10%" OnSelectedIndexChanged="esContactoInterno"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelOrganizacion" runat="server" Text="Organización" Width="14%" CssClass="TextoConsulta"></asp:Label>
                            <asp:TextBox ID="TextBoxOrganizacion" runat="server"></asp:TextBox>

                            <asp:Label ID="LabelArea" runat="server" Text="Área" Width="19%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownArea" runat="server" Width="10%"></asp:DropDownList>

                            <asp:Label ID="LabelActivo" runat="server" Text="Activo" Width="15%" CssClass="TextoConsultaOtraColumna"></asp:Label>
                            <asp:DropDownList ID="DropDownActivo" runat="server" Width="10%"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div>
                    <asp:CustomValidator ID="ValidatorFechas" runat="server" OnServerValidate="validarFechas"
                        ErrorMessage="Fecha de ingreso desde debe ser anterior o igual que fecha de ingreso hasta"
                        CssClass="validationSummaryCampos">
                    </asp:CustomValidator>
                </div>
                <div>
                    <asp:ImageButton ID="ImageButtonLimpiarCampos" runat="server" ImageUrl="Imagenes Botones\clearFilter.png"
                        CssClass="botonLimiarCampos" OnClick="limpiarFiltros" />

                    <asp:Button ID="ButtonNuevoContacto" runat="server" Text="Nuevo contacto" CssClass="botonNuevoContacto" OnClick="nuevoContacto" />

                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="botonConsulta" OnClick="buscarPorFiltro" />
                </div>
                <div>
                    <asp:GridView ID="GridViewResultadosConsulta" runat="server" Width="100%" 
                                  OnRowCommand="botonesGridViewResultadosConsulta" AutoGenerateColumns="false" 
                                  RowStyle-HorizontalAlign="Center" GridLines="Horizontal" AllowPaging="true" 
                                  PageSize="5" OnPageIndexChanging="cambiarIndicePagina" RowStyle-CssClass="HeaderResultadoConsulta">
                        <Columns>
                            <asp:BoundField DataField="apellidoYnombre" HeaderText="Apellido y Nombre" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="genero" HeaderText="Género" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="pais" HeaderText="País" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="localidad" HeaderText="Localidad" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="contactoInterno" HeaderText="Contacto interno" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="organizacion" HeaderText="Organización" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="area" HeaderText="Área" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha de ingreso" HeaderStyle-CssClass="HeaderResultadoConsulta" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="activo" HeaderText="Activo" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="direccion" HeaderText="Dirección" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="telefonoFijoInterno" HeaderText="Tel. Fijo interno" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="telefonoCelular" HeaderText="Tel. celular" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="eMail" HeaderText="E-Mail" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="cuentaSkype" HeaderText="Cuenta Skype" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:BoundField DataField="cuil" HeaderText="CUIL" HeaderStyle-CssClass="HeaderResultadoConsulta" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButtonBorrarContacto" runat="server"
                                        ImageUrl="Imagenes Botones/delete.png" CommandArgument='<%# Eval("id") %>'
                                        CommandName="eliminarContacto"
                                        OnClientClick="return confirm('Estas Seguro que desea eliminar este contacto?')"
                                        ToolTip="Borrar contacto" />

                                    <asp:ImageButton ID="ImageButtonAbrirContacto" runat="server"
                                        ImageUrl="Imagenes Botones/zoom.png" CommandArgument='<%# Eval("id") %>'
                                        CommandName="abrirContacto"
                                        ToolTip="Abrir contacto" />

                                    <asp:ImageButton ID="ImageButtonEditarContacto" runat="server" ImageUrl="Imagenes Botones/edit.png"
                                        CommandArgument='<%# Eval("id") %>' CommandName="editarContacto"
                                        ToolTip="Editar contacto" />

                                    <asp:ImageButton ID="ImageButtonActivarDesactivarContacto" runat="server"
                                        ImageUrl='<%# Eval("activo").Equals("Si") ? "Imagenes Botones/anular.png" : "Imagenes Botones/play_pause.png" %>'
                                        OnClientClick='<%# Eval("activo").Equals("Si") ? "return confirmCambioActivo()" : "return confirmCambioInactivo()"%>'
                                        CommandArgument='<%# Eval("id") %>' CommandName="activarDesactivarContacto"
                                        ToolTip='<%# Eval("activo").Equals("Si") ? "Inactivar contacto" : "Activar contacto" %>' />
                                    <script>
                                        function confirmCambioActivo() {
                                            return confirm('¿Desea inactivar el contacto?')
                                        }
                                        function confirmCambioInactivo() {
                                            return confirm('¿Desea activar el contacto?')
                                        }
                                    </script>
                                    <style type="text/css">
                                        th
                                        {
                                            text-align:center;
                                        }
                                    </style>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle HorizontalAlign="Center" CssClass="botonesPagerGridView" />
                        <PagerSettings Mode="NextPreviousFirstLast"
                            PageButtonCount="1" NextPageImageUrl="Imagenes Botones/arrow-right.svg"
                            PreviousPageImageUrl="Imagenes Botones/arrow-left.svg" Position="Bottom"
                            FirstPageImageUrl="Imagenes Botones/chevron-bar-left.svg"
                            LastPageImageUrl="Imagenes Botones/chevron-bar-right.svg" />
                        <RowStyle CssClass="HeaderResultadoConsulta"/>
                    </asp:GridView>
                </div>
            </div>
        </div>
</body>
</html>
</asp:Content>
