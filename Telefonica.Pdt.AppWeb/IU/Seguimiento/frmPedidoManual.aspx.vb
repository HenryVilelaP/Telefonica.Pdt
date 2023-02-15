Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business
Imports System.Data

Namespace Telefonica.Pdt.AppWeb
    Partial Class frmPedidoManual
        Inherits WebPaginaBase
        Implements IPaginaBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents ibtnGuardar As System.Web.UI.WebControls.ImageButton
        Protected WithEvents hGrillaIndicePagina As System.Web.UI.HtmlControls.HtmlInputHidden


        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

#Region "Constantes - Variables"


        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoEliminar As String = "GrillaEventoEliminar"
        Private Shared ModoPaginaProceso As String = ""

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboZonal()
            Me.LlenarComboTipoDocumento()
            Me.LlenarComboSegmento()
            Me.LlenarComboSubSegmento()
            Me.LlenarComboPaquetesComplejos()        

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

#Region "Metodos Privados"

        Private Sub LlenarComboZonal()            
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Zonas, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlzonal)

        End Sub

        Private Sub LlenarComboTipoDocumento()            
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Documento_Identidad_Personal, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlTipoDocumento)

        End Sub

        Private Sub LlenarComboSegmento()            
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Segmento, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlsegmento)

        End Sub

        Private Sub LlenarComboSubSegmento()            
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Sub_Segmento, Enumeradores.TextoMostrarCombo.Seleccionar, Me.ddlSubSegmento)

        End Sub

        Private Sub LlenarComboPaquetesComplejos()
            Dim opdt_paqueteBL As New pdt_paqueteBL

            Dim dt As DataTable = opdt_paqueteBL.Listar_Paquete

            If Not (dt Is Nothing) Then
                Dim dw As DataView = dt.DefaultView
                dw.Sort = Enumeradores.Col_PAQUETE.paqtc_vDescripcion.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioDESC
                Me.ddlProductosComplejos.DataSource = dw

            End If

            Me.ddlProductosComplejos.DataTextField = Enumeradores.Col_PAQUETE.paqtc_vDescripcion.ToString()
            Me.ddlProductosComplejos.DataValueField = Enumeradores.Col_PAQUETE.paqtc_iIdPaquete.ToString()
            Me.ddlProductosComplejos.DataBind()

            HelperWeb.ComboAddItemSeleccionar(Me.ddlProductosComplejos)

            dt.Dispose()
            dt = Nothing

        End Sub

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable
            Return Nothing

        End Function

        Private Function LlenarControlesDetalle() As Integer

        End Function

        Private Sub ReiniciarControles()

        End Sub

        Private Sub LimpiarControles()

        End Sub

#End Region

#Region "Metodos Formulario"
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try

        End Sub

        Private Sub btnRegistrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRegistrar.Click
            Try                
                Me.RegistrarPedido()                

            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try

        End Sub

        Private Sub RegistrarPedido()
            Dim opdt_pedidoBL As New pdt_pedidoBL()
            Dim entPdt_pedido As New PEDIDO
            Dim intIdPedido As Integer

            entPdt_pedido.Vzonc_iIdZona = Convert.ToInt32(Me.ddlzonal.SelectedItem.Value)
            entPdt_pedido.Pdtic_vNombre_Contacto = Me.txtNombreContacto.Text
            entPdt_pedido.Pdtic_vTelefono_Contacto = Me.txttelefonodocumento.Text
            entPdt_pedido.Pdtic_iIdUsuario_Vendedor = Me.txtCodigoVendedor.Text
            entPdt_pedido.Pdtic_vNombre_Cliente = Me.txtcliente.Text
            entPdt_pedido.Vtdoc_iIdTip_Doc = Convert.ToInt32(Me.ddlTipoDocumento.SelectedItem.Value)
            entPdt_pedido.Pdtic_vNum_Doc = Me.txtnumerodocumento.Text
            entPdt_pedido.Vpaqc_iIdPaquete = Convert.ToInt32(Me.ddlProductosComplejos.SelectedItem.Value)
            entPdt_pedido.Segmc_iIdSegmento = Convert.ToInt32(Me.ddlsegmento.SelectedItem.Value)
            entPdt_pedido.Sessc_iIdSub_Segmento = Convert.ToInt32(Me.ddlSubSegmento.SelectedItem.Value)
            entPdt_pedido.Pdtic_iIdUsuario_Registro = Me.PAG_IdUsuario_InicioSesion

            intIdPedido = opdt_pedidoBL.Registrar_Pedido_Manual(entPdt_pedido)

            Me.hIdPedido.Value = intIdPedido.ToString
            Me.hIdPaquete.Value = entPdt_pedido.Vpaqc_iIdPaquete

            Select Case intIdPedido
                Case -1
                    NetAjax.JsMensajeAlert(Me.Page, "No se puede guardar")
                    
            End Select

        End Sub
#End Region

    End Class

End Namespace
