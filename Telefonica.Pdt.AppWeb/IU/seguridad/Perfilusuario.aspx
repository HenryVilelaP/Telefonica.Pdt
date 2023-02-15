<%@ Page Language="vb" AutoEventWireup="false" CodeFile="Perfilusuario.aspx.vb" Inherits="Perfilusuario"%>

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
															                    <asp:Label id="Label5" runat="server" CssClass="normalDetalle" Width="138px">PERFILES POR USUARIO</asp:Label></TD>
													                    </TR>
													                    <TR>
														                    <TD style="WIDTH: 22px" align="left">
															                    <asp:Label id="Label1" runat="server" CssClass="normalDetalle">Código</asp:Label></TD>
														                    <TD align="left">
															                    <asp:TextBox id="TextBox1" runat="server" Width="111px" CssClass="inputtexto"></asp:TextBox></TD>
													                    </TR>
													                    <TR>
														                    <TD style="WIDTH: 22px" align="left">
															                    <asp:Label id="Label2" runat="server" CssClass="normalDetalle">Nombres</asp:Label></TD>
														                    <TD align="left">
															                    <asp:TextBox id="TextBox2" runat="server" Width="248px" CssClass="inputtexto"></asp:TextBox></TD>
													                    </TR>
													                    <TR>
														                    <TD style="WIDTH: 22px" align="left">
															                    <asp:Label id="Label3" runat="server" CssClass="normalDetalle" Width="81px">Apellido Paterno</asp:Label></TD>
														                    <TD align="left">
															                    <asp:TextBox id="TextBox3" runat="server" Width="248px" CssClass="inputtexto"></asp:TextBox></TD>
													                    </TR>
                                                                        <tr>
                                                                            <td align="left" style="width: 22px">
															                    <asp:Label id="Label4" runat="server" CssClass="normalDetalle" Width="83px">Apellido Materno</asp:Label></td>
                                                                            <td align="left">
															                    <asp:TextBox id="TextBox4" runat="server" Width="248px" CssClass="inputtexto"></asp:TextBox></td>
                                                                        </tr>
													                    <TR>
														                    <TD align="center" colSpan="2">
															                    <asp:Button id="Button1" runat="server" Text="Buscar" CssClass="InputBoton"></asp:Button>&nbsp;
															                    <asp:Button id="Button2" runat="server" Text="Limpiar" CssClass="InputBoton"></asp:Button></TD>
													                    </TR>
												                    </TABLE>
											                    </td>
										                    </tr>
										                    <tr>
											                    <td align="center" colSpan="3">
                                                                    <asp:GridView ID="GridView1" runat="server" Width="347px" CssClass="AlternateItemGrilla">
                                                                    </asp:GridView>    													        
											                    </td>
										                    </tr>
										                    <tr>
											                    <td vAlign="middle" align="center" colSpan="3">
												                    <TABLE id="Table2" cellSpacing="1" cellPadding="1" width="300" border="1">
													                    <TR>
														                    <TD align="center" colSpan="1">
															                    <asp:Label id="Label10" runat="server" CssClass="normalDetalle">Perfiles:</asp:Label></TD>
													                    </TR>
													                    <TR>
														                    <TD style="WIDTH: 244px" align="left">
                                                                                <asp:CheckBox ID="CheckBox1" runat="server" CssClass="inputtexto" /></TD>
													                    </TR>
													                    <TR>
														                    <TD align="center" colSpan="1">
															                    <asp:Button id="Button5" runat="server" Text="Guardar" CssClass="InputBoton"></asp:Button>&nbsp;
															                    <asp:Button id="Button4" runat="server" Text="Cancelar" CssClass="InputBoton"></asp:Button></TD>
													                    </TR>
												                    </TABLE>
												                </td>
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
