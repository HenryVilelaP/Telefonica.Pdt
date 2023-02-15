<%@ Control Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.cuPedidosRelacionados" CodeFile="cuPedidosRelacionados.ascx.vb" %>
<TABLE id="Table1">
	<TR>
		<TD>
			<INPUT id="hCodigo" style="WIDTH: 18px; HEIGHT: 18px" type="hidden" name="hCodigo" runat="server">
			<INPUT id="hGrillaIndicePagina" style="WIDTH: 18px; HEIGHT: 18px" type="hidden" name="hGrillaIndicePagina"
				runat="server">
			<asp:datagrid id="grid" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" HorizontalAlign="Center"
				PageSize="5" AllowCustomPaging="True" Width="100%" runat="server">
				<FooterStyle CssClass="FooterGrilla"></FooterStyle>
				<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="NRO_WEB" HeaderText="Nro Web">
						<HeaderStyle Width="70px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="FUENTE" HeaderText="Fuente">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Fecha Emisi&#243;n del Pedido">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Cliente">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Tipo Operaci&#243;n Comercial">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Zonal">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Producto">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Fecha Ultimo Seguimiento">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Antig&#252;edad en Web">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESCR" HeaderText="Antig&#252;edad Pedido Emitido">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="Critico" HeaderText="Critico">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:TemplateColumn HeaderText="Pedido Emitible">
						<HeaderStyle Width="70px"></HeaderStyle>
						<ItemTemplate>
							<asp:ImageButton id="Imagebutton1" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Modificar.gif"
								CommandName="GrillaEventoModificar"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
		</TD>
	</TR>
	<tr>
		<td>
			<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
		</td>
	</tr>
</TABLE>
