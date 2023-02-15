<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmAdminListaCotizacion"
    CodeFile="frmAdminListaCotizacion.aspx.vb"%>

<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc3" %>

<%@ Register Assembly="customCalendar" Namespace="customCalendar" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc2" %>
    
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PdT - Administración de Cotización</title>
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">
    <link href="../../Style/Style.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tGeneral" style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
            <tr>
                <td>
                    <table id="tWFijo" cellspacing="0" cellpadding="0" align="left" border="0">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <table id="tPrincipal" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
                                    border="0">
                                    <tr style="width: 100%; height: 90px" valign="top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <uc2:cuCabecera ID="CuCabecera1" runat="server" />
                                            </td>
                                    </tr>
                                    <tr style="height: 455px">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td valign="top">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="left"
                                                border="0">
                                                 <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                                    <td>
                                                        <asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server">BUSQUEDA DE COTIZACIONES</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0">
                                                            <tr>
                                                                <td class="TablaColumnaEtiqueta" style="height: 27px">
                                                                    <asp:Label ID="lblRuc" CssClass="normal" runat="server">R.U.C. :</asp:Label>
                                                                </td>
                                                                <td class="TablaFilaPar" style="height: 27px">
                                                                    <ew:NumericBox ID="nbRuc" CssClass="InputTexto" runat="server" MaxLength="11"
                                                                        Width="110px" DecimalPlaces="0"/>
                                                                </td>
                                                                <td class="TablaColumnaEtiqueta" style="height: 27px">
                                                                    <asp:Label ID="lblClienteAtis" CssClass="normal" runat="server">Cliente ATIS :</asp:Label>
                                                                </td>
                                                                <td class="TablaFilaPar" style="height: 27px">
                                                                    <ew:NumericBox ID="nbClienteAtis" CssClass="InputTexto" runat="server" MaxLength="9"
                                                                        Width="110px" DecimalPlaces="0" />
                                                                </td>
                                                                <td style="height: 27px; width: 120px;" class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblNumeroCotizacionFiltro" CssClass="normal" runat="server">Número Cotización :</asp:Label>
                                                                </td>
                                                                <td style="height: 27px" class="TablaFilaPar">
                                                                    <ew:NumericBox ID="nbNumeroCotizacion" CssClass="InputTexto" runat="server" MaxLength="9"
                                                                        Width="90px" DecimalPlaces="0" />
                                                                </td>
                                                                <td style="height: 27px" class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblEstadoCotizacion" CssClass="normal" runat="server">Estado :</asp:Label>
                                                                </td>
                                                                <td style="height: 27px" class="TablaFilaPar">
                                                                    <asp:DropDownList ID="ddlEstadoCotizacion" CssClass="InputTexto" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 25px;" class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblNombreCliente" CssClass="normal" runat="server">Nombre cliente :</asp:Label>
                                                                </td>
                                                                <td colspan="3" class="TablaFilaPar" style="height: 25px">
                                                                    <asp:TextBox ID="txtNombreCliente" CssClass="InputTexto" runat="server" MaxLength="120"
                                                                        Width="300px" />
                                                                </td>
                                                                <td style="width: 120px" class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblFechaIngresoInicio" CssClass="normal" runat="server">Ver Fechas Desde :</asp:Label>
                                                                </td>
                                                                <td class="TablaFilaPar">
                                                                    <cc1:webCalendar ID="calFechaRegistroInicio" runat="server" FechaServerPagina="true"
                                                                        RutaImagen="../../Images/calendar/cal.gif" RutaJavaScript="../../Script/popcalendar.js"
                                                                        Validable="false" ValidableErrorMessage="Fecha es requerido"  CssClass="InputTexto"/>
                                                                </td>
                                                                <td class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblFecIngFin" CssClass="normal" runat="server">Hasta :</asp:Label>
                                                                </td>
                                                                <td class="TablaFilaPar">
                                                                    &nbsp;<cc1:webCalendar ID="calFechaRegistroFin" runat="server" FechaServerPagina="true"
                                                                        RutaImagen="../../Images/calendar/cal.gif" RutaJavaScript="../../Script/popcalendar.js"
                                                                        Validable="false" ValidableErrorMessage="Fecha es requerido"  CssClass="InputTexto"/>
                                                                </td>
                                                                <td class="TablaColumnaEtiqueta">
                                                                    <asp:Button ID="btnConsultar" CssClass="InputBoton" runat="Server" Text="Consultar" CausesValidation="false">
                                                                    </asp:Button></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" align="right" border="0">
                                                                        <tr>
                                                                            <td align="right">
                                                                                <input id="hCodigo" style="width: 18px; height: 18px" type="hidden" name="hCodigo"
                                                                                    runat="server">
                                                                                <input id="hGrillaIndicePagina" style="width: 18px; height: 18px" type="hidden" name="hGrillaIndicePagina"
                                                                                    runat="server">
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:Button ID="btnNuevo" CssClass="InputBoton" runat="Server" Text="Nuevo" OnClick="btnNuevo_Click"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 181px" align="center" valign="top">
                                                                    <asp:GridView ID="grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
                                                                        AllowPaging="True" HorizontalAlign="Center" OnRowDataBound="grid_RowDataBound" OnRowCommand="grid_RowCommand">
                                                                        <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                                                                        <AlternatingRowStyle CssClass="AlternateItemGrilla"></AlternatingRowStyle>
                                                                        <RowStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></RowStyle>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                                                                        <Columns>
                                                                            <asp:BoundField DataField="cotic_iIdCotizacion" HeaderText="Id Cotizacion" Visible="False">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="cotic_vRazon_Social" HeaderText="Nombre / Raz&#243;n Social">
                                                                                 <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="cotic_iNum_Cotizacion" HeaderText="Cotizaci&#243;n">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="vectc_iDescrEstado_Cotizacion" HeaderText="Estado">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField DataField="cotic_dFec_Registro" HeaderText="Fecha Registro">
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="Modificar">
                                                                                <HeaderStyle Width="70px" />
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgbtnModificar" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Modificar.gif"
                                                                                            PostBackUrl="~/IU/Seguimiento/frmdetallecotizacion.aspx" ></asp:ImageButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Nueva Versi&#243;n">
                                                                                <HeaderStyle Width="70px"></HeaderStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgbtnNuevaVersion" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Ejecutar.gif"
                                                                                        CommandName="GrillaEventoNuevaVersion"></asp:ImageButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Movimientos" Visible="False">
                                                                                <HeaderStyle Width="70px"></HeaderStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgbtnListarMovimientos" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Estados.gif"
                                                                                        CommandName="GrillaEventoListarMovimientos"></asp:ImageButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bit&#225;cora"  Visible="False">
                                                                                <HeaderStyle Width="70px"></HeaderStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgbtnVerBitacora" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Detalles.gif"
                                                                                        CommandName="GrillaEventoVerBitacora"></asp:ImageButton>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" >
                                                                        </PagerStyle>
                                                                    </asp:GridView>
                                                                    <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 17px">
                                                                    &nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%; height: 25px" cellspacing="0" cellpadding="0" border="0">
                                                                        <tr>
                                                                            <td style="height: 25px">
                                                                            </td>
                                                                            <td align="right" style="height: 25px">
                                                                                <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="normal" Visible="False">Total de Registros Encontrados:&nbsp;</asp:Label></td>
                                                                            <td width="50" style="height: 25px">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="WIDTH: 100%; HEIGHT: 60px" valign="top">
											<!--Region del Pie de Pagina de PdT -->
											<td id="cPiePagina">
                                                <uc1:cuPiePagina ID="CuPiePagina1" runat="server" />
                                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                    <ProgressTemplate>
                                                        <uc3:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
											
											</td>
										</tr>
                                </table>
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