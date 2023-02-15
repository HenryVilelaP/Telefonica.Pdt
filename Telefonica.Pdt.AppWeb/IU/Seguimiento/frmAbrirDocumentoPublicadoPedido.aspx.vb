Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.AppWeb

Partial Class IU_Seguimiento_frmAbrirDocumentoPublicadoPedido
    Inherits WebPaginaBase

    Protected Sub btnAbrirDocumento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAbrirDocumento.Click
        Try
            Me.AbrirDocumento()
        Catch ex As Exception
            Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        End Try
    End Sub

    Private Function NombreDigitalDocumentoPedidoDocumento() As String
        Dim retorno As String = Convert.ToString(Me.Page.Request.Params(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString()))
        Return retorno
    End Function

    Private Sub AbrirDocumento()
        Dim strRutaFileServer As String = System.Configuration.ConfigurationManager.AppSettings(ConstantesWeb.FileServerPDT_GdC)
        Dim strNombreArchivo As String = Me.NombreDigitalDocumentoPedidoDocumento()
        strRutaFileServer = strRutaFileServer + strNombreArchivo
        HelperWeb.AbrirArchivoServer(Me.Page, strRutaFileServer, strNombreArchivo)
    End Sub

    Private Sub RegistrarJavaScript()
        Me.btnAbrirDocumento.Width = Unit.Pixel(0)
        Me.btnAbrirDocumento.Height = Unit.Pixel(0)
        Const NombreFuncionCliente As String = "AbrirDocumentPublicPedido()"

        Dim Js As String = "    function " + NombreFuncionCliente + ConstantesWeb.SaltoLinea
        Js += "    {" + ConstantesWeb.SaltoLinea
        Js += "         __doPostBack('" + Me.btnAbrirDocumento.ClientID + "','');" + ConstantesWeb.SaltoLinea
        Js += "    }" + ConstantesWeb.SaltoLinea
        HelperWeb.RegistrarJavaScriptEnHead(Me.Page, "AbrirDocumentPublicPedido", Js)

        Dim JsCargar As String = NombreFuncionCliente + ConstantesWeb.SaltoLinea
        JsCargar += "setTimeout(""window.close();"",""8000"")"

        Me.ltlMensaje.Text = JsCargar

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.RegistrarJavaScript()
    End Sub

End Class
