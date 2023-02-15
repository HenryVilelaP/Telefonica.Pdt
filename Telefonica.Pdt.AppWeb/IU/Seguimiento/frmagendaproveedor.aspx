<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmagendaproveedor.aspx.vb"
    Inherits="Telefonica.Pdt.AppWeb.frmagendaproveedor" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="customCalendar" Namespace="customCalendar" TagPrefix="cc1" %>
<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PdT</title>
    <link href="../../style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
            <tr>
                <td>
                    <table style="width: 1002px" cellspacing="0" cellpadding="0" align="left" border="0">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <uc4:cuCabecera ID="CuCabecera1" runat="server" />
                            </td>
                        </tr>
                        <tr style="height: 450px">
                            <td style="width: 5px">
                            </td>
                            <td valign="top">
                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                    <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                        <td style="height: 30px">
                                            <asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server">ADMINISTRAR AGENDA</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table id="tFiltroAvanzado" cellspacing="1" cellpadding="1" width="100%" border="0"
                                                visible="true" runat="server">
                                                <tr>
                                                    <td align="right" style="width: 14%" class="TablaColumnaEtiqueta">
                                                        <asp:Label ID="Label3" runat="server" CssClass="normaldetalle">Proveedor</asp:Label></td>
                                                    <td class="TablaFilaPar" width="29%">
                                                        <asp:DropDownList ID="ddlbProveedor" runat="server" CssClass="InputTexto" Width="85%"
                                                            CausesValidation="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvProveedor" runat="server" ControlToValidate="ddlbProveedor">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td align="right" class="TablaColumnaEtiqueta" style="width: 14%">
                                                        <asp:Label ID="Label4" runat="server" CssClass="normaldetalle">Producto:</asp:Label></td>
                                                    <td class="TablaFilaPar" style="width: 29%">
                                                        <asp:DropDownList ID="ddlbProducto" runat="server" CssClass="InputTexto" Width="85%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ControlToValidate="ddlbProducto">*</asp:RequiredFieldValidator></td>
                                                    <td class="TablaColumnaEtiqueta" style="width: 14%" align="right">
                                                        <asp:Button ID="btnConsultar" runat="Server" CssClass="InputBoton" Text="Consultar" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="TablaColumnaEtiqueta" style="width: 14%">
                                                        <asp:Label ID="Label1" runat="server" CssClass="normaldetalle">Ver Fechas:</asp:Label></td>
                                                    <td class="TablaFilaPar" colspan="3" width="29%">
                                                        <asp:Label ID="Label2" runat="server" CssClass="normaldetalle">Desde:</asp:Label>
                                                        <cc1:webCalendar ID="calFechaInicio" runat="server" CssClass="InputTexto" FechaServerPagina="true"
                                                            RutaImagen="../../Images/calendar/cal.gif" RutaJavaScript="../../Script/popcalendar.js"
                                                            Validable="false" ValidableErrorMessage="Fecha es requerido" Width="60px" />
                                                        <asp:Label ID="Label5" runat="server" CssClass="normaldetalle">Hasta:</asp:Label>
                                                        <cc1:webCalendar ID="calFechaFin" runat="server" CssClass="InputTexto" FechaServerPagina="true"
                                                            RutaImagen="../../Images/calendar/cal.gif" RutaJavaScript="../../Script/popcalendar.js"
                                                            Validable="false" ValidableErrorMessage="Fecha es requerido" Fecha="" Width="60px" />
                                                    </td>
                                                    <td class="TablaColumnaEtiqueta" style="width: 14%" align="right">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="TablaColumnaEtiqueta" style="width: 14%">
                                                    </td>
                                                    <td class="TablaFilaPar" width="29%">
                                                    </td>
                                                    <td align="right" class="TablaColumnaEtiqueta" style="width: 14%">
                                                    </td>
                                                    <td class="TablaFilaPar" style="width: 29%">
                                                    </td>
                                                    <td class="TablaColumnaEtiqueta" style="width: 14%" align="right">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top">
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <table style="width: 100%" cellspacing="1" cellpadding="1" align="left" border="0">
                                                <tr>
                                                    <td style="width: 50%" rowspan="2" valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <table style="width: 100%" cellspacing="1" cellpadding="1" align="center" border="0">
                                                                                <tr>
                                                                                    <td rowspan="2" valign="top" style="width: 50%">
                                                                                        <asp:DataGrid ID="grid" runat="server" Width="100%" AutoGenerateColumns="False" HorizontalAlign="Center"
                                                                                            AllowPaging="True" PageSize="10" ShowFooter="True">
                                                                                            <FooterStyle CssClass="FooterGrilla" />
                                                                                            <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                                                            <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                                                            <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                            <HeaderStyle CssClass="HeaderGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                            <Columns>
                                                                                                <asp:BoundColumn HeaderText="Nº">
                                                                                                    <HeaderStyle Width="2%" />
                                                                                                </asp:BoundColumn>
                                                                                                <asp:TemplateColumn HeaderText="FECHA">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="lbkbFecha" runat="server" CssClass="ItemGrillaLink"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle Width="40%" />
                                                                                                    <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:BoundColumn HeaderText="DIA DE SEMANA" DataField="NombreDia">
                                                                                                    <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                                                    <HeaderStyle Width="15%" />
                                                                                                </asp:BoundColumn>
                                                                                                <asp:TemplateColumn HeaderText="CIERRE">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Image ID="imgCierre" runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                                    <HeaderStyle Width="15%" />
                                                                                                </asp:TemplateColumn>
                                                                                                <asp:BoundColumn Visible="false" HeaderText="NO EMITIDOS" DataField="NoEmitidos">
                                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                                    <HeaderStyle Width="15%" />
                                                                                                </asp:BoundColumn>
                                                                                                <asp:BoundColumn Visible="false" HeaderText="PEDIDO INVALIDO" DataField="PedidoInvalido">
                                                                                                    <ItemStyle Width="15%" HorizontalAlign="Center" />
                                                                                                    <HeaderStyle Width="15%" />
                                                                                                </asp:BoundColumn>
                                                                                            </Columns>
                                                                                        </asp:DataGrid>
                                                                                        <input id="hCodigo" style="width: 2px; height: 2px" type="hidden" name="hCodigo"
                                                                                            runat="server">
                                                                                        <input id="hGrillaIndicePagina" style="width: 2px; height: 2px" type="hidden" name="hGrillaIndicePagina"
                                                                                            runat="server">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td align="right" style="height: 8px">
                                                                                        <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:</asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:DataGrid ID="gridc" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                    HorizontalAlign="Center">
                                                                    <FooterStyle CssClass="FooterGrilla" />
                                                                    <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                                    <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                                    <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                    <HeaderStyle CssClass="HeaderGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                    <Columns>
                                                                        <asp:BoundColumn HeaderText="N&#186;">
                                                                            <HeaderStyle Width="2%" />
                                                                        </asp:BoundColumn>
                                                                        <asp:BoundColumn DataField="zgrpc_iIdZona_Grp_Instalacion" Visible="False"></asp:BoundColumn>
                                                                        <asp:TemplateColumn>
                                                                            <ItemTemplate>
                                                                                <asp:Image ID="imgEstadoFecha" runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="8%" />
                                                                        </asp:TemplateColumn>
                                                                        <asp:BoundColumn HeaderText="ZONA" DataField="zgrpc_vDescripcion">
                                                                            <ItemStyle Width="40%" Height="20px" HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="40%" Height="20px" HorizontalAlign="Center" />
                                                                        </asp:BoundColumn>
                                                                        <asp:TemplateColumn HeaderText="BAJAR A EXCEL">
                                                                            <ItemStyle Width="30%" />
                                                                            <ItemTemplate>
                                                                                <asp:Literal ID="ltlExportaExcel" runat="server"></asp:Literal>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="20%" />
                                                                        </asp:TemplateColumn>
                                                                        <asp:TemplateColumn HeaderText="CERRAR FECHA" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton ID="lbkbReAbrirFecha" runat="server" CssClass="normaldetalle">Re-Abrir</asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkbCerrarFecha" runat="server" CssClass="normaldetalle">Cerrar</asp:LinkButton>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="30%" />
                                                                            <ItemStyle Width="30%" />
                                                                        </asp:TemplateColumn>
                                                                    </Columns>
                                                                </asp:DataGrid><input id="hCodigoCierre" style="width: 2px; height: 2px" type="hidden"
                                                                    name="hCodigoCierre" runat="server">
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DataGrid ID="gridd" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                HorizontalAlign="Center">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                                                <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                                                <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn HeaderText="N&#186;">
                                                                                        <HeaderStyle Width="2%" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="cupoc_iIdCupo" Visible="False">
                                                                                        <HeaderStyle Width="0%" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn HeaderText="FRANJA" DataField="Franja">
                                                                                        <ItemStyle Width="15%" HorizontalAlign="Left" />
                                                                                        <HeaderStyle Width="15%" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn HeaderText="GRUPO" DataField="grpic_vDescripcion">
                                                                                        <HeaderStyle Width="45%" />
                                                                                        <ItemStyle Width="45%" HorizontalAlign="Left" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:TemplateColumn HeaderText="CUPOS">
                                                                                        <HeaderStyle Height="20px" Width="15%" />
                                                                                        <ItemStyle Height="20px" Width="15%" />
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblCupos" runat="server"></asp:Label>
                                                                                            <asp:LinkButton ID="lnkbCupos" Visible="false" runat="server"></asp:LinkButton>
                                                                                            <asp:Literal ID="ltlExportaExcel" runat="server"></asp:Literal>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                    <asp:BoundColumn HeaderText="RESERVAS" DataField="Reserva">
                                                                                        <HeaderStyle Width="10%" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:BoundColumn Visible="false" HeaderText="RES. NO EMITIDAS" DataField="ReservaNoEmitida">
                                                                                        <HeaderStyle Width="15%" />
                                                                                    </asp:BoundColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid>
                                                                            <input id="hCodigoCupo" style="width: 2px; height: 2px" type="hidden" name="hCodigoCupo"
                                                                                runat="server">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="pnlDetalleCupo" Visible="false" runat="server" Width="100%">
                                                                                <table style="width: 100%" cellspacing="1" cellpadding="1" align="left" border="0">
                                                                                    <tr>
                                                                                        <td style="width: 30%" align="center" class="TablaFilaTitulo" colspan="2">
                                                                                            <asp:Label ID="Label8" runat="server" CssClass="TituloPrincipalAzul">Agregar nuevos grupos y horarios a esta fecha
                                                                                            </asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%" align="right" class="TablaColumnaEtiqueta">
                                                                                            <asp:Label ID="lblGrupo" runat="server" CssClass="normaldetalle">Grupo de Instalacion:</asp:Label></td>
                                                                                        <td style="width: 70%" class="TablaFilaPar">
                                                                                            <asp:DropDownList ID="ddlbGrupoInstalacion" Enabled="false" runat="server" CssClass="InputTexto"
                                                                                                Width="85%">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%" align="right" class="TablaColumnaEtiqueta">
                                                                                            <asp:Label ID="Label6" runat="server" CssClass="normaldetalle">Franja Horaria:</asp:Label></td>
                                                                                        <td style="width: 70%" class="TablaFilaPar">
                                                                                            <asp:DropDownList ID="ddlbFranja" Enabled="false" runat="server" CssClass="InputTexto"
                                                                                                Width="30%">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%" align="right" class="TablaColumnaEtiqueta">
                                                                                            <asp:Label ID="Label7" runat="server" CssClass="normaldetalle">Nº Cupos:</asp:Label></td>
                                                                                        <td style="width: 70%" class="TablaFilaPar">
                                                                                            <ew:NumericBox ID="nbCupos" ReadOnly="true" runat="server" CssClass="InputTexto"
                                                                                                Width="20%" PositiveNumber="True" RealNumber="False"></ew:NumericBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 30%" align="right" class="TablaColumnaEtiqueta">
                                                                                        </td>
                                                                                        <td style="width: 70%" class="TablaFilaPar">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="center" class="TablaColumnaEtiqueta" colspan="2">
                                                                                            <asp:Button ID="btnGrabar" runat="Server" Enabled="false" CssClass="InputBoton" Text="Grabar"
                                                                                                Width="60px" />
                                                                                            <asp:Button ID="btnCancelar" runat="server" CssClass="InputBoton" Text="Cancelar"
                                                                                                Width="60px" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 50%">
                                                    </td>
                                                    <td style="width: 50%">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdateProgress ID="upgProcesandoWeb" runat="server" DisplayAfter="250">
                                                <ProgressTemplate>
                                                    <uc2:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <uc3:cuPiePagina ID="CuPiePagina1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>

    <script>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
    </script>

</body>
</html>
