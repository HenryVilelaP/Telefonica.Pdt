<%@ Page Language="vb" AutoEventWireup="false" CodeFile="AccionPaginaPerfil.aspx.vb" Inherits="AccionPaginaPerfil"%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PDT - USUARIOS</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../../Style/Style.css" rel="stylesheet">
		<link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../../Script/jscript.js"></script>
	</HEAD>
	<body class="clsBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" MS_POSITIONING="FlowLayout">
		<form id="Form1" method="post" runat="server">
			<table id="tGeneral" cellSpacing="0" cellPadding="0" align="center" border="0" style="WIDTH: 100%">
				<tr>
					<td>
						<table id="tWFijo" style="WIDTH: 1002px" cellSpacing="0" cellPadding="0" align="center"
							border="0">
							<tr>
								<td style="WIDTH: 5px"></td>
								<td>
									<table id="tPrincipal" style="WIDTH: 100%" cellSpacing="0" cellPadding="0" align="center"
										border="0">
										<tr style="WIDTH: 100%; HEIGHT: 112px" valign="top">
											<!--Region de la Cabecera de PdT -->
											<td id="cCabecera">CABECERA DE PDT</td>
										</tr>
										<tr style="WIDTH: 100%; HEIGHT: 428px" valign="top">
											<!--Region de Trabajo del Desarrollador -->
											<td align="center" style="height: 418px">
                                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table id="tContenido" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
											                <tr>
											                    <td align="center">
												                    <TABLE id="tblFormUsuarios" cellSpacing="1" cellPadding="1" width="300" border="1">
													                    <TR>
														                    <TD align="center" colSpan="2" style="height: 23px">
															                    <asp:Label id="Label5" runat="server" CssClass="normalDetalle" Width="180px">ACCION EN PAGINA POR PERFIL</asp:Label></TD>
													                    </TR>
													                    <TR>
														                    <TD style="WIDTH: 37px" align="left">
															                    <asp:Label id="Label1" runat="server" CssClass="normalDetalle">Perfil</asp:Label></TD>
														                    <TD align="left" style="width: 253px">
                                                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="inputtexto" Width="222px">
                                                                                </asp:DropDownList></TD>
													                    </TR>
													                    <TR>
														                    <TD align="center" colSpan="2">
															                    <asp:Button id="Button1" runat="server" Text="Buscar" CssClass="boton"></asp:Button>&nbsp;
															                    </TD>
													                    </TR>
												                    </TABLE>
											                    </td>
										                    </tr>
										                    <tr>
											                    <td align="center" colSpan="3" style="width: 351px">
                                                                    <asp:GridView ID="GridView1" runat="server" Width="347px" CssClass="AlternateItemGrilla">
                                                                    </asp:GridView>    													        
											                    </td>
										                    </tr>
										                    <tr>
											                    <td vAlign="middle" align="center" colSpan="3" style="width: 351px">
															                    <asp:Button id="Button5" runat="server" Text="Guardar" CssClass="boton" style="left: 0px"></asp:Button>&nbsp;<asp:Button id="Button4" runat="server" Text="Cancelar" CssClass="boton" style="left: 0px; top: 1px"></asp:Button></td>
											                </tr>
											            </table>                                                        
                                                    </ContentTemplate>                                                                                                    
                                                </asp:UpdatePanel>																								
                                            </td>
										</tr>
										<tr style="WIDTH: 100%; HEIGHT: 60px" valign="top">
											<!--Region del Pie de Pagina de PdT -->
											<td id="cPiePagina">PIE DE PAGINA DE PDT</td>
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
</HTML>
