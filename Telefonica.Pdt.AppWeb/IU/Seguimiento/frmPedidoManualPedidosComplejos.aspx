<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmPedidoManualPedidosComplejos"
    CodeFile="frmPedidoManualPedidosComplejos.aspx.vb" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ PreviousPageType VirtualPath="~/IU/Seguimiento/frmPedidoManual.aspx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>PdT - Selección Pedidos Complejos</title>
    <link href="../../Style/Style.css" type="text/css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body class="clsBody" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tGeneral" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
            border="0">
            <tr>
                <td style="height: 587px">
                    <table id="tWFijo" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
                        border="0">
                        <tr>
                            <td style="width: 5px; height: 573px;">
                            </td>
                            <td style="height: 573px">
                                <table id="tPrincipal" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
                                    border="0">
                                    <tr style="width: 100%; height: 90px" valign="top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <uc1:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td>
                                            <table id="tContenido" style="width: 100%" cellspacing="1" cellpadding="1" border="0">
                                                <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                                    <td>
                                                        <asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server" Text="Elige Productos del Paquete"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                                        <tr>
                                                                            <td style="height: 140px" align="center">
                                                                                <!--GridPS-->
                                                                                <asp:GridView ID="gridPS" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                    AllowSorting="True" AllowPaging="True" HorizontalAlign="Center" PageSize="5">
                                                                                    <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                                                                                    <AlternatingRowStyle CssClass="AlternateItemGrilla"></AlternatingRowStyle>
                                                                                    <RowStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></RowStyle>
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Item">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblNumeroItem" runat="server"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Incluir">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="chkIncluir" runat="server" AutoPostBack="true"></asp:CheckBox>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="tococ_iIdTip_Ope_Com" Visible="false">
                                                                                            <HeaderStyle Width="70px"></HeaderStyle>
                                                                                        </asp:BoundField>
                                                                                        
                                                                                        <asp:TemplateField HeaderText="IdProducto" Visible=false>
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblIdProducto" runat="server"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Producto">
                                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProducto" runat="server"></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Operación Comercial">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlOperacionComercial" CssClass="InputTexto" runat="server"
                                                                                                    Width="100px">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Modalidad">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlModalidad" CssClass="InputTexto" runat="server" Width="100px">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Cantidad">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlCantidad" CssClass="InputTexto" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Tipo Venta">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlTipoVenta" CssClass="InputTexto" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Tipo Contrato">
                                                                                            <ItemTemplate>
                                                                                                <asp:DropDownList ID="ddlTipoContrato" CssClass="InputTexto" runat="server">
                                                                                                </asp:DropDownList>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
                                                                                </asp:GridView>
                                                                                <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 19px" align="right">
                                                                                <asp:Button ID="btnGrabarPedido" runat="server" CssClass="InputBoton" Text="Grabar Pedido">
                                                                                </asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span style="display: none">
                                                                                    <table style="width: 100%; height: 25px" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td align="right">
                                                                                                <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="normal" Visible="False">Total de Registros Encontrados:&nbsp;</asp:Label></td>
                                                                                            <td width="50">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
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
