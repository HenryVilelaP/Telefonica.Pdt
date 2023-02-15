Imports System
Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.AppWeb

Partial Class UserControls_cuOrigenesGestel
    Inherits System.Web.UI.UserControl

    Public Sub LlenarDatosGestel(ByVal IdPedidoProducto As Integer)
        Try
            Me.Clear()
            Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
            Dim oBE As FUENTE_PEDIDO_LEGACIE = Me.FuentePedidoLegacie(IdPedidoProducto)
            If Not (oBE Is Nothing) Then
                Dim IdRegistro As Decimal = oBE.Pdtic_nCod_Pedido_Legacie.Value
                Me.hCodigoLegacie.Value = IdRegistro.ToString()
                Me.LlenarDatos()
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Clear()
        Me.hIdPedidoProducto.Value = ""

        Me.lblFechaPedidoGestel.Text = ""
        Me.lblEstado.Text = ""
        Me.lblOrdenServicio.Text = ""
        Me.lblTelefono.Text = ""

        Me.lblArea1.Text = ""
        Me.lblArea2.Text = ""
        Me.lblArea3.Text = ""

        Me.lblEstacion1.Text = ""
        Me.lblEstacion2.Text = ""
        Me.lblEstacion3.Text = ""

        Me.lblFecha1.Text = ""
        Me.lblFecha2.Text = ""
        Me.lblFecha3.Text = ""

        Me.lblEstado1.Text = ""
        Me.lblEstado2.Text = ""
        Me.lblEstado3.Text = ""

        Me.lblUrd1.Text = ""
        Me.lblUrd2.Text = ""
        Me.lblUrd3.Text = ""

    End Sub

    Private Function FuentePedidoLegacie(ByVal IdPedidoProducto As Integer) As FUENTE_PEDIDO_LEGACIE
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oBE As FUENTE_PEDIDO_LEGACIE = opdt_tr_origenesBL.DetalleFuentePedidoLegacie(IdPedidoProducto)
        Return oBE

    End Function

    Private Sub LlenarDatos()
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oBE As TR_GESTEL = opdt_tr_origenesBL.Detalle_TR_GESTEL(Convert.ToInt32(Me.hCodigoLegacie.Value))
        If Not (oBE Is Nothing) Then
            Me.lblFechaPedidoGestel.Text = oBE.FecRegistro
            Me.lblEstado.Text = oBE.Estado
            Me.lblOrdenServicio.Text = oBE.Ooss
            Me.lblTelefono.Text = oBE.Telefono

            Me.lblArea1.Text = "Planta Interna"
            Me.lblArea2.Text = "Planta Externa"
            Me.lblArea3.Text = "MDF"

            Me.lblEstacion1.Text = oBE.Planta_interna
            Me.lblEstacion2.Text = oBE.Planta_externa
            Me.lblEstacion3.Text = oBE.Mdf


            Me.lblFecha1.Text = oBE.Fec_planta_interna
            Me.lblFecha2.Text = oBE.Fec_planta_externa
            Me.lblFecha3.Text = oBE.Fec_mdf



            Me.lblEstado1.Text = oBE.Estado_planta_interna
            Me.lblEstado2.Text = oBE.Estado_planta_externa
            Me.lblEstado3.Text = oBE.Estado_mdf

            Me.lblUrd1.Text = oBE.Urd_planta_interna
            Me.lblUrd2.Text = oBE.Urd_planta_externa
            Me.lblUrd3.Text = oBE.Urd_mdf

        End If

    End Sub



End Class
