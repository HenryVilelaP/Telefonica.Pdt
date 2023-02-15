using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_cotizacionBL
    {
        public DataTable ListarCotizacion(string pstrRUC, string pstrCodigoClienteAtis, string pstrNumeroCotizacion,
                                int pintEstadoCotizacion, string pstrNombreCliente,
                                DateTime? pdtFechaInicio, DateTime? pdtFechaFin)
        {
            DataTable dtCotizacion;

            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();
            dtCotizacion = objCotizacionDL.Listar(pstrRUC, pstrCodigoClienteAtis, pstrNumeroCotizacion,
                                                  pintEstadoCotizacion, pstrNombreCliente,
                                                  pdtFechaInicio, pdtFechaFin);
            return dtCotizacion;
        }

        public COTIZACION ObtenerCotizacion(int pintIdCotizacion)
        {
            COTIZACION objCotizacion;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();

            objCotizacion = objCotizacionDL.Obtener(pintIdCotizacion);
            return objCotizacion;
        }

        public int InsertarCotizacion(COTIZACION pobjCotizacion, 
                            List<COTIZACION_PRD> objListaProductos , 
                            List<COTIZACION_PRD_SPR> objListaSubProductos )
        {
            int intIdCotizacion;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();

            this.EstablecerDatosCotizacionMayusculas(pobjCotizacion);

            intIdCotizacion = objCotizacionDL.Insertar(pobjCotizacion);

            if (objListaProductos != null)
            {
                this.Insertar_PS(objListaProductos, objListaSubProductos, intIdCotizacion);
            }

            return intIdCotizacion;
        }

        private void EstablecerDatosCotizacionMayusculas(COTIZACION pobjCotizacion)
        {
            pobjCotizacion.Cotic_vRazon_Social = pobjCotizacion.Cotic_vRazon_Social.ToUpper();
            pobjCotizacion.Cotic_vNombre_Persona_Contacto = pobjCotizacion.Cotic_vNombre_Persona_Contacto.ToUpper();
            pobjCotizacion.Cotic_vNombre_Cliente = pobjCotizacion.Cotic_vNombre_Cliente.ToUpper();
            pobjCotizacion.Cotic_vApellido_Paterno = pobjCotizacion.Cotic_vApellido_Paterno.ToUpper();
            pobjCotizacion.Cotic_vApellido_Materno = pobjCotizacion.Cotic_vApellido_Materno.ToUpper();
            pobjCotizacion.Cotic_vNombre_Via_Instalacion = pobjCotizacion.Cotic_vNombre_Via_Instalacion.ToUpper();
            pobjCotizacion.Cotic_vNombre_Via_Facturacion = pobjCotizacion.Cotic_vNombre_Via_Facturacion.ToUpper();
        }

        public void Insertar_PS(List<COTIZACION_PRD> pobjListaProductos,
                                List<COTIZACION_PRD_SPR> pobjListaSubProductos,
                                int pIntIdCotizacion)
        {
            int intIdCotizacionPS;
            pdt_cotizacion_prdDL objCotizacionPSDL = new pdt_cotizacion_prdDL();

            foreach (COTIZACION_PRD objCotizacionPS in pobjListaProductos)
            {
                objCotizacionPS.Cotic_iIdCotizacion = pIntIdCotizacion;
                intIdCotizacionPS = 0;

                if (objCotizacionPS.Coprc_iIdCotizacion_Prd == 0)
                {
                    objCotizacionPS.Coprc_iEstado_Registro = 1;
                    intIdCotizacionPS = objCotizacionPSDL.Insertar(objCotizacionPS);
                    objCotizacionPS.Coprc_iIdCotizacion_Prd = intIdCotizacionPS;
                }
                else
                {
                    intIdCotizacionPS = objCotizacionPS.Coprc_iIdCotizacion_Prd;
                    objCotizacionPSDL.Modificar(objCotizacionPS);
                }

                if (pobjListaSubProductos != null)
                {
                    this.Insertar_SubPS(pobjListaSubProductos, pIntIdCotizacion, intIdCotizacionPS);
                }
            }
        }

        public void Insertar_SubPS(List<COTIZACION_PRD_SPR> pobjListaSubProductos, 
                                    int pIntIdCotizacion, 
                                    int pIntIdCotizacionPS)
        {
            int intIdCotizacionSubPS;
            string strExpresionConsulta = "";
            Boolean blnExisteBD = false;
            DataTable dt;

            pdt_cotizacion_prd_sprDL objCotizacionSubPSDL = new pdt_cotizacion_prd_sprDL();

            dt = objCotizacionSubPSDL.ListarPorCotizacion(pIntIdCotizacion, Common.Enumeradores.EstadoRegistro.Ninguno);

            foreach (COTIZACION_PRD_SPR objCotizacionSubPS in pobjListaSubProductos)
            {
                Boolean blnEsNuevo = true;
                
                intIdCotizacionSubPS = 0;
                objCotizacionSubPS.Cotic_iIdCotizacion = pIntIdCotizacion;
                objCotizacionSubPS.Coprc_iIdCotizacion_Prd = pIntIdCotizacionPS;

                strExpresionConsulta = "Cotic_iIdCotizacion = {0} And ";
                strExpresionConsulta += "Coprc_iIdCotizacion_Prd = {1} And ";
                strExpresionConsulta += "Prsec_iIdPrd_Servicio = {2} And ";
                strExpresionConsulta += "Psspc_iNum_Sub_Prd = {3}";

                strExpresionConsulta = string.Format(strExpresionConsulta,
                                                    pIntIdCotizacion,
                                                    pIntIdCotizacionPS,
                                                    objCotizacionSubPS.Prsec_iIdPrd_Servicio,
                                                    objCotizacionSubPS.Psspc_iNum_Sub_Prd);

                blnExisteBD = ((dt != null) && (dt.Select(strExpresionConsulta).Length>0));
                 
                blnEsNuevo = (objCotizacionSubPS.Cospr_iIdCotizacion_Spr == 0) && !blnExisteBD;

                if (blnEsNuevo)
                {
                    objCotizacionSubPS.Cospc_iEstado_Registro = 1;
                    intIdCotizacionSubPS = objCotizacionSubPSDL.Insertar(objCotizacionSubPS);
                    objCotizacionSubPS.Cospr_iIdCotizacion_Spr = intIdCotizacionSubPS;
                }
                else
                {
                    objCotizacionSubPSDL.Modificar(objCotizacionSubPS);
                }
                
            }

        }

        public int ModificarCotizacion(COTIZACION pobjCotizacion,
                                       List<COTIZACION_PRD> objListaProductos,
                                       List<COTIZACION_PRD_SPR> objListaSubProductos)
        {
            int intNumeroRegistrosAfectados;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();

            this.EstablecerDatosCotizacionMayusculas(pobjCotizacion);

            intNumeroRegistrosAfectados = objCotizacionDL.Modificar(pobjCotizacion);
                      
            this.EliminarProductoPorCotizacion(pobjCotizacion.Cotic_iIdCotizacion);

            if (objListaProductos != null)
            {
                this.Insertar_PS(objListaProductos, objListaSubProductos, pobjCotizacion.Cotic_iIdCotizacion);
            }

            return intNumeroRegistrosAfectados;
        }

        public COTIZACION ObtenerCotizacionPorDocumentoCliente(int pintTipoDocumento, string pstrNumeroDocumento)
        {
            COTIZACION objCotizacion;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();
            objCotizacion = objCotizacionDL.ObtenerPorDocumentoCliente(pintTipoDocumento, pstrNumeroDocumento);
            return objCotizacion;
        }

        public int InsertarNuevaVersion(int pintIdCotizacion, int pintIdUsuario)
        {
            int intNumeroRegistrosAfectados;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();
            intNumeroRegistrosAfectados = objCotizacionDL.InsertarNuevaVersion(pintIdCotizacion, pintIdUsuario);
            return intNumeroRegistrosAfectados;
        }

        public int CambiarEstadoCotizacion(int pintIdCotizacion, int pintIdEstadoCotizacion, int pintIdUsuario)
        {
            int intNumeroRegistrosAfectados = 0;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();
            intNumeroRegistrosAfectados = objCotizacionDL.CambiarEstado(pintIdCotizacion, pintIdEstadoCotizacion, pintIdUsuario);
            return intNumeroRegistrosAfectados;
        }

        public int AprobarCotizacion(int pintIdCotizacion, int pintIdUsuario)
        {
            int intNumeroRegistrosAfectados = 0;
            pdt_cotizacionDL objCotizacionDL = new pdt_cotizacionDL();

            CambiarEstadoCotizacion(pintIdCotizacion, 4, pintIdUsuario);

            intNumeroRegistrosAfectados = objCotizacionDL.Aprobar(pintIdCotizacion, pintIdUsuario);
            return intNumeroRegistrosAfectados;
        }

        public DataTable Listar_PSPorPaqueteOC(int pintIdPaquete, int pintOperacionComercial)
        {
            DataTable dt;

            pdt_prd_servicioDL objProductoServicioDL = new pdt_prd_servicioDL();
            dt = objProductoServicioDL.Listar_PSPorPaqueteOC(pintIdPaquete, pintOperacionComercial);
            return dt;
        }

        public DataTable Listar_SubProductoPorProducto(int pintProducto)
        {
            DataTable dt;

            pdt_prd_servicio_sub_prdDL objSubProductoDL = new pdt_prd_servicio_sub_prdDL();
            dt = objSubProductoDL.Listar_PorPS(pintProducto);
            return dt;
        }

        public PRD_SERVICIO_SUB_PRD ObtenerSubProducto(int pintIdProducto, int pintIdSubProducto)
        {
            PRD_SERVICIO_SUB_PRD objSubProducto;
            pdt_prd_servicio_sub_prdDL objSubProductoDL = new pdt_prd_servicio_sub_prdDL();

            objSubProducto = objSubProductoDL.Obtener(pintIdProducto, pintIdSubProducto);
            return objSubProducto;
        }

        public DESCUENTO Obtener_DescuentoPorProductoMonto(int pintIdProducto, decimal pdecMonto)
        {
            DESCUENTO objDescuento;
            pdt_descuentoDL objDescuentoDL = new pdt_descuentoDL();

            objDescuento = objDescuentoDL.Obtener_PorProductoMonto(pintIdProducto, pdecMonto);
            return objDescuento;
        }

        public DataTable ListarCotizacionProducto(int pintIdCotizacion)
        {
            DataTable dt;
            pdt_cotizacion_prdDL objCotizacionProductoDL = new pdt_cotizacion_prdDL();
            dt = objCotizacionProductoDL.ListarPorCotizacion(pintIdCotizacion);
            return dt;
        }

        public DataTable ListarCotizacionSubProducto(int pintIdCotizacion)
        {
            DataTable dt;
            pdt_cotizacion_prd_sprDL objCotizacionSubProductoDL = new pdt_cotizacion_prd_sprDL();
            dt = objCotizacionSubProductoDL.ListarPorCotizacion(pintIdCotizacion);
            return dt;
        }

        public int EliminarProductoPorCotizacion(int pintIdCotizacion)
        {
            int intResultado = 0;

            pdt_cotizacion_prdDL objCotizacionProductoDL = new pdt_cotizacion_prdDL();
            pdt_cotizacion_prd_sprDL objCotizacionSubProductoDL = new pdt_cotizacion_prd_sprDL();

            intResultado += objCotizacionSubProductoDL.EliminarPorCotizacion(pintIdCotizacion);
            intResultado += objCotizacionProductoDL.EliminarPorCotizacion(pintIdCotizacion);

            return intResultado;
        }

        public DataTable ListarProductos()
        {
            return this.Listar_PSPorPaqueteOC(0, 0);
        }

        public DataTable ListarSubProductos(int pintIdProducto)
        {
            return this.Listar_SubProductoPorProducto(pintIdProducto);
        }

        public COTIZACION_PRD ObtenerCotizacionProducto(int pintIdCotizacion, int pintIdProducto)
        {
            COTIZACION_PRD obj;
            pdt_cotizacion_prdDL objCotizacionProductoDL = new pdt_cotizacion_prdDL();
            obj = objCotizacionProductoDL.Obtener(pintIdCotizacion, pintIdProducto);
            return obj;
        }
    }
}
