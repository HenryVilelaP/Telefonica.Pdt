<%@ Page Language="vb" AutoEventWireup="false" CodeFile="Turno.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.Turno" %>

<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc1" %>
<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc2" %>
<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc1" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PDT - TURNOS</title>
    <link href="../../Style/Style.css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="frmPanel" method="post" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table id="tGeneral" cellspacing="0" cellpadding="0" align="center" border="0" style="width: 100%">
            <tr style="vertical-align:top">
                <td>
                    <table id="tWFijo" style="width: 1002px" cellspacing="0" cellpadding="0" align="center"
                        border="0">
                        <tr style="vertical-align:top">
                            <td style="width: 5px;">
                            </td>
                            <td>
                                <table id="tPrincipal" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
                                    border="0">
                                    <tr style="width: 100%; height: 112px" valign="top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera">
                                            <uc2:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center">
                                            <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                border="0">
                                                <tr class="TablaFilaTitulo">
                                                    <td align="center">
                                                        <asp:Label ID="Label5" runat="server" CssClass="TituloPrincipal" Width="200px">TURNOS</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelGrilla" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <table style="width: 75px">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <input id="hcodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                    style="width: 18px; height: 18px" type="hidden" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:GridView ID="grid" runat="server" Width="757px" CssClass="AlternateItemGrilla"
                                                                                AutoGenerateColumns="False" OnPageIndexChanging="grid_PageIndexChanging" OnRowCommand="grid_RowCommand"
                                                                                OnRowDataBound="grid_RowDataBound" PageSize="8">
                                                                                <FooterStyle CssClass="FooterGrilla" />
                                                                                <RowStyle CssClass="ItemGrilla" />
                                                                                <HeaderStyle CssClass="HeaderGrilla" />
                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="turnc_iIdTurno" HeaderText="ID" />
                                                                                    <asp:BoundField DataField="turnc_vDescripcion_Turno" HeaderText="DESCRIPCION" >
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Lunes" HeaderText="LUNES (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Lunes" HeaderText="LUNES (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Martes" HeaderText="MARTES (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Martes" HeaderText="MARTES (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Miercoles" HeaderText="MIERCOLES (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Miercoles" HeaderText="MIERCOLES (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Jueves" HeaderText="JUEVES (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Jueves" HeaderText="JUEVES (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Viernes" HeaderText="VIERNES (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Viernes" HeaderText="VIERNES (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Sabado" HeaderText="SABADO (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Sabado" HeaderText="SABADO (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Ingreso_Domingo" HeaderText="DOMINGO (I)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="turnc_dHora_Salida_Domingo" HeaderText="DOMINGO (S)" >
                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="MODIFICAR">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnModificar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                                ImageUrl="../../Images/Body/Icons/Modificar.gif" />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="ELIMINAR">
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="imgBtnEliminar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                                ImageUrl="../../Images/Body/Icons/Eliminar.gif" />
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
                                                    <td align="center">
                                                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="InputBoton"></asp:Button>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="middle" align="center">
                                                        <asp:UpdatePanel ID="UpdatePanelDetalle" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="pnlFrmTurno" runat="server">
                                                                    <table id="Table2" cellspacing="1" cellpadding="1" width="300" border="0">
                                                                        <tr class="TablaFilaTitulo">
                                                                            <td align="center" colspan="4">
                                                                                <asp:Label ID="lblAccion" runat="server" CssClass="TituloPrincipal"></asp:Label></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px" align="left">
                                                                                <asp:Label ID="Label9" runat="server" CssClass="normaldetalle">Id</asp:Label></td>
                                                                            <td align="left" colspan="3">
                                                                                <asp:TextBox ID="txtId" runat="server" Width="39px" CssClass="InputTexto"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td style="width: 22px; height: 17px" align="left">
                                                                                <asp:Label ID="Label8" runat="server" CssClass="normaldetalle">Descripción</asp:Label></td>
                                                                            <td style="height: 17px" align="left" colspan="3">
                                                                                <asp:TextBox ID="txtDescripcion" runat="server" Width="362px" CssClass="InputTexto" MaxLength="50"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</asp:RequiredFieldValidator></td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="4">
                                                                                <table style="width: 191px">
                                                                                    <tr>
                                                                                        <td style="height: 27px">
                                                                                        </td>
                                                                                        <td align="center" colspan="4" style="height: 27px">
                                                                                            <asp:Label ID="Label41" runat="server" CssClass="normaldetalle">INGRESO</asp:Label></td>
                                                                                        <td align="center" colspan="4" style="height: 27px">
                                                                                            <asp:Label ID="Label42" runat="server" CssClass="normaldetalle">SALIDA</asp:Label></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label1" runat="server" CssClass="normaldetalle">Lunes</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label13" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoLunes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label20" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoLunes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label27" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaLunes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label28" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaLunes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label2" runat="server" CssClass="normaldetalle">Martes</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label14" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoMartes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label21" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoMartes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label29" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaMartes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label35" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaMartes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label3" runat="server" CssClass="normaldetalle">Miercoles</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label15" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoMiercoles" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label22" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoMiercoles" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label30" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaMiercoles" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label36" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaMiercoles" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 20px" align="left">
                                                                                            <asp:Label ID="Label4" runat="server" CssClass="normaldetalle">Jueves</asp:Label></td>
                                                                                        <td style="width: 19px; height: 20px">
                                                                                            <asp:Label ID="Label16" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td style="height: 20px">
                                                                                            <asp:DropDownList ID="cboHoraIngresoJueves" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px; height: 20px">
                                                                                            <asp:Label ID="Label23" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td style="height: 20px">
                                                                                            <asp:DropDownList ID="cboMinutosIngresoJueves" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px; height: 20px">
                                                                                            <asp:Label ID="Label31" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td style="height: 20px">
                                                                                            <asp:DropDownList ID="cboHoraSalidaJueves" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="height: 20px">
                                                                                            <asp:Label ID="Label37" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td style="height: 20px">
                                                                                            <asp:DropDownList ID="cboMinutosSalidaJueves" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label6" runat="server" CssClass="normaldetalle">Viernes</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label17" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoViernes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label24" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoViernes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label32" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaViernes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label38" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaViernes" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label7" runat="server" CssClass="normaldetalle">Sábado</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label18" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoSabado" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label25" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoSabado" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label33" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaSabado" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label39" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaSabado" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label11" runat="server" CssClass="normaldetalle">Domingo</asp:Label></td>
                                                                                        <td style="width: 19px">
                                                                                            <asp:Label ID="Label19" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraIngresoDomingo" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 5px">
                                                                                            <asp:Label ID="Label26" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosIngresoDomingo" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td style="width: 3px">
                                                                                            <asp:Label ID="Label34" runat="server" CssClass="normaldetalle">Hora:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboHoraSalidaDomingo" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            <asp:Label ID="Label40" runat="server" CssClass="normaldetalle">Min:</asp:Label></td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="cboMinutosSalidaDomingo" runat="server" CssClass="InputTexto">
                                                                                            </asp:DropDownList></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <asp:Label ID="Label12" runat="server" CssClass="normaldetalle">Inactivo</asp:Label></td>
                                                                                        <td align="left" colspan="8">
                                                                                            <asp:CheckBox ID="chkInactivo" runat="server" CssClass="InputTexto" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr class="TablaColumnaEtiqueta">
                                                                            <td align="center" colspan="4">
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
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px" valign="top">
                                        <!--Region del Pie de Pagina de PdT -->
                                        <td id="cPiePagina">
                                            <uc1:cuPiePagina ID="CuPiePagina1" runat="server" />
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
