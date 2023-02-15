<%@ Page Language="vb" AutoEventWireup="false" CodeFile="usuarios.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.usuarios" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PDT - </title>
    <link href="../../Style/Style.css" type="text/css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript" language="javascript" src="../../Script/jscript.js"></script>

</head>
<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">
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
                                        <td id="cCabecera" style="height: 74px">
                                            <uc2:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr valign="top">
                                                    <td align="center" style="height: 84px">
                                                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                            <tr class="TablaFilaTitulo">
                                                                <td style="height: 30px">
                                                                    <asp:Label ID="Label5" runat="server" CssClass="TituloPrincipal" Width="205px">ADMINISTRAR USUARIOS</asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td style="width: 39px; height: 30px;" class="TablaColumnaEtiqueta">
                                                                                <asp:Label ID="Label1" runat="server" CssClass="normaldetalle">Login</asp:Label></td>
                                                                            <td style="width: 129px; height: 30px;" align="left" class="TablaColumnaEtiqueta">
                                                                                <asp:TextBox ID="txtLogin" runat="server" Width="111px" CssClass="InputTexto"></asp:TextBox></td>
                                                                            <td style="width: 66px; height: 30px;" class="TablaColumnaEtiqueta">
                                                                                <asp:Label ID="Label2" runat="server" CssClass="normaldetalle">Nombres</asp:Label></td>
                                                                            <td style="width: 264px; height: 30px;" align="left" class="TablaColumnaEtiqueta">
                                                                                <asp:TextBox ID="txtNombres" runat="server" Width="412px" CssClass="InputTexto"></asp:TextBox></td>
                                                                            <td align="left" class="TablaColumnaEtiqueta" style="height: 30px">&nbsp;&nbsp;
                                                                                <asp:Button ID="btnConsultar" runat="server" CausesValidation="False" CssClass="InputBoton"
                                                                                    Style="top: 0px; left: 0px;" Text="Consultar" Width="70px" />&nbsp;&nbsp;&nbsp;
                                                                                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="InputBoton" CausesValidation="False"
                                                                                    Width="70px" Style="left: -9px; top: 0px"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr valign="top">
                                                    <td align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 100%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <input id="hCodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" />
                                                                            <input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina" style="width: 18px;
                                                                                height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <asp:GridView ID="grid" runat="server" Width="100%" CssClass="AlternateItemGrilla"
                                                                                AutoGenerateColumns="False" OnPageIndexChanging="grid_PageIndexChanging" PageSize="6"
                                                                                AllowPaging="True" HorizontalAlign="Center" ShowFooter="True" OnRowCommand="grid_RowCommand"
                                                                                OnRowDataBound="grid_RowDataBound">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="NRO">
                                                                                        <ItemStyle Width="25px" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="IdRegistro" DataField="usuac_iId_Usuario" Visible="False">
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="usuac_vLogin" HeaderText="LOGIN">
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="NOMBRES" DataField="usuac_vNombre">
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="AP. PATERNO" DataField="usuac_vApellido_Paterno">
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="AP. MATERNO" DataField="usuac_vApellido_Materno">
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="EMAIL" DataField="usuac_vCorreo">
                                                                                        <HeaderStyle VerticalAlign="Top" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="desc_iIdEstado_Usuario" HeaderText="INACTIVO" />
                                                                                    <asp:BoundField DataField="desc_iIdEstado_Bloqueado" HeaderText="BLOQUEADO" />
                                                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                                                        <HeaderStyle VerticalAlign="Top" />
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
                                                <tr valign="top" style="height:125px;">
                                                    <td align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnlFrmUsuario" runat="server" Height="50px" Width="125px">
                                                                    <table id="tblFrmUsuario" cellspacing="1" cellpadding="1" width="300" border="0">
                                                                        <tr class="TablaFilaTitulo" style="height: 30px">
                                                                            <td align="center" colspan="4">
                                                                                <asp:Label ID="lblAccion" runat="server" CssClass="TituloPrincipal" Width="162px"></asp:Label></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="lblLoginN" runat="server" CssClass="normaldetalle">Login</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox ID="txtLoginN" runat="server" Width="152px" CssClass="InputTexto"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="rfvLoginN" runat="server" ControlToValidate="txtLoginN">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 17px" align="left">
                                                                                <asp:Label ID="Label8" runat="server" CssClass="normaldetalle">Nombres</asp:Label></td>
                                                                            <td style="height: 17px" align="left" colspan="3">
                                                                                <asp:TextBox ID="txtNombresN" runat="server" Width="400px" CssClass="InputTexto"
                                                                                    MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="rfvNombreN" runat="server"
                                                                                        ControlToValidate="txtNombresN">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 23px;" align="left">
                                                                                <asp:Label ID="Label7" runat="server" CssClass="normaldetalle" Width="82px">Apellido Paterno</asp:Label></td>
                                                                            <td align="left" colspan="3" style="height: 23px">
                                                                                <asp:TextBox ID="txtApellidoPaternoN" runat="server" Width="400px" CssClass="InputTexto"
                                                                                    MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvApellidoPaternoN"
                                                                                        runat="server" ControlToValidate="txtApellidoPaternoN">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label17" runat="server" CssClass="normaldetalle" Width="82px">Apellido Materno</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox ID="txtApellidoMaternoN" runat="server" Width="400px" CssClass="InputTexto"
                                                                                    MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvApellidoMaterno"
                                                                                        runat="server" ControlToValidate="txtApellidoMaternoN">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label6" runat="server" CssClass="normaldetalle" Width="80px">Tipo Doc. Ident.</asp:Label></td>
                                                                            <td style="width: 198px" align="left">
                                                                                <asp:DropDownList ID="cboTipoDocIdent" runat="server" Width="154px" CssClass="InputTexto">
                                                                                </asp:DropDownList></td>
                                                                            <td style="width: 61px" align="left">
                                                                                <asp:Label ID="Label15" runat="server" CssClass="normaldetalle" Width="82px">Num. Doc. Ident.</asp:Label></td>
                                                                            <td align="left" style="width: 140px">
                                                                                <asp:TextBox ID="txtNumeroDocIdent" runat="server" CssClass="InputTexto" Width="120px"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label11" runat="server" CssClass="normaldetalle">Turno</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:DropDownList ID="cboTurno" runat="server" Width="154px" CssClass="InputTexto">
                                                                                </asp:DropDownList><asp:RequiredFieldValidator ID="rfvTurno" runat="server" ControlToValidate="cboTurno">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label13" runat="server" CssClass="normaldetalle">Email</asp:Label></td>
                                                                            <td style="width: 244px" align="left" colspan="3">
                                                                                <asp:TextBox ID="txtEmail" runat="server" Width="400px" CssClass="InputTexto"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="left" style="width: 22px">
                                                                                <asp:Label ID="Label3" runat="server" CssClass="normaldetalle">Perfil</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:DropDownList ID="cboPerfil" runat="server" Width="154px" CssClass="InputTexto">
                                                                                </asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label14" runat="server" CssClass="normaldetalle">Inactivo</asp:Label></td>
                                                                            <td style="width: 198px" align="left">
                                                                                <asp:CheckBox ID="chkInactivo" runat="server" CssClass="InputTexto"></asp:CheckBox></td>
                                                                            <td style="width: 61px" align="left">
                                                                                <asp:Label ID="Label16" runat="server" CssClass="normaldetalle">Bloqueado</asp:Label></td>
                                                                            <td align="left" style="width: 140px">
                                                                                <asp:CheckBox ID="chkBloqueado" runat="server" CssClass="InputTexto"></asp:CheckBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="4" style="height: 23px">
                                                                                <asp:Button ID="btnGrabar" runat="server" Text="Grabar" CssClass="InputBoton" Enabled="False"
                                                                                    Width="75px"></asp:Button>&nbsp;
                                                                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="InputBoton" CausesValidation="False"
                                                                                    Width="75px"></asp:Button>&nbsp;
                                                                            </td>
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
                                    <tr>
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
                                            <uc3:cuPiePagina ID="CuPiePagina1" runat="server" />
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
