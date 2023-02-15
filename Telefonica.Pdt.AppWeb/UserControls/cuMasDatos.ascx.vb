Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports System.Data

Namespace Telefonica.Pdt.AppWeb
    Partial Class cuMasDatos
        Inherits System.Web.UI.UserControl
        Private intTipoAccion As Integer        

        Private Sub Clear()
            Me.lblFechaInsertadaWebUsuario.Text = ""
            Me.lblFechaRecepcionContratoBO.Text = ""
            Me.lblFechaAcuerdo.Text = ""
            Me.lblSubSegmento.Text = ""
            Me.lblFechaUsuarioBOEmitio.Text = ""
            Me.lblObservacionesActualizo.Text = ""
            Me.lblCanales.Text = ""
            Me.lblFechaLiquidacionWeb.Text = ""
            Me.lblInscripcion.Text = ""
            Me.lblTelefonoGestel.Text = ""
            Me.lblCircuitoDigital.Text = ""
            Me.lblRouter.Text = ""
            Me.lblPaquete.Text = ""
            Me.lblTelefonoNombreVendedor.Text = ""
            Me.lblEjecutivoCreoVentaGesneg.Text = ""
            Me.lblFormaAdquisicion.Text = ""
            Me.lblTiempoContrato.Text = ""
            Me.lblFechaContrato.Text = ""
            Me.lblFechaInicioFinPiloto.Text = ""
            Me.lblNumeroItems.Text = ""
            Me.lblNombreContacto.Text = ""
            Me.lblTelefonoContacto.Text = ""
            Me.lblObservacionesEjecutivo.Text = ""

        End Sub

        Private Sub ConfigurarAccesoControles(ByVal IdPedidoProducto As Integer)
            Dim opdt_pedidoBL As pdt_pedidoBL
            Dim dtEstadoPedido As DataTable
            Dim intEstadoPedido As Integer
            opdt_pedidoBL = New pdt_pedidoBL

            If IdPedidoProducto > 0 Then
                dtEstadoPedido = opdt_pedidoBL.Detalle_Estado_Pedido(IdPedidoProducto)
                intEstadoPedido = Convert.ToInt32(dtEstadoPedido.Rows(0)("vetdc_iIdEstado_Pedido").ToString)

                If intEstadoPedido <> 6 Then
                    Me.Table2.Visible = False
                Else
                    Me.Table2.Visible = True
                End If

            End If

        End Sub

        Public Sub ConsultarDatos(ByVal IdPedidoProducto As Integer, ByVal idDetPedido As Integer)
            Me.hCodigo.Value = IdPedidoProducto.ToString
            Me.hIdPedidoPrd.Value = idDetPedido.ToString

            Me.Clear()
            Me.ConfigurarAccesoControles(IdPedidoProducto)

            Dim oPedido As pdt_pedidoBL
            Dim oDatosSeguimiento As DataTable

            Try
                oPedido = New pdt_pedidoBL
                oDatosSeguimiento = oPedido.Listar_DatosWebSeguimiento(IdPedidoProducto)
                If Not oDatosSeguimiento Is Nothing Then
                    Dim pdtic_dFec_Registro As String = ""
                    If (Not Convert.IsDBNull(oDatosSeguimiento.Rows(0)("pdtic_dFec_Registro"))) Then
                        pdtic_dFec_Registro = Convert.ToDateTime(oDatosSeguimiento.Rows(0)("pdtic_dFec_Registro")).ToString(ConstantesWeb.FORMATOFECHA4)
                    End If

                    Me.lblFechaInsertadaWebUsuario.Text = pdtic_dFec_Registro + " / " + oDatosSeguimiento.Rows(0)("USUARIO_RECEPCION").ToString
                    Me.lblFechaRecepcionContratoBO.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_Recepcion_Contrato_BO").ToString + " / " + oDatosSeguimiento.Rows(0)("USUARIO_RECEPCION").ToString
                    Me.lblFechaAcuerdo.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_Acuerdo").ToString
                    Me.lblSubSegmento.Text = oDatosSeguimiento.Rows(0)("SUBSEGMENTO").ToString
                    Me.lblFechaUsuarioBOEmitio.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_Emitio_Contrato_bo").ToString + " / " + oDatosSeguimiento.Rows(0)("USUARIO_EMITIO").ToString
                    Me.lblObservacionesActualizo.Text = oDatosSeguimiento.Rows(0)("pdtic_vObservacion_Usuario_bo").ToString
                    Me.lblCanales.Text = oDatosSeguimiento.Rows(0)("pdtic_vCanales").ToString
                    Me.lblFechaLiquidacionWeb.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_liquidacion_web").ToString
                    Me.lblInscripcion.Text = oDatosSeguimiento.Rows(0)("pdtic_vInscripcion").ToString
                    Me.lblTelefonoGestel.Text = oDatosSeguimiento.Rows(0)("pdtic_vTelefono_Gestel").ToString
                    Me.lblCircuitoDigital.Text = oDatosSeguimiento.Rows(0)("pdtic_vCircuito_Digital").ToString
                    Me.lblRouter.Text = oDatosSeguimiento.Rows(0)("pdtic_vRouter").ToString
                    Me.lblPaquete.Text = oDatosSeguimiento.Rows(0)("paqtc_vDescripcion").ToString
                    Me.lblTelefonoNombreVendedor.Text = oDatosSeguimiento.Rows(0)("pdtic_vTelefono_Vendedor").ToString + " / " + oDatosSeguimiento.Rows(0)("pdtic_vNombre_Vendedor").ToString
                    Me.lblEjecutivoCreoVentaGesneg.Text = oDatosSeguimiento.Rows(0)("paqtc_vDescripcion").ToString
                    Me.lblFormaAdquisicion.Text = oDatosSeguimiento.Rows(0)("FORMAADQUISICION").ToString
                    Me.lblTiempoContrato.Text = oDatosSeguimiento.Rows(0)("TIEMPOCONTRATO").ToString
                    Me.lblFechaContrato.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_Contrato").ToString
                    Me.lblFechaInicioFinPiloto.Text = oDatosSeguimiento.Rows(0)("pdtic_dFec_inicio_piloto").ToString + " / " + oDatosSeguimiento.Rows(0)("pdtic_dFec_fin_piloto").ToString
                    'Me.lblNumeroItems.Text = oDatosSeguimiento.Rows(0)("").ToString
                    Me.lblNombreContacto.Text = oDatosSeguimiento.Rows(0)("pdtic_vNombre_Contacto").ToString
                    Me.lblTelefonoContacto.Text = oDatosSeguimiento.Rows(0)("pdtic_vTelefono_Contacto").ToString
                    Me.lblObservacionesEjecutivo.Text = oDatosSeguimiento.Rows(0)("pdtic_vObservacion_ejecutivo").ToString

                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Protected Sub btnAprobar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
            Try
                intTipoAccion = 1
                Me.ActualizarEstadoAprobar_Rechazar(intTipoAccion)

            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            End Try
        End Sub

        Private Sub ActualizarEstadoAprobar_Rechazar(ByVal intTipoAccion As Integer)
            Dim opdt_pedidoBL As pdt_pedidoBL

            Dim intIdPedidoPrd As Integer
            Dim intIdEstadoPedido As Integer
            Dim intUsuarioModifica As Integer
            Dim lintResult As Integer
            Dim intEstadoPedido As Integer

            opdt_pedidoBL = New pdt_pedidoBL
            intUsuarioModifica = HelperWeb.CuIdUsuarioInicioSession()

            intIdPedidoPrd = Convert.ToInt32(Me.hIdPedidoPrd.Value)

            If intEstadoPedido <> 6 Then
                NetAjax.JsMensajeAlert(Me.Page, "Para Aprobar ó Rechazar, el pedido tiene que estar EN VALIDACION X CONTROL.")

            Else
                If intTipoAccion = 1 Then
                    intIdEstadoPedido = Enumeradores.TAB_Val_EstadoPedido.Aprobado_por_control
                Else
                    intIdEstadoPedido = Enumeradores.TAB_Val_EstadoPedido.Rechazado
                End If

                lintResult = opdt_pedidoBL.Actualiza_ESTADO_VALIDACION_CONTROL(intidPedidoPrd, intIdEstadoPedido, intUsuarioModifica)

                Select Case lintResult
                    Case -1
                        NetAjax.JsMensajeAlert(Me.Page, "No se puede actualizar.")
                    Case Is > 0
                        NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
                End Select

            End If

        End Sub

        Protected Sub btnRechazar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRechazar.Click
            Try
                intTipoAccion = 2
                Me.ActualizarEstadoAprobar_Rechazar(intTipoAccion)

            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, ConstantesWeb.MensajeErrorException, ConstantesWeb.MensajeError)
            End Try

        End Sub

        Protected Sub btnAgendar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAgendar.Click
            Dim strUrl As String = "frmagendapedido.aspx?" + Enumeradores.col_PDTT_PEDIDO_PRD.pdppc_iIdPedido_Prd.ToString() + ConstantesWeb.SignoIGUAL + Me.hIdPedidoPrd.Value
            Me.Page.Response.Redirect(strUrl)

        End Sub

    End Class

End Namespace
