<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmMain.aspx.vb" Inherits="IU_frmMain" %>

<%@ Register Src="../UserControls/cuCabecera.ascx" TagName="cuCabecera" TagPrefix="uc1" %>
<%@ Register Src="../UserControls/cuPiePagina.ascx" TagName="cuPiePagina" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PDT Pagina Principal</title>
    <link href="../Style/Style.css"rel="stylesheet" />
    <link href="../style/Estilos.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/jscript" src="../Script/jscript.js"></script>
</head>
<body style="margin-bottom: 0; margin-left: 0; margin-right: 0; margin-top: 0">
    <form id="form1" runat="server">
        <table id="tGeneral" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
            text-align: center">
            <tr>
                <td>
                    <table id="tWFijo" border="0" cellpadding="0" cellspacing="0" style="width: 1002px;
                        text-align: center">
                        <tr>
                            <td style="width: 5px">
                            </td>
                            <td>
                                <table id="tPrincipal" border="0" cellpadding="0" cellspacing="0" style="width: 100%;
                                    text-align: center">
                                    <tr style="height: 90px; vertical-align:top">
                                        <!--Region de la Cabecera de PdT -->
                                        <td id="cCabecera">
                                            <uc1:cuCabecera ID="CuCabecera1" runat="server" />
                                            
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 428px; vertical-align:top">
                                        <!--Region de Trabajo del Desarrollador -->
                                        <td style="height: 424px">
                                            <table id="tContenido" border="0" cellpadding="1" cellspacing="1" style="width:100%; text-align:left">
                                                <tr>
                                                    <td>
                                                        </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 60px; vertical-align:top">
                                        <!--Region del Pie de Pagina de PdT -->
                                        <td id="cPiePagina">
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
    </form>
</body>
</html>
