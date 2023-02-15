<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCargarDocumentoPedidoProducto.aspx.vb"
    Inherits="IU_Seguimiento_frmCargarDocumentoPedidoProducto" %>

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
                    <table id="tWFijo" border="0" cellpadding="0" cellspacing="0" style="width: 478px;
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
                                                        <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPrincipal" Text="Publicación de Documentos"></asp:Label></td>
                                                </tr>
                                                <tr style="height: 35px" class="TablaColumnaEtiqueta">
                                                    <td>
                                                        <asp:Label ID="lblDescripcionTipoDocumento" runat="server" CssClass="TituloSecundario"
                                                            Text="Descripción del tipo de documento a cargar"></asp:Label></td>
                                                </tr>
                                                <tr class="TablaFilaPar">
                                                    <td style="text-align: left">
                                                        <asp:Label ID="lblPublicarDocumento" runat="server" CssClass="normal" Text='Elige el archivo y presiona "Publicar"... '></asp:Label></td>
                                                </tr>
                                                <tr class="TablaFilaPar">
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: left">
                                                            <tr style="height: 30px; vertical-align: middle" class="TablaColumnaEtiqueta">
                                                                <td style="text-align: right">
                                                                    <asp:Label ID="lblRutaArchivo" runat="server" CssClass="normal" Text="ARCHIVO:&nbsp;"></asp:Label></td>
                                                                <td>
                                                                    <asp:FileUpload ID="FileUploadArchivo" runat="server" CssClass="normaldetalle" ToolTip="Ubicar el archivo que desee publicar"
                                                                        Width="300px" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: left">
                                                                        <tr style="height: 30px; vertical-align: middle">
                                                                            <td style="text-align: right; width: 140px;">
                                                                                <asp:Button ID="brnGrabar" runat="server" CssClass="InputBoton" Text="Publicar" Width="75px" />
                                                                            </td>
                                                                            <td style="width: 20px">
                                                                            </td>
                                                                            <td style="text-align: left"><asp:Button ID="btnCerrar" runat="server" CssClass="InputBoton" Text="Cerrar" Width="75px" /></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center">
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
