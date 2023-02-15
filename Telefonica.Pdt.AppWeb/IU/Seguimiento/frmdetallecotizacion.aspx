<%@ Page Language="vb" AutoEventWireup="false" Inherits="Telefonica.Pdt.AppWeb.frmDetalleCotizacion"
    CodeFile="frmDetalleCotizacion.aspx.vb" EnableEventValidation="false"%>

<%@ Register Src="../../UserControls/AspNetAjaxProgresoProceso.ascx" TagName="AspNetAjaxProgresoProceso"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>

<%@ Register Src="../../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ PreviousPageType VirtualPath="~/IU/Seguimiento/frmadminlistacotizacion.aspx" %>

<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PdT - Detalle de la Cotización</title>
    <link href="../../Style/Style.css" type="text/css" rel="stylesheet">
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body  bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0">
    <form id="Form1" method="post" runat="server">        
        <table id="tGeneral" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
            border="0">
            <tr>
                <td>
                    <table id="tWFijo" style="width: 100%" cellspacing="0" cellpadding="0" align="center"
                        border="0">
                        <tr>
                            <td style="width: 5px;">
                            </td>
                            <td>
                                <table id="tPrincipal" style="width: 100%" cellspacing="0" cellpadding="0" align="left"
                                    border="0">
                                    <tr style="width: 100%; height: 90px" valign="top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <uc1:cuCabecera ID="CuCabecera1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 428px" valign="top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td>
                                            <table id="tContenido" style="width: 100%" cellspacing="1" cellpadding="1" border="0">
                                                <tr style="height: 30px" align="center" class="TablaFilaTitulo">
                                                    <td>
                                                        &nbsp;<asp:Label ID="lblTitulo" CssClass="TituloPrincipal" runat="server">REGISTRO DE COTIZACIONES</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td align="left" height="21" class="TablaColumnaEtiqueta">
                                                                    <asp:Label ID="lblTipoDocumento" CssClass="normal" runat="server">Tipo Documento</asp:Label></td>
                                                                <td class="TablaFilaPar" align="left" height="21">
                                                                    <asp:DropDownList ID="ddlTipoDocumentoFiltro" CssClass="InputTexto" runat="server" EnableViewState="True" TabIndex="0">
                                                                    </asp:DropDownList>
                                                                    <ew:NumericBox ID="txtNumeroDocumentoFiltro" TabIndex="1" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="7" Width="100px" RealNumber="False"></ew:NumericBox>
                                                                </td>
                                                                <td class="TablaColumnaEtiqueta">
                                                                    <asp:updatepanel ID="UpdatePanelBotones" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:Button ID="btnConsultar" runat="Server" CssClass="InputBoton" Text="Consultar"></asp:Button>
                                                                            <asp:Button ID="btnRegresar" runat="server" CssClass="InputBoton" Text="Regresar" OnClick="btnRegresar_Click"></asp:Button>
                                                                            <asp:Button ID="btnGrabar" runat="server" CssClass="InputBoton" Text="Grabar" CausesValidation="true"></asp:Button>
                                                                            <asp:Button ID="btnTraerPlantilla" runat="server" CssClass="InputBoton" Text="Traer Plantilla" Enabled="False"></asp:Button>
                                                                            <asp:Button ID="btnCerrar" runat="server" CssClass="InputBoton" Text="Cerrar" Enabled="False" OnClick="btnCerrar_Click"></asp:Button>
                                                                            <asp:Button ID="btnExportar" runat="server" CssClass="InputBoton" Text="Exportar" Enabled="False"></asp:Button>
                                                                            <asp:Button ID="btnAnular" runat="server" CssClass="InputBoton" Text="Anular"></asp:Button>
                                                                            <asp:Button ID="btnEnviar" runat="server" CssClass="InputBoton" Text="Enviar"></asp:Button>
                                                                            <asp:Button ID="btnAprobar" runat="server" CssClass="InputBoton" Text="Aprobar" Enabled=false></asp:Button>                                                                    
                                                                            <asp:Button ID="btnImprimir" runat="server" CssClass="InputBoton" Text="Imprimir" Enabled="False" EnableTheming="True"></asp:Button>
                                                                        </ContentTemplate>
                                                                    </asp:updatepanel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    <asp:UpdatePanel ID="UpdatePanelTabPanel" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <cc1:TabContainer ID="TabContainer1" runat="server">
                                                            <cc1:TabPanel ID="TabPanel1" runat="server">
                                                                <HeaderTemplate>
                                                                    Datos Cliente
                                                                </HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <asp:UpdatePanel ID="UpdatePanelDatosCliente" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                            <table width="100%" border="0">
                                                                                <tr>
                                                                                    <td width="165">
                                                                                        <asp:Label ID="lblNumeroCotizacion" CssClass="normal" runat="server">Número de Cotización:</asp:Label></td>
                                                                                    <td class="clsBodyStaticText" height="11">
                                                                                        <asp:Label ID="lblCotizacion" CssClass="TextoNegroNegrita" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="9">
                                                                                        <asp:Label ID="lblTipoCliente" CssClass="normal" runat="server">Tipo de Cliente:</asp:Label>
                                                                                    </td>
                                                                                    <td height="9">
                                                                                        <asp:DropDownList ID="ddlTipoCliente" TabIndex="4" CssClass="InputTexto" runat="server"
                                                                                            AutoPostBack="True">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="rfvTipoCliente" runat="server" Text="*" ErrorMessage="Tipo de Cliente"
                                                                                            ControlToValidate="ddlTipoCliente" InitialValue="%%" ValidationGroup="DatosCliente" ToolTip="Ingrese Tipo de Cliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRazonSocial" CssClass="normal" runat="server">Razón Social:</asp:Label></td>
                                                                                    <td colspan="3">
                                                                                        <asp:TextBox ID="txtRazonSocial" TabIndex="5" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="120" Width="250px" Enabled="False"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvRazonSocial" runat="server" Text="*" ErrorMessage="Razón Social"
                                                                                            ControlToValidate="txtRazonSocial" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNombres" CssClass="normal" runat="server">Nombres:</asp:Label></td>
                                                                                    <td colspan="3">
                                                                                        <asp:TextBox ID="txtNombres" CssClass="InputTexto" runat="server" MaxLength="120"
                                                                                            Width="250px" Enabled="False" TabIndex="6"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvNombres" runat="server" Text="*" ErrorMessage="Nombres"
                                                                                            ControlToValidate="txtNombres" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblApellidoPaterno" CssClass="normal" runat="server">Apellido Paterno:</asp:Label></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtApellidoPaterno" CssClass="InputTexto" runat="server" MaxLength="30"
                                                                                            Width="120px" Enabled="False" TabIndex="7"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvApellidoPaterno" runat="server" Text="*" ErrorMessage="Apellido Paterno"
                                                                                            ControlToValidate="txtApellidoPaterno" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="lblApellidoMaterno" CssClass="normal" runat="server">Apellido Materno:</asp:Label></td>
                                                                                    <td valign="top">
                                                                                        <asp:TextBox ID="txtApellidoMaterno" CssClass="InputTexto" runat="server" MaxLength="30"
                                                                                            Width="120px" Enabled="False" TabIndex="10"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvApellidoMaterno" runat="server" Text="*" ErrorMessage="Apellido Materno"
                                                                                            ControlToValidate="txtApellidoMaterno" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTipoDocumentoIdentidad" CssClass="normal" runat="server">Tipo Doc. Identidad:</asp:Label></td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlTipoDocumentoIdentidad" CssClass="InputTexto" runat="server"
                                                                                            AutoPostBack="False" Enabled="False" TabIndex="11" Width="96px">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="rfvTipoDocumentoIdentidad" runat="server" Text="*"
                                                                                            ErrorMessage="Tipo de Documento de Identidad" ControlToValidate="ddlTipoDocumentoIdentidad"
                                                                                            InitialValue="%%" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <asp:Label ID="lblNumeroDocumentoIdentidad" CssClass="normal" runat="server">Doc. Identidad:</asp:Label></td>
                                                                                    <td valign="top">
                                                                                        <ew:NumericBox ID="nbNumeroDocumetoIdentidad" CssClass="InputTexto" runat="server"
                                                                                        MaxLength="20" Width="100px" Enabled="False" TabIndex="12" RealNumber="False"></ew:NumericBox>
                                                                                        <asp:RequiredFieldValidator ID="rfvNumeroDocumetoIdentidad" runat="server" Text="*"
                                                                                        ErrorMessage="Documento de Identidad" ControlToValidate="nbNumeroDocumetoIdentidad" ValidationGroup="DatosCliente"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTelefonoReferencia" CssClass="normal" runat="server">Teléfono Referencia:</asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <ew:NumericBox ID="nbTelefonoReferencia" TabIndex="13" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="7" Width="100px" RealNumber="False"></ew:NumericBox></td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <cc1:TabPanel ID="TabPanel2" runat="server">
                                                                <HeaderTemplate>
                                                                    Datos Contacto</HeaderTemplate>
                                                                <ContentTemplate>
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTelefonoContacto" CssClass="normal" runat="server">Teléfono de Contacto</asp:Label></td>
                                                                                    <td>
                                                                                        <ew:NumericBox ID="nbTelefonoContacto" TabIndex="14" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="7" Width="100px" RealNumber="False"></ew:NumericBox>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 17px">
                                                                                        <asp:Label ID="lblPersonaContacto" CssClass="normal" runat="server">Persona de Contacto</asp:Label></td>
                                                                                    <td style="height: 17px">
                                                                                        <asp:TextBox ID="txtPersonaContacto" TabIndex="15" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="20" Width="250px"></asp:TextBox></td>
                                                                                    <td style="height: 17px">
                                                                                    </td>
                                                                                    <td style="height: 17px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:Label ID="lblCanalVenta" CssClass="normal" runat="server">Canal de venta</asp:Label></td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:DropDownList ID="ddlCanalVenta" TabIndex="16" CssClass="InputTexto" runat="server"
                                                                                            Width="250px" AutoPostBack="False">
                                                                                        </asp:DropDownList></td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:Label ID="lblPaquete" CssClass="normal" runat="server">Paquete</asp:Label></td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:DropDownList ID="ddlPaquete" TabIndex="17" CssClass="InputTexto" runat="server"
                                                                                            Width="250px" AutoPostBack="False">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="rfvPaquete" runat="server" Text="*" ErrorMessage="Paquete"
                                                                                            ControlToValidate="ddlPaquete" InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>                                                                                        
                                                                                       </td>
                                                                                </tr>
                                                                                 <tr>
                                                                                   <td height="23" style="height: 23px">
                                                                                        <asp:Label ID="lblSegmento" CssClass="normal" runat="server">Segmento</asp:Label></td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:DropDownList ID="ddlSegmento" TabIndex="17" CssClass="InputTexto" runat="server"
                                                                                            Width="250px" AutoPostBack="False">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="rfvSegmento" runat="server" Text="*" ErrorMessage="Tipo de Cliente"
                                                                                            ControlToValidate="ddlSegmento" InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:Label ID="lblSubSegmento" CssClass="normal" runat="server">Sub Segmento</asp:Label></td>
                                                                                    <td height="23" style="height: 23px">
                                                                                        <asp:DropDownList ID="ddlSubSegmento" TabIndex="17" CssClass="InputTexto" runat="server"
                                                                                            Width="250px" AutoPostBack="False">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="rfvSubSegmento" runat="server" Text="*" ErrorMessage="Tipo de Cliente"
                                                                                            ControlToValidate="ddlSubSegmento" InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblCUC" CssClass="normal" runat="server">C.U.C.:</asp:Label></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtCUC" TabIndex="18" CssClass="InputTexto" runat="server" MaxLength="9"
                                                                                            Width="100px"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblClienteAtis" CssClass="normal" runat="server">Cliente ATIS:</asp:Label></td>
                                                                                    <td>
                                                                                        <ew:NumericBox ID="nbClienteAtis" TabIndex="19" CssClass="InputTexto" runat="server"
                                                                                            MaxLength="9" Width="100px" RealNumber="False"></ew:NumericBox></td>
                                                                                </tr>
                                                                            </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <cc1:TabPanel ID="TabPanel3" runat="server">
                                                                <HeaderTemplate>
                                                                    Datos Instalación</HeaderTemplate>
                                                                <ContentTemplate>
                                                                <asp:UpdatePanel ID="UpdatePanelDatosInstalacion" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblNombreViaInstalacion" CssClass="normal" runat="server">Nombre Via de Instalación:</asp:Label></td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlTipoViaInstalacion" TabIndex="20" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="False">
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtNombreViaInstalacion" TabIndex="21" CssClass="InputTexto"
                                                                                    runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvNombreViaInstalacion" runat="server" Text="*"
                                                                                    ErrorMessage="Nombre Vía de Instalación" ControlToValidate="txtNombreViaInstalacion" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblNumeroViaInstalacion" CssClass="normal" runat="server">Número Via de Instalación:</asp:Label></td>
                                                                            <td>
                                                                                <ew:NumericBox ID="txtNumeroViaInstalacion" TabIndex="22" CssClass="InputTexto" runat="server">
                                                                                </ew:NumericBox>
                                                                                <asp:RequiredFieldValidator ID="rfvNumeroViaInstalacion" runat="server" Text="*"
                                                                                    ErrorMessage="Número de la Vía de Instalación" ControlToValidate="txtNumeroViaInstalacion" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="21" style="height: 21px">
                                                                                <asp:Label ID="lblDepartamentoInstalacion" CssClass="normal" runat="server">Departamento Instalación:</asp:Label></td>
                                                                            <td height="21" style="height: 21px">
                                                                                <asp:DropDownList ID="ddlDepartamentoInstalacion" TabIndex="23" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDepartamentoInstalacion" runat="server" Text="*"
                                                                                    ErrorMessage="Departamento de Instalación" ControlToValidate="ddlDepartamentoInstalacion"
                                                                                    InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td height="21" style="height: 21px">
                                                                                <asp:Label ID="lblProvinciaInstalacion" CssClass="normal" runat="server">Provincia Instalación:</asp:Label></td>
                                                                            <td height="21" style="height: 21px">
                                                                                <asp:DropDownList ID="ddlProvinciaInstalacion" TabIndex="24" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvProvinciaInstalacion" runat="server" Text="*"
                                                                                    ErrorMessage="Provincia de Instalación" ControlToValidate="ddlProvinciaInstalacion"
                                                                                    InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblDistritoInstalacion" CssClass="normal" runat="server">Distrito Instalación:</asp:Label></td>
                                                                            <td>
                                                                                <asp:DropDownList ID="ddlDistritoInstalacion" TabIndex="25" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="false">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDistritoInstalación" runat="server" Text="*" ErrorMessage="Distrito de Instalación"
                                                                                    ControlToValidate="ddlDistritoInstalacion" InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <cc1:TabPanel ID="TabPanel4" runat="server">
                                                                <HeaderTemplate>
                                                                    Datos Facturación</HeaderTemplate>
                                                                <ContentTemplate>
                                                                 <asp:UpdatePanel ID="UpdatePanelDatosFacturacion" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td width="165">
                                                                                <asp:Label ID="lblNombreViaFacturacion" CssClass="normal" runat="server">Nombre Via de Facturación:</asp:Label></td>
                                                                            <td width="292">
                                                                                <asp:DropDownList ID="ddlTipoViaFacturacion" TabIndex="26" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="False">
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtNombreViaFacturacion" TabIndex="27" CssClass="InputTexto"
                                                                                    runat="server" MaxLength="60" Width="170px"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvNombreViaFacturacion" runat="server" Text="*"
                                                                                    ErrorMessage="Nombre Vía de Instalación" ControlToValidate="txtNombreViaFacturacion" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblNumeroViaFacturacion" CssClass="normal" runat="server">Número Via de Facturación:</asp:Label></td>
                                                                            <td>
                                                                                <ew:NumericBox ID="txtNumeroViaFacturacion" CssClass="InputTexto" runat="server" TabIndex="27" >
                                                                                </ew:NumericBox>
                                                                                <asp:RequiredFieldValidator ID="rfvNumeroViaFacturacion" runat="server" Text="*"
                                                                                    ErrorMessage="Número Vía de Facturación" ControlToValidate="txtNumeroViaFacturacion"
                                                                                    InitialValue="" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 25px">
                                                                                <asp:Label ID="lblDepartamentoFacturacion" CssClass="normal" runat="server">Departamento Facturación:</asp:Label></td>
                                                                            <td style="height: 25px">
                                                                                <asp:DropDownList ID="ddlDepartamentoFacturacion" TabIndex="29" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDepartamentoFacturacion" runat="server" Text="*"
                                                                                    ErrorMessage="Departamento de Facturación" ControlToValidate="ddlDepartamentoFacturacion"
                                                                                    InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="height: 25px">
                                                                                <asp:Label ID="lblProvinciaFacturacion" CssClass="normal" runat="server">Provincia Facturación:</asp:Label></td>
                                                                            <td style="height: 25px">
                                                                                <asp:DropDownList ID="ddlProvinciaFacturacion" TabIndex="30" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="True">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvProvinciaFacturacion" runat="server" Text="*"
                                                                                    ErrorMessage="Provincia de Facturación" ControlToValidate="ddlProvinciaFacturacion"
                                                                                    InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="21">
                                                                                <asp:Label ID="lblDistritoFacturacion" CssClass="normal" runat="server">Distrito Facturación:</asp:Label></td>
                                                                            <td height="21">
                                                                                <asp:DropDownList ID="ddlDistritoFacturacion" TabIndex="31" CssClass="InputTexto"
                                                                                    runat="server" AutoPostBack="False">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="rfvDistritoFacturacion" runat="server" Text="*" ErrorMessage="Distrito de Facturación"
                                                                                    ControlToValidate="ddlDistritoFacturacion" InitialValue="%%" ValidationGroup="DatosPlantilla"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td height="21">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                     </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                            <cc1:TabPanel ID="TabPanel5" runat="server" Enabled="false">
                                                                <HeaderTemplate>
                                                                    Productos Servicios</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table style="width: 100%" border=0>
                                                                        <tr>
                                                                            <td>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" align="center">
                                                                                         <asp:UpdatePanel ID="UpdatePanelGrillaPS" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                            <!--GridPS-->
                                                                                            <asp:GridView ID="gridPS" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
                                                                                                AllowPaging="True" HorizontalAlign="Center" PageSize="10">
                                                                                                <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla"></AlternatingRowStyle>
                                                                                                <RowStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></RowStyle>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Id Cotizacion PR" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdCotizacionPR" CssClass="normal" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField  Visible =false>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdProducto" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="tococ_iIdTip_Ope_Com"  Visible =false>
                                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                                    </asp:BoundField>
                                                                                                    <asp:TemplateField HeaderText="Item">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblNumeroItem" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Incluir">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chkIncluir" runat="server" AutoPostBack="true"></asp:Checkbox>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField  HeaderText="Producto">
                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblProducto" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Operación Comercial">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlOperacionComercial" Enabled=false CssClass="InputTexto" runat="server" Width="100px"></asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Cantidad">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlCantidad" CssClass="InputTexto" runat="server"></asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblRenta" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdDescuento" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblPorcentajeIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMontoIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Renta Con IGV">
                                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblRentaIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="% Dscto">
                                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblPorcentajeDescuento" runat="server"></asp:Label>                                                                                                                        
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Mto Dscto">
                                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMontoDescuento" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Mto Total">
                                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMontoTotal" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Tipo Venta">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlTipoVenta" CssClass="InputTexto" runat="server"></asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Tipo Contrato">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlTipoContrato" CssClass="InputTexto" runat="server"></asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
                                                                                            </asp:GridView>
                                                                                            <asp:Label ID="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                                            </ContentTemplate>
                                                                                         </asp:UpdatePanel>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 19px" align="right"> 
                                                                                            <asp:Button ID="btnModificar" runat="server" CssClass="InputBoton" Text="Modificar" Enabled="false"></asp:Button>
                                                                                            <asp:Button ID="btnProcesar" runat="server" CssClass="InputBoton" Text="Procesar"></asp:Button>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" align="left" border="0">
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                         <asp:UpdatePanel ID="UpdatePanelGrillaSubPS" runat="server" UpdateMode="Conditional">
                                                                                         <ContentTemplate>
                                                                                            <asp:GridView ID="gridSubPS" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                                                AllowSorting="True" AllowPaging="false" HorizontalAlign="Center" PageSize="10" Visible="true">
                                                                                                <FooterStyle CssClass="FooterGrilla"></FooterStyle>
                                                                                                <AlternatingRowStyle CssClass="AlternateItemGrilla"></AlternatingRowStyle>
                                                                                                <RowStyle HorizontalAlign="Center" CssClass="ItemGrilla" VerticalAlign="Top"></RowStyle>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla" VerticalAlign="Top"></HeaderStyle>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Id Cotizacion PR" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdCotizacionPR" CssClass="normal" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Id Cotizacion Sub Producto" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdCotizacionSubPR" CssClass="normal" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Id Producto" Visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblIdProducto" CssClass="normal" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:BoundField DataField="prsec_vDescripcion" HeaderText="Tipo Producto Servicio">
                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                    </asp:BoundField>
                                                                                                    <asp:TemplateField HeaderText="C&#243;digo P/S">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblCodigoPS" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Producto/Servicio">
                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DropDownList ID="ddlProductoServicio" CssClass="InputTexto" runat="server" AutoPostBack="true"></asp:DropDownList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblRenta" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblPorcentajeIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField visible="false">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblMontoIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Renta Con IGV">
                                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblRentaIGV" runat="server"></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Nro Inscripci&#243;n">
                                                                                                         <ItemTemplate>
                                                                                                            <asp:TextBox ID="txtNumeroInscripcion" CssClass="InputTexto" runat="server"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Nro Tel&#233;fono">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:TextBox ID="lblNumeroTelefono" CssClass="InputTexto" runat="server"></asp:TextBox>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Modificar" Visible="false">
                                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton ID="imgbtnModificar" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Modificar.gif"
                                                                                                                CommandName="GrillaEventoModificar"></asp:ImageButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Descuentos" Visible="false">
                                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton ID="imgbtnMostrarDescuentos" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Ejecutar.gif"
                                                                                                                CommandName="GrillaEventoModificar"></asp:ImageButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Eliminar" Visible="false">
                                                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:ImageButton ID="imgbtnEliminar" runat="server" CausesValidation="False" ImageUrl="../../Images/Body/Icons/Eliminar.gif"
                                                                                                                CommandName="GrillaEventoModificar"></asp:ImageButton>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
                                                                                            </asp:GridView>
                                                                                            <asp:Label ID="Label1" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></td>
                                                                                        </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 19px" align="right">
                                                                                            <asp:Button ID="btnAgregar" runat="server" CssClass="InputBoton" Text="Agregar" Visible="false"></asp:Button>
                                                                                            <asp:Button ID="btnCalcular" runat="server" CssClass="InputBoton" Text="Calcular" Visible="false"></asp:Button>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Panel ID="pnlVentanaSeleccionarSubProducto" CssClass="modalPopup" runat="server" Visible="false">
                                                                                                <asp:UpdatePanel ID="UpdatePanelSubProducto" runat="server" UpdateMode="Conditional">
                                                                                                    <ContentTemplate>
                                                                                                        <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProducto" runat="server" CssClass="normal">Producto:</asp:Label>
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlProducto" runat="server" AutoPostBack="true">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblSubProducto" runat="server" CssClass="normal">Sub Producto:</asp:Label>
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlSubProducto" runat="server">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan=2 align="center">
                                                                                                                <asp:Button ID="btnAceptar" runat="server" CssClass="InputBoton" Text="Aceptar" />
                                                                                                                <asp:Button ID="btnCancelar" runat="server" CssClass="InputBoton" Text="Cancelar" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </ContentTemplate>
                                                                                                </asp:UpdatePanel>
                                                                                            </asp:Panel>
                                                                                            <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                                                                                            TargetControlID="btnAgregar"
                                                                                            PopupControlID="pnlVentanaSeleccionarSubProducto"
                                                                                            BackgroundCssClass="modalBackground"
                                                                                            DropShadow="true" >
                                                                                            </cc1:ModalPopupExtender>
                                                                                        </td>
                                                                                    </tr>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </cc1:TabPanel>
                                                        </cc1:TabContainer>
                                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Debe ingresar los campos:" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                           
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                                            <ProgressTemplate>
                                                        <uc3:AspNetAjaxProgresoProceso ID="AspNetAjaxProgresoProceso1" runat="server" />
                                                            </ProgressTemplate>
                                                        </asp:UpdateProgress>
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 17px">
                                                        &nbsp; &nbsp;&nbsp;</td>
                                                </tr>
                                                <tr style="width: 100%; height: 60px" valign="top">
                                                    <!--Region del Pie de Pagina de PdT -->
                                                    <td id="cPiePagina">
                                                        &nbsp;&nbsp;
                                                        <uc2:cuPiePagina ID="CuPiePagina1" runat="server" />
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