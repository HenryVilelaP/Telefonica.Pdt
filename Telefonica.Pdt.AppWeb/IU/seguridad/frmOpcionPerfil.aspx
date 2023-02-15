<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmOpcionPerfil.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.IU_seguridad_frmOpcionPerfil" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PDT - OPCION / PERFIL</title>
    <link href="../../Style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/jscript" src="../../Script/jscript.js"></script>        
</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0"
    ms_positioning="FlowLayout">
    <form id="frmOpcion" method="post" runat="server">
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
                                                <tr>
                                                    <td align="center">
                                                        <table style="width: 100%">
                                                            <tr class="TablaFilaTitulo">
                                                                <td colspan="5" style="height: 30px" valign="middle">
                                                                    <asp:Label ID="Label5" runat="server" CssClass="TituloPrincipal" Width="138px">OPCION - PERFIL</asp:Label></td>
                                                            </tr>
                                                            <tr class="TablaColumnaEtiqueta">
                                                                <td colspan="5" align="left">
                                                                    <table style="width: 159px" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label1" runat="server" CssClass="normaldetalle" Width="124px">PERFIL SELECCIONADO:</asp:Label></td>
                                                                            <td align="left">
                                                                                <asp:Label ID="lblPerfilSeleccionado" runat="server" CssClass="normaldetalle" Width="157px" Font-Bold="True"></asp:Label></td>
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
                                                                            <input id="hcodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                    style="width: 18px; height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                <asp:GridView ID="grid" runat="server" Width="100%" CssClass="AlternateItemGrilla"  AutoGenerateColumns="False"  AllowPaging="True">
                                                                    <FooterStyle CssClass="FooterGrilla" />
                                                                    <RowStyle CssClass="ItemGrilla" />
                                                                    <HeaderStyle CssClass="HeaderGrilla" />
                                                                    <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                                                                    <Columns>
                                                                        <asp:BoundField HeaderText="NRO." />
                                                                        <asp:TemplateField HeaderText="APLICAR">
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkIdOpcion" runat="server" CssClass="InputTexto" />
                                                                                <asp:HiddenField ID="hIdOpcion" runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>                                                                        
                                                                        <asp:BoundField DataField="opcic_vDescripcion" HeaderText="OPCION" >
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="acpac_iEstado_Registro" HeaderText="ESTADO"  Visible="False"/>
                                                                        <asp:TemplateField HeaderText="ACCION">
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="imgBtnConsultar" runat="server" CausesValidation="False" CommandName="GrillaEventoMostrarDetalle"
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
                                                    <td align="center" style="height: 21px">
                                                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="InputBoton" Width="80px"></asp:Button>
                                                        <asp:Button ID="btnRegresar" runat="server" CausesValidation="False" CssClass="InputBoton"
                                                            Text="Regresar" Width="80px" /></td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        &nbsp;</td>
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
                                            &nbsp;
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
