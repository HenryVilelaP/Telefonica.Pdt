<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmOpcion.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.IU_seguridad_frmOpcion" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDT - OPCIONES</title>
    <link href="../../Style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/jscript" src="../../Script/jscript.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" ms_positioning="FlowLayout">
    <form id="frmOpcion" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table id="tGeneral" cellspacing="0" cellpadding="0" align="center" border="0" style="width: 100%">
            <tr valign="top">
                <td>
                    <table id="tWFijo" style="width: 1002px" cellspacing="0" cellpadding="0" align="center"
                        border="0">
                        <tr valign="top">
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
                                                <tr valign="top">
                                                    <td align="center">
                                                        <table cellpadding="0" cellspacing="0" width="100%">
                                                            <tr class="TablaFilaTitulo">
                                                                <td colspan="5">
                                                                    <asp:Label ID="Label5" runat="server" CssClass="TituloPrincipal" Width="138px">OPCIONES</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="height: 30px; width: 77px;">
                                                                                <asp:Label ID="Label1" runat="server" CssClass="normaldetalle">Descripción</asp:Label></td>
                                                                            <td style="height: 30px; width: 204px;" align="left">
                                                                                <asp:TextBox ID="txtDescripcionBusqueda" runat="server" Width="172px" CssClass="InputTexto"></asp:TextBox></td>
                                                                            <td style="height: 30px; width: 93px;">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="normaldetalle" Width="75px">Tipo opción</asp:Label></td>
                                                                            <td style="height: 30px; width: 194px;" align="left">
                                                                                <asp:DropDownList ID="cboTipoOpcionBusqueda" runat="server" CssClass="InputTexto"
                                                                                    Width="156px">
                                                                                </asp:DropDownList></td>
                                                                            <td style="height: 30px" align="left">
                                                                                <asp:Button ID="btnConsultar" runat="server" Text="Buscar" CssClass="InputBoton"></asp:Button>&nbsp;&nbsp;&nbsp;
                                                                                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="InputBoton"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <input id="hCodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                    style="width: 18px; height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" style="height: 213px">
                                                                            <asp:GridView ID="grid" runat="server" Width="100%" CssClass="AlternateItemGrilla"
                                                                                AutoGenerateColumns="False" AllowPaging="True" HorizontalAlign="Center" ShowFooter="True"
                                                                                OnPageIndexChanging="grid_PageIndexChanging" OnRowCommand="grid_RowCommand" OnRowDataBound="grid_RowDataBound">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <RowStyle CssClass="ItemGrilla" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" />
                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="vtopc_iIdTip_Opcion" HeaderText="ID" />
                                                                                    <asp:BoundField DataField="opcic_vEtiqueta" HeaderText="ETIQUETA" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="opcic_vDescripcion" HeaderText="DESCRIPCION" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="opcic_vNombre_Pagina" HeaderText="PAGINA" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="vDescripcion" HeaderText="TIPO" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="opcic_iInd_Opcion_Critica" HeaderText="OPC. CRITICA" />
                                                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnModificar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                                ImageUrl="../../Images/Body/Icons/Modificar.gif" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ASOCIAR ACCION">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnMostrarDetalle" runat="server" CommandName="GrillaEventoMostrarDetalle"
                                                                                                ImageUrl="~/Images/Body/Icons/Consultar.gif" />
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
                                                    <td align="center">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnlFrmOpcion" runat="server">
                                                                    <table id="Table2" cellspacing="1" cellpadding="1" width="300" border="0">
                                                                        <tr class="TablaFilaTitulo" style="height:30px;">
                                                                            <td align="center" colspan="3" style="height: 27px" valign="middle">
                                                                                <asp:Label ID="lblAccion" runat="server" CssClass="TituloPrincipal"></asp:Label></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label9" runat="server" CssClass="normaldetalle">Id</asp:Label></td>
                                                                            <td align="left" colspan="2">
                                                                                <asp:TextBox ID="txtId" runat="server" Width="68px" CssClass="InputTexto"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="left" style="width: 22px; height: 17px">
                                                                                <asp:Label ID="lblDescripcion" runat="server" CssClass="normaldetalle">Descripción</asp:Label></td>
                                                                            <td align="left" colspan="1" style="height: 17px">
                                                                                <asp:TextBox ID="txtDescripcion" runat="server" CssClass="InputTexto" Width="426px"
                                                                                    MaxLength="200"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 17px">
                                                                                <asp:RequiredFieldValidator ID="rfvdescripcion" runat="server" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 17px" align="left">
                                                                                <asp:Label ID="lblEtiqueta" runat="server" CssClass="normaldetalle">Etiqueta</asp:Label></td>
                                                                            <td style="height: 17px" align="left" colspan="1">
                                                                                <asp:TextBox ID="txtEtiqueta" runat="server" Width="426px" CssClass="InputTexto"
                                                                                    MaxLength="80"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 17px">
                                                                                <asp:RequiredFieldValidator ID="rfvetiqueta" runat="server" ControlToValidate="txtEtiqueta">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="left" style="width: 22px; height: 23px">
                                                                                <asp:Label ID="lblNombrePagina" runat="server" CssClass="normaldetalle" Width="99px">Nombre Página</asp:Label></td>
                                                                            <td align="left" colspan="1" style="height: 23px">
                                                                                <asp:TextBox ID="txtNombrePagina" runat="server" CssClass="InputTexto" Width="426px"
                                                                                    MaxLength="120"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 23px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="left" style="width: 22px; height: 23px">
                                                                                <asp:Label ID="lblRutaPagina" runat="server" CssClass="normaldetalle" Width="99px">Ruta URL Pagina</asp:Label></td>
                                                                            <td align="left" colspan="1" style="height: 23px">
                                                                                <asp:TextBox ID="txtRutaUrlPagina" runat="server" CssClass="InputTexto" Width="426px"
                                                                                    MaxLength="200"></asp:TextBox></td>
                                                                            <td align="left" colspan="1" style="height: 23px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 3px;" align="left" valign="top">
                                                                                <table style="width: 89px" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblOpcionPadre" runat="server" CssClass="normaldetalle" Width="82px">Opción padre</asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td align="left" colspan="1" style="height: 3px" valign="top">
                                                                                <table style="width: 259px" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td style="width: 235px; height: 19px;">
                                                                                            <asp:TextBox ID="txtOpcionPadre" runat="server" Width="224px" CssClass="InputTexto"></asp:TextBox></td>
                                                                                        <td style="height: 19px">
                                                                                            <asp:HyperLink ID="hlkBuscaPadre" runat="server" ImageUrl="~/Images/Body/Icons/Consultar.gif">HyperLink</asp:HyperLink></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <input id="hOpcionPadre" runat="server" type="hidden" name="hOpcionPadre" style="width: 25px" /></td>
                                                                            <td align="left" colspan="1" style="height: 3px" valign="top">
                                                                                <asp:RequiredFieldValidator ID="rfvOpcionPadre" runat="server" ControlToValidate="txtOpcionPadre">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="lblNumeroOrden" runat="server" CssClass="normaldetalle" Width="80px">Número orden</asp:Label></td>
                                                                            <td align="left" colspan="1">
                                                                                <ew:NumericBox ID="txtNumeroOrden" CssClass="InputTexto" runat="server" MaxLength="20"
                                                                                    Width="146px"></ew:NumericBox>
                                                                            </td>
                                                                            <td align="left" colspan="1">
                                                                                <asp:RequiredFieldValidator ID="rfvNumerOrden" runat="server" ControlToValidate="txtNumeroOrden"
                                                                                    Width="0px">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="lblOpcionCritica" runat="server" CssClass="normaldetalle" Width="80px">Opción crítica</asp:Label></td>
                                                                            <td style="width: 244px" align="left">
                                                                                <asp:DropDownList ID="cboOpcionCritica" runat="server" Width="154px" CssClass="InputTexto">
                                                                                </asp:DropDownList></td>
                                                                            <td align="left" style="width: 244px">
                                                                                <asp:RequiredFieldValidator ID="rfvOpcionCritica" runat="server" ControlToValidate="cboOpcionCritica">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="lblTipoOpcion" runat="server" CssClass="normaldetalle" Width="82px">Tipo opción</asp:Label></td>
                                                                            <td style="width: 244px" align="left">
                                                                                <asp:DropDownList ID="cboTipoOpcion" runat="server" CssClass="InputTexto" Width="155px">
                                                                                </asp:DropDownList></td>
                                                                            <td align="left" style="width: 244px">
                                                                                <asp:RequiredFieldValidator ID="rfvTipoOpcion" runat="server" ControlToValidate="cboTipoOpcion">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="3" style="height: 38px" valign="middle">
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
