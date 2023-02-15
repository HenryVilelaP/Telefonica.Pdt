<%@ Page Language="vb" AutoEventWireup="false" CodeFile="opcion.aspx.vb" Inherits="opcion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PDT - USUARIOS</title>
    <link href="../../Style/Style.css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body class="clsBody" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0"
    ms_positioning="FlowLayout">
    <form id="Form1" method="post" runat="server">
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
                                            CABECERA DE PDT</td>
                                    </tr>
                                    <tr style="width: 100%; height: 428px" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td align="center" style="height: 418px">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table id="tContenido" cellspacing="1" cellpadding="1" width="100%" align="center"
                                                        border="0">
                                                        <tr>
                                                            <td align="center">
                                                                <table id="tblFormUsuarios" cellspacing="1" cellpadding="1" width="300" border="1">
                                                                    <tr>
                                                                        <td align="center" colspan="2" style="height: 23px">
                                                                            <asp:Label ID="Label5" runat="server" CssClass="normalDetalle" Width="138px">OPCIONES</asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label1" runat="server" CssClass="normalDetalle">Descripción</asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Width="111px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label2" runat="server" CssClass="normalDetalle" Width="75px">Tipo opción</asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="DropDownList3" runat="server" CssClass="inputtexto">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label3" runat="server" CssClass="normalDetalle" Width="81px">Opción Padre</asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox3" runat="server" Width="248px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" style="width: 22px">
                                                                            <asp:Label ID="Label4" runat="server" CssClass="normalDetalle" Width="83px">Opción Critica</asp:Label></td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox4" runat="server" Width="248px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="boton"></asp:Button>&nbsp;
                                                                            <asp:Button ID="Button2" runat="server" Text="Limpiar" CssClass="boton" Style="left: 0px;
                                                                                top: 0px"></asp:Button></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:GridView ID="GridView1" runat="server" Width="347px" CssClass="AlternateItemGrilla">
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="3">
                                                                <asp:Button ID="Button3" runat="server" Text="Nuevo" CssClass="boton"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle" align="center" colspan="3">
                                                                <table id="Table2" cellspacing="1" cellpadding="1" width="300" border="1">
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Label ID="Label10" runat="server" CssClass="normalDetalle">Label</asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label9" runat="server" CssClass="normalDetalle">Id</asp:Label></td>
                                                                        <td style="width: 244px" align="left">
                                                                            <asp:TextBox ID="TextBox8" runat="server" Width="250px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px; height: 17px" align="left">
                                                                            <asp:Label ID="Label8" runat="server" CssClass="normalDetalle">Descripción</asp:Label></td>
                                                                        <td style="height: 17px" align="left" colspan="1">
                                                                            <asp:TextBox ID="TextBox7" runat="server" Width="426px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px; height: 23px;" align="left">
                                                                            <asp:Label ID="Label7" runat="server" CssClass="normalDetalle" Width="82px">Tipo opción</asp:Label></td>
                                                                        <td align="left" colspan="1" style="height: 23px">
                                                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="inputtexto">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label17" runat="server" CssClass="normalDetalle" Width="82px">Opción padre</asp:Label></td>
                                                                        <td align="left" colspan="1">
                                                                            <asp:TextBox ID="TextBox11" runat="server" Width="426px" CssClass="inputtexto"></asp:TextBox></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label6" runat="server" CssClass="normalDetalle" Width="80px">Opción crítica</asp:Label></td>
                                                                        <td style="width: 244px" align="left">
                                                                            <asp:DropDownList ID="DropDownList1" runat="server" Width="154px" CssClass="inputtexto">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 22px" align="left">
                                                                            <asp:Label ID="Label11" runat="server" CssClass="normalDetalle" Width="80px">Número orden</asp:Label></td>
                                                                        <td style="width: 244px" align="left">
                                                                            <asp:DropDownList ID="DropDownList2" runat="server" Width="154px" CssClass="inputtexto">
                                                                            </asp:DropDownList></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center" colspan="2">
                                                                            <asp:Button ID="Button5" runat="server" Text="Guardar" CssClass="boton"></asp:Button>&nbsp;
                                                                            <asp:Button ID="Button4" runat="server" Text="Cancelar" CssClass="boton"></asp:Button></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px" valign="top">
                                        <!--Region del Pie de Pagina de PdT -->
                                        <td id="cPiePagina">
                                            PIE DE PAGINA DE PDT</td>
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
