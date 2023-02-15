<%@ Control Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.cuSeguimiento" CodeFile="cuSeguimiento.ascx.vb" %>
<TABLE id="Table1" style="MARGIN-LEFT:auto;MARGIN-RIGHT:auto" width="100%">
	<TR>
		<TD align="center">
			<INPUT id="hCodigo" style="WIDTH: 18px; HEIGHT: 18px" type="hidden" name="hCodigo" runat="server">
			<INPUT id="hGrillaIndicePagina" style="WIDTH: 18px; HEIGHT: 18px" type="hidden" name="hGrillaIndicePagina"
				runat="server">
			<asp:datagrid id="grid" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" HorizontalAlign="Center"
				PageSize="5" AllowCustomPaging="True" Width="944px" runat="server" CssClass="grid">
				<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
				<ItemStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></ItemStyle>
				<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
				<FooterStyle CssClass="FooterGrilla"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="diafc_dFec_Registro" HeaderText="Fecha">
						<HeaderStyle Width="70px"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="USUARIO_REGISTRO" HeaderText="Usuario">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="cobic_vDescripcion" HeaderText="Observaci&#243;n">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="TRATAMIENTO" HeaderText="Tratamiento">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="DESTINO" HeaderText="Destino">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="cobic_dFec_Atencion" HeaderText="Fecha Agenda">
						<ItemStyle HorizontalAlign="Left"></ItemStyle>
					</asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
			</asp:datagrid>
			<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
		</TD>
	</TR>
	<tr>
		<td style="HEIGHT: 17px">&nbsp;</td>
	</tr>
	<tr>
		<td>
			<table style="WIDTH: 100%; HEIGHT: 25px" cellSpacing="0" cellPadding="0" border="0">
				<tr>
					<td></td>
					<td align="right"><asp:label id="lblRegistrosEncontrados" runat="server" CssClass="clsBodyLabel" Visible="False">Total de Registros Encontrados:&nbsp;</asp:label></td>
					<td width="50">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</TABLE>
