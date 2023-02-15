
Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmlistapedidosnoagendados
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
            Me.LlenarComboProducto()
            Me.LlenarComboGrupoInstalacion()
            Me.LlenarComboFranjaHoraria()
        End Sub
        Public Sub LlenarComboFranjaHoraria()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Franja_Horaria, Me.ddlbFranja)

        End Sub

        Public Sub LlenarComboGrupoInstalacion()
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

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.ReiniciarControles()
            Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))

            Me.gridd.DataSource = Nothing
            Me.gridd.DataBind()

            Me.gridc.DataSource = Nothing
            Me.gridc.DataBind()
            Me.btnAgregar.Visible = False
            Me.pnlDetalleCupo.Visible = False

            Me.UpdatePanel2.Update()
            Me.UpdatePanel3.Update()

        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion
            Dim dt As DataTable = Me.ListarDataLlenarGrilla()
            If Not (dt Is Nothing) Then
                Me.grid.DataSource = dt
                IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(Convert.ToUInt32(dt.Rows.Count), Me.grid.PageSize, IndicePagina)
                Me.grid.CurrentPageIndex = IndicePagina
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + dt.Rows.Count.ToString()
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
            Finally
                Me.UpdatePanel1.Update()
            End Try
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            Me.rfvProveedor.ErrorMessage = "Seleccionar el proveedor..."
            Me.rfvProveedor.InitialValue = ConstantesWeb.VACIO

            Me.rfvProducto.ErrorMessage = "Seleccionar el producto..."
            Me.rfvProducto.InitialValue = ConstantesWeb.VACIO
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

        Private Sub LlenarComboProducto()
            Try
                Me.ddlbProducto.Items.Clear()
                Dim opdt_prd_servicioBL As New pdt_prd_servicioBL
                Dim zgrpc_iIdZona_Grp_Instalacion As Integer = -1 ' Convert.ToInt32(Me.Page.Request.Params(Enumeradores.col_PDTT_GRP_INSTALACION.zgrpc_iIdZona_Grp_Instalacion.ToString()))
                Dim dt As DataTable = opdt_prd_servicioBL.Listar_PRD_SERVICIO_AGENDABLE(-1, 1)
                If Not (dt Is Nothing) Then
                    Dim dw As DataView = dt.DefaultView
                    dw.Sort = Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                    Me.ddlbProducto.DataSource = dw
                End If
                Me.ddlbProducto.DataTextField = Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString
                Me.ddlbProducto.DataValueField = Enumeradores.Col_PRD_SERVICIO.prsec_iIdPrd_Servicio.ToString
                Me.ddlbProducto.DataBind()
                HelperWeb.ComboAddItemSeleccionarVacio(Me.ddlbProducto)
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Private Function ListarDataLlenarGrilla() As DataTable
            Try
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim intCodProveedor As Integer = 0
                Dim intCodProducto As Integer = 0
                If ddlbProveedor.SelectedValue = String.Empty Then
                    intCodProveedor = -1
                Else
                    intCodProveedor = Convert.ToString(ddlbProveedor.SelectedValue)
                End If
                If ddlbProducto.SelectedValue = String.Empty Then
                    intCodProducto = -1
                Else
                    intCodProducto = Convert.ToString(ddlbProducto.SelectedValue)
                End If
                Dim datFechaInicio As Nullable(Of DateTime)
                If (Me.calFechaInicio.Fecha.Length > 0) Then
                    datFechaInicio = CType(HelperWeb.ConvertToDateTime(Me.calFechaInicio.Fecha), Nullable(Of DateTime))
                End If
                Dim datFechaFin As Nullable(Of DateTime)
                If (calFechaFin.Fecha.Length > 0) Then
                    datFechaFin = CType(HelperWeb.ConvertToDateTime(Me.calFechaFin.Fecha), Nullable(Of DateTime))
                End If
                Dim dt As DataTable
                dt = opdt_cupoBL.ListarFecha(-1, intCodProveedor, intCodProducto, 1, datFechaInicio, datFechaFin)
                Return dt
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Private Function ListarDataLlenarGrillaCupos() As DataSet
            Try
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim intCodFecha As Integer = 0
                Dim intCodProveedor As Integer = 0
                Dim intCodGrupoInstalacion As Integer = 0
                If Me.hCodigo.Value.Length > 0 Then
                    intCodFecha = Convert.ToInt32(Me.hCodigo.Value)
                Else
                    intCodFecha = ViewState("Codigo")
                End If
                If ddlbProveedor.SelectedValue = String.Empty Then
                    intCodProveedor = -1
                Else
                    intCodProveedor = Convert.ToString(ddlbProveedor.SelectedValue)
                End If
                Dim intCodProducto As Integer = 0
                If ddlbProducto.SelectedValue = String.Empty Then
                    intCodProducto = -1
                Else
                    intCodProducto = Convert.ToString(ddlbProducto.SelectedValue)
                End If
                intCodGrupoInstalacion = -1
                Dim ds As DataSet
                ds = opdt_cupoBL.Listar(-1, intCodProveedor, intCodGrupoInstalacion, intCodFecha, intCodProducto)
                Return ds
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        Private Function ListarDataLlenarGrillaZonas() As DataTable
            Try
                Dim dt As DataTable
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim provc_iIdProveedor As Integer = -1
                If Me.ddlbProveedor.SelectedValue.Length > 0 Then
                    provc_iIdProveedor = Me.ddlbProveedor.SelectedValue
                End If
                Dim prsec_iIdPrd_Servicio As Integer = -1
                If Me.ddlbProducto.SelectedValue.Length > 0 Then
                    prsec_iIdPrd_Servicio = Me.ddlbProducto.SelectedValue
                End If
                Dim fechc_iIdFecha As Integer = -1
                If Me.hCodigo.Value.Length > 0 Then
                    fechc_iIdFecha = Convert.ToInt32(Me.hCodigo.Value)
                Else
                    fechc_iIdFecha = ViewState("Codigo")
                End If
                dt = opdt_cupoBL.ListarZonaPedidoAgendado(provc_iIdProveedor, prsec_iIdPrd_Servicio, fechc_iIdFecha)

                Return dt
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
                Return Nothing
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

        Sub LlenarGrillaCupos()
            Try
                gridd.DataSource = Nothing
                gridd.DataBind()
                Dim ds As DataSet
                Dim dt As DataTable
                ds = Me.ListarDataLlenarGrillaCupos()
                Me.btnAgregar.Visible = False
                If Not ds Is Nothing Then
                    dt = ds.Tables(1)
                    Me.btnAgregar.Visible = True
                Else
                    dt = Nothing
                End If
                gridd.DataSource = dt
                gridd.DataBind()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try

        End Sub

        Sub LlenarGrillaZonas()
            Try
                gridc.DataSource = Nothing
                gridc.DataBind()
                Dim dtz As DataTable
                dtz = Me.ListarDataLlenarGrillaZonas
                If Not dtz Is Nothing Then
                    gridc.DataSource = dtz
                Else
                    gridc.DataSource = Nothing
                End If
                gridc.DataBind()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Sub EventoClickListarCupos(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                If Me.hCodigo.Value.Length > 0 Then
                    ViewState("Codigo") = Me.hCodigo.Value
                End If
                Me.pnlDetalleCupo.Visible = False
                Me.LlenarGrillaCupos()
                Me.LlenarGrillaZonas()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanel2.Update()
                Me.UpdatePanel3.Update()
            End Try
        End Sub

        Protected Sub grid_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemCreated
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) OrElse (elemType = ListItemType.AlternatingItem)) Then
                Dim lbkbFecha As New LinkButton
                lbkbFecha = CType(e.Item.FindControl("lbkbFecha"), LinkButton)
                AddHandler lbkbFecha.Click, AddressOf Me.EventoClickListarCupos
            End If
        End Sub

        Private Sub grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemDataBound
            If ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then
                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row

                e.Item.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)

                Dim lbkbFecha As LinkButton
                lbkbFecha = CType(e.Item.FindControl("lbkbFecha"), LinkButton)
                lbkbFecha.Text = Convert.ToString(dr("FechaDia".ToString()))
                Dim imgCierre As Image
                imgCierre = CType(e.Item.FindControl("imgCierre"), Image)

                '//Logica para mostrar las imagenes en el grid de fechas
                If Convert.ToString(dr("FechaCerrada".ToString())) = 0 Then
                    imgCierre.ImageUrl = ConstantesWeb.RutaImagenVacio
                ElseIf Convert.ToString(dr("FechaCerrada".ToString())) > 0 And _
                            Convert.ToString(dr("FechaCerrada".ToString())) = Convert.ToString(dr("FechaMaximo".ToString())) Then
                    imgCierre.ImageUrl = ConstantesWeb.RutaImagenLleno
                ElseIf Convert.ToString(dr("FechaCerrada".ToString())) > 0 And _
                            Convert.ToString(dr("FechaCerrada".ToString())) < Convert.ToString(dr("FechaMaximo".ToString())) Then
                    imgCierre.ImageUrl = ConstantesWeb.RutaImagenMedio
                End If
                Dim fechc_iIdFecha As Integer = Convert.ToString(dr("fechc_iIdFecha".ToString()))
                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ID, fechc_iIdFecha.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
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
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlbProveedor)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlbProducto)
        End Sub

#End Region

        '/****Grid de la Lista de Cupos por Fecha
        Sub EventoClickModificarCupo(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Dim dt As DataTable
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim cupoc_iIdCupo As Integer = -1
                If Me.hCodigoCupo.Value.Length > 0 Then
                    cupoc_iIdCupo = Convert.ToInt32(Me.hCodigoCupo.Value)
                Else
                    NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
                    Return
                End If
                dt = opdt_cupoBL.Listar(cupoc_iIdCupo, -1, -1, -1, -1).Tables(1)

                If Not dt Is Nothing Then
                    Me.ddlbGrupoInstalacion.SelectedValue = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.grpic_iIdGrp_Instalacion.ToString())
                    Me.ddlbFranja.SelectedValue = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.vfhoc_iIdFranja_Horaria.ToString())
                    Me.nbCupos.Text = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.cupoc_iCanti_Cupo_Asignada.ToString())
                    'ViewState("Cupoc_iCanti_Cupo_Asignada") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.cupoc_iCanti_Cupo_Asignada.ToString())
                    ViewState("Cupoc_iCanti_Cupo_Disponible") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.cupoc_iCanti_Cupo_Disponible.ToString())
                    'ViewState("Vfhoc_iIdFranja_Horaria") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.vfhoc_iIdFranja_Horaria.ToString())
                    'ViewState("Grpic_iIdGrp_Instalacion") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.grpic_iIdGrp_Instalacion.ToString())
                    ViewState("Cupoc_iInd_Cierre_Cupo") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.cupoc_iInd_Cierre_Cupo.ToString())
                    'ViewState("Cupoc_iEstado_Registro") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.cupoc_iEstado_Registro.ToString())
                    'ViewState("Cupoc_iIdUsuario_Modifica") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.vfhoc_iIdFranja_Horaria.ToString())
                    'ViewState("Provc_iIdProveedor") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.vfhoc_iIdFranja_Horaria.ToString())
                    'ViewState("Fechc_iIdFecha") = dt.Rows(ConstantesWeb.VALORCERO).Item(Enumeradores.col_PDTT_CUPO.vfhoc_iIdFranja_Horaria.ToString())
                    Me.pnlDetalleCupo.Visible = True
                    Me.btnAgregar.Visible = False
                End If

            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Protected Sub gridd_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridd.ItemCreated
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) Or (elemType = ListItemType.AlternatingItem)) Then
                Dim lnkbCupos As LinkButton
                lnkbCupos = CType(e.Item.FindControl("lnkbCupos"), LinkButton)
                lnkbCupos.Text = Convert.ToString("Modificar".ToString())
                AddHandler lnkbCupos.Click, AddressOf Me.EventoClickModificarCupo
            End If
        End Sub

        Protected Sub gridd_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridd.ItemDataBound
            If ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then
                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Item.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.gridd, e)

                Dim lnkbCupos As LinkButton
                lnkbCupos = CType(e.Item.FindControl("lnkbCupos"), LinkButton)
                lnkbCupos.Text = Convert.ToString("Modificar".ToString())

                lnkbCupos.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea Modificar el numero de cupos asignados por el proveedor?"))


                Dim lblCupos As Label
                lblCupos = CType(e.Item.FindControl("lblCupos"), Label)
                lblCupos.Text = Convert.ToString(dr(Enumeradores.col_PDTT_CUPO.cupoc_iCanti_Cupo_Asignada.ToString()))

                Dim cupoc_iIdCupo As Integer = Convert.ToString(dr("cupoc_iIdCupo".ToString()))


                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigoCupo.ID, cupoc_iIdCupo.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
            End If
        End Sub

        '/****Grid de la Lista de Producto / Franja

        Public Function UrlPaginaGeneraExcel(ByVal provc_iIdProveedor As Integer, ByVal prsec_iIdPrd_Servicio As Integer, ByVal fechc_iIdFecha As Integer) As String
            Dim Url As String = ""
            Url += "frmGeneraExcel.aspx?"
            Url += Enumeradores.col_PDTT_PROVEEDOR.provc_iIdProveedor.ToString() + ConstantesWeb.SignoIGUAL + provc_iIdProveedor.ToString()
            Url += ConstantesWeb.SignoAMPERSON + Enumeradores.col_PDTT_PEDIDO_PRD.prsec_iIdPrd_Servicio.ToString() + ConstantesWeb.SignoIGUAL + prsec_iIdPrd_Servicio.ToString()
            Url += ConstantesWeb.SignoAMPERSON + Enumeradores.col_PDTT_CUPO.fechc_iIdFecha.ToString() + ConstantesWeb.SignoIGUAL + fechc_iIdFecha.ToString()
            Return Url
        End Function

        Sub EventoClickReAbrirFecha(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try

                Dim pobjpdt_cupobl As New pdt_cupoBL
                Dim Grpic_iIdGrp_Instalacion As Integer = Convert.ToInt32(Me.hCodigoCierre.Value) 'Convert.ToInt32(Me.ddlbGrupoInstalacion.SelectedValue)
                Dim Cupoc_iInd_Cierre_Cupo As Integer = 0
                Dim Cupoc_iEstado_Registro As Integer = 1
                Dim Cupoc_iIdUsuario_Modifica As Integer = Me.PAG_IdUsuario_InicioSesion
                Dim Provc_iIdProveedor As Integer = Convert.ToInt32(Me.ddlbProveedor.SelectedValue)

                Dim intCodigo As Integer = 0
                If Me.hCodigo.Value.Length > 0 Then
                    intCodigo = Me.hCodigo.Value
                Else
                    intCodigo = ViewState("Codigo")
                End If

                Dim Fechc_iIdFecha As Integer = intCodigo

                Dim Prsec_iIdPrd_Servicio As Integer = Convert.ToInt32(Me.ddlbProducto.SelectedValue)

                Dim retorno As Integer = 0
                retorno = pobjpdt_cupobl.CierraReAbreFecha(Grpic_iIdGrp_Instalacion, Cupoc_iInd_Cierre_Cupo, Cupoc_iEstado_Registro, Cupoc_iIdUsuario_Modifica, Provc_iIdProveedor, Fechc_iIdFecha, Prsec_iIdPrd_Servicio)
                If retorno > 0 Then
                    Me.LlenarGrilla()
                    Me.LlenarGrillaZonas()
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanel1.Update()
                Me.UpdatePanel2.Update()
            End Try
        End Sub

        Sub EventoClickCerrarFecha(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                Dim pobjpdt_cupobl As New pdt_cupoBL
                Dim Grpic_iIdGrp_Instalacion As Integer = Convert.ToInt32(Me.hCodigoCierre.Value) 'Convert.ToInt32(Me.ddlbGrupoInstalacion.SelectedValue)
                Dim Cupoc_iInd_Cierre_Cupo As Integer = 1
                Dim Cupoc_iEstado_Registro As Integer = 1
                Dim Cupoc_iIdUsuario_Modifica As Integer = Me.PAG_IdUsuario_InicioSesion
                Dim Provc_iIdProveedor As Integer = Convert.ToInt32(Me.ddlbProveedor.SelectedValue)

                Dim intCodigo As Integer = 0
                If Me.hCodigo.Value.Length > 0 Then
                    intCodigo = Me.hCodigo.Value
                Else
                    intCodigo = ViewState("Codigo")
                End If

                Dim Fechc_iIdFecha As Integer = intCodigo
                Dim Prsec_iIdPrd_Servicio As Integer = Convert.ToInt32(Me.ddlbProducto.SelectedValue)

                Dim retorno As Integer = 0
                retorno = pobjpdt_cupobl.CierraReAbreFecha(Grpic_iIdGrp_Instalacion, Cupoc_iInd_Cierre_Cupo, Cupoc_iEstado_Registro, Cupoc_iIdUsuario_Modifica, Provc_iIdProveedor, Fechc_iIdFecha, Prsec_iIdPrd_Servicio)
                If retorno > 0 Then
                    Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
                    'Me.LlenarGrilla()
                    Me.LlenarGrillaZonas()
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanel1.Update()
                Me.UpdatePanel2.Update()
            End Try
        End Sub

        Protected Sub gridc_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridc.ItemCreated
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) Or (elemType = ListItemType.AlternatingItem)) Then
                Dim lbkbReAbrirFecha As New LinkButton
                lbkbReAbrirFecha = CType(e.Item.FindControl("lbkbReAbrirFecha"), LinkButton)
                AddHandler lbkbReAbrirFecha.Click, AddressOf Me.EventoClickReAbrirFecha

                Dim lnkbCerrarFecha As New LinkButton
                lnkbCerrarFecha = CType(e.Item.FindControl("lnkbCerrarFecha"), LinkButton)
                AddHandler lnkbCerrarFecha.Click, AddressOf Me.EventoClickCerrarFecha

            End If
        End Sub

        Protected Sub gridc_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles gridc.ItemDataBound
            If ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then
                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Item.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.gridc, e)
                Dim lbkbReAbrirFecha As New LinkButton
                lbkbReAbrirFecha = CType(e.Item.FindControl("lbkbReAbrirFecha"), LinkButton)
                Dim lnkbCerrarFecha As New LinkButton
                lnkbCerrarFecha = CType(e.Item.FindControl("lnkbCerrarFecha"), LinkButton)
                Dim ltlExportaExcel As System.Web.UI.WebControls.Literal = CType(e.Item.FindControl("ltlExportaExcel"), System.Web.UI.WebControls.Literal)
                Dim intCodigo As Integer = 0
                If Me.hCodigo.Value.Length > 0 Then
                    intCodigo = Me.hCodigo.Value
                Else
                    intCodigo = ViewState("Codigo")
                End If

                lbkbReAbrirFecha.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea Re-abrir la fecha para el proveedor?"))
                lnkbCerrarFecha.Attributes.Add(ConstantesWeb.JsEventoOnClick, HelperWeb.JsConfirmarAccionProceso("¿Desea Cerrar la fecha para el proveedor?"))

                ltlExportaExcel.Text = HelperWeb.JsAbrirReporteFrameWeb(Me.UrlPaginaGeneraExcel(Me.ddlbProveedor.SelectedValue, Me.ddlbProducto.SelectedValue, intCodigo), "17px", "17px")
                Dim imgEstadoFecha As Image = CType(e.Item.FindControl("imgEstadoFecha"), Image)

                If Convert.ToString(dr("FechaCerrada".ToString())) = 0 Then
                    imgEstadoFecha.ImageUrl = ConstantesWeb.RutaImagenVacio
                    lbkbReAbrirFecha.Visible = False
                    lnkbCerrarFecha.Visible = True
                ElseIf Convert.ToString(dr("FechaCerrada".ToString())) > 0 And _
                            Convert.ToString(dr("FechaCerrada".ToString())) = Convert.ToString(dr("FechaMaximo".ToString())) Then
                    imgEstadoFecha.ImageUrl = ConstantesWeb.RutaImagenLleno
                    lbkbReAbrirFecha.Visible = True
                    lnkbCerrarFecha.Visible = False
                ElseIf Convert.ToString(dr("FechaCerrada".ToString())) > 0 And _
                            Convert.ToString(dr("FechaCerrada".ToString())) < Convert.ToString(dr("FechaMaximo".ToString())) Then
                    imgEstadoFecha.ImageUrl = ConstantesWeb.RutaImagenMedio
                    lbkbReAbrirFecha.Visible = True
                    lnkbCerrarFecha.Visible = True
                End If

                Dim grpic_iIdGrp_Instalacion As Integer = Convert.ToInt32(dr(Enumeradores.col_PDTT_GRP_INSTALACION.grpic_iIdGrp_Instalacion.ToString()))
                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigoCierre.ID, grpic_iIdGrp_Instalacion.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
            End If
        End Sub

        Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
            Me.LlenarGrilla()
        End Sub

        Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            Try
                Dim retorno As Integer = 0
                Dim pobjcupo As New CUPO
                Dim pobjpdt_cupobl As New pdt_cupoBL
                If Me.hCodigoCupo.Value.Length > 0 Then
                    pobjcupo.Cupoc_iIdCupo = Convert.ToInt32(Me.hCodigoCupo.Value)
                    pobjcupo.Cupoc_iCanti_Cupo_Asignada = Convert.ToInt32(Me.nbCupos.Text)
                    pobjcupo.Cupoc_iCanti_Cupo_Disponible = ViewState("Cupoc_iCanti_Cupo_Disponible")
                    pobjcupo.Vfhoc_iIdFranja_Horaria = Convert.ToInt32(Me.ddlbFranja.SelectedValue)
                    pobjcupo.Grpic_iIdGrp_Instalacion = Convert.ToInt32(Me.ddlbGrupoInstalacion.SelectedValue)
                    pobjcupo.Cupoc_iInd_Cierre_Cupo = ViewState("Cupoc_iInd_Cierre_Cupo")
                    pobjcupo.Cupoc_iEstado_Registro = 1
                    pobjcupo.Cupoc_iIdUsuario_Modifica = 1
                    pobjcupo.Provc_iIdProveedor = Convert.ToInt32(Me.ddlbProveedor.SelectedValue)
                    Dim intCodigo As Integer = 0
                    If Me.hCodigo.Value.Length > 0 Then
                        intCodigo = Me.hCodigo.Value
                    Else
                        intCodigo = ViewState("Codigo")
                    End If
                    pobjcupo.Fechc_iIdFecha = intCodigo
                    pobjcupo.Prsec_iIdPrd_Servicio = Convert.ToInt32(Me.ddlbProducto.SelectedValue)
                    retorno = pobjpdt_cupobl.Modificar(pobjcupo)
                    If retorno > 0 Then
                        Me.pnlDetalleCupo.Visible = False
                        NetAjax.JsMensajeAlert(Me.Page, "El registro se grabo con exito...", "Mensaje")
                    Else
                        'Me.pnlDetalleCupo.Visible = False
                        NetAjax.JsMensajeAlert(Me.Page, "Ya existe grupo asignado a la franja...", "Mensaje")
                    End If
                Else
                    pobjcupo.Cupoc_iCanti_Cupo_Asignada = Convert.ToInt32(Me.nbCupos.Text)
                    pobjcupo.Cupoc_iCanti_Cupo_Disponible = Convert.ToInt32(Me.nbCupos.Text)
                    pobjcupo.Vfhoc_iIdFranja_Horaria = Convert.ToInt32(Me.ddlbFranja.SelectedValue)
                    pobjcupo.Grpic_iIdGrp_Instalacion = Convert.ToInt32(Me.ddlbGrupoInstalacion.SelectedValue)
                    pobjcupo.Cupoc_iInd_Cierre_Cupo = 0
                    pobjcupo.Cupoc_iEstado_Registro = 1
                    pobjcupo.Cupoc_iIdUsuario_Registro = 1
                    pobjcupo.Provc_iIdProveedor = Convert.ToInt32(Me.ddlbProveedor.SelectedValue)
                    Dim intCodigo As Integer = 0
                    If Me.hCodigo.Value.Length > 0 Then
                        intCodigo = Me.hCodigo.Value
                    Else
                        intCodigo = ViewState("Codigo")
                    End If
                    pobjcupo.Fechc_iIdFecha = intCodigo
                    pobjcupo.Prsec_iIdPrd_Servicio = Convert.ToInt32(Me.ddlbProducto.SelectedValue)
                    retorno = pobjpdt_cupobl.Insertar(pobjcupo)
                    If retorno > 0 Then
                        Me.pnlDetalleCupo.Visible = False
                        Me.btnAgregar.Visible = True
                        NetAjax.JsMensajeAlert(Me.Page, "El registro se grabo con exito...", "Mensaje")
                    Else
                        NetAjax.JsMensajeAlert(Me.Page, "Ya existe grupo asignado a la franja...", "Mensaje")
                    End If
                End If
                Me.LlenarGrillaZonas()
                Me.LlenarGrillaCupos()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            Finally
                Me.UpdatePanel2.Update()
                Me.UpdatePanel3.Update()
            End Try
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.pnlDetalleCupo.Visible = False
            Me.UpdatePanel3.Update()
        End Sub

        Protected Sub btnAgregar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
            Me.pnlDetalleCupo.Visible = True
            Me.btnAgregar.Visible = False
            Me.ddlbFranja.SelectedIndex = ConstantesWeb.VALORMENOSUNO
            Me.ddlbGrupoInstalacion.SelectedIndex = ConstantesWeb.VALORMENOSUNO
            Me.nbCupos.Text = ConstantesWeb.VACIO
        End Sub
    End Class

End Namespace


