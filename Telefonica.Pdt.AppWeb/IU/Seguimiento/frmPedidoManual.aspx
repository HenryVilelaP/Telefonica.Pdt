<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmPedidoManual"
    CodeFile="frmPedidoManual.aspx.vb" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PEDIDOS MANUALES</title>
    <link href="../../style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script type="text/jscript" language="javascript" src="../../Script/jscript.js"></script>

    <link href="../../Style/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="Table6" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
            border="0">
            <tr>
                <td style="width: 1000px">
                    <table id="Table7" style="width: 1002px" cellspacing="0" cellpadding="0" align="left"
                        border="0">
                        <tr>
                            <td style="width: 5px; height: 108px;">
                            </td>
                            <td style="width: 1020px; height: 108px;">
                                <uc4:cuCabecera ID="CuCabecera1" runat="server" />
                            </td>
                        </tr>
                        <tr style="height: 450px">
                            <td style="width: 5px">
                            </td>
                            <td valign="top" style="width: 1020px">
                                <table id="Table8" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
                                    border="0">
                                    <tr>
                                        <td>
                                            <table id="Table9" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
                                                border="0">
                                                <tr>
                                                    <td style="height: 17px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table id="Table10" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <input id="hIdPedido" runat="server" name="hIdPedido" style="width: 10px; height: 10px"
                                                                        type="hidden" />
                                                                    <input id="hIdPaquete" runat="server" name="hIdPaquete" style="width: 10px; height: 10px"
                                                                        type="hidden" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2">
                                                                    <table id="Table15" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                                    <tr>
                                                                                        <td class="TablaFilaTitulo" style="height: 22px" width="25%">
                                                                                            <asp:Label ID="lbltitulo1" runat="server" CssClass="TituloPrincipal">Datos Vendedor</asp:Label></td>
                                                                                        <td class="TablaFilaTitulo" style="height: 22px" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" style="height: 22px" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" style="height: 22px" width="25%">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblCodigoVendedor" runat="server" CssClass="normal" Text="Codigo Vendedor"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txtCodigoVendedor" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblNombreVendedor" runat="server" CssClass="normal" Width="132px"
                                                                                                Text="Nombre Vendedor"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txtNombreVendedor" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" style="height: 20px" width="25%">
                                                                                            <asp:Label ID="lblTelefonoVendedor" runat="server" CssClass="normal" Text="Telefono Vendedor"></asp:Label></td>
                                                                                        <td style="height: 20px" width="25%">
                                                                                            <asp:TextBox ID="txtTelefonoVendedor" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                        <td class="TablaColumnaEtiqueta" style="height: 20px" width="25%">
                                                                                        </td>
                                                                                        <td style="height: 20px" width="25%">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                            <asp:Label ID="lbltitulo2" runat="server" CssClass="TituloPrincipal" Text="Datos del Cliente"></asp:Label></td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblZonal" runat="server" CssClass="normal" Text="Zonal"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:DropDownList ID="ddlzonal" runat="server" CssClass="InputTexto" Width="90%">
                                                                                            </asp:DropDownList></td>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblcliente" runat="server" CssClass="normal" Width="152px" Text="Cliente"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txtcliente" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblTipoDocumento" runat="server" CssClass="normal" Text="Tipo Documento"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="InputTexto" Width="90%">
                                                                                            </asp:DropDownList></td>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblNumeroDocumento" runat="server" CssClass="normal" Width="152px"
                                                                                                Text="Número Documento"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txtnumerodocumento" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblNombreContacto" runat="server" CssClass="normal" Text="Nombre Contacto"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txtNombreContacto" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblTelefonoContacto" runat="server" CssClass="normal" Width="144px"
                                                                                                Text="Telefóno Contacto"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:TextBox ID="txttelefonodocumento" runat="server" CssClass="InputTexto" Width="90%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblsegmento" runat="server" CssClass="normal" Text="Segmento"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:DropDownList ID="ddlsegmento" runat="server" CssClass="InputTexto" Width="90%">
                                                                                            </asp:DropDownList></td>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblSubSegmento" runat="server" CssClass="normal" Width="144px" Text="Subsegmento"></asp:Label></td>
                                                                                        <td width="25%">
                                                                                            <asp:DropDownList ID="ddlSubSegmento" runat="server" CssClass="InputTexto" Width="90%">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                            <strong>
                                                                                                <asp:Label ID="lbltitulo3" runat="server" CssClass="TituloPrincipal" Text="Datos del pedido"></asp:Label></strong></td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                        <td class="TablaFilaTitulo" width="25%">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="TablaColumnaEtiqueta" width="25%">
                                                                                            <asp:Label ID="lblEligeTipo" runat="server" CssClass="normal" Text="Elige el tipo de producto/paquete"></asp:Label></td>
                                                                                        <td width="25%" colspan="3">
                                                                                            <asp:RadioButton ID="rbProductoComplejo" runat="server" CssClass="normaldetalle"
                                                                                                Text="Paquetes Complejos" Checked="true"/>
                                                                                        </td>
                                                                                        <td width="25%" colspan="4">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="10">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id="Table17" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="pnlPaquetesComplejos" runat="server" Visible="true" Width="100%">
                                                                                    <table id="Table16" width="50%" cellspacing="0" cellpadding="0" align="center" border="0">
                                                                                        <tr>
                                                                                            <td class="TablaColumnaEtiqueta" align="left" width="25%">
                                                                                                <asp:Label ID="lblProductosComplejos" CssClass="normal" runat="server" Text="Productos Complejos"></asp:Label></td>
                                                                                            <td width="25%">
                                                                                                <asp:DropDownList ID="ddlProductosComplejos" runat="server" CssClass="InputTexto">
                                                                                                </asp:DropDownList></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="10">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table id="Table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td class="TablaFilaTitulo" width="25%">
                                                                                <asp:Label ID="LblTitulo4" runat="server" CssClass="TituloPrincipal">Datos adicionales</asp:Label></td>
                                                                            <td class="TablaFilaTitulo" width="25%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="TablaColumnaEtiqueta" width="25%">
                                                                                <asp:Label ID="lblEmailZonaSeguridad" runat="server" CssClass="normal" Width="184px" Text="Email Zona de Seguridad"></asp:Label></td>
                                                                            <td width="75%">
                                                                                <asp:TextBox ID="txtEmailZonaSeguridad" runat="server" CssClass="InputTexto"></asp:TextBox><asp:Label
                                                                                    ID="lblMensaje" runat="server" CssClass="normal" Width="424px" Text="Solo para PDTI. Email al que se enviará instrucciones para activar la zona de seguridad"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="TablaColumnaEtiqueta" width="25%">
                                                                                <asp:Label ID="lblObservaciones" runat="server" CssClass="normal" Width="184px" Text="Observaciones EC"></asp:Label></td>
                                                                            <td width="75%">
                                                                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="InputTexto" Width="352px"
                                                                                    TextMode="MultiLine" Height="48px"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table id="Table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                            <tr>
                                                                <td align="center" style="height: 11px">
                                                                    <asp:Button ID="btnRegistrar" runat="server" CssClass="InputBoton" Width="84px" Text="Registrar" PostBackUrl="~/IU/Seguimiento/frmPedidoManualPedidosComplejos.aspx">
                                                                    </asp:Button></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td style="width: 1020px">
                                <uc3:cuPiePagina ID="CuPiePagina1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>

    <script type="text/jscript">
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
    </script>

</body>
</html>
