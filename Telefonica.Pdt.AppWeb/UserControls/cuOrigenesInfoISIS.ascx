<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuOrigenesInfoISIS.ascx.vb"
    Inherits="UserControls_cuOrigenesInfoISIS" %>
<table style="width: 100%; border: 0; vertical-align: top" class="TablaColumnaEtiqueta">
    <tr>
        <td style="text-align:center">
            <asp:Label ID="Label20" runat="server" CssClass="TituloPrincipal">Fecha de la última carga de datos desde ISIS: XXXXXX</asp:Label></td>
    </tr>
    <tr>
        <td>
            <table style="width: 100%; border: 0; vertical-align: top" cellpadding="0" cellspacing="0">
                <tr class="TablaFilaImpar">
                    <td style="width: 50%; height: 20px;">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:Label><input
                            id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px;
                            height: 15px" type="hidden" /><input id="hCodigoLegacie" runat="server" name="hCodigoLegacie"
                                style="width: 15px; height: 15px" type="hidden" /></td>
                    <td style="width: 50%; height: 20px;">
                        <asp:Label ID="lblHistorialISIS" runat="server" CssClass="TituloPrincipal">Historial en ISIS</asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 50%">
                        <table style="width: 100%; border: 1; vertical-align: top; border-color: #ffffff"
                            cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label1" runat="server" CssClass="normal">Fecha del pedido en ISIS:</asp:Label></td>
                                <td align="right" style="width: 2px">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaPedidoISIS" runat="server" CssClass="normaldetalle" Width="80px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label2" runat="server" CssClass="normal">Fecha del emisión en ISIS:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaEmisionISIS" runat="server" CssClass="normaldetalle" Width="120px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label3" runat="server" CssClass="normal">FecRec:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFecRec" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label4" runat="server" CssClass="normal">FecDoc:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFecDoc" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label5" runat="server" CssClass="normal">Prereg:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblPrereg" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label6" runat="server" CssClass="normal">PreDoc / NroDoc:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblPreDocNroDoc" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label7" runat="server" CssClass="normal">Ejecutivo de Servicio:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblEjecutivoServicio" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label8" runat="server" CssClass="normal">Ejecutivo de Atención:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblEjecutivoAtencion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label9" runat="server" CssClass="normal">Código de Cliente:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigoCliente" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label10" runat="server" CssClass="normal">Nombre del Cliente:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblNombreCliente" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label11" runat="server" CssClass="normal">Segmento:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblSegmento" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label12" runat="server" CssClass="normal">Sub Segmento:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblSubSegmento" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label13" runat="server" CssClass="normal">Servicio:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblServicio" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label14" runat="server" CssClass="normal">Marca:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblMarca" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label15" runat="server" CssClass="normal">Circuito:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblCircuito" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 25px; width: 180px;" class="TablaColumnaEtiqueta" align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="normal">Acción 1</asp:Label></td>
                                <td align="right" style="height: 25px">
                                </td>
                                <td style="height: 25px">
                                    <asp:Label ID="lblAccion1" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label17" runat="server" CssClass="normal">Acción 2:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblAccion2" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label18" runat="server" CssClass="normal">Situación:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblSituacion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 180px">
                                    <asp:Label ID="Label19" runat="server" CssClass="normal">Pendiente/Liquidado:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblEstado" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 50%">
                        tabla grilla
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
