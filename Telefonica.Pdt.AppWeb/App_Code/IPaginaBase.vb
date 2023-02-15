Namespace Telefonica.Pdt.AppWeb

Public Interface IPaginaBase

    '' <summary>
    '' Llena el grid
    '' </summary>
    Sub LlenarGrilla()

    '' <summary>
    '' Llena el grid,lo ordena por la columna indicada y va al indice de la pagina indicada
    '' </summary>
    '' <param name="columnaOrdenar">Columna por la que se quiere ordenar el grid</param>
    '' <param name="indicePagina">Indice de la pagina a seleccionar</param>
    Sub LlenarGrillaPaginacion(ByVal indicePagina As Integer)

    '' <summary>
    '' LLena los combos del formulario web
    '' </summary>
    Sub LlenarCombos()

    '' <summary>
    '' Llena los datos en el formulario web
    '' </summary>
    Sub LlenarDatos()

    '' <summary>
    '' Asigna javaScript a los controles del formulario web
    '' </summary>
    Sub LlenarJScript()

    '' <summary>
    '' Registra javaScript en el formulario web
    '' </summary>
    Sub RegistrarJScript()

    '' <summary>
    '' Configura las controles del formulario web en base a los privilegios del perfil
    '' </summary>
    Sub ConfigurarAccesoControles()

    '' <summary>
    '' Valida los filtros a emplear
    '' </summary>
    Function ValidarFiltros() As Boolean


End Interface

End Namespace
