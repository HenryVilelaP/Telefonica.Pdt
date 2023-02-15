<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmlogin.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.frmlogin" %>

<%@ Register Src="~/UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>

<%@ Register Src="~/UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PDT Login</title>
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
                                            &nbsp;</td>
                                    </tr>
                                    <tr style="width: 100%" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center" style="height: 107px">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr style="height:400px;">
                                                    <td align="center" style="height: 150px" valign="middle">
                                                        <table style="width: 34%" cellpadding="0" cellspacing="0">
                                                            <tr class="TablaFilaTitulo">
                                                                <td style="height: 30px" valign="middle">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="TituloPrincipal" Text="BIENVENIDO"
                                                                        Width="99px"></asp:Label></td>
                                                            </tr>
                                                            <tr class="TablaColumnaEtiqueta" style="height:130px;">
                                                                <td valign="middle">
                                                                    <table border="0" style="width: 177px" cellpadding="0" cellspacing="0">
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td >
                                                                                <asp:Label ID="Label2" runat="server" CssClass="normaldetalle" Text="Login" Width="99px"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLogin" runat="server" CssClass="InputTexto">jfonseca</asp:TextBox></td>
                                                                            <td style="width: 7px">
                                                                                <asp:RequiredFieldValidator ID="rfvLogin" runat="server" ControlToValidate="txtLogin">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td >
                                                                                <asp:Label ID="Label3" runat="server" CssClass="normaldetalle" Text="Clave" Width="99px"></asp:Label></td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtClave" runat="server" CssClass="InputTexto" TextMode="Password">chinita</asp:TextBox></td>
                                                                            <td style="width: 7px">
                                                                                <asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td colspan="3" style="height: 35px">
                                                                                <asp:Button ID="btnAceptar" runat="server" CssClass="InputBoton" Text="Aceptar" Width="88px" /></td>
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
                                            &nbsp;</td>
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
