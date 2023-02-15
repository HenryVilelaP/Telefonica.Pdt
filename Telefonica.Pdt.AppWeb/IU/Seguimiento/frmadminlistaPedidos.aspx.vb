Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmadminlistaPedidos
        Inherits System.Web.UI.Page
        Implements IPaginaBase

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoEliminar As String = "GrillaEventoEliminar"
        Private Const ConstGrillaEventoMostrarDetalle As String = "GrillaEventoMostrarDetalle"
        Private Shared ModoPaginaProceso As String = ""    

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboEstados()
            Me.LlenarComboGrupoProducto()
            Me.LlenarComboGrupoOperacionComercial()
            Me.LlenarComboZonal()
            Me.LlenarComboPaquete()
            Me.LlenarComboProducto()
            Me.LlenarComboFuente()
            Me.LlenarComboSegmento()
            Me.LlenarComboSubSegmento()
            Me.LlenarComboTipoOperacionComercial()
            Me.LlenarComboCritico()
            Me.LlenarComboDestino()
            Me.LlenarComboEstacionIsis()
            Me.LlenarRadioButtons()
        End Sub

        Public Sub LlenarRadioButtons()
            HelperWeb.LLenarListaPedidosEmitibles(Me.rbtnlPedidosEmitibles)
            HelperWeb.LLenarListaTipoBusqueda(Me.rbtnlTipoBusqueda)
            HelperWeb.LLenarListaTipoSeguimiento(Me.rbtnlTipoSeguimiento)

        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.ReiniciarControles()
            Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

            Dim dt As DataTable = Me.ListarDataLlenarGrilla()

            If Not (dt Is Nothing) Then
                Me.grid.Visible = True
                Me.grid.DataSource = dt
                IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(dt.Rows.Count, Me.grid.PageSize, IndicePagina)
                Me.grid.CurrentPageIndex = IndicePagina
                Me.grid.VirtualItemCount = dt.Rows.Count
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + Me.grid.VirtualItemCount.ToString()
                Me.VisualizarControles(True)
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.VisualizarControles(False)
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados
                Me.lblRegistrosEncontrados.Visible = False
            End If

            Try
                Me.grid.DataBind()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible

        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)
            Me.pnlAcciones.Visible = blnEsVisible
            Me.pnlOpcionesCabecera.Visible = blnEsVisible

            'Me.UpdatePanelGrilla.Visible = blnEsVisible
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.upgProcesandoWeb)
        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.upgProcesandoWeb)
        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

#End Region

#Region "Metodos Privados"

        Public Sub ActualizaEstadoCritico()
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intPedido As Integer

            intPedido = Me.hCodigo.Value
            intUsuarioModifica = 1
            opdt_pedidoBL = New pdt_pedidoBL

            lintResult = opdt_pedidoBL.Actualiza_PEDIDO_CRITICO(intPedido, intUsuarioModifica)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede actualizar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
            End Select

        End Sub

        Public Sub ActualizaEstadoRechazado()
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim intEstado As Integer
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intPedido As Integer

            intPedido = Me.hCodigo.Value
            intUsuarioModifica = 9
            opdt_pedidoBL = New pdt_pedidoBL

            intEstado = Enumeradores.TAB_Val_EstadoPedido.Rechazado
            lintResult = opdt_pedidoBL.Actualiza_ESTADO_PEDIDO_ADMINISTRACION(intPedido, intEstado, intUsuarioModifica)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede actualizar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
            End Select

        End Sub

        Public Sub ActualizaEstadoRecibido()
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim intEstado As Integer
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intPedido As Integer

            intPedido = Me.hCodigo.Value
            intUsuarioModifica = 9
            opdt_pedidoBL = New pdt_pedidoBL

            intEstado = Enumeradores.TAB_Val_EstadoPedido.Recibido
            lintResult = opdt_pedidoBL.Actualiza_ESTADO_PEDIDO_ADMINISTRACION(intPedido, intEstado, intUsuarioModifica)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede actualizar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
            End Select

        End Sub

        Public Sub DocumentosPendientes()            
            Dim opdt_pedidoBL As pdt_pedidoBL
            opdt_pedidoBL = New pdt_pedidoBL

            Dim dt As DataTable
            dt = opdt_pedidoBL.DETALLE_DOCUMENTOS_PENDIENTES(Me.hCodigo.Value)

            If dt.Rows(0)("DOCUMENTOPENDIENTES") <> 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "El pedido tiene documentos pendientes y no se puede Cambiar a Estado Recibido")
            Else
                Me.ActualizaEstadoRecibido()
            End If

        End Sub

        Private Sub LlenarComboEstados()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Estado_Pedido, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlEstado)

        End Sub
        Private Sub LlenarComboGrupoProducto()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Grupo_Productos, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlgrupoProducto)

        End Sub

        Private Sub LlenarComboGrupoOperacionComercial()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Grupo_Operacion_Comercial, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlgrupoOperacion)

        End Sub

        Private Sub LlenarComboZonal()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Zonas, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlZonal)

        End Sub

        Private Sub LlenarComboPaquete()
            Me.ddlPaquete.Items.Clear()
            Dim opdt_PaqueteBL As New pdt_paqueteBL()

            Dim dt As DataTable = opdt_PaqueteBL.Listar_Paquete()

            If Not (dt Is Nothing) Then
                Dim dw As DataView = dt.DefaultView
                dw.Sort = Enumeradores.Col_PAQUETE.paqtc_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                Me.ddlPaquete.DataSource = dw

            End If

            Me.ddlPaquete.DataTextField = Enumeradores.Col_PAQUETE.paqtc_vDescripcion.ToString()
            Me.ddlPaquete.DataValueField = Enumeradores.Col_PAQUETE.paqtc_iIdPaquete.ToString()
            Me.ddlPaquete.DataBind()

            HelperWeb.ComboAddItemTodos(Me.ddlPaquete)

        End Sub

        Private Sub LlenarComboSegmento()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Segmento, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlSegmento)

        End Sub

        Private Sub LlenarComboSubSegmento()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Sub_Segmento, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlSubSegmento)

        End Sub

        Private Sub LlenarComboProducto()
            Me.ddlProducto.Items.Clear()
            Dim opdt_prd_servicioBL As New pdt_prd_servicioBL()
            Dim dt As DataTable

            If ddlgrupoProducto.SelectedIndex = 0 Then
                dt = opdt_prd_servicioBL.Listar_PRD_SERVICIO(0)
            Else
                dt = opdt_prd_servicioBL.Listar_PRD_SERVICIO(Integer.Parse(ddlgrupoProducto.SelectedValue))
            End If

            If Not (dt Is Nothing) Then
                Dim dw As DataView = dt.DefaultView
                dw.Sort = Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                Me.ddlProducto.DataSource = dw

            End If

            Me.ddlProducto.DataTextField = Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString()
            Me.ddlProducto.DataValueField = Enumeradores.Col_PRD_SERVICIO.prsec_iIdPrd_Servicio.ToString()
            Me.ddlProducto.DataBind()

            HelperWeb.ComboAddItemTodos(Me.ddlProducto)

        End Sub

        Private Sub LlenarComboTipoOperacionComercial()
            Me.ddlTipoOperacion.Items.Clear()
            Dim opdt_tip_ope_comBL As New pdt_tip_ope_comBL
            Dim dt As DataTable

            If ddlgrupoOperacion.SelectedIndex = 0 Then
                dt = opdt_tip_ope_comBL.Listar_TIP_OPE_COM(0)
            Else
                dt = opdt_tip_ope_comBL.Listar_TIP_OPE_COM(Integer.Parse(ddlgrupoOperacion.SelectedValue))
            End If

            If Not (dt Is Nothing) Then
                Dim dw As DataView = dt.DefaultView
                dw.Sort = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                Me.ddlTipoOperacion.DataSource = dw

            End If

            Me.ddlTipoOperacion.DataTextField = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_vDescripcion.ToString()
            Me.ddlTipoOperacion.DataValueField = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_iIdTip_Ope_Com.ToString()
            Me.ddlTipoOperacion.DataBind()

            HelperWeb.ComboAddItemTodos(Me.ddlTipoOperacion)

        End Sub

        Private Sub LlenarComboFuente()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Fuente_Pedido, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlFuente)

        End Sub

        Private Sub LlenarComboEstacionIsis()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Fuente_Pedido, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlEstacionIsis)

        End Sub

        Private Sub LlenarComboDestino()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Fuente_Pedido, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlDestino)

        End Sub

        Private Sub LlenarComboCritico()
            Me.ddlCritico.Items.Clear()
            HelperWeb.ComboValidacionSiNo(Me.ddlCritico)

            HelperWeb.ComboAddItemTodos(Me.ddlCritico)

        End Sub

        Private Function ListarDataLlenarGrilla() As DataTable
            Try
                Dim oPedido As pdt_pedidoBL
                Dim intNumeroPedido As Integer
                Dim strCliente As String
                Dim intNumeroPedidoWeb As Integer
                Dim strTelefono As String
                Dim intEstadoWeb As Integer
                Dim intZonal As Integer
                Dim intPaquete As Integer
                Dim intSegmento As Integer
                Dim intSubSegmento As Integer
                Dim intEstacionIsis As Integer
                Dim intDestino As Integer
                Dim intGrupoProducto As Integer
                Dim intProducto As Integer
                Dim intGrupoOperacion As Integer
                Dim intTipoOperacionComercial As Integer                
                Dim intFuente As Integer
                Dim intCritico As Integer

                If rbtnlTipoBusqueda.Items(0).Selected = True Then 'Avanzado
                    strCliente = txtcliente1.Text
                Else    'Simple
                    strCliente = txtCliente.Text
                End If

                strTelefono = txtTelefono.Text

                If ddlCritico.SelectedIndex = 0 Then
                    intCritico = 0
                Else
                    intCritico = ddlCritico.SelectedValue
                End If

                If ddlFuente.SelectedIndex = 0 Then
                    intFuente = 0
                Else
                    intFuente = ddlFuente.SelectedValue.ToString
                End If

                If ddlSegmento.SelectedIndex = 0 Then
                    intSegmento = 0
                Else
                    intSegmento = ddlSegmento.SelectedValue.ToString
                End If

                If ddlSubSegmento.SelectedIndex = 0 Then
                    intSubSegmento = 0
                Else
                    intSubSegmento = ddlSubSegmento.SelectedValue.ToString
                End If

                If ddlEstacionIsis.SelectedIndex = 0 Or ddlEstacionIsis.SelectedIndex = -1 Then
                    intEstacionIsis = 0
                Else
                    intEstacionIsis = ddlEstacionIsis.SelectedValue.ToString
                End If

                If ddlDestino.SelectedIndex = 0 Or ddlDestino.SelectedIndex = -1 Then
                    intDestino = 0
                Else
                    intDestino = ddlDestino.SelectedValue.ToString
                End If

                If ddlgrupoProducto.SelectedIndex = 0 Then
                    intGrupoProducto = 0
                Else
                    intGrupoProducto = ddlgrupoProducto.SelectedValue.ToString
                End If

                If ddlProducto.SelectedIndex = 0 Then
                    intProducto = 0
                Else
                    intProducto = ddlProducto.SelectedValue.ToString
                End If

                If ddlgrupoOperacion.SelectedIndex = 0 Then
                    intGrupoOperacion = 0
                Else
                    intGrupoOperacion = ddlgrupoOperacion.SelectedValue.ToString
                End If

                If ddlTipoOperacion.SelectedIndex = 0 Then
                    intTipoOperacionComercial = 0
                Else
                    intTipoOperacionComercial = ddlTipoOperacion.SelectedValue.ToString
                End If

                If ddlEstado.SelectedIndex = 0 Then
                    intEstadoWeb = 0
                Else
                    intEstadoWeb = ddlEstado.SelectedValue.ToString
                End If

                If ddlZonal.SelectedIndex = 0 Then
                    intZonal = 0
                Else
                    intZonal = ddlZonal.SelectedValue.ToString
                End If

                If ddlPaquete.SelectedIndex = 0 Then
                    intPaquete = 0
                Else
                    intPaquete = ddlPaquete.SelectedValue.ToString
                End If

                intNumeroPedidoWeb = IIf(txtNumeroPedidoWeb.Text = "", 0, txtNumeroPedidoWeb.Text)

                If (hCodigo.Value.Length = 0) Then
                    intNumeroPedido = IIf(txtNumeroPedido.Text = "", 0, txtNumeroPedido.Text)
                Else
                    intNumeroPedido = hCodigo.Value
                End If

                Dim dt As DataTable = Nothing

                oPedido = New pdt_pedidoBL
                dt = oPedido.Listar_Pedido(intNumeroPedidoWeb, intNumeroPedido, strTelefono, strCliente, intEstadoWeb, intZonal, intPaquete, intFuente, intSegmento, intProducto, intGrupoProducto, intCritico)

                Return dt
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ex.Message, ConstantesWeb.MensajeError)
                Return Nothing
            End Try
        End Function

        Private Sub ReiniciarControles()
            Me.VisualizarControles(False)
            Me.VisualizarControlesDetalle(False)            
            Me.MostrarPanel()
            Me.hCodigo.Value = String.Empty
        End Sub

        Private Sub LimpiarControles()
            Me.txtNumeroPedido.Text = String.Empty
            Me.txtCliente.Text = String.Empty
            Me.txtNumeroPedidoWeb.Text = String.Empty
            Me.txtTelefono.Text = String.Empty
        End Sub

        'Private Sub MostrarPanel(ByVal nombreBoton As String)
        Private Sub MostrarPanel()
            'Dim strNombrePanel As String

            'strNombrePanel = nombreBoton.Replace("btn", "pnl")

            For Each oControl As Control In Me.pnlPaneles.Controls
                If TypeOf (oControl) Is Panel Then
                    'oControl.Visible = oControl.ID.Equals(strNombrePanel)
                    oControl.Visible = True
                End If
            Next

            'For Each oControl As Control In Me.pnlOpcionesCabecera.Controls
            '    If TypeOf (oControl) Is Button Then
            '        If nombreBoton.Length > 0 Then
            '            If oControl.ID.Equals(nombreBoton) Then
            '                CType(oControl, Button).CssClass = "InputBotonSeleccionado"
            '            Else
            '                CType(oControl, Button).CssClass = "InputBoton"
            '            End If
            '        End If
            '    End If
            'Next
        End Sub

        Private Sub LimpiaCajasTexto()
            Me.txtCliente.Text = ""
            Me.txtNumeroPedido.Text = ""
            Me.txtNumeroPedidoWeb.Text = ""
            Me.txtTelefono.Text = ""

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
                    Me.VisualizarControlesDetalle(False)
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub EventoClickListarCupos(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Try
                If Me.hCodigo.Value.Length > 0 And Me.hIdPedidoPrd.Value.Length > 0 Then
                    Dim intCodigo As Integer = Convert.ToInt32(Me.hCodigo.Value)
                    Dim intIdPedidoPrd As Integer = Convert.ToInt32(Me.hIdPedidoPrd.Value)

                    VisualizarControlesDetalle(True)
                    Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
                    Me.CuMasDatos1.ConsultarDatos(intCodigo, intIdPedidoPrd)
                    Me.CuSeguimiento1.NumeroPedidoWeb = intIdPedidoPrd
                    Me.CuSeguimiento1.LlenarGrilla()
                    Me.CuNuevoSeguimiento1.IdPedidoProducto = intCodigo
                    Me.CuNuevoSeguimiento1.CargarDatosControlUsuario(ScriptManager1)
                    Me.CuAdministracion1.IdPedidoProducto = intCodigo
                    Me.CuCargarDocumetoPedidoProducto1.LlenarGrillaDocumentos(intCodigo)

                End If

            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, "MensajeError")
            Finally
                Me.UpdatePanelTab.Update()
            End Try
        End Sub
        Protected Sub grid_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemCreated
            Dim elemType As New ListItemType
            elemType = e.Item.ItemType
            If ((elemType = ListItemType.Item) Or (elemType = ListItemType.AlternatingItem)) Then

                Dim lnkbNroPDT As LinkButton
                lnkbNroPDT = CType(e.Item.FindControl("lnkbNroPDT"), LinkButton)                
                AddHandler lnkbNroPDT.Click, AddressOf Me.EventoClickListarCupos

            End If

        End Sub

        Private Sub grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemDataBound

            If ((e.Item.ItemType = ListItemType.AlternatingItem) Or (e.Item.ItemType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Item.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row

                Dim lnkbNroPDT As LinkButton
                lnkbNroPDT = CType(e.Item.FindControl("lnkbNroPDT"), LinkButton)
                lnkbNroPDT.Text = CStr(dr.Item("pdtic_iIdPedido"))

                Dim lnkbIdentUnico As LinkButton
                lnkbIdentUnico = CType(e.Item.FindControl("lnkbIdentUnico"), LinkButton)
                lnkbIdentUnico.Text = CStr(dr.Item("pdtic_iCod_Gesneg"))

                Dim lblIdentUnico As Label
                lblIdentUnico = CType(e.Item.FindControl("lblIdentUnico"), Label)
                lblIdentUnico.Text = CStr(dr.Item("pdtic_iCod_Gesneg"))

                Dim lnkbFuente As LinkButton
                lnkbFuente = CType(e.Item.FindControl("lnkbFuente"), LinkButton)
                lnkbFuente.Text = CStr(dr.Item("desc_iFuente_Pedido"))

                Dim lblFuente As Label
                lblFuente = CType(e.Item.FindControl("lblFuente"), Label)
                lblFuente.Text = CStr(dr.Item("desc_iFuente_Pedido"))

                Dim lblFechaEmision As Label
                lblFechaEmision = CType(e.Item.FindControl("lblFechaEmision"), Label)
                lblFechaEmision.Text = CStr(dr.Item("pdtic_dFec_Contrato"))

                Dim lnkbCliente As LinkButton
                lnkbCliente = CType(e.Item.FindControl("lnkbCliente"), LinkButton)
                lnkbCliente.Text = CStr(dr.Item("pdtic_vNombre_Cliente"))

                Dim lblClienteTipo As Label
                lblClienteTipo = CType(e.Item.FindControl("lblClienteTipo"), Label)
                lblClienteTipo.Text = CStr(dr.Item("desc_Sub_Segmento"))

                Dim lnkbOperComer As LinkButton
                lnkbOperComer = CType(e.Item.FindControl("lnkbOperComer"), LinkButton)
                lnkbOperComer.Text = CStr(dr.Item("tococ_vDescripcion"))

                Dim lblZonal As Label
                lblZonal = CType(e.Item.FindControl("lblZonal"), Label)
                lblZonal.Text = CStr(dr.Item("desc_iZona_Pedido"))

                Dim lnkbProducto As LinkButton
                lnkbProducto = CType(e.Item.FindControl("lnkbProducto"), LinkButton)
                lnkbProducto.Text = CStr(dr.Item("prsec_vDescripcion"))

                Dim lblProducto As Label
                lblProducto = CType(e.Item.FindControl("lblProducto"), Label)
                lblProducto.Text = CStr(dr.Item("prsec_vDescripcion"))

                Dim lblModalidad As Label
                lblModalidad = CType(e.Item.FindControl("lblModalidad"), Label)
                lblModalidad.Text = CStr(dr.Item("pspsc_vDescripcion"))

                Dim lblCantidad As Label
                lblCantidad = CType(e.Item.FindControl("lblCantidad"), Label)
                lblCantidad.Text = CStr(dr.Item("pdtic_iCantidad_Prd"))

                Dim lblFechaUltSeg As Label
                lblFechaUltSeg = CType(e.Item.FindControl("lblFechaUltSeg"), Label)
                lblFechaUltSeg.Text = CStr(dr.Item("pdtic_dFec_Contrato"))

                Dim lblAntPDT As Label
                lblAntPDT = CType(e.Item.FindControl("lblAntPDT"), Label)
                lblAntPDT.Text = CStr(dr.Item("AntiguedadWeb"))

                Dim lblAntEmitido As Label
                lblAntEmitido = CType(e.Item.FindControl("lblAntEmitido"), Label)
                lblAntEmitido.Text = CStr(dr.Item("AntiguedadPedido"))

                Dim lblCritico As Label
                lblCritico = CType(e.Item.FindControl("lblCritico"), Label)
                lblCritico.Text = CStr(dr.Item("Critico"))

                Dim lblDocPublica As Label
                lblDocPublica = CType(e.Item.FindControl("lblDocPublica"), Label)
                lblDocPublica.Text = CStr(dr.Item("pdtic_iIdPedido"))

                Dim lblestadopedido As Label
                lblestadopedido = CType(e.Item.FindControl("lblestadopedido"), Label)
                lblestadopedido.Text = CStr(dr.Item("desc_iEstado_pedido"))

                Dim lblfechaCambioestado As Label
                lblfechaCambioestado = CType(e.Item.FindControl("lblfechaCambioestado"), Label)
                lblfechaCambioestado.Text = CStr(dr.Item("peesc_dFec_Modifica"))

                Dim lblDescripcionAlerta As Label
                lblDescripcionAlerta = CType(e.Item.FindControl("lblDescripcionAlerta"), Label)
                lblDescripcionAlerta.Text = CStr(dr.Item("cobic_vDescripcion"))

                Dim LblEstadoMarcadoCritico As Label
                LblEstadoMarcadoCritico = CType(e.Item.FindControl("LblEstadoMarcadoCritico"), Label)
                LblEstadoMarcadoCritico.Text = CStr(dr.Item("pdtic_dFec_Marca_Critico")) + " / " + CStr(dr.Item("UsuarioCritico"))

                'Dim LblDescricionProducto As Label
                'LblDescricionProducto = CType(e.Item.FindControl("LblDescricionProducto"), Label)
                'LblDescricionProducto.Text = CStr(dr.Item("prsec_vDescripcion"))

                Dim LblIdPedidoPrd As Label
                LblIdPedidoPrd = CType(e.Item.FindControl("LblIdPedidoPrd"), Label)
                LblIdPedidoPrd.Text = CStr(dr.Item("pdppc_iIdPedido_Prd"))
                
                Dim imgEmitible As Image
                imgEmitible = CType(e.Item.FindControl("imgEmitible"), Image)
                imgEmitible.ImageUrl = "../../Images/Body/Icons/Modificar.gif"

                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e)

                Dim IdRegistro As String = Convert.ToString(dr("pdtic_iIdPedido").ToString())
                Dim idRegistroDetalle As String = Convert.ToString(dr("pdppc_iIdPedido_Prd").ToString())

                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ID, IdRegistro.ToString())
                Cadena += HelperWeb.AsignarDatoControlHtml(Me.hIdPedidoPrd.ClientID, idRegistroDetalle.ToString())

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
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
            Try
                If txtNumeroPedido.Text.Trim.Length = 0 And txtCliente.Text.Trim.Length = 0 And _
                    txtNumeroPedidoWeb.Text.Length = 0 And txtTelefono.Text.Length = 0 Then
                    NetAjax.JsMensajeAlert(Me.Page, "Ingresa el número del pedido Legacie , Gesneg o Web, nombre del cliente o número de teléfono...")                    
                Else
                    Me.LlenarGrilla()
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, "MensajeError")
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlgrupoProducto)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlgrupoOperacion)

        End Sub

        Protected Sub btnListar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnListar.Click
            Try
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, "MensajeError")
            Finally
                Me.UpdatePanelGrilla.Update()
                Me.UpdatePanelFiltro.Update()
            End Try
        End Sub

        Protected Sub ddlgrupoProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgrupoProducto.SelectedIndexChanged
            Me.LlenarComboProducto()

        End Sub

        Protected Sub ddlgrupoOperacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgrupoOperacion.SelectedIndexChanged
            Me.LlenarComboTipoOperacionComercial()
        End Sub

        Protected Sub rbtnlTipoBusqueda_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnlTipoBusqueda.SelectedIndexChanged
            If Me.rbtnlTipoBusqueda.Items(0).Selected = True Then                
                Me.tFiltroAvanzado.Visible = True
                Me.tFiltroIndividual.Visible = False
                Me.lblRegistrosEncontrados.Visible = False
                Me.grid.Visible = False
                Me.UpdatePanelGrilla.Update()
                Me.pnlAcciones.Visible = False
                Me.pnlOpcionesCabecera.Visible = False
                Me.UpdatePanelTab.Update()
            Else
                Me.LimpiaCajasTexto()
                Me.tFiltroAvanzado.Visible = False
                Me.tFiltroIndividual.Visible = True
                Me.lblRegistrosEncontrados.Visible = False
                Me.grid.Visible = False
                Me.UpdatePanelGrilla.Update()
                Me.pnlAcciones.Visible = False
                Me.pnlOpcionesCabecera.Visible = False
                Me.UpdatePanelTab.Update()
            End If
        End Sub

        Protected Sub btnRecibido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecibido.Click            
            Me.DocumentosPendientes()

        End Sub

        Protected Sub btnRechazado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazado.Click
            Me.ActualizaEstadoRechazado()

        End Sub

        Protected Sub btnCrítico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrítico.Click
            Me.ActualizaEstadoCritico()

        End Sub

#End Region

        
    End Class

End Namespace
