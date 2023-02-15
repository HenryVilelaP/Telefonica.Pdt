Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Partial Class frmAdminListaCotizacion
        Inherits WebPaginaBase
        Implements IPaginaBase

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoNuevaVersion As String = "GrillaEventoNuevaVersion"
        Private Const ConstGrillaEventoMostrarDetalle As String = "GrillaEventoMostrarDetalle"
        Private Shared ModoPaginaProceso As String = ""
        Private _IdCotizacionSeleccionada As Integer

        Public Property IdCotizacionSeleccionada() As Integer
            Get
                Return _IdCotizacionSeleccionada
            End Get
            Set(ByVal value As Integer)
                _IdCotizacionSeleccionada = value
            End Set
        End Property

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
                    Me.LlenarCombos()
                    Me.LlenarDatos()
                    Me.calFechaRegistroInicio.Fecha = DateTime.Now.ToShortDateString
                    Me.calFechaRegistroFin.Fecha = DateTime.Now.ToShortDateString
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
            Try
                Me.hGrillaIndicePagina.Value = "0"
                Me.ReiniciarControles()
                Me.LlenarGrilla()
                Me.UpdatePanelGrilla.Update()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub grid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            If (e.Row.RowType = DataControlRowType.Header) Then
                e.Row.Cells(2).ToolTip = "Hola Mundo... "
            ElseIf (e.Row.RowType = DataControlRowType.DataRow) Then
                Dim drw As DataRowView = CType(e.Row.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Row.Height = Unit.Pixel(20)

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_COTIZACION.cotic_iIdCotizacion.ToString()))
                Dim Cadena As String = HelperWeb.AsignarDatoControlHtml(Me.hCodigo.ClientID, IdRegistro.ToString())

                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)

                Cadena = HelperWeb.JsConfirmarAccionProceso("¿Desea crear una nueva version de la cotizacion seleccionada?")

                Dim imgbtnNuevaVersion As ImageButton

                imgbtnNuevaVersion = e.Row.FindControl("imgbtnNuevaVersion")
                If Not imgbtnNuevaVersion Is Nothing Then
                    imgbtnNuevaVersion.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick.ToString(), Cadena)
                End If
            End If
        End Sub

        Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            Me.hCodigo.Value = "0"
            Response.Redirect("~/IU/Seguimiento/frmdetallecotizacion.aspx")
        End Sub

        Protected Sub grid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grid.PageIndexChanging
            Try
                Me.hGrillaIndicePagina.Value = e.NewPageIndex.ToString()
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub grid_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
            Dim intIdCotizacion As Int32
            Dim objCotizacionBL As pdt_CotizacionBL
            Dim intNumeroFilasAfectadas As Integer

            If hCodigo.Value.ToString().Trim().Length > 0 Then

                intIdCotizacion = Convert.ToInt32(hCodigo.Value)

                If e.CommandName = ConstGrillaEventoNuevaVersion Then
                    objCotizacionBL = New pdt_cotizacionBL
                    intNumeroFilasAfectadas = objCotizacionBL.InsertarNuevaVersion(intIdCotizacion, Me.PAG_IdUsuario_InicioSesion)
                    If intNumeroFilasAfectadas = 1 Then
                        NetAjax.JsMensajeAlert(Me.Page, "Se creo una nueva versión de la cotizacion seleccionada.")
                    End If

                    Me.LlenarGrilla()
                End If
            End If
        End Sub
#End Region

#Region "IPaginaBase"
        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles

        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboTipoEstado()
        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion
            Dim TotalRegistros As Integer = 0
            Dim dt As DataTable = Me.ListarDataLlenarGrilla()

            If Not (dt Is Nothing) Then
                TotalRegistros = dt.Rows.Count
                Me.grid.DataSource = dt
                indicePagina = HelperWeb.ValidarIndicePaginacionGrilla(TotalRegistros, Me.grid.PageSize, indicePagina)
                Me.grid.PageIndex = indicePagina
                lblResultado.Visible = False
                Dim strMensaje As String = ConstantesWeb.TotalRegistrosEncontrados & dt.Rows.Count.ToString()
                Me.lblRegistrosEncontrados.Text = strMensaje
                Me.lblRegistrosEncontrados.Visible = True
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.lblResultado.Visible = True
                Me.lblRegistrosEncontrados.Text = ""
                Me.lblRegistrosEncontrados.Visible = False
            End If

            Try
                Me.grid.DataBind()
            Catch ex As Exception
                Me.grid.PageIndex = 0
                Me.grid.DataBind()
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.UpdateProgress1)
        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript

        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function
#End Region

#Region "Metodos Privados"
        Private Sub LlenarComboTipoEstado()
            HelperWeb.LlenarComboRegistroTablaTablas(Enumeradores.Cabecera_Tabla_Tablas.Tab_Estado_Cotizacion, _
                                                    Enumeradores.TextoMostrarCombo.Seleccionar, _
                                                    ddlEstadoCotizacion)
        End Sub

        Private Function ListarDataLlenarGrilla() As DataTable
            'Dim opdt_coti As pdt_cotizacion
            Dim strRuc As String
            Dim strCodigoClienteAtis As String
            Dim strNumeroCotizacion As String
            Dim intEstadoCotizacion As Integer
            Dim strNombreCliente As String
            Dim dtFechaInicio As Nullable(Of Date)
            Dim dtFechaFin As Nullable(Of Date)

            strRuc = Me.nbRuc.Text.Trim()
            strCodigoClienteAtis = Me.nbClienteAtis.Text.Trim()
            strNumeroCotizacion = Me.nbNumeroCotizacion.Text
            Integer.TryParse(Me.ddlEstadoCotizacion.SelectedItem.Value, intEstadoCotizacion)
            strNombreCliente = Me.txtNombreCliente.Text.Trim

            If Me.calFechaRegistroInicio.Fecha.Length > 0 Then
                dtFechaInicio = Convert.ToDateTime(Me.calFechaRegistroInicio.Fecha)
            Else
                dtFechaInicio = Nothing
            End If

            If Me.calFechaRegistroFin.Fecha.Length > 0 Then
                dtFechaFin = Convert.ToDateTime(Me.calFechaRegistroFin.Fecha)
            Else
                dtFechaFin = Nothing
            End If

            Dim objCotizacionBL As New pdt_cotizacionBL

            Dim dt As DataTable = objCotizacionBL.ListarCotizacion(strRuc, strCodigoClienteAtis, strNumeroCotizacion, _
                                                       intEstadoCotizacion, strNombreCliente, _
                                                       dtFechaInicio, dtFechaFin)

            Return dt
        End Function

        Private Sub ReiniciarControles()
            Me.hCodigo.Value = ""
        End Sub

        Private Sub LimpiarControles()

        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnConsultar)
        End Sub
#End Region

    End Class

End Namespace
