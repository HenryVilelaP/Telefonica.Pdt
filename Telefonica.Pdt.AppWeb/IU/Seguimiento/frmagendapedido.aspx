<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc4" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc2" %>

<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmagendapedido"
    CodeFile="frmagendapedido.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PdT</title>
    <link href="../../style/Style.css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
            <tr>
                <td>
                    <table style="width: 1002px" cellspacing="0" cellpadding="0" align="left" border="0">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <uc4:cuCabecera ID="CuCabecera1" runat="server" />
                            </td>
                        </tr>
                        <tr style="height: 450px">
                            <td style="width: 5px">
                            </td>
                            <td valign="top">
                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                    <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                        <td>
                                            <asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server">AGENDAR PEDIDO</asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table id="tFiltroAvanzado" cellspacing="1" cellpadding="1" width="100%" border="0"
                                                visible="true" runat="server">
                                                <tr>
                                                    <td align="right" style="width: 40%" class="TablaColumnaEtiqueta">
                                                        <asp:Label ID="Label3" runat="server" CssClass="normaldetalle">Proveedor</asp:Label></td>
                                                    <td class="TablaFilaPar" style="width: 60%">
                                                        <asp:DropDownList ID="ddlbProveedor" runat="server" CssClass="InputTexto" Width="65%"
                                                            AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="TablaColumnaEtiqueta" align="right" style="width: 40%">
                                                        <asp:Label ID="Label4" runat="server" CssClass="normaldetalle">Grupo de Instalacion</asp:Label></td>
                                                    <td class="TablaFilaPar" style="width: 60%">
                                                        <asp:DropDownList ID="ddlbGrupoInstalacion" runat="server" CssClass="InputTexto"
                                                            Width="65%" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td>
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                                    <tr>
                                                                        <td align="right" style="height: 7px;">
                                                                            <input id="hCodigo" style="width: 10px; height: 10px" type="hidden" name="hCodigo"
                                                                                runat="server">
                                                                            <input id="hGrillaIndicePagina" style="width: 10px; height: 10px" type="hidden" name="hGrillaIndicePagina"
                                                                                runat="server">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <asp:DataGrid ID="grid" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
                                                                                AllowPaging="True" PageSize="10" HorizontalAlign="Center" AllowCustomPaging="True">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <PagerStyle CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages" />
                                                                                <AlternatingItemStyle CssClass="AlternateItemGrilla" />
                                                                                <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                <Columns>
                                                                                    <asp:BoundColumn DataField="fechc_iIdFecha" Visible="False"></asp:BoundColumn>
                                                                                    <asp:BoundColumn DataField="NombreDia">
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                        <HeaderStyle Width="20%" />
                                                                                    </asp:BoundColumn>
                                                                                    <asp:TemplateColumn>
                                                                                        <ItemTemplate>
                                                                                            <asp:DataGrid ID="gridc" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                                HorizontalAlign="Center" ShowHeader="False">
                                                                                                <ItemStyle CssClass="ItemGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                                <HeaderStyle CssClass="HeaderGrilla" Height="20px" HorizontalAlign="Center" VerticalAlign="Top" />
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="cupoc_iIdCupo" Visible="False">
                                                                                                        <HeaderStyle Width="0%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:BoundColumn HeaderText="Franja Horaria" DataField="Franja">
                                                                                                        <ItemStyle Width="15%"  HorizontalAlign="Left" />
                                                                                                        <HeaderStyle Width="15%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:BoundColumn HeaderText="Cupos Totales" DataField="cupoc_iCanti_Cupo_Asignada">
                                                                                                        <ItemStyle Width="15%"  HorizontalAlign="Center" />
                                                                                                        <HeaderStyle Width="15%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:BoundColumn HeaderText="Usados" DataField="CuposUsados">
                                                                                                        <ItemStyle Width="15%"  HorizontalAlign="Center" />
                                                                                                        <HeaderStyle Width="15%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:BoundColumn HeaderText="Reservados para Gesneg no existentes en PdT" DataField="ReservaGesneg">
                                                                                                        <ItemStyle Width="25%"  HorizontalAlign="Center" />
                                                                                                        <HeaderStyle Width="25%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:BoundColumn HeaderText="Cupos Disponibles" DataField="cupoc_iCanti_Cupo_Disponible">
                                                                                                        <ItemStyle Width="15%"  HorizontalAlign="Center" />
                                                                                                        <HeaderStyle Width="15%" />
                                                                                                    </asp:BoundColumn>
                                                                                                    <asp:TemplateColumn HeaderText="Acci&#243;n">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:LinkButton ID="lbkbAgendarPedido" runat="server" CssClass="normaldetalle">Elegir Cupo</asp:LinkButton>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="15%" />
                                                                                                        <HeaderStyle Width="15%" />
                                                                                                    </asp:TemplateColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="80%" />
                                                                                        <HeaderTemplate>
                                                                                            <table style="width:100%" cellpadding=1 cellspacing=1 border=0>
                                                                                                <tr>
                                                                                                    <td width="15%">
                                                                                                        Franja Horaria</td>
                                                                                                    <td width="15%">
                                                                                                        Cupos Totales</td>
                                                                                                    <td width="15%">
                                                                                                        Usados</td>
                                                                                                    <td width="25%">
                                                                                                        Reservados para Gesneg no existentes en PdT</td>
                                                                                                    <td width="15%">
                                                                                                        Cupos Disponibles</td>
                                                                                                    <td width="15%">
                                                                                                        Accion</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </HeaderTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid>
                                                                            <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <table cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td align="right" style="height: 8px">
                                                                                        <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:</asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdateProgress ID="upgProcesandoWeb" runat="server" DisplayAfter="250">
                                                            <ProgressTemplate>
                                                                <uc2:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <uc3:cuPiePagina ID="CuPiePagina1" runat="server" />
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
