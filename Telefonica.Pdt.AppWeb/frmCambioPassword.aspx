<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmCambioPassword.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.frmCambioPassword" %>

<%@ Register Src="~/UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PDT - Cambio de password</title>
    <link href="Style/Style.css" type="text/css" rel="stylesheet" />
    <link href="Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="Script/jscript.js"></script>
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <table id="tGeneral" cellspacing="0" cellpadding="0" align="center" border="0" style="width: 100%">
            <tr>
                <td>
                    <table id="tWFijo" style="width: 1002px" cellspacing="0" cellpadding="0" align="center"
                        border="0">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <table id="tPrincipal" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
                                    border="0">
                                    <tr style="width: 100%; height: 112px" valign="top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera" style="height: 74px">
                                            <uc2:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center" style="height: 107px">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr>
                                                    <td align="center" style="height: 84px">
                                                        <table style="width: 34%">
                                                            <tr>
                                                                <td style="height: 37px" valign="middle">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="normaldetalle" Text="CAMBIO DE PASSWORD"
                                                                        Width="141px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table border="0" style="width: 177px">
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="normaldetalle" Text="Clave actual" Width="99px"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtClaveActual" runat="server" CssClass="InputTexto" TextMode="Password"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvClaveActual" runat="server" ControlToValidate="txtClaveActual">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="normaldetalle" Text="Nueva Clave" Width="99px"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtNuevaClave" runat="server" CssClass="InputTexto" TextMode="Password"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvNuevaClave" runat="server" ControlToValidate="txtNuevaClave">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <asp:Label ID="Label4" runat="server" CssClass="normaldetalle" Text="Confirmar nueva clave"
                                                                                    Width="110px"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtRepetirNuevaClave" runat="server" CssClass="InputTexto" TextMode="Password"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvRepetirNuevaClave" runat="server" ControlToValidate="txtRepetirNuevaClave">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="height: 41px" valign="middle">
                                                                                <table style="width: 170px" border="0" cellpadding="2" cellspacing="0">
                                                                                    <tr style="height: 41px" valign="middle">
                                                                                        <td style="height: 41px">
                                                                                            <asp:Button ID="btnAceptar" runat="server" CssClass="InputBoton" Text="Aceptar" Width="88px" style="left: 6px; top: 0px" /></td>
                                                                                        <td style="width: 3px; height: 41px;">
                                                                                            <asp:Button ID="btnCancelar" runat="server" CssClass="InputBoton" Text="Cancelar" Width="88px" style="left: 6px; top: 0px" CausesValidation="False" /></td>
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
                                    <tr>
                                        <td>
                                            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                        ShowSummary="False" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px" valign="top">
                                        <!--Region del Pie de Pagina de PdT -->
                                        <td id="cPiePagina">
                                            <uc3:cuPiePagina ID="CuPiePagina1" runat="server" />
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
