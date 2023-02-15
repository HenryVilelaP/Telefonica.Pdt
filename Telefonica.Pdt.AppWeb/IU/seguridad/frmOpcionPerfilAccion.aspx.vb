Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class IU_seguridad_frmOpcionPerfilAccion
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
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
            Me.LlenarDatoControlesDetalle()
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
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

#End Region

#Region "IPaginaMantenimento"

        Public Sub Agregar() Implements IPaginaMantenimento.Agregar

            Dim lobjOpcionPerfilAccionEnt As SG_OPCION_PERFIL_ACCION
            Dim lobjOpcionPerfilAccionBL As New pdt_sg_opcion_perfil_accionBL
            Dim FilaGrilla As Integer
            Dim iIdOpcion As Integer = Me.Page.Request.Params(Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString())
            Dim iIdPerfil As Integer = Me.Page.Request.Params(Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString())

            lobjOpcionPerfilAccionEnt = New SG_OPCION_PERFIL_ACCION

            For FilaGrilla = 0 To grid.Rows.Count - 1

                Dim rowgrid As GridViewRow = grid.Rows(FilaGrilla)
                Dim CheckIdAccion As CheckBox = CType(rowgrid.FindControl("chkIdAccion"), CheckBox)
                Dim iIdAccion As HiddenField = CType(rowgrid.FindControl("hIdAccion"), HiddenField)

                lobjOpcionPerfilAccionEnt.Perfc_iIdPerfil = Convert.ToInt32(iIdPerfil)
                lobjOpcionPerfilAccionEnt.Opcic_iIdOpcion = Convert.ToInt32(iIdOpcion)
                lobjOpcionPerfilAccionEnt.Accic_iIdAccion = Convert.ToInt32(iIdAccion.Value)
                lobjOpcionPerfilAccionEnt.Ppacc_iIdUsuario_Registro = 1
                If CheckIdAccion.Checked = True Then
                    lobjOpcionPerfilAccionEnt.Ppacc_iEstado_Registro = 1
                Else
                    lobjOpcionPerfilAccionEnt.Ppacc_iEstado_Registro = 0
                End If

                Dim lintResult As Integer
                lintResult = lobjOpcionPerfilAccionBL.Insertar(lobjOpcionPerfilAccionEnt)

                'If lintResult > 0 Then
                'NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                'Me.CargarSeccionGrilla()
                'Me.UpdatePanelGrilla.Update()
                'End If

            Next

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            If (Me.LlenarDatoControlesDetalle() > 0) Then
                Me.btnGrabar.Enabled = True
            End If

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
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

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Function LlenarDatoControlesDetalle() As Integer

            Dim strIdOpcion As String = Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString()
            Dim strIdPerfil As String = Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString()

            Dim IdPerfil As Integer = Me.Page.Request.Params(strIdPerfil)
            Dim IdOpcion As Integer = Me.Page.Request.Params(strIdOpcion)

            Dim opdt_perfilBL As New pdt_perfilBL
            Dim oSG_PERFIL As SG_PERFIL = opdt_perfilBL.Detalle(IdPerfil)

            Dim opdt_sg_opcionBL As New pdt_sg_opcionBL
            Dim oSG_OPCION As SG_OPCION = opdt_sg_opcionBL.Detalle(IdOpcion)

            If (Not (oSG_PERFIL Is Nothing)) And Not ((oSG_OPCION Is Nothing)) Then
                Me.lblPerfilOpcionSelecionada.Text = oSG_PERFIL.Perfc_vDescripcion & " / " & oSG_OPCION.Opcic_vDescripcion
                Return 1
            End If

            Return 0
        End Function

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.LimpiarControlesDetalle() 'Limpia los controles de formulario

            Me.CargarModoPagina()
        End Sub

        Public Sub LlenarJScriptSeccionDetalle()

        End Sub

        Public Sub LimpiarControlesDetalle()

        End Sub

        Private Sub CargarSeccionGrilla()
            ModoPaginaProceso = ""
            Me.LlenarGrilla()
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)

        End Sub

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable

            Dim oOpcionPerfilAccion As pdt_sg_opcion_perfil_accionBL

            Dim dt As DataTable

            Dim iIdOpcion As String = Me.Page.Request.Params(Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString())
            Dim iIdPerfil As String = Me.Page.Request.Params(Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString())

            oOpcionPerfilAccion = New pdt_sg_opcion_perfil_accionBL
            dt = oOpcionPerfilAccion.Lista_Opcion_Perfil_Accion(iIdPerfil, iIdOpcion, 0)
            If dt Is Nothing Then
                TotalRegistros = 0
            Else
                TotalRegistros = dt.Rows.Count
            End If

            oOpcionPerfilAccion = Nothing

            Return dt

        End Function

        Private Sub ReiniciarControles()
            Me.VisualizarControles(False)
            Me.hcodigo.Value = String.Empty
        End Sub

        Private Sub LimpiarControles()

        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnGrabar)
        End Sub

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

        Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            Try
                ModoPaginaProceso = ConstantesWeb.ModoPagina.Nuevo.ToString()
                If (Me.IsValid) AndAlso (Me.ValidarCampos()) Then
                    Dim strModoPagina As String = ModoPaginaProceso
                    Select Case ModoPaginaProceso
                        Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                            Me.Agregar()
                    End Select
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub grid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            If ((e.Row.RowType = ListItemType.AlternatingItem) OrElse (e.Row.RowType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Row.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Row.Height = Unit.Pixel(20)

                e.Row.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.col_SG_OPCION_PERFIL_ACCION.accic_iIdAccion.ToString()))
                Dim hIdOpcion As HiddenField = CType(e.Row.FindControl("hIdAccion"), HiddenField)
                hIdOpcion.Value = IdRegistro.ToString()

                Dim chkIdAccion As CheckBox = CType(e.Row.FindControl("chkIdAccion"), CheckBox)
                chkIdAccion.Checked = IIf(Convert.ToInt32(dr(Enumeradores.col_SG_OPCION_PERFIL_ACCION.ppacc_iEstado_Registro.ToString())) = 1, True, False)

                Dim strJs As String = HelperWeb.AsignarDatoControlHtml(Me.hcodigo.Name, IdRegistro.ToString())
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

        Protected Sub btnRegresar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegresar.Click
            Dim strIdPerfil As String = Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString()

            Dim IdPerfil As Integer = Me.Page.Request.Params(strIdPerfil)

            Response.Redirect("frmOpcionPerfil.aspx?" & strIdPerfil & "=" & IdPerfil)
        End Sub

#End Region

    End Class


End Namespace
