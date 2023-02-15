
Imports System.Data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities


Namespace Telefonica.Pdt.AppWeb


    Partial Class cuSeguimiento
        Inherits System.Web.UI.UserControl
        Implements IPaginaBase


#Region " C�digo generado por el Dise�ador de Web Forms "

        'El Dise�ador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Dise�ador de Web Forms necesita la siguiente declaraci�n del marcador de posici�n.
        'No se debe eliminar o mover.

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Dise�ador de Web Forms requiere esta llamada de m�todo
            'No la modifique con el editor de c�digo.
            InitializeComponent()
        End Sub

#End Region

#Region "Constantes - Variables"
        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
#End Region

        Private _numeroPedidoWeb As String

        Public Property NumeroPedidoWeb() As Integer
            Get
                Return _numeroPedidoWeb
            End Get
            Set(ByVal Value As Integer)
                _numeroPedidoWeb = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aqu� el c�digo de usuario para inicializar la p�gina
            Try
                Me.RegistrarJScript()
                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarCombos()
                    Me.LlenarDatos()
                    Me.LlenarGrilla()
                End If
            Catch ex As Exception
                Dim ltlMensaje As Literal
                ltlMensaje = CType(Page.FindControl("ltlMensaje"), Literal)
                ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos

        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
            ViewState.Add("GrillaIndicePagina", 0)
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.LlenarGrillaPaginacion(Convert.ToInt32(ViewState.Item("GrillaIndicePagina")))
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion
            Dim dt As DataTable = Me.ListarDataLlenarGrilla()

            If Not (dt Is Nothing) Then
                Me.grid.DataSource = dt
                Me.grid.CurrentPageIndex = indicePagina
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + Me.grid.VirtualItemCount.ToString()
                Me.lblRegistrosEncontrados.Visible = True
                Me.lblResultado.Visible = False
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.lblResultado.Visible = True
                Me.lblRegistrosEncontrados.Visible = False
            End If

            Try
                Me.grid.DataBind()
            Catch ex As Exception
                Dim ltlMensaje As Literal
                ltlMensaje = CType(Page.FindControl("ltlMensaje"), Literal)
                ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

        Private Function ListarDataLlenarGrilla() As DataTable
            Dim dt As DataTable
            Dim opdt_bitacoraBL As New pdt_bitacoraBL()

            dt = opdt_bitacoraBL.Listar_Datos_Historico_Seguimiento(NumeroPedidoWeb)
            Return dt            
        End Function

    End Class

End Namespace
