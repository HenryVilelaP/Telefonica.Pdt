Imports System
Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.AppWeb

Partial Class UserControls_cuOrigenesInfoISIS
    Inherits System.Web.UI.UserControl

#Region "Constantes - Variables"
    Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
#End Region

    Public Sub LlenarDatosInfoIsis(ByVal IdPedidoProducto As Integer)
        Try
            Me.Clear()
            Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
            Dim oBE As FUENTE_PEDIDO_LEGACIE = Me.FuentePedidoLegacie(IdPedidoProducto)
            If Not (oBE Is Nothing) Then
                Dim IdRegistro As Integer = Convert.ToInt32(oBE.Pdtic_nCod_Pedido_Legacie.Value)
                Me.hCodigoLegacie.Value = IdRegistro.ToString()
                Me.LlenarDatos(IdRegistro)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function FuentePedidoLegacie(ByVal IdPedidoProducto As Integer) As FUENTE_PEDIDO_LEGACIE
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oBE As FUENTE_PEDIDO_LEGACIE = opdt_tr_origenesBL.DetalleFuentePedidoLegacie(IdPedidoProducto)
        Return oBE

    End Function

    Private Sub Clear()
        Me.hIdPedidoProducto.Value = ""
        Me.lblTitulo.Text = ""
        Me.lblFechaPedidoISIS.Text = ""
        Me.lblFechaEmisionISIS.Text = ""
        Me.lblFecRec.Text = ""
        Me.lblFecDoc.Text = ""
        Me.lblPrereg.Text = ""
        Me.lblPreDocNroDoc.Text = ""
        Me.lblEjecutivoServicio.Text = ""
        Me.lblEjecutivoAtencion.Text = ""
        Me.lblCodigoCliente.Text = ""
        Me.lblNombreCliente.Text = ""
        Me.lblSegmento.Text = ""
        Me.lblSubSegmento.Text = ""
        Me.lblServicio.Text = ""
        Me.lblMarca.Text = ""
        Me.lblCircuito.Text = ""
        Me.lblAccion1.Text = ""
        Me.lblAccion2.Text = ""
        Me.lblSituacion.Text = ""
        Me.lblEstado.Text = ""

    End Sub

    Private Sub LlenarDatos(ByVal IdPedidoProducto As Integer)
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oBE As TR_ISIS = opdt_tr_origenesBL.Detalle_TR_ISIS(IdPedidoProducto)
        If Not (oBE Is Nothing) Then
            Me.lblTitulo.Text = "Requerimiento " & oBE.Codreg.ToString() & " | " & "Pedido " & Me.hIdPedidoProducto.Value
            If (oBE.Fechapedido.HasValue) Then
                Me.lblFechaPedidoISIS.Text = oBE.Fechapedido.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
            If oBE.FechaEmision.HasValue Then
                Me.lblFechaEmisionISIS.Text = oBE.FechaEmision.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If

            Me.lblFechaEmisionISIS.Text += "   " + oBE.HoraEmision

            If (oBE.FecRegistro.HasValue) Then
                Me.lblFecRec.Text = oBE.FecRegistro.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
            If (oBE.FecDoc.HasValue) Then
                Me.lblFecDoc.Text = oBE.FecDoc.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
            Me.lblPrereg.Text = oBE.Prereg

            Me.lblPreDocNroDoc.Text = oBE.PreDoc.ToString() & " - " & oBE.NoDoc.ToString()
            Me.lblEjecutivoServicio.Text = oBE.EjecutivoServicio
            Me.lblEjecutivoAtencion.Text = oBE.EjecutivoAtencion
            Me.lblCodigoCliente.Text = oBE.Codcliente.ToString()
            Me.lblNombreCliente.Text = oBE.Nombrecliente
            Me.lblSegmento.Text = oBE.Segmento
            Me.lblSubSegmento.Text = oBE.SubSegmento
            Me.lblServicio.Text = oBE.Servicio
            Me.lblMarca.Text = oBE.Marca
            If (oBE.Circuito.HasValue) Then
                Me.lblCircuito.Text = oBE.Circuito.Value.ToString()
            End If

            Me.lblAccion1.Text = oBE.CodAccion1.ToString() + "   " + oBE.Accion1
            Me.lblAccion2.Text = oBE.CodAccion2.ToString() + "   " + oBE.Accion2
            Me.lblSituacion.Text = oBE.NombreSituacion
            Me.lblEstado.Text = oBE.PendLiq
        End If
    End Sub


End Class
