<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBuscarOpcionPadre.aspx.vb" Inherits="Telefonica.Pdt.AppWeb.IU_seguridad_frmBuscarOpcionPadre" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Asignar opcion padre</title>
    <link href="../../style/Style.css" rel="stylesheet" />
    <link href="../../style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/jscript" src="../../Script/jscript.js"></script>    
</head>
<body style="margin-bottom: 0; margin-left: 0; margin-right: 0; margin-top: 0">
    <form id="form1" runat="server">
        <table id="tGeneral" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
            text-align: center">
            <tr>
                <td>
                    <table id="tWFijo" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                        text-align: center">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <table id="tPrincipal" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                                    text-align: center">
                                    <tr style="width: 100%; vertical-align:top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td>
                                            <table id="tContenido" border="0" cellpadding="1" cellspacing="1" style="width:100%; text-align:left">
                                                <tr>
                                                    <td align="center">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="height: 43px">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="normaldetalle" Text="OPCIONES DEL MENU PRINCIPAL"
                                                                        Width="166px"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" valign="top">
                                                                    &nbsp;<table style="width: 100%">
                                                                        <tr>
                                                                            <td align="right">
                                                                                <input id="hcodigo" runat="server" name="hCodigo" style="width: 18px; height: 18px"
                                                                                    type="hidden" /><input id="hGrillaIndicePagina" runat="server" name="hGrillaIndicePagina"
                                                                                        style="width: 18px; height: 18px" type="hidden" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                    <asp:GridView ID="grid" runat="server" CssClass="AlternateItemGrilla" Width="100%" AutoGenerateColumns="False" PageSize="8" AllowPaging="True">
                                                                        <RowStyle CssClass="ItemGrilla" />
                                                                        <HeaderStyle CssClass="HeaderGrilla" />
                                                                        <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="NRO." />
                                                                            <asp:BoundField HeaderText="OPCION" DataField="opcic_vDescripcion" >
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="APLICAR">
                                                                                <ItemTemplate>
                                                                                    <asp:ImageButton ID="imgBtnModificar" runat="server" CausesValidation="False" CommandName="GrillaEventoModificar"
                                                                                        ImageUrl="~/Images/Body/Icons/Detalles.gif" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right">
                                                                                <asp:Label ID="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:</asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:Button ID="btnCerrar" runat="server" CssClass="InputBoton" Text="Cerrar" Width="80px" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
