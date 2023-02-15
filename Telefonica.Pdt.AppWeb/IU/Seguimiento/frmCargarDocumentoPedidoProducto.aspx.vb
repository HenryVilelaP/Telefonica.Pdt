Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.AppWeb
Imports Telefonica.Pdt.Entities

Partial Class IU_Seguimiento_frmCargarDocumentoPedidoProducto
    Inherits WebPaginaBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Me.Page.IsPostBack) Then
            Me.LlenarJScript()
            Me.LlenarDatos()
        End If
    End Sub

    Private Sub LlenarDatos()
        Dim IdTipoDocumento As Integer = Me.IdTipoDocumento()
        Dim opdt_tabla_tablasBL As New pdt_tabla_tablasBL
        Dim oBE As TABLA_TABLAS = opdt_tabla_tablasBL.Detalle(Convert.ToInt32(Enumeradores.Cabecera_Tabla_Tablas.Tab_Lista_Documentos), IdTipoDocumento)
        Me.lblDescripcionTipoDocumento.Text = oBE.Tablc_vDescripcion
    End Sub

    Private Sub LlenarJScript()
        Me.btnCerrar.Attributes.Add(ConstantesWeb.JsEventoOnClick, "window.close(); return false;")
    End Sub

    Private Sub GuardarDocumento()
        If (Me.FileUploadArchivo.HasFile) Then
            Dim Data() As Byte = HelperWeb.ArchivoRetornarBuffer(Me.FileUploadArchivo)
            Dim NombreDigitalArchivo As String = HelperWeb.ArchivoRetornarNombre(Me.FileUploadArchivo)
            Dim strRutaFileServer As String = System.Configuration.ConfigurationManager.AppSettings(ConstantesWeb.FileServerPDT_GdC)
            strRutaFileServer = strRutaFileServer + NombreDigitalArchivo

            Dim opdt_pedido_prd_docBL As New pdt_pedido_prd_docBL
            Dim retorno As Integer = opdt_pedido_prd_docBL.ModificarPublicarDocumento(Me.IdPedidoDocumento(), strRutaFileServer, Data, Me.PAG_IdUsuario_InicioSesion)

            If (retorno > 0) Then
                Dim Js As String = "window.opener.ActulizarListaDocumentPublicPedido(); " + ConstantesWeb.SaltoLinea
                Js += HelperWeb.JsMensajeAlert("El documento se publico con exito..") + ConstantesWeb.SaltoLinea
                Js += "window.close();"
                Me.ltlMensaje.Text = Js
            End If

        End If

    End Sub

    Private Function IdPedidoDocumento() As Integer
        Dim retorno As Integer = Convert.ToInt32(Me.Page.Request.Params(Enumeradores.Col_PEDIDO_PRD_DOC.ppdoc_iIdPedido_Doc.ToString()))
        Return retorno
    End Function

    Private Function IdTipoDocumento() As Integer
        Dim retorno As Integer = Convert.ToInt32(Me.Page.Request.Params(Enumeradores.Col_PEDIDO_PRD_DOC.vtdoc_iIdTip_Doc.ToString()))
        Return retorno
    End Function

    'Private Function NombreDocumentoPublicar(ByVal ExtencionDocumento As String) As String
    '    Dim strNombre As String = Me.IdPedidoDocumento.ToString("000000000")
    '    strNombre = PrefigoDocumentoArchivo + strNombre
    '    If (ExtencionDocumento.Trim().Length > 0) Then
    '        strNombre += ExtencionDocumento
    '    End If
    '    Return strNombre
    'End Function

    Protected Sub brnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles brnGrabar.Click
        Try
            Me.GuardarDocumento()
        Catch ex As Exception
            Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        End Try

    End Sub

End Class
