Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb
    Public Class cuInfoISIS
        Inherits System.Web.UI.UserControl

#Region "Constantes - Variables"
        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
#End Region


        Public Sub LlenarDatosInfoIsis(ByVal IdPedidoProducto As Integer)
            Try
                Me.Clear()
                Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
                Me.LlenarDatos(IdPedidoProducto)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

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
                lblTitulo.Text = "Requerimiento " & oBE.Codreg.ToString() & " | " & "Pedido " & Me.hIdPedidoProducto.Value
                If (oBE.Fechapedido.HasValue) Then
                    lblFechaPedidoISIS.Text = oBE.Fechapedido.Value.ToString(ConstantesWeb.FORMATOFECHA4)
                End If
                If oBE.FechaEmision.HasValue Then
                    lblFechaEmisionISIS.Text = oBE.FechaEmision.Value.ToString(ConstantesWeb.FORMATOFECHA4)
                End If
                If (oBE.FecRegistro.HasValue) Then
                    lblFecRec.Text = oBE.FecRegistro.Value.ToString(ConstantesWeb.FORMATOFECHA4)
                End If
                If (oBE.FecDoc.HasValue) Then
                    lblFecDoc.Text = oBE.FecDoc.Value.ToString(ConstantesWeb.FORMATOFECHA4)
                End If
                lblPrereg.Text = oBE.Prereg

                lblPreDocNroDoc.Text = oBE.PreDoc.ToString() & " - " & oBE.NoDoc.ToString()
                lblEjecutivoServicio.Text = oBE.EjecutivoServicio
                lblEjecutivoAtencion.Text = oBE.EjecutivoAtencion
                lblCodigoCliente.Text = oBE.Codcliente.ToString()
                lblNombreCliente.Text = oBE.Nombrecliente
                lblSegmento.Text = oBE.Segmento
                lblSubSegmento.Text = oBE.SubSegmento
                lblServicio.Text = oBE.Servicio
                lblMarca.Text = oBE.Marca
                If (oBE.Circuito.HasValue) Then
                    lblCircuito.Text = oBE.Circuito.Value.ToString()
                End If

                lblAccion1.Text = oBE.CodAccion1.ToString() + "   " + oBE.Accion1
                lblAccion2.Text = oBE.CodAccion2.ToString() + "   " + oBE.Accion2
                lblSituacion.Text = oBE.NombreSituacion
                lblEstado.Text = oBE.PendLiq
            End If
        End Sub


    End Class

End Namespace
