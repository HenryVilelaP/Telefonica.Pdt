<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmTipoOpcion.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.IU_seguridad_frmTipoOpcion" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDT - OPCIONES/TIPOS</title>
    <link href="../../Style/Style.css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" type="text/javascript" src="../../Script/jscript.js"></script>

</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0"
    ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                                        <td id="cCabecera">
                                            <uc1:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 428px" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center" style="height: 312px">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr class="TablaFilaTitulo">
                                                    <td align="center">
                                                        <asp:Label ID="Label5" runat="server" CssClass="TituloPrincipal" Width="200px">TIPO DE OPCIONES</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <input id="hcodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                    style="width: 18px; height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grid" runat="server" Width="100%" CssClass="AlternateItemGrilla" AutoGenerateColumns="False" OnPageIndexChanging="grid_PageIndexChanging" OnRowCommand="grid_RowCommand" OnRowDataBound="grid_RowDataBound">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <RowStyle CssClass="ItemGrilla" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" />
                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="vtopc_iIdTip_Opcion" HeaderText="ID" />
                                                                                    <asp:BoundField DataField="vDescripcion" HeaderText="DESCRIPCION" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnModificar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                                ImageUrl="../../Images/Body/Icons/Modificar.gif" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:</asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="InputBoton"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center" colspan="3">
                                                        <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnlFrmTipoOpcion" runat="server" Height="50px" Width="125px">
                                                                    <table id="Table2" cellspacing="1" cellpadding="1" width="300" border="0">
                                                                        <tr class="TablaFilaTitulo">
                                                                            <td align="center" colspan="3">
                                                                                <asp:Label ID="lblAccion" runat="server" CssClass="TituloPrincipal"></asp:Label></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="lblId" runat="server" CssClass="normaldetalle">Id</asp:Label></td>
                                                                            <td align="left" colspan="2">
                                                                                <asp:TextBox ID="txtId" runat="server" Width="60px" CssClass="InputTexto"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 17px" align="left">
                                                                                <asp:Label ID="lblDescripcion" runat="server" CssClass="normaldetalle">Descripción</asp:Label></td>
                                                                            <td style="height: 17px" align="left" colspan="1">
                                                                                <asp:TextBox ID="txtDescripcion" runat="server" Width="367px" CssClass="InputTexto" MaxLength="100"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 17px">
                                                                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="3">
                                                                                <asp:Button ID="btnGrabar" runat="server" Text="Guardar" CssClass="InputBoton"></asp:Button>&nbsp;
                                                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="InputBoton"></asp:Button></td>
                                                                        </tr>
                                                                    </table>
                                                                </asp:Panel>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px" valign="top">
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <uc1:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px" valign="top">
                                        <!--Region del Pie de Pagina de PdT -->
                                        <td id="cPiePagina">
                                            <uc2:cuPiePagina ID="CuPiePagina1" runat="server" />
                                        </td>
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
