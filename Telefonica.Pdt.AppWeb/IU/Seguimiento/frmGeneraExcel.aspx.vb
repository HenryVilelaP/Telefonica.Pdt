
Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports System.Web.UI.Control


Namespace Telefonica.Pdt.AppWeb

    Partial Class frmGeneraExcel
        Inherits WebPaginaBase

        Protected Sub imgbExportarExcel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbExportarExcel.Click
            Try
                EventoClickListarGeneraExcel()
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(ConstantesWeb.MensajeErrorException)
            End Try
        End Sub

        Sub EventoClickListarGeneraExcel()
            Try
                Dim dt As DataTable
                Dim opdt_cupoBL As New pdt_cupoBL
                Dim provc_iIdProveedor As Integer = -1
                Dim prsec_iIdPrd_Servicio As Integer = -1
                Dim fechc_iIdFecha As Integer = -1
                Dim pdppc_iIdPedido_Prd As Integer = -1
                Dim vetdc_iIdEstado_Pedido As Integer = -1
                Dim pdppc_iInd_Pedido_Agendado As Integer = -1
                Dim datFechaInicio As DateTime = Date.MinValue
                Dim datFechaFin As DateTime = Date.MaxValue

                provc_iIdProveedor = Me.Page.Request.Params("provc_iIdProveedor".ToString())
                prsec_iIdPrd_Servicio = Me.Page.Request.Params("prsec_iIdPrd_Servicio".ToString())
                fechc_iIdFecha = Me.Page.Request.Params("fechc_iIdFecha".ToString())


                dt = opdt_cupoBL.ListarPedidoAgendado(provc_iIdProveedor, prsec_iIdPrd_Servicio, fechc_iIdFecha, pdppc_iIdPedido_Prd, vetdc_iIdEstado_Pedido, pdppc_iInd_Pedido_Agendado, datFechaInicio, datFechaFin)

                If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                    HelperWeb.ExportarExcelDataTable(Me.Page, dt)
                Else
                    Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert("No se encontraron pedidos agendados...")
                    Return
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(ConstantesWeb.MensajeErrorException)
            End Try
        End Sub

    End Class
End Namespace