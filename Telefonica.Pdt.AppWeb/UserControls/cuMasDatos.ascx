<%@ Control Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.cuMasDatos" CodeFile="cuMasDatos.ascx.vb" %>
<TABLE class="normaldetalle" id="Table1" width="100%" border="0">
	<TR>
		<TD class="TablaFilaTitulo" style="HEIGHT: 17px" colSpan="8"><asp:label id="Label47" CssClass="TituloPrincipal" Runat="server">Agendamiento</asp:label>
		    <input id="hIdPedidoPrd" runat="server" name="hIdPedidoPrd" style="width: 10px; height: 10px" type="hidden"/>
            <input id="hCodigo" runat="server" name="hCodigo" style="width: 10px; height: 10px"
                type="hidden"/></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label2" CssClass="normal" Runat="server">Fecha Agendamiento</asp:label></TD>
		<TD colSpan="7"><asp:label id="Label3" CssClass="textoRojoNegrita" Runat="server">Aún no ha sido agendado esta pedido!</asp:label><asp:button id="btnAgendar" CssClass="InputBoton" Runat="server" Text="Agendar..."></asp:button></TD>
	</TR>
	<TR>
		<TD class="TablaFilaTitulo" colSpan="8"><asp:label id="Label4" CssClass="TituloPrincipal" Runat="server">Datos Web Seguimiento</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta" style="WIDTH: 100px"><asp:label id="Label5" CssClass="normal" Runat="server">Fecha Insertada en la Web / Usuario</asp:label></TD>
		<TD><asp:label id="lblFechaInsertadaWebUsuario" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta" style="WIDTH: 100px"><asp:label id="Label6" CssClass="normal" Runat="server">Fecha de Recepción en Contrato BO</asp:label></TD>
		<TD><asp:label id="lblFechaRecepcionContratoBO" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta" style="WIDTH: 100px"><asp:label id="Label9" CssClass="normal" Runat="server">Fecha de Acuerdo</asp:label></TD>
		<TD><asp:label id="lblFechaAcuerdo" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta" style="WIDTH: 100px"><asp:label id="Label11" CssClass="normal" Runat="server">Sub Segmento</asp:label></TD>
		<TD><asp:label id="lblSubSegmento" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label13" CssClass="normal" Runat="server">Fecha y Usuario BO que Emitió</asp:label></TD>
		<TD><asp:label id="lblFechaUsuarioBOEmitio" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label15" CssClass="normal" Runat="server">Observaciones BO que Actualizó</asp:label></TD>
		<TD><asp:label id="lblObservacionesActualizo" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label17" CssClass="normal" Runat="server">Canales</asp:label></TD>
		<TD><asp:label id="lblCanales" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label19" CssClass="normal" Runat="server">Fecha Liquidación Web</asp:label></TD>
		<TD><asp:label id="lblFechaLiquidacionWeb" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaFilaTitulo" colSpan="8"><asp:label id="Label21" CssClass="TituloPrincipal" Runat="server">Datos de Gestel</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label22" CssClass="normal" Runat="server">Inscripción</asp:label></TD>
		<TD><asp:label id="lblInscripcion" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label24" CssClass="normal" Runat="server">Teléfono GESTEL</asp:label></TD>
		<TD><asp:label id="lblTelefonoGestel" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label26" CssClass="normal" Runat="server">Circuito Digital</asp:label></TD>
		<TD><asp:label id="lblCircuitoDigital" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label28" CssClass="normal" Runat="server">Router</asp:label></TD>
		<TD><asp:label id="lblRouter" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaFilaTitulo" style="HEIGHT: 16px" colSpan="8"><asp:label id="Label30" CssClass="TituloPrincipal" Runat="server">Datos de Gesneg</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label31" CssClass="normal" Runat="server">Paquete</asp:label></TD>
		<TD><asp:label id="lblPaquete" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label33" CssClass="normal" Runat="server">Teléfono y nombre vendedor</asp:label></TD>
		<TD><asp:label id="lblTelefonoNombreVendedor" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label35" CssClass="normal" Runat="server">Ejecutivo que creó la venta en Gesneg</asp:label></TD>
		<TD><asp:label id="lblEjecutivoCreoVentaGesneg" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label37" CssClass="normal" Runat="server">Tipo y # documento cliente</asp:label></TD>
		<TD><asp:label id="lblTipoNumeroDocumentoCliente" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label39" CssClass="normal" Runat="server">Forma Adquisición</asp:label></TD>
		<TD><asp:label id="lblFormaAdquisicion" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label41" CssClass="normal" Runat="server">Tiempo Contrato</asp:label></TD>
		<TD><asp:label id="lblTiempoContrato" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label43" CssClass="normal" Runat="server">Fecha Contrato</asp:label></TD>
		<TD><asp:label id="lblFechaContrato" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label45" CssClass="normal" Runat="server">Id Liquidación Gesneg</asp:label></TD>
		<TD><asp:label id="lblIdLiquidacionGesneg" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label48" CssClass="normal" Runat="server">Fecha Inicio/Fin Piloto</asp:label></TD>
		<TD><asp:label id="lblFechaInicioFinPiloto" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label50" CssClass="normal" Runat="server">Número items</asp:label></TD>
		<TD><asp:label id="lblNumeroItems" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label52" CssClass="normal" Runat="server">Nombre contacto</asp:label></TD>
		<TD><asp:label id="lblNombreContacto" CssClass="normal" Runat="server">-</asp:label></TD>
		<TD class="TablaColumnaEtiqueta"><asp:label id="Label54" CssClass="normal" Runat="server">Teléfono contacto</asp:label></TD>
		<TD><asp:label id="lblTelefonoContacto" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
	<TR>
		<TD class="TablaColumnaEtiqueta"><asp:label id="label155" CssClass="normal" Runat="server">Observaciones Ejecutivo</asp:label></TD>
		<TD colSpan="7"><asp:label id="lblObservacionesEjecutivo" CssClass="normal" Runat="server">-</asp:label></TD>
	</TR>
</TABLE>
<BR>
<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
	<TR>
		<TD class="TablaFilaTitulo" style="HEIGHT: 30px" colSpan="2">
			<asp:Label id="Label1" CssClass="TituloPrincipal" runat="server">Resultado de la validación</asp:Label></TD>
	</TR>
	<TR>
		<TD style="WIDTH: 100px" align="center"><asp:button id="btnAprobar" CssClass="InputBoton" Runat="server" Text="Aprobar" Width="85px"></asp:button></TD>
		<TD class="normal">control Aprueba el pedido para su emisión</TD>
	</TR>
	<TR>
		<TD style="WIDTH: 104px" align="center"><asp:button id="btnRechazar" CssClass="InputBoton" Runat="server" Text="Rechazar" Width="85px"></asp:button></TD>
		<TD class="normal">control Rechaza el pedido del cliente</TD>
	</TR>
</TABLE>
