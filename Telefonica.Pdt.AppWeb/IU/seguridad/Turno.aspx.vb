Imports System.Data
Imports Telefonica.Pdt.Common
Imports Telefonica.Pdt.Business
Imports Telefonica.Pdt.Entities

Namespace Telefonica.Pdt.AppWeb

    Public Class Turno
        Inherits WebPaginaBase
        Implements IPaginaBase, IPaginaMantenimento

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

#Region "Constantes - Variables"

        Private Const GRILLAVACIA As String = "NO SE ENCONTRARON REGISTROS"
        Private Const ConstGrillaEventoModificar As String = "GrillaEventoModificar"
        Private Const ConstGrillaEventoEliminar As String = "GrillaEventoEliminar"
        Private Const ConstGrillaEventoMostrarDetalle As String = "GrillaEventoMostrarDetalle"
        Private Shared ModoPaginaProceso As String = ""

#End Region

#Region "IPaginaBase"

        Public Sub ConfigurarAccesoControles() Implements IPaginaBase.ConfigurarAccesoControles
            pnlFrmTurno.Visible = False
        End Sub

        Public Sub LlenarCombos() Implements IPaginaBase.LlenarCombos
            Me.LlenarComboHoras()
            Me.LlenarComboMinutos()
        End Sub

        Public Sub LlenarDatos() Implements IPaginaBase.LlenarDatos
            Me.hGrillaIndicePagina.Value = "0"
        End Sub

        Public Sub LlenarGrilla() Implements IPaginaBase.LlenarGrilla
            Me.ReiniciarControles()
            Me.LlenarGrillaPaginacion(Convert.ToInt32(Me.hGrillaIndicePagina.Value))
        End Sub

        Public Sub LlenarGrillaPaginacion(ByVal IndicePagina As Integer) Implements IPaginaBase.LlenarGrillaPaginacion

            Dim TotalRegistros As Integer = 0
            Dim dt As DataTable = Me.ListarDataLlenarGrilla(Me.grid.PageSize, IndicePagina, TotalRegistros)

            If Not (dt Is Nothing) Then
                Me.grid.DataSource = dt
                IndicePagina = HelperWeb.ValidarIndicePaginacionGrilla(TotalRegistros, Me.grid.PageSize, IndicePagina)
                Me.grid.PageIndex = IndicePagina
                Me.lblRegistrosEncontrados.Text = ConstantesWeb.TotalRegistrosEncontrados + dt.Rows.Count.ToString()
                Me.VisualizarControles(True)
            Else
                Me.grid.DataSource = Nothing
                Me.lblResultado.Text = GRILLAVACIA
                Me.VisualizarControles(False)
            End If

            Try
                Me.grid.DataBind()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Public Sub LlenarJScript() Implements IPaginaBase.LlenarJScript

        End Sub

        Public Sub RegistrarJScript() Implements IPaginaBase.RegistrarJScript
            NetAjax.StyleUpdateProgressPaginaCentral(Me.UpdateProgress1)
        End Sub

        Public Function ValidarFiltros() As Boolean Implements IPaginaBase.ValidarFiltros

        End Function

        Public Sub Nuevo()
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
            Me.chkInactivo.Checked = False
            'Horas Ingreso
            Me.cboHoraIngresoLunes.SelectedIndex = 0
            Me.cboHoraIngresoMartes.SelectedIndex = 0
            Me.cboHoraIngresoMiercoles.SelectedIndex = 0
            Me.cboHoraIngresoJueves.SelectedIndex = 0
            Me.cboHoraIngresoViernes.SelectedIndex = 0
            Me.cboHoraIngresoSabado.SelectedIndex = 0
            Me.cboHoraIngresoDomingo.SelectedIndex = 0
            'Horas Salida
            Me.cboHoraSalidaLunes.SelectedIndex = 0
            Me.cboHoraSalidaMartes.SelectedIndex = 0
            Me.cboHoraSalidaMiercoles.SelectedIndex = 0
            Me.cboHoraSalidaJueves.SelectedIndex = 0
            Me.cboHoraSalidaViernes.SelectedIndex = 0
            Me.cboHoraSalidaSabado.SelectedIndex = 0
            Me.cboHoraSalidaDomingo.SelectedIndex = 0
            'Minutos Ingreso
            Me.cboMinutosIngresoLunes.SelectedIndex = 0
            Me.cboMinutosIngresoMartes.SelectedIndex = 0
            Me.cboMinutosIngresoMiercoles.SelectedIndex = 0
            Me.cboMinutosIngresoJueves.SelectedIndex = 0
            Me.cboMinutosIngresoViernes.SelectedIndex = 0
            Me.cboMinutosIngresoSabado.SelectedIndex = 0
            Me.cboMinutosIngresoDomingo.SelectedIndex = 0
            'Minutos Salida
            Me.cboMinutosSalidaLunes.SelectedIndex = 0
            Me.cboMinutosSalidaMartes.SelectedIndex = 0
            Me.cboMinutosSalidaMiercoles.SelectedIndex = 0
            Me.cboMinutosSalidaJueves.SelectedIndex = 0
            Me.cboMinutosSalidaViernes.SelectedIndex = 0
            Me.cboMinutosSalidaSabado.SelectedIndex = 0
            Me.cboMinutosSalidaDomingo.SelectedIndex = 0
        End Sub

#End Region

#Region "IPaginaMantenimento"

        Public Sub Agregar() Implements IPaginaMantenimento.Agregar

            Dim lobjTurnoEnt As SG_TURNO
            Dim lobjTurnoBL As pdt_turnoBL

            lobjTurnoEnt = New SG_TURNO

            lobjTurnoEnt.Turnc_vDescripcion_Turno = Me.txtDescripcion.Text
            lobjTurnoEnt.Turnc_iInd_Estado_Turno = IIf(Me.chkInactivo.Checked, 1, 0)
            lobjTurnoEnt.Turnc_iIdUsuario_Registro = 1

            lobjTurnoEnt.Turnc_dHora_Ingreso_Lunes = FormarHora(cboHoraIngresoLunes, cboMinutosIngresoLunes)
            lobjTurnoEnt.Turnc_dHora_Salida_Lunes = FormarHora(cboHoraSalidaLunes, cboMinutosSalidaLunes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Martes = FormarHora(cboHoraIngresoMartes, cboMinutosIngresoMartes)
            lobjTurnoEnt.Turnc_dHora_Salida_Martes = FormarHora(cboHoraSalidaMartes, cboMinutosSalidaMartes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Miercoles = FormarHora(cboHoraIngresoMiercoles, cboMinutosIngresoMiercoles)
            lobjTurnoEnt.Turnc_dHora_Salida_Miercoles = FormarHora(cboHoraSalidaMiercoles, cboMinutosSalidaMiercoles)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Jueves = FormarHora(cboHoraIngresoJueves, cboMinutosIngresoJueves)
            lobjTurnoEnt.Turnc_dHora_Salida_Jueves = FormarHora(cboHoraSalidaJueves, cboMinutosSalidaJueves)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Viernes = FormarHora(cboHoraIngresoViernes, cboMinutosIngresoViernes)
            lobjTurnoEnt.Turnc_dHora_Salida_Viernes = FormarHora(cboHoraSalidaViernes, cboMinutosSalidaViernes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Sabado = FormarHora(cboHoraIngresoSabado, cboMinutosIngresoSabado)
            lobjTurnoEnt.Turnc_dHora_Salida_Sabado = FormarHora(cboHoraSalidaSabado, cboMinutosSalidaSabado)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Domingo = FormarHora(cboHoraIngresoDomingo, cboMinutosIngresoDomingo)
            lobjTurnoEnt.Turnc_dHora_Salida_Domingo = FormarHora(cboHoraSalidaDomingo, cboMinutosSalidaDomingo)

            lobjTurnoBL = New pdt_turnoBL

            Dim lintResult As Integer
            lintResult = lobjTurnoBL.Insertar(lobjTurnoEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos guardados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Sub CargarModoConsulta() Implements IPaginaMantenimento.CargarModoConsulta

        End Sub

        Public Sub CargarModoModificar() Implements IPaginaMantenimento.CargarModoModificar
            Me.lblAccion.Text = "MODIFICAR USUARIO"
            If (Me.LlenarDatoControlesDetalle() > 0) Then
                Me.btnGrabar.Enabled = True
            End If

        End Sub

        Public Sub CargarModoNuevo() Implements IPaginaMantenimento.CargarModoNuevo
            Me.lblAccion.Text = "NUEVO USUARIO"
            Me.btnGrabar.Enabled = True
        End Sub

        Public Sub CargarModoPagina() Implements IPaginaMantenimento.CargarModoPagina

            Dim strModoPagina As String = ModoPaginaProceso
            Select Case ModoPaginaProceso
                Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                    Me.CargarModoNuevo()
                Case ConstantesWeb.ModoPagina.Modificar.ToString()
                    Me.CargarModoModificar()
                Case ConstantesWeb.ModoPagina.Consultar.ToString()
                    Me.CargarModoConsulta()
            End Select
        End Sub

        Public Sub Eliminar() Implements IPaginaMantenimento.Eliminar

        End Sub

        Public Sub Modificar() Implements IPaginaMantenimento.Modificar

            Dim lobjTurnoEnt As SG_TURNO
            Dim lobjTurnoBL As pdt_turnoBL

            lobjTurnoEnt = New SG_TURNO

            lobjTurnoEnt.Turnc_iIdTurno = Me.hcodigo.Value
            lobjTurnoEnt.Turnc_vDescripcion_Turno = Me.txtDescripcion.Text
            lobjTurnoEnt.Turnc_iInd_Estado_Turno = IIf(Me.chkInactivo.Checked, 1, 0)
            lobjTurnoEnt.Turnc_iIdUsuario_Registro = 1

            lobjTurnoEnt.Turnc_dHora_Ingreso_Lunes = FormarHora(cboHoraIngresoLunes, cboMinutosIngresoLunes)
            lobjTurnoEnt.Turnc_dHora_Salida_Lunes = FormarHora(cboHoraSalidaLunes, cboMinutosSalidaLunes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Martes = FormarHora(cboHoraIngresoMartes, cboMinutosIngresoMartes)
            lobjTurnoEnt.Turnc_dHora_Salida_Martes = FormarHora(cboHoraSalidaMartes, cboMinutosSalidaMartes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Miercoles = FormarHora(cboHoraIngresoMiercoles, cboMinutosIngresoMiercoles)
            lobjTurnoEnt.Turnc_dHora_Salida_Miercoles = FormarHora(cboHoraSalidaMiercoles, cboMinutosSalidaMiercoles)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Jueves = FormarHora(cboHoraIngresoJueves, cboMinutosIngresoJueves)
            lobjTurnoEnt.Turnc_dHora_Salida_Jueves = FormarHora(cboHoraSalidaJueves, cboMinutosSalidaJueves)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Viernes = FormarHora(cboHoraIngresoViernes, cboMinutosIngresoViernes)
            lobjTurnoEnt.Turnc_dHora_Salida_Viernes = FormarHora(cboHoraSalidaViernes, cboMinutosSalidaViernes)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Sabado = FormarHora(cboHoraIngresoSabado, cboMinutosIngresoSabado)
            lobjTurnoEnt.Turnc_dHora_Salida_Sabado = FormarHora(cboHoraSalidaSabado, cboMinutosSalidaSabado)

            lobjTurnoEnt.Turnc_dHora_Ingreso_Domingo = FormarHora(cboHoraIngresoDomingo, cboMinutosIngresoDomingo)
            lobjTurnoEnt.Turnc_dHora_Salida_Domingo = FormarHora(cboHoraSalidaDomingo, cboMinutosSalidaDomingo)

            lobjTurnoBL = New pdt_turnoBL

            Dim lintResult As Integer
            lintResult = lobjTurnoBL.Modificar(lobjTurnoEnt)

            If lintResult > 0 Then
                NetAjax.JsMensajeAlert(Me.Page, "Datos actualizados correctamente.")
                Me.CargarSeccionGrilla()
                Me.UpdatePanelGrilla.Update()
            End If

        End Sub

        Public Function ValidarCampos() As Boolean Implements IPaginaMantenimento.ValidarCampos
            If (Me.txtDescripcion.Text.Trim().Length = 0) Then
                NetAjax.JsMensajeAlert(Me.Page, Me.rfvDescripcion.ErrorMessage)
                Return False
            End If
            Return True
        End Function

#End Region

#Region "Metodos Privados"

        Private Sub CargarSeccionFormularioDetalle()
            Me.LlenarJScriptSeccionDetalle()
            Me.LimpiarControlesDetalle() 'Limpia los controles de formulario
            Me.pnlFrmTurno.Visible = True

            Me.LlenarCombos()
            Me.CargarModoPagina()

        End Sub

        Public Sub LlenarJScriptSeccionDetalle()
            Me.rfvDescripcion.ErrorMessage = "Falta la descripcion del turno"
            Me.rfvDescripcion.ToolTip = Me.rfvDescripcion.ErrorMessage
        End Sub

        Public Sub LimpiarControlesDetalle()
            'Me.hcodigo.Value = ""
            Me.txtDescripcion.Text = ""
            'Horas Ingreso/Salida
            Me.cboHoraIngresoLunes.Items.Clear()
            Me.cboHoraSalidaLunes.Items.Clear()
            Me.cboHoraIngresoMartes.Items.Clear()
            Me.cboHoraSalidaMartes.Items.Clear()
            Me.cboHoraIngresoMiercoles.Items.Clear()
            Me.cboHoraSalidaMiercoles.Items.Clear()
            Me.cboHoraIngresoJueves.Items.Clear()
            Me.cboHoraSalidaJueves.Items.Clear()
            Me.cboHoraIngresoViernes.Items.Clear()
            Me.cboHoraSalidaViernes.Items.Clear()
            Me.cboHoraIngresoSabado.Items.Clear()
            Me.cboHoraSalidaSabado.Items.Clear()
            Me.cboHoraIngresoDomingo.Items.Clear()
            Me.cboHoraSalidaDomingo.Items.Clear()
            'Minutos Ingreso/Salida
            Me.cboMinutosIngresoLunes.Items.Clear()
            Me.cboMinutosSalidaLunes.Items.Clear()
            Me.cboMinutosIngresoMartes.Items.Clear()
            Me.cboMinutosSalidaMartes.Items.Clear()
            Me.cboMinutosIngresoMiercoles.Items.Clear()
            Me.cboMinutosSalidaMiercoles.Items.Clear()
            Me.cboMinutosIngresoJueves.Items.Clear()
            Me.cboMinutosSalidaJueves.Items.Clear()
            Me.cboMinutosIngresoViernes.Items.Clear()
            Me.cboMinutosSalidaViernes.Items.Clear()
            Me.cboMinutosIngresoSabado.Items.Clear()
            Me.cboMinutosSalidaSabado.Items.Clear()
            Me.cboMinutosIngresoDomingo.Items.Clear()
            Me.cboMinutosSalidaDomingo.Items.Clear()

            Me.chkInactivo.Checked = False
        End Sub

        Private Sub CargarSeccionGrilla()
            pnlFrmTurno.Visible = False
            lblAccion.Text = ""
            ModoPaginaProceso = ""
            Me.LlenarGrilla()
        End Sub

        Private Function FormarHora(ByVal ComboHora As DropDownList, ByVal ComboMinuto As DropDownList) As Nullable(Of DateTime)
            Dim ldFechaHoras As Nullable(Of DateTime) = Nothing
            If (ComboHora.SelectedValue <> ConstantesWeb.ValorSeleccionar) Then
                Dim lstrHora As String = Convert.ToInt32(ComboHora.SelectedValue).ToString("00")
                Dim lstrMinuto As String = Convert.ToInt32(ComboMinuto.SelectedValue).ToString("00")
                Dim lstrFechaHora As String = "1900/01/01 " + lstrHora + ":" + lstrMinuto + ":00"
                ldFechaHoras = HelperWeb.ConvertToDateTime(lstrFechaHora)
            End If

            Return ldFechaHoras

        End Function

        Private Sub LlenarComboHoras()
            Dim dt As DataTable
            dt = HelperWeb.HorasDataTable()

            'Ingreso Horas
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoLunes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoMartes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoMiercoles)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoJueves)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoViernes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoSabado)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraIngresoDomingo)

            'Salida Horas
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaLunes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaMartes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaMiercoles)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaJueves)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaViernes)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaSabado)
            HelperWeb.LlenarCombo(dt, "IdHora", "varHora", Enumeradores.TextoMostrarCombo.Seleccionar, cboHoraSalidaDomingo)

            dt = Nothing
        End Sub

        Private Sub LlenarComboMinutos()
            Dim dt As DataTable
            dt = HelperWeb.MinutosDataTable()

            'Ingreso Minutos
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoLunes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoMartes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoMiercoles)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoJueves)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoViernes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoSabado)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosIngresoDomingo)

            'Salida Minutos
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaLunes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaMartes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaMiercoles)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaJueves)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaViernes)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaSabado)
            HelperWeb.LlenarCombo(dt, "IdMinuto", "varMinutos", Enumeradores.TextoMostrarCombo.Ninguno, cboMinutosSalidaDomingo)

            dt = Nothing
        End Sub

        Public Sub VisualizarControles(ByVal blnEsVisible As Boolean)
            Me.lblResultado.Visible = Not blnEsVisible
            Me.lblRegistrosEncontrados.Visible = blnEsVisible
        End Sub

        Public Sub VisualizarControlesDetalle(ByVal blnEsVisible As Boolean)
            'Me.pnlAcciones.Visible = blnEsVisible
            'Me.pnlOpcionesCabecera.Visible = blnEsVisible
        End Sub

        Private Function ListarDataLlenarGrilla(ByVal NumeroRegistrosPagina As Integer, ByVal IndicePagina As Integer, ByRef TotalRegistros As Integer) As DataTable

            Dim oTurno As pdt_turnoBL
            Dim dt As DataTable

            oTurno = New pdt_turnoBL
            dt = oTurno.Listar()
            If dt Is Nothing Then
                TotalRegistros = 0
            Else
                TotalRegistros = dt.Rows.Count
            End If

            oTurno = Nothing

            Return dt

        End Function

        Private Sub ReiniciarControles()
            Me.VisualizarControles(False)
            Me.hcodigo.Value = ""
            Me.btnGrabar.Enabled = False
        End Sub

        Private Sub LimpiarControles()
            'Formulario de mantenimiento
            Me.txtId.Text = ""
            Me.txtDescripcion.Text = ""
            Me.chkInactivo.Checked = False
        End Sub

        Private Sub HacerControlComandoNetAjax()
            NetAjax.RegistroControlPostBackControlAsync(Me.ScriptManager1, Me.btnNuevo)
        End Sub

        Private Function LlenarDatoControlesDetalle() As Integer
            Dim IdTurno As Integer = Convert.ToInt32(Me.hcodigo.Value)
            Dim opdt_turnoBL As New pdt_turnoBL
            Dim oSG_TURNO As SG_TURNO = opdt_turnoBL.Detalle(IdTurno)

            If Not (oSG_TURNO Is Nothing) Then               
                Me.txtDescripcion.Text = oSG_TURNO.Turnc_vDescripcion_Turno

                'Hora/Minuto ingreso
                If (oSG_TURNO.Turnc_dHora_Ingreso_Lunes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Lunes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Lunes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoLunes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoLunes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Martes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Martes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Martes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoMartes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoMartes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Miercoles.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Miercoles.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Miercoles.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoMiercoles, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoMiercoles, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Jueves.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Jueves.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Jueves.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoJueves, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoJueves, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Viernes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Viernes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Viernes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoViernes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoViernes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Sabado.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Sabado.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Sabado.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoSabado, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoSabado, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Ingreso_Domingo.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Domingo.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Ingreso_Domingo.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraIngresoDomingo, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosIngresoDomingo, nMinutos.ToString())
                End If

                'Hora salida
                If (oSG_TURNO.Turnc_dHora_Salida_Lunes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Lunes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Lunes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaLunes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaLunes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Martes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Martes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Martes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaMartes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaMartes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Miercoles.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Miercoles.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Miercoles.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaMiercoles, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaMiercoles, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Jueves.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Jueves.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Jueves.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaJueves, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaJueves, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Viernes.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Viernes.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Viernes.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaViernes, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaViernes, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Sabado.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Sabado.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Sabado.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaSabado, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaSabado, nMinutos.ToString())
                End If
                If (oSG_TURNO.Turnc_dHora_Salida_Domingo.HasValue) Then
                    Dim nHoras As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Domingo.Value.ToString("HH"))
                    Dim nMinutos As Integer = Convert.ToInt32(oSG_TURNO.Turnc_dHora_Salida_Domingo.Value.ToString("mm"))

                    HelperWeb.ComboSeleccionarItem(Me.cboHoraSalidaDomingo, nHoras.ToString())
                    HelperWeb.ComboSeleccionarItem(Me.cboMinutosSalidaDomingo, nMinutos.ToString())
                End If

                If (oSG_TURNO.Turnc_iInd_Estado_Turno.HasValue) Then
                    Me.chkInactivo.Checked = IIf(oSG_TURNO.Turnc_iInd_Estado_Turno.Value = 0, False, True)
                End If

                Return 1
            End If

            Return 0

        End Function

#End Region

#Region "Metodos Formulario"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            Try
                Me.RegistrarJScript()
                Me.HacerControlComandoNetAjax()
                If (Not Me.IsPostBack) Then
                    Me.ConfigurarAccesoControles()
                    Me.LlenarJScript()
                    Me.LlenarDatos()
                    Me.LlenarGrilla()
                End If
            Catch ex As Exception
                Me.ltlMensaje.Text = HelperWeb.JsMensajeAlert(HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub btnNuevo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            Try
                ModoPaginaProceso = ConstantesWeb.ModoPagina.Nuevo.ToString()
                Me.CargarSeccionFormularioDetalle()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelDetalle.Update()
            End Try
        End Sub

        Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
            Try
                Me.CargarSeccionGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try
        End Sub

        Protected Sub btnGrabar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            Try
                If (Me.IsValid) AndAlso (Me.ValidarCampos()) Then
                    Dim strModoPagina As String = ModoPaginaProceso
                    Select Case ModoPaginaProceso
                        Case ConstantesWeb.ModoPagina.Nuevo.ToString()
                            Me.Agregar()
                        Case ConstantesWeb.ModoPagina.Modificar.ToString()
                            Me.Modificar()
                    End Select
                End If
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try
        End Sub

        Protected Sub grid_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
            Try
                Dim lstrCurrentCommand As String = e.CommandName()

                Dim lintIdUsuario As Integer = Convert.ToInt32(Me.hcodigo.Value)

                Select Case lstrCurrentCommand
                    Case ConstGrillaEventoModificar
                        ModoPaginaProceso = ConstantesWeb.ModoPagina.Modificar.ToString()
                        Me.CargarSeccionFormularioDetalle()
                        Me.UpdatePanelDetalle.Update()
                    Case ConstGrillaEventoEliminar

                    Case ConstGrillaEventoMostrarDetalle
                End Select
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            End Try

        End Sub

        Protected Sub grid_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
            If ((e.Row.RowType = ListItemType.AlternatingItem) OrElse (e.Row.RowType = ListItemType.Item)) Then

                Dim drw As DataRowView = CType(e.Row.DataItem, DataRowView)
                Dim dr As DataRow = drw.Row
                e.Row.Height = Unit.Pixel(20)

                e.Row.Cells(0).Text = HelperWeb.ObtenerIndiceRegistroGrilla(Me.grid, e)

                Dim IdRegistro As Integer = Convert.ToInt32(dr(Enumeradores.Col_SG_TURNO.turnc_iIdTurno.ToString()))

                Dim strJs As String = HelperWeb.AsignarDatoControlHtml(Me.hcodigo.Name, IdRegistro.ToString())
                HelperWeb.SeleccionarItemGrillaOnClickMoverRaton(e, strJs)

            End If
        End Sub

        Protected Sub grid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs)
            Try
                Me.hGrillaIndicePagina.Value = e.NewPageIndex.ToString()
                Me.LlenarGrilla()
            Catch ex As Exception
                NetAjax.JsMensajeAlert(Me.Page, HelperWeb.MensajeError(ex, "E00001"))
            Finally
                Me.UpdatePanelGrilla.Update()
            End Try

        End Sub

#End Region

    End Class

End Namespace
