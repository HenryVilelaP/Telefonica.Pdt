Imports Microsoft.VisualBasic
Imports System.Web

Namespace Telefonica.Pdt.AppWeb
    Public Class NetAjax

        Public Shared Sub JsLanzarExecutarScriptRecargarPagina(ByVal oPage As Page, ByVal type As System.Type, ByVal key As String, ByVal script As String, ByVal CabeceraScript As Boolean)
            ScriptManager.RegisterClientScriptBlock(oPage, type, key, script, CabeceraScript)
        End Sub

        Public Shared Sub JsLanzarExecutarScriptRecargarPagina(ByVal oPage As Page, ByVal key As String, ByVal script As String, ByVal CabeceraScript As Boolean)
            ScriptManager.RegisterClientScriptBlock(oPage, oPage.GetType(), key, script, CabeceraScript)
        End Sub

        Public Shared Sub JsLanzarExecutarScriptRecargarPagina(ByVal oControl As System.Web.UI.Control, ByVal type As System.Type, ByVal key As String, ByVal script As String, ByVal CabeceraScript As Boolean)
            ScriptManager.RegisterClientScriptBlock(oControl, type, key, script, CabeceraScript)
        End Sub

        Public Shared Sub JsLanzarExecutarScriptRecargarPagina(ByVal oControl As System.Web.UI.Control, ByVal key As String, ByVal script As String, ByVal CabeceraScript As Boolean)
            ScriptManager.RegisterClientScriptBlock(oControl, oControl.GetType(), key, script, CabeceraScript)
        End Sub

        Public Shared Sub RegistroControlPostBackControlAsync(ByVal oScriptManager As ScriptManager, ByVal oControl As System.Web.UI.Control)
            oScriptManager.RegisterAsyncPostBackControl(oControl)
        End Sub

        Public Shared Sub JsMensajeAlert(ByVal oPage As Page, ByVal sMensaje As String)
            Dim strMensaje As String = HelperWeb.MensajeAlert(sMensaje)
            JsLanzarExecutarScriptRecargarPagina(oPage, "MensajeAlertWeb", strMensaje, True)

        End Sub

        Public Shared Sub JsMensajeAlert(ByVal oPage As Page, ByVal sMensaje As String, ByVal NombreMensaje As String)
            Dim strMensaje As String = HelperWeb.MensajeAlert(sMensaje)
            JsLanzarExecutarScriptRecargarPagina(oPage, NombreMensaje, strMensaje, True)

        End Sub

        Public Shared Sub StyleUpdateProgressPaginaCentral(ByVal oControlUpdateProgress As System.Web.UI.UpdateProgress)
            Dim NombreBloqueJava As String = "Style" + oControlUpdateProgress.ClientID

            If Not oControlUpdateProgress.Page.ClientScript.IsClientScriptBlockRegistered("Style" + oControlUpdateProgress.ClientID) Then
                Dim Style As String = ""
                Style += "<style type=""text/css"">" + Microsoft.VisualBasic.vbCrLf
                Style += "  #" + oControlUpdateProgress.ClientID + Microsoft.VisualBasic.vbCrLf
                Style += "  {" + Microsoft.VisualBasic.vbCrLf
                Style += "  width:280px; background-color: #ffff33;" + Microsoft.VisualBasic.vbCrLf
                Style += "  bottom: 50%; left: 40%; position: absolute;z-index:100;padding-top:.2em;padding-bottom:.2em;padding-left:.2em;" + Microsoft.VisualBasic.vbCrLf
                Style += "  }" + Microsoft.VisualBasic.vbCrLf
                Style += "</style>" + Microsoft.VisualBasic.vbCrLf

                oControlUpdateProgress.Page.ClientScript.RegisterClientScriptBlock(oControlUpdateProgress.Page.GetType(), NombreBloqueJava, Style)
                oControlUpdateProgress.DisplayAfter = 250 'milisegundos
            End If
        End Sub

    End Class

 
End Namespace
