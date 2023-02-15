<%@ Control Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.cuNuevoSeguimiento"
    CodeFile="cuNuevoSeguimiento.ascx.vb" %>
    <link href="../Style/Estilos.css" type="text/css" rel="stylesheet" />
<table id="tblNuevoSeguimiento" cellspacing="2" cellpadding="1" width="100%" border="0">
    <tr>
        <td class="normal" style="width: 464px" align="center">
            <asp:Label ID="lblObservacion" runat="server" CssClass="normal" Text="Observación"></asp:Label>
            <input id="hCodigo" runat="server" name="hCodigo" style="width: 10px; height: 10px"
                type="hidden" /></td>                   
        <td class="normal" style="width: 50px" align="center">
            </td>                     
        <td class="normal" align="center">
            <asp:Label ID="lblTratamiento" runat="server" CssClass="normal" Text="Tratamiento"></asp:Label></td>
        <td class="normal" align="center">
            <asp:Label ID="lblDestino" runat="server" CssClass="normal" Text="Destino"></asp:Label></td>
    </tr>
    <tr>
        <td valign="top" align="center">
            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td style="height: 65px" valign="top" align="center">                        
                        <asp:TextBox ID="txtObservacion" CssClass="normal" Height="64px" TextMode="MultiLine"
                        Width="100%" runat="server"></asp:TextBox></td>
                            
                </tr>
                <tr>
                    <td class="normaldetalle" align="center">
                        <asp:TextBox ID="TextBox2" CssClass="normaldetalle" Width="30px" runat="server">
                        </asp:TextBox>&nbsp;/
                        250 caracteres</td>
                </tr>
                <tr>
                    <td style="text-align:center" class="normaldetalle">
                        <table id="tblCalendario" cellspacing="0" cellpadding="0" width="250px" border="0">
                            <tr>
                                <td>
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td style="text-align:right">
                                                <asp:Label ID="lblMes" runat="server" CssClass="normal" Text="Mes:"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlMes" runat="server" CssClass="normaldetalle" Width="80px" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                            <td style="text-align:right">
                                                <asp:Label ID="lblAño" runat="server" CssClass="normal" Text="Año:"></asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="ddlAño" runat="server" CssClass="normaldetalle" Width="60px" AutoPostBack="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:center">
                                    <asp:UpdatePanel ID="UpdatePanelCalendario" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:calendar id="calFecha" runat="server" BorderColor="LightGray" ShowTitle="False" ShowNextPrevMonth="False"></asp:calendar>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="normaldetalle" align="center">
                        <asp:CheckBox ID="chkMarcar" runat="server" Text="Marcar como liquidado" TextAlign="Left">
                        </asp:CheckBox></td>
                </tr>
                <tr>
                    <td align="left">
                        <font class="textoRojo">Importante: SOLO se debe marcar como liquidado un pedido que
                            se termina satisfactoriamente, esto quiere decir un producto que se Instala, una
                            migracion que se realiza, etc. Cualquier pedido que no se termina satisfactoriamente
                            porque el cliente lo cancele,&nbsp;este mal emitida o cualquier motivo que impida
                            su término, NO se debe marcar como liquidado.<br>
                            <br>
                            Si el pedido definitivamente no se puede atender, se debe marcar como Rechazado</font></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnIngresarSeguimiento" CssClass="inputboton" Width="137px" runat="server"
                            Text="Ingresar seguimiento"></asp:Button></td>
                </tr>
            </table>
        </td>
        <td valign="top" align="center"></td>         
        <td valign="top" align="center">
            <asp:ListBox ID="lstTratamiento" runat="server" Width="195px" Height="272px" CssClass="normaldetalle">
            </asp:ListBox></td>
        <td valign="top" align="center">
            <asp:ListBox ID="lstDestino" runat="server" Width="194px" Height="272px" CssClass="normaldetalle">
            </asp:ListBox></td>
    </tr>
</table>
