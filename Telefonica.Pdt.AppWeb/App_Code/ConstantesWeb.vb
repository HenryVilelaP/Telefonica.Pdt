Imports System


Namespace Telefonica.Pdt.AppWeb

    Public NotInheritable Class ConstantesWeb
        Public Shared ReadOnly ESPACIO As String = " "
        Public Shared ReadOnly EspacioEnBlancoHTML As String = "&nbsp;"
        Public Shared ReadOnly EspacioEnBlancoVS As String = " "
        Public Shared ReadOnly JsEventoOnBlur As String = "OnBlur"
        Public Shared ReadOnly JsEventoOnChange As String = "OnChange"
        Public Shared ReadOnly JsEventoOnClick As String = "OnClick"
        Public Shared ReadOnly JsEventoOndblclick As String = "Ondblclick"
        Public Shared ReadOnly JsEventoOnFocus As String = "OnFocus"
        Public Shared ReadOnly JsEventoOnKeydown As String = "OnKeydown"
        Public Shared ReadOnly JsEventoOnKeypress As String = "OnKeypress"
        Public Shared ReadOnly JsEventoOnKeyup As String = "OnKeyup"
        Public Shared ReadOnly JsEventoOnMouseDown As String = "OnMouseDown"
        Public Shared ReadOnly JsEventoOnMousemove As String = "OnMousemove"
        Public Shared ReadOnly JsEventoOnMouseout As String = "OnMouseout"
        Public Shared ReadOnly JsEventoOnMouseover As String = "OnMouseover"
        Public Shared ReadOnly JsEventoOnSubmit As String = "OnSubmit"
        Public Shared ReadOnly KEYMODOPAGINA As String = "Modo"
        Public Shared ReadOnly LINEA As String = "-"
        Public Shared ReadOnly Palotes As String = "|"
        Public Shared ReadOnly SaltoLinea As String = System.Convert.ToChar(13) & System.Convert.ToChar(10)
        Public Shared ReadOnly SEPARADOR As String = " " & System.Convert.ToChar(166) & " "
        Public Shared ReadOnly SEPARADORFECHA As String = "/"
        Public Shared ReadOnly SignoABREPARANTESIS As String = "("
        Public Shared ReadOnly SignoAMPERSON As String = "&"
        Public Shared ReadOnly SignoCIERRAPARANTESIS As String = ")"
        Public Shared ReadOnly SignoCOMA As String = ","
        Public Shared ReadOnly SignoCOMILLADOBLE As String = """"
        Public Shared ReadOnly SignoCOMILLASIMPLE As String = "'"
        Public Shared ReadOnly SignoDIFERENTEQUE As String = "<>"
        Public Shared ReadOnly SignoIGUAL As String = "="
        Public Shared ReadOnly SignoINTERROGACION As String = "?"
        Public Shared ReadOnly SignoLINEAVERTICAL As String = "|"
        Public Shared ReadOnly SignoMAS As String = "+"
        Public Shared ReadOnly SignoMAYOR As String = ">"
        Public Shared ReadOnly SignoMAYORIGUAL As String = ">="
        Public Shared ReadOnly SignoMENOR As String = "<"
        Public Shared ReadOnly SignoMENORIGUAL As String = "<="
        Public Shared ReadOnly SignoPORCENTAJE As String = "%"
        Public Shared ReadOnly SignoPUNTOYCOMA As String = ";"
        Public Shared ReadOnly SignoX As String = "X"
        Public Shared ReadOnly SignoPUNTO As String = "."
        Public Shared ReadOnly Tabulacion As String = System.Convert.ToChar(9)
        Public Shared ReadOnly TEXTOTOTAL As String = "TOTAL"
        Public Shared ReadOnly TotalRegistrosEncontrados As String = "Total Registros Encontrados: "
        Public Shared ReadOnly VACIO As String = ""
        Public Shared ReadOnly VALORCERO As String = "0.00"
        Public Shared ReadOnly VALORMENOSUNO As Integer = -1
        Public Shared ReadOnly BotonPorDefectoPaginaWeb As String = "__EVENTTARGET"
        Public Shared ReadOnly TotalRegistrosCombo As String = "1000"

#Region "Contantes"
        Public Shared ReadOnly TextoSeleccionar As String = "-Seleccionar-"
        Public Shared ReadOnly TextoLibre As String = "<- LIBRES ->"
        Public Shared ReadOnly TextoTodos As String = "-Todos-"

        Public Shared ReadOnly ValorSeleccionar As String = "%%"
        Public Shared ReadOnly ValorLibre As String = "$%"
        Public Shared ReadOnly ValorTodos As String = "0"
        Public Shared ReadOnly ValorNinguno As String = "0%"

        Public Shared ReadOnly FormatoNumerico1 As String = "###,###,###,##0"
        Public Shared ReadOnly FormatoNumerico2 As String = "###,###,###,##0.0"
        Public Shared ReadOnly FormatoNumerico3 As String = "###,###,###,##0.00"

        Public Shared ReadOnly FormatoFecha1 As String = "dd/MM/yyyy"
        Public Shared ReadOnly FormatoFecha2 As String = "yyyy-MM-dd"
        Public Shared ReadOnly FORMATOHORA1 As String = "HH:mm:ss"

        Public Shared ReadOnly OrderCriterioASC As String = "ASC"
        Public Shared ReadOnly OrderCriterioDESC As String = "DESC"

        Public Shared ReadOnly ColorItemGrillaSelect As String = "#ffffcc"
        Public Shared ReadOnly ColorItemGrillaNoSelect As String = "#ffffff"

#End Region

        Public Shared ReadOnly RutaImagenVacio As String = "~/Images/Body/Icons/imgVacio.gif"
        Public Shared ReadOnly RutaImagenLleno As String = "~/Images/Body/Icons/imgLleno.gif"
        Public Shared ReadOnly RutaImagenMedio As String = "~/Images/Body/Icons/imgMedio.gif"
        Public Shared ReadOnly PassWordInicial As String = "12345"

        Public Shared ReadOnly SIMBOLOPUNTO As String = "."
        Public Shared ReadOnly SIGNOMICHI As String = "#"
        Public Shared ReadOnly VALORCONFIRMACIONREGISTRO As Integer = 1
        Public Shared ReadOnly FORMATODECIMAL2 As String = "##0.00"
        Public Shared ReadOnly FORMATODECIMAL3 As String = "##0.000"
        Public Shared ReadOnly FORMATODECIMAL4 As String = "#,###,###,##0.00"
        Public Shared ReadOnly FORMATODECIMAL5 As String = "# ### ### ### ##0"
        Public Shared ReadOnly FORMATODECIMAL6 As String = "# ### ### ##0.00"
        Public Shared ReadOnly FORMATOFECHA As String = "dddd MMM dd"
        Public Shared ReadOnly FORMATOFECHA3 As String = "dd-MM-yyyy"
        Public Shared ReadOnly FORMATOFECHA4 As String = "dd/MM/yyyy"
        Public Shared ReadOnly FORMATOFECHA5 As String = "dd/MM/yyyy HH:mm:ss"
        Public Shared ReadOnly FORMATOHORA As String = "HH:mm:ss"
        Public Shared ReadOnly FORMATOAÑO As String = "yyyy"
        Public Shared ReadOnly ValorConstanteMenosUno As Integer = -1 'Numero Cero
        Public Shared ReadOnly ValorConstanteCero As Integer = 0 'Numero Cero
        Public Shared ReadOnly ValorConstanteUno As Integer = 1 ' Numero Uno
        Public Shared ReadOnly ValorConstanteDos As Integer = 2 ' Numero Dos

        'Public Shared ReadOnly KEYMODOOPCION As String = "Opcion"
        'Public Shared ReadOnly KEYTIPOBUSQUEDAENTIDAD As String = "TipoBusqueda"
        'Public Shared ReadOnly RUTAUPLOAD As String = "RutaUpload"
        'Public Shared ReadOnly RUTAUPLOADSERVER As String = "RutaUploadServer"
        'Public Shared ReadOnly KEYEDITORNOMBREOBJDESCRIPCION As String = "EditObjDesc"

        Public Shared ReadOnly KeyWebCadenaConeccionBDSql As String = "CadenaConeccionBDSql"
        Public Shared ReadOnly EVENTOCLICK As String = "onclick"
        Public Shared ReadOnly EVENTODBLCLICK As String = "ondblclick"
        Public Shared ReadOnly EVENTOMOUSEDOWN As String = "onmousedown"
        Public Shared ReadOnly EVENTOONKEYDOWN As String = "onkeydown"
        Public Shared ReadOnly EVENTOONKEYUP As String = "onkeyup"
        Public Shared ReadOnly TIPOCURSORMANO As String = "'hand'"
        Public Shared ReadOnly EVENTOCLOSE As String = "window.close(); "

        Public Shared ReadOnly KEYQMENSAJEPAGINAERRROR As String = "MensajePaginaError"

        Public Shared ReadOnly URLPaginaEnConstruccion As String = "PaginaEnConstruccion.aspx"
        Public Shared ReadOnly URLPaginaDefault As String = "Default.aspx"
        Public Shared ReadOnly OrdenamientoSortASC As String = "ASC"
        Public Shared ReadOnly OrdenamientoSortDESC As String = "DESC"
        Public Shared ReadOnly KeyControlLiteralNombre As String = "ltlMensaje"

        Public Shared ReadOnly MensajeError As String = "MensajeError"

        Public Shared ReadOnly KEYSNOMBREARCHIVOEXPORTAR As String = "archivoExportar"

        Public Shared ReadOnly MensajeErrorException As String = "Se produjo un error en el servidor"

#Region "Constantes de Variables de Sesiones"
        Public Shared ReadOnly KEYSesionSORT As String = "SesionSort"
        Public Shared ReadOnly KEYSesionDIRECCIONSORT As String = "SessionDireccionSort"
        Public Shared ReadOnly KEYSesionSortAsc As String = "SesionASC"
        Public Shared ReadOnly KEYSesionSortDesc As String = "SesionDesc"
        Public Shared ReadOnly KeySesionGeneralCaptChaValorGenerado As String = "GeneralSeesionCaptChaValorGenerado"
        Public Shared ReadOnly KEYSesionHistorialWebUrlControlsForms As String = "HistorialWebUrlControlesFormulario"
        Public Shared ReadOnly KEYSesionHistorialWebControlsForms As String = "HistorialWebControlesFormulario"
        Public Shared ReadOnly KEYSesionHistorialWebUrlPaginaAnterior As String = "HistorialWebUrlPaginaAnterior"
#End Region

#Region "Constantes de Cultura"
        Public Shared ReadOnly CULTUREINFOEspanishPeru As String = "es-Pe"
        Public Shared ReadOnly CULTUREINFOFrenchFrance As String = "fr-FR"
#End Region

#Region "Configuracion"

        Public Enum ModoPagina
            Nuevo
            Modificar
            Consultar
        End Enum

        Public Enum EventosJavaScript
            OnClick
            OnMouseDown
            OnMouseout
            OnMouseover
            OnMousemove
            Ondblclick
            OnKeydown
            OnKeypress
            OnKeyup
            OnChange
            OnFocus
            OnBlur
            SinEvento
        End Enum

        Public Enum GENValorNumeros
            Cero = 0
            Uno = 1
            Dos = 2
            Tres = 3
            Cuatro = 4
            Cinco = 5
            Seis = 6
            Siete = 7
            Ocho = 8
            Nueve = 9
        End Enum

        Public Enum GENColumnasAuditoriaTablas
            intEstadoRegistro
            varUsuarioRegistro
            datFechaRegistro
            varUsuarioModifica
            datFechaModifica
        End Enum


        Public Enum GeneralValorTTablaGeneral
            TablasAplicacion = 0
            TablaEstados = 1
        End Enum

        Public Enum GeneralColumnasTDias
            IdDia
            NombreDia
        End Enum

        Public Enum GeneralColumnasTMeses
            idMes
            NombreMes
        End Enum

        Public Enum GeneralColumnasTAnos
            idAno
            NombreAno
        End Enum

        Public Enum ExportarFormato
            Excel
            Word
            PDF
        End Enum

        Public Enum GeneralColumnasTHoras
            IdHora
            varHora
        End Enum

        Public Enum GeneralColumnasTMinutos
            IdMinuto
            varMinutos
        End Enum

        Public Enum GeneralValorProceso
            Exito = 1
            Fracaso = 0
        End Enum


        Public Enum CCTCombo
            intCodigo
            varCodigo
            varDescripcion
            varNombre
        End Enum

        Public Enum GeneralValorTTablaGENTipoMoneda
            Soles = 1
            Dolares = 2
        End Enum

        Public Enum GeneralValorTTablaGENEstadoGeneralRegistro
            Activo = 1
            Eliminado = 2
        End Enum

#End Region

#Region "Mensajes"
        Public Shared ReadOnly MensajeConfirmacionRegistro = "Se registraron los datos satisfactoriamente."
        Public Shared ReadOnly MensajeConfirmacionModificacion = "Se modificaron los datos satisfactoriamente."
#End Region

        Public Shared ReadOnly ValorPaqueteComplejo As Int32 = 1
        Public Shared ReadOnly ValorCerrado As Int32 = 5
        Public Shared ReadOnly ValorAprobado As Int32 = 4
        Public Shared ReadOnly ValorAltaNueva As Int32 = 4

#Region "FileServer PDT GdC"
        Public Shared ReadOnly FileServerPDT_GdC As String = "FileServerPDT_GdC"
#End Region

    End Class

End Namespace
