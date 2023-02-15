<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuOrigenesWebRPS.ascx.vb"
    Inherits="UserControls_cuOrigenesWebRPS" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<link href="../Style/Estilos.css" rel="stylesheet" type="text/css" />
<table style="width: 100%; border: 0; vertical-align: top" class="TablaColumnaEtiqueta"
    border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table style="width: 100%; vertical-align: top" class="TablaColumnaEtiqueta" border="0"
                cellpadding="0" cellspacing="0">
                <tr style="text-align: center; height: 30px; vertical-align: middle">
                    <td>
                        <input id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px;
                            height: 15px" type="hidden" />
                        <asp:Label ID="lblTitulo" runat="server" Text="Fecha de la última carga de datos desde Web RPS : XXXXXXXX"
                            CssClass="TituloPrincipal"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PanelDetalleUsuario" runat="server" Height="200px" Width="100%">
                            <table style="width: 100%; vertical-align: top; text-align:center" class="TablaColumnaEtiqueta" border="0"
                                cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:DataGrid ID="grid" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                                            PageSize="7" Width="400px">
                                            <FooterStyle CssClass="FooterGrilla" />
                                            <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                            <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                            <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                            <Columns>
                                                <asp:BoundColumn HeaderText="NRO">
                                                    <HeaderStyle Width="25px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="varUsuario" HeaderText="Usuario Asignado"></asp:BoundColumn>
                                                <asp:BoundColumn DataField="varClave" HeaderText="Clave Asignada"></asp:BoundColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="HeaderGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:DataGrid>
                                        <asp:Label id="lblResultado" CssClass="ResultadoBusqueda" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 20px">
                                    <td>
                                    </td>
                                </tr>
                                <tr style="text-align: center">
                                    <td>
                                        <asp:Button ID="btnCartaTipo" runat="server" CssClass="InputBoton" Text="Vista Preliminar Carta Tipo"
                                            CausesValidation="False" Width="200px" /></td>
                                </tr>
                                <tr style="height: 20px">
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="PanelDetallePedido" runat="server" Height="200px" Width="100%">
                            <table style="width: 100%; vertical-align: top; text-align:center" class="TablaColumnaEtiqueta" border="0"
                                cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:DataGrid ID="grid2" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                            HorizontalAlign="Center" PageSize="7" Width="900px">
                                            <FooterStyle CssClass="FooterGrilla" />
                                            <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                            <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                            <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                            <Columns>
                                                <asp:BoundColumn HeaderText="NRO">
                                                    <HeaderStyle Width="25px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Pedido" DataField="NumeroPedido">
                                                    <HeaderStyle Width="60px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Operaci&#243;n" DataField="operacion"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Cliente" DataField="NombreCliente"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Servicio" DataField="NombreServicio"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Tipo" DataField="Tipo"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Fono" DataField="Fono">
                                                    <HeaderStyle Width="70px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Fecha" DataField="Fecha">
                                                    <HeaderStyle Width="70px" />
                                                </asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Estado" DataField="estado">
                                                    <HeaderStyle Width="90px" />
                                                </asp:BoundColumn>
                                            </Columns>
                                            <HeaderStyle CssClass="HeaderGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                        </asp:DataGrid>
                                        <asp:Label id="lblResultado2" CssClass="ResultadoBusqueda" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 20px">
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="width: 100%; vertical-align: top" class="TablaColumnaEtiqueta" border="0"
                                            cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanelPedidoSecundario" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <table style="width: 100%; vertical-align: top" class="TablaColumnaEtiqueta" border="0"
                                                                cellpadding="0" cellspacing="0">
                                                                <tr style="text-align: center">
                                                                    <td>
                                                                        <asp:DataGrid ID="grid3" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                                                            HorizontalAlign="Center" PageSize="7" Width="900px">
                                                                            <FooterStyle CssClass="FooterGrilla" />
                                                                            <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                                            <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                                            <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                            <Columns>
                                                                                <asp:BoundColumn HeaderText="NRO">
                                                                                    <HeaderStyle Width="25px" />
                                                                                </asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Pedido"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Valido?"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Operaci&#243;n"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Cliente"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Servicio"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Tipo"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Fono"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Fecha"></asp:BoundColumn>
                                                                                <asp:BoundColumn HeaderText="Estado"></asp:BoundColumn>
                                                                            </Columns>
                                                                            <HeaderStyle CssClass="HeaderGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                        </asp:DataGrid>
                                                                        <asp:Label ID="lblResultado3" CssClass="ResultadoBusqueda" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 20px">
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align: center">
                                                                        <table style="width: 440px; height: 30px; vertical-align: middle; border-color: #f5f5f5"
                                                                            class="TablaColumnaEtiqueta" border="1" cellpadding="0" cellspacing="1">
                                                                            <tr>
                                                                                <td style="text-align: right; width: 133px;">
                                                                                    <ew:NumericBox ID="nbNumeroPedidoSecundario" runat="server" CssClass="normaldetalle"
                                                                                        Width="120px"></ew:NumericBox></td>
                                                                                <td style="text-align: left">
                                                                                    <asp:Button ID="btnAgregarPedidoSecundario" runat="server" CssClass="InputBoton"
                                                                                        Text="Agregar Número de Pedido Secundario" CausesValidation="False" Width="280px" /></td>
                                                                            </tr>
                                                                        </table>
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
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
