<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmGeneraExcel.aspx.vb"
    Inherits="Telefonica.Pdt.AppWeb.frmGeneraExcel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PdT</title>
    <link href="../../style/Style.css" rel="stylesheet" />
    <link href="../../Style/Estilos.css" type="text/css" rel="stylesheet" />

    <script language="javascript" src="../../Script/jscript.js"></script>

</head>
<body bottommargin="0" topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <asp:ImageButton ID="imgbExportarExcel" runat="server" ImageUrl="~/Images/imgWebPdt/ico_XLS.jpg"
            Height="17px" Width="17px" />
    </form>
     <script>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
    </script>
</body>
</html>
