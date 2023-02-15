<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuOrigenesInfoSIG.ascx.vb"
    Inherits="UserControls_cuOrigenesInfoSIG" %>
<table style="width: 100%; border: 0; vertical-align: top" class="TablaColumnaEtiqueta">
    <tr>
        <td style="text-align: center">
            <asp:Label ID="lblFechaUltimaCarga" runat="server" CssClass="TituloPrincipal">Fecha de la última carga de datos desde SpeedySIG: XXXXXX</asp:Label></td>
    </tr>
    <tr>
        <td>
            <table style="width: 100%; border: 0; vertical-align: top" cellpadding="0" cellspacing="0">
                <tr class="TablaFilaImpar">
                    <td style="width: 45%; height: 20px;">
                        <asp:Label ID="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:Label><input
                            id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px;
                            height: 15px" type="hidden" />
                        <input
                            id="hCodigoLegacie" runat="server" name="hCodigoLegacie" style="width: 15px;
                            height: 15px" type="hidden" /></td>
                    <td style="width: 55%; height: 20px;">
                        <asp:Label ID="lblHistorialISIS" runat="server" CssClass="TituloPrincipal">Detalle del Items del Pedido</asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 45%; vertical-align:top">
                        <table style="width: 100%; border: 1; vertical-align: top; border-color: #ffffff"
                            cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label1" runat="server" CssClass="normal">Empresa:</asp:Label></td>
                                <td align="right" style="width: 2px">
                                </td>
                                <td>
                                    <asp:Label ID="lblEmpesa" runat="server" CssClass="normaldetalle" Width="80px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label2" runat="server" CssClass="normal">Segmento:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblSegmento" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label3" runat="server" CssClass="normal">Estado:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblEstado" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label4" runat="server" CssClass="normal">Teléfono:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblTelefono" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label5" runat="server" CssClass="normal">Inscripción:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblIncripcion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label6" runat="server" CssClass="normal">Cliente:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblNombreCliente" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label7" runat="server" CssClass="normal">Dirección:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblDireccion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label8" runat="server" CssClass="normal">Ciudad:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblCiudad" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label9" runat="server" CssClass="normal">Ciclo de Facturación:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblCicloFacturacion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label10" runat="server" CssClass="normal">Persona de Contacto:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblPersonaContacto" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label11" runat="server" CssClass="normal">Código de Facturación:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblCodigoFacturacion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label12" runat="server" CssClass="normal">Fono de Contacto:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFonoContacto" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label13" runat="server" CssClass="normal">Vendedor:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblVendedor" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label14" runat="server" CssClass="normal">Canal de venta:</asp:Label></td>
                                <td align="right" style="height: 19px">
                                </td>
                                <td>
                                    <asp:Label ID="lblCanalVenta" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label15" runat="server" CssClass="normal">Fecha de registro:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaRegistro" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 140px;" class="TablaColumnaEtiqueta" align="right">
                                    <asp:Label ID="Label16" runat="server" CssClass="normal">Fecha de liquidación:</asp:Label></td>
                                <td align="right" style="height: 25px">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaLiquidacion" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label17" runat="server" CssClass="normal">Fecha de devolución:</asp:Label></td>
                                <td align="right" style="height: 19px">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaDevolucion1" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label19" runat="server" CssClass="normal">Fecha de Reprogración:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaReprogramacion1" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="TablaColumnaEtiqueta" align="right" style="width: 140px">
                                    <asp:Label ID="Label22" runat="server" CssClass="normal">Fecha de cancelación:</asp:Label></td>
                                <td align="right">
                                </td>
                                <td>
                                    <asp:Label ID="lblFechaCancelacion1" runat="server" CssClass="normaldetalle"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 55%; vertical-align: top">
                        <asp:UpdatePanel ID="UpdatePanelDetalleItems" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table style="width: 100%; border: 0; text-align: left; vertical-align: top" cellpadding="0"
                                    cellspacing="0">
                                    <tr>
                                        <td style="text-align: center">
                                            <asp:DataGrid ID="grid" runat="server" Width="100%" PageSize="7" HorizontalAlign="Center"
                                                AutoGenerateColumns="False" AllowPaging="True">
                                                <FooterStyle CssClass="FooterGrilla" />
                                                <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                <ItemStyle CssClass="ItemGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                <HeaderStyle CssClass="HeaderGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                <Columns>
                                                    <asp:BoundColumn HeaderText="NRO">
                                                        <HeaderStyle Width="25px" />
                                                    </asp:BoundColumn>
                                                    <asp:TemplateColumn>
                                                        <ItemTemplate>
                                                            <table style="width: 100%; border: 0; vertical-align: top" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%; border: 0; vertical-align: middle" cellpadding="0" cellspacing="0">
                                                                            <tr style="text-align:center">
                                                                                <td>
                                                                                    <asp:Label ID="Label18" runat="server" CssClass="subtituloNegrita" Text="Producto"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label20" runat="server" CssClass="subtituloNegrita" Text="Paquete"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label21" runat="server" CssClass="subtituloNegrita" Text="Cantidad"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label23" runat="server" CssClass="subtituloNegrita" Text="Número de Serie"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label24" runat="server" CssClass="subtituloNegrita" Text="Periodo"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label25" runat="server" CssClass="subtituloNegrita" Text="Estado"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="Label26" runat="server" CssClass="subtituloNegrita" Text="Tipo de Cliente"></asp:Label></td>
                                                                            </tr>
                                                                            <tr style="text-align:left">
                                                                                <td>
                                                                                    <asp:Label ID="lblProducto" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblPaquete" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td style="text-align:center">
                                                                                    <asp:Label ID="lblCantidad" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblNumeroSerie" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblPeriodo" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblEstado" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td>
                                                                                    <asp:Label ID="lblTipoCliente" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table style="width: 100%; border: 1; vertical-align: middle; border-color:#f5f5f5" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td style="text-align:right; width:90px">
                                                                                    <asp:Label ID="Label27" runat="server" CssClass="subtituloNegrita" Text="CPU:&nbsp"></asp:Label></td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblCPU" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td style="text-align:right; width:90px">
                                                                                    <asp:Label ID="Label28" runat="server" CssClass="subtituloNegrita" Text="RAM:&nbsp"></asp:Label></td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblRAM" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="text-align:right; width:90px">
                                                                                    <asp:Label ID="Label29" runat="server" CssClass="subtituloNegrita" Text="S.O:&nbsp"></asp:Label></td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblSO" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                                <td style="text-align:right; width:90px">
                                                                                    <asp:Label ID="Label30" runat="server" CssClass="subtituloNegrita" Text="Procesador:&nbsp"></asp:Label></td>
                                                                                <td style="text-align:left">
                                                                                    <asp:Label ID="lblProcesador" runat="server" CssClass="normaldetalle"></asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                            </asp:DataGrid>
                                            <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 17px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table style="width: 100%; border: 0; text-align: left; vertical-align: top" cellpadding="0"
                                                cellspacing="0">
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="normal" Visible="False">Total de Registros Encontrados:&nbsp;</asp:Label></td>
                                                    <td style="width: 50px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 17px">
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
