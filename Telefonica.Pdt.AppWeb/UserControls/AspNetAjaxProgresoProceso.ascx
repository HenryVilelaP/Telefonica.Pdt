<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AspNetAjaxProgresoProceso.ascx.vb" Inherits="EmpleoLocalWeb.AspNetAjaxProgresoProceso" %>

<table border="0" cellpadding="0" cellspacing="0" width="280" bgcolor="#ffffcc" id="TABLE1">
    <tr>
        <td style="width: 10px">
        </td>
        <td style="text-align: left; width: 20px">
            <asp:Image ID="imgUpgProcesaPagina" runat="server" ImageUrl="~/Images/Controls/ControlAjax/UpgPaginaNet.gif" /></td>
        <td style="text-align: left">
            <asp:Label ID="lblProcesandoPagina" runat="server" Text="Procesando..." Font-Bold="True"
                Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label></td>
    </tr>
</table>

