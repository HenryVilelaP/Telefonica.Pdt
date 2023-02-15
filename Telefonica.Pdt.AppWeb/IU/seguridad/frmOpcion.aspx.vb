Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class IU_seguridad_frmOpcion
        Inherits WebPaginaBase
        Implements IPaginaBase, IPaginaMantenimento

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoEliminar As String = "GrillaEventoEliminar"
        Private Const ConstGrillaEventoMostrarDetalle As String = "GrillaEventoMostrarDetalle"
        Private Shared ModoPaginaProceso As String = ""

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles
            pnlFrmOpcion.Visible = False
            LlenarComboTipoOpcion(0) 'Llena combo la parte para busqueda
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboOpcionCritica()
            Me.LlenarComboTipoOpcion(1)
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
            Dim dt As DataTable = Me.ListarDataLlenarGrilla()

            If Not (dt Is Nothing) Then
                TotalRegistros = dt.Rows.Count
                Me.grid.DataSource = dt
                IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(TotalRegistros, Me.grid.PageSize, IndicePagina)
                Me.grid.PageIndex = IndicePagina
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
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            HelperWeb.RegistrarJavaScriptEnHead(Me.Page, "PasarValorHijoaPadre", PasarValorHijoaPadre())
        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript
            Dim UrlDescargaArchivo As String = HelperWeb.AbrirVentanaWinPopup("frmBuscarOpcionPadre.aspx", 700, 350, True, True)
            hlkBuscaPadre.ToolTip = "Buscar Padre..."
            hlkBuscaPadre.Target = "_blank"
            hlkBuscaPadre.Attributes.Add("OnClick".ToString(), UrlDescargaArchivo)
        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

#End Region

#Region "IPaginaMantenimento"

        Public Sub Agregar() Implements IPaginaMantenimento.Agregar

            Dim lobjOpcionEnt As SG_OPCION
            Dim lobjOpcionBL As pdt_sg_opcionBL

            lobjOpcionEnt = New SG_OPCION

            lobjOpcionEnt.Opcic_iIdOpcion = 0
            lobjOpcionEnt.Opcic_vEtiqueta = Me.txtEtiqueta.Text
            lobjOpcionEnt.Opcic_vDescripcion = Me.txtDescripcion.Text
            lobjOpcionEnt.Opcic_vNombre_Pagina = Me.txtNombrePagina.Text
            lobjOpcionEnt.Opcic_vRuta_Url_Pagina = Me.txtRutaUrlPagina.Text
            lobjOpcionEnt.Opcic_iNum_Orden = Convert.ToInt32(Me.txtNumeroOrden.Text)
            lobjOpcionEnt.Opcic_iInd_Opcion_Critica = Convert.ToInt32(Me.cboOpcionCritica.SelectedValue)
            lobjOpcionEnt.Vtopc_iIdTip_Opcion = Convert.ToInt32(Me.cboTipoOpcion.SelectedValue)
            lobjOpcionEnt.Opcic_iIdUsuario_Registro = 1
            lobjOpcionEnt.Opcic_iId_Opcion_Padre = Convert.ToInt32(Me.hOpcionPadre.Value)

            lobjOpcionBL = New pdt_sg_opcionBL

            Dim lintResult As Integer
            lintResult = lobjOpcionBL.Insertar(lobjOpcionEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            Me.lblAccion.Text = "MODIFICAR OPCION"
            If (Me.LlenarDatoControlesDetalle() > 0) Then
                Me.btnGrabar.Enabled = True
            End If

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
            Me.lblAccion.Text = "NUEVA OPCION"
            Me.btnGrabar.Enabled = True
        End Sub

        Public Sub CargarModoPagina() Implements IPaginaMantenimento.CargarModoPagina

            Dim strModoPagina As String = ModoPaginaProceso
            Select Case ModoPaginaProceso
                Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                    Me.CargarModoNuevo()
                Case ConstantesWeb.ModoPagina.Modificar.ToString()
                    Me.CargarModoModificar()
                Case ConstantesWeb.ModoPagina.Consultar.ToString()
                    Me.CargarModoConsulta()
            End Select
        End Sub

        Public Sub Eliminar() Implements IPaginaMantenimento.Eliminar

        End Sub

        Public Sub Modificar() Implements IPaginaMantenimento.Modificar

            Dim lobjOpcionEnt As SG_OPCION
            Dim lobjOpcionBL As pdt_sg_opcionBL

            lobjOpcionEnt = New SG_OPCION

            lobjOpcionEnt.Opcic_iIdOpcion = Me.hcodigo.Value
            lobjOpcionEnt.Opcic_vEtiqueta = Me.txtEtiqueta.Text
            lobjOpcionEnt.Opcic_vDescripcion = Me.txtDescripcion.Text
            lobjOpcionEnt.Opcic_vNombre_Pagina = Me.txtNombrePagina.Text
            lobjOpcionEnt.Opcic_vRuta_Url_Pagina = Me.txtRutaUrlPagina.Text
            lobjOpcionEnt.Opcic_iNum_Orden = Convert.ToInt32(Me.txtNumeroOrden.Text)
            lobjOpcionEnt.Opcic_iInd_Opcion_Critica = Convert.ToInt32(Me.cboOpcionCritica.SelectedItem.Value)
            lobjOpcionEnt.Vtopc_iIdTip_Opcion = Convert.ToInt32(Me.cboTipoOpcion.SelectedItem.Value)
            lobjOpcionEnt.Opcic_iIdUsuario_Modifica = 1
            lobjOpcionEnt.Opcic_iId_Opcion_Padre = Convert.ToInt32(Me.hOpcionPadre.Value)

            lobjOpcionBL = New pdt_sg_opcionBL

            Dim lintResult As Integer
            lintResult = lobjOpcionBL.Modificar(lobjOpcionEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            If (Me.txtDescripcion.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvdescripcion.ErrorMessage)
                Return False
            End If
            If (Me.txtEtiqueta.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvetiqueta.ErrorMessage)
                Return False
            End If
            If (Me.txtNumeroOrden.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvNumerOrden.ErrorMessage)
                Return False
            End If
            If (Me.cboOpcionCritica.SelectedValue = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvOpcionCritica.ErrorMessage)
                Return False
            End If
            If (Me.cboTipoOpcion.SelectedValue = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvTipoOpcion.ErrorMessage)
                Return False
            End If
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Function Descripcion_OpcionPadre(ByVal idOpcionPadre As Integer) As String
            Dim ldescr_opcionpadre As String = "NIVEL SUPERIOR"
            Dim opdt_sg_opcionBL As New pdt_sg_opcionBL
            Dim oSG_OPCION As SG_OPCION = opdt_sg_opcionBL.Detalle(idOpcionPadre)

            If Not (oSG_OPCION Is Nothing) Then
                ldescr_opcionpadre = oSG_OPCION.Opcic_vEtiqueta
            End If

            Descripcion_OpcionPadre = ldescr_opcionpadre
        End Function

        Private Sub LlenarComboOpcionCritica()
            HelperWeb.ComboLlenarDatosSiNo(Me.cboOpcionCritica)
        End Sub

        Private Sub LlenarComboTipoOpcion(ByVal Zona As Integer)
            Dim dt As DataTable
            Dim objTipoOpcionBL As New pdt_sg_tip_opcionBL
            dt = objTipoOpcionBL.Lista_Tipo_Opcion()
            If Zona = 0 Then 'Se llena el combo de la busqueda
                HelperWeb.LlenarCombo(dt, Enumeradores.Col_SG_TIP_OPCION.vtopc_iIdTip_Opcion.ToString(), Enumeradores.Col_SG_TIP_OPCION.vDescripcion.ToString(), Enumeradores.TextoMostrarCombo.Seleccionar, Me.cboTipoOpcionBusqueda)
            Else
                HelperWeb.LlenarCombo(dt, Enumeradores.Col_SG_TIP_OPCION.vtopc_iIdTip_Opcion.ToString(), Enumeradores.Col_SG_TIP_OPCION.vDescripcion.ToString(), Enumeradores.TextoMostrarCombo.Seleccionar, Me.cboTipoOpcion)
            End If
        End Sub

        Private Function LlenarDatoControlesDetalle() As Integer
            Dim IdOpcion As Integer = Convert.ToInt32(Me.hcodigo.Value)
            Dim opdt_sg_opcionBL As New pdt_sg_opcionBL
            Dim oSG_OPCION As SG_OPCION = opdt_sg_opcionBL.Detalle(IdOpcion)

            If Not (oSG_OPCION Is Nothing) Then
                Me.txtId.Text = IdOpcion
                Me.txtDescripcion.Text = oSG_OPCION.Opcic_vDescripcion
                Me.txtEtiqueta.Text = oSG_OPCION.Opcic_vEtiqueta
                Me.txtNombrePagina.Text = oSG_OPCION.Opcic_vNombre_Pagina
                Me.txtRutaUrlPagina.Text = oSG_OPCION.Opcic_vRuta_Url_Pagina
                Me.txtOpcionPadre.Text = Descripcion_OpcionPadre(oSG_OPCION.Opcic_iId_Opcion_Padre)
                Me.hOpcionPadre.Value = oSG_OPCION.Opcic_iId_Opcion_Padre
                Me.txtNumeroOrden.Text = oSG_OPCION.Opcic_iNum_Orden
                HelperWeb.ComboSeleccionarItem(Me.cboOpcionCritica, oSG_OPCION.Opcic_iInd_Opcion_Critica.ToString())
                HelperWeb.ComboSeleccionarItem(Me.cboTipoOpcion, oSG_OPCION.Vtopc_iIdTip_Opcion.ToString())

                Return 1
            End If

            Return 0

        End Function

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.LimpiarControlesDetalle() 'Limpia los controles de formulario
            Me.pnlFrmOpcion.Visible = True

            Me.LlenarCombos()
            Me.CargarModoPagina()
        End Sub

        Public Sub LlenarJScriptSeccionDetalle()
            Me.rfvDescripcion.ErrorMessage = "Falta la descripcion del perfil"
            Me.rfvDescripcion.ToolTip = Me.rfvDescripcion.ErrorMessage
        End Sub

        Public Sub LimpiarControlesDetalle()
            'Me.hcodigo.Value = ""
            Me.hOpcionPadre.Value = 0
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
            Me.txtEtiqueta.Text = ""
            Me.txtNombrePagina.Text = ""
            Me.txtRutaUrlPagina.Text = ""
            Me.txtOpcionPadre.Text = ""
            'Me.nbNumeroOrden.Text = ""
            Me.txtNumeroOrden.Text = ""
            Me.cboOpcionCritica.Items.Clear()
            Me.cboTipoOpcion.Items.Clear()
        End Sub

        Private Sub CargarSeccionGrilla()
            Me.pnlFrmOpcion.Visible = False
            Me.lblAccion.Text = ""
            ModoPaginaProceso = ""
            Me.LlenarGrilla()
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)
            'Me.pnlAcciones.Visible = blnEsVisible
            'Me.pnlOpcionesCabecera.Visible = blnEsVisible
        End Sub

        Private Function ListarDataLlenarGrilla() As DataTable

            Dim oOpcion As pdt_sg_opcionBL

            Dim lstrDescripcion As String = Me.txtDescripcionBusqueda.Text
            Dim lintTipoOpcion As Integer = 0

            If Me.cboTipoOpcionBusqueda.SelectedValue <> ConstantesWeb.ValorSeleccionar Then
                lintTipoOpcion = Me.cboTipoOpcionBusqueda.SelectedValue
            End If

            Dim dt As DataTable

            oOpcion = New pdt_sg_opcionBL
            dt = oOpcion.Lista_Opcion(lstrDescripcion, lintTipoOpcion)

            oOpcion = Nothing

            Return dt

        End Function

        Private Sub ReiniciarControles()
            'Me.VisualizarControlesDetalle(False)
            Me.VisualizarControles(False)
            Me.hcodigo.Value = ""
        End Sub

        Private Sub LimpiarControles()
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnNuevo)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
        End Sub

        Private Function PasarValorHijoaPadre() As String
            Dim strJs As String
            strJs = "function AsignarValor(valorTxt,valorId)"
            strJs += "{"
            strJs += "document.forms[0].elements['txtOpcionPadre'].value=valorTxt;"
            strJs += "document.forms[0].elements['hOpcionPadre'].value=valorId;"
            strJs += "}"
            Return strJs
        End Function

#End Region

#Region "Metodos Formulario"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            Try
                Me.RegistrarJScript()
                Me.HacerControlComandoNetAjax()
                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarDatos()
                    Me.LlenarGrilla()
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            Try
                ModoPaginaProceso = ConstantesWeb.ModoPagina.Nuevo.ToString()
                Me.CargarSeccionFormularioDetalle()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelDetalle.Update()
            End Try
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Try
                Me.CargarSeccionGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            Try
                If (Me.IsValid) AndAlso (Me.ValidarCampos()) Then
                    Dim strModoPagina As String = ModoPaginaProceso
                    Select Case ModoPaginaProceso
                        Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                            Me.Agregar()
                        Case ConstantesWeb.ModoPagina.Modificar.ToString()
                            Me.Modificar()
                    End Select
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub grid_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
            If Me.hcodigo.Value.ToString().Trim().Length > 0 Then
                Try
                    Dim lstrCurrentCommand As String = e.CommandName()

                    Dim lintIdOpcion As Integer = Convert.ToInt32(Me.hCodigo.Value)

                    Select Case lstrCurrentCommand
                        Case ConstGrillaEventoModificar
                            ModoPaginaProceso = ConstantesWeb.ModoPagina.Modificar.ToString()
                            Me.CargarSeccionFormularioDetalle()
                            Me.UpdatePanelDetalle.Update()
                        Case ConstGrillaEventoEliminar

                        Case ConstGrillaEventoMostrarDetalle
                            Me.Page.Response.Redirect("frmOpcionAccion.aspx?" & Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString() & "=" & lintIdOpcion.ToString())
                    End Select
                Catch ex As Exception
                    NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
                End Try
            End If
        End Sub

        Protected Sub grid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            If ((e.Row.RowType = ListItemType.AlternatingItem) OrElse (e.Row.RowType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Row.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Row.Height = Unit.Pixel(20)

                e.Row.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString()))

                Dim strJs As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ClientID, IdRegistro.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, strJs)

            End If
        End Sub

        Protected Sub grid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
            Try
                Me.hGrillaIndicePagina.Value = e.NewPageIndex.ToString()
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Protected Sub btnConsultar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
            Try
                Me.hGrillaIndicePagina.Value = "0"
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Protected Sub imgBtnBuscarPadre_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            HelperWeb.AbrirVentanaWinPopup("frmBuscarOpcionPadre", 500, 400, False, True)
        End Sub

#End Region

    End Class

End Namespace
