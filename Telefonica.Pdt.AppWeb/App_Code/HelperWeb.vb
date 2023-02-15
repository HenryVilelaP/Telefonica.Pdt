Imports System
Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Cryptography
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Common.Enumeradores
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb
    Public Class HelperWeb
        Inherits System.Configuration.NameValueSectionHandler

#Region "Helper Inicial"

        Public Shared Sub AbrirDescargarArchivo(ByVal oPage As Page, ByVal Cadena As String)
            oPage.Response.ClearContent()
            oPage.Response.AppendHeader("Content-Disposition", "attachment;filename=ConteoFeedback.txt;")
            oPage.Response.Write(Cadena)
            oPage.Response.End()
        End Sub

        Public Shared Function AsignarDatoControlHtml2(ByVal NombreControlObjetoHtml As String, ByVal ValorAsignar As String) As String
            Return " document.forms[0].elements['" + NombreControlObjetoHtml + "'].value='" + ValorAsignar + "'; "
        End Function

        Public Shared Function SetFocusControlHtml(ByVal NombreControlObjetoHtml As String) As String
            Return " SetFocusControlHtml('" + NombreControlObjetoHtml + "'); "
        End Function

        Public Shared Sub ComboAddItemLibre(ByVal oCombo As DropDownList)
            Dim oItem As New ListItem(ConstantesWeb.TextoLibre, ConstantesWeb.ValorLibre)
            oCombo.Items.Insert(0, oItem)
        End Sub

        Public Shared Sub ComboAddItemSeleccionar(ByVal oCombo As DropDownList)
            Dim oItem As New ListItem(ConstantesWeb.TextoSeleccionar, ConstantesWeb.ValorSeleccionar)
            oCombo.Items.Insert(0, oItem)
        End Sub

        'Para valor del SelectedValue Vacio
        Public Shared Sub ComboAddItemSeleccionarVacio(ByVal oCombo As DropDownList)
            Dim oItem As New ListItem(ConstantesWeb.TextoSeleccionar, ConstantesWeb.VACIO)
            oCombo.Items.Insert(0, oItem)
        End Sub

        Public Shared Sub ComboAddItemTodos(ByVal oCombo As DropDownList)
            Dim oItem As New ListItem(ConstantesWeb.TextoTodos, ConstantesWeb.ValorTodos)
            oCombo.Items.Insert(0, oItem)
        End Sub

        Public Shared Sub ComboValidacionSiNo(ByVal oCombo As DropDownList)
            oCombo.Items.Insert(0, "Si")
            oCombo.Items.Insert(1, "No")
        End Sub

        Public Shared Sub ComboRemoveItem(ByVal oCombo As DropDownList, ByVal Value As String)
            Dim oItem As ListItem = oCombo.Items.FindByValue(Value)
            If (Not oItem Is Nothing) Then
                oCombo.Items.Remove(oItem)
            End If
        End Sub

        Public Shared Sub ComboSeleccionarItem(ByVal oCombo As DropDownList, ByVal Value As String)
            Dim oItem As ListItem = oCombo.Items.FindByValue(Value)
            If (Not oItem Is Nothing) Then
                oItem.Selected = True
            End If
        End Sub

        Public Shared Function ConvertTo_HH_mm_ss(ByVal segundos As Integer) As String
            Dim d As New DateTime(2000, 1, 1, 0, 0, 0)
            Return d.AddSeconds(Convert.ToInt32(segundos)).ToString("HH:mm:ss")
        End Function

        Public Shared Function CriterioOrdenamiento(ByVal criterioOrder As String) As String
            Select Case criterioOrder
                Case "ASC"
                    criterioOrder = "DESC"
                    Return criterioOrder
                Case "DESC"
                    criterioOrder = "ASC"
                    Return criterioOrder
            End Select
            criterioOrder = "ASC"
            Return criterioOrder
        End Function

        Public Shared Sub ExportarExcelDataTable(ByVal oPage As Page, ByVal dtExportar As DataTable)
            If (Not dtExportar Is Nothing) Then
                Dim str As New StringBuilder
                str.Append("<table border=1 bordercolor='#000000'>")
                str.Append("<tr>")
                Dim i As Integer
                For i = 0 To dtExportar.Columns.Count - 1
                    str.Append("<th style='WIDTH:95px'>")
                    str.Append(dtExportar.Columns.Item(i).ColumnName)
                    str.Append("</th>")
                Next i
                str.Append("</tr>")
                Dim dr As DataRow
                For Each dr In dtExportar.Rows
                    str.Append("<tr>")
                    For i = 0 To dtExportar.Columns.Count - 1
                        str.Append("<td style='WIDTH:95px' align='right'>")
                        If Not Convert.IsDBNull(dr.Item(i)) Then
                            str.Append(dr.Item(i).ToString)
                        End If
                        str.Append("</td>")
                    Next i
                    str.Append("</tr>")
                Next
                str.Append("</table>")
                oPage.Response.ClearHeaders()
                oPage.Response.Buffer = True
                oPage.Response.ContentType = "application/vnd.xls"
                oPage.Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1")
                oPage.Response.Clear()
                oPage.Response.AppendHeader("content-disposition", "attachment;filename=FileName.xls")
                oPage.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Dim stringWrite As New StringWriter(str)
                Dim htmlWrite As New HtmlTextWriter(stringWrite)
                oPage.Response.Write(str.ToString)
                oPage.Response.End()
            End If
        End Sub

        Public Shared Sub ExportarXMLDataTable(ByVal oPage As Page, ByVal dtExportar As DataTable)
            If Not (dtExportar Is Nothing) Then
                Dim str As New StringBuilder
                str.Append("<?xml version=""" + "1.0" + """ encoding=""" + "ISO-8859-1" + """ ?>")
                str.Append(Convert.ToChar(13) + Convert.ToChar(10))
                Dim NombreTabla As String = dtExportar.TableName
                str.Append("<" + NombreTabla + ">")
                str.Append(Convert.ToChar(13) + Convert.ToChar(10))

                For Each dr As DataRow In dtExportar.Rows
                    str.Append("<RowFilaXml>")

                    For i As Integer = 0 To (dtExportar.Columns.Count - 1)
                        Dim NombreColumna As String = dtExportar.Columns(i).ColumnName.Replace(" ", "_").Replace("º", "")
                        Dim ValorCell As String = ""
                        str.Append("<" + NombreColumna + ">")
                        If (Not Convert.IsDBNull(dr(i))) Then
                            ValorCell = Convert.ToString(dr(i))
                        End If
                        str.Append(ValorCell)
                        str.Append("</" + NombreColumna + ">")
                    Next

                    str.Append("</RowFilaXml>")
                    str.Append(Convert.ToChar(13) + Convert.ToChar(10))
                Next

                str.Append(Convert.ToChar(13) + Convert.ToChar(10))
                str.Append("</" + NombreTabla + ">")

                oPage.Response.ClearHeaders()
                oPage.Response.Buffer = True
                oPage.Response.ContentType = "application/vnd.txt"
                oPage.Response.ContentEncoding = Encoding.GetEncoding("ISO-8859-1")
                oPage.Response.Clear()
                oPage.Response.AppendHeader("content-disposition", "attachment;filename=" + NombreTabla + ".XML")
                oPage.Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Dim stringWrite As New StringWriter(str)
                Dim htmlWrite As New HtmlTextWriter(stringWrite)
                oPage.Response.Write(str.ToString)
                oPage.Response.End()

            End If
        End Sub

        Public Shared Sub ExportarExcelGrilla(ByVal oGrid As DataGrid)
            oGrid.Page.Response.Clear()
            oGrid.Page.Response.AddHeader("content-disposition", "attachment;filename=FileName.xls")
            oGrid.Page.Response.Charset = ""
            oGrid.Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            oGrid.Page.Response.ContentType = "application/vnd.xls"
            Dim stringWrite As New StringWriter
            Dim htmlWrite As New HtmlTextWriter(stringWrite)
            oGrid.RenderControl(htmlWrite)
            oGrid.Page.Response.Write(stringWrite.ToString)
            oGrid.Page.Response.End()
        End Sub

        Public Shared Function JsConfirmarAccionPaginaWeb(ByVal IdObjetoControl As String, ByVal strMensajeError As String, ByVal strMensajeParaConfirmar As String) As String
            Return String.Concat(New String() {" return ConfimarEliminarRegistroWeb('", IdObjetoControl, "','", strMensajeError, "','", strMensajeParaConfirmar, "'); "})
        End Function

        Public Shared Function JsConfirmarAccionSeleccionar(ByVal IdObjetoControl As String, ByVal strMensajeError As String, ByVal strMensajeParaConfirmar As String) As String
            Return String.Concat(New String() {" return ConfimarSeleccionarRegistro('", IdObjetoControl, "','", strMensajeError, "','", strMensajeParaConfirmar, "'); "})
        End Function

        Public Shared Function JsConfirmarEliminacionRegistro(ByVal IdObjetoControl As String) As String
            Dim sMensajeError As String = "Falta seleccionar el(los) registro(s) en la Lista "
            Dim sMensajeConfirmar As String = System.Convert.ToChar(191) & "Esta seguro de eliminar el(los) registro(s) seleccionado(s)? "
            Return HelperWeb.JsConfirmarAccionPaginaWeb(IdObjetoControl, sMensajeError, sMensajeConfirmar)
        End Function

        Public Shared Function JsConfirmarSeleccionRegistro(ByVal IdObjetoControl As String) As String
            Dim sMensajeError As String = "Falta seleccionar el(los) registro(s) en la Lista "
            Dim sMensajeConfirmar As String = System.Convert.ToChar(191) & "Est" & System.Convert.ToChar(225) & " seguro de asignar el(los) registro(s) seleccionado(s)? "
            Return HelperWeb.JsConfirmarAccionSeleccionar(IdObjetoControl, sMensajeError, sMensajeConfirmar)
        End Function

        Public Shared Function JsMensajeAlert(ByVal mensaje As String) As String
            Return ("alert('" & mensaje & "'); ")
        End Function

        Public Shared Function MensajeError(ByVal ex As Exception) As String
            Return ex.Message.Substring(1, 100)
        End Function

        Public Shared Function MensajeError(ByVal ex As Exception, ByVal CodigoMensaje As String) As String
            If (CodigoMensaje.Trim.Length > 0) Then
                Return "Se produjo un error en el servidor"
            End If
            Return ex.Message.Substring(1, 120)
        End Function



        Public Shared Sub TextBoxAlinearTextoHorizontal(ByVal oText As TextBox, ByVal Alineamiento As HorizontalAlign)
            oText.Style.Add("text-align", Alineamiento.ToString)
        End Sub


        Public Shared Function ValidarValorSeleccionado(ByVal oCombo As DropDownList, ByVal valRetorno As String, ByVal ParamArray valComparacion As String()) As String
            If (oCombo.Items.Count <= 0) Then
                Return valRetorno
            End If
            If ((Not valComparacion Is Nothing) AndAlso (valComparacion.Length > 0)) Then
                Dim val As String
                For Each val In valComparacion
                    If (oCombo.SelectedValue = val) Then
                        Return valRetorno
                    End If
                Next
            End If
            Return oCombo.SelectedValue
        End Function

        Public Shared Function ValidarValorTodos(ByVal oCombo As DropDownList, ByVal valRetorno As String) As String
            If (oCombo.Items.Count > 0) Then
                If (oCombo.SelectedValue = ConstantesWeb.ValorTodos) Then
                    Return valRetorno
                End If
                Return oCombo.SelectedValue
            End If
            Return valRetorno
        End Function

        Public Shared Function RadioButtonHtml(ByVal NombreControl As String, ByVal valor As String, ByVal JsCadenaOnclic As String) As String
            Dim str As String = "<INPUT type=" + ConstantesWeb.SignoCOMILLADOBLE + "radio" + ConstantesWeb.SignoCOMILLADOBLE + " value=" + ConstantesWeb.SignoCOMILLADOBLE + valor + ConstantesWeb.SignoCOMILLADOBLE + " name=" + ConstantesWeb.SignoCOMILLADOBLE + NombreControl + ConstantesWeb.SignoCOMILLADOBLE + " onclick=" + ConstantesWeb.SignoCOMILLADOBLE + JsCadenaOnclic + ConstantesWeb.SignoCOMILLADOBLE + " > "
            Return str
        End Function

        Public Shared Function VerificarSeleccionControl(ByVal IdObjetoControl As String, ByVal Mensaje As String) As String
            Dim str As String = " return VerificarSeleccionControl('" + IdObjetoControl + "','" + Mensaje + "'); "
            Return str
        End Function

        Public Shared Function ListarEnterosPorRango(ByVal valMinimo As Integer, ByVal valMaximo As Integer, ByVal OrdenadoASC As Boolean) As ArrayList
            Dim ArrayEntero As New ArrayList
            If (OrdenadoASC = True) Then
                For i As Integer = valMinimo To valMaximo
                    ArrayEntero.Add(i)
                Next
            Else
                For i As Integer = valMaximo To valMinimo Step -1
                    ArrayEntero.Add(i)
                Next
            End If
            Return ArrayEntero
        End Function

        Public Shared Function ArchivoRetornarNombreArchivo(ByVal oHtmlInputFile As System.Web.UI.HtmlControls.HtmlInputFile) As String
            Dim strNombreArchivo As String
            strNombreArchivo = System.IO.Path.GetFileName(oHtmlInputFile.PostedFile.FileName)
            Return strNombreArchivo
        End Function

        Public Shared Function ExtensionDocumento(ByVal NombreDocumento As String) As String
            Dim strExt As String = ""
            Dim Extension() As String = NombreDocumento.Split("."c)
            Dim CountElemento As Integer = Extension.Length
            If (CountElemento > 0) Then
                strExt = Extension(CountElemento - 1)
                strExt = "." + strExt
            End If
            Return strExt
        End Function

        Public Shared Function AbrirArchivoServer(ByVal oPage As System.Web.UI.Page, ByVal RutaFileServerNombreArchivo As String, ByVal NombreArchivoMostrar As String) As String
            Dim strReader As New System.IO.StreamReader(RutaFileServerNombreArchivo)
            Dim k As Integer = Convert.ToInt32(strReader.BaseStream.Length)
            Dim myData() As Byte = New Byte(k) {}
            strReader.BaseStream.Read(myData, 0, k)
            oPage.Response.ClearHeaders()
            oPage.Response.Buffer = True
            oPage.Response.Clear()
            oPage.Response.AppendHeader("Content-Disposition", "attachment;filename=" + NombreArchivoMostrar + ";")
            oPage.Response.BinaryWrite(myData)
            oPage.Response.End()
            Return Nothing
        End Function

        Public Shared Function WebConfigObtenerValorPorKey(ByVal Key As String) As String
            Dim valor As String = System.Configuration.ConfigurationManager.AppSettings(Key)
            Return valor
        End Function

        Public Shared Function AbrirVentanaWinPopup(ByVal pagina As String, ByVal namePagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','" & namePagina & "','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=20,left=40'); "
            Cadena = "var ventana = " + Cadena ' + Convert.ToChar(10) + Convert.ToChar(13)
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); return "
            Cadena += "false; "
            Return Cadena
        End Function

        Public Shared Function AbrirVentanaWinPopup2(ByVal pagina As String, ByVal namePagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','" & namePagina & "','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=20,left=40'); "
            Cadena = "var ventana = " + Cadena ' + Convert.ToChar(10) + Convert.ToChar(13)
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); "
            Return Cadena
        End Function

        Const EXPORTAREXCEL As String = "application/vnd.ms-excel"

        Public Shared Sub ExportaExcel(ByVal Pagina As System.Web.UI.Page)
            Pagina.Response.ContentType = EXPORTAREXCEL
            Pagina.Response.ContentEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1")
            Pagina.Response.AppendHeader("content-disposition", "attachment;   filename=" + Pagina.ClientID.Replace("."c, "") + ".xls")
        End Sub

        Public Shared Function HTMLIframe(ByVal Url As String, ByVal sWidthPx As String, ByVal sHeightPx As String) As String
            Dim str As String = ""
            str += "<iframe src=" + Url + " width='" + sWidthPx + "' "
            str += "height='" + sHeightPx + "' scrolling='auto' frameborder='0' transparency>"
            str += "<p>Texto alternativo para navegadores que no aceptan iframes.</p>"
            str += "</iframe>"
            Return str
        End Function

#End Region

#Region "Mensaje Confirmacion Proceso"
        Public Shared Function JsConfirmarAccionProceso(ByVal MensajeConfir As String) As String
            Return " return ConfirmarAccionProceso('" + MensajeConfir + "'); "
        End Function

        Public Shared Function JsConfirmarAccionEliminar() As String
            Return JsConfirmarAccionProceso("¿Esta seguro que desea eliminar el registro? ")
        End Function

#End Region

#Region "Seguridad"

#End Region


        'Const EXPORTAREXCEL As String = "application/vnd.ms-excel"
        Const EXPORTARWORD As String = "application/vnd.ms-word"
        Const BOTONCANCELAR As String = "ibtnCancelar"
        Const BOTONATRAS As String = "ibtnAtras"
        Const STYLEBACKCOLOR As String = "background-color"
        Const COLOR As String = "Transparent"
        Const STYLEBORDER As String = "border-style"
        Const NONE As String = "none"
        Const CALPREFIJOCALENDARIO As String = ":txtFecha"

        Public Shared Function ObtenerIndiceRegistroGrilla(ByVal GridControl As DataGrid, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) As String
            Dim IndiceRegistro As Integer = (GridControl.CurrentPageIndex * GridControl.PageSize) + e.Item.ItemIndex + 1
            Return IndiceRegistro.ToString()
        End Function

        Public Shared Function ObtenerIndiceRegistroGrillaNuevo(ByVal GridControl As DataGrid, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) As String
            Dim IndiceRegistro As Integer = (GridControl.CurrentPageIndex * GridControl.PageSize) + e.Item.ItemIndex + 1
            Return IndiceRegistro.ToString()
        End Function

        Public Shared Function ObtenerIndiceRegistroGrilla(ByVal GridControl As System.Web.UI.WebControls.GridView, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) As String
            Dim IndiceRegistro As Integer = (GridControl.PageIndex * GridControl.PageSize) + e.Row.RowIndex + 1
            Return IndiceRegistro.ToString()
        End Function

        Public Shared Function ObtenerIndiceRegistroGrillaMenos1(ByVal GridControl As DataGrid, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) As String
            Dim IndiceRegistro As Integer = (GridControl.CurrentPageIndex * GridControl.PageSize) + e.Item.ItemIndex
            Return IndiceRegistro.ToString()
        End Function

        Public Shared Function MensajeAlert(ByVal mensaje As String) As String
            Return "alert('" + mensaje + "'); "
        End Function

        Public Shared Sub SeleccionarItemGrillaOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
            Dim Cadena As String = ""
            SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
        End Sub

        ' DataGrid View. Evento
        Public Shared Sub SeleccionarItemGrillaOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            Dim Cadena As String = ""
            SeleccionarItemGrillaOnClickMoverRaton(e, Cadena)
        End Sub

        Public Shared Sub SeleccionarItemGrillaPublicoOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
            Dim Cadena As String = ""
            SeleccionarItemGrillaPublicoOnClickMoverRaton(e, Cadena)
        End Sub

        Public Shared Sub SeleccionarItemGrillaOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, ByVal CadenaScriptOnClick As String)
            e.Item.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseover.ToString())
            e.Item.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseout.ToString())
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseover.ToString(), "CambiarColorPasarMouseOver(this); ")
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseout.ToString(), "CambiarColorPasarMouseOut(this); ")
            Dim Cadena As String = ""
            'Cadena += "CambiarColorSeleccion(this); "
            Cadena += CadenaScriptOnClick
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick.ToString(), Cadena)
        End Sub

        ' DataGrid View. Evento
        Public Shared Sub SeleccionarItemGrillaOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs, ByVal CadenaScriptOnClick As String)
            e.Row.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseover.ToString())
            e.Row.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseout.ToString())
            e.Row.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseover.ToString(), "CambiarColorPasarMouseOver(this); ")
            e.Row.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseout.ToString(), "CambiarColorPasarMouseOut(this); ")
            Dim Cadena As String = ""
            'Cadena += "CambiarColorSeleccion(this); "
            Cadena += CadenaScriptOnClick
            e.Row.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick.ToString(), Cadena)

        End Sub

        Public Shared Sub SeleccionarItemGrillaPublicoOnClickMoverRaton(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, ByVal CadenaScriptOnClick As String)
            e.Item.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseover.ToString())
            e.Item.Attributes.Remove(ConstantesWeb.EventosJavaScript.OnMouseout.ToString())
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseover.ToString(), "CambiarColorPasarMouseOverPublico(this); ")
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnMouseout.ToString(), "CambiarColorPasarMouseOutPublico(this); ")
            Dim Cadena As String = ""
            'Cadena += "CambiarColorSeleccion(this); "
            Cadena += CadenaScriptOnClick
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick.ToString(), Cadena)
        End Sub

        Public Shared Sub SeleccionarItemGrillaEventoOnClick(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs, ByVal CadenaScriptOnClick As String)
            Dim Cadena As String = CadenaScriptOnClick
            e.Item.Attributes.Add(ConstantesWeb.EventosJavaScript.OnClick.ToString(), Cadena)
        End Sub

        Public Shared Function CortarTextoDerecha(ByVal tamaño As Integer, ByVal texto As String) As String
            Return texto.Substring(texto.Length - tamaño, tamaño)
        End Function

        Public Shared Sub ReiniciarSession()
            HttpContext.Current.Session(ConstantesWeb.KEYSesionSORT) = Nothing
            HttpContext.Current.Session(ConstantesWeb.KEYSesionDIRECCIONSORT) = Nothing
        End Sub

        Public Shared Function GenerarExpresionOrdenamiento(ByVal ColumnaSort As String, ByVal OrdenamientoASC As Boolean) As String
            Dim direccionSort As String = ""

            If HttpContext.Current.Session(ConstantesWeb.KEYSesionSORT) Is Nothing Then
                If OrdenamientoASC = True Then
                    direccionSort = ConstantesWeb.OrdenamientoSortASC
                Else
                    direccionSort = ConstantesWeb.OrdenamientoSortDESC
                End If
            Else
                If CType(HttpContext.Current.Session(ConstantesWeb.KEYSesionSORT), String) = ColumnaSort Then
                    If CType(HttpContext.Current.Session(ConstantesWeb.KEYSesionDIRECCIONSORT), String) = ConstantesWeb.OrdenamientoSortASC Then
                        direccionSort = ConstantesWeb.OrdenamientoSortDESC
                    Else
                        direccionSort = ConstantesWeb.OrdenamientoSortASC
                    End If
                Else
                    direccionSort = ConstantesWeb.OrdenamientoSortASC
                End If
            End If
            HttpContext.Current.Session(ConstantesWeb.KEYSesionSORT) = ColumnaSort
            HttpContext.Current.Session(ConstantesWeb.KEYSesionDIRECCIONSORT) = direccionSort
            ColumnaSort = ColumnaSort + ConstantesWeb.ESPACIO + direccionSort
            Return ColumnaSort
        End Function

        Public Shared Function AsignarDatoControlHtml(ByVal NombreControlObjetoHtml As String, ByVal ValorAsignar As String) As String
            Dim Cadena As String = "MostrarDatosEnCajaTexto('" + NombreControlObjetoHtml + "','" + ValorAsignar + "'); " + ConstantesWeb.ESPACIO
            Return Cadena

        End Function

        Public Shared Function ValidarIndicePaginacionGrilla(ByVal CantidadRegistrosData As Integer, ByVal CantidadRegistrosPorPagina As Integer, ByVal IndiceActualPaginacionGrilla As Integer) As Integer
            Dim retorno As Integer = 0
            retorno = Convert.ToInt32(CantidadRegistrosData / CantidadRegistrosPorPagina)
            If (retorno < IndiceActualPaginacionGrilla) Then
                Return retorno
            Else
                Return IndiceActualPaginacionGrilla
            End If
        End Function

        Public Shared Function BoolInvertirValorBoleano(ByVal Valor As Boolean) As Boolean
            If Valor = True Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Shared Function JavaScriptVerificarSeleccionControl(ByVal IdNombreControlHtml As String, ByVal MensajeMostrar As String) As String
            Dim CadenaJava As String = " return VerificarSeleccionControl('" + IdNombreControlHtml + "','" + MensajeMostrar + "'); " + ConstantesWeb.ESPACIO
            Return CadenaJava
        End Function

        Public Shared Function BooleanCambiarValorBool(ByVal ValorBool As Boolean) As Boolean
            If ValorBool = True Then
                Return False
            Else
                Return True
            End If
        End Function

        Public Shared Function BooleanCambiarValorVisible(ByVal oControl As System.Web.UI.Control) As Boolean
            Return (Not oControl.Visible)
        End Function

        Public Shared Sub SeleccionarItemComboWeb(ByVal ObjetoCombo As System.Web.UI.WebControls.DropDownList, ByVal ValorSelectValue As String)
            Dim Item As New System.Web.UI.WebControls.ListItem
            Item = ObjetoCombo.Items.FindByValue(ValorSelectValue)
            If Not (Item Is Nothing) Then
                Item.Selected = True
            End If
        End Sub

        Public Shared Function JavaScriptConfirmarEliminacionRegistro(ByVal IdObjetoControl As String) As String
            Dim sMensajeError As String = "FALTA SELECCIONAR UN REGISTRO..."
            Dim sMensajeConfirmar As String = "DESEA ELIMINAR REGISTRO?"
            Dim sCadena As String = JavaScripConfirmarAccionPaginaWeb(IdObjetoControl, sMensajeError, sMensajeConfirmar)
            Return sCadena
        End Function

        Public Shared Function JavaScripConfirmarAccionPaginaWeb(ByVal IdObjetoControl As String, ByVal strMensajeError As String, ByVal strMensajeParaConfirmar As String) As String
            Dim sCadena As String = " return ConfimarEliminarRegistro('" + IdObjetoControl + "','" + strMensajeError + "','" + strMensajeParaConfirmar + "'); "
            Return sCadena

        End Function

        Public Shared Function ConvertToDataTable(ByVal DataViewOrigen As DataView) As DataTable
            If Not (DataViewOrigen Is Nothing) Then
                If (DataViewOrigen.Count > 0) Then
                    Dim dt As DataTable = DataViewOrigen.Table.Clone
                    Dim drNew As DataRow
                    For Each drW As DataRowView In DataViewOrigen
                        drNew = dt.NewRow()
                        For C As Integer = 0 To (dt.Columns.Count - 1)
                            drNew(C) = drW.Row(C)
                        Next
                        dt.Rows.Add(drNew)
                    Next
                    Return dt
                Else
                    Return Nothing
                End If
            Else
                Return Nothing
            End If
        End Function

        Public Shared Function ConvertToDateTime(ByVal valueFecha As String) As DateTime
            Dim Format As System.IFormatProvider = New System.Globalization.CultureInfo("es-PE", True)
            Dim datFecha As DateTime = Convert.ToDateTime(valueFecha, Format)
            Return datFecha
        End Function

        Public Shared Function ConvertToDateTime(ByVal ControlCalendario As customCalendar.webCalendar) As DateTime
            Dim datFecha As DateTime = ConvertToDateTime(ControlCalendario.Fecha)
            Return datFecha
        End Function

        Public Shared Sub AbrirVentanaWinPopupServidor(ByVal Pagina As Page, ByVal keyPopup As String, ByVal Nombrepagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean, ByVal retur As Boolean)
            Dim Cadena As String
            Cadena = "<script language=JavaScript id='" + keyPopup + "'> "
            Cadena += "window.open('" + Nombrepagina + "','miwin','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=20,left=40'); "
            Cadena += "</script>"
            Pagina.ClientScript.RegisterClientScriptBlock(Pagina.GetType(), keyPopup, Cadena)
        End Sub

        Public Shared Function RecargarFormularioPadreDeUnPopup() As String
            Dim Cadena As String = " window.opener.location.reload(); " + CerrarVentana()
            Return Cadena
        End Function

        Public Shared Function RecargarFormulario() As String
            Dim Cadena As String = " window.opener.document.forms[0].submit();"
            Return Cadena
        End Function

        Public Shared Function CerrarVentana() As String
            Dim Cadena As String
            Cadena = "window.close(); "
            Return Cadena
        End Function

        Public Shared Function PageResponseRedirect(ByVal UrlPagina As String) As String
            Dim cadena As String = "window.location.href='" + UrlPagina + "'; "
            Return cadena
        End Function

        Public Shared Function PageResponseRedirect(ByVal UrlPagina As String, ByVal MensajeAlertPrevio As String) As String
            Dim cadena As String = HelperWeb.MensajeAlert(MensajeAlertPrevio) + " window.location.href='" + UrlPagina + "'; "
            Return cadena
        End Function

        Public Shared Function AbrirVentanaWinPopup(ByVal pagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean, ByVal retur As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','miwin','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=20,left=40'); "
            Cadena = "var ventana = " + Cadena
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); return "
            If retur = False Then
                Cadena += "false; "
            Else
                Cadena += "true; "
            End If
            Return Cadena
        End Function

        Public Shared Function AbrirVentanaWinPopup(ByVal pagina As String, ByVal namePagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal Top As Integer, ByVal Left As Integer, ByVal scrollBars As Boolean, ByVal retur As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','" & namePagina & "','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=" + Top.ToString() + ",left=" + Left.ToString() + ",menubar=no'); "
            Cadena = "var ventana = " + Cadena
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); return "
            If retur = False Then
                Cadena += "false; "
            Else
                Cadena += "true; "
            End If
            Return Cadena
        End Function

        Public Shared Function AbrirVentanaWinPopup(ByVal pagina As String, ByVal namePagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean, ByVal retur As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','" & namePagina & "','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=20,left=40'); "
            Cadena = "var ventana = " + Cadena
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); return "
            If retur = False Then
                Cadena += "false; "
            Else
                Cadena += "true; "
            End If
            Return Cadena
        End Function

        Public Shared Function CrearLibroTrabajoExcel(ByVal ds As DataSet) As String
            Dim xmldd As New System.Xml.XmlDataDocument(ds)
            Dim xslt As New System.Xml.Xsl.XslCompiledTransform
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(GetType(HelperWeb).Assembly.GetManifestResourceStream(GetType(HelperWeb), "Excel.xsl"))
            Dim xmlreader As System.Xml.XmlTextReader = New System.Xml.XmlTextReader(reader)
            xslt.Load(xmlreader, Nothing, Nothing)
            Dim sw As New System.IO.StringWriter
            xslt.Transform(xmldd, Nothing, sw)
            Return sw.ToString()
        End Function

        Public Shared Sub GenerarExcelGeneral(ByVal pagina As Page, ByVal grid As GridView)
            Dim sb As StringBuilder = New StringBuilder()
            Dim SW As System.IO.StringWriter = New System.IO.StringWriter(sb)
            Dim htw As HtmlTextWriter = New HtmlTextWriter(SW)
            Dim Page As Page = New Page()
            Dim form As HtmlForm = New HtmlForm()
            grid.EnableViewState = False
            Page.EnableEventValidation = False
            Page.DesignerInitialize()
            Page.Controls.Add(form)
            form.Controls.Add(grid)
            Page.RenderControl(htw)
            pagina.Response.Clear()
            pagina.Response.Buffer = True
            pagina.Response.ContentType = "application/vnd.ms-excel"
            pagina.Response.AddHeader("Content-Disposition", "attachment;filename=data.xls")
            pagina.Response.Charset = "UTF-8"
            pagina.Response.ContentEncoding = Encoding.Default
            pagina.Response.Write(sb.ToString())
            pagina.Response.End()
        End Sub

        Private Shared Sub ClearControls(ByVal control As Control)
            Dim i As Integer
            For i = control.Controls.Count - 1 To 0 Step -1
                ClearControls(control.Controls(i))
            Next
            If control.GetType() Is GetType(TableCell) Then
                If Not control.GetType().GetProperty(Propiedades.SelectedItem.ToString()) Is Nothing Then
                    Dim literal As LiteralControl = New LiteralControl
                    control.Parent.Controls.Add(literal)
                    Try
                        literal.Text = CType(control.GetType().GetProperty(Propiedades.SelectedItem.ToString()).GetValue(control, Nothing), String)
                    Catch
                    End Try
                    control.Parent.Controls.Remove(control)
                Else
                    If Not control.GetType().GetProperty(Propiedades.Text.ToString()) Is Nothing Then
                        Dim literal As LiteralControl = New LiteralControl
                        control.Parent.Controls.Add(literal)
                        literal.Text = CType(control.GetType().GetProperty(Propiedades.Text.ToString()).GetValue(control, Nothing), String)
                        control.Parent.Controls.Remove(control)
                    End If
                End If
                Return
            End If
        End Sub

        Private Enum Propiedades
            SelectedItem
            Text
        End Enum

#Region "General"

        Public Shared Sub RegistrarJavaScriptEnHead(ByVal oPage As Page, ByVal NombreBloqueJava As String, ByVal CogidoDelBloqueJavaScript As String)
            Dim JsCadena As String = "<script language=""JavaScript"" type=""text/javascript"">" + Microsoft.VisualBasic.vbCrLf + CogidoDelBloqueJavaScript + Microsoft.VisualBasic.vbCrLf + "</script>"
            If (Not oPage.ClientScript.IsClientScriptBlockRegistered(NombreBloqueJava)) Then
                oPage.ClientScript.RegisterClientScriptBlock(oPage.GetType(), NombreBloqueJava, JsCadena)
            End If
        End Sub

        Public Shared Function ArchivoGrabarServidor(ByVal RutaGrabarNombreArchivo As String, ByVal Buffer As Byte()) As Integer
            Dim newFile As New System.IO.FileStream(RutaGrabarNombreArchivo, FileMode.Create)
            newFile.Write(Buffer, 0, Buffer.Length)
            newFile.Close()

            Return ConstantesWeb.VALORCONFIRMACIONREGISTRO

        End Function

        Public Shared Function ArchivoRetornarExtension(ByVal oHtmlInputFile As System.Web.UI.HtmlControls.HtmlInputFile) As String
            Dim strExtensionArchivo As String
            strExtensionArchivo = System.IO.Path.GetExtension(oHtmlInputFile.PostedFile.FileName)
            Return strExtensionArchivo

        End Function

        Public Shared Function ArchivoRetornarExtension(ByVal oHtmlInputFile As System.Web.UI.WebControls.FileUpload) As String
            Dim strExtensionArchivo As String
            strExtensionArchivo = System.IO.Path.GetExtension(oHtmlInputFile.PostedFile.FileName)
            Return strExtensionArchivo

        End Function

        Public Shared Function ArchivoRetornarNombre(ByVal oHtmlInputFile As System.Web.UI.WebControls.FileUpload) As String
            Dim strNombreArchivo As String
            strNombreArchivo = System.IO.Path.GetFileName(oHtmlInputFile.PostedFile.FileName)
            Return strNombreArchivo

        End Function

        Public Shared Function ArchivoRetornarBuffer(ByVal oHtmlInputFile As System.Web.UI.HtmlControls.HtmlInputFile) As Byte()
            Dim myFile As HttpPostedFile = oHtmlInputFile.PostedFile
            Dim nFileLen As Integer = myFile.ContentLength
            Dim myData() As Byte = New Byte(nFileLen) {}
            myFile.InputStream.Read(myData, 0, nFileLen)

            Return myData

        End Function

        Public Shared Function ArchivoRetornarBuffer(ByVal oHtmlInputFile As System.Web.UI.WebControls.FileUpload) As Byte()
            Dim myFile As HttpPostedFile = oHtmlInputFile.PostedFile
            Dim nFileLen As Integer = myFile.ContentLength
            Dim myData() As Byte = New Byte(nFileLen) {}
            myFile.InputStream.Read(myData, 0, nFileLen)

            Return myData

        End Function


        Private Shared Function ListarPeriodos(ByVal PeriodoInicial As Integer, ByVal PeriodoFinal As Integer, ByVal OrdenadoDecendente As Boolean) As ArrayList
            Dim oList As New ArrayList
            If (OrdenadoDecendente = True) Then
                Do While PeriodoFinal >= PeriodoInicial
                    oList.Add(PeriodoFinal)
                    PeriodoFinal = PeriodoFinal - 1
                Loop
            Else
                Do While PeriodoFinal >= PeriodoInicial
                    oList.Add(PeriodoInicial)
                    PeriodoInicial = PeriodoInicial + 1
                Loop
            End If

            Return oList
        End Function

        Public Shared Sub LlenarComboPeriodos(ByVal ControlCombo As DropDownList, ByVal PeriodoInicial As Integer, ByVal PeriodoFinal As Integer, ByVal OrdenadoDecendente As Boolean)
            ControlCombo.DataSource = ListarPeriodos(PeriodoInicial, PeriodoFinal, OrdenadoDecendente)
            ControlCombo.DataBind()

        End Sub

        Public Shared Sub LlenaComboSeleccionItem(ByVal ControlCombo As DropDownList)
            Dim oListItem As New ListItem(ConstantesWeb.TextoSeleccionar, ConstantesWeb.ValorSeleccionar)
            ControlCombo.Items.Insert(0, oListItem)
        End Sub

        Public Shared Function MinutosDataTable() As DataTable

            Dim dtNew As New DataTable("dtNew")
            Dim dcNew As DataColumn
            Dim drNew As DataRow

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.Int32")
            dcNew.ColumnName = "IdMinuto"
            dtNew.Columns.Add(dcNew)

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.String")
            dcNew.ColumnName = "varMinutos"
            dtNew.Columns.Add(dcNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 0
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 5
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "05"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 10
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "10"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 15
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "15"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 20
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "20"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 25
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "25"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 30
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "30"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 35
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "35"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 40
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "40"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 45
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "45"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 50
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "50"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()) = 55
            drNew(ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()) = "55"
            dtNew.Rows.Add(drNew)

            Return dtNew

        End Function

        Public Shared Function HorasDataTable() As DataTable

            Dim dtNew As New DataTable("dtNew")
            Dim dcNew As DataColumn
            Dim drNew As DataRow

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.Int32")
            dcNew.ColumnName = "IdHora"
            dtNew.Columns.Add(dcNew)

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.String")
            dcNew.ColumnName = "varHora"
            dtNew.Columns.Add(dcNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 0
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "00:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 1
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "01:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 2
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "02:00"
            dtNew.Rows.Add(drNew)
            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 3
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "03:00"
            dtNew.Rows.Add(drNew)
            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 4
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "04:00"
            dtNew.Rows.Add(drNew)
            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 5
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "05:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 6
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "06:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 7
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "07:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 8
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "08:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 9
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "09:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 10
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "10:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 11
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "11:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 12
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "12:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 13
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "13:00"

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 14
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "14:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 15
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "15:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 16
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "16:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 17
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "17:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 18
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "18:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 19
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "19:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 20
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "20:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 21
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "21:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 22
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "22:00"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()) = 23
            drNew(ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()) = "23:00"
            dtNew.Rows.Add(drNew)

            Return dtNew

        End Function

        Public Shared Function MesesDataTable() As DataTable

            Dim dtNew As New DataTable("dtNew")
            Dim dcNew As DataColumn
            Dim drNew As DataRow

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.Int32")
            dcNew.ColumnName = "IdMes"
            dtNew.Columns.Add(dcNew)

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.String")
            dcNew.ColumnName = "NombreMes"
            dtNew.Columns.Add(dcNew)

            drNew = dtNew.NewRow()

            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 1
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "ENERO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 2
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "FEBRERO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 3
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "MARZO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 4
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "ABRIL"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 5
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "MAYO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 6
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "JUNIO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 7
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "JULIO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 8
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "AGOSTO"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 9
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "SETIEMBRE"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 10
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "OCTUBRE"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 11
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "NOVIEMBRE"
            dtNew.Rows.Add(drNew)

            drNew = dtNew.NewRow()
            drNew(ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()) = 12
            drNew(ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()) = "DICIEMBRE"
            dtNew.Rows.Add(drNew)

            Return dtNew

        End Function

        Public Shared Function DiasDataTable() As DataTable

            Dim dtNew As New DataTable("dtNew")
            Dim dcNew As DataColumn
            Dim drNew As DataRow
            Dim intIndice As Integer
            intIndice = ConstantesWeb.ValorConstanteUno
            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.Int32")
            dcNew.ColumnName = "IdDia"
            dtNew.Columns.Add(dcNew)

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.String")
            dcNew.ColumnName = "NombreDia"
            dtNew.Columns.Add(dcNew)

            For intIndice = ConstantesWeb.ValorConstanteUno To 31
                drNew = dtNew.NewRow()
                drNew(ConstantesWeb.GeneralColumnasTDias.IdDia.ToString()) = intIndice
                drNew(ConstantesWeb.GeneralColumnasTDias.NombreDia.ToString()) = Convert.ToString(intIndice)
                dtNew.Rows.Add(drNew)
            Next

            Return dtNew

        End Function

        Public Shared Function RangoNumerosDataTable(ByVal intNumeroInicial As Integer, ByVal intNumeroFinal As Integer) As DataTable

            Dim dtNew As New DataTable("dtNew")
            Dim dcNew As DataColumn
            Dim drNew As DataRow

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.Int32")
            dcNew.ColumnName = "IdNumero"
            dtNew.Columns.Add(dcNew)

            dcNew = New DataColumn
            dcNew.DataType = System.Type.GetType("System.String")
            dcNew.ColumnName = "Numero"
            dtNew.Columns.Add(dcNew)

            Dim intNumero As Integer
            For intNumero = intNumeroInicial To intNumeroFinal
                drNew = dtNew.NewRow()
                drNew("IdNumero") = intNumero
                drNew("Numero") = intNumero
                dtNew.Rows.Add(drNew)
            Next
            Return dtNew

        End Function

        Public Shared Sub LlenarComboHoras(ByVal ControlComboDropDownList As DropDownList)
            Dim dt As DataTable = HorasDataTable()
            ControlComboDropDownList.DataSource = dt
            ControlComboDropDownList.DataValueField = ConstantesWeb.GeneralColumnasTHoras.IdHora.ToString()
            ControlComboDropDownList.DataTextField = ConstantesWeb.GeneralColumnasTHoras.varHora.ToString()
            ControlComboDropDownList.DataBind()
        End Sub

        Public Shared Sub LlenarComboMinutos(ByVal ControlComboDropDownList As DropDownList)
            Dim dt As DataTable = MinutosDataTable()
            ControlComboDropDownList.DataSource = dt
            ControlComboDropDownList.DataValueField = ConstantesWeb.GeneralColumnasTMinutos.IdMinuto.ToString()
            ControlComboDropDownList.DataTextField = ConstantesWeb.GeneralColumnasTMinutos.varMinutos.ToString()
            ControlComboDropDownList.DataBind()
        End Sub

        Public Shared Sub LlenarComboWebMesesPeriodo(ByVal ControlComboDropDownList As DropDownList)
            Dim dt As DataTable = MesesDataTable()
            ControlComboDropDownList.DataSource = dt
            ControlComboDropDownList.DataValueField = ConstantesWeb.GeneralColumnasTMeses.idMes.ToString()
            ControlComboDropDownList.DataTextField = ConstantesWeb.GeneralColumnasTMeses.NombreMes.ToString()
            ControlComboDropDownList.DataBind()

        End Sub

        'Public Shared Sub LlenarComboWebAnosPeriodo(ByVal intAnoInicial As Integer, ByVal intNumeroAnos As Integer, ByVal ControlComboDropDownList As DropDownList)
        '    Dim dt As DataTable = AnosDataTable(intAnoInicial, intNumeroAnos)
        '    Dim oListItem As ListItem
        '    ControlComboDropDownList.DataSource = dt
        '    ControlComboDropDownList.DataValueField = ConstantesWeb.GeneralColumnasTAnos.idAno.ToString()
        '    ControlComboDropDownList.DataTextField = ConstantesWeb.GeneralColumnasTAnos.NombreAno.ToString()
        '    ControlComboDropDownList.DataBind()
        '    oListItem = New ListItem(ConstantesWeb.TextoSeleccionar, ConstantesWeb.ValorConstanteMenosUno.ToString())
        '    ControlComboDropDownList.Items.Insert(0, oListItem)
        'End Sub

        Public Shared Sub MesesLlenarComboWeb(ByVal ControlComboDropDownList As DropDownList)
            LlenarComboWebMesesPeriodo(ControlComboDropDownList)
        End Sub

        'Public Shared Sub AnosLlenarComboWeb(ByVal intAnoInicial As Integer, ByVal intNumeroAnos As Integer, ByVal ControlComboDropDownList As DropDownList)
        '    LlenarComboWebAnosPeriodo(intAnoInicial, intNumeroAnos, ControlComboDropDownList)
        'End Sub

        Public Shared Function ObtenerFechaSistemaDateTime() As DateTime
            Dim fecha As Date = DateTime.Now
            Return fecha
        End Function

        'Public Shared Function ObtenerFechaSistemaNullableDateTime() As NullableDateTime
        '    Dim fecha As NullableDateTime = NullableDateTime.Parse(DateTime.Now)
        '    Return fecha
        'End Function

        'Public Shared Function LimpiarTexto(ByVal CadenaTexto As String) As String
        '    Return CadenaTexto.Replace("<", "(").ToString().Replace(">", ")").ToString().Replace(Chr(13) + Chr(10), " ").ToString().Replace("'", ",").ToString()
        'End Function

        Public Shared Function LimpiarTextoMantenerSaltoLinea(ByVal CadenaTexto As String) As String
            Return CadenaTexto.Replace("<", "(").ToString().Replace(">", ")").ToString().Replace(Chr(13) + Chr(10), "\r\n").Replace("'", "\'").Replace(Chr(9), "\t").ToString()
        End Function

        Public Shared Function UltimoDiaDelMes(ByVal intMes As Integer, ByVal intAno As Integer) As Integer
            Dim datMesSiguiente As DateTime
            datMesSiguiente = DateAdd("m", 1, DateSerial(intAno, intMes, Convert.ToInt32("01")))
            UltimoDiaDelMes = Day(DateAdd("d", -1, datMesSiguiente))
        End Function


#End Region

#Region "Remover Duplicados de un datatable"
        Public Shared Sub RemoverDuplicados(ByRef dt As DataTable, ByVal KeyColumns As System.Data.DataColumn())
            Dim IndiceFila As Integer = 0
            While IndiceFila < dt.Rows.Count - 1
                Dim FilasDuplicadas As DataRow() = EncontrarDuplicados(dt, IndiceFila, KeyColumns)
                If (FilasDuplicadas.Length > 0) Then
                    Dim Fila As DataRow
                    For Each Fila In FilasDuplicadas
                        dt.Rows.Remove(Fila)
                    Next
                Else
                    IndiceFila += 1
                End If
            End While
        End Sub
        Private Shared Function EncontrarDuplicados(ByVal dt As DataTable, ByVal Indice As Integer, ByVal KeyColumns As System.Data.DataColumn()) As DataRow()
            Dim contador As Integer
            Dim retorno As ArrayList = New ArrayList
            Dim FilaFuente As DataRow = dt.Rows(Indice)
            For contador = Indice + 1 To dt.Rows.Count - 1 Step 1
                Dim FilaObjetivo As DataRow = dt.Rows(contador)
                If EsDuplicado(FilaFuente, FilaObjetivo, KeyColumns) Then
                    retorno.Add(FilaObjetivo)
                End If
            Next
            Return CType(retorno.ToArray(GetType(DataRow)), DataRow())
        End Function
        Private Shared Function EsDuplicado(ByVal FilaFuente As DataRow, ByVal FilaObjetivo As DataRow, ByVal KeyColumns As System.Data.DataColumn()) As Boolean
            Dim retorno As Boolean = True
            Dim columna As DataColumn
            For Each columna In KeyColumns
                retorno = (retorno And FilaFuente(columna.ColumnName).Equals(FilaObjetivo(columna.ColumnName)))
                If retorno = False Then
                    Exit For
                End If
            Next
            Return retorno
        End Function
#End Region


#Region "Funciones Ajax"

        Public Shared Sub Ajax_cargarCombo(ByVal idComboFormulario As String, ByVal nombrePagina As String, ByVal Pagina As System.Web.UI.Page, ByVal nombreMetodoAjax As String, ByVal nombreCampoValue As String, ByVal nombreCampoText As String)
            Dim Salto As String = Microsoft.VisualBasic.vbCrLf
            Dim JsCadena As String ' "function CerrarVentana()" + Salto + "{window.close();}"
            'HelperWeb.RegistrarJavaScriptEnHead(Me, "JsCerraVentana", JsCadena)
            Dim nombreMetodoJavaScript As String = nombreMetodoAjax.ToString().Trim() '"cargarCombo_" + idComboFormulario.ToString()
            JsCadena = ""
            JsCadena += "function " + nombreMetodoJavaScript + "()" + Salto
            JsCadena += "{" + Salto
            JsCadena += nombrePagina.Trim() + "." + nombreMetodoAjax.ToString().Trim() + "(" + nombreMetodoJavaScript + "_callback);" + Salto
            JsCadena += "}" + Salto
            JsCadena += "function " + nombreMetodoJavaScript + "_callback(res)" + Salto
            JsCadena += "{" + Salto
            JsCadena += " for( i=0; i<res.value.Rows.length; i++) " + Salto
            JsCadena += "    {" + Salto
            JsCadena += "    var oOption = document.createElement('OPTION');" + Salto
            JsCadena += "    document.forms[0].elements['" + idComboFormulario + "'].options.add(oOption); " + Salto
            JsCadena += "    oOption.value = res.value.Rows[i]." + nombreCampoValue.Trim() + ";" + Salto
            JsCadena += "    oOption.innerText = res.value.Rows[i]." + nombreCampoText.Trim() + ";" + Salto
            JsCadena += "    }" + Salto
            JsCadena += "}" + Salto
            HelperWeb.RegistrarJavaScriptEnHead(Pagina, "JsAjax", JsCadena)

        End Sub
#End Region

        Public Shared Function RutaActualClase(ByVal oPage As Page) As String
            Dim strFisica As String = oPage.Request.PhysicalPath
            Dim NombreClase As String = oPage.AppRelativeVirtualPath.Replace(oPage.AppRelativeTemplateSourceDirectory, "")
            strFisica = strFisica.Replace(NombreClase, "")
            Return strFisica
        End Function

        Public Shared Function AbrirVentanaWinPopup(ByVal pagina As String, ByVal ancho As Integer, ByVal alto As Integer, ByVal scrollBars As Boolean) As String
            Dim Cadena As String = "window.open('" + pagina + "','miwin','Width=" + ancho.ToString() + ",Height=" + alto.ToString() + ",scrollbars="
            If scrollBars = True Then
                Cadena += "yes"
            Else
                Cadena += "no"
            End If
            Cadena += ",screenX=50, screenY=50,top=80,left=90'); "
            Cadena = "var ventana = " + Cadena
            Cadena = Cadena + " ventana.opener=self;  ventana.focus(); return "
            Cadena += "false; "
            Return Cadena
        End Function

        Public Shared Sub ComboLlenarDatosSiNo(ByVal oCombo As DropDownList)
            Dim oItem As ListItem
            oItem = New ListItem("SI", "1")
            oCombo.Items.Add(oItem)
            oItem = New ListItem("NO", "0")
            oCombo.Items.Add(oItem)
        End Sub

        Public Shared Sub CalendarioEstablecerFechaSistema(ByVal ControlCalendario As customCalendar.webCalendar, ByVal MostrarFechaSistema As Boolean)
            If MostrarFechaSistema = True Then
                Dim d As Integer = DateTime.Now.Day
                Dim m As Integer = DateTime.Now.Month
                Dim y As Integer = DateTime.Now.Year
                ControlCalendario.Fecha = d.ToString("00") + ConstantesWeb.SEPARADORFECHA + m.ToString("00") + ConstantesWeb.SEPARADORFECHA + y.ToString()
            End If
        End Sub

        Public Shared Sub LLenarListaTipoBusqueda(ByVal oRadioButtonList As RadioButtonList)
            Dim oItem As ListItem
            oItem = New ListItem("Listar", "1")
            oRadioButtonList.Items.Add(oItem)
            oItem = New ListItem("Buscar un Registro", "2")
            oRadioButtonList.Items.Add(oItem)
            oRadioButtonList.Items(0).Selected = True
        End Sub

        Public Shared Sub LLenarListaTipoSeguimiento(ByVal oRadioButtonList As RadioButtonList)
            Dim oItem As ListItem
            oItem = New ListItem("Todos", "1")
            oRadioButtonList.Items.Add(oItem)

            oItem = New ListItem("Sin Seguimiento", "2")
            oRadioButtonList.Items.Add(oItem)

            oItem = New ListItem("Con Seguimiento", "3")
            oRadioButtonList.Items.Add(oItem)
        End Sub

        Public Shared Sub LLenarListaPedidosEmitibles(ByVal oRadioButtonList As RadioButtonList)
            Dim oItem As ListItem
            oItem = New ListItem("Todos", "1")
            oRadioButtonList.Items.Add(oItem)
            oItem = New ListItem("Emitibles", "2")
            oRadioButtonList.Items.Add(oItem)
            oItem = New ListItem("No Emitibles", "3")
            oRadioButtonList.Items.Add(oItem)
        End Sub

        Public Shared Sub LlenarComboRegistroTablaTablas(ByVal piIdCabecera As Integer, ByVal poControlLista As ListControl)
            LlenarComboRegistroTablaTablas(piIdCabecera, Col_TABLA_TABLAS.tablc_vDescripcion.ToString(), poControlLista)
        End Sub

        Public Shared Sub LlenarComboRegistroTablaTablas(ByVal piIdCabecera As Integer, ByVal peTextoAgregar As Enumeradores.TextoMostrarCombo, ByVal poControlLista As ListControl)
            LlenarComboRegistroTablaTablas(piIdCabecera, Col_TABLA_TABLAS.tablc_vDescripcion.ToString(), peTextoAgregar, poControlLista)
        End Sub

        Public Shared Sub LlenarComboRegistroTablaTablas(ByVal piIdCabecera As Integer, ByVal pstrCampoMostrar As String, ByVal poControlLista As ListControl)
            LlenarComboRegistroTablaTablas(piIdCabecera, pstrCampoMostrar, TextoMostrarCombo.Ninguno, poControlLista)
        End Sub

        Public Shared Sub LlenarComboRegistroTablaTablas(ByVal piIdCabecera As Integer, ByVal pstrCampoMostrar As String, ByVal peTextoAgregar As Enumeradores.TextoMostrarCombo, ByVal poControlLista As ListControl)
            poControlLista.Items.Clear()
            Dim oTablaTablasBL As New pdt_tabla_tablasBL()
            Dim strNombreFuncion As String
            Dim dt As DataTable = oTablaTablasBL.Listar_PorCabecera(piIdCabecera)
            If Not dt Is Nothing Then
                poControlLista.DataTextField = pstrCampoMostrar
                poControlLista.DataValueField = Enumeradores.Col_TABLA_TABLAS.tablc_iCodigo.ToString()
                poControlLista.DataSource = dt
            End If
            poControlLista.DataBind()
            If peTextoAgregar <> TextoMostrarCombo.Ninguno Then
                Dim oTipo As Type
                Dim oArray As Object() = {poControlLista}
                oTipo = GetType(HelperWeb)
                strNombreFuncion = "ComboAddItem" & peTextoAgregar.ToString()
                oTipo.InvokeMember(strNombreFuncion, Reflection.BindingFlags.InvokeMethod, Nothing, Nothing, oArray)
            End If
            oTablaTablasBL = Nothing
        End Sub

        Public Shared Sub LlenarCombo(ByVal dt As DataTable, ByVal pstrCampoValor As String, ByVal pstrCampoMostrar As String, ByVal peTextoAgregar As Enumeradores.TextoMostrarCombo, ByVal pddlCombo As DropDownList)
            Dim strNombreFuncion As String
            pddlCombo.Items.Clear()
            If Not dt Is Nothing Then
                pddlCombo.DataTextField = pstrCampoMostrar
                pddlCombo.DataValueField = pstrCampoValor
                pddlCombo.DataSource = dt
            End If
            pddlCombo.DataBind()
            If peTextoAgregar <> TextoMostrarCombo.Ninguno Then
                Dim oTipo As Type
                Dim oArray As Object() = {pddlCombo}
                oTipo = GetType(HelperWeb)
                strNombreFuncion = "ComboAddItem" & peTextoAgregar.ToString()
                oTipo.InvokeMember(strNombreFuncion, Reflection.BindingFlags.InvokeMethod, Nothing, Nothing, oArray)
            End If
        End Sub

        Public Shared Function JsAbrirReporteFrameWeb(ByVal UrlPagina As String, ByVal widthRpt As String, ByVal heightRpt As String) As String
            Return "<iframe src='" + UrlPagina + "' width=" + widthRpt + " height=" + heightRpt + " scrolling='no' frameborder='no' style='width:" + widthRpt + " height:" + heightRpt + "'></iframe> <inoframes > </inoframes>"
        End Function

#Region "Variables de Inicio de Session - SEGURIDAD"
        Public Shared Function CuIdUsuarioInicioSession() As Integer
            Dim oWebPaginaBase As New WebPaginaBase
            Dim IdUsuario As Integer = oWebPaginaBase.PAG_IdUsuario_InicioSesion
            Return IdUsuario

        End Function

#End Region

    End Class

    Public Class UICryptography
        Private Const gs_CLAVE_ENCRYPT As String = "$PdT2008TdP$"

#Region "Enumeraciones"
        Public Enum eSymmProv As Short
            DES = 1
            RC2 = 2
            Rijndael = 3
            TripleDES = 4
        End Enum
#End Region

#Region "Variables"
        Private oCryptoService As SymmetricAlgorithm
#End Region

#Region "Constructores"
        '// Constructor for using an instrinsic .Net SymmetricAlgorithm class
        Public Sub New(ByVal AlgorithmSelected As eSymmProv)
            Select Case AlgorithmSelected
                Case eSymmProv.DES
                    oCryptoService = New DESCryptoServiceProvider
                Case eSymmProv.RC2
                    oCryptoService = New RC2CryptoServiceProvider
                Case eSymmProv.Rijndael
                    oCryptoService = New RijndaelManaged
                Case eSymmProv.TripleDES
                    oCryptoService = New TripleDESCryptoServiceProvider
            End Select
        End Sub

        '// Construct for using a customized SymmetricAlgorithm class
        Public Sub New(ByVal ServiceProvider As SymmetricAlgorithm)
            oCryptoService = ServiceProvider
        End Sub

#End Region

#Region "Metodos"

        Public Function EncriptarCadena(ByVal pisCadena As String) As String
            Dim oCrypto As New UICryptography(UICryptography.eSymmProv.TripleDES)

            Return oCrypto.Encrypting(pisCadena, gs_CLAVE_ENCRYPT)
        End Function

        Private Function GetLegalKey(ByVal strKey As String) As Byte()
            oCryptoService.GenerateKey()
            Dim sTemp As String = strKey
            Dim bytTemp() As Byte = oCryptoService.Key
            Dim keyLength As Int32 = bytTemp.Length
            If sTemp.Length > keyLength Then
                sTemp = sTemp.Substring(0, keyLength)
            ElseIf sTemp.Length < keyLength Then
                sTemp = sTemp.PadRight(keyLength, Chr(32))
            End If
            GetLegalKey = ASCIIEncoding.ASCII.GetBytes(sTemp)
        End Function

        Private Function GetLegalIV(ByVal strKey As String) As Byte()
            oCryptoService.GenerateIV()
            Dim sTemp As String = strKey
            Dim bytTemp() As Byte = oCryptoService.IV
            Dim IVLength As Int32 = bytTemp.Length
            If sTemp.Length > IVLength Then
                sTemp = sTemp.Substring(0, IVLength)
            ElseIf sTemp.Length < IVLength Then
                sTemp = sTemp.PadRight(IVLength, Chr(32))
            End If
            GetLegalIV = ASCIIEncoding.ASCII.GetBytes(sTemp)
        End Function

        Public Function Encrypting(ByVal source As String, ByVal strKey As String) As String
            Dim bytIn As Byte() = UTF8Encoding.UTF8.GetBytes(source)
            '// create a MemoryStream so that the process can be without I/O files
            Dim ms As System.IO.MemoryStream = New System.IO.MemoryStream
            '// set the private key
            oCryptoService.Key = GetLegalKey(strKey)
            oCryptoService.IV = GetLegalIV(strKey)
            '// create an Encryptor from the Provider Service instance
            Dim encrypto As ICryptoTransform = oCryptoService.CreateEncryptor
            '// create a Crypto Stream that transforms a stream using the encryption
            Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Write)
            '// write out encrypted content into MemoryStream
            cs.Write(bytIn, 0, bytIn.Length)
            cs.FlushFinalBlock()
            ms.Close()
            '// get the ouput and trim the '\0' bytes
            Dim bytOut As Byte() = ms.ToArray
            '// convert into Base64 so that result can be used in xml
            Return System.Convert.ToBase64String(bytOut)
        End Function

        Public Function Desencrypting(ByVal source As String, ByVal strKey As String) As String
            '// convert from Base64 to binary
            Dim bytIn As Byte() = System.Convert.FromBase64String(source)
            '// create a MemoryStream with the input
            Dim ms As MemoryStream = New MemoryStream(bytIn, 0, bytIn.Length)
            '// set the private key
            oCryptoService.Key = GetLegalKey(strKey)
            oCryptoService.IV = GetLegalIV(strKey)
            '// create a Decryptor from the Provider Service instance
            Dim encrypto As ICryptoTransform = oCryptoService.CreateDecryptor()
            '// create a Crypto Stream that transforms a stream using the decryption
            Dim cs As CryptoStream = New CryptoStream(ms, encrypto, CryptoStreamMode.Read)
            '// read out the result from the Crypto Stream
            Dim sr As StreamReader = New StreamReader(cs)
            Return sr.ReadToEnd
        End Function
#End Region


    End Class


End Namespace
