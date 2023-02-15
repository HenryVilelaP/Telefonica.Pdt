<%@ Control Language="VB" AutoEventWireup="false" CodeFile="cuCargarDocumetoPedidoProducto.ascx.vb"
    Inherits="Telefonica.Pdt.AppWeb.UserControls_cuCargarDocumetoPedidoProducto" %>
<table style="width: 100%; border: 0; text-align: left; vertical-align: top">
    <tr>
        <td>
            <asp:UpdatePanel ID="UpdatePanelDocumenento" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%; border: 0; text-align: left; vertical-align: top" cellpadding="0"
                        cellspacing="0">
                        <tr>
                            <td style="height: 25px;" align="right">
                                <input id="hIdPedidoProducto" runat="server" name="hIdPedidoProducto" style="width: 15px; height: 15px"
                                    type="hidden" />
                                <input id="hCodigo" runat="server" name="hCodigo" style="width: 15px; height: 15px"
                                    type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                        style="width: 15px; height: 15px" type="hidden" />
                                <asp:Button ID="btnActualizarGrilla" runat="server" Text="Actualizar" CausesValidation="False" CssClass="InputBoton" Height="25px" OnClick="btnActualizarGrilla_Click" Width="70px" /></td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:DataGrid ID="grid" runat="server" Width="100%" ShowFooter="True" PageSize="7" HorizontalAlign="Center" AutoGenerateColumns="False">
                                    <FooterStyle CssClass="FooterGrilla" />
                                    <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                    <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                    <ItemStyle CssClass="ItemGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                    <HeaderStyle CssClass="HeaderGrilla" Height="15px" HorizontalAlign="Center" VerticalAlign="Top" />
                                    <Columns>
                                        <asp:BoundColumn HeaderText="NRO">
                                            <HeaderStyle Width="25px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="ppdoc_iIdPedido_Doc" HeaderText="ppdoc_iIdPedido_Doc"
                                            Visible="False"></asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="I1">
                                            <HeaderStyle Width="35px" />
                                            <ItemTemplate>
                                                <asp:Image ID="imgChequear" runat="server" ImageUrl="~/Images/imgWebPdt/ico_check.gif"
                                                    Visible="False" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Tipo de Documento">
                                            <ItemTemplate>
                                                <table style="width: 100%; border: 0;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width:0px">
                                                            <asp:ImageButton ID="imgDocumento" runat="server" Visible="False" ImageUrl="~/Images/imgWebPdt/ico_DOC.bmp" /></td>
                                                        <td style="text-align:left">
                                                            <asp:Label ID="lblEtiqueta_TipoDocumento" runat="server" Text="Label"></asp:Label><asp:LinkButton ID="lbtnDesc_TipoDocumento" runat="server" Visible="False">LinkButton</asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                Font-Underline="False" HorizontalAlign="Left" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="Publicado">
                                            <ItemTemplate>
                                                <table style="width: 100%; border: 0;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDescPublicar" runat="server" Text="Label" Visible="False"></asp:Label>
                                                            <asp:LinkButton ID="lbtnPublicar" runat="server" CausesValidation="False" Visible="False">Publicar</asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                                                Font-Overline="False" Font-Bold="False"></ItemStyle>
                                            <HeaderStyle Width="80px" />
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="pptdc_dFec_Publicacion" HeaderText="Fec. Publicacion"
                                            DataFormatString="{0:dd/MM/yyyy}">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Nombre_Usuario_Publica" HeaderText="Publicador">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                                                Font-Overline="False" Font-Bold="False"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Nombre_Usuario_Aprueba" HeaderText="Aprobador">
                                            <HeaderStyle Width="150px" />
                                            <ItemStyle HorizontalAlign="Left" Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                                                Font-Overline="False" Font-Bold="False"></ItemStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="Desc_iIdEstado_Doc" HeaderText="Estado">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundColumn>
                                        <asp:TemplateColumn HeaderText="Accion">
                                            <HeaderStyle Width="100px" />
                                            <ItemTemplate>
                                                <table style="width: 100%; border: 0;" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="width: 50%; text-align: center">
                                                            <asp:ImageButton ID="imgRecibidoFisicamente" runat="server" CausesValidation="False"
                                                                CommandName="cmdNameMarcarRecibidoFicamente" ImageUrl="~/Images/imgWebPdt/ico_check2.gif"
                                                                Visible="False" /><asp:ImageButton ID="imgAprobarDocumento" runat="server" CausesValidation="False"
                                                                    CommandName="cmdNameAprobarDocumento" ImageUrl="~/Images/imgWebPdt/ico_check.gif"
                                                                    Visible="False" /></td>
                                                        <td style="width: 50%; text-align: center">
                                                            <asp:ImageButton ID="ibtnRechar" runat="server" CausesValidation="False" CommandName="cmdNameRechazarDocumento"
                                                                ImageUrl="~/Images/imgWebPdt/ico_aspa.gif" Visible="False" /></td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="vtdoc_iIdTip_Doc" HeaderText="TipoDocumento" Visible="False">
                                        </asp:BoundColumn>
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
                        <tr>
                            <td style="text-align:center">
                                <asp:Button ID="btnDocumentoAdicional" runat="server" CausesValidation="False" CssClass="InputBoton"
                                    Text="Adicionar Documento" Visible="False" /></td>
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
