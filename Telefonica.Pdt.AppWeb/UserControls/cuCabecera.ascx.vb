Imports System.Data
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities
Imports Telefonica.Pdt.Common

Namespace Telefonica.Pdt.AppWeb
    Partial Class cuCabecera
        Inherits System.Web.UI.UserControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                If (Not Me.IsPostBack) Then
                    Dim strLogin As String = Session("login").ToString()
                    Construir_Menu(strLogin, 0, Nothing)
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Private Sub Construir_Menu(ByVal pStrLogin As String, ByVal indicePadre As Integer, ByVal nodePadre As MenuItem)
            Try
                Dim oOpcionBL As pdt_sg_opcionBL
                oOpcionBL = New pdt_sg_opcionBL
                Dim DtMenu As DataTable
                DtMenu = oOpcionBL.Lista_Menu_Opciones(pStrLogin)
                Dim dataViewHijos As DataView
                dataViewHijos = New DataView(DtMenu)

                dataViewHijos.RowFilter = DtMenu.Columns("opcic_iId_Opcion_Padre").ColumnName + " = " + indicePadre.ToString()

                For Each dataRowCurrent As DataRowView In dataViewHijos
                    Dim nuevoItemMenu As New MenuItem
                    nuevoItemMenu.Value = dataRowCurrent("opcic_iIdOpcion").ToString().Trim()
                    nuevoItemMenu.Text = dataRowCurrent("opcic_vEtiqueta").ToString().Trim()
                    nuevoItemMenu.NavigateUrl = dataRowCurrent("opcic_vRuta_Url_Pagina").ToString().Trim()

                    If nodePadre Is Nothing Then
                        Me.Menu1.Items.Add(nuevoItemMenu)
                    Else
                        nodePadre.ChildItems.Add(nuevoItemMenu)
                    End If

                    Construir_Menu(pStrLogin, Int32.Parse(dataRowCurrent("opcic_iIdOpcion").ToString()), nuevoItemMenu)
                Next dataRowCurrent
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

    End Class
End Namespace

