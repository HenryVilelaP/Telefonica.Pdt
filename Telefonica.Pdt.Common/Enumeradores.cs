using System;

namespace Telefonica.Pdt.Common
{
    /// <summary>
    /// Summary description for Enumeradores.
    /// </summary>
    public class Enumeradores
    {
        public Enumeradores()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "Columnas Tablas Modelo 2005"
        public enum col_PDTT_CUPO
        {
            cupoc_iIdCupo,
            cupoc_iCanti_Cupo_Asignada,
            cupoc_iCanti_Cupo_Disponible,
            vfhoc_iIdFranja_Horaria,
            grpic_iIdGrp_Instalacion,
            cupoc_iInd_Cierre_Cupo,
            cupoc_iEstado_Registro,
            cupoc_dFecha_Registro,
            cupoc_iIdUsuario_Registro,
            cupoc_dFec_Modifica,
            cupoc_iIdUsuario_Modifica,
            provc_iIdProveedor,
            fechc_iIdFecha,
        }
        public enum col_PDTT_PEDIDO_PRD
        {
            pdppc_iIdPedido_Prd,
            pdtic_iIdPedido,
            vetdc_iIdEstado_Pedido,
            pdtic_iCantidad_Prd,
            prsec_iIdPrd_Servicio,
            pdtic_nCod_Pedido_Legacie,
            psspc_iNum_Sub_Prd,
            vpaqc_iIdPaquete,
            vtctc_iIdTiempo_Contrato,
            vmrpc_iIdMotivo_Rechazo_Pdti,
            tococ_iIdTip_Ope_Com,
            vfadc_iIdForma_Adquisicion,
            pdppc_iIdRequiere_Llamada_Calidad,
            pdppc_iInd_Marca_Critico,
            pdtic_dFec_Marca_Critico,
            pdtic_iIdUsuario_Marca_Critico,
            pdtic_vObservacion_Usuario_Marca_Critico,
            pdppc_iEstado_Registro,
            pdppc_dFec_Registro,
            pdppc_iIdUsuario_Registro,
            pdppc_dFecha_Modifica,
            pdppc_iIdUsuario_Modifica,
            cupoc_iIdCupo,
        }

        public enum col_PDTT_GRP_INSTALACION
        {

            grpic_iIdGrp_Instalacion,
            grpic_vDescripcion,
            zgrpc_iIdZona_Grp_Instalacion,
            grpic_iEstado_Registro,
            grpic_dFec_Registro,
            grpic_iIdUsuario_Registro,
            grpic_dFec_Modifica,
            grpic_iIdUsuario_Modifica,
        }

        public enum col_PDTT_PROVEEDOR
        {
            provc_iIdProveedor,
            provc_vRazon_Social,
            provc_vRUC,
            provc_vNombreRepresentante,
            provc_vCorreo_Representante,
            provc_vDireccion,
            provc_vTelefono1,
            provc_vTelefono2,
            provc_vTelefono3,
            provc_vFax1,
            provc_vFax2,
            provc_observacion,
            provc_iEstado_Registro,
            provc_dFec_Registro,
            provc_iIdUsuario_Registro,
            provc_dFec_Modifica,
            provc_iUsuario_Modifica,

        }

        public enum Col_PDTT_TIP_OPE_COM
        {
            tococ_iIdTip_Ope_Com,
            vgtoc_iIdGrp_Tip_Ope_Com,
            tococ_vDescripcion,
            vgdoc_iIdGrp_Tip_Doc,
            tococ_iEstado_Registro,
            tococ_dFec_Registro,
            tococ_iIdUsuario_Registro,
            tococ_dFec_Modifica,
            tococ_iIdUsuario_Modifica,
            tococ_iInd_Hacer_Seguimiento
        }

        public enum Col_SEGMENTO
        {
            segmc_iIdSegmento,
            segmc_vDescripcion,
            vsisc_iIdSistema,
            segmc_iEstado_Registro,
            segmc_dFec_Registro,
            segmc_iIdUsuario_Registro,
            segmc_dFec_Modifica,
            segmc_iIdUsuario_Modifica

        }


        public enum Col_SEGMENTO_SUB_SEGMENTO
        {
            segmc_iIdSegmento,
            sessc_iNum_Sub_Segmento,
            sessc_vDescripcion,
            sessc_iEstado_Registro,
            sessc_dFec_Registro,
            sessc_iIdUsuario_Registro,
            sessc_iIdUsuario_Modifica,
            sessc_dFec_Modifica
        }

        public enum Col_PRD_SERVICIO
        {
            prsec_iIdPrd_Servicio,
            prsec_vDescripcion,
            num_Sla,
            vsisc_iIdSistema,
            vgprc_iIdGrp_Prd,
            prsec_iIdMostrar_Registro,
            prsec_iEstado_Registro,
            prsec_dFec_Registro,
            prsec_iIdUsuario_Registro,
            prsec_dFec_Modifica,
            prsec_iIdUsuario_Modifica
        }

        public enum Col_PAQUETE
        {
            paqtc_iIdPaquete,
            paqtc_vDescripcion,
            vfamc_iIdFamilia_Paquete,
            paqtc_vDescripcion_Detalle,
            paqtc_vDuo_Trio_Tipo_Speedy,
            paqtc_vDuo_Trio_Tipo_Linea,
            paqtc_vDuo_Trio_Tipo_Cable,
            paqtc_vDuo_Trio_Tipo_Pdti,
            paqtc_nDuo_Trio_Descuento,
            paqtc_nRenta_Linea,
            paqtc_nRenta_Speedy,
            paqtc_nRenta_Cable,
            paqtc_nRenta_Pdti,
            paqtc_iInd_Activo,
            paqtc_nOrden_Oferta,
            paqtc_iEstado_Registro,
            paqtc_dFec_Registro,
            paqtc_iUsuario_Registro,
            paqtc_dFec_Modifica,
            paqtc_iIdUsuario_Modifica
        }

        public enum Col_TABLA_TABLAS
        {
            tablc_iIdTabla_Tablas,
            tablc_iCodigo,
            tablc_vDescripcion,
            tablc_vDescripcion_Detalle,
            tablc_vAbreviatura1,
            tablc_vAbreviatura2,
            tablc_nValor1,
            tablc_nValor2,
            tablc_iOrden,
            tablc_iEditable,
            tablc_iEstado
        }

        public enum Col_SG_USUARIO
        {
            usuac_iId_Usuario,
            usuac_vApellido_Paterno,
            usuac_vApellido_Materno,
            usuac_vNombre,
            usuac_vLogin,
            usuac_vPassword,
            vtdoc_iIdTip_Doc,
            usuac_vNum_Doc,
            usuac_iNum_Intento_Accesos,
            turnc_iIdTurno,
            usuac_iIdEstado_Usuario,
            usuac_iIdEstado_Bloqueado,
            usuac_vIp_Estacion,
            usuac_dFec_Ultimo_Acceso,
            usuac_dFec_Ultimo_Acceso_Fallido,
            usuac_vCorreo,
            usuac_iEstado_Registro,
            usuac_iIdUsuario_Registro,
            usuac_dFec_Registro,
            usuac_iIdUsuario_Modifica,
            usuac_dFec_Modifica,
            perfc_iIdPerfil
        }

        public enum Col_SG_ACCION
        {
            accic_iIdAccion,
            accic_vDescripcion,
            accic_vNombre_Accion,
            accic_iEstado_Registro,
            accic_iUsuario_Registro,
            accic_dFec_Registro,
            accic_iUsuario_Modifica,
            accic_dFec_Modifica
        }

        public enum Col_SG_TURNO
        {
            turnc_iIdTurno,
            turnc_vDescripcion_Turno,
            turnc_dHora_Ingreso_Lunes,
            turnc_dHora_Salida_Lunes,
            turnc_dHora_Ingreso_Martes,
            turnc_dHora_Salida_Martes,
            turnc_dHora_Ingreso_Miercoles,
            turnc_dHora_Salida_Miercoles,
            turnc_dHora_Ingreso_Jueves,
            turnc_dHora_Salida_Jueves,
            turnc_dHora_Ingreso_Viernes,
            turnc_dHora_Salida_Viernes,
            turnc_dHora_Ingreso_Sabado,
            turnc_dHora_Salida_Sabado,
            turnc_dHora_Ingreso_Domingo,
            turnc_dHora_Salida_Domingo,
            turnc_iInd_Estado_Turno,
            turnc_iEstado_Registro,
            turnc_iIdUsuario_Registro,
            turnc_dFec_Registro,
            turnc_iIdUsuario_Modifica,
            turnc_dFec_Modifica
        }

        public enum Col_SG_PERFIL
        {
            perfc_iIdPerfil,
            perfc_vDescripcion,
            perfc_vNemotecnico,
            perfc_iEstado_Registro,
            perfc_iIdUsuario_Registro,
            perfc_dFec_Registro,
            perfc_iIdUsuario_Modifica,
            perfc_dFec_Modifica
        }

        public enum Col_SG_OPCION
        {
            opcic_iIdOpcion,
            opcic_vEtiqueta,
            opcic_vNombre_Pagina,
            opcic_vRuta_Url_Pagina,
            opcic_iId_Opcion_Padre,
            opcic_iNum_Orden,
            opcic_iInd_Opcion_Critica,
            opcic_iEstado_Registro,
            opcic_iIdUsuario_Registro,
            opcic_dFec_Registro,
            opcic_iIdUsuario_Modifica,
            opcic_dFec_Modifica,
            vtopc_iIdTip_Opcion,
            opcic_vDescripcion,
            Opcic_vRuta_Url_Pagina,
            Opcic_iId_Opcion_Padre,
            Opcic_iNum_Orden,
            Opcic_iInd_Opcion_Critica,
            Vtopc_iIdTip_Opcion
        }

        public enum Col_SG_TIP_OPCION
        {
            vtopc_iIdTip_Opcion,
            vDescripcion
        }

        public enum Col_SG_OPCION_ACCION
        {
            opcic_iIdOpcion,
            accic_iIdAccion,
            oaccc_iEstado_Registro,
            oaccc_iIdUsuario_Registro,
            oaccc_dFecha_Registro,
            oaccc_iIdUsuario_Modifica,
            oaccc_dFecha_Modifica
        }

        public enum Col_SG_OPCION_PERFIL
        {
            opcic_iIdOpcion,
            perfc_iIdPerfil,
            acpac_iEstado_Registro,
            acpac_iIdUsuario_Registro,
            acpac_dFec_Registro,
            acpac_iIdUsuario_Modifica,
            acpac_dFecha_Modifica
        }

        public enum col_SG_OPCION_PERFIL_ACCION
        {
            opcic_iIdOpcion,
            accic_iIdAccion,
            perfc_iIdPerfil,
            ppacc_iEstado_Registro,
            ppacc_iIdUsuario_Registro,
            ppacc_dFecha_Registro,
            ppacc_iIdUsuario_Modifica,
            ppacc_dFecha_Modifica
        }

        public enum col_SG_HISTORIA_CAMBIO_PASSWORD
        {
            hcapc_iIdHistoria_Cambio_Password,
            usuac_iId_Usuario,
            hcapc_vPassword,
            hcapc_iEstado_Registro,
            hcapc_iIdUsuario_Registro,
            hcapc_dFec_Registro
        }

        public enum Col_PEDIDO_PRD_DOC
        {
            ppdoc_iIdPedido_Doc,
            vtdoc_iIdTip_Doc,
            ppdoc_iInd_Doc_Publicado,
            ppdoc_iIdUsuario_Publica,
            pptdc_dFec_Publicacion,
            ppdoc_iIdUsuario_Aprueba,
            pptdc_dFec_Aprobacion,
            vedoc_iIdEstado_Doc,
            pdppc_iIdPedido_Prd,
            pptdc_vNombre_Doc_Digital,
            pptdc_iEstado_Registro,
            pptdc_dFec_Registro,
            pptdc_iIdUsuario_Registro,
            pptdc_dFec_Modifica,
            pptdc_iIdUsuario_Modifica,
        }

        public enum Col_TR_ISIS
        {
            codreg,
            FechaEmision,
            HoraEmision,
            servicio,
            codcliente,
            Nombrecliente,
            NombreSituacion,
            segmento,
            SubSegmento,
            circuito,
            CodAccion1,
            Accion1,
            Fechapedido,
            NroPedido,
            CodAccion2,
            Accion2,
            Prereg,
            EjecutivoServicio,
            EjecutivoAtencion,
            PreDoc,
            NoDoc,
            FecRegistro,
            FecDoc,
            PendLiq,
            Marca,
            UltimaSecEst
        }

        public enum Col_TR_GESTEL
        {
            zonal,
            ciudad,
            pedido,
            Inscripcion,
            telefono,
            servicio,
            movimiento,
            fecRegistro,
            Cod_negocio,
            estado,
            prom_mig,
            prom_act,
            ooss,
            fec_planta_interna,
            planta_interna,
            estado_planta_interna,
            urd_planta_interna,
            fec_planta_externa,
            planta_externa,
            estado_planta_externa,
            urd_planta_externa,
            fec_mdf,
            mdf,
            estado_mdf,
            urd_mdf,
            fec_red_inteligente,
            red_inteligente,
            Estado_Red_Inteligente,
            urd_red_inteligente,
            cod_observacion,
            Col031,
            observacion,
            dice_tecnico,
            usuario_reg,
            cod_clasificacion,
            cod_tecnologia,
            tecnologia,
            segmento,
            segmento_emp,
            medio_util,
            cod_circuito,
            Col042,
            speedy_tipo,
            Speedy_Velocidad,
            Speedy_Equipo,
            Ruta_Cobro,
            Cod_Central,
            Col048,
            Desc_Segmento,
            Cliente,
            Cuc,
            tipo_operacion_comercial,
            modalidad,
            producto,
            cod_registro_manual,
            subsegmento,
            Cruce_segmento,
            id_tipo_Operacion_Comercial,
            id_producto,
            id_vendedor,
            id_segmento,
            Ind_ya_registrado,
            id_zonal,
        }

        public enum Col_TR_SPEEDYSIG
        {
            pedido,
            empresa,
            segmento,
            estado,
            telefono,
            inscripcion,
            Fecha_Registro,
            Fecha_liquidacion,
            fecha_Devolucion,
            Motivo_Devolucion,
            Fecha_Reprogramacion,
            Motivo_Reprogramacion,
            fecha_Cancelacion,
            Motivo_Cancelacion,
            Ciudad,
            Ciclo_Fact,
            Cod_Cliente,
            Cliente,
            Direccion,
            referencia,
            Cod_Facturacion,
            Persona_Contacto,
            Fono_Contacto,
            Cod_Vendedor,
            Vendedor,
            tipo_cliente,
            canal_de_venta,
            Pedido_Numerico,
            Q_pcs,
            Producto,
            Paquete,
            Cant,
            NroSerie,
            Peroodo,
            Estado1,
            Tipo_Cliente,
            Cpu,
            RAM,
            SistemaOperativo,
            Procesador
        }

        #region "Columna Tablas Cotización"

        public enum Col_COTIZACION
        {
            cotic_iIdCotizacion,
            cotic_iNum_Cotizacion,
            cotic_iNum_Cotizacion_Version,
            vtpec_iIdTip_Persona,
            vtidc_iIdTip_Doc_Identidad,
            cotic_vNum_Doc,
            cotic_vRazon_Social,
            cotic_vNombre_Cliente,
            cotic_vApellido_Parterno,
            cotic_vApellido_Materno,
            cotic_vTelefono_Referencia,
            cotic_vTelefono_Contacto,
            cotic_iCodigo_Carterizado,
            cotic_vNombre_Persona_Contacto,
            vcavc_iIdCanal_Venta,
            cotic_vCuc,
            cotic_iIdCliente_Atis,
            vviac_iIdTip_Via_Instalacion,
            cotic_vNombre_Via_Instalacion,
            cotic_iNum_Via_Instalacion,
            vdepc_vIdDepartamento_Instalacion,
            vproc_vIdProvincia_Instalacion,
            vdisc_vIdDistrito_Instalacion,
            vviac_iIdTip_Via_Facturacion,
            cotic_vNombre_Via_Facturacion,
            cotic_iNum_Via_Facturacion,
            vdepc_vIdDepartamento_Facturacion,
            vproc_vIdProvincia_Facturacion,
            vdisc_vIdDistrito_Facturacion,
            vtctc_iIdTiempo_Contrato,
            vtptc_iIdTip_Pdt,
            vnptc_iIdNivel_Pdt,
            cotic_dFec_Inicio_Contrato,
            cotic_dFec_Fin_Contrato,
            segmc_iIdSegmento,
            sessc_iNum_Sub_Segmento,
            vectc_iIdEstado_Cotizacion
        }

        public enum Col_COTIZACION_PRD
        {
            coprc_iIdCotizacion_Prd,
            cotic_iIdCotizacion,
            coprc_iCantidad_Prd,
            prsec_iIdPrd_Servicio,
            paqtc_iIdPaquete,
            tococ_iIdTip_Ope_Com,
            vfadc_iIdForma_Adquisicion,
            coprc_nPorc_Igv,
            coprc_nMonto_IGV,
            descc_iIdDescuento,
            coprc_nPorc_Descuento,
            coprc_nMonto_Descuento,
            coprc_nMonto_Total,
            coprc_nPrecio,
            vtctc_iIdTiempo_Contrato,
            coprc_iEstado_Registro,
            coprc_dFec_Registro,
            coprc_iIdUsuario_Registro,
            coprc_dFec_Modifica,
            coprc_iIdUsuario_Modifica            
        }

        public enum Col_COTIZACION_PRD_SPR
        {
            cospr_iIdCotizacion_Spr,
            coprc_iIdCotizacion_Prd,
            cotic_iIdCotizacion,
            prsec_iIdPrd_Servicio,
            psspc_iNum_Sub_Prd,
            cospc_vNumero_Telefono,
            cospc_vNumero_Inscripcion,
            cospc_nPrecio,
            cospc_nPorc_Descuento,
            cospc_nMonto_Descuento,
            cospc_nPorc_Igv,
            cospc_nMonto_IGV,
            cospc_nMonto_Total,
            cospc_iEstado_Registro,
            cospc_dFec_Registro,
            cospc_iIdUsuario_Registro,
            cospc_dFec_Modifica,
            cospc_iIdUsuario_Modifica
        }
        #endregion "Columnas Tablas Cotización"


        #region "Tabla Tablas"

        public enum Cabecera_Tabla_Tablas
        {
            Tab_Tablas = 0,
            Tab_Estado_Cotizacion = 1,
            Tab_Canales_Venta = 2,
            Tab_Estado_Documento = 3,
            Tab_Estado_Pedido = 4,
            Tab_Familia_Paquetes = 5,
            Tab_Forma_Adquisición = 6,
            Tab_Franja_Horaria = 7,
            Tab_Fuente_Pedido = 8,
            Tab_Grupo_Productos = 9,
            Tab_Grupo_Documentos = 10,
            Tab_Documento_Identidad_Personal = 11,
            Tab_Grupo_Operacion_Comercial = 12,
            Tab_Motivo_Rechazo_Pedido_Producto = 13,
            Tab_Sistema_Origen_Informacion = 14,
            Tab_Tiempo_Contrato = 15,
            Tab_Lista_Documentos = 16,
            Tab_Tipo_Pedido = 17,
            Tab_Tipo_Via = 18,
            Tab_Cliente_Carterizado = 19,
            Tab_Segmento = 20,
            Tab_Sub_Segmento = 21,
            Tab_Zonas = 22,
            Tab_Dia_Semana = 23,
            Tab_Meses_Año = 24,
            Tab_Tipo_Persona = 25,
            Tab_Valor_logico = 26,
            Tab_Destino = 27,
            Tab_Tratamiento = 28,
        }
        #endregion "Tabla Tablas"

        public enum Col_PRD_SERVICIO_SUB_PRD
        {
            prsec_iIdPrd_Servicio,
            psspc_iNum_Sub_Prd,
            pspsc_vDescripcion,
            pspsc_nMonto_Renta,
            pspsc_iEstado_Registro,
            pspsc_dFec_Registro,
            pspsc_iIdUsuario_Registro,
            pspsc_dFec_Modifica,
            pspsc_iIdUsuario_Modifica
        }

        public enum Col_PAQUETE_PRD_OPE_COM
        {
            paqtc_iIdPaquete,
            tococ_iIdTip_Ope_Com,
            prsec_iIdPrd_Servicio,
            ppocc_iNum_Item,
            ppocc_iInd_Obligatorio,
            ppocc_iEstado_Registro,
            ppocc_dFec_Registro,
            ppocc_iIdUsuario_Registro,
            ppocc_dFec_Modifica,
            ppocc_iIdUsuario_Modica
        }

        public enum TAB_Val_PedidoProductoEstadoDocumento
        {
            Pendiente = 1,
            Publicado = 2,
            Aprobado = 3,
            Rechazado = 4,

        }

        public enum TAB_Val_EstadoPedido
        {
            Insertado = 1,
            Recibido = 2,
            Rechazado = 3,
            Emitido = 4,
            Liquidado = 5,
            En_validacion_por_control = 6,
            Aprobado_por_control = 7,

        }



        

        #endregion "Columnas Tablas Modelo 2005"

        public enum TextoMostrarCombo
        {
            Ninguno = 0,
            Seleccionar = 1,
            Todos = 2,
            Libre = 3

        }

        public enum TipoPersona
        {
            Natural = 1,
            Juridica = 2
        }

        public enum ValorBooleano
        {
            No = 0,
            Si = 1
        }

        public enum EstadoRegistro
        {
            Ninguno = -1,
            Inactivo = 0,
            Activo = 1
        }

    }
}
