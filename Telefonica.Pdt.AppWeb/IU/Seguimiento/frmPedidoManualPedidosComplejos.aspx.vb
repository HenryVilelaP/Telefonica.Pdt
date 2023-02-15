Imports System.Data
Imports System.Collections.Generic
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmPedidoManualPedidosComplejos
        Inherits WebPaginaBase
        Implements IPaginaBase        

#Region "Variables"
        Private intNumeroItem As Integer = 1
        Private intIdPedido As Integer
        Private intIdPaquete As Integer

        Private Structure DatosProducto
            Public IdProducto As Integer
            Public DescripcionProducto As String
            Public CantidadProductos As Integer
        End Structure

#End Region

#Region "Metodos Formulario"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            Try
                Dim hidPed As HtmlInputHidden = Nothing
                Dim hIdPaq As HtmlInputHidden = Nothing

                If Not Me.Page.PreviousPage Is Nothing Then
                    hidPed = CType(Me.Page.PreviousPage, frmPedidoManual).FindControl("hIdPedido")
                    hIdPaq = CType(Me.Page.PreviousPage, frmPedidoManual).FindControl("hIdPaquete")
                End If

                If Not hidPed Is Nothing And Not hIdPaq Is Nothing Then
                    Integer.TryParse(hidPed.Value, intIdPedido)
                    ViewState("IdPedido") = intIdPedido

                    Integer.TryParse(hIdPaq.Value, intIdPaquete)
                    ViewState("IdPaquete") = intIdPaquete

                ElseIf Not ViewState("IdPedido") Is Nothing And Not ViewState("IdPaquete") Then
                    Integer.TryParse(ViewState("IdPedido"), intIdPedido)
                    Integer.TryParse(ViewState("IdPaquete"), intIdPaquete)
                End If

                Me.HacerControlComandoNetAjax()

                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarCombos()
                    Me.LlenarDatos()
                    Me.MostrarTabDetalle()
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub gridPS_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPS.RowCreated
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim chk As New CheckBox
                Dim ddl As New DropDownList
                Dim ddlMod As New DropDownList

                chk = CType(e.Row.FindControl("chkIncluir"), CheckBox)
                If Not chk Is Nothing Then
                    AddHandler chk.CheckedChanged, AddressOf Me.ActivarFilaCheckedChanged
                End If

            End If
        End Sub

        Protected Sub gridPS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPS.RowDataBound
            Dim intCantidad As Nullable(Of Integer)

            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim drw As DataRowView
                Dim dr As DataRow
                Dim lbl As Label
                Dim ddl As DropDownList = Nothing
                Dim strNombreColumna As String

                drw = CType(e.Row.DataItem, DataRowView)
                dr = drw.Row

                lbl = e.Row.FindControl("lblNumeroItem")

                If Not lbl Is Nothing Then
                    lbl.Text = intNumeroItem.ToString()
                    intNumeroItem = intNumeroItem + 1
                End If

                lbl = e.Row.FindControl("lblIdProducto")

                If Not lbl Is Nothing Then
                    lbl.Text = dr("prsec_iIdPrd_Servicio")
                End If

                lbl = e.Row.FindControl("lblIdProducto")

                ddl = CType(e.Row.FindControl("ddlModalidad"), DropDownList)
                If Not ddl Is Nothing Then
                    ddl.Enabled = True
                    Me.LlenarComboModalidad(ddl, Convert.ToInt32(lbl.Text))
                    ddl.SelectedValue = ConstantesWeb.ValorAltaNueva
                End If

                lbl = e.Row.FindControl("lblProducto")

                If Not lbl Is Nothing Then
                    lbl.Text = dr("prsec_vDescripcion")
                End If

                Dim intIdEstadoRegistro As Integer
                Dim blnEsRegistroObligatorio As Boolean = False
                Dim blnRegistroHaSidoEliminado As Boolean
                Dim blnEsNuevo As Boolean

                Try
                    intCantidad = NullableTypes.ConvertNullInt32(dr(Enumeradores.Col_COTIZACION_PRD.coprc_iCantidad_Prd.ToString))
                    blnEsNuevo = Not intCantidad.HasValue
                Catch
                    blnEsNuevo = True
                End Try

                Try
                    intIdEstadoRegistro = Convert.ToInt32(dr(Enumeradores.Col_COTIZACION_PRD.coprc_iEstado_Registro.ToString))
                Catch
                    intIdEstadoRegistro = 1
                End Try

                blnRegistroHaSidoEliminado = (intIdEstadoRegistro = 0)

                Dim chk As CheckBox
                chk = e.Row.FindControl("chkIncluir")
                If Not chk Is Nothing Then
                    Dim intIndicadorObligatorio As Integer
                    strNombreColumna = Enumeradores.Col_PAQUETE_PRD_OPE_COM.ppocc_iInd_Obligatorio.ToString()
                    intIndicadorObligatorio = Convert.ToInt32(dr(strNombreColumna))
                    blnEsRegistroObligatorio = (intIndicadorObligatorio = Enumeradores.ValorBooleano.Si)
                    chk.Visible = Not blnEsRegistroObligatorio
                End If

                ddl = CType(e.Row.FindControl("ddlOperacionComercial"), DropDownList)
                If Not ddl Is Nothing Then
                    ddl.Enabled = False
                    Me.LlenarComboOperacionComercial(ddl)
                    ddl.SelectedValue = ConstantesWeb.ValorAltaNueva
                End If

                ddl = New DropDownList
                ddl = CType(e.Row.FindControl("ddlCantidad"), DropDownList)
                If Not ddl Is Nothing Then
                    ddl.Enabled = Not chk.Visible
                    Me.LlenarComboCantidad(ddl)
                End If

                ddl = New DropDownList
                ddl = CType(e.Row.FindControl("ddlTipoVenta"), DropDownList)
                If Not ddl Is Nothing Then
                    ddl.Enabled = Not chk.Visible
                    Me.LlenarComboTipoVenta(ddl)
                    ddl.SelectedValue = ConstantesWeb.ValorAltaNueva
                End If

                ddl = New DropDownList
                ddl = CType(e.Row.FindControl("ddlTipoContrato"), DropDownList)
                If Not ddl Is Nothing Then
                    ddl.Enabled = Not chk.Visible
                    Me.LlenarComboDuracionContrato(ddl)
                    ddl.SelectedValue = ConstantesWeb.ValorAltaNueva

                End If

            End If

        End Sub

        Private Sub ActivarFilaCheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            'Buscar Control en Grilla
            Dim gvr As GridViewRow = EncontrarFilaDelControl(Of CheckBox)(sender, gridPS)

            If Not gvr Is Nothing Then
                Dim chk As CheckBox = CType(gvr.FindControl("chkIncluir"), CheckBox)
                Dim ddl As DropDownList = Nothing

                ddl = New DropDownList
                ddl = CType(gvr.FindControl("ddlModalidad"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = chk.Checked
                End If

                ddl = New DropDownList
                ddl = CType(gvr.FindControl("ddlCantidad"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = chk.Checked
                End If

                ddl = New DropDownList
                ddl = CType(gvr.FindControl("ddlTipoVenta"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = chk.Checked
                End If

                ddl = New DropDownList
                ddl = CType(gvr.FindControl("ddlTipoContrato"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = chk.Checked
                End If
            End If

        End Sub

        Private Sub ValidarCamposObligatorios()
            Dim chk As CheckBox
            Dim ddl As DropDownList
            Dim lbl As Label
            Dim strb As New StringBuilder

            For i As Integer = 0 To gridPS.Rows.Count - 1

                chk = CType(gridPS.Rows(i).FindControl("chkIncluir"), CheckBox)
                If Not chk.Visible OrElse chk.Checked Then
                    ddl = CType(gridPS.Rows(i).FindControl("ddlCantidad"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.AppendLine("- Debe seleccionar la cantidad")
                        'SetFocus(ddl)
                    End If

                    ddl = CType(gridPS.Rows(i).FindControl("ddlTipoVenta"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.AppendLine("- Debe seleccionar el tipo de venta")
                        'SetFocus(ddl)
                    End If

                    ddl = CType(gridPS.Rows(i).FindControl("ddlTipoContrato"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.AppendLine("- Debe seleccionar el tipo de contrato")
                        'SetFocus(ddl)
                    End If
                End If

                If strb.Length > 0 Then
                    NetAjax.JsMensajeAlert(Me.Page, strb.ToString())
                End If
            Next
        End Sub

        

        
#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos

        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            If intIdPedido > 0 And intIdPaquete Then
                Dim objCotizacionBL As New pdt_cotizacionBL
                'Dim objCotizacion As COTIZACION

                'objCotizacion = objCotizacionBL.ObtenerCotizacion(intIdCotizacion)

                'Habilitar botones

                'Datos del cliente                
            End If
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla

        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            Dim strMensaje As String = HelperWeb.JsConfirmarAccionProceso("¿Desea grabar el detalle del pedido manual?")
            btnGrabarPedido.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick, strMensaje)

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

#End Region

#Region "Metodos Privados"

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnGrabarPedido)
        End Sub

        Private Sub MostrarTabDetalle()
            Me.Page.Validate()

            If Me.Page.IsValid Then
                ObtenerDatosPS()            
            End If

        End Sub

        Private Sub HabilitarCamposObligatorios()            
            'Me.HabilitarValidacionDatosPlantilla(btnTraerPlantilla.Enabled)
        End Sub


        Public Sub LlenarComboModalidad(ByVal ddl As DropDownList, ByVal pintIdProducto As Integer)
            If Not ddl Is Nothing Then
                Dim objCotizacionBL As New pdt_cotizacionBL()
                Dim dt As DataTable = objCotizacionBL.Listar_SubProductoPorProducto(pintIdProducto)
                HelperWeb.LlenarCombo(dt, _
                                    Enumeradores.Col_PRD_SERVICIO_SUB_PRD.psspc_iNum_Sub_Prd.ToString(), _
                                    Enumeradores.Col_PRD_SERVICIO_SUB_PRD.pspsc_vDescripcion.ToString(), _
                                    Enumeradores.TextoMostrarCombo.Seleccionar, ddl)
            End If
        End Sub

        Public Sub LlenarComboOperacionComercial(ByVal ddl As DropDownList)
            If Not ddl Is Nothing Then
                Dim objOperacionComercial As New pdt_tip_ope_comBL
                Dim dt As DataTable = objOperacionComercial.Listar_TIP_OPE_COM(1)
                HelperWeb.LlenarCombo(dt, _
                                    Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_iIdTip_Ope_Com.ToString(), _
                                    Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_vDescripcion.ToString(), _
                                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                                    ddl)
            End If
        End Sub

        Public Sub LlenarComboCantidad(ByVal ddl As DropDownList)
            If Not ddl Is Nothing Then
                Dim dt As DataTable = HelperWeb.RangoNumerosDataTable(1, 9)
                HelperWeb.LlenarCombo(dt, _
                                    "IdNumero", _
                                    "Numero", _
                                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                                    ddl)
            End If
        End Sub

        Public Sub LlenarComboTipoVenta(ByVal ddl As DropDownList)
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Forma_Adquisición, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddl)
        End Sub

        Public Sub LlenarComboDuracionContrato(ByVal ddl As DropDownList)
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Tiempo_Contrato, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddl)
        End Sub

        Private Sub CargarIdCotizacionPR(ByVal pobjListaProductos As List(Of COTIZACION_PRD))
            Dim gvrc As List(Of GridViewRow)
            Dim lbl As Label

            For Each objProducto As COTIZACION_PRD In pobjListaProductos
                gvrc = Me.EncontrarFilasDelValor(Of Label)(objProducto.Prsec_iIdPrd_Servicio.ToString(), _
                                                           "lblIdProducto", gridPS)
                For Each gvr As GridViewRow In gvrc
                    lbl = CType(gvr.FindControl("lblIdCotizacionPR"), Label)
                    lbl.Text = objProducto.Coprc_iIdCotizacion_Prd.ToString()
                    Exit For
                Next
            Next

        End Sub


        Private Function ObtenerListadoProductos() As List(Of COTIZACION_PRD)
            Dim gvr As GridViewRow
            Dim lbl As Label
            Dim ddl As DropDownList
            Dim chk As CheckBox
            Dim intNumeroProductos As Integer
            Dim intIdCotizacionPR As Integer
            Dim intIdProducto As Integer
            Dim intCantidadSubProductos As Integer
            Dim intIdFormaAdquisicion As Integer
            Dim intIdTiempoContrato As Integer
            Dim intIdDescuento As Nullable(Of Integer)
            Dim decPorcentajeIGV As Nullable(Of Decimal)
            Dim decMontoIGV As Nullable(Of Decimal)
            Dim decRenta As Nullable(Of Decimal)
            Dim decRentaConIGV As Nullable(Of Decimal)
            Dim decPorcentajeDescuento As Nullable(Of Decimal)
            Dim decMontoDescuento As Nullable(Of Decimal)
            Dim decMontoTotal As Nullable(Of Decimal)

            Dim objListaProductos As New List(Of COTIZACION_PRD)
            Dim objCOTIZACION_PRD As COTIZACION_PRD

            intNumeroProductos = gridPS.Rows.Count

            For i As Integer = 0 To intNumeroProductos - 1
                objCOTIZACION_PRD = New COTIZACION_PRD

                gvr = gridPS.Rows(i)

                chk = CType(gvr.FindControl("chkIncluir"), CheckBox)

                If Not chk.Visible OrElse chk.Checked Then

                    lbl = CType(gvr.FindControl("lblIdCotizacionPR"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        intIdCotizacionPR = Convert.ToInt32(lbl.Text)
                    Else
                        intIdCotizacionPR = 0
                    End If

                    lbl = CType(gvr.FindControl("lblIdProducto"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        intIdProducto = Convert.ToInt32(lbl.Text)
                    Else
                        intIdProducto = 0
                    End If

                    ddl = CType(gvr.FindControl("ddlCantidad"), DropDownList)
                    If Not ddl Is Nothing AndAlso _
                        ddl.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                        intCantidadSubProductos = Convert.ToInt32(ddl.SelectedValue)
                    Else
                        intCantidadSubProductos = 0
                    End If

                    ddl = CType(gvr.FindControl("ddlTipoVenta"), DropDownList)

                    If Not ddl Is Nothing AndAlso _
                        ddl.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                        intIdFormaAdquisicion = Convert.ToInt32(ddl.SelectedValue)
                    Else
                        intIdFormaAdquisicion = 0
                    End If

                    ddl = CType(gvr.FindControl("ddlTipoContrato"), DropDownList)

                    If Not ddl Is Nothing AndAlso _
                       ddl.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                        intIdTiempoContrato = Convert.ToInt32(ddl.SelectedValue)
                    Else
                        intIdTiempoContrato = 0
                    End If

                    lbl = CType(gvr.FindControl("lblIdDescuento"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        intIdDescuento = Convert.ToInt32(lbl.Text)
                    Else
                        intIdDescuento = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblPorcentajeIGV"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decPorcentajeIGV = Convert.ToDecimal(lbl.Text)
                    Else
                        decPorcentajeIGV = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblMontoIGV"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decMontoIGV = Convert.ToDecimal(lbl.Text)
                    Else
                        decMontoIGV = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblRenta"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decRenta = Convert.ToDecimal(lbl.Text)
                    Else
                        decRenta = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblRentaIGV"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decRentaConIGV = Convert.ToDecimal(lbl.Text)
                    Else
                        decRentaConIGV = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblPorcentajeDescuento"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decPorcentajeDescuento = Convert.ToDecimal(lbl.Text)
                    Else
                        decPorcentajeDescuento = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblMontoDescuento"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decMontoDescuento = Convert.ToDecimal(lbl.Text)
                    Else
                        decMontoDescuento = Nothing
                    End If

                    lbl = CType(gvr.FindControl("lblMontoTotal"), Label)
                    If lbl.Text.Trim().Length > 0 Then
                        decMontoTotal = Convert.ToDecimal(lbl.Text)
                    Else
                        decMontoTotal = Nothing
                    End If

                    objCOTIZACION_PRD.Coprc_iIdCotizacion_Prd = intIdCotizacionPR
                    objCOTIZACION_PRD.Cotic_iIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
                    objCOTIZACION_PRD.Prsec_iIdPrd_Servicio = intIdProducto
                    'objCOTIZACION_PRD.Paqtc_iIdPaquete = Convert.ToInt32(ddlPaquete.SelectedValue)
                    objCOTIZACION_PRD.Coprc_iCantidad_Prd = intCantidadSubProductos
                    objCOTIZACION_PRD.Tococ_iIdTip_Ope_Com = ConstantesWeb.ValorAltaNueva
                    objCOTIZACION_PRD.Vfadc_iIdForma_Adquisicion = intIdFormaAdquisicion
                    objCOTIZACION_PRD.Vtctc_iIdTiempo_Contrato = intIdTiempoContrato
                    objCOTIZACION_PRD.Coprc_nPorc_Igv = decPorcentajeIGV
                    objCOTIZACION_PRD.Coprc_nMonto_IGV = decMontoIGV
                    objCOTIZACION_PRD.Descc_iIdDescuento = intIdDescuento
                    objCOTIZACION_PRD.Coprc_nPrecio = decRenta
                    objCOTIZACION_PRD.Coprc_nPorc_Descuento = decPorcentajeDescuento
                    objCOTIZACION_PRD.Coprc_nMonto_Descuento = decMontoDescuento
                    objCOTIZACION_PRD.Coprc_nMonto_Total = decMontoTotal
                    objCOTIZACION_PRD.Coprc_iEstado_Registro = ConstantesWeb.ValorConstanteUno
                    objCOTIZACION_PRD.Coprc_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion

                    objListaProductos.Add(objCOTIZACION_PRD)
                End If
            Next

            If objListaProductos.Count = 0 Then
                objListaProductos = Nothing
            End If

            Return objListaProductos
        End Function

        Private Sub ObtenerDatosPS()
            Dim objCotizacionBL As New pdt_cotizacionBL
            Dim dt As DataTable

            'intIdPedido 
            'intIdPaquete 

            objCotizacionBL = New pdt_cotizacionBL
            dt = objCotizacionBL.Listar_PSPorPaqueteOC(intIdPaquete, ConstantesWeb.ValorAltaNueva)

            gridPS.DataSource = dt
            gridPS.DataBind()

            objCotizacionBL = Nothing

        End Sub

        Private Function EncontrarFilaDelControl(Of T)(ByVal pobjSender As Control, ByVal pobjGrid As GridView) As GridViewRow
            Dim gvr As GridViewRow = Nothing

            For i As Integer = 0 To (pobjGrid.Rows.Count - 1)
                Dim eg As New System.Web.UI.WebControls.GridViewRowEventArgs(pobjGrid.Rows(i))
                Dim objControl As Control = CType(Convert.ChangeType(pobjSender, GetType(T)), Control)
                Dim objControlGrilla As Control = CType(Convert.ChangeType(eg.Row.FindControl(pobjSender.ID), GetType(T)), Control)
                If (objControl.ClientID = objControlGrilla.ClientID) Then
                    gvr = eg.Row
                    i = pobjGrid.Rows.Count
                End If
            Next

            Return gvr

        End Function

        Private Sub HabilitarControlesGrillaPS(ByVal pblnOpcion As Boolean)
            Dim ddl As DropDownList
            Dim chk As CheckBox
            Dim blnMostrarCantidad As Boolean

            For i As Integer = 0 To gridPS.Rows.Count - 1
                chk = CType(gridPS.Rows(i).FindControl("chkIncluir"), CheckBox)
                If chk.Visible Then
                    chk.Enabled = pblnOpcion

                    If chk.Checked Then
                        blnMostrarCantidad = True
                    End If
                Else
                    blnMostrarCantidad = True
                End If

                If blnMostrarCantidad Then
                    ddl = CType(gridPS.Rows(i).FindControl("ddlCantidad"), DropDownList)
                    ddl.Enabled = pblnOpcion
                End If
            Next
        End Sub

        Private Sub LimpiarEtiquetasMontosGrillaPS()
            Dim lbl As Label

            For i As Integer = 0 To gridPS.Rows.Count - 1
                lbl = CType(gridPS.Rows(i).FindControl("lblRenta"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblPorcentajeIGV"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblMontoIGV"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblRentaIGV"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblIdDescuento"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblPorcentajeDescuento"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblMontoDescuento"), Label)
                lbl.Text = ""

                lbl = CType(gridPS.Rows(i).FindControl("lblMontoTotal"), Label)
                lbl.Text = ""
            Next
        End Sub

        Private Sub LimpiarEtiquetasMontosGrillaSubPS(ByVal pobjGvr As GridViewRow)
            Dim lbl As Label
            lbl = CType(pobjGvr.FindControl("lblCodigoPS"), Label)
            lbl.Text = ""

            lbl = CType(pobjGvr.FindControl("lblRenta"), Label)
            lbl.Text = ""

            lbl = CType(pobjGvr.FindControl("lblPorcentajeIGV"), Label)
            lbl.Text = ""

            lbl = CType(pobjGvr.FindControl("lblMontoIGV"), Label)
            lbl.Text = ""

            lbl = CType(pobjGvr.FindControl("lblRentaIGV"), Label)
            lbl.Text = ""
        End Sub

        Private Function EncontrarFilasDelValor(Of T)(ByVal pstrIdentificador As String, ByVal pstrIdControlBuscar As String, ByVal pobjGrid As GridView) As List(Of GridViewRow)
            Dim gvrc As New List(Of GridViewRow)
            Dim strValor As String = ""

            For i As Integer = 0 To (pobjGrid.Rows.Count - 1)
                Dim eg As New System.Web.UI.WebControls.GridViewRowEventArgs(pobjGrid.Rows(i))
                Dim objControlGrilla As Control = CType(Convert.ChangeType(eg.Row.FindControl(pstrIdControlBuscar), GetType(T)), Control)
                If TypeOf (objControlGrilla) Is T Then
                    If TypeOf (objControlGrilla) Is Label Then
                        strValor = CType(objControlGrilla, Label).Text
                    ElseIf TypeOf (objControlGrilla) Is TextBox Then
                        strValor = CType(objControlGrilla, Label).Text
                    ElseIf TypeOf (objControlGrilla) Is DropDownList Then
                        strValor = CType(objControlGrilla, DropDownList).SelectedValue.ToString()
                    End If

                    If pstrIdentificador.Equals(strValor) Then
                        gvrc.Add(eg.Row)
                    End If
                End If
            Next

            If gvrc.Count = 0 Then
                gvrc = Nothing
            End If

            Return gvrc

        End Function
#End Region

    End Class
End Namespace