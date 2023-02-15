
<%@ Control Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.cuAdministracion" CodeFile="cuAdministracion.ascx.vb" %>
<TABLE id="Table1">
	<TR>
		<TD style="height: 22px">
			<asp:Label id="lblTitulo1" CssClass="normal" runat="server">Cambio de estado</asp:Label>
            <input id="hCodigo" runat="server" name="hCodigo" style="width: 10px; height: 10px"
                type="hidden" /></TD>
	</TR>
	<TR>
		<TD class="normalDetalle">
            <asp:Label ID="lblMensaje4" runat="server" CssClass="normal" Text="Para cambiar el estado del pedido eligelo y presiona
			''Cambiar Estado'' " ></asp:Label>			    
			<asp:dropdownlist id="ddlEstado" runat="Server"></asp:dropdownlist>
			<asp:Button id="btnCambiarEstado" CssClass="inputBoton" Text="Cambiar Estado" Runat="server"></asp:Button></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblMensaje1" CssClass="normal" runat="server">Si se cambia el estado a insertado o recibido, se borra el número de pedido asociado, si es que lo tiene</asp:Label></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblMensaje2" CssClass="normal" runat="server">Cambio de tipo de operación comercial</asp:Label></TD>
	</TR>
	<TR>
		<TD>
			<asp:Label id="lblMensaje3" CssClass="normaldetalle" runat="server">Para cambiar el tipo de operación comercial eligelo y presiona "Cambiar Operación Comercial"</asp:Label>
			<asp:dropdownlist id="ddlOperacionComercial" runat="Server"></asp:dropdownlist>
			<asp:Button id="btnCambiarOperacionComercial" CssClass="inputBoton" Text="Cambiar Operacion Comercial"
				Runat="server"></asp:Button></TD>
	</TR>
</TABLE>
