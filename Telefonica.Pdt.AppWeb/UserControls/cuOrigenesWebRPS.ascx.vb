Imports System
Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.AppWeb

Partial Class UserControls_cuOrigenesWebRPS
    Inherits System.Web.UI.UserControl

#Region "Definicion de Variables"
    Private dtCabeceraPedidoWebRPS As DataTable = Nothing
    Private dtDetallePedidoWebRPS As DataTable = Nothing
    Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
#End Region

    Public Sub LlenarDatosWebRPS(ByVal IdPedidoProducto As Integer)
        Try
            Me.Clear()
            Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
            Me.LlenarDatosTablasWebRPS()
            Me.LlenarDatosGrillaCabeceraPedido()
            Me.LlenarDatosGrillaDetallePedido()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Clear()
        Me.hIdPedidoProducto.Value = ""
        Me.dtCabeceraPedidoWebRPS = Nothing
        Me.dtDetallePedidoWebRPS = Nothing
    End Sub


    Private Sub LlenarDatosTablasWebRPS()
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        opdt_tr_origenesBL.Listar_TR_WEBRPS_Datos(Convert.ToInt32(Me.hIdPedidoProducto.Value), dtCabeceraPedidoWebRPS, dtDetallePedidoWebRPS)

    End Sub

    Private Sub LlenarDatosGrillaCabeceraPedido()
        Me.LlenarGrilla(Me.grid2, Me.lblResultado2, 0, dtCabeceraPedidoWebRPS)
    End Sub

    Private Sub LlenarDatosGrillaDetallePedido()
        Me.LlenarGrilla(Me.grid3, Me.lblResultado3, 0, dtDetallePedidoWebRPS)
    End Sub

    Private Sub LlenarGrilla(ByVal oGrid As DataGrid, ByVal lblControlResulrado As Label, ByVal indicePagina As Integer, ByVal dt As DataTable)

        If Not (dt Is Nothing) Then
            oGrid.DataSource = dt
            indicePagina = HelperWeb.ValidarIndicePaginacionGrilla(dt.Rows.Count, oGrid.PageSize, indicePagina)
            oGrid.CurrentPageIndex = indicePagina
            lblControlResulrado.Visible = False
        Else
            oGrid.DataSource = Nothing
            lblControlResulrado.Text = GRILLAVACIA
            lblControlResulrado.Visible = True
        End If

        Try
            oGrid.DataBind()
        Catch ex As Exception
            oGrid.CurrentPageIndex = 0
            oGrid.DataBind()
            Throw ex
        End Try
    End Sub






End Class
