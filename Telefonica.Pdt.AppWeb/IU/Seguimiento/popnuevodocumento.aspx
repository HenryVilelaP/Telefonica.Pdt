<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.popNuevoDocumento" CodeFile="popNuevoDocumento.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<HEAD>
		<title>popNuevoDocumento</title>
		
		
		
		
		<LINK href="../../style/Style.css" rel="stylesheet">
		<LINK href="../../Style/Estilos.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body  bottomMargin="0" leftMargin="5" topMargin="25" rightMargin="5">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD width="100%"><asp:label id="lblarchivo" runat="server" CssClass="normal">Elige el archivo a subir y presiona "Publicar"... </asp:label>
						<hr>
					</TD>
				</TR>
				<TR>
					<TD width="100%">
						<TABLE id="Table2" style="WIDTH: 100%; HEIGHT: 156px" cellSpacing="1" cellPadding="1" border="0">
							<TR>
								<TD vAlign="top"><asp:label id="Label1" runat="server" CssClass="normal">Archivo</asp:label></TD>
								<TD><asp:textbox id="txtarchivo" runat="server" CssClass="normaldetalle" Width="200px"></asp:textbox><asp:button id="btnSubir" runat="server" CssClass="inputboton" Text="Examinar"></asp:button><BR>
									<asp:label id="Label2" runat="server" CssClass="normal">(peso maximo 300kb)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:label id="Label3" runat="server" CssClass="normal">Tipo</asp:label></TD>
								<TD><asp:listbox id="lstTipos" runat="server" CssClass="normaldetalle" Width="100%" Height="240px"></asp:listbox></TD>
							</TR>
							<TR>
								<TD vAlign="middle" align="center" colSpan="2"><asp:button id="btnPublicar" runat="server" CssClass="inputboton" Text="Publicar"></asp:button></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
