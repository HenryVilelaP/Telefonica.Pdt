Public Class WebPaginaBase
    Inherits System.Web.UI.Page

#Region "Definicion de Constantes y Variables"
    Private _IdUsuario_Not_InicioSesion As Integer = 1
    Private Const ConstKeyCodigoUsuario As String = "HttpSessionUserCodigoUsuario"

#End Region

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If (PAG_IdUsuario_InicioSesion <= 0) Then
            Me.Page.Response.Redirect("~default.aspx")
        End If
    End Sub

    Public ReadOnly Property PAG_IdUsuario_InicioSesion() As Integer
        Get
            Return Me.IdUsuario_InicioSesion()
        End Get
    End Property

    Private Function IdUsuario_InicioSesion() As Integer
        If Not VariableSessionIsNull(ConstKeyCodigoUsuario) Then
            Return Convert.ToInt32(System.Web.HttpContext.Current.Session(ConstKeyCodigoUsuario))
        End If

        Return _IdUsuario_Not_InicioSesion

    End Function

    Private Function VariableSessionIsNull(ByVal KeyValiable As String) As Boolean
        If (System.Web.HttpContext.Current.Session(KeyValiable)) Is Nothing Then
            Return True
        End If

        Return False

    End Function


End Class
