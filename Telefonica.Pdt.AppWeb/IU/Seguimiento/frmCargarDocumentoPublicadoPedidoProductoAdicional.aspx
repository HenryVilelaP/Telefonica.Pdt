<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCargarDocumentoPublicadoPedidoProductoAdicional.aspx.vb"
    Inherits="IU_Seguimiento_frmCargarDocumentoPublicadoPedidoProductoAdicional" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Publicación de documentos</title>
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/jscript" src="../../Script/jscript.js"></script>

</head>
<body style="margin-bottom: 0; margin-left: 0; margin-right: 0; margin-top: 0">
    <form id="form1" runat="server">
        <table id="tGeneral" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
            text-align: center">
            <tr>
                <td>
                    <table id="tWFijo" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                        text-align: center">
                        <tr>
                            <td>
                                <table id="tPrincipal" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                                    text-align: center">
                                    <tr style="width: 100%; vertical-align: top">
                                        <td>
                                            <table id="tContenido" border="0" cellpadding="1" cellspacing="1" style="width: 100%;
                                                text-align: left">
                                                <tr style="height: 30px; vertical-align: middle" class="TablaFilaTitulo">
                                                    <td style="text-align: center">
                                                        <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPrincipal" Text="Publicación de Documentos Adicionales"></asp:Label></td>
                                                </tr>
                                                <tr class="TablaFilaPar">
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblPublicarDocumento" runat="server" CssClass="normal" Text='Elige el archivo y el tipo de documento y luego presiona "Publicar"... '></asp:Label></td>
                                                </tr>
                                                <tr class="TablaFilaPar">
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: left">
                                                            <tr style="height: 30px; vertical-align: middle" class="TablaColumnaEtiqueta">
                                                                <td style="text-align: right">
                                                                    <asp:Label ID="lblRutaArchivo" runat="server" CssClass="normal" Text="ARCHIVO:&nbsp;"></asp:Label></td>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUploadArchivo" runat="server" CssClass="normaldetalle" ToolTip="Ubicar el archivo que desee publicar"
                                                                        Width="300px" Height="20px" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="TablaFilaPar">
                                                    <td style="text-align: center">
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr style="vertical-align: top">
                                                                <td style="width: 10px">
                                                                </td>
                                                                <td style="text-align: left">
                                                                    <asp:Label ID="lblListaDocumentos" runat="server" CssClass="TituloPrincipal" Text="LISTA DE DOCUMENTOS"></asp:Label></td>
                                                                <td style="width: 10px">
                                                                </td>
                                                            </tr>
                                                            <tr style="vertical-align: top">
                                                                <td style="width: 10px">
                                                                </td>
                                                                <td>
                                                                    <asp:ListBox ID="lstTipoDocumentoAdicional" runat="server" Rows="20" Width="700"
                                                                        CssClass="normaldetalle"></asp:ListBox></td>
                                                                <td style="width: 10px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: left">
                                                            <tr style="height: 30px; vertical-align: middle">
                                                                <td style="text-align: right; width: 340px;">
                                                                    <asp:Button ID="brnGrabar" runat="server" CssClass="InputBoton" Text="Publicar" Width="75px" />
                                                                </td>
                                                                <td style="width: 20px">
                                                                </td>
                                                                <td style="text-align: left">
                                                                    <asp:Button ID="btnCerrar" runat="server" CssClass="InputBoton" Text="Cerrar" Width="75px" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="height: 20px">
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
    </form>

    <script type="text/jscript">
		    <asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
    </script>

</body>
</html>
