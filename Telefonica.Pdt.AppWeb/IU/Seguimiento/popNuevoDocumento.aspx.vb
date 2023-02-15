Imports Telefonica.Pdt.Common

Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Business
Imports System.Data

Namespace Telefonica.Pdt.AppWeb

Partial Class popNuevoDocumento
    Inherits System.Web.UI.Page
    Implements IPaginaBase, IPaginaMantenimento

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

#Region "IPaginaBase"

    Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

    End Sub

    Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
        Me.LlenarLista()

    End Sub

    Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
        'Me.hGrillaIndicePagina.Value = "0"
    End Sub

    Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
        'Me.ReiniciarControles()
        'Me.hGrillaIndicePagina.Value
        Me.LlenarGrillaPaginacion(Convert.ToInt32(0))
    End Sub

    Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

        'Dim TotalRegistros As Integer = 0
        'Dim dt As DataTable = Me.ListarDataLlenarGrilla(Me.grid.PageSize, IndicePagina, TotalRegistros)

        'If Not (dt Is Nothing) Then
        '    Me.grid.DataSource = dt
        '    IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(TotalRegistros, Me.grid.PageSize, IndicePagina)
        '    Me.grid.CurrentPageIndex = IndicePagina
        '    Me.grid.VirtualItemCount = TotalRegistros

        '    'Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + Me.grid.VirtualItemCount.ToString()
        '    'Me.lblRegistrosEncontrados.Visible = True
        '    'Me.lblResultado.Visible = False
        'Else
        '    Me.grid.DataSource = Nothing

        '    'Me.lblResultado.Text = GRILLAVACIA
        '    'Me.lblResultado.Visible = True
        '    'Me.lblRegistrosEncontrados.Visible = False
        '    'Me.ibtnNuevo.Visible = False
        'End If

        'Try
        '    Me.grid.DataBind()

        'Catch ex As Exception
        '    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        'End Try

    End Sub


    Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
        'Me.rfvCodigo.ErrorMessage = "Falta el código del departamento"
        'Me.rfvCodigo.ToolTip = Me.rfvCodigo.ErrorMessage

        'Me.rfvDescripcion.ErrorMessage = "Falta la descripcion del departamento"
        'Me.rfvDescripcion.ToolTip = Me.rfvDescripcion.ErrorMessage

    End Sub

    Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

    End Sub

    Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

    End Function

#End Region

#Region "IPaginaMantenimento"

    Public Sub Agregar() Implements IPaginaMantenimento.Agregar

            'Dim oDocumentacion As pdt_documentacionBL
            'Dim oDocumentacionEnt As pdt_documentacion

            'oDocumentacionEnt = New pdt_documentacion

            'oDocumentacionEnt.Tipo = lstTipos.SelectedItem.Text
            'oDocumentacionEnt.Publicado = "No"
            'oDocumentacionEnt.Publicador = "No"
            'oDocumentacionEnt.Aprobador = "Edwin Purizaca"
            'oDocumentacionEnt.Estado = "Validado OK"

            'oDocumentacion = New pdt_documentacionBL
            'oDocumentacion.Insertar_Documentacion(oDocumentacionEnt)
            'oDocumentacion = Nothing

            'oDocumentacionEnt = Nothing

    End Sub

    Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

    End Sub

    Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar

    End Sub

    Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo

    End Sub

    Public Sub CargarModoPagina() Implements IPaginaMantenimento.CargarModoPagina

    End Sub

    Public Sub Eliminar() Implements IPaginaMantenimento.Eliminar

    End Sub

    Public Sub Modificar() Implements IPaginaMantenimento.Modificar
        'Dim oPdT_CiuBE As New PdT_CiuBE

        'oPdT_CiuBE.COD_DPTO = NullableString.Parse(ddlDepartamentoFiltro.SelectedValue.ToString)
        'oPdT_CiuBE.COD_CIU = Me.TxtCodigo.Text
        'oPdT_CiuBE.DESCR = NullableString.Parse(Me.txtDescripcion.Text.ToUpper())
        'oPdT_CiuBE.USU_MOD = NullableString.Parse(CurrentSession.CodigoUsuario)

        'Dim oCCiudad As New CCiudad
        'Dim retorno As Integer = oCCiudad.Modifica(oPdT_CiuBE)
        'If (retorno > 0) Then
        '    ModoPaginaProceso = ""
        '    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("El registro se modifico con exito")
        '    Me.LlenarGrilla()
        'End If

    End Sub

    Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos

    End Function


#End Region

#Region "Metodos Privados"

    Private Sub LlenarLista()

            'Me.lstTipos.Items.Clear()
            'Dim opdt_estadosBL As New pdt_tipodocumentoBL

            'Dim dt As DataTable = opdt_estadosBL.Listar_Tipodocumento()

            'If Not (dt Is Nothing) Then
            '    Dim dw As DataView = dt.DefaultView
            '    dw.Sort = Enumeradores.ColPdt_TipoDocumento.identTipo.ToString() + ConstantesWeb.ESPACIO + ConstantesWeb.OrderCriterioASC
            '    Me.lstTipos.DataSource = dw

            'End If

            'Me.lstTipos.DataTextField = Enumeradores.ColPdt_TipoDocumento.DescrTipo.ToString
            'Me.lstTipos.DataValueField = Enumeradores.ColPdt_TipoDocumento.identTipo.ToString
            'Me.lstTipos.DataBind()

        'HelperWeb.ComboAddItemSelecionar(Me.ddlZonal)
        'HelperWeb.ComboSeleccionarItem(Me.ddlZonal, "g")

    End Sub

    Private Sub ReiniciarControles()
        'Me.LimpiarControles()
        'Me.hCodigo.Value = ""
        'Me.panelDetalle.Visible = False
    End Sub

    Private Sub LimpiarControles()
        'Me.txtDescripcion.Text = ""
        'Me.TxtCodigo.Text = ""
    End Sub

#End Region

#Region "Metodos Formulario"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.RegistrarJScript()
            If (Not Me.IsPostBack) Then
                    Me.LlenarLista()
            End If
        Catch ex As Exception
            HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
        End Try
    End Sub

    Private Sub btnPublicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPublicar.Click
        Agregar()
    End Sub

#End Region


End Class

End Namespace
