Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmlogin
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
            Dim dtUsuario As DataTable
            Dim lobjUsuarioBL As pdt_usuarioBL
            Dim lstrLogin As String = Me.txtLogin.Text
            Dim lstrClave As String = Me.txtClave.Text

            lobjUsuarioBL = New pdt_usuarioBL

            dtUsuario = lobjUsuarioBL.Detalle(lstrLogin, lstrClave)

            If Not (dtUsuario Is Nothing) Then
                Dim iRetorno As Integer = dtUsuario.Rows(0).Item(1)
                Dim iIdUsuario As Integer = dtUsuario.Rows(0).Item(0)
                Select Case iRetorno
                    Case 0
                        'Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Aqui ira el redirect al main...")
                        Session("login") = lstrLogin
                        Response.Redirect("IU/frmMain.aspx")
                    Case -1
                        Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("Por favor, verifique su ingreso")
                    Case -2
                        Response.Redirect("frmCambioPassword.aspx?" & Enumeradores.Col_SG_USUARIO.usuac_iId_Usuario.ToString() & "=" & iIdUsuario.ToString())
                End Select
            End If

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            'Me.lblAccion.Text = "MODIFICAR USUARIO"
            'If (Me.LlenarDatoControlesDetalle() > 0) Then
            '    Me.btnGrabar.Enabled = True
            '    Me.txtLoginN.Enabled = False
            'End If

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
            If (Me.txtLogin.Text.Trim().Length = 0) Then
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(Me.rfvLogin.ErrorMessage)
                Return False
            End If
            If (Me.txtClave.Text.Trim().Length = 0) Then
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(Me.rfvClave.ErrorMessage)
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
            Me.rfvLogin.ErrorMessage = "Falta el Login del usuario"
            Me.rfvLogin.ToolTip = Me.rfvLogin.ErrorMessage

            Me.rfvClave.ErrorMessage = "Falta la clave del usuario"
            Me.rfvClave.ToolTip = Me.rfvClave.ErrorMessage
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
            Session("login") = ""
            Me.txtLogin.Text = ""
            Me.txtClave.Text = ""
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

#End Region

    End Class

End Namespace

