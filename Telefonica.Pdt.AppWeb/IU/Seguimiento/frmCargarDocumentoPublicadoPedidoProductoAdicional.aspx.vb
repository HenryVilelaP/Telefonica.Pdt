Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.AppWeb

Partial Class IU_Seguimiento_frmCargarDocumentoPublicadoPedidoProductoAdicional
    Inherits WebPaginaBase

    Private Const PrefigoDocumentoArchivo As String = "PRD-"

    Private Sub LlenarJScript()
        Me.btnCerrar.Attributes.Add(ConstantesWeb.JsEventoOnClick, "window.close(); return false;")
    End Sub

    Private Sub LlenarLista()
        Dim opdt_pedido_prd_docBL As New pdt_pedido_prd_docBL
        Dim dt As DataTable = opdt_pedido_prd_docBL.Listar_DocumentoPorPedidoProductoTipoDocumetoAdicional(Me.IdPedidoProducto())
        Me.lstTipoDocumentoAdicional.DataSource = dt
        Me.lstTipoDocumentoAdicional.DataTextField = "vtdoc_vDescripcion"
        Me.lstTipoDocumentoAdicional.DataValueField = "vtdoc_iIdTip_Doc"
        Me.lstTipoDocumentoAdicional.DataBind()

    End Sub

    Private Sub GuardarDocumento()
        If (Me.FileUploadArchivo.HasFile) Then
            Dim IdTipoDocumento As Integer = Convert.ToInt32(Me.lstTipoDocumentoAdicional.SelectedValue)
            Dim Data() As Byte = HelperWeb.ArchivoRetornarBuffer(Me.FileUploadArchivo)
            Dim NombreDigitalArchivo As String = HelperWeb.ArchivoRetornarNombre(Me.FileUploadArchivo)
            Dim strRutaFileServer As String = System.Configuration.ConfigurationManager.AppSettings(ConstantesWeb.FileServerPDT_GdC)
            strRutaFileServer = strRutaFileServer + NombreDigitalArchivo

            Dim opdt_pedido_prd_docBL As New pdt_pedido_prd_docBL
            Dim retorno As Integer = opdt_pedido_prd_docBL.InsertarPublicarDocumentoAdicional(Me.IdPedidoProducto(), IdTipoDocumento, strRutaFileServer, Data, Me.PAG_IdUsuario_InicioSesion)

            If (retorno > 0) Then
                Dim Js As String = "window.opener.ActulizarListaDocumentPublicPedido(); " + ConstantesWeb.SaltoLinea
                Js += HelperWeb.JsMensajeAlert("El documento se publico con exito..") + ConstantesWeb.SaltoLinea
                Js += "window.close();"
                Me.ltlMensaje.Text = Js
            End If

        Else
            Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Falta selecionar el archivo")
        End If

    End Sub

    Private Function IdPedidoProducto() As Integer
        Dim retorno As Integer = 3 'Convert.ToInt32(Me.Page.Request.Params(Enumeradores.Col_PEDIDO_PRD_DOC.pdppc_iIdPedido_Prd.ToString()))
        Return retorno
    End Function

    Private Function ValidarCampo() As Boolean
        If ((Me.lstTipoDocumentoAdicional.Items.Count = 0) OrElse (Me.lstTipoDocumentoAdicional.SelectedIndex < 0)) Then
            Me.ltlMensaje.Text = HelperWeb.MensajeAlert("Falta seleccionar un tipo de documento")
            Return False
        End If

        Return True

    End Function

    Protected Sub brnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles brnGrabar.Click
        Try
            If (Me.ValidarCampo()) Then
                Me.GuardarDocumento()
            End If
        Catch ex As Exception
            Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        End Try

    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not (Me.Page.IsPostBack) Then
                Me.LlenarJScript()
                Me.LlenarLista()
            End If
        Catch ex As Exception
            Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        End Try
    End Sub
End Class
