Namespace Telefonica.Pdt.AppWeb

Partial Class _default2
        Inherits WebPaginaBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnDocumentos)
            Me.LlenarJScript()
        End Sub

        Protected Sub btnDocumentos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDocumentos.Click
            Try
                Me.CuCargarDocumetoPedidoProducto1.LlenarGrillaDocumentos(3)
                'Me.LlenarJScript()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, "Error en el Sevidor")
            End Try

        End Sub

        Private Sub LlenarJScript()
            Dim Js As String = "    function ActulizarListaDocumentPublicPedido()" + ConstantesWeb.SaltoLinea
            Js += "    {" + ConstantesWeb.SaltoLinea
            Js += "         __doPostBack('" + Me.btnDocumentos.ClientID + "','');" + ConstantesWeb.SaltoLinea
            Js += "    }" + ConstantesWeb.SaltoLinea
            HelperWeb.RegistrarJavaScriptEnHead(Me.Page, "ActulizarDocumentoPedidoPublic", Js)

        End Sub

        Protected Sub btnInfoISIS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfoISIS.Click
            Try
                Me.CuOrigenesInfoISIS1.LlenarDatosInfoIsis(8)
            Catch ex As Exception

            End Try

        End Sub

        Protected Sub btnInfoSIG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInfoSIG.Click
            Try
                Me.CuOrigenesInfoSIG1.LlenarDatosInfoSIG(3)
            Catch ex As Exception

            End Try
        End Sub

        Protected Sub btnGestel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGestel.Click
            Try
                Me.CuOrigenesGestel1.LlenarDatosGestel(10)
            Catch ex As Exception

            End Try
        End Sub
    End Class

End Namespace
