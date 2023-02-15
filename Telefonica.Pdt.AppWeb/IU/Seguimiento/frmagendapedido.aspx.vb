
Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmagendapedido
        Inherits WebPaginaBase
        Implements IPaginaBase

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboProveedor()
            Me.LlenarComboGrupoInstalacion()
        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.ReiniciarControles()
            Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion
            Dim TotalRegistros As Integer = 0
            Dim ds As DataSet = Me.ListarDataLlenarGrilla()


            If Not (ds Is Nothing) Then
                Me.grid.DataSource = ds.Tables(0)
                IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(TotalRegistros, Me.grid.PageSize, IndicePagina)
                Me.grid.CurrentPageIndex = IndicePagina
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + ds.Tables(0).Rows.Count.ToString()
                Me.VisualizarControles(True)
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.VisualizarControles(False)
            End If
            Try
                Me.grid.DataBind()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.upgProcesandoWeb)
        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros
        End Function

#End Region

#Region "Metodos Privados"

        Private Sub LlenarComboProveedor()

            Try
                Me.ddlbProveedor.Items.Clear()
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim dt As DataTable = opdt_cupoBL.ListarProveedores(-1, String.Empty, String.Empty)

                If Not (dt Is Nothing) Then
                    Dim dw As DataView = dt.DefaultView
                    dw.Sort = Enumeradores.col_PDTT_PROVEEDOR.provc_vRazon_Social.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                    Me.ddlbProveedor.DataSource = dw
                End If

                Me.ddlbProveedor.DataValueField = Enumeradores.col_PDTT_PROVEEDOR.provc_iIdProveedor.ToString
                Me.ddlbProveedor.DataTextField = Enumeradores.col_PDTT_PROVEEDOR.provc_vRazon_Social.ToString
                Me.ddlbProveedor.DataBind()

                HelperWeb.ComboAddItemSeleccionarVacio(Me.ddlbProveedor)
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try

        End Sub

        Private Sub LlenarComboGrupoInstalacion()

            Try
                Me.ddlbGrupoInstalacion.Items.Clear()
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim zgrpc_iIdZona_Grp_Instalacion As Integer = -1 ' Convert.ToInt32(Me.Page.Request.Params(Enumeradores.col_PDTT_GRP_INSTALACION.zgrpc_iIdZona_Grp_Instalacion.ToString()))

                Dim dt As DataTable = opdt_cupoBL.ListarGrupoInstalacion(-1, zgrpc_iIdZona_Grp_Instalacion, String.Empty)

                If Not (dt Is Nothing) Then
                    Dim dw As DataView = dt.DefaultView
                    dw.Sort = Enumeradores.col_PDTT_GRP_INSTALACION.grpic_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                    Me.ddlbGrupoInstalacion.DataSource = dw

                End If

                Me.ddlbGrupoInstalacion.DataTextField = Enumeradores.col_PDTT_GRP_INSTALACION.grpic_vDescripcion.ToString
                Me.ddlbGrupoInstalacion.DataValueField = Enumeradores.col_PDTT_GRP_INSTALACION.grpic_iIdGrp_Instalacion.ToString
                Me.ddlbGrupoInstalacion.DataBind()
                HelperWeb.ComboAddItemSeleccionarVacio(Me.ddlbGrupoInstalacion)
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try

        End Sub

        Private Function ListarDataLlenarGrilla() As DataSet
            Try
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim intCodProveedor As Integer = 0
                Dim intCodGrupoInstalacion As Integer = 0
                If ddlbProveedor.SelectedValue = String.Empty Then
                    intCodProveedor = -1
                Else
                    intCodProveedor = Convert.ToString(ddlbProveedor.SelectedValue)
                End If
                If ddlbGrupoInstalacion.SelectedValue = String.Empty Then
                    intCodGrupoInstalacion = -1
                Else
                    intCodGrupoInstalacion = Convert.ToString(ddlbGrupoInstalacion.SelectedValue)
                End If
                Dim ds As DataSet
                ds = opdt_cupoBL.Listar(-1, intCodProveedor, intCodGrupoInstalacion, -1, -1)
                Return ds
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Private Sub ReiniciarControles()
            Me.hCodigo.Value = String.Empty
        End Sub

        Private Sub LimpiarControles()
        End Sub

#End Region

#Region "Metodos Formulario"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.HacerControlComandoNetAjax()
                Me.RegistrarJScript()
                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarCombos()
                    Me.LlenarDatos()
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Sub EventoClickElegirCupo(ByVal sender As System.Object, ByVal e As System.EventArgs)

            Try
                'Captura el parametro enviado del formulario anterior.

                Dim pdppc_iIdPedido_Prd As Integer = Convert.ToInt32(Me.Page.Request.Params(Enumeradores.col_PDTT_PEDIDO_PRD.pdppc_iIdPedido_Prd.ToString()))
                Dim cupoc_iIdCupo As Integer = Convert.ToInt32(Me.hCodigo.Value)
                Dim pdppc_iIdUsuario_Modifica As Integer = Convert.ToInt32(Me.PAG_IdUsuario_InicioSesion)

                Dim opdt_cupoBL As New pdt_cupoBL

                Dim retorno As Integer = 0
                If cupoc_iIdCupo.ToString().Length > 0 Then
                    retorno = opdt_cupoBL.AsignarCupo(pdppc_iIdPedido_Prd, cupoc_iIdCupo, pdppc_iIdUsuario_Modifica)
                End If
                If retorno > 0 Then
                    NetAjax.JsMensajeAlert(Me.Page, "El Pedido fue asignado con exito...", "Mensaje")
                Else
                    NetAjax.JsMensajeAlert(Me.Page, "No se pudo asignar el pedido...", "Mensaje")
                End If
                Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))

            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanel1.Update()
            End Try
        End Sub

        Protected Sub gridc_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) Or (elemType = ListItemType.AlternatingItem)) Then
                Dim lbkbAgendarPedido As LinkButton
                lbkbAgendarPedido = CType(e.Item.FindControl("lbkbAgendarPedido"), LinkButton)
                AddHandler lbkbAgendarPedido.Click, AddressOf Me.EventoClickElegirCupo
            End If
        End Sub

        Protected Sub grid_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemCreated
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) Or (elemType = ListItemType.AlternatingItem)) Then
                Dim gdv As New DataGrid
                gdv = CType(e.Item.FindControl("gridc"), DataGrid)
                AddHandler gdv.ItemCreated, AddressOf Me.gridc_ItemCreated
            End If
        End Sub

        Private Sub gridc_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

            If ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then
                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                
                Dim lbkbAgendarPedido As LinkButton
                lbkbAgendarPedido = CType(e.Item.FindControl("lbkbAgendarPedido"), LinkButton)

                lbkbAgendarPedido.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea Agendar el Pedido al proveedor para esta fecha?"))

                Dim IdRegistro As Integer = Convert.ToInt32(e.Item.Cells(0).Text)
                If Convert.ToInt32(e.Item.Cells(2).Text) = Convert.ToInt32(e.Item.Cells(3).Text) Then
                    lbkbAgendarPedido.Enabled = False
                End If

                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ID, IdRegistro.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
            End If
        End Sub

        Private Sub grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemDataBound

            If ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row

                Dim fechc_iIdFecha As Integer = Convert.ToString(dr("fechc_iIdFecha".ToString()))
                Dim dt As New DataTable
                Dim gdv As New DataGrid
                gdv = CType(e.Item.FindControl("gridc"), DataGrid)
                Dim dtv As DataSet = Me.ListarDataLlenarGrilla
                If Not dtv Is Nothing Then
                    dt = dtv.Tables(1)
                    Dim filter As String = " fechc_iIdFecha = '" & fechc_iIdFecha & "'"
                    dt.DefaultView.RowFilter = filter
                Else
                    dt = Nothing
                End If
                AddHandler gdv.ItemDataBound, AddressOf Me.gridc_ItemDataBound

                Try
                    If Not gdv Is Nothing Then
                        gdv.DataSource = dt
                        gdv.DataBind()
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End If
        End Sub

        Private Sub grid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grid.PageIndexChanged
            Try
                Me.hGrillaIndicePagina.Value = e.NewPageIndex.ToString()
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, "MensajeError")
            Finally
                Me.UpdatePanel1.Update()
            End Try
        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlbProveedor)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlbGrupoInstalacion)
        End Sub

#End Region

        Protected Sub ddlbProveedor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbProveedor.SelectedIndexChanged
          
            Me.LlenarGrilla()
            Me.UpdatePanel1.Update()
        End Sub

        Protected Sub ddlbGrupoInstalacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbGrupoInstalacion.SelectedIndexChanged
            Me.LlenarGrilla()
            Me.UpdatePanel1.Update()
        End Sub

    End Class

End Namespace
