Imports System
Imports System.data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.AppWeb

Partial Class UserControls_cuOrigenesInfoSIG
    Inherits System.Web.UI.UserControl

    Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"

    Public Sub LlenarDatosInfoSIG(ByVal IdPedidoProducto As Integer)
        Try
            Me.Clear()
            Me.hIdPedidoProducto.Value = IdPedidoProducto.ToString()
            Dim oBE As FUENTE_PEDIDO_LEGACIE = Me.FuentePedidoLegacie(IdPedidoProducto)
            If Not (oBE Is Nothing) Then
                Dim IdRegistro As Decimal = oBE.Pdtic_nCod_Pedido_Legacie.Value
                Me.hCodigoLegacie.Value = IdRegistro.ToString()
                Me.LlenarDatos(IdRegistro)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub Clear()
        Me.lblTitulo.Text = ""
        Me.lblSegmento.Text = ""
        Me.lblEstado.Text = ""
        Me.lblTelefono.Text = ""
        Me.lblIncripcion.Text = ""
        Me.lblNombreCliente.Text = ""
        Me.lblDireccion.Text = ""
        Me.lblCiudad.Text = ""
        Me.lblCicloFacturacion.Text = ""
        Me.lblPersonaContacto.Text = ""
        Me.lblCodigoFacturacion.Text = ""
        Me.lblFonoContacto.Text = ""
        Me.lblVendedor.Text = ""
        Me.lblCanalVenta.Text = ""
        Me.lblFechaRegistro.Text = ""
        Me.lblFechaLiquidacion.Text = ""
        Me.lblFechaDevolucion1.Text = ""
        Me.lblFechaReprogramacion1.Text = ""
        Me.lblFechaCancelacion1.Text = ""
        Me.grid.DataSource = Nothing
        Me.grid.DataBind()

    End Sub

    Private Function FuentePedidoLegacie(ByVal IdPedidoProducto As Integer) As FUENTE_PEDIDO_LEGACIE
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oBE As FUENTE_PEDIDO_LEGACIE = opdt_tr_origenesBL.DetalleFuentePedidoLegacie(IdPedidoProducto)
        Return oBE

    End Function

    Private Sub LlenarDatos(ByVal IdRegistro As Decimal)
        Dim oTR_SPEEDYSIG_GENERICS As TR_SPEEDYSIG_GENERICS = Me.ListarDatos(IdRegistro)
        If (oTR_SPEEDYSIG_GENERICS Is Nothing) Then Return

        Dim oBE As TR_SPEEDYSIG = oTR_SPEEDYSIG_GENERICS.Cabecera_TR_SPEEDYSIG
        Me.LlenarDetalle(oBE)
        Me.LlenarGrilla(oTR_SPEEDYSIG_GENERICS.DetalleItemsPedidos, 0)

    End Sub



    Private Function ListarDatos(ByVal IdRegistro As Decimal) As TR_SPEEDYSIG_GENERICS
        Dim opdt_tr_origenesBL As New pdt_tr_origenesBL
        Dim oTR_SPEEDYSIG_GENERICS As TR_SPEEDYSIG_GENERICS = opdt_tr_origenesBL.Detalle_TR_SPEEDYSIG(IdRegistro)
        Return oTR_SPEEDYSIG_GENERICS

    End Function

    Private Sub LlenarDetalle(ByVal oBE As TR_SPEEDYSIG)
        If Not (oBE Is Nothing) Then
            Me.lblTitulo.Text = "Pedido " & oBE.Pedido & " | " & "Pedido " & Me.hIdPedidoProducto.Value
            Me.lblSegmento.Text = oBE.Segmento
            Me.lblEstado.Text = oBE.Estado
            Me.lblTelefono.Text = oBE.Telefono.ToString()
            If (oBE.Inscripcion.HasValue) Then
                Me.lblIncripcion.Text = oBE.Inscripcion.Value.ToString()
            End If
            Me.lblNombreCliente.Text = oBE.Cliente
            Me.lblDireccion.Text = oBE.Direccion
            Me.lblCiudad.Text = oBE.Ciudad
            If (oBE.Ciclo_Fact.HasValue) Then
                Me.lblCicloFacturacion.Text = oBE.Ciclo_Fact.Value.ToString()
            End If
            Me.lblPersonaContacto.Text = oBE.Persona_Contacto
            If (oBE.Cod_Facturacion.HasValue) Then
                Me.lblCodigoFacturacion.Text = oBE.Cod_Facturacion.Value.ToString()
            End If
            If (oBE.Fono_Contacto.HasValue) Then
                Me.lblFonoContacto.Text = oBE.Fono_Contacto.Value.ToString()
            End If
            Me.lblVendedor.Text = oBE.Vendedor
            Me.lblCanalVenta.Text = oBE.Canal_de_venta
            If (oBE.Fecha_Registro.HasValue) Then
                Me.lblFechaRegistro.Text = oBE.Fecha_Registro.Value.ToString(ConstantesWeb.FORMATOFECHA5)
            End If
            If (oBE.Fecha_liquidacion.HasValue) Then
                Me.lblFechaLiquidacion.Text = oBE.Fecha_liquidacion.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
            Me.lblFechaDevolucion1.Text = oBE.Fecha_Devolucion
            If (oBE.Fecha_Reprogramacion.HasValue) Then
                Me.lblFechaReprogramacion1.Text = oBE.Fecha_Reprogramacion.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
            If (oBE.Fecha_Cancelacion.HasValue) Then
                Me.lblFechaCancelacion1.Text = oBE.Fecha_Cancelacion.Value.ToString(ConstantesWeb.FORMATOFECHA4)
            End If
        End If

    End Sub

    Private Sub LlenarGrilla(ByVal indicePagina As Integer)
        Dim oTR_SPEEDYSIG_GENERICS As TR_SPEEDYSIG_GENERICS = Me.ListarDatos(Convert.ToDecimal(Me.hCodigoLegacie.Value))
        If (oTR_SPEEDYSIG_GENERICS Is Nothing) Then Return

        Me.LlenarGrilla(oTR_SPEEDYSIG_GENERICS.DetalleItemsPedidos, indicePagina)

    End Sub

    Private Sub LlenarGrilla(ByVal oBE As System.Collections.Generic.List(Of TR_SPEEDYSIG), ByVal indicePagina As Integer)

        If Not (oBE Is Nothing) Then
            Me.grid.DataSource = oBE
            indicePagina = HelperWeb.ValidarIndicePaginacionGrilla(oBE.Count, Me.grid.PageSize, indicePagina)
            Me.grid.CurrentPageIndex = indicePagina
            Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + oBE.Count.ToString()
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
            Me.grid.CurrentPageIndex = 0
            Me.grid.DataBind()
            Throw ex
        End Try
    End Sub

    Protected Sub grid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grid.ItemDataBound
        If (e.Item.ItemType = ListItemType.Header) Then

        ElseIf ((e.Item.ItemType = ListItemType.AlternatingItem) OrElse (e.Item.ItemType = ListItemType.Item)) Then

            e.Item.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)
            Dim BE As TR_SPEEDYSIG = CType(e.Item.DataItem, TR_SPEEDYSIG)
            Me.EtiquetaValorControl(e, "lblProducto", BE.Producto)

            Me.EtiquetaValorControl(e, "lblPaquete", BE.Paquete)
            If (BE.Cant.HasValue) Then
                Me.EtiquetaValorControl(e, "lblCantidad", BE.Cant.Value.ToString())
            End If
            Me.EtiquetaValorControl(e, "lblNumeroSerie", BE.NroSerie)
            Me.EtiquetaValorControl(e, "lblPeriodo", BE.Peroodo)
            Me.EtiquetaValorControl(e, "lblEstado", BE.Estado1)
            Me.EtiquetaValorControl(e, "lblTipoCliente", BE.Tipo_cliente)
            Me.EtiquetaValorControl(e, "lblCPU", BE.Cpu)
            Me.EtiquetaValorControl(e, "lblRAM", BE.RAM)
            Me.EtiquetaValorControl(e, "lblSO", BE.SistemaOperativo)
            Me.EtiquetaValorControl(e, "lblProcesador", BE.Procesador)

            HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e)

        End If
    End Sub

    Private Sub EtiquetaValorControl(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, ByVal NombreControl As String, ByVal Valor As String)
        Dim lbl As Label = CType(e.Item.FindControl(NombreControl), Label)
        lbl.Text = Valor
    End Sub

    Protected Sub grid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles grid.PageIndexChanged
        Try
            Me.LlenarGrilla(e.NewPageIndex)
        Catch ex As Exception
            NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
        Finally
            Me.UpdatePanelDetalleItems.Update()
        End Try
    End Sub
End Class
