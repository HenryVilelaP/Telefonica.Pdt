Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmCambioPassword
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
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion
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
            Dim lIntResult As Integer
            Dim lobjHistoriaCambioPasswordBL As pdt_sg_historia_cambio_passwordBL
            Dim lobjHistoriaCambioPasswordEnt As SG_HISTORIA_CAMBIO_PASSWORD
            Dim lstrClaveActual As String = Me.txtClaveActual.Text
            Dim lstrNuevaClave As String = Me.txtNuevaClave.Text
            Dim lstrRepetirNuevaClave As String = Me.txtRepetirNuevaClave.Text

            lobjHistoriaCambioPasswordBL = New pdt_sg_historia_cambio_passwordBL
            lobjHistoriaCambioPasswordEnt = New SG_HISTORIA_CAMBIO_PASSWORD

            lobjHistoriaCambioPasswordEnt.Usuac_iId_Usuario = Me.Page.Request.Params(Enumeradores.Col_SG_USUARIO.usuac_iId_Usuario.ToString())
            lobjHistoriaCambioPasswordEnt.Hcapc_vPassword = lstrNuevaClave
            lobjHistoriaCambioPasswordEnt.Hcapc_iIdUsuario_Registro = 1

            lIntResult = lobjHistoriaCambioPasswordBL.Insertar(lobjHistoriaCambioPasswordEnt, lstrClaveActual)

            Select Case lIntResult
                Case Is > 0
                    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Clave cambiada con exito.")
                Case -1
                    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Clave usada en anteriores oportunidades.")
                Case -2
                    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Clave actual no coincide.")
            End Select
            If lIntResult > 0 Then
                Response.Redirect("frmLogin.aspx")
            End If

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta
        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
        End Sub

        Public Sub CargarModoPagina() Implements IPaginaMantenimento.CargarModoPagina
            ModoPaginaProceso = ConstantesWeb.ModoPagina.Nuevo.ToString()
        End Sub

        Public Sub Eliminar() Implements IPaginaMantenimento.Eliminar

        End Sub

        Public Sub Modificar() Implements IPaginaMantenimento.Modificar

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            If (Me.txtClaveActual.Text.Trim().Length = 0) Then
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(Me.rfvClaveActual.ErrorMessage)
                Return False
            End If
            If (Me.txtNuevaClave.Text.Trim().Length = 0) Then
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(Me.rfvNuevaClave.ErrorMessage)
                Return False
            End If
            If (Me.txtRepetirNuevaClave.Text.Trim().Length = 0) Or (Me.txtNuevaClave.Text.Trim() <> Me.txtRepetirNuevaClave.Text.Trim()) Then
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(Me.rfvRepetirNuevaClave.ErrorMessage)
                Return False
            End If
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.CargarModoPagina()
        End Sub

        Public Sub LlenarJScriptSeccionDetalle()
            Me.rfvClaveActual.ErrorMessage = "Ingrese la clave actual"
            Me.rfvClaveActual.ToolTip = Me.rfvClaveActual.ErrorMessage

            Me.rfvNuevaClave.ErrorMessage = "Ingrese la nueva clave"
            Me.rfvNuevaClave.ToolTip = Me.rfvNuevaClave.ErrorMessage

            Me.rfvRepetirNuevaClave.ErrorMessage = "La nueva clave y su confirmación no coinciden"
            Me.rfvRepetirNuevaClave.ToolTip = Me.rfvNuevaClave.ErrorMessage
        End Sub

        Private Sub HacerControlComandoNetAjax()

        End Sub

        Private Sub CargarSeccionGrilla()
            ModoPaginaProceso = ""
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)

        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)

        End Sub

        Private Function ListarDataLlenarGrilla() As DataTable
            Return Nothing
        End Function

        Private Sub ReiniciarControles()
            Me.VisualizarControles(False)
        End Sub

        Private Sub LimpiarControles()
            Me.txtClaveActual.Text = ""
            Me.txtNuevaClave.Text = ""
            Me.txtRepetirNuevaClave.Text = ""
        End Sub

        Private Function LlenarDatoControlesDetalle() As Integer
            Return 0
        End Function


#End Region

#Region "Metodos Formulario"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If (Not Me.IsPostBack) Then
                    Me.CargarSeccionFormularioDetalle()
                    Me.LimpiarControles()
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try

        End Sub

        Protected Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            Try
                If (Me.IsValid) AndAlso (Me.ValidarCampos()) Then
                    Dim strModoPagina As String = ModoPaginaProceso
                    Select Case ModoPaginaProceso
                        Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                            Me.Agregar()
                    End Select
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Response.Redirect("frmLogin.aspx")
        End Sub

#End Region

    End Class

End Namespace


