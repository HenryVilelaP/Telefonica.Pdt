<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuCabecera.ascx.vb" Inherits="Telefonica.Pdt.AppWeb.cuCabecera" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 1002px;">
    <tr style="height: 90px">
        <td background="/Telefonica.Pdt.AppWeb/Images/Header/imgCabecera.jpg">
        </td>
    </tr>
    <tr>
        <td align="left">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" CssClass="normaldetalle" Width="100%">
                <DynamicMenuStyle CssClass="normaldetalle" />
            </asp:Menu>
        </td>
    </tr>
</table>
 