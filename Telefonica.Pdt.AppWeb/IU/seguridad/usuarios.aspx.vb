Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.AppWeb.UICryptography

Namespace Telefonica.Pdt.AppWeb

    Partial Class usuarios
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
            Me.pnlFrmUsuario.Visible = False
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboPerfil()
            Me.LlenarComboTurno()
            Me.LlenarComboTipoDocumento()
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
            Dim dt As DataTable = Me.ListarDataLlenarGrilla(Me.grid.PageSize, IndicePagina, TotalRegistros)

            If Not (dt Is Nothing) Then
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
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.UpdateProgress1)
        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function



#End Region

#Region "IPaginaMantenimento"

        Public Sub Agregar() Implements IPaginaMantenimento.Agregar
            Dim lobjUsuarioEnt As SG_USUARIO
            Dim lobjUsuarioBL As pdt_usuarioBL

            lobjUsuarioEnt = New SG_USUARIO

            lobjUsuarioEnt.Usuac_vLogin = txtLoginN.Text
            lobjUsuarioEnt.Usuac_vApellido_Paterno = txtApellidoPaternoN.Text
            lobjUsuarioEnt.Usuac_vApellido_Materno = txtApellidoMaternoN.Text
            lobjUsuarioEnt.Usuac_vNombre = txtNombresN.Text


            lobjUsuarioEnt.Usuac_vPassword = ConstantesWeb.PassWordInicial

            lobjUsuarioEnt.Vtdoc_iIdTip_Doc = 1
            lobjUsuarioEnt.Usuac_vNum_Doc = txtNumeroDocIdent.Text
            lobjUsuarioEnt.Turnc_iIdTurno = Convert.ToInt32(cboTurno.SelectedItem.Value)
            If (cboPerfil.SelectedItem.Value <> ConstantesWeb.ValorSeleccionar) Then
                lobjUsuarioEnt.Perfc_iIdPerfil = Convert.ToInt32(cboPerfil.SelectedItem.Value)
            End If
            lobjUsuarioEnt.Usuac_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion
            lobjUsuarioEnt.Usuac_vCorreo = txtEmail.Text
            lobjUsuarioEnt.Usuac_iIdEstado_Usuario = IIf(chkInactivo.Checked, 1, 0)
            lobjUsuarioEnt.Usuac_iIdEstado_Bloqueado = IIf(chkBloqueado.Checked, 1, 0)

            lobjUsuarioBL = New pdt_usuarioBL

            Dim lintResult As Integer
            lintResult = lobjUsuarioBL.Insertar(lobjUsuarioEnt)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "Login de usuario existente. No se puede guardar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                    Me.CargarSeccionGrilla()
                    Me.UpdatePanelGrilla.Update()
            End Select

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            Me.lblAccion.Text = "MODIFICAR USUARIO"
            If (Me.LlenarDatoControlesDetalle() > 0) Then
                Me.btnGrabar.Enabled = True
                Me.txtLoginN.Enabled = False
            End If

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
            Me.lblAccion.Text = "NUEVO USUARIO"
            Me.btnGrabar.Enabled = True
            Me.txtLoginN.Enabled = True
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
            Dim lobjUsuarioEnt As SG_USUARIO
            Dim lobjUsuarioBL As pdt_usuarioBL

            lobjUsuarioEnt = New SG_USUARIO

            lobjUsuarioEnt.Usuac_iId_Usuario = Me.hcodigo.Value
            lobjUsuarioEnt.Usuac_vApellido_Paterno = Me.txtApellidoPaternoN.Text
            lobjUsuarioEnt.Usuac_vApellido_Materno = Me.txtApellidoMaternoN.Text
            lobjUsuarioEnt.Usuac_vNombre = Me.txtNombresN.Text
            lobjUsuarioEnt.Usuac_vLogin = Me.txtLoginN.Text
            lobjUsuarioEnt.Usuac_vPassword = "123456"
            lobjUsuarioEnt.Vtdoc_iIdTip_Doc = 1
            lobjUsuarioEnt.Usuac_vNum_Doc = Me.txtNumeroDocIdent.Text
            lobjUsuarioEnt.Turnc_iIdTurno = Me.cboTurno.SelectedItem.Value
            lobjUsuarioEnt.Usuac_iIdEstado_Usuario = IIf(Me.chkInactivo.Checked, 1, 0)
            lobjUsuarioEnt.Usuac_iIdEstado_Bloqueado = IIf(Me.chkBloqueado.Checked, 1, 0)
            lobjUsuarioEnt.Usuac_vIp_Estacion = ""
            lobjUsuarioEnt.Usuac_vCorreo = Me.txtEmail.Text
            lobjUsuarioEnt.Usuac_iIdUsuario_Modifica = 1
            lobjUsuarioEnt.Perfc_iIdPerfil = Me.cboPerfil.SelectedItem.Value

            lobjUsuarioBL = New pdt_usuarioBL

            Dim lintResult As Integer = 0
            lintResult = lobjUsuarioBL.Modificar(lobjUsuarioEnt)

            If (lintResult > 0) Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                ModoPaginaProceso = ""
                Me.LlenarGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            If (Me.txtLoginN.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvLoginN.ErrorMessage)
                Return False
            End If
            If (Me.txtApellidoPaternoN.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvApellidoPaternoN.ErrorMessage)
                Return False
            End If
            If (Me.txtApellidoMaternoN.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvApellidoMaterno.ErrorMessage)
                Return False
            End If
            If (Me.cboTurno.SelectedValue = ConstantesWeb.ValorSeleccionar) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvTurno.ErrorMessage)
                Return False
            End If
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.LimpiarControlesDetalle() 'Limpia los controles de formulario
            Me.pnlFrmUsuario.Visible = True

            Me.LlenarCombos()
            Me.CargarModoPagina()

        End Sub

        Public Sub LlenarJScriptSeccionDetalle()
            Me.rfvLoginN.ErrorMessage = "Falta el Login del usuario"
            Me.rfvLoginN.ToolTip = Me.rfvLoginN.ErrorMessage

            Me.rfvNombreN.ErrorMessage = "Falta el nombre del usuario"
            Me.rfvNombreN.ToolTip = Me.rfvNombreN.ErrorMessage

            Me.rfvApellidoPaternoN.ErrorMessage = "Falta el apellido paterno"
            Me.rfvApellidoPaternoN.ToolTip = Me.rfvApellidoPaternoN.ErrorMessage

            Me.rfvApellidoMaterno.ErrorMessage = "Falta el apellido materno"
            Me.rfvApellidoMaterno.ToolTip = Me.rfvApellidoMaterno.ErrorMessage

            Me.rfvTurno.ErrorMessage = "Falta seleccionar el turno"
            Me.rfvTurno.ToolTip = Me.rfvTurno.ToolTip
            Me.rfvTurno.InitialValue = ConstantesWeb.ValorSeleccionar

        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnNuevo)
        End Sub

        Private Sub CargarSeccionGrilla()
            pnlFrmUsuario.Visible = False
            lblAccion.Text = ""
            ModoPaginaProceso = ""
            Me.LlenarGrilla()
        End Sub

        Public Sub LimpiarControlesDetalle()
            'Me.hcodigo.Value = ""
            Me.txtLoginN.Text = ""
            Me.txtApellidoPaternoN.Text = ""
            Me.txtApellidoMaternoN.Text = ""
            Me.txtNombresN.Text = ""
            Me.txtNumeroDocIdent.Text = ""
            Me.cboPerfil.Items.Clear()
            Me.cboTipoDocIdent.Items.Clear()
            Me.cboTurno.Items.Clear()
            Me.txtEmail.Text = ""
            Me.chkInactivo.Checked = False
            Me.chkBloqueado.Checked = False
        End Sub

        Private Sub LlenarComboPerfil()
            Dim dt As DataTable
            Dim objPerfilBL As New pdt_perfilBL
            dt = objPerfilBL.Listar_Perfil()
            HelperWeb.LlenarCombo(dt, Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString(), Enumeradores.Col_SG_PERFIL.perfc_vDescripcion.ToString(), Enumeradores.TextoMostrarCombo.Seleccionar, Me.cboPerfil)
        End Sub

        Private Sub LlenarComboTurno()
            Dim dt As DataTable
            Dim objTurnoBL As New pdt_turnoBL
            dt = objTurnoBL.Listar()
            HelperWeb.LlenarCombo(dt, Enumeradores.Col_SG_TURNO.turnc_iIdTurno.ToString(), Enumeradores.Col_SG_TURNO.turnc_vDescripcion_Turno.ToString(), Enumeradores.TextoMostrarCombo.Seleccionar, Me.cboTurno)
        End Sub

        Private Sub LlenarComboTipoDocumento()
            HelperWeb.LlenarComboRegistroTablaTablas( _
                    Enumeradores.Cabecera_Tabla_Tablas.Tab_Documento_Identidad_Personal, _
                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                    cboTipoDocIdent)
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)
            'Me.pnlAcciones.Visible = blnEsVisible
            'Me.pnlOpcionesCabecera.Visible = blnEsVisible
        End Sub

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable

            Dim oUsuarioEnt As SG_USUARIO
            oUsuarioEnt = New SG_USUARIO
            oUsuarioEnt.Usuac_vLogin = txtLogin.Text
            oUsuarioEnt.Usuac_vNombre = txtNombres.Text

            Dim dt As DataTable

            Dim oUsuario As New pdt_usuarioBL
            dt = oUsuario.Listar_PorNombre(oUsuarioEnt)

            If dt Is Nothing Then
                TotalRegistros = 0
            Else
                TotalRegistros = dt.Rows.Count
            End If

            Return dt

        End Function

        Private Sub ReiniciarControles()
            Me.VisualizarControles(False)
            Me.hcodigo.Value = ""
            Me.btnGrabar.Enabled = False
        End Sub

        Private Sub LimpiarControles()
            'Busqueda
            Me.txtLogin.Text = String.Empty
            Me.txtNombres.Text = String.Empty
            'Formulario de mantenimiento
            Me.txtLoginN.Text = String.Empty
            Me.txtApellidoMaternoN.Text = String.Empty
            Me.txtApellidoPaternoN.Text = String.Empty
            Me.txtNombresN.Text = String.Empty
            Me.cboTipoDocIdent.SelectedIndex = 0
            Me.txtNumeroDocIdent.Text = String.Empty
            Me.cboTurno.SelectedIndex = 0
            Me.txtEmail.Text = String.Empty
            Me.cboPerfil.SelectedIndex = 0
            Me.chkInactivo.Checked = False
            Me.chkBloqueado.Checked = False
        End Sub

        Private Function LlenarDatoControlesDetalle() As Integer
            Dim IdUsuario As Integer = Convert.ToInt32(Me.hcodigo.Value)
            Dim opdt_usuarioBL As New pdt_usuarioBL
            Dim oSG_USUARIO As SG_USUARIO = opdt_usuarioBL.Detalle(IdUsuario)

            If Not (oSG_USUARIO Is Nothing) Then
                Me.txtLoginN.Text = oSG_USUARIO.Usuac_vLogin
                Me.txtApellidoPaternoN.Text = oSG_USUARIO.Usuac_vApellido_Paterno
                Me.txtApellidoMaternoN.Text = oSG_USUARIO.Usuac_vApellido_Materno
                Me.txtNombresN.Text = oSG_USUARIO.Usuac_vNombre
                Me.txtEmail.Text = oSG_USUARIO.Usuac_vCorreo
                If (oSG_USUARIO.Vtdoc_iIdTip_Doc.HasValue) Then
                    HelperWeb.ComboSeleccionarItem(Me.cboTipoDocIdent, oSG_USUARIO.Vtdoc_iIdTip_Doc.Value.ToString())
                End If
                Me.txtNumeroDocIdent.Text = oSG_USUARIO.Usuac_vNum_Doc
                If (oSG_USUARIO.Perfc_iIdPerfil.HasValue) Then
                    HelperWeb.ComboSeleccionarItem(Me.cboPerfil, oSG_USUARIO.Perfc_iIdPerfil.Value.ToString())
                End If
                HelperWeb.ComboSeleccionarItem(Me.cboTurno, oSG_USUARIO.Turnc_iIdTurno.ToString())
                Me.chkInactivo.Checked = IIf(oSG_USUARIO.Usuac_iIdEstado_Usuario = 0, False, True)
                Me.chkBloqueado.Checked = IIf(oSG_USUARIO.Usuac_iIdEstado_Bloqueado = 0, False, True)
                Return 1
            End If

            Return 0

        End Function


#End Region

#Region "Metodos Formulario"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            If Me.hCodigo.Value.ToString().Trim().Length > 0 Then
                Try
                    Dim lstrCurrentCommand As String = e.CommandName()

                    Dim lintIdUsuario As Integer = Convert.ToInt32(Me.hCodigo.Value)

                    Select Case lstrCurrentCommand
                        Case ConstGrillaEventoModificar
                            ModoPaginaProceso = ConstantesWeb.ModoPagina.Modificar.ToString()
                            Me.CargarSeccionFormularioDetalle()
                            Me.UpdatePanelDetalle.Update()
                        Case ConstGrillaEventoEliminar
                        Case ConstGrillaEventoMostrarDetalle
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

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_SG_USUARIO.usuac_iId_Usuario.ToString()))

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

#End Region

    End Class

End Namespace
