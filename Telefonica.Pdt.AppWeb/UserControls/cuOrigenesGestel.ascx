<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuOrigenesGestel.ascx.vb"
    Inherits="UserControls_cuOrigenesGestel" %>
<table style="width: 100%; border: 0; vertical-align: top" cellpadding="0" cellspacing="0" class="TablaColumnaEtiqueta">
    <tr>
        <td>
            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table style="width: 100%; border-color: #f5f5f5" cellpadding="0" cellspacing="0"
                            border="0">
                            <tr style="height: 22px">
                                <td style="text-align: right; width: 50%" class="TablaColumnaEtiqueta">
                                    <asp:Label ID="Label1" runat="server" CssClass="normal" Text="Fecha de pedido en gestel:&nbsp;"></asp:Label></td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblFechaPedidoGestel" runat="server" CssClass="normaldetalle" Width="200px"></asp:Label><input
                                        id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px;
                                        height: 15px" type="hidden" /><input id="hCodigoLegacie" runat="server" name="hCodigoLegacie"
                                            style="width: 15px; height: 15px" type="hidden" /></td>
                            </tr>
                            <tr style="height: 22px">
                                <td style="text-align: right; width: 50%" class="TablaColumnaEtiqueta">
                                    <asp:Label ID="Label2" runat="server" CssClass="normal" Text="Estado:&nbsp;"></asp:Label></td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblEstado" runat="server" CssClass="normaldetalle" Width="200px"></asp:Label></td>
                            </tr>
                            <tr style="height: 22px">
                                <td style="text-align: right; width: 50%" class="TablaColumnaEtiqueta">
                                    <asp:Label ID="Label3" runat="server" CssClass="normal" Text="Orden de servicio:&nbsp;"></asp:Label></td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblOrdenServicio" runat="server" CssClass="normaldetalle" Width="200px"></asp:Label></td>
                            </tr>
                            <tr style="height: 22px">
                                <td style="text-align: right; width: 50%" class="TablaColumnaEtiqueta">
                                    <asp:Label ID="Label4" runat="server" CssClass="normal" Text="Teléfono:&nbsp;"></asp:Label></td>
                                <td style="width: 50%">
                                    <asp:Label ID="lblTelefono" runat="server" CssClass="normaldetalle" Width="200px"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height:15px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <table style="width: 75%; border-color: #f5f5f5" cellpadding="1" cellspacing="0"
                            border="1">
                            <tr style="height: 22px; vertical-align: middle; text-align: center" class="TablaColumnaEtiqueta">
                                <td>
                                    <asp:Label ID="Label5" runat="server" CssClass="subtituloNegrita" Text="Area"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" CssClass="subtituloNegrita" Text="Estación"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" CssClass="subtituloNegrita" Text="Fecha"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" CssClass="subtituloNegrita" Text="Estado"></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" CssClass="subtituloNegrita" Text="URD"></asp:Label></td>
                            </tr>
                            <tr style="height: 22px; vertical-align: middle; text-align: left">
                                <td>
                                    <asp:Label ID="lblArea1" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstacion1" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblFecha1" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstado1" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblUrd1" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                            </tr>
                            <tr style="height: 22px; vertical-align: middle; text-align: left">
                                <td>
                                    <asp:Label ID="lblArea2" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstacion2" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblFecha2" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstado2" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblUrd2" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                            </tr>
                            <tr style="height: 22px; vertical-align: middle; text-align: left">
                                <td>
                                    <asp:Label ID="lblArea3" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstacion3" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblFecha3" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblEstado3" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblUrd3" runat="server" CssClass="normaldetalle" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
