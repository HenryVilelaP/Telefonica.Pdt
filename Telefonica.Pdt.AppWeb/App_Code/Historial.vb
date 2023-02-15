Imports System
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Web
Imports System.Web.UI.Page
Imports System.Web.UI.WebControls
Imports Telefonica.Pdt.AppWeb

Public Class Historial

#Region "Estructura Historial"
    Private Structure ClassHistorialWeb
        Private _UrlPagina As String
        Private _ControlWeb As ClassControlWeb()

        Public Property UrlPagina() As String
            Get
                Return _UrlPagina
            End Get
            Set(ByVal Value As String)
                _UrlPagina = Value
            End Set
        End Property

        Public Property ControlWeb() As ClassControlWeb()
            Get
                Return _ControlWeb
            End Get
            Set(ByVal Value As ClassControlWeb())
                _ControlWeb = Value
            End Set
        End Property

    End Structure

#End Region

#Region "Estructura Control"
    Private Structure ClassControlWeb
        Private _ControlType As String
        Private _ControlValor As String
        Private _IdControl As String

        Public Property ControlType() As String
            Get
                Return _ControlType
            End Get
            Set(ByVal Value As String)
                _ControlType = Value
            End Set
        End Property

        Public Property ControlValor() As String
            Get
                Return _ControlValor
            End Get
            Set(ByVal Value As String)
                _ControlValor = Value
            End Set
        End Property

        Public Property IdControl() As String
            Get
                Return _IdControl
            End Get
            Set(ByVal Value As String)
                _IdControl = Value
            End Set
        End Property

    End Structure

#End Region

    Public Shared Sub HistorialWebIrPaginaSiguiente(ByVal oPagina As System.Web.UI.Page)
        HistorialWebIrPaginaSiguiente(oPagina, Nothing)
    End Sub

    Public Shared Sub HistorialWebIrPaginaAnterior(ByVal oPagina As System.Web.UI.Page)
        Dim oPage As New System.Web.UI.Control
        Dim Url As String = HistorialWebIrPaginaAnteriorPrivado()
        oPagina.Response.Redirect(Url, False)
    End Sub

    Public Shared Function MensajeAlerHistorialWebIrPaginaAnterior(ByVal mensaje As String) As String
        Dim Url As String = HistorialWebIrPaginaAnteriorPrivado()
        Dim JavaScript As String = HelperWeb.MensajeAlert(mensaje) + " window.location.href='" + Url + "'; "
        Return JavaScript
    End Function

    Public Shared Function EjecutarJavaScriptHistorialWebIrPaginaAnterior(ByVal strJavaScript As String) As String
        Dim Url As String = HistorialWebIrPaginaAnteriorPrivado()
        Dim JavaScript As String = strJavaScript + ConstantesWeb.SignoPUNTOYCOMA + " window.location.href='" + Url + "'; "
        Return JavaScript
    End Function

    Public Shared Function getHistorialPaginaAnterior() As String
        Return HistorialWebIrPaginaAnteriorPrivado()
    End Function

    Public Shared Sub ReiniciarSessionHistorialWebNavegacion()
        HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms) = Nothing
    End Sub

    Public Shared Sub ReiniciarSessionHistorialWebControlesFormulario()
        HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebControlsForms) = Nothing
    End Sub

    Public Shared Sub ReiniciarSessionHistorialWebUrlPaginaAnterior()
        HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlPaginaAnterior) = Nothing
    End Sub

    Public Shared Sub ReiniciarSessionHistorialWeb()
        Historial.ReiniciarSessionHistorialWebNavegacion()
        Historial.ReiniciarSessionHistorialWebControlesFormulario()
        Historial.ReiniciarSessionHistorialWebUrlPaginaAnterior()
    End Sub


    Public Shared Sub HistorialWebIrPaginaSiguiente(ByVal oPagina As System.Web.UI.Page, ByVal ParamArray oControl As System.Web.UI.Control())
        Dim alHistorial As New ArrayList
        If Not (HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms) Is Nothing) Then
            alHistorial = CType(HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms), ArrayList)
        End If
        Dim oControlWeb() As ClassControlWeb = Nothing
        If Not (oControl Is Nothing) Then
            If (oControl.Length > 0) Then
                Dim oClassControlWeb(oControl.Length - 1) As ClassControlWeb
                For I As Integer = 0 To (oControl.Length - 1)
                    oClassControlWeb(I) = New ClassControlWeb
                    Dim TypoControlWeb As String = oControl(I).GetType().ToString()
                    Dim ValorControl As String = ""
                    Dim IdControl As String = ""
                    oClassControlWeb(I).ControlType = TypoControlWeb
                    Select Case TypoControlWeb
                        Case "System.Web.UI.HtmlControls.HtmlInputHidden"
                            Dim oCtrl As System.Web.UI.HtmlControls.HtmlInputHidden = CType(oControl(I), System.Web.UI.HtmlControls.HtmlInputHidden)
                            ValorControl = oCtrl.Value
                            IdControl = oCtrl.ID
                        Case "System.Web.UI.WebControls.TextBox"
                            Dim oCtrl As System.Web.UI.WebControls.TextBox = CType(oControl(I), System.Web.UI.WebControls.TextBox)
                            ValorControl = oCtrl.Text
                            IdControl = oCtrl.ID
                        Case "System.Web.UI.WebControls.DropDownList"
                            Dim oCtrl As System.Web.UI.WebControls.DropDownList = CType(oControl(I), System.Web.UI.WebControls.DropDownList)
                            ValorControl = oCtrl.SelectedValue
                            IdControl = oCtrl.ID
                        Case "System.Web.UI.WebControls.CheckBox"
                            Dim oCtrl As System.Web.UI.WebControls.CheckBox = CType(oControl(I), System.Web.UI.WebControls.CheckBox)
                            ValorControl = oCtrl.Checked.ToString()
                            IdControl = oCtrl.ID
                        Case "eWorld.UI.NumericBox"
                            Dim oCtrl As eWorld.UI.NumericBox = CType(oControl(I), eWorld.UI.NumericBox)
                            ValorControl = oCtrl.Text
                            IdControl = oCtrl.ID
                        Case "customCalendar.webCalendar"
                            Dim oCtrl As customCalendar.webCalendar = CType(oControl(I), customCalendar.webCalendar)
                            ValorControl = oCtrl.Fecha
                            IdControl = oCtrl.ID
                    End Select
                    oClassControlWeb(I).ControlValor = ValorControl
                    oClassControlWeb(I).IdControl = IdControl
                Next
                oControlWeb = oClassControlWeb
            End If
        End If
        Dim oStrucHistorial As New ClassHistorialWeb
        oStrucHistorial.UrlPagina = oPagina.Request.Url.AbsoluteUri
        If Not (oControlWeb Is Nothing) Then
            If (oControlWeb.Length > 0) Then
                oStrucHistorial.ControlWeb = oControlWeb
            End If
        End If
        alHistorial.Add(oStrucHistorial)
        HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms) = alHistorial
        ReiniciarSessionHistorialWebControlesFormulario()
    End Sub

    Private Shared Function HistorialWebIrPaginaAnteriorPrivado() As String
        'Dim Url As String = EncriptarQuery.EncriptarQueryString(ConstantesWeb.URLPaginaDefault)
        Dim Url As String = ConstantesWeb.URLPaginaDefault

        If (HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms) Is Nothing) Then
            Return Url
        End If
        Try
            Dim alHistorial As ArrayList = CType(HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms), ArrayList)
            If alHistorial.Count > 0 Then
                Dim oStrucHistorial As New ClassHistorialWeb
                oStrucHistorial = CType(alHistorial.Item(alHistorial.Count - 1), ClassHistorialWeb)
                Url = oStrucHistorial.UrlPagina
                HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebControlsForms) = oStrucHistorial.ControlWeb
                HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlPaginaAnterior) = Url
                alHistorial.RemoveAt(alHistorial.Count - 1) 'Remover el último Item del Historial.
                Dim ItemArrys As Integer = alHistorial.Count
                If (ItemArrys > 0) Then
                    HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlControlsForms) = alHistorial
                Else
                    ReiniciarSessionHistorialWebNavegacion()
                End If
            End If
        Catch ex As Exception
            Return Url
        End Try
        Return Url
    End Function

    Public Shared Sub HistorialWebRestablecerPagina(ByVal oPagina As System.Web.UI.Page)
        If Not (HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebControlsForms) Is Nothing) Xor Convert.ToString(HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebUrlPaginaAnterior)) = oPagina.Request.Url.AbsolutePath Then
            If Not (HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebControlsForms) Is Nothing) Then
                Dim oControl() As ClassControlWeb = CType(HttpContext.Current.Session(ConstantesWeb.KEYSesionHistorialWebControlsForms), ClassControlWeb())
                Dim Ele As Integer = 0

                For Ele = 0 To (oControl.Length - 1)
                    Dim ControlTypo As String = oControl(Ele).ControlType
                    Select Case ControlTypo
                        Case "System.Web.UI.WebControls.DropDownList"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), System.Web.UI.WebControls.DropDownList).SelectedValue = oControl(Ele).ControlValor

                        Case "System.Web.UI.HtmlControls.HtmlInputHidden"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), System.Web.UI.HtmlControls.HtmlInputHidden).Value = oControl(Ele).ControlValor

                        Case "System.Web.UI.WebControls.TextBox"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), System.Web.UI.WebControls.TextBox).Text = oControl(Ele).ControlValor

                        Case "eWorld.UI.NumericBox"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), eWorld.UI.NumericBox).Text = oControl(Ele).ControlValor

                        Case "customCalendar.webCalendar"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), customCalendar.webCalendar).Fecha = oControl(Ele).ControlValor

                        Case "System.Web.UI.WebControls.CheckBox"
                            CType(oPagina.FindControl(oControl(Ele).IdControl), System.Web.UI.WebControls.CheckBox).Checked = Convert.ToBoolean(oControl(Ele).ControlValor)
                    End Select
                Next
                ReiniciarSessionHistorialWebControlesFormulario()
                'DirectCast
            End If
            ReiniciarSessionHistorialWebUrlPaginaAnterior()
        End If
    End Sub

End Class
