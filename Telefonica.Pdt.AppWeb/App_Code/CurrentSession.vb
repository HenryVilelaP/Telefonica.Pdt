Imports System.Web
Imports System.Data


Namespace Telefonica.Pdt.AppWeb

    Public Class CurrentSession

#Region "Contantes"
        Private Const ConstKeyCodigoUsuario As String = "HttpSessionUserCodigoUsuario"
        'Private Const ConstKeyCodigoPerfil As String = "HttpSessionUserCodigoPerfil"
        'Private Const ConstKeyDescripcionPerfil As String = "HttpSessionUserDescripcionPerfil"
        'Private Const ConstKeyFechaUltimaActualizacion As String = "HttpSessionUserFechaUltimaActualizacion"

#End Region

        Private Shared Sub ClearSession()
            System.Web.HttpContext.Current.Session.Remove(ConstKeyCodigoUsuario)
            'System.Web.HttpContext.Current.Session.Remove(ConstKeyCodigoPerfil)
            'System.Web.HttpContext.Current.Session.Remove(ConstKeyDescripcionPerfil)
            'System.Web.HttpContext.Current.Session.Remove(ConstKeyFechaUltimaActualizacion)

        End Sub


        Private Shared Function ValidarVariableSession(ByVal KeyValiable As String) As Boolean
            If Not (System.Web.HttpContext.Current.Session(KeyValiable)) Is Nothing Then
                Return True
            End If

            Return False

        End Function


        Public Shared Property IdUsuario_InicioSesion() As Integer
            Get
                If (ValidarVariableSession(ConstKeyCodigoUsuario) = True) Then
                    Return Convert.ToInt32(System.Web.HttpContext.Current.Session(ConstKeyCodigoUsuario))
                End If
                Return 0
            End Get
            Set(ByVal Value As Integer)
                System.Web.HttpContext.Current.Session(ConstKeyCodigoUsuario) = Value
            End Set
        End Property

        'Public Shared Property CodigoPerfil() As String
        '    Get
        '        If (ValidarVariableSession(ConstKeyCodigoPerfil) = True) Then
        '            Return Convert.ToString(System.Web.HttpContext.Current.Session(ConstKeyCodigoPerfil))
        '        End If
        '        Return Nothing
        '    End Get
        '    Set(ByVal Value As String)
        '        System.Web.HttpContext.Current.Session(ConstKeyCodigoPerfil) = Value
        '    End Set
        'End Property

        'Public Shared Property DescripcionPerfil() As String
        '    Get
        '        If (ValidarVariableSession(ConstKeyDescripcionPerfil) = True) Then
        '            Return Convert.ToString(System.Web.HttpContext.Current.Session(ConstKeyDescripcionPerfil))
        '        End If
        '        Return Nothing
        '    End Get
        '    Set(ByVal Value As String)
        '        System.Web.HttpContext.Current.Session(ConstKeyDescripcionPerfil) = Value
        '    End Set
        'End Property

        'Public Shared Property FechaUltimaActualizacion() As DateTime
        '    Get
        '        Return Convert.ToDateTime(System.Web.HttpContext.Current.Session(ConstKeyFechaUltimaActualizacion))
        '    End Get
        '    Set(ByVal Value As DateTime)
        '        System.Web.HttpContext.Current.Session(ConstKeyFechaUltimaActualizacion) = Value
        '    End Set
        'End Property

    End Class

End Namespace
