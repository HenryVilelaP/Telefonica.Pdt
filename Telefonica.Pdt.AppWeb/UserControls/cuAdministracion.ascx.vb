Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business


Namespace Telefonica.Pdt.AppWeb

    Partial Class cuAdministracion
        Inherits System.Web.UI.UserControl
        Implements IPaginaBase

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

#End Region

#Region "Metodos Formulario"
        Protected Sub btnCambiarEstado_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiarEstado.Click
            Me.ActualizaEstado()

        End Sub

        Protected Sub btnCambiarOperacionComercial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiarOperacionComercial.Click
            Me.ActualizaTipoOperacionComercial()

        End Sub

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            Try
                Me.RegistrarJScript()
                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarCombos()
                End If
            Catch ex As Exception
                'Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

#End Region

#Region "IPaginaBase"
        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboEstados()
            Me.LlenarComboTipoOperacionComercial()

        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos

        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla

        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable
            Return Nothing

        End Function

#End Region

#Region "Metodos Privados"

        Private Sub LlenarComboEstados()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Estado_Pedido, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlEstado)

        End Sub

        Private Sub LlenarComboTipoOperacionComercial()
            Me.ddlOperacionComercial.Items.Clear()
            Dim opdt_tip_ope_comBL As New pdt_tip_ope_comBL
            Dim dt As DataTable

            dt = opdt_tip_ope_comBL.Listar_TIP_OPE_COM(0)

            If Not (dt Is Nothing) Then
                Dim dw As DataView = dt.DefaultView
                dw.Sort = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
                Me.ddlOperacionComercial.DataSource = dw

            End If

            Me.ddlOperacionComercial.DataTextField = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_vDescripcion.ToString()
            Me.ddlOperacionComercial.DataValueField = Enumeradores.Col_PDTT_TIP_OPE_COM.tococ_iIdTip_Ope_Com.ToString()
            Me.ddlOperacionComercial.DataBind()

            HelperWeb.ComboAddItemTodos(Me.ddlOperacionComercial)

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


        Private Sub ActualizaTipoOperacionComercial()
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim intTipoOperacionComercial As Integer
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intIdPedido As Integer

            opdt_pedidoBL = New pdt_pedidoBL
            intUsuarioModifica = 10
            intIdPedido = IdPedidoProducto

            If Me.ddlOperacionComercial.SelectedIndex = -1 Then
                NetAjax.JsMensajeAlert(Me.Page, "Seleccione un Tipo de Operación Comercial")
            Else
                intTipoOperacionComercial = Convert.ToInt32(Me.ddlOperacionComercial.SelectedItem.Value)
            End If
            lintResult = opdt_pedidoBL.Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION(intIdPedido, intTipoOperacionComercial, intUsuarioModifica)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede guardar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
            End Select

        End Sub
        Private Sub ActualizaEstado()
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim intEstado As Integer
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intPedido As Integer

            intPedido = IdPedidoProducto
            intUsuarioModifica = 9
            opdt_pedidoBL = New pdt_pedidoBL

            If Me.ddlEstado.SelectedIndex = -1 Then
                NetAjax.JsMensajeAlert(Me.Page, "Seleccione un estado")
            Else
                intEstado = Convert.ToInt32(Me.ddlEstado.SelectedItem.Value)
            End If

            lintResult = opdt_pedidoBL.Actualiza_ESTADO_PEDIDO_ADMINISTRACION(intPedido, intEstado, intUsuarioModifica)

            Select Case lintResult
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede guardar")
                Case Is > 0
                    NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
            End Select

        End Sub

#End Region

    End Class

End Namespace
