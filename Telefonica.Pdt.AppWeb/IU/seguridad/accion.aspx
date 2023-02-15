<%@ Page Language="vb" AutoEventWireup="false" CodeFile="accion.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.accion" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDT - ACCIONES</title>
    <link href="../../Style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../../Script/jscript.js"></script>

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
                                        <td align="center" style="height: 418px">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr class="TablaFilaTitulo">
                                                    <td align="center">
                                                        <asp:Label ID="lblAcciones" runat="server" CssClass="TituloPrincipal" Width="200px">ACCIONES</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="3">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 90%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <input id="hcodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                    style="width: 18px; height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grid" runat="server" Width="100%" CssClass="AlternateItemGrilla"
                                                                                AutoGenerateColumns="False">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="accic_iIdAccion" HeaderText="ID" />
                                                                                    <asp:BoundField DataField="accic_vDescripcion" HeaderText="DESCRIPCION" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="accic_vNombre_Accion" HeaderText="NOMBRE" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnModificar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                                ImageUrl="../../Images/Body/Icons/Modificar.gif" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <RowStyle CssClass="ItemGrilla" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" />
                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla" />
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
                                                    <td align="center" colspan="3" style="height: 33px">
                                                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="InputBoton"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center" colspan="3">
                                                        <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnlFrmAccion" runat="server">
                                                                    <table id="Table2" cellspacing="1" cellpadding="1" width="300" border="0">
                                                                        <tr class="TablaFilaTitulo">
                                                                            <td align="center" colspan="5">
                                                                                <asp:Label ID="lblAccion" runat="server" CssClass="TituloPrincipal"></asp:Label></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label9" runat="server" CssClass="normaldetalle">Id</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox ID="txtId" runat="server" Width="52px" CssClass="InputTexto"></asp:TextBox></td>
                                                                            <td align="left" colspan="1">
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 17px" align="left">
                                                                                <asp:Label ID="Label8" runat="server" CssClass="normaldetalle">Nombre</asp:Label></td>
                                                                            <td style="height: 17px" align="left" colspan="3">
                                                                                <asp:TextBox ID="txtNombre" runat="server" Width="358px" CssClass="InputTexto" MaxLength="40"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 17px">
                                                                                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 23px;" align="left">
                                                                                <asp:Label ID="Label7" runat="server" CssClass="normaldetalle" Width="82px">Descripción</asp:Label></td>
                                                                            <td align="left" colspan="3" style="height: 23px">
                                                                                <asp:TextBox ID="txtDescripcion" runat="server" Width="358px" CssClass="InputTexto" MaxLength="200"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 23px">
                                                                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="5">
                                                                                <asp:Button ID="btnGrabar" runat="server" Text="Guardar" CssClass="InputBoton"></asp:Button>&nbsp;
                                                                                <asp:Button ID="btCancelar" runat="server" Text="Cancelar" CssClass="InputBoton"></asp:Button></td>
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
                                    <tr style="width: 100%;" valign="top">
                                        <td>
                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                <ProgressTemplate>
                                                    <uc1:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
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
