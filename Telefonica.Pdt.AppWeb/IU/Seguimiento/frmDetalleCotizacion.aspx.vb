Imports System.Data
Imports System.Collections.Generic
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmDetalleCotizacion
        Inherits WebPaginaBase 'System.Web.UI.Page
        Implements IPaginaBase
        Implements IPaginaMantenimento

#Region "Variables"
        Private intIdCotizacion As Integer
        Private intNumeroItem As Integer = 1

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
                Dim hid As HtmlInputHidden = Nothing

                If Not Me.Page.PreviousPage Is Nothing Then
                    hid = CType(Me.Page.PreviousPage, frmAdminListaCotizacion).FindControl("hCodigo")
                End If

                If Not hid Is Nothing Then
                    Integer.TryParse(hid.Value, intIdCotizacion)
                    ViewState("IdCotizacion") = intIdCotizacion
                ElseIf Not ViewState("IdCotizacion") Is Nothing Then
                    Integer.TryParse(ViewState("IdCotizacion"), intIdCotizacion)
                End If

                Me.HacerControlComandoNetAjax()

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

        Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
            Me.BuscarUsuario()
        End Sub

        Protected Sub btnTraerPlantilla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTraerPlantilla.Click
            Me.MostrarTabDetalle()
            Me.UpdatePanelTabPanel.Update()
        End Sub

        Protected Sub ddlDepartamentoInstalacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartamentoInstalacion.SelectedIndexChanged
            LlenarComboProvinciaInstalacion(ddlDepartamentoInstalacion.SelectedItem.Value)
        End Sub

        Protected Sub ddlDepartamentoFacturacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartamentoFacturacion.SelectedIndexChanged
            LlenarComboProvinciaFacturacion(ddlDepartamentoFacturacion.SelectedItem.Value)
        End Sub

        Protected Sub ddlProvinciaInstalacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvinciaInstalacion.SelectedIndexChanged
            LlenarComboDistritoInstalacion(ddlDepartamentoInstalacion.SelectedItem.Value, ddlProvinciaInstalacion.SelectedItem.Value)
        End Sub

        Protected Sub ddlProvinciaFacturacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProvinciaFacturacion.SelectedIndexChanged
            LlenarComboDistritoFacturacion(ddlDepartamentoFacturacion.SelectedItem.Value, ddlProvinciaFacturacion.SelectedItem.Value)
        End Sub

        Protected Sub ddlTipoCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTipoCliente.SelectedIndexChanged
            If ddlTipoCliente.Items.Count > 0 Then
                Dim strCodigo As String
                strCodigo = ddlTipoCliente.SelectedValue

                If strCodigo.Equals(ConstantesWeb.ValorSeleccionar) Then
                    btnGrabar.Visible = False
                    txtRazonSocial.Enabled = False
                    txtNombres.Enabled = False
                    txtApellidoPaterno.Enabled = False
                    txtApellidoMaterno.Enabled = False
                    ddlTipoDocumentoIdentidad.Enabled = False
                    nbNumeroDocumetoIdentidad.Enabled = False
                Else
                    btnGrabar.Visible = True
                    ddlTipoDocumentoIdentidad.Enabled = True
                    nbNumeroDocumetoIdentidad.Enabled = True
                    HabilitarControlesPorTipoCliente(Integer.Parse(strCodigo))
                End If
                Me.UpdatePanelDatosCliente.Update()
            End If
        End Sub

        Protected Sub Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            Try
                Dim strMensaje As String

                strMensaje = Me.ValidarCamposObligatorios()
                If strMensaje.Trim().Length = 0 Then
                    Me.Grabar()
                    Me.MostrarTabsMasDatos(True)
                    Me.UpdatePanelTabPanel.Update()
                Else
                    NetAjax.JsMensajeAlert(Me.Page, strMensaje)
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Response.Redirect("~/IU/Seguimiento/frmadminlistacotizacion.aspx")
        End Sub

        Protected Sub btnCerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Dim objCotizacionBL As New pdt_cotizacionBL
                Dim intIdCotizacion As Integer

                If Not ViewState("IdCotizacion") Is Nothing Then
                    intIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
                    Dim intNumeroFilasAfectadas As Integer = objCotizacionBL.CambiarEstadoCotizacion(intIdCotizacion, ConstantesWeb.ValorCerrado, PAG_IdUsuario_InicioSesion)
                    If intNumeroFilasAfectadas = 1 Then
                        NetAjax.JsMensajeAlert(Me.Page, "Se cerró la cotización correctamente.")
                        btnGrabar.Enabled = False
                        btnImprimir.Enabled = True
                        btnExportar.Enabled = True
                    End If
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
            Try
                Dim objCotizacionBL As New pdt_cotizacionBL
                Dim intIdCotizacion As Integer

                If Not ViewState("IdCotizacion") Is Nothing Then
                    intIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
                    Dim intNumeroFilasAfectadas As Integer = objCotizacionBL.AprobarCotizacion(intIdCotizacion, PAG_IdUsuario_InicioSesion)
                    If intNumeroFilasAfectadas = 1 Then
                        NetAjax.JsMensajeAlert(Me.Page, "Se aprobó la cotización")
                    End If
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub gridPS_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridPS.RowCreated
            If (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim chk As New CheckBox
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
                    lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.prsec_iIdPrd_Servicio.ToString).ToString()
                End If

                lbl = e.Row.FindControl("lblProducto")

                If Not lbl Is Nothing Then
                    lbl.Text = dr(Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString).ToString()
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

                If Not blnEsNuevo Then
                    If Not ddl Is Nothing Then
                        If intCantidad.HasValue AndAlso Not blnRegistroHaSidoEliminado Then
                            ddl.SelectedValue = intCantidad.Value
                            chk.Checked = (intCantidad.Value > 0 And chk.Visible)
                        End If
                    End If

                    If Not blnRegistroHaSidoEliminado Then
                        lbl = e.Row.FindControl("lblIdCotizacionPR")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_iIdCotizacion_Prd.ToString).ToString()
                        End If


                        lbl = e.Row.FindControl("lblRenta")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nPrecio.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblIdDescuento")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.descc_iIdDescuento.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblPorcentajeIGV")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nPorc_Igv.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblMontoIGV")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nMonto_IGV.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblRentaIGV")

                        If Not lbl Is Nothing Then
                            Dim monto1 As Nullable(Of Decimal)
                            Dim monto2 As Nullable(Of Decimal)
                            monto1 = NullableTypes.ConvertNullDecimal(dr(Enumeradores.Col_COTIZACION_PRD.coprc_nPrecio.ToString))
                            monto2 = NullableTypes.ConvertNullDecimal(dr(Enumeradores.Col_COTIZACION_PRD.coprc_nMonto_IGV.ToString))
                            If monto1.HasValue AndAlso monto2.HasValue Then
                                lbl.Text = (monto1.Value + monto2.Value).ToString()
                            ElseIf monto1.HasValue And Not monto2.HasValue Then
                                lbl.Text = monto1.Value.ToString()
                            ElseIf Not monto1.HasValue And monto2.HasValue Then
                                lbl.Text = (monto2.Value).ToString()
                            End If
                        End If
                        lbl = e.Row.FindControl("lblPorcentajeDescuento")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nPorc_Descuento.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblMontoDescuento")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nMonto_Descuento.ToString).ToString()
                        End If

                        lbl = e.Row.FindControl("lblMontoTotal")

                        If Not lbl Is Nothing Then
                            lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD.coprc_nMonto_Total.ToString).ToString()
                        End If
                    End If
                End If

                Dim intIdentificador As Nullable(Of Integer)
                ddl = New DropDownList
                ddl = CType(e.Row.FindControl("ddlTipoVenta"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = Not chk.Visible
                    Me.LlenarComboTipoVenta(ddl)

                    If Not blnEsNuevo Then
                        intIdentificador = NullableTypes.ConvertNullInt32(dr(Enumeradores.Col_COTIZACION_PRD.vfadc_iIdForma_Adquisicion.ToString))
                        If (intIdentificador.HasValue AndAlso Not blnRegistroHaSidoEliminado) Then
                            ddl.SelectedValue = intIdentificador.Value
                        End If
                    End If
                End If

                ddl = New DropDownList
                ddl = CType(e.Row.FindControl("ddlTipoContrato"), DropDownList)

                If Not ddl Is Nothing Then
                    ddl.Enabled = Not chk.Visible
                    Me.LlenarComboDuracionContrato(ddl)

                    If Not blnEsNuevo Then
                        intIdentificador = NullableTypes.ConvertNullInt32(dr(Enumeradores.Col_COTIZACION_PRD.vtctc_iIdTiempo_Contrato.ToString))
                        If (intIdentificador.HasValue AndAlso Not blnRegistroHaSidoEliminado) Then
                            ddl.SelectedValue = intIdentificador.Value
                        End If
                    End If
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

            Me.UpdatePanelGrillaPS.Update()
        End Sub

        Protected Sub btnProcesar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcesar.Click
            Try
                Dim strMensaje As String
                strMensaje = Me.ValidarCamposObligatorios()

                If strMensaje.Trim().Length = 0 Then
                    Me.ObtenerDatosSubPS()
                    Me.MostrarGrillaSubPS(True)
                    Me.LimpiarEtiquetasMontosGrillaPS()
                    Me.UpdatePanelGrillaSubPS.Update()
                Else
                    NetAjax.JsMensajeAlert(Me.Page, strMensaje)
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Private Function ValidarCamposObligatorios() As String
            Dim chk As CheckBox
            Dim ddl As DropDownList
            Dim strb As New StringBuilder

            For i As Integer = 0 To gridPS.Rows.Count - 1

                chk = CType(gridPS.Rows(i).FindControl("chkIncluir"), CheckBox)
                If Not chk.Visible OrElse chk.Checked Then
                    ddl = CType(gridPS.Rows(i).FindControl("ddlCantidad"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.Append("- Debe seleccionar la cantidad \n")
                    End If

                    ddl = CType(gridPS.Rows(i).FindControl("ddlTipoVenta"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.Append("- Debe seleccionar el tipo de venta \n")

                    End If

                    ddl = CType(gridPS.Rows(i).FindControl("ddlTipoContrato"), DropDownList)
                    If ddl.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                        strb.Append("- Debe seleccionar el tipo de contrato \n")
                    End If

                    If strb.Length > 0 Then
                        Exit For
                    End If
                End If
            Next

            Return strb.ToString()
        End Function

        Protected Sub btnModificar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModificar.Click
            Try
                Me.MostrarGrillaSubPS(False)
                Me.UpdatePanelGrillaSubPS.Update()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub gridSubPS_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridSubPS.RowCreated
            Dim ddl As DropDownList

            ddl = CType(e.Row.FindControl("ddlProductoServicio"), DropDownList)
            If Not ddl Is Nothing Then
                AddHandler ddl.SelectedIndexChanged, AddressOf Me.ddlProductoServicio_SelectedIndexChanged
            End If
        End Sub

        Protected Sub gridSubPS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gridSubPS.RowDataBound
            If e.Row.RowType = DataControlRowType.DataRow Then
                Dim drw As DataRowView
                Dim dr As DataRow
                Dim lbl As Label
                Dim ddl As DropDownList = Nothing
                Dim intIdProducto As Integer

                drw = CType(e.Row.DataItem, DataRowView)
                dr = drw.Row

                intIdProducto = Convert.ToInt32(dr("prsec_iIdPrd_Servicio"))

                lbl = CType(e.Row.FindControl("lblIdProducto"), Label)
                If Not lbl Is Nothing Then
                    lbl.Text = intIdProducto.ToString()
                End If

                ddl = CType(e.Row.FindControl("ddlProductoServicio"), DropDownList)
                If Not ddl Is Nothing Then
                    Me.LlenarComboModalidad(ddl, intIdProducto)
                End If


                If dr.ItemArray.Length > 2 Then

                    If Not ddl Is Nothing Then
                        ddl.SelectedValue = dr(Enumeradores.Col_COTIZACION_PRD_SPR.psspc_iNum_Sub_Prd.ToString).ToString()
                    End If

                    lbl = e.Row.FindControl("lblIdCotizacionPR")
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.coprc_iIdCotizacion_Prd.ToString).ToString()
                    End If

                    lbl = e.Row.FindControl("lblIdCotizacionSubPR")
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospr_iIdCotizacion_Spr.ToString).ToString()
                    End If

                    lbl = CType(e.Row.FindControl("lblCodigoPS"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.psspc_iNum_Sub_Prd.ToString).ToString()
                    End If

                    lbl = CType(e.Row.FindControl("lblRenta"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_nPrecio.ToString).ToString()
                    End If

                    lbl = CType(e.Row.FindControl("lblPorcentajeIGV"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_nPorc_Igv.ToString).ToString()
                    End If

                    lbl = CType(e.Row.FindControl("lblMontoIGV"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_nMonto_IGV.ToString).ToString()
                    End If

                    lbl = CType(e.Row.FindControl("lblRentaIGV"), Label)
                    If Not lbl Is Nothing Then
                        lbl.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_nMonto_Total.ToString).ToString()
                    End If

                    Dim txt As TextBox
                    txt = CType(e.Row.FindControl("txtNumeroInscripcion"), TextBox)
                    If Not txt Is Nothing Then
                        txt.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_vNumero_Inscripcion.ToString).ToString()
                    End If

                    txt = CType(e.Row.FindControl("lblNumeroTelefono"), TextBox)
                    If Not txt Is Nothing Then
                        txt.Text = dr(Enumeradores.Col_COTIZACION_PRD_SPR.cospc_vNumero_Telefono.ToString).ToString()
                    End If
                End If
            End If
        End Sub

        Protected Sub ddlProductoServicio_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Me.EstablecerValoresGrillaSubPS(sender)
        End Sub
#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles
            Me.MostrarTabsMasDatos(False)
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboTipoDocumentoFiltro()
            Me.LlenarComboTipoDocumento()
            Me.LlenarComboTipoPersona()
            Me.LlenarComboCanalesVenta()
            Me.LlenarComboSegmento()
            Me.LlenarComboSubSegmento()
            Me.LlenarComboPaquete()
            Me.LlenarComboTipoVia()
            Me.LlenarComboDepartamentoInstalacion()
            Me.LlenarComboDepartamentoFacturacion()
            Me.LlenarComboProvinciaInstalacion(ddlDepartamentoInstalacion.SelectedItem.Value.ToString())
            Me.LlenarComboProvinciaFacturacion(ddlDepartamentoFacturacion.SelectedItem.Value.ToString())
            Me.LlenarComboDistritoInstalacion(ddlDepartamentoInstalacion.SelectedItem.Value.ToString(), _
                                            ddlProvinciaInstalacion.SelectedItem.Value.ToString())
            Me.LlenarComboDistritoFacturacion(ddlDepartamentoFacturacion.SelectedItem.Value.ToString(), _
                                            ddlProvinciaFacturacion.SelectedItem.Value.ToString())
            Me.LlenarComboProducto()
        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            If Not ViewState("IdCotizacion") Is Nothing Then
                intIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
            End If

            If intIdCotizacion > 0 Then
                Dim objCotizacionBL As New pdt_cotizacionBL
                Dim objCotizacion As COTIZACION

                objCotizacion = objCotizacionBL.ObtenerCotizacion(intIdCotizacion)

                'Habilitar botones
                Me.HabilitarBotones(objCotizacion)

                'Datos del cliente
                Me.LlenarDatosCliente(objCotizacion)

                'Datos del contacto
                Me.nbTelefonoContacto.Text = objCotizacion.Cotic_vTelefono_Contacto
                Me.txtPersonaContacto.Text = objCotizacion.Cotic_vNombre_Persona_Contacto

                If objCotizacion.Vcavc_iIdCanal_Venta.HasValue Then
                    Me.ddlCanalVenta.SelectedValue = objCotizacion.Vcavc_iIdCanal_Venta
                End If

                If objCotizacion.Paqtc_iIdPaquete.HasValue Then
                    Me.ddlPaquete.SelectedValue = objCotizacion.Paqtc_iIdPaquete.Value
                End If

                If objCotizacion.Segmc_iIdSegmento.HasValue Then
                    Me.ddlSegmento.SelectedValue = objCotizacion.Segmc_iIdSegmento
                End If

                If objCotizacion.Sessc_iNum_Sub_Segmento.HasValue Then
                    Me.ddlSubSegmento.SelectedValue = objCotizacion.Sessc_iNum_Sub_Segmento
                End If

                Me.txtCUC.Text = objCotizacion.Cotic_vCuc

                'Datos de la dirección de instalación
                If objCotizacion.Vviac_iIdTip_Via_Instalacion.HasValue Then
                    Me.ddlTipoViaInstalacion.SelectedValue = objCotizacion.Vviac_iIdTip_Via_Instalacion
                End If

                Me.txtNombreViaInstalacion.Text = objCotizacion.Cotic_vNombre_Via_Instalacion

                If objCotizacion.Cotic_iNum_Via_Instalacion.HasValue Then
                    Me.txtNumeroViaInstalacion.Text = objCotizacion.Cotic_iNum_Via_Instalacion
                End If

                Me.ddlDepartamentoInstalacion.SelectedValue = objCotizacion.Vdepc_vIdDepartamento_Instalacion
                If Me.ddlDepartamentoInstalacion.SelectedValue.ToString <> ConstantesWeb.ValorSeleccionar Then
                    ddlDepartamentoInstalacion_SelectedIndexChanged(Me, Nothing)
                End If

                Me.ddlProvinciaInstalacion.SelectedValue = objCotizacion.Vproc_vIdProvincia_Instalacion
                If Me.ddlProvinciaInstalacion.SelectedValue.ToString <> ConstantesWeb.ValorSeleccionar Then
                    ddlProvinciaInstalacion_SelectedIndexChanged(Me, Nothing)
                End If

                Me.ddlDistritoInstalacion.SelectedValue = objCotizacion.Vdisc_vIdDistrito_Instalacion

                'Datos de la dirección de facturación
                If objCotizacion.Vviac_iIdTip_Via_Facturacion.HasValue Then
                    Me.ddlTipoViaFacturacion.SelectedValue = objCotizacion.Vviac_iIdTip_Via_Facturacion
                End If

                Me.txtNombreViaFacturacion.Text = objCotizacion.Cotic_vNombre_Via_Facturacion

                If objCotizacion.Cotic_iNum_Via_Facturacion.HasValue Then
                    Me.txtNumeroViaFacturacion.Text = objCotizacion.Cotic_iNum_Via_Facturacion
                End If

                Me.ddlDepartamentoFacturacion.SelectedValue = objCotizacion.Vdepc_vIdDepartamento_Facturacion
                If Me.ddlDepartamentoFacturacion.SelectedValue.ToString <> ConstantesWeb.ValorSeleccionar Then
                    ddlDepartamentoFacturacion_SelectedIndexChanged(Me, Nothing)
                End If

                Me.ddlProvinciaFacturacion.SelectedValue = objCotizacion.Vproc_vIdProvincia_Facturacion
                If Me.ddlProvinciaFacturacion.SelectedValue.ToString <> ConstantesWeb.ValorSeleccionar Then
                    ddlProvinciaFacturacion_SelectedIndexChanged(Me, Nothing)
                End If

                Me.ddlDistritoFacturacion.SelectedValue = objCotizacion.Vdisc_vIdDistrito_Facturacion

                Me.MostrarTabsMasDatos(True)
                Me.HabilitarControlesPorTipoCliente(objCotizacion.Vtpec_iIdTip_Persona)
                Me.btnTraerPlantilla.Enabled = True
                Me.ValidarHabilitarTabDetalle()
            End If
        End Sub

        Private Sub HabilitarBotones(ByVal objCotizacion As COTIZACION)
            If objCotizacion.Vectc_iIdEstado_Cotizacion = ConstantesWeb.ValorAprobado Then
                btnGrabar.Enabled = False
                btnTraerPlantilla.Enabled = False
                btnCerrar.Enabled = False
                btnAprobar.Enabled = False
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            ElseIf objCotizacion.Vectc_iIdEstado_Cotizacion = ConstantesWeb.ValorCerrado Then
                btnGrabar.Enabled = False
                btnTraerPlantilla.Enabled = False
                btnCerrar.Enabled = False
                btnAprobar.Enabled = True
                btnImprimir.Enabled = True
                btnExportar.Enabled = True
            Else
                btnGrabar.Enabled = True
                btnTraerPlantilla.Enabled = True
                btnCerrar.Enabled = False
                btnAprobar.Enabled = False
                btnImprimir.Enabled = False
                btnExportar.Enabled = False
            End If
        End Sub

        Private Sub LlenarDatosCliente(ByVal pobjCotizacion As COTIZACION)
            Try
                If Not pobjCotizacion Is Nothing Then
                    Me.lblCotizacion.Text = pobjCotizacion.Cotic_iNum_Cotizacion.ToString() & "-" & pobjCotizacion.Cotic_iNum_Cotizacion_Version.ToString()
                    Me.ddlTipoCliente.SelectedValue = pobjCotizacion.Vtpec_iIdTip_Persona
                    Me.ddlTipoCliente_SelectedIndexChanged(Me, Nothing)

                    If pobjCotizacion.Vtpec_iIdTip_Persona = Enumeradores.TipoPersona.Natural Then
                        Me.txtNombres.Text = pobjCotizacion.Cotic_vNombre_Cliente
                        Me.txtApellidoPaterno.Text = pobjCotizacion.Cotic_vApellido_Paterno
                        Me.txtApellidoMaterno.Text = pobjCotizacion.Cotic_vApellido_Materno
                        Me.txtRazonSocial.Text = ""
                    Else
                        Me.txtNombres.Text = ""
                        Me.txtApellidoPaterno.Text = ""
                        Me.txtApellidoMaterno.Text = ""
                        Me.txtRazonSocial.Text = pobjCotizacion.Cotic_vRazon_Social
                    End If

                    Me.ddlTipoDocumentoIdentidad.SelectedValue = pobjCotizacion.Vtidc_iIdTip_Doc_Identidad
                    Me.nbNumeroDocumetoIdentidad.Text = pobjCotizacion.Cotic_vNum_Doc
                    Me.nbTelefonoReferencia.Text = pobjCotizacion.Cotic_vTelefono_Referencia

                    If pobjCotizacion.Cotic_iCodigo_Carterizado.HasValue Then
                        'Me.txtCarterizado.Text = pobjCotizacion.Cotic_iCodigo_Carterizado
                    End If

                    Me.UpdatePanelDatosCliente.Update()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla

        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.UpdateProgress1)

            Dim strMensaje As String = HelperWeb.JsConfirmarAccionProceso("¿Desea grabar los datos de la cotización?")
            btnGrabar.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick, strMensaje)

            strMensaje = HelperWeb.JsConfirmarAccionProceso("¿Desea cerrar esta cotización?")
            btnCerrar.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick, strMensaje)

            strMensaje = HelperWeb.JsConfirmarAccionProceso("¿Desea aprobar esta cotización?")
            btnAprobar.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick, strMensaje)

            strMensaje = HelperWeb.JsConfirmarAccionProceso("¿Desea agregar el producto escogido?")
            btnAceptar.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick, strMensaje)
        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

        Private Function ValidarHabilitarTabDetalle() As Boolean
            Dim blnResultado As Boolean = True

            blnResultado = blnResultado And Not ddlPaquete.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)
            blnResultado = blnResultado And (txtNombreViaInstalacion.Text.Trim().Length > 0)
            blnResultado = blnResultado And (txtNumeroViaInstalacion.Text.Trim().Length > 0)
            blnResultado = blnResultado And Not ddlDepartamentoInstalacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)
            blnResultado = blnResultado And Not ddlProvinciaInstalacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)
            blnResultado = blnResultado And Not ddlDistritoInstalacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)

            blnResultado = blnResultado And (txtNombreViaFacturacion.Text.Trim().Length > 0)
            blnResultado = blnResultado And (txtNumeroViaFacturacion.Text.Trim().Length > 0)
            blnResultado = blnResultado And Not ddlDepartamentoFacturacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)
            blnResultado = blnResultado And Not ddlProvinciaFacturacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)
            blnResultado = blnResultado And Not ddlDistritoFacturacion.SelectedValue.Equals(ConstantesWeb.ValorSeleccionar)

            TabPanel5.Enabled = False

            If blnResultado Then
                Dim pdt_cotizacionBL As New pdt_cotizacionBL()
                Dim dtProducto As DataTable
                Dim dtSubProducto As DataTable

                dtProducto = pdt_cotizacionBL.ListarCotizacionProducto(intIdCotizacion)
                dtSubProducto = pdt_cotizacionBL.ListarCotizacionSubProducto(intIdCotizacion)

                If (Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0) And _
                   (Not dtSubProducto Is Nothing AndAlso dtSubProducto.Rows.Count > 0) Then

                    Me.CargarValoresGrillaPS(dtProducto)
                    Me.CargarValoresGrillaSubPS(dtSubProducto)
                    Me.MostrarGrillaSubPS(True)

                    TabPanel5.Enabled = True
                End If
            End If
        End Function

        Private Sub CargarValoresGrillaPS(ByVal pDt As DataTable)
            Me.gridPS.DataSource = pDt
            Me.gridPS.DataBind()
        End Sub

        Private Sub CargarValoresGrillaSubPS(ByVal pDt As DataTable)
            Me.gridSubPS.DataSource = pDt
            Me.gridSubPS.DataBind()
        End Sub
#End Region

#Region "Metodos Privados"

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnGrabar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnTraerPlantilla)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnCerrar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnAprobar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnImprimir)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnExportar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnModificar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnProcesar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnAgregar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnAceptar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.ddlProducto)
        End Sub

        Private Sub HabilitarControlesPorTipoCliente(ByVal pintCodigoTipoCliente As Integer)
            If pintCodigoTipoCliente = Enumeradores.TipoPersona.Natural Then
                txtRazonSocial.Enabled = False
                txtNombres.Enabled = True
                txtApellidoPaterno.Enabled = True
                txtApellidoMaterno.Enabled = True
                txtRazonSocial.CssClass = "InputTextoFijo"
                txtNombres.CssClass = "InputTexto"
                txtApellidoPaterno.CssClass = "InputTexto"
                txtApellidoMaterno.CssClass = "InputTexto"
            ElseIf pintCodigoTipoCliente = Enumeradores.TipoPersona.Juridica Then
                txtRazonSocial.Enabled = True
                txtNombres.Enabled = False
                txtApellidoPaterno.Enabled = False
                txtApellidoMaterno.Enabled = False
                txtRazonSocial.CssClass = "InputTexto"
                txtNombres.CssClass = "InputTextoFijo"
                txtApellidoPaterno.CssClass = "InputTextoFijo"
                txtApellidoMaterno.CssClass = "InputTextoFijo"
            End If
        End Sub

        Private Sub MostrarTabsMasDatos(ByVal pblnOpcion As Boolean)
            Me.TabPanel2.Enabled = pblnOpcion
            Me.TabPanel3.Enabled = pblnOpcion
            Me.TabPanel4.Enabled = pblnOpcion
        End Sub

        Private Sub MostrarTabDetalle()
            Me.HabilitarValidacionPorTipoCliente()
            Me.HabilitarValidacionDatosPlantilla(True)
            Me.Page.Validate()
            Me.TabPanel5.Enabled = Me.Page.IsValid

            If Me.Page.IsValid Then
                ObtenerDatosPS()
                UpdatePanelGrillaPS.Update()

                If gridPS.Rows.Count > 0 Then
                    Me.TabContainer1.ActiveTab = Me.TabPanel5
                    Me.MostrarBotonesGrillaPS(True)
                Else
                    Me.TabPanel5.Enabled = False
                    NetAjax.JsMensajeAlert(Me.Page, "No se encontraron productos para el paquete seleccionado")
                    Me.MostrarBotonesGrillaPS(False)
                End If
            Else
                'Dim strMensaje As String
                'strMensaje = "javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions('btnConsultar', '', true, '', '', false, false))"

                'NetAjax.JsLanzarExecutarScriptRecargarPagina(Me.Page, Me.Page.GetType(), "ShowValidationSummary", strMensaje, True)
            End If
        End Sub

        Private Sub MostrarBotonesGrillaPS(ByVal blnMostrar)
            Me.btnModificar.Visible = blnMostrar
            Me.btnProcesar.Visible = blnMostrar
        End Sub

        Private Sub MostrarBotonesGrillaSubPS(ByVal blnMostrar)
            Me.btnAgregar.Visible = blnMostrar
            Me.btnCalcular.Visible = blnMostrar
            Me.pnlVentanaSeleccionarSubProducto.Visible = blnMostrar
        End Sub

        Private Sub HabilitarValidacionPorTipoCliente()
            Dim intTipoPersona As Integer

            Me.rfvTipoCliente.Enabled = True
            Me.rfvTipoDocumentoIdentidad.Enabled = True
            Me.rfvNumeroDocumetoIdentidad.Enabled = True

            Integer.TryParse(ddlTipoCliente.SelectedValue, intTipoPersona)
            If intTipoPersona = Enumeradores.TipoPersona.Natural Then
                Me.HabilitarValidacionDatosCliente(True)
            Else
                Me.HabilitarValidacionDatosCliente(False)
            End If
        End Sub

        Private Sub HabilitarValidacionDatosCliente(ByVal blnHabilitado As Boolean)
            rfvNombres.Enabled = blnHabilitado
            rfvApellidoPaterno.Enabled = blnHabilitado
            rfvApellidoMaterno.Enabled = blnHabilitado
            rfvRazonSocial.Enabled = Not blnHabilitado
        End Sub

        Private Sub HabilitarValidacionDatosPlantilla(ByVal blnHabilitar As Boolean)
            rfvPaquete.Enabled = blnHabilitar
            rfvSubSegmento.Enabled = blnHabilitar
            rfvSegmento.Enabled = blnHabilitar
            rfvNumeroViaInstalacion.Enabled = blnHabilitar
            rfvNombreViaInstalacion.Enabled = blnHabilitar

            rfvDepartamentoInstalacion.Enabled = blnHabilitar
            rfvProvinciaInstalacion.Enabled = blnHabilitar
            rfvDistritoInstalación.Enabled = blnHabilitar

            rfvNumeroViaFacturacion.Enabled = blnHabilitar
            rfvNombreViaFacturacion.Enabled = blnHabilitar

            rfvDepartamentoFacturacion.Enabled = blnHabilitar
            rfvProvinciaFacturacion.Enabled = blnHabilitar
            rfvDistritoFacturacion.Enabled = blnHabilitar
        End Sub

        Private Sub HabilitarCamposObligatorios()
            Me.HabilitarValidacionPorTipoCliente()
            Me.HabilitarValidacionDatosPlantilla(btnTraerPlantilla.Enabled)
        End Sub

        Private Sub LlenarComboTipoDocumentoFiltro()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                    Enumeradores.Cabecera_Tabla_Tablas.Tab_Documento_Identidad_Personal, _
                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                    ddlTipoDocumentoFiltro)
        End Sub

        Private Sub LlenarComboTipoDocumento()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                        Enumeradores.Cabecera_Tabla_Tablas.Tab_Documento_Identidad_Personal, _
                        Enumeradores.TextoMostrarCombo.Seleccionar, _
                        ddlTipoDocumentoIdentidad)
        End Sub

        Private Sub LlenarComboTipoPersona()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                Enumeradores.Cabecera_Tabla_Tablas.Tab_Tipo_Persona, _
                Enumeradores.TextoMostrarCombo.Seleccionar, _
                ddlTipoCliente)
        End Sub

        Private Sub LlenarComboCanalesVenta()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                Enumeradores.Cabecera_Tabla_Tablas.Tab_Canales_Venta, _
                Enumeradores.TextoMostrarCombo.Seleccionar, _
                ddlCanalVenta)
        End Sub

        Private Sub LlenarComboSegmento()
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Segmento, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddlSegmento)
        End Sub

        Private Sub LlenarComboSubSegmento()
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Sub_Segmento, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddlSubSegmento)
        End Sub

        Private Sub LlenarComboPaquete()
            Dim dt As DataTable
            Dim objPaqueteBL As New pdt_paqueteBL
            dt = objPaqueteBL.Listar_PaquetePorFamilia(ConstantesWeb.ValorPaqueteComplejo)
            HelperWeb.LlenarCombo(dt, _
                                Enumeradores.Col_PAQUETE.paqtc_iIdPaquete.ToString(), _
                                Enumeradores.Col_PAQUETE.paqtc_vDescripcion.ToString(), _
                                Enumeradores.TextoMostrarCombo.Seleccionar, _
                                ddlPaquete)
        End Sub

        Private Sub LlenarComboTipoVia()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                Enumeradores.Cabecera_Tabla_Tablas.Tab_Tipo_Via, _
                Enumeradores.TextoMostrarCombo.Seleccionar, _
                ddlTipoViaInstalacion)
            HelperWeb.LlenarComboRegistroTablaTablas( _
                Enumeradores.Cabecera_Tabla_Tablas.Tab_Tipo_Via, _
                Enumeradores.TextoMostrarCombo.Seleccionar, _
                ddlTipoViaFacturacion)
        End Sub

        Private Sub LlenarComboDepartamentoInstalacion()
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_Departamentos()
            HelperWeb.LlenarCombo(dt, "vdepc_vIdDepartamento", "vdepc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlDepartamentoInstalacion)
        End Sub

        Private Sub LlenarComboDepartamentoFacturacion()
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_Departamentos()
            HelperWeb.LlenarCombo(dt, "vdepc_vIdDepartamento", "vdepc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlDepartamentoFacturacion)
        End Sub

        Private Sub LlenarComboProvinciaInstalacion(ByVal pstrIdDepartamento As String)
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_ProvinciaPorDepartamento(pstrIdDepartamento)
            HelperWeb.LlenarCombo(dt, "vproc_vIdProvincia", "vproc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlProvinciaInstalacion)
        End Sub

        Private Sub LlenarComboProvinciaFacturacion(ByVal pstrIdDepartamento As String)
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_ProvinciaPorDepartamento(pstrIdDepartamento)
            HelperWeb.LlenarCombo(dt, "vproc_vIdProvincia", "vproc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlProvinciaFacturacion)
        End Sub

        Private Sub LlenarComboDistritoInstalacion(ByVal pstrIdDepartamento As String, ByVal pstrIdProvincia As String)
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_DistritoPorProvincia(pstrIdDepartamento, pstrIdProvincia)
            HelperWeb.LlenarCombo(dt, "vdisc_vIdDistrito", "vdisc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlDistritoInstalacion)
        End Sub

        Private Sub LlenarComboDistritoFacturacion(ByVal pstrIdDepartamento As String, ByVal pstrIdProvincia As String)
            Dim dt As DataTable
            Dim objUbigeoBL As New pdt_ubigeoBL
            dt = objUbigeoBL.Listar_DistritoPorProvincia(pstrIdDepartamento, pstrIdProvincia)
            HelperWeb.LlenarCombo(dt, "vdisc_vIdDistrito", "vdisc_vNombre", Enumeradores.TextoMostrarCombo.Seleccionar, ddlDistritoFacturacion)
        End Sub

        Private Sub LlenarComboModalidad(ByVal ddl As DropDownList, ByVal pintIdProducto As Integer)
            If Not ddl Is Nothing Then
                Dim objCotizacionBL As New pdt_cotizacionBL()
                Dim dt As DataTable = objCotizacionBL.Listar_SubProductoPorProducto(pintIdProducto)
                HelperWeb.LlenarCombo(dt, _
                                    Enumeradores.Col_PRD_SERVICIO_SUB_PRD.psspc_iNum_Sub_Prd.ToString(), _
                                    Enumeradores.Col_PRD_SERVICIO_SUB_PRD.pspsc_vDescripcion.ToString(), _
                                    Enumeradores.TextoMostrarCombo.Seleccionar, ddl)
            End If
        End Sub

        Private Sub LlenarComboOperacionComercial(ByVal ddl As DropDownList)
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

        Private Sub LlenarComboCantidad(ByVal ddl As DropDownList)
            If Not ddl Is Nothing Then
                Dim dt As DataTable = HelperWeb.RangoNumerosDataTable(1, 9)
                HelperWeb.LlenarCombo(dt, _
                                    "IdNumero", _
                                    "Numero", _
                                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                                    ddl)
            End If
        End Sub

        Private Sub LlenarComboTipoVenta(ByVal ddl As DropDownList)
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Forma_Adquisición, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddl)
        End Sub

        Private Sub LlenarComboDuracionContrato(ByVal ddl As DropDownList)
            HelperWeb.LlenarComboRegistroTablaTablas( _
               Enumeradores.Cabecera_Tabla_Tablas.Tab_Tiempo_Contrato, _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddl)
        End Sub

        Private Sub LlenarComboProducto()
            Dim dt As DataTable
            Dim objCotizacionBL As New pdt_cotizacionBL
            dt = objCotizacionBL.ListarProductos()
            HelperWeb.LlenarCombo(dt, _
               Enumeradores.Col_PRD_SERVICIO.prsec_iIdPrd_Servicio.ToString(), _
               Enumeradores.Col_PRD_SERVICIO.prsec_vDescripcion.ToString(), _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddlProducto)
            Me.ddlProducto_SelectedIndexChanged(Me.Page, Nothing)
        End Sub

        Private Sub LlenarComboSubProducto(ByVal intIdProducto As Integer)
            Dim dt As DataTable
            Dim objCotizacionBL As New pdt_cotizacionBL
            dt = objCotizacionBL.ListarSubProductos(intIdProducto)

            HelperWeb.LlenarCombo(dt, _
               Enumeradores.Col_PRD_SERVICIO_SUB_PRD.psspc_iNum_Sub_Prd.ToString(), _
               Enumeradores.Col_PRD_SERVICIO_SUB_PRD.pspsc_vDescripcion.ToString(), _
               Enumeradores.TextoMostrarCombo.Seleccionar, _
               ddlSubProducto)
        End Sub

        Private Sub Grabar()
            Me.Grabar(True)
        End Sub

        Private Sub Grabar(ByVal blnMostrarMensaje As Boolean)
            Dim objCotizacionBL As New pdt_cotizacionBL
            Dim objCotizacion As New COTIZACION
            Dim intCodigoTipoCliente As Integer

            Me.HabilitarCamposObligatorios()
            Me.Page.Validate()

            If Page.IsValid() Then

                If Not ViewState("IdCotizacion") Is Nothing Then
                    intIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
                End If

                If intIdCotizacion > 0 Then
                    objCotizacion = objCotizacionBL.ObtenerCotizacion(intIdCotizacion)
                End If

                'Datos del cliente
                Dim arrayNumeroCotizacion As String()

                If Me.lblCotizacion.Text.Trim().Length > 0 Then
                    Me.lblCotizacion.Text = Me.lblCotizacion.Text.Replace(" ", "")
                    arrayNumeroCotizacion = Me.lblCotizacion.Text.Split("-")

                    objCotizacion.Cotic_iNum_Cotizacion = arrayNumeroCotizacion(0)
                    objCotizacion.Cotic_iNum_Cotizacion_Version = arrayNumeroCotizacion(1)
                End If

                objCotizacion.Vtpec_iIdTip_Persona = Me.ddlTipoCliente.SelectedValue

                Integer.TryParse(ddlTipoCliente.SelectedValue.ToString(), intCodigoTipoCliente)

                If intCodigoTipoCliente = Enumeradores.TipoPersona.Natural Then
                    objCotizacion.Cotic_vNombre_Cliente = Me.txtNombres.Text
                    objCotizacion.Cotic_vApellido_Paterno = Me.txtApellidoPaterno.Text
                    objCotizacion.Cotic_vApellido_Materno = Me.txtApellidoMaterno.Text
                    objCotizacion.Cotic_vRazon_Social = Me.txtNombres.Text & " " & Me.txtApellidoPaterno.Text & " " & Me.txtApellidoMaterno.Text
                Else
                    objCotizacion.Cotic_vNombre_Cliente = ""
                    objCotizacion.Cotic_vApellido_Paterno = ""
                    objCotizacion.Cotic_vApellido_Materno = ""
                    objCotizacion.Cotic_vRazon_Social = Me.txtRazonSocial.Text
                End If

                Integer.TryParse(Me.ddlTipoDocumentoIdentidad.SelectedValue, objCotizacion.Vtidc_iIdTip_Doc_Identidad)
                objCotizacion.Cotic_vNum_Doc = Me.nbNumeroDocumetoIdentidad.Text

                objCotizacion.Cotic_vTelefono_Referencia = Me.nbTelefonoReferencia.Text

                'Datos del contacto
                objCotizacion.Cotic_vTelefono_Contacto = Me.nbTelefonoContacto.Text
                objCotizacion.Cotic_vNombre_Persona_Contacto = Me.txtPersonaContacto.Text

                If Me.ddlCanalVenta.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vcavc_iIdCanal_Venta = Convert.ToInt32(Me.ddlCanalVenta.SelectedValue)
                End If

                If Me.ddlPaquete.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Paqtc_iIdPaquete = Convert.ToInt32(Me.ddlPaquete.SelectedValue)
                End If

                If Me.ddlSegmento.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Segmc_iIdSegmento = Convert.ToInt32(Me.ddlSegmento.SelectedValue)
                End If

                If Me.ddlSubSegmento.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Sessc_iNum_Sub_Segmento = Convert.ToInt32(Me.ddlSubSegmento.SelectedValue)
                End If

                objCotizacion.Cotic_vCuc = Me.txtCUC.Text

                'Datos de la dirección de instalación
                If Me.ddlTipoViaInstalacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vviac_iIdTip_Via_Instalacion = Convert.ToInt32(Me.ddlTipoViaInstalacion.SelectedValue)
                End If

                objCotizacion.Cotic_vNombre_Via_Instalacion = Me.txtNombreViaInstalacion.Text

                If Me.txtNumeroViaInstalacion.Text.Trim().Length > 0 Then
                    objCotizacion.Cotic_iNum_Via_Instalacion = Convert.ToInt32(Me.txtNumeroViaInstalacion.Text)
                Else
                    objCotizacion.Cotic_iNum_Via_Instalacion = Nothing
                End If

                If Me.ddlDepartamentoInstalacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vdepc_vIdDepartamento_Instalacion = Me.ddlDepartamentoInstalacion.SelectedValue.ToString()
                End If

                If Me.ddlProvinciaInstalacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vproc_vIdProvincia_Instalacion = Me.ddlProvinciaInstalacion.SelectedValue.ToString()
                End If

                If Me.ddlDistritoInstalacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vdisc_vIdDistrito_Instalacion = Me.ddlDistritoInstalacion.SelectedValue.ToString()
                End If

                'Datos de la dirección de facturación
                If Me.ddlTipoViaFacturacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vviac_iIdTip_Via_Facturacion = Convert.ToInt32(Me.ddlTipoViaFacturacion.SelectedValue)
                End If

                objCotizacion.Cotic_vNombre_Via_Facturacion = Me.txtNombreViaFacturacion.Text

                If Me.txtNumeroViaFacturacion.Text.Trim().Length > 0 Then
                    objCotizacion.Cotic_iNum_Via_Facturacion = Convert.ToInt32(Me.txtNumeroViaFacturacion.Text)
                Else
                    objCotizacion.Cotic_iNum_Via_Facturacion = Nothing
                End If

                If Me.ddlDepartamentoFacturacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vdepc_vIdDepartamento_Facturacion = Me.ddlDepartamentoFacturacion.SelectedValue.ToString()
                End If

                If Me.ddlProvinciaFacturacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vproc_vIdProvincia_Facturacion = Me.ddlProvinciaFacturacion.SelectedValue.ToString()
                End If
                If Me.ddlDistritoFacturacion.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                    objCotizacion.Vdisc_vIdDistrito_Facturacion = Me.ddlDistritoFacturacion.SelectedValue.ToString()
                End If

                objCotizacion.Vectc_iIdEstado_Cotizacion = ConstantesWeb.ValorConstanteUno
                objCotizacion.Cotic_iEstado_Registro = ConstantesWeb.ValorConstanteUno

                Dim strMensaje As String = ""
                Dim intNumeroRegistrosAfectados As Integer
                Dim objListaProductos As List(Of COTIZACION_PRD)
                Dim objListaSubProductos As List(Of COTIZACION_PRD_SPR)

                objListaProductos = Me.ObtenerListadoProductos()

                objListaSubProductos = Me.ObtenerListadoSubProductos()
                Dim blnEsNuevo As Boolean
                blnEsNuevo = (objCotizacion.Cotic_iIdCotizacion = 0)

                If blnEsNuevo Then
                    objCotizacion.Cotic_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion

                    Dim intIdCotizacion As String
                    intIdCotizacion = objCotizacionBL.InsertarCotizacion(objCotizacion, objListaProductos, objListaSubProductos)

                    If intIdCotizacion > -1 Then
                        ViewState.Item("IdCotizacion") = intIdCotizacion
                        objCotizacion = objCotizacionBL.ObtenerCotizacion(intIdCotizacion)
                        lblCotizacion.Text = objCotizacion.Cotic_iNum_Cotizacion.ToString() & "-" & objCotizacion.Cotic_iNum_Cotizacion_Version.ToString()
                        strMensaje = ConstantesWeb.MensajeConfirmacionRegistro
                    Else
                    End If
                Else
                    objCotizacion.Cotic_iIdUsuario_Modifica = Me.PAG_IdUsuario_InicioSesion
                    intNumeroRegistrosAfectados = objCotizacionBL.ModificarCotizacion(objCotizacion, objListaProductos, objListaSubProductos)

                    If intNumeroRegistrosAfectados > 0 Then
                        strMensaje = ConstantesWeb.MensajeConfirmacionModificacion
                        Me.btnTraerPlantilla.Enabled = True
                        Me.UpdatePanelBotones.Update()
                    Else
                    End If
                End If

                If blnMostrarMensaje AndAlso strMensaje.Trim().Length > 0 Then
                    NetAjax.JsMensajeAlert(Me.Page, strMensaje)
                    Me.CargarIdCotizacionPR(objListaProductos)
                    Me.CargarIdCotizacionSubPR(objListaSubProductos)
                End If

                objCotizacionBL = Nothing
            End If
        End Sub

        Private Sub CargarIdCotizacionPR(ByVal pobjListaProductos As List(Of COTIZACION_PRD))
            Dim gvrc As List(Of GridViewRow)
            Dim lbl As Label

            If Not pobjListaProductos Is Nothing Then
                For Each objProducto As COTIZACION_PRD In pobjListaProductos
                    gvrc = Me.EncontrarFilasDelValor(Of Label)(objProducto.Prsec_iIdPrd_Servicio.ToString(), _
                                                               "lblIdProducto", gridPS)
                    For Each gvr As GridViewRow In gvrc
                        lbl = CType(gvr.FindControl("lblIdCotizacionPR"), Label)
                        lbl.Text = objProducto.Coprc_iIdCotizacion_Prd.ToString()
                        Exit For
                    Next
                Next
            End If

        End Sub

        Private Sub CargarIdCotizacionSubPR(ByVal pobjListaSubProductos As List(Of COTIZACION_PRD_SPR))
            Dim gvrc As List(Of GridViewRow)
            Dim lbl As Label

            If Not pobjListaSubProductos Is Nothing Then
                For Each objSubProducto As COTIZACION_PRD_SPR In pobjListaSubProductos
                    gvrc = Me.EncontrarFilasDelValor(Of Label)(objSubProducto.Prsec_iIdPrd_Servicio.ToString(), _
                                                               "lblIdProducto", gridSubPS)
                    For Each gvr As GridViewRow In gvrc
                        If CType(gvr.FindControl("lblCodigoPS"), Label).Text.Equals(objSubProducto.Psspc_iNum_Sub_Prd.ToString()) Then
                            lbl = CType(gvr.FindControl("lblIdCotizacionPR"), Label)
                            lbl.Text = objSubProducto.Coprc_iIdCotizacion_Prd.ToString()

                            lbl = CType(gvr.FindControl("lblIdCotizacionSubPR"), Label)
                            lbl.Text = objSubProducto.Cospr_iIdCotizacion_Spr.ToString()
                            Exit For
                        End If
                    Next
                Next
            End If
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
                    objCOTIZACION_PRD.Paqtc_iIdPaquete = Convert.ToInt32(ddlPaquete.SelectedValue)
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

                    If intIdCotizacionPR = 0 Then
                        objCOTIZACION_PRD.Coprc_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion
                    Else
                        objCOTIZACION_PRD.Coprc_iIdUsuario_Modifica = Me.PAG_IdUsuario_InicioSesion
                    End If

                    objListaProductos.Add(objCOTIZACION_PRD)
                End If
            Next

            If objListaProductos.Count = 0 Then
                objListaProductos = Nothing
            End If

            Return objListaProductos
        End Function

        Private Function ObtenerListadoSubProductos() As List(Of COTIZACION_PRD_SPR)
            Dim gvr As GridViewRow
            Dim lbl As Label
            Dim ddl As DropDownList
            Dim txt As TextBox
            Dim intNumeroSubProductos As Integer
            Dim intIdCotizacionPR As Integer
            Dim intIdCotizacionSubPR As Integer
            Dim intIdProducto As Integer
            Dim intNumeroSubProducto As Integer
            Dim decRenta As Decimal
            Dim decPorcentajeIGV As Nullable(Of Decimal)
            Dim decMontoIGV As Nullable(Of Decimal)
            Dim decRentaIGV As Nullable(Of Decimal)
            Dim strNumeroInscripcion As String
            Dim strNumeroTelefono As String

            Dim objListaSubProductos As New List(Of COTIZACION_PRD_SPR)
            Dim objCOTIZACION_PRD_SPR As COTIZACION_PRD_SPR

            intNumeroSubProductos = gridSubPS.Rows.Count

            For i As Integer = 0 To intNumeroSubProductos - 1
                objCOTIZACION_PRD_SPR = New COTIZACION_PRD_SPR
                gvr = gridSubPS.Rows(i)

                lbl = CType(gvr.FindControl("lblIdCotizacionPR"), Label)
                If lbl.Text.Trim().Length > 0 Then
                    intIdCotizacionPR = Convert.ToInt32(lbl.Text)
                Else
                    intIdCotizacionPR = 0
                End If

                lbl = CType(gvr.FindControl("lblIdCotizacionSubPR"), Label)
                If lbl.Text.Trim().Length > 0 Then
                    intIdCotizacionSubPR = Convert.ToInt32(lbl.Text)
                Else
                    intIdCotizacionSubPR = 0
                End If

                lbl = CType(gvr.FindControl("lblIdProducto"), Label)
                intIdProducto = Convert.ToInt32(lbl.Text)

                ddl = CType(gvr.FindControl("ddlProductoServicio"), DropDownList)
                intNumeroSubProducto = Convert.ToInt32(ddl.SelectedValue)

                lbl = CType(gvr.FindControl("lblRenta"), Label)
                decRenta = Convert.ToDecimal(lbl.Text)

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

                lbl = CType(gvr.FindControl("lblRentaIGV"), Label)
                If lbl.Text.Trim().Length > 0 Then
                    decRentaIGV = Convert.ToDecimal(lbl.Text)
                Else
                    decRentaIGV = Nothing
                End If

                txt = CType(gvr.FindControl("txtNumeroInscripcion"), TextBox)
                strNumeroInscripcion = txt.Text

                txt = CType(gvr.FindControl("lblNumeroTelefono"), TextBox)
                strNumeroTelefono = txt.Text

                objCOTIZACION_PRD_SPR.Cospr_iIdCotizacion_Spr = intIdCotizacionSubPR
                objCOTIZACION_PRD_SPR.Coprc_iIdCotizacion_Prd = intIdCotizacionPR
                objCOTIZACION_PRD_SPR.Cotic_iIdCotizacion = Convert.ToInt32(ViewState("IdCotizacion"))
                objCOTIZACION_PRD_SPR.Prsec_iIdPrd_Servicio = intIdProducto
                objCOTIZACION_PRD_SPR.Psspc_iNum_Sub_Prd = intNumeroSubProducto
                objCOTIZACION_PRD_SPR.Cospc_vNumero_Telefono = strNumeroTelefono
                objCOTIZACION_PRD_SPR.Cospc_vNumero_Inscripcion = strNumeroInscripcion
                objCOTIZACION_PRD_SPR.Cospc_nPrecio = decRenta
                objCOTIZACION_PRD_SPR.Cospc_nPorc_Igv = decPorcentajeIGV
                objCOTIZACION_PRD_SPR.Cospc_nMonto_IGV = decMontoIGV
                objCOTIZACION_PRD_SPR.Cospc_nMonto_Total = decRentaIGV
                objCOTIZACION_PRD_SPR.Cospc_iEstado_Registro = ConstantesWeb.ValorConstanteUno

                If intIdCotizacionSubPR = 0 Then
                    objCOTIZACION_PRD_SPR.Cospc_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion
                Else
                    objCOTIZACION_PRD_SPR.Cospc_iIdUsuario_Modifica = Me.PAG_IdUsuario_InicioSesion
                End If

                objListaSubProductos.Add(objCOTIZACION_PRD_SPR)
            Next

            If objListaSubProductos.Count = 0 Then
                objListaSubProductos = Nothing
            End If

            Return objListaSubProductos
        End Function

        Private Sub BuscarUsuario()
            Dim intTipoDocumento As Integer
            Dim strNumeroDocumentoIdentidad As String

            intTipoDocumento = 0
            strNumeroDocumentoIdentidad = ""

            If ddlTipoDocumentoFiltro.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                intTipoDocumento = Convert.ToInt32(ddlTipoDocumentoFiltro.SelectedValue)
            End If

            strNumeroDocumentoIdentidad = txtNumeroDocumentoFiltro.Text

            Dim objCotizacionBL As New pdt_cotizacionBL()
            Dim objCotizacion As New COTIZACION()

            objCotizacion = objCotizacionBL.ObtenerCotizacionPorDocumentoCliente( _
                                                                        intTipoDocumento, _
                                                                        strNumeroDocumentoIdentidad)

            Me.LlenarDatosCliente(objCotizacion)

            objCotizacionBL = Nothing
        End Sub

        Private Sub ObtenerDatosPS()
            Dim objCotizacionBL As New pdt_cotizacionBL
            Dim dt As DataTable
            Dim intIdPaquete As Integer

            If Me.ddlPaquete.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                intIdPaquete = Convert.ToInt32(ddlPaquete.SelectedValue)
            End If

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

        Private Sub MostrarGrillaSubPS(ByVal pblnOpcion As Boolean)
            Me.gridSubPS.Visible = pblnOpcion
            Me.btnModificar.Enabled = pblnOpcion
            Me.btnProcesar.Enabled = Not pblnOpcion
            Me.HabilitarControlesGrillaPS(Not pblnOpcion)
            Me.MostrarBotonesGrillaSubPS(pblnOpcion)
            Me.UpdatePanelGrillaPS.Update()
            Me.UpdatePanelGrillaSubPS.Update()
        End Sub

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

        Private Sub ObtenerDatosSubPS()
            Dim gvr As GridViewRow
            Dim ddl As DropDownList
            Dim lbl As Label
            Dim chk As CheckBox
            Dim intNumeroProductos As Integer
            Dim intIdProducto As Integer
            Dim intCantidadSubProductos As Integer
            Dim strDescripcionProducto As String
            Dim objValores As New List(Of DatosProducto)
            Dim objDatosProducto As DatosProducto
            intNumeroProductos = gridPS.Rows.Count

            For i As Integer = 0 To intNumeroProductos - 1
                gvr = gridPS.Rows(i)
                chk = CType(gvr.FindControl("chkIncluir"), CheckBox)

                If Not chk.Visible OrElse chk.Checked Then
                    lbl = CType(gvr.FindControl("lblIdProducto"), Label)
                    intIdProducto = Convert.ToInt32(lbl.Text)

                    lbl = CType(gvr.FindControl("lblProducto"), Label)
                    strDescripcionProducto = lbl.Text

                    ddl = CType(gvr.FindControl("ddlCantidad"), DropDownList)
                    intCantidadSubProductos = 0

                    If ddl.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                        intCantidadSubProductos = Convert.ToInt32(ddl.SelectedValue)
                    End If

                    If intCantidadSubProductos > 0 Then
                        objDatosProducto.IdProducto = intIdProducto
                        objDatosProducto.DescripcionProducto = strDescripcionProducto
                        objDatosProducto.CantidadProductos = intCantidadSubProductos
                        objValores.Add(objDatosProducto)
                    End If
                End If
            Next

            Me.CrearDataTableGrillaSubProducto(objValores)
        End Sub

        Private Sub CrearDataTableGrillaSubProducto(ByVal objValores As List(Of DatosProducto))
            Dim dt As New DataTable
            Dim dr As DataRow
            Dim intCantidad As Integer

            intCantidad = 0

            dt.Columns.Add("prsec_iIdPrd_Servicio", GetType(Integer))
            dt.Columns.Add("prsec_vDescripcion", GetType(String))

            For i As Integer = 0 To objValores.Count - 1

                intCantidad = objValores(i).CantidadProductos
                For j As Integer = 0 To intCantidad - 1
                    dr = dt.NewRow()
                    dr("prsec_iIdPrd_Servicio") = objValores(i).IdProducto
                    dr("prsec_vDescripcion") = objValores(i).DescripcionProducto
                    dt.Rows.Add(dr)
                Next
            Next

            gridSubPS.DataSource = dt
            gridSubPS.DataBind()
        End Sub

        Private Sub EstablecerValoresGrillaSubPS(ByVal pobjSender As Object)
            Dim gvr As GridViewRow = EncontrarFilaDelControl(Of DropDownList)(pobjSender, gridSubPS)

            If Not gvr Is Nothing Then
                Dim intIdProducto As Integer
                Dim intIdSubProducto As Integer
                Dim decPorcentajeIGV As Decimal
                Dim decMontoIGV As Decimal
                Dim decMontoTotal As Decimal

                Dim lbl As Label = CType(gvr.FindControl("lblIdProducto"), Label)
                Dim ddl As DropDownList = CType(gvr.FindControl("ddlProductoServicio"), DropDownList)

                intIdProducto = Convert.ToInt32(lbl.Text)


                If Not ddl Is Nothing AndAlso _
                    ddl.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then

                    Dim objCotizacion As pdt_cotizacionBL
                    Dim objSubProducto As PRD_SERVICIO_SUB_PRD

                    intIdSubProducto = Convert.ToInt32(ddl.SelectedValue)

                    objCotizacion = New pdt_cotizacionBL
                    objSubProducto = objCotizacion.ObtenerSubProducto(intIdProducto, intIdSubProducto)

                    lbl = CType(gvr.FindControl("lblCodigoPS"), Label)
                    lbl.Text = objSubProducto.Psspc_iNum_Sub_Prd

                    lbl = CType(gvr.FindControl("lblRenta"), Label)
                    lbl.Text = objSubProducto.Pspsc_nMonto_Renta.ToString()

                    decPorcentajeIGV = 19

                    lbl = CType(gvr.FindControl("lblPorcentajeIGV"), Label)
                    lbl.Text = decPorcentajeIGV.ToString()

                    decMontoIGV = (objSubProducto.Pspsc_nMonto_Renta * (decPorcentajeIGV / 100))

                    lbl = CType(gvr.FindControl("lblMontoIGV"), Label)
                    lbl.Text = decMontoIGV.ToString()

                    decMontoTotal = objSubProducto.Pspsc_nMonto_Renta + decMontoIGV

                    lbl = CType(gvr.FindControl("lblRentaIGV"), Label)
                    lbl.Text = decMontoTotal

                ElseIf Not ddl Is Nothing AndAlso _
                    ddl.SelectedValue.ToString() = ConstantesWeb.ValorSeleccionar Then
                    Me.LimpiarEtiquetasMontosGrillaSubPS(gvr)
                End If

                If intIdProducto > 0 Then
                    Me.ActualizarMontoProducto(intIdProducto)
                End If

                UpdatePanelGrillaPS.Update()
                UpdatePanelGrillaSubPS.Update()
            End If
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

        Private Sub ActualizarMontoProducto(ByVal pintIdProducto As Integer)
            Dim gvrc As List(Of GridViewRow)
            Dim lbl As Label
            Dim decRenta As Decimal
            Dim decRentaIGV As Decimal
            Dim decPorcentajeDescuento As Decimal
            Dim decMontoDescuento As Decimal
            Dim decMontoTotal As Decimal
            Dim decPorcentajeIGV As Decimal
            Dim decMontoIGV As Decimal

            decPorcentajeDescuento = 0
            decMontoDescuento = 0
            decMontoTotal = 0
            decPorcentajeIGV = 19

            gvrc = Me.EncontrarFilasDelValor(Of Label)(pintIdProducto.ToString(), "lblIdProducto", gridSubPS)

            For Each gvr As GridViewRow In gvrc
                lbl = CType(gvr.FindControl("lblRenta"), Label)
                If lbl.Text.Trim().Length > 0 Then
                    decRenta += Convert.ToDecimal(lbl.Text)
                End If
            Next

            If decRenta > 0 Then
                gvrc = Me.EncontrarFilasDelValor(Of Label)(pintIdProducto.ToString(), "lblIdProducto", gridPS)

                lbl = CType(gvrc.Item(0).FindControl("lblRenta"), Label)
                lbl.Text = decRenta.ToString()

                lbl = CType(gvrc.Item(0).FindControl("lblPorcentajeIGV"), Label)
                lbl.Text = decPorcentajeIGV.ToString()

                decMontoIGV = (decRenta * (decPorcentajeIGV / 100))

                lbl = CType(gvrc.Item(0).FindControl("lblMontoIGV"), Label)
                lbl.Text = decMontoIGV.ToString()

                decRentaIGV = decRenta + decMontoIGV

                lbl = CType(gvrc.Item(0).FindControl("lblRentaIGV"), Label)
                lbl.Text = decRentaIGV.ToString()

                Dim objDescuento As DESCUENTO
                Dim objCotizacionBL As New pdt_cotizacionBL
                objDescuento = objCotizacionBL.Obtener_DescuentoPorProductoMonto(pintIdProducto, decRenta)

                If Not objDescuento Is Nothing Then

                    lbl = CType(gvrc.Item(0).FindControl("lblIdDescuento"), Label)
                    lbl.Text = objDescuento.Descc_iIdDescuento.ToString()

                    decPorcentajeDescuento = objDescuento.Descc_nPorc_Descuento

                    lbl = CType(gvrc.Item(0).FindControl("lblPorcentajeDescuento"), Label)
                    lbl.Text = decPorcentajeDescuento.ToString()

                    decMontoDescuento = (decRentaIGV * decPorcentajeDescuento) / 100

                    lbl = CType(gvrc.Item(0).FindControl("lblMontoDescuento"), Label)
                    lbl.Text = decMontoDescuento.ToString()
                End If

                decMontoTotal = decRentaIGV - decMontoDescuento

                lbl = CType(gvrc.Item(0).FindControl("lblMontoTotal"), Label)
                lbl.Text = decMontoTotal.ToString()
            End If
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

#Region "IPaginaMantenimento"

        Public Sub Agregar() Implements IPaginaMantenimento.Agregar

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo

        End Sub

        Public Sub CargarModoPagina() Implements IPaginaMantenimento.CargarModoPagina

        End Sub

        Public Sub Eliminar() Implements IPaginaMantenimento.Eliminar

        End Sub

        Public Sub Modificar() Implements IPaginaMantenimento.Modificar

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos

        End Function
#End Region

        Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            Me.ModalPopupExtender1.Hide()
            Me.AgregarProductoServicio()
            Dim pdt_cotizacionBL As New pdt_cotizacionBL()
            Dim dtProducto As DataTable
            Dim dtSubProducto As DataTable

            dtProducto = pdt_cotizacionBL.ListarCotizacionProducto(intIdCotizacion)
            dtSubProducto = pdt_cotizacionBL.ListarCotizacionSubProducto(intIdCotizacion)

            If (Not dtProducto Is Nothing AndAlso dtProducto.Rows.Count > 0) And _
               (Not dtSubProducto Is Nothing AndAlso dtSubProducto.Rows.Count > 0) Then

                Me.CargarValoresGrillaPS(dtProducto)
                Me.CargarValoresGrillaSubPS(dtSubProducto)
                Me.MostrarGrillaSubPS(True)
            End If
        End Sub

        Protected Sub ddlProducto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlProducto.SelectedIndexChanged
            Dim intIdProducto As Integer
            intIdProducto = 0

            If ddlProducto.SelectedValue.ToString() <> ConstantesWeb.ValorSeleccionar Then
                intIdProducto = Convert.ToInt32(ddlProducto.SelectedValue)
            End If

            Me.LlenarComboSubProducto(intIdProducto)

            Me.UpdatePanelSubProducto.Update()
            'Me.ModalPopupExtender1.Show()
        End Sub

        Private Sub AgregarProductoServicio()
            Dim objCotizacionBL As New pdt_cotizacionBL
            Dim objListaCotizacionProductos As New List(Of COTIZACION_PRD)
            Dim objCotizacionProducto As COTIZACION_PRD
            Dim objListaCotizacionSubProductos As New List(Of COTIZACION_PRD_SPR)
            Dim objCotizacionSubProducto As New COTIZACION_PRD_SPR
            Dim intIdCotizacion As Integer
            Dim intIdProducto As Integer
            Dim intIdSubProducto As Integer
            Dim objSubProductoTemp As PRD_SERVICIO_SUB_PRD

            intIdCotizacion = Convert.ToInt32(ViewState.Item("IdCotizacion"))

            If Not ddlProducto.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                intIdProducto = Convert.ToInt32(ddlProducto.SelectedValue)
            End If

            If Not ddlSubProducto.SelectedValue.ToString().Equals(ConstantesWeb.ValorSeleccionar) Then
                intIdSubProducto = Convert.ToInt32(ddlSubProducto.SelectedValue)
            End If

            'Dim dt As DataTable = objCotizacionBL.ListarCotizacionProducto(intIdCotizacion)
            objCotizacionProducto = objCotizacionBL.ObtenerCotizacionProducto(intIdCotizacion, intIdProducto)

            If objCotizacionProducto Is Nothing Then
                objCotizacionProducto = New COTIZACION_PRD
                objCotizacionProducto.Coprc_iCantidad_Prd = 1
                objCotizacionProducto.Cotic_iIdCotizacion = intIdCotizacion
                objCotizacionProducto.Prsec_iIdPrd_Servicio = intIdProducto
                objCotizacionProducto.Tococ_iIdTip_Ope_Com = ConstantesWeb.ValorAltaNueva
                objCotizacionProducto.Coprc_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion
            Else
                objCotizacionProducto.Coprc_iCantidad_Prd += 1
                objCotizacionProducto.Coprc_iIdUsuario_Modifica = Me.PAG_IdUsuario_InicioSesion
            End If

            objListaCotizacionProductos.Add(objCotizacionProducto)

            objSubProductoTemp = objCotizacionBL.ObtenerSubProducto(intIdProducto, intIdSubProducto)

            objCotizacionSubProducto.Cotic_iIdCotizacion = intIdCotizacion
            objCotizacionSubProducto.Prsec_iIdPrd_Servicio = intIdProducto
            objCotizacionSubProducto.Psspc_iNum_Sub_Prd = intIdSubProducto
            objCotizacionSubProducto.Cospc_nPrecio = objSubProductoTemp.Pspsc_nMonto_Renta
            objCotizacionSubProducto.Cospc_nPorc_Igv = 19
            objCotizacionSubProducto.Cospc_nMonto_IGV = (objCotizacionSubProducto.Cospc_nPrecio.Value * 19) / 100
            objCotizacionSubProducto.Cospc_nMonto_Total = objCotizacionSubProducto.Cospc_nPrecio.Value + objCotizacionSubProducto.Cospc_nMonto_IGV.Value
            objCotizacionSubProducto.Cospc_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion

            If objCotizacionProducto.Coprc_nPrecio.HasValue Then
                objCotizacionProducto.Coprc_nPrecio += objCotizacionSubProducto.Cospc_nPrecio.Value
            Else
                objCotizacionProducto.Coprc_nPrecio = objCotizacionSubProducto.Cospc_nPrecio.Value
            End If

            objCotizacionProducto.Coprc_nPorc_Igv = 19

            If objCotizacionProducto.Coprc_nMonto_IGV.HasValue Then
                objCotizacionProducto.Coprc_nMonto_IGV += ((objCotizacionProducto.Coprc_nPrecio.Value * 19) / 100)
            Else
                objCotizacionProducto.Coprc_nMonto_IGV = (objCotizacionProducto.Coprc_nPrecio.Value * 19) / 100
            End If

            Dim decMontoParcial As Decimal
            decMontoParcial = objCotizacionProducto.Coprc_nPrecio.Value + objCotizacionProducto.Coprc_nMonto_IGV.Value
            If objCotizacionProducto.Coprc_nMonto_Total.HasValue Then
                objCotizacionProducto.Coprc_nMonto_Total += decMontoParcial
            Else
                objCotizacionProducto.Coprc_nMonto_Total = decMontoParcial
            End If

            Dim objDescuento As DESCUENTO
            objDescuento = objCotizacionBL.Obtener_DescuentoPorProductoMonto(intIdProducto, objCotizacionSubProducto.Cospc_nPrecio.Value)

            If Not objDescuento Is Nothing Then
                objCotizacionProducto.Coprc_nPorc_Descuento = objDescuento.Descc_nPorc_Descuento
                objCotizacionProducto.Descc_iIdDescuento = objDescuento.Descc_iIdDescuento
                If objCotizacionProducto.Coprc_nMonto_Descuento.HasValue Then
                    objCotizacionProducto.Coprc_nMonto_Descuento += ((objCotizacionProducto.Coprc_nPrecio * objDescuento.Descc_nPorc_Descuento) / 100)
                Else
                    objCotizacionProducto.Coprc_nMonto_Descuento = (objCotizacionProducto.Coprc_nPrecio * objDescuento.Descc_nPorc_Descuento) / 100
                End If
            End If

            If objCotizacionProducto.Coprc_nMonto_Descuento.HasValue Then
                If objCotizacionProducto.Coprc_nMonto_Total.HasValue Then
                    objCotizacionProducto.Coprc_nMonto_Total += (decMontoParcial - objCotizacionProducto.Coprc_nMonto_Descuento.Value)
                Else
                    objCotizacionProducto.Coprc_nMonto_Total = (decMontoParcial - objCotizacionProducto.Coprc_nMonto_Descuento.Value)
                End If
            End If

            objListaCotizacionSubProductos.Add(objCotizacionSubProducto)
            objCotizacionBL.Insertar_PS(objListaCotizacionProductos, objListaCotizacionSubProductos, intIdCotizacion)
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Me.ModalPopupExtender1.Hide()
        End Sub
    End Class
End Namespace