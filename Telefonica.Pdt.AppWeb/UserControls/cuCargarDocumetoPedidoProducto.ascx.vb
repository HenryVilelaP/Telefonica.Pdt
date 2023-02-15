Imports System
Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common


Namespace Telefonica.Pdt.AppWeb
    Partial Class UserControls_cuCargarDocumetoPedidoProducto
        Inherits System.Web.UI.UserControl

#Region "Constantes"
        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ControlImgCheck As String = "imgChequear"
        Private Const ControlImgDocumento As String = "imgDocumento"
        Private Const ControlLbtnDesc_TipoDocumento As String = "lbtnDesc_TipoDocumento"
        Private Const ControlLBlEtiqueta_TipoDocumento As String = "lblEtiqueta_TipoDocumento"
        Private Const ControlDescLblPublicar As String = "lblDescPublicar"
        Private Const ControlLbtnPublicar As String = "lbtnPublicar"

        Private Const ControlIbtnRecibidoFisicamente As String = "imgRecibidoFisicamente"
        Private Const ControlIbtnAprobarDocumento As String = "imgAprobarDocumento"
        Private Const ControlIbtnRecharDocumento As String = "ibtnRechar"
        Private Const CmdNameMarcarRecibidoFicamente As String = "cmdNameMarcarRecibidoFicamente"
        Private Const CmdNameAprobarDocumento As String = "cmdNameAprobarDocumento"
        Private Const CmdNameRechazarDocumento As String = "cmdNameRechazarDocumento"

#End Region

        Public Sub LlenarGrillaDocumentos(ByVal IdPedidoProducto As Integer)
            Try
                Me.JsAbrirFormularioPublicarArchivoAdicional(IdPedidoProducto)
                Me.LlenarGrilla(IdPedidoProducto)

            Catch ex As Exception
                Throw ex
            Finally
                Me.UpdatePanelDocumenento.Update()
            End Try

        End Sub

        Private Sub LlenarJScript()

        End Sub

        Private Sub RegistrarJavaScript()
            Me.btnActualizarGrilla.Width = Unit.Pixel(0)
            Me.btnActualizarGrilla.Height = Unit.Pixel(0)

            Dim Js As String = "    function ActulizarListaDocumentPublicPedido()" + ConstantesWeb.SaltoLinea
            Js += "    {" + ConstantesWeb.SaltoLinea
            Js += "         __doPostBack('" + Me.btnActualizarGrilla.ClientID + "','');" + ConstantesWeb.SaltoLinea
            Js += "    }" + ConstantesWeb.SaltoLinea
            HelperWeb.RegistrarJavaScriptEnHead(Me.Page, "ActulizarDocumentoPedidoPublic", Js)

        End Sub

        Private Sub LlenarGrilla(ByVal IdPedidoProducto As Integer)
            Dim indicePagina As Integer = 0
            Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
            Me.btnDocumentoAdicional.Visible = True

            Dim dt As DataTable = Me.ListarDataLlenarGrilla(IdPedidoProducto)

            If Not (dt Is Nothing) Then
                Me.grid.DataSource = dt
                indicePagina = HelperWeb.ValidarIndicePaginacionGrilla(dt.Rows.Count, Me.grid.PageSize, indicePagina)
                Me.grid.CurrentPageIndex = indicePagina
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + dt.Rows.Count.ToString()
                Me.lblRegistrosEncontrados.Visible = True
                Me.lblResultado.Visible = False
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.lblResultado.Visible = True
                Me.lblRegistrosEncontrados.Visible = False
            End If

            Try
                Me.grid.DataBind()
            Catch ex As Exception
                Me.grid.CurrentPageIndex = 0
                Me.grid.DataBind()
                Me.btnDocumentoAdicional.Visible = False
                Throw ex
            End Try
        End Sub

        Private Sub LlenarGrilla()
            Me.LlenarGrilla(Convert.ToInt32(Me.hIdPedidoProducto.Value))
        End Sub

        Private Sub AccionAprobarDocumento(ByVal iIdPedido_Doc As Integer)
            Dim EstadoDocumento As Integer = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Aprobado)
            Me.AccionCambiarEstadoDocumento(iIdPedido_Doc, EstadoDocumento)

        End Sub

        Private Sub AccionRechazarDocumento(ByVal iIdPedido_Doc As Integer)
            Dim EstadoDocumento As Integer = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Rechazado)
            Me.AccionCambiarEstadoDocumento(iIdPedido_Doc, EstadoDocumento)

        End Sub

        Private Sub AccionCambiarEstadoDocumento(ByVal iIdPedido_Doc As Integer, ByVal iIdEstado_Doc As Integer)
            Dim iIdUsuario_Modifica As Integer = Me.CuIdUsuarioInicioSession
            Dim opdt_pedido_prd_docBL As New pdt_pedido_prd_docBL
            Dim retorno As Integer = opdt_pedido_prd_docBL.ModificarEstadoDocumento(iIdPedido_Doc, iIdEstado_Doc, iIdUsuario_Modifica)
            If (retorno > 0) Then
                NetAjax.JsMensajeAlert(Me.Page, "La acción se realizo con exito")
            End If

        End Sub

        Private Function ListarDataLlenarGrilla(ByVal IdPedidoProducto As Integer) As DataTable
            Dim opdt_pedido_prd_docBL As New pdt_pedido_prd_docBL
            Return opdt_pedido_prd_docBL.Listar_DocumentoPorPedidoProducto(IdPedidoProducto)
        End Function


        Private Sub JsAbrirFormularioPublicarArchivoAdicional(ByVal iIdPedido_Producto As Integer)
            Dim strUrl As String = "frmCargarDocumentoPublicadoPedidoProductoAdicional.aspx?"
            strUrl += Enumeradores.Col_PEDIDO_PRD_DOC.pdppc_iIdPedido_Prd.ToString() + ConstantesWeb.SignoIGUAL + iIdPedido_Producto.ToString()
            strUrl = HelperWeb.AbrirVentanaWinPopup(strUrl, "PUBLICARDOC", 740, 450, 20, 20, False, False)

            Me.btnDocumentoAdicional.Attributes.Add(ConstantesWeb.JsEventoOnClick, strUrl)

        End Sub

        Private Function JsAbrirFormularioPublicarArchivo(ByVal iIdPedido_Doc As Integer, ByVal IdTipoDocumento As Integer) As String
            Dim strUrl As String = "frmCargarDocumentoPedidoProducto.aspx?"
            strUrl += Enumeradores.Col_PEDIDO_PRD_DOC.ppdoc_iIdPedido_Doc.ToString() + ConstantesWeb.SignoIGUAL + iIdPedido_Doc.ToString()
            strUrl += ConstantesWeb.SignoAMPERSON + Enumeradores.Col_PEDIDO_PRD_DOC.vtdoc_iIdTip_Doc.ToString() + ConstantesWeb.SignoIGUAL + IdTipoDocumento.ToString()
            strUrl = HelperWeb.AbrirVentanaWinPopup(strUrl, "PUBLICARDOC", 470, 220, 50, 200, False, False)

            Return strUrl
        End Function

        Private Function JsAbrirAbrirDocumentoPublicado(ByVal vNombreDocumentoDigital As String) As String
            Dim strUrl As String = "frmAbrirDocumentoPublicadoPedido.aspx?"
            strUrl += Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString() + ConstantesWeb.SignoIGUAL + vNombreDocumentoDigital
            strUrl = HelperWeb.AbrirVentanaWinPopup(strUrl, "ABRIRDOC", 320, 20, 0, 0, False, False)

            Return strUrl
        End Function

        Private Sub ImagenTipoDocumento(ByRef oImagen As Image, ByVal NombreDocumento As String)
            oImagen.Width = Unit.Pixel(17)
            oImagen.Height = Unit.Pixel(17)
            Dim str() As String = NombreDocumento.Split(".")
            Dim ExtencionDocumento As String = ""
            If (str.Length > 0) Then
                Dim iUltimo As Integer = (str.Length - 1)
                ExtencionDocumento = str(iUltimo)
            End If

            Select Case ExtencionDocumento.ToUpper()
                Case "DOC"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_DOC.bmp"
                Case "PDF"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_PDF.bmp"
                Case "JPG"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_aspa.bmp"
                Case "XLS"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_XLS.jpg"
                Case "PPT"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_PPT.bmp"
                Case "PPS"
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_PPS.bmp"
                Case Else
                    oImagen.ImageUrl = "~/Images/imgWebPdt/ico_OTRO.bmp"
            End Select
            oImagen.Visible = True
        End Sub

        Private Function CuIdUsuarioInicioSession() As Integer
            Dim oWebPaginaBase As New WebPaginaBase
            Dim IdUsuario As Integer = oWebPaginaBase.PAG_IdUsuario_InicioSesion
            Return IdUsuario

        End Function

        Protected Sub grid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles grid.ItemCommand
            Try
                If (e.Item.ItemType = ListItemType.Header) Then

                ElseIf ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then
                    Dim idRegistro As Integer = Convert.ToInt32(e.Item.Cells(1).Text)

                    Select Case e.CommandName
                        Case CmdNameMarcarRecibidoFicamente
                            Me.AccionAprobarDocumento(idRegistro)
                            Exit Select
                        Case CmdNameAprobarDocumento
                            Me.AccionAprobarDocumento(idRegistro)
                            Exit Select
                        Case CmdNameRechazarDocumento
                            Me.AccionRechazarDocumento(idRegistro)
                            Exit Select
                    End Select

                    Me.LlenarGrilla()
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanelDocumenento.Update()
            End Try

        End Sub


        Protected Sub grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemDataBound
            If (e.Item.ItemType = ListItemType.Header) Then

            ElseIf ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Item.Height = Unit.Pixel(20)
                e.Item.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_PEDIDO_PRD_DOC.ppdoc_iIdPedido_Doc.ToString()))
                Dim IdEstadoDocumento As Integer = Convert.ToInt32(dr(Enumeradores.Col_PEDIDO_PRD_DOC.vedoc_iIdEstado_Doc.ToString()))
                Dim IdDocumentoPublicado As Integer = Convert.ToInt32(dr(Enumeradores.Col_PEDIDO_PRD_DOC.ppdoc_iInd_Doc_Publicado.ToString()))
                Dim IdTipoDocumento As Integer = Convert.ToInt32(dr(Enumeradores.Col_PEDIDO_PRD_DOC.vtdoc_iIdTip_Doc.ToString()))

                Dim strTipoDocumento As String = Convert.ToString(dr("vtdoc_vDescripcion"))
                Dim lblTipoDocumento As Label = CType(e.Item.FindControl(ControlLBlEtiqueta_TipoDocumento), Label)
                lblTipoDocumento.Text = strTipoDocumento

                Dim img As Image = Nothing
                If (IdEstadoDocumento = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Publicado)) Then
                    lblTipoDocumento.Visible = False

                    Dim lbtn As LinkButton = CType(e.Item.FindControl(ControlLbtnDesc_TipoDocumento), LinkButton)
                    lbtn.Text = strTipoDocumento
                    lbtn.Attributes.Add(ConstantesWeb.JsEventoOnClick, Me.JsAbrirAbrirDocumentoPublicado(Convert.ToString(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString()))))
                    lbtn.CausesValidation = False
                    lbtn.Visible = True

                    img = CType(e.Item.FindControl(ControlImgDocumento), Image)
                    Me.ImagenTipoDocumento(img, Convert.ToString(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString())))

                    Dim lbl As Label = CType(e.Item.FindControl(ControlDescLblPublicar), System.Web.UI.WebControls.Label)
                    lbl.Text = Convert.ToString(dr("Desc_iInd_Doc_Publicado"))

                    lbl.Visible = True


                    Dim ibtn As ImageButton = Nothing

                    ibtn = New ImageButton
                    ibtn = CType(e.Item.FindControl(ControlIbtnAprobarDocumento), ImageButton)
                    ibtn.ToolTip = "Aprobar documento..."
                    ibtn.Visible = True
                    ibtn.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea aprobar el Documento?"))

                    ibtn = New ImageButton
                    ibtn = CType(e.Item.FindControl(ControlIbtnRecharDocumento), ImageButton)
                    ibtn.ToolTip = "Recharzar documento..."
                    ibtn.Visible = True
                    ibtn.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea rechazar el documento?"))

                ElseIf (IdEstadoDocumento = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Aprobado)) Then
                    img = CType(e.Item.FindControl(ControlImgCheck), Image)

                    If (IdDocumentoPublicado = 1) Then
                        lblTipoDocumento.Visible = False

                        img.ImageUrl = "~/Images/imgWebPdt/ico_check.gif"
                        img.ToolTip = "Documento aprobado"

                        Dim lbtn As LinkButton = CType(e.Item.FindControl(ControlLbtnDesc_TipoDocumento), LinkButton)
                        lbtn.Text = strTipoDocumento
                        lbtn.Attributes.Add(ConstantesWeb.JsEventoOnClick, Me.JsAbrirAbrirDocumentoPublicado(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString())))
                        lbtn.CausesValidation = False
                        lbtn.Visible = True

                        Dim img2 As Image = CType(e.Item.FindControl(ControlImgDocumento), Image)
                        Me.ImagenTipoDocumento(img2, Convert.ToString(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString())))

                        Dim lbl As Label = CType(e.Item.FindControl(ControlDescLblPublicar), System.Web.UI.WebControls.Label)
                        lbl.Text = Convert.ToString(dr("Desc_iInd_Doc_Publicado"))
                        lbl.Visible = True

                    Else
                        img.ImageUrl = "~/Images/imgWebPdt/ico_check2.gif"
                        img.ToolTip = "Documento recibido fisicamente"

                        Dim lbl As Label = CType(e.Item.FindControl(ControlDescLblPublicar), System.Web.UI.WebControls.Label)
                        lbl.Text = "NO"
                        lbl.Visible = True

                    End If
                    img.Visible = True


                ElseIf (IdEstadoDocumento = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Rechazado)) Then
                    img = CType(e.Item.FindControl(ControlImgCheck), Image)
                    img.ImageUrl = "~/Images/imgWebPdt/ico_aspa.gif"
                    img.ToolTip = "Documento rechazado"
                    img.Visible = True

                    If (IdDocumentoPublicado = 1) Then
                        lblTipoDocumento.Visible = False

                        Dim lbtn As LinkButton = CType(e.Item.FindControl(ControlLbtnPublicar), LinkButton)
                        lbtn.ToolTip = "Publicar documento..."
                        lbtn.Attributes.Add(ConstantesWeb.JsEventoOnClick.ToString(), Me.JsAbrirFormularioPublicarArchivo(IdRegistro, IdTipoDocumento))
                        lbtn.Visible = True

                        Dim lbtn2 As LinkButton = CType(e.Item.FindControl(ControlLbtnDesc_TipoDocumento), LinkButton)
                        lbtn2.Text = strTipoDocumento
                        lbtn2.Attributes.Add(ConstantesWeb.JsEventoOnClick, Me.JsAbrirAbrirDocumentoPublicado(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString())))
                        lbtn2.CausesValidation = False
                        lbtn2.Visible = True

                        Dim img2 As Image = CType(e.Item.FindControl(ControlImgDocumento), Image)
                        Me.ImagenTipoDocumento(img2, Convert.ToString(dr(Enumeradores.Col_PEDIDO_PRD_DOC.pptdc_vNombre_Doc_Digital.ToString())))

                    Else
                        Dim lbl As Label = CType(e.Item.FindControl(ControlDescLblPublicar), System.Web.UI.WebControls.Label)
                        lbl.Text = "NO"
                        lbl.Visible = True
                    End If

                ElseIf (IdEstadoDocumento = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Pendiente)) Then
                    Dim lbtn As LinkButton = CType(e.Item.FindControl(ControlLbtnPublicar), LinkButton)
                    lbtn.ToolTip = "Publicar documento..."
                    lbtn.Attributes.Add(ConstantesWeb.JsEventoOnClick.ToString(), Me.JsAbrirFormularioPublicarArchivo(IdRegistro, IdTipoDocumento))
                    lbtn.Visible = True

                    Dim ibtn As New ImageButton
                    ibtn = CType(e.Item.FindControl(ControlIbtnRecibidoFisicamente), ImageButton)
                    ibtn.ToolTip = "Marcar como documento recibido fisicamente..."
                    ibtn.Visible = True
                    ibtn.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Marcar documento como recibido fisicamente?"))

                End If

                Dim Js As String = ""
                Js += HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ClientID, IdRegistro.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Js)

            End If

        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Me.RegistrarJavaScript()
            Me.LlenarJScript()
        End Sub

        Protected Sub btnActualizarGrilla_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, "Error en el Servidor")
            End Try
        End Sub
    End Class
End Namespace


