<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmAbrirDocumentoPublicadoPedido.aspx.vb"
    Inherits="IU_Seguimiento_frmAbrirDocumentoPublicadoPedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body style="margin:0; background-color:#000080">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table style="width: 100%; border: 0; text-align: left; vertical-align: top"
                cellpadding="0">
                <tr>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 35px;
                            background-color: #ffffcc">
                            <tr>
                                <td style="width: 10px">
                                </td>
                                <td style="width: 20px; text-align: left">
                                    <asp:Image ID="imgUpgProcesaPagina" runat="server" ImageUrl="~/Images/Controls/ControlAjax/UpgPaginaNet.gif" /></td>
                                <td style="text-align: left">
                                    <asp:Label ID="lblProcesandoPagina" runat="server" Font-Bold="True" Font-Names="Arial"
                                        Font-Size="Small" ForeColor="Red" Text="Descargando documento..."></asp:Label></td>
                                <td style="width: 10px">
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <asp:Button ID="btnAbrirDocumento" runat="server" Text="Abriendo documento..." Width="200px" /></td>
                </tr>
            </table>
        </div>
    </form>

    <script type="text/jscript">
		    <asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
    </script>

</body>
</html>
