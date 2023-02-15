Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Public Class perfil
        Inherits WebPaginaBase
        Implements IPaginaBase, IPaginaMantenimento

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoEliminar As String = "GrillaEventoEliminar"
        Private Const ConstGrillaEventoMostrarDetalle As String = "GrillaEventoMostrarDetalle"
        Private Shared ModoPaginaProceso As String = ""

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles
            pnlFrmPerfil.Visible = False
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos

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

            Dim lobjPerfilEnt As SG_PERFIL
            Dim lobjPerfilBL As pdt_perfilBL

            lobjPerfilEnt = New SG_PERFIL

            lobjPerfilEnt.Perfc_iIdPerfil = 0
            lobjPerfilEnt.Perfc_vDescripcion = txtDescripcion.Text
            lobjPerfilEnt.Perfc_vNemotecnico = txtNemonico.Text
            lobjPerfilEnt.Perfc_iIdUsuario_Registro = 1

            lobjPerfilBL = New pdt_perfilBL

            Dim lintResult As Integer
            lintResult = lobjPerfilBL.Insertar(lobjPerfilEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            Me.lblAccion.Text = "MODIFICAR USUARIO"
            If (Me.LlenarDatoControlesDetalle() > 0) Then
                Me.btnGrabar.Enabled = True
            End If

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
            Me.lblAccion.Text = "NUEVO USUARIO"
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

            Dim lobjPerfilEnt As SG_PERFIL
            Dim lobjPerfilBL As pdt_perfilBL

            lobjPerfilEnt = New SG_PERFIL

            lobjPerfilEnt.Perfc_iIdPerfil = Me.hcodigo.Value
            lobjPerfilEnt.Perfc_vDescripcion = Me.txtDescripcion.Text
            lobjPerfilEnt.Perfc_vNemotecnico = Me.txtNemonico.Text
            lobjPerfilEnt.Perfc_iIdUsuario_Modifica = 1

            lobjPerfilBL = New pdt_perfilBL

            Dim lintResult As Integer
            lintResult = lobjPerfilBL.Modificar(lobjPerfilEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            If (Me.txtDescripcion.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvDescripcion.ErrorMessage)
                Return False
            End If
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Function LlenarDatoControlesDetalle() As Integer
            Dim IdPerfil As Integer = Convert.ToInt32(Me.hcodigo.Value)
            Dim opdt_perfilBL As New pdt_perfilBL
            Dim oSG_PERFIL As SG_PERFIL = opdt_perfilBL.Detalle(IdPerfil)

            If Not (oSG_PERFIL Is Nothing) Then
                Me.txtId.Text = IdPerfil
                Me.txtDescripcion.Text = oSG_PERFIL.Perfc_vDescripcion
                Me.txtNemonico.Text = oSG_PERFIL.Perfc_vNemotecnico
                Return 1
            End If

            Return 0

        End Function

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.LimpiarControlesDetalle() 'Limpia los controles de formulario
            Me.pnlFrmPerfil.Visible = True

            Me.CargarModoPagina()
        End Sub

        Public Sub LlenarJScriptSeccionDetalle()
            Me.rfvDescripcion.ErrorMessage = "Falta la descripcion del perfil"
            Me.rfvDescripcion.ToolTip = Me.rfvDescripcion.ErrorMessage
        End Sub

        Public Sub LimpiarControlesDetalle()
            'Me.hcodigo.Value = ""
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
            Me.txtNemonico.Text = ""
        End Sub

        Private Sub CargarSeccionGrilla()
            pnlFrmPerfil.Visible = False
            lblAccion.Text = ""
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

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable

            Dim oPerfil As pdt_perfilBL

            Dim dt As DataTable

            oPerfil = New pdt_perfilBL
            dt = oPerfil.Listar_Perfil()
            If dt Is Nothing Then
                TotalRegistros = 0
            Else
                TotalRegistros = dt.Rows.Count
            End If

            oPerfil = Nothing

            Return dt

        End Function

        Private Sub ReiniciarControles()
            'Me.VisualizarControlesDetalle(False)
            Me.VisualizarControles(False)
            Me.hcodigo.Value = String.Empty
        End Sub

        Private Sub LimpiarControles()
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
            Me.txtNemonico.Text = ""
        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnNuevo)
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

        Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
            Try
                Dim lstrCurrentCommand As String = e.CommandName()

                Dim lintIdPerfil As Integer = Convert.ToInt32(Me.hcodigo.Value)

                Select Case lstrCurrentCommand
                    Case ConstGrillaEventoModificar
                        ModoPaginaProceso = ConstantesWeb.ModoPagina.Modificar.ToString()
                        Me.CargarSeccionFormularioDetalle()
                        Me.UpdatePanelDetalle.Update()
                    Case ConstGrillaEventoEliminar

                    Case ConstGrillaEventoMostrarDetalle
                        Me.Page.Response.Redirect("frmOpcionPerfil.aspx?" & Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString() & "=" & lintIdPerfil.ToString())
                End Select
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

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString()))

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

#End Region

    End Class

End Namespace
