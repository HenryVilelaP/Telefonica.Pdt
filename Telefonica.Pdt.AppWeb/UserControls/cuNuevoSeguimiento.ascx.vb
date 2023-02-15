Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business

Namespace Telefonica.Pdt.AppWeb

    Partial Class cuNuevoSeguimiento
        Inherits System.Web.UI.UserControl        

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.

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
        Private Shared ModoPaginaProceso As String = ""

#End Region

#Region "Metodos Privados"

        Public Sub LlenarCombos()
            Me.LlenarListas()
            Me.LlenarComboAño()
            Me.LlenarComboMes()

        End Sub

        Private Sub GrabarNuevoSeguimiento()
            Dim oBITACORAEnt As BITACORA
            Dim opdt_bitacoraBL As pdt_bitacoraBL

            oBITACORAEnt = New BITACORA
            opdt_bitacoraBL = New pdt_bitacoraBL

            oBITACORAEnt.Pdtic_iIdPedido = IdPedidoProducto
            oBITACORAEnt.Cobic_vDescripcion = Me.txtObservacion.Text

            If Me.lstDestino.SelectedIndex = -1 Then
                NetAjax.JsMensajeAlert(Me.Page, "Seleccione un destino")
            Else
                oBITACORAEnt.Vdesc_iIdDestino = Convert.ToInt32(Me.lstDestino.SelectedItem.Value)
            End If

            If Me.lstTratamiento.SelectedIndex = -1 Then
                NetAjax.JsMensajeAlert(Me.Page, "Seleccione un tratamiento")
            Else
                oBITACORAEnt.Vtrac_iIdTratamiento = Convert.ToInt32(Me.lstTratamiento.SelectedItem.Value)
            End If

            oBITACORAEnt.Cobic_iIdUsuario_Registro = 1

            Dim lintResult As Integer
            lintResult = opdt_bitacoraBL.Insertar(oBITACORAEnt)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede guardar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                    Me.UpdatePanelCalendario.Update()
            End Select

        End Sub

        Private Sub AniosDetalleCalendario()
            Dim xAnioActual As Integer = Me.calFecha.SelectedDate.Year
            Dim yAnioNuevo As Integer = Convert.ToInt32(Me.ddlAño.SelectedValue)
            Dim diferencia As Integer = yAnioNuevo - xAnioActual

            Dim NuevaFecha As DateTime = Me.calFecha.SelectedDate.AddYears(diferencia)
            Me.calFecha.SelectedDate = NuevaFecha
            Me.calFecha.VisibleDate = NuevaFecha
        End Sub

        Private Sub MesesDetalleCalendario()
            Dim xMesActual As Integer = Me.calFecha.SelectedDate.Month
            Dim yMesNuevo As Integer = Convert.ToInt32(Me.ddlMes.SelectedValue)
            Dim diferencia As Integer = yMesNuevo - xMesActual

            Dim NuevaFecha As DateTime = Me.calFecha.SelectedDate.AddMonths(diferencia)
            Me.calFecha.SelectedDate = NuevaFecha
            Me.calFecha.VisibleDate = NuevaFecha

        End Sub

        Private Sub LlenarListas()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Destino, Me.lstTratamiento)
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Tratamiento, Me.lstDestino)

        End Sub

        Private Sub LlenarComboAño()
            Dim periodoIniciar As Integer = DateTime.Now.Year
            Dim periodoFinal As Integer = DateTime.Now.Year + 8

            Dim dt As DataTable = HelperWeb.RangoNumerosDataTable(periodoIniciar, periodoFinal)
            Me.ddlAño.DataSource = dt
            Me.ddlAño.DataTextField = "IdNumero"
            Me.ddlAño.DataValueField = "Numero"
            Me.ddlAño.DataBind()

        End Sub

        Private Sub LlenarComboMes()
            HelperWeb.LlenarComboRegistroTablaTablas(Convert.ToInt32(Enumeradores.Cabecera_Tabla_Tablas.Tab_Meses_Año), Enumeradores.TextoMostrarCombo.Ninguno, Me.ddlMes)

        End Sub

        Private Sub ReiniciarControles()

        End Sub

        Private Sub LimpiarControles()

        End Sub

#End Region

#Region "Metodos Formulario"

        Private Sub HacerControlComandoNetAjax(ByVal oScriptManager As ScriptManager)
            NetAjax.RegistroControlPostBackControlAsync(oScriptManager, Me.ddlAño)
            NetAjax.RegistroControlPostBackControlAsync(oScriptManager, Me.ddlMes)

        End Sub

        Public Sub CargarDatosControlUsuario(ByVal oScriptManager As ScriptManager)
            Me.HacerControlComandoNetAjax(oScriptManager)
            Me.LlenarCombos()

        End Sub

        Public Property IdPedidoProducto() As Integer
            Get
                If (Me.hCodigo.Value.Trim().Length = 0) Then
                    Me.hCodigo.Value = "0"
                End If
                Return Convert.ToInt32(Me.hCodigo.Value)
            End Get

            Set(ByVal value As Integer)
                Me.hCodigo.Value = Convert.ToInt32(value)
            End Set

        End Property

        Protected Sub ddlAño_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAño.SelectedIndexChanged
            Me.AniosDetalleCalendario()
            Me.UpdatePanelCalendario.Update()

        End Sub

        Protected Sub ddlMes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMes.SelectedIndexChanged
            Me.MesesDetalleCalendario()
            Me.UpdatePanelCalendario.Update()

        End Sub

        Protected Sub btnIngresarSeguimiento_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnIngresarSeguimiento.Click
            Try
                Me.GrabarNuevoSeguimiento()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try

        End Sub

#End Region

    End Class

End Namespace
