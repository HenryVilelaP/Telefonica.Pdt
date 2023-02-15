<%@ Page EnableEventValidation="true" Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmadminlistaPedidos"
    CodeFile="frmadminlistaPedidos.aspx.vb" %>

<%@ Register Src="../../UserControls/cuPedidosRelacionados.ascx" TagName="cuPedidosRelacionados"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/cuAdministracion.ascx" TagName="cuAdministracion"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/cuNuevoSeguimiento.ascx" TagName="cuNuevoSeguimiento"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/cuSeguimiento.ascx" TagName="cuSeguimiento"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/cuMasDatos.ascx" TagName="cuMasDatos" TagPrefix="uc5" %>
<%@ Register Src="../../UserControls/cuCargarDocumetoPedidoProducto.ascx" TagName="cuCargarDocumetoPedidoProducto"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>

<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDT - Configuración - Ciudades</title>
    <link href="../../style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script type="text/jscript" language="javascript" src="../../Script/jscript.js"></script>

    <link href="../../Style/Estilos.css" rel="stylesheet" type="text/css" />
    
</head>
<body class="TablaFilaPar" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
            <tr>
                <td style="width: 931px">
                    <table style="width: 1002px" cellspacing="0" cellpadding="0" align="left" border="0">
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
                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                    <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                        <td>
                                            <asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server">BUSQUEDA DE PEDIDO</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" align="left" border="0" width="100%">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:UpdatePanel ID="UpdatePanelFiltro" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table cellspacing="0" cellpadding="0" align="left" border="0" width="1000">
                                                                    <tr>
                                                                        <td style="width: 1001px">
                                                                            <table id="Table1" cellspacing="1" cellpadding="1" align="left" border="0" width="100%">
                                                                                <tr>
                                                                                    <td align="right" class="TablaColumnaEtiqueta" width="50%">
                                                                                        <asp:Label ID="Label16" runat="server" CssClass="TituloPrincipal"> Indica el modo de búsqueda</asp:Label></td>
                                                                                    <td align="left" class="TablaColumnaEtiqueta" width="50%">
                                                                                        <asp:RadioButtonList ID="rbtnlTipoBusqueda" runat="server" CssClass="normaldetalle"
                                                                                            RepeatDirection="Horizontal" AutoPostBack="True">
                                                                                        </asp:RadioButtonList></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 1001px">
                                                                            <table id="tFiltroIndividual" runat="server" cellspacing="1" cellpadding="1" align="left"
                                                                                border="0" width="100%" visible="false">
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" style="width: 20%;" align="left">
                                                                                        <asp:Label ID="lblNumeroPedido" runat="server" CssClass="normal" Text="# Pedido Legacy o Código Gesneg"></asp:Label></td>
                                                                                    <td style="width: 20%;" class="TablaFilaPar">
                                                                                        <asp:TextBox ID="txtNumeroPedidoWeb" CssClass="normaldetalle" runat="server" MaxLength="15"
                                                                                            Width="45%"></asp:TextBox></td>
                                                                                    <td align="left" class="TablaColumnaEtiqueta" style="width: 20%;">
                                                                                        <asp:Label ID="lblCliente" runat="server" CssClass="normal" Text="Cliente"> </asp:Label></td>
                                                                                    <td class="TablaFilaPar" style="width: 30%;">
                                                                                        <asp:TextBox ID="txtCliente" CssClass="normaldetalle" runat="server" MaxLength="15"
                                                                                            Width="50%"></asp:TextBox><asp:Label ID="Label1" CssClass="normaldetalle" runat="Server"
                                                                                                Text="(Parte o todo del nombre)"></asp:Label></td>
                                                                                    <td align="right" class="TablaColumnaEtiqueta" style="width: 10%;">
                                                                                        <asp:Button ID="btnConsultar" CssClass="InputBoton" runat="Server" Text="Consultar">
                                                                                        </asp:Button></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" style="width: 20%;" align="left">
                                                                                        <asp:Label ID="lblNumeroPedidoWeb" runat="server" CssClass="normal" Text="# Pedido PdT"></asp:Label></td>
                                                                                    <td style="width: 20%;" class="TablaFilaPar">
                                                                                        <asp:TextBox ID="txtNumeroPedido" CssClass="normaldetalle" runat="server" MaxLength="15"
                                                                                            Width="45%"></asp:TextBox></td>
                                                                                    <td align="left" class="TablaColumnaEtiqueta" style="width: 20%;">
                                                                                        <asp:Label ID="lblTelefono" runat="server" CssClass="normal" Text="Teléfono"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" colspan="2">
                                                                                        <asp:TextBox ID="txtTelefono" CssClass="normaldetalle" runat="server" MaxLength="10"
                                                                                            Width="30%"></asp:TextBox>
                                                                                        <asp:Label ID="lblMensaje1" CssClass="normaldetalle" runat="Server" Text="(Teléfono en Gestel o de la Persona en Contacto)">
                                                                                        </asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 1001px">
                                                                            <table id="tFiltroAvanzado" cellspacing="1" cellpadding="1" width="100%" border="0"
                                                                                visible="true" runat="server">
                                                                                <tr>
                                                                                    <td align="left" class="TablaColumnaEtiqueta" width="15%">
                                                                                        <asp:Label ID="Label2" runat="server" CssClass="normal" Text="Estado"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="normaldetalle" Width="95%"
                                                                                            AutoPostBack="True">
                                                                                        </asp:DropDownList></td>
                                                                                    <td align="center" class="TablaColumnaEtiqueta" colspan="2">
                                                                                        <asp:RadioButtonList ID="rbtnlTipoSeguimiento" runat="server" CssClass="normaldetalle"
                                                                                            RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList></td>
                                                                                    <td align="left" class="TablaColumnaEtiqueta" width="10%">
                                                                                        <asp:Label ID="Label10" runat="server" CssClass="normal" Text="Destino"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlDestino" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label3" runat="server" CssClass="normal" Text="Grupo de producto"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlgrupoProducto" runat="server" CssClass="normaldetalle" Width="95%"
                                                                                            AutoPostBack="true">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label6" runat="server" CssClass="normal" Text="Producto"></asp:Label></td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="10%">
                                                                                        <asp:Label ID="Label11" runat="server" CssClass="normal" Text="Cliente"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:TextBox ID="txtcliente1" runat="server" CssClass="normaldetalle" Width="95%"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label4" runat="server" CssClass="normal" Width="101px" Text="Grupo de operación"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlgrupoOperacion" runat="server" CssClass="normaldetalle"
                                                                                            Width="95%" AutoPostBack="true">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label7" runat="server" CssClass="normal" Text="Tipo de Operación"></asp:Label></td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlTipoOperacion" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="10%">
                                                                                        <asp:Label ID="Label12" runat="server" CssClass="normal" Text="Segmento"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlSegmento" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label5" runat="server" CssClass="normal" Text="Zonal"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlZonal" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label8" runat="server" CssClass="normal" Text="Crítico"></asp:Label></td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlCritico" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="10%">
                                                                                        <asp:Label ID="Label13" runat="server" CssClass="normal" Text="Subsegmento"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlSubSegmento" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label9" runat="server" CssClass="normal" Text="Paquete"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlPaquete" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="15%">
                                                                                        <asp:Label ID="Label14" runat="server" CssClass="normal" Width="95px" Text="Fuente del registro"></asp:Label></td>
                                                                                    <td width="20%">
                                                                                        <asp:DropDownList ID="ddlFuente" runat="server" CssClass="normaldetalle" Width="95%">
                                                                                        </asp:DropDownList></td>
                                                                                    <td class="TablaColumnaEtiqueta" align="left" width="10%">
                                                                                        <asp:Label ID="Label15" runat="server" CssClass="normal" Width="65px" Visible="False" Text="Estación ISIS"></asp:Label></td>
                                                                                    <td class="TablaFilaPar" width="20%">
                                                                                        <asp:DropDownList ID="ddlEstacionIsis" runat="server" CssClass="normaldetalle" Width="95%"
                                                                                            Visible="False">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" class="TablaColumnaEtiqueta" colspan="2">
                                                                                        <asp:RadioButtonList ID="rbtnlPedidosEmitibles" runat="server" CssClass="normaldetalle"
                                                                                            RepeatDirection="Horizontal">
                                                                                        </asp:RadioButtonList></td>
                                                                                    <td align="right" class="TablaColumnaEtiqueta" colspan="2">
                                                                                    </td>
                                                                                    <td align="right" class="TablaColumnaEtiqueta" colspan="2">
                                                                                        <asp:Button ID="btnListar" runat="server" CssClass="InputBoton" Text="Listar registros">
                                                                                        </asp:Button></td>
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
                                    <tr valign="top">
                                        <td>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                <tr>
                                                    <td style="width: 1000px;">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td align="right" style="height: 5px">
                                                                            <input id="hCodigo" style="width: 10px; height: 10px" type="hidden" name="hCodigo"
                                                                                runat="server" />
                                                                            <input id="hGrillaIndicePagina" style="width: 10px; height: 10px" type="hidden" name="hGrillaIndicePagina"
                                                                                runat="server" />
                                                                            <input id="hIdPedidoPrd" runat="server" name="hIdPedidoPrd" style="width: 10px;
                                                                                height: 10px" type="hidden" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <asp:DataGrid ID="grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
                                                                                AllowPaging="True" HorizontalAlign="Center" PageSize="5" AllowCustomPaging="True">
                                                                                <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                                                                                <AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></ItemStyle>
                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                                                                                <Columns>
                                                                                    <asp:TemplateColumn>
                                                                                        <HeaderTemplate>
                                                                                            <table id="tGridCabecera" border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                                                                                <tr>
                                                                                                    <td style="width: 55px">
                                                                                                        NRO pDT</td>
                                                                                                    <td style="width: 63px">
                                                                                                        IDENT. UNICO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        FUENTE</td>
                                                                                                    <td style="width: 63px">
                                                                                                        FECHA EMISION DEL PEDIDO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        CLIENTE</td>
                                                                                                    <td style="width: 63px">
                                                                                                        TIPO OPER. COMERCIAL</td>
                                                                                                    <td style="width: 63px">
                                                                                                        ZONAL</td>
                                                                                                    <td style="width: 63px">
                                                                                                        PRODUCTO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        MODALIDAD</td>
                                                                                                    <td style="width: 63px">
                                                                                                        CANT.</td>
                                                                                                    <td style="width: 63px">
                                                                                                        FECHA ULT. SEGUIMIENTO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        ANTIG. EN PDT</td>
                                                                                                    <td style="width: 63px">
                                                                                                        ANTIG. PEDIDO EMITIDO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        CRITICO</td>
                                                                                                    <td style="width: 63px">
                                                                                                        DOC'S POR PUBLICAR</td>
                                                                                                    <td style="width: 63px">
                                                                                                        PEDIDO EMITIBLE</td>                                                                                                                                                                                                           
                                                                                                </tr>
                                                                                            </table>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <table id="tGridContenido" border="0" cellpadding="1" cellspacing="1">
                                                                                                <tr>
                                                                                                    <td rowspan="2" style="width: 55px">
                                                                                                        <asp:LinkButton ID="lnkbNroPDT" runat="server"></asp:LinkButton></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:LinkButton ID="lnkbIdentUnico" runat="server"></asp:LinkButton></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:LinkButton ID="lnkbFuente" runat="server"></asp:LinkButton></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblFechaEmision" runat="server"></asp:Label></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:LinkButton ID="lnkbCliente" runat="server"></asp:LinkButton></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:LinkButton ID="lnkbOperComer" runat="server"></asp:LinkButton></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblZonal" runat="server"></asp:Label></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:LinkButton ID="lnkbProducto" runat="server"></asp:LinkButton></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblModalidad" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblCantidad" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblFechaUltSeg" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblAntPDT" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblAntEmitido" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblCritico" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Label ID="lblDocPublica" runat="server"></asp:Label></td>
                                                                                                    <td rowspan="2" style="width: 63px">
                                                                                                        <asp:Image ID="imgEmitible" runat="server" /></td>                                                                                                                                                                                                                        
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:Label ID="lblIdentUnico" runat="server"></asp:Label>
                                                                                                    </td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:Label ID="lblFuente" runat="server"></asp:Label></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:Label ID="lblClienteTipo" runat="server"></asp:Label></td>
                                                                                                    <td style="width: 63px">
                                                                                                        <asp:Label ID="lblProducto" runat="server"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        <asp:Label ID="lblEstadoPedido" runat="server"></asp:Label></td>
                                                                                                    <td colspan="8">
                                                                                                    </td>
                                                                                                    <td colspan="4">
                                                                                                        <asp:Label ID="LblIdPedidoPrd" runat="server" Visible="False"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        <asp:Label ID="lblFechaCambioEstado" runat="server"></asp:Label></td>
                                                                                                    <td align="left" colspan="8">
                                                                                                        <asp:Label ID="lblEstadoSIG" CssClass="TextoRojo" runat="server"></asp:Label></td>
                                                                                                    <td align="left" colspan="4">
                                                                                                        <asp:Label ID="lblDescripcionProducto" runat="server"></asp:Label></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="4">
                                                                                                        <asp:Label ID="lblDescripcionAlerta" CssClass="TextoRojo" runat="server"></asp:Label></td>
                                                                                                    <td colspan="8" align="left">
                                                                                                        <asp:Label ID="lblEstadoMarcadoCritico" runat="server" CssClass="TextoRojo"></asp:Label></td>
                                                                                                    <td colspan="4">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                                <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
                                                                            </asp:DataGrid><asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda"
                                                                                Visible="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 1228px;">
                                                                            <table style="width: 100%;" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td align="right" style="height: 5px">
                                                                                        <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:</asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1000px">
                                                        <asp:UpdateProgress ID="upgProcesandoWeb" runat="server" DisplayAfter="250">
                                                            <ProgressTemplate>
                                                                <uc2:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 1000px">
                                                        <asp:UpdatePanel ID="UpdatePanelTab" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="pnlAcciones" runat="server" Width="100%">
                                                                                <asp:Label ID="lblAcciones" runat="server" CssClass="normaldetalle">Acciones</asp:Label>
                                                                                <asp:Button ID="btnRecibido" runat="Server" CssClass="inputboton" Width="150px" Text="Marcar como Recibido">
                                                                                </asp:Button>
                                                                                <asp:Button ID="btnRechazado" runat="Server" CssClass="inputboton" Width="150px"
                                                                                    Text="Marcar como Rechazado"></asp:Button>
                                                                                <asp:Button ID="btnCrítico" runat="Server" CssClass="inputboton" Width="150px" Text="Marcar como Crítico">
                                                                                </asp:Button>
                                                                                <asp:Button ID="btnVolverListado" runat="Server" CssClass="inputboton" Width="150px"
                                                                                    Text="Volver al Listado"></asp:Button>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="pnlOpcionesCabecera" runat="server" Width="100%">
                                                                                <cc1:TabContainer ID="tbcInformacion" runat="server">
                                                                                    <cc1:TabPanel ID="tabpanel1" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Mas Datos</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc5:cuMasDatos ID="CuMasDatos1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                    <cc1:TabPanel ID="tabpanel2" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Seguimiento</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc6:cuSeguimiento ID="CuSeguimiento1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                    <cc1:TabPanel ID="tabpanel3" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Nuevo Seguimiento</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc7:cuNuevoSeguimiento ID="CuNuevoSeguimiento1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                    <cc1:TabPanel ID="tabpanel4" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Pedidos Relacionados</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc9:cuPedidosRelacionados ID="CuPedidosRelacionados1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                    <cc1:TabPanel ID="tabpanel5" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Documentación</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc1:cuCargarDocumetoPedidoProducto ID="CuCargarDocumetoPedidoProducto1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                    <cc1:TabPanel ID="tabpanel6" runat="server">
                                                                                        <HeaderTemplate>
                                                                                            Administración</HeaderTemplate>
                                                                                        <ContentTemplate>
                                                                                            <uc8:cuAdministracion ID="CuAdministracion1" runat="server" />
                                                                                        </ContentTemplate>
                                                                                    </cc1:TabPanel>
                                                                                </cc1:TabContainer></asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:Panel ID="pnlPaneles" runat="server">
                                                                            </asp:Panel>
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
