<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb._default2"
    CodeFile="default.aspx.vb" %>

<%@ Register Src="../../UserControls/cuOrigenesGestel.ascx" TagName="cuOrigenesGestel"
    TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/cuOrigenesInfoSIG.ascx" TagName="cuOrigenesInfoSIG"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/cuOrigenesInfoISIS.ascx" TagName="cuOrigenesInfoISIS"
    TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/cuCargarDocumetoPedidoProducto.ascx" TagName="cuCargarDocumetoPedidoProducto"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>default</title>
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/jscript" src="../../Script/jscript.js"></script>

    <link href="../Style/Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-bottom: 0; margin-left: 0; margin-top: 0; margin-right: 0">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%; border-spacing: 0; padding: 0; border: 0">
            <tr>
                <td>
                    <asp:Button ID="btnDocumentos" runat="server" Text="LISTAR" />
                    <input id="btnRefrescar" name="btnRefrescar" type="button" value="Refresar HTML"
                        onclick="ActulizarListaDocumentPublicPedido();" /></td>
            </tr>
            <tr>
                <td>
                    <uc1:cuCargarDocumetoPedidoProducto ID="CuCargarDocumetoPedidoProducto1" runat="server">
                    </uc1:cuCargarDocumetoPedidoProducto>
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    <asp:Button ID="btnInfoISIS" runat="server" Text="ISIS" Width="83px" /></td>
            </tr>
            <tr>
                <td>
                    <uc2:cuOrigenesInfoISIS ID="CuOrigenesInfoISIS1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    <asp:Button ID="btnInfoSIG" runat="server" Text="Speedy SIG" Width="83px" /></td>
            </tr>
            <tr>
                <td>
                    <uc3:cuOrigenesInfoSIG ID="CuOrigenesInfoSIG1" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    <asp:Button ID="btnGestel" runat="server" Text="GESTEL" Width="83px" /></td>
            </tr>
            <tr>
                <td>
                    <uc4:cuOrigenesGestel ID="CuOrigenesGestel1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="btnWebRPS" runat="server" Text="GESTEL" Width="83px" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
