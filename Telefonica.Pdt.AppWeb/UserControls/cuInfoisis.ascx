<%@ Control Language="vb" AutoEventWireup="false" CodeFile="cuInfoisis.ascx.vb" Inherits="Telefonica.Pdt.AppWeb.cuInfoISIS" %>
<table style="width: 100%" cellpadding="1" cellspacing="1" border="0">
    <tr>
        <td style="width: 50%; height: 30px" class="TablaFilaImpar">
            <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:Label></td>
        <td valign="top" style="width: 50%" class="TablaFilaTitulo">
            <asp:Label ID="lblHistorialISIS" runat="server" CssClass="TituloPrincipal">Historial en ISIS</asp:Label><input
                id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px;
                height: 15px" type="hidden" /></td>
    </tr>
    <tr>
        <td style="width: 50%">
            <table style="width: 100%" cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td runat="server" class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label1" runat="server" CssClass="normal">Fecha del pedido en ISIS</asp:Label></td>
                    <td>
                        <asp:Label ID="lblFechaPedidoISIS" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label2" runat="server" CssClass="normal">Fecha del emisión en ISIS</asp:Label></td>
                    <td>
                        <asp:Label ID="lblFechaEmisionISIS" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label3" runat="server" CssClass="normal">FecRec</asp:Label></td>
                    <td>
                        <asp:Label ID="lblFecRec" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label4" runat="server" CssClass="normal">FecDoc</asp:Label></td>
                    <td>
                        <asp:Label ID="lblFecDoc" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label5" runat="server" CssClass="normal">Prereg</asp:Label></td>
                    <td>
                        <asp:Label ID="lblPrereg" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label6" runat="server" CssClass="normal">PreDoc / NroDoc </asp:Label></td>
                    <td>
                        <asp:Label ID="lblPreDocNroDoc" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label7" runat="server" CssClass="normal">Ejecutivo de Servicio</asp:Label></td>
                    <td>
                        <asp:Label ID="lblEjecutivoServicio" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label8" runat="server" CssClass="normal">Ejecutivo de Atención</asp:Label></td>
                    <td>
                        <asp:Label ID="lblEjecutivoAtencion" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label9" runat="server" CssClass="normal">Código de Cliente</asp:Label></td>
                    <td>
                        <asp:Label ID="lblCodigoCliente" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label10" runat="server" CssClass="normal">Nombre del Cliente</asp:Label></td>
                    <td>
                        <asp:Label ID="lblNombreCliente" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label11" runat="server" CssClass="normal">Segmento</asp:Label></td>
                    <td>
                        <asp:Label ID="lblSegmento" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label12" runat="server" CssClass="normal">Sub Segmento</asp:Label></td>
                    <td>
                        <asp:Label ID="lblSubSegmento" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label13" runat="server" CssClass="normal">Servicio</asp:Label></td>
                    <td>
                        <asp:Label ID="lblServicio" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label14" runat="server" CssClass="normal">Marca</asp:Label></td>
                    <td>
                        <asp:Label ID="lblMarca" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label15" runat="server" CssClass="normal">Circuito</asp:Label></td>
                    <td>
                        <asp:Label ID="lblCircuito" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height: 25px" class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label16" runat="server" CssClass="normal">Acción 1</asp:Label></td>
                    <td style="height: 25px">
                        <asp:Label ID="lblAccion1" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label17" runat="server" CssClass="normal">Acción 2</asp:Label></td>
                    <td>
                        <asp:Label ID="lblAccion2" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label18" runat="server" CssClass="normal">Situación</asp:Label></td>
                    <td>
                        <asp:Label ID="lblSituacion" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
                <tr>
                    <td class="TablaColumnaEtiqueta" align="right">
                        <asp:Label ID="Label19" runat="server" CssClass="normal">Pendiente/Liquidado</asp:Label></td>
                    <td>
                        <asp:Label ID="lblEstado" runat="server" CssClass="normal"></asp:Label></td>
                </tr>
            </table>
        </td>
        <td valign="top" style="width: 50%">
            <table style="width: 100%" cellpadding="1" cellspacing="1" border="0">
                <tr>
                    <td>
                        <asp:DataGrid ID="grid" CssClass="grid" runat="server" AllowCustomPaging="True" PageSize="5"
                            HorizontalAlign="Center" AllowSorting="True" AutoGenerateColumns="False">
                            <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                            <AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                            <Columns>
                                <asp:BoundColumn DataField="sec" HeaderText="Secuencia">
                                    <HeaderStyle Width="70px"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="est" HeaderText="Estación">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="fec_lleg" HeaderText="Fecha Llegada">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="fec_sal" HeaderText="Fecha Salida">
                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
                        </asp:DataGrid></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
