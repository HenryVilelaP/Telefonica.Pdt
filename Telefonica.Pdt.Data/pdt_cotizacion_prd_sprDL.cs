using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
    public class pdt_cotizacion_prd_sprDL
    {
        public DataTable ListarPorCotizacion(int pintIdCotizacion)
        /* Objetivo	:	Permite listar los datos de diferentes cotizaciones por producto.
         * Author	:	Comsa/MD
         * Fecha	:	28/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                return this.ListarPorCotizacion(pintIdCotizacion, 
                                                Common.Enumeradores.EstadoRegistro.Activo);
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prd_sprDL.ListarPorCotizacion: " + ex.Message, ex);
            }
        }

        public DataTable ListarPorCotizacion(int pintIdCotizacion, Common.Enumeradores.EstadoRegistro pintEstadoRegistro)
        /* Objetivo	:	Permite listar los datos de diferentes cotizaciones por producto.
         * Author	:	Comsa/MD
         * Fecha	:	01/09/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_COTIZACION_PRD_SPR_POR_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@cospc_iEstado_Registro", DbType.Int32, 4, Convert.ToInt32(pintEstadoRegistro));
                    obRequest.Parameters.AddRange(arrParam);

                    DataSet ds;

                    //Ejecutar Comando.
                    ds = obRequest.Factory.ExecuteDataset(ref obRequest);
                    if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        DataTable dt = ds.Tables[0];
                        return dt;

                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prd_sprDL.ListarPorCotizacion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prd_sprDL.ListarPorCotizacion: " + ex.Message, ex);
            }
        }

        public int Insertar(COTIZACION_PRD_SPR pobjCotizacionSubPrd)
        /* Objetivo	:	Permite insertar los datos de los productos de una cotizacion.
         * Author	:	Comsa/MD
         * Fecha	:	14/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_COTIZACION_PRD_SPR";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[12];
                    arrParam[0] = new DACRequest.Parameter("@coprc_iIdCotizacion_Prd", DbType.Int32, 4, pobjCotizacionSubPrd.Coprc_iIdCotizacion_Prd);
                    arrParam[1] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pobjCotizacionSubPrd.Cotic_iIdCotizacion);
                    arrParam[2] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjCotizacionSubPrd.Prsec_iIdPrd_Servicio);
                    arrParam[3] = new DACRequest.Parameter("@psspc_iNum_Sub_Prd", DbType.String, pobjCotizacionSubPrd.Psspc_iNum_Sub_Prd);
                    arrParam[4] = new DACRequest.Parameter("@cospc_vNumero_Telefono", DbType.String, 10, pobjCotizacionSubPrd.Cospc_vNumero_Telefono );
                    arrParam[5] = new DACRequest.Parameter("@cospc_vNumero_Inscripcion", DbType.String, 20, pobjCotizacionSubPrd.Cospc_vNumero_Inscripcion);
                    arrParam[6] = new DACRequest.Parameter("@cospc_nPrecio", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nPrecio);
                    arrParam[7] = new DACRequest.Parameter("@cospc_nPorc_Igv", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nPorc_Igv);
                    arrParam[8] = new DACRequest.Parameter("@cospc_nMonto_IGV", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nMonto_IGV);
                    arrParam[9] = new DACRequest.Parameter("@cospc_nMonto_Total", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nMonto_Total);
                    arrParam[10] = new DACRequest.Parameter("@cospc_iEstado_Registro", DbType.Int32, 4, pobjCotizacionSubPrd.Cospc_iEstado_Registro);
                    arrParam[11] = new DACRequest.Parameter("@cospc_iIdUsuario_Registro", DbType.Int32, 4, pobjCotizacionSubPrd.Cospc_iIdUsuario_Registro);
                    
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prd_sprDL.Insertar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prd_sprDL.Insertar: " + ex.Message, ex);
            }
        }

        public int Modificar(COTIZACION_PRD_SPR pobjCotizacionSubPrd)
        /* Objetivo	:	Permite modificar los datos de los productos de una cotización.
         * Author	:	Comsa/MD
         * Fecha	:	20/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_COTIZACION_PRD_SPR";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[13];

                    arrParam[0] = new DACRequest.Parameter("@cospr_iIdCotizacion_Spr", DbType.Int32, 4, pobjCotizacionSubPrd.Cospr_iIdCotizacion_Spr);
                    arrParam[1] = new DACRequest.Parameter("@coprc_iIdCotizacion_Prd", DbType.Int32, 4, pobjCotizacionSubPrd.Coprc_iIdCotizacion_Prd);
                    arrParam[2] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pobjCotizacionSubPrd.Cotic_iIdCotizacion);
                    arrParam[3] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjCotizacionSubPrd.Prsec_iIdPrd_Servicio);
                    arrParam[4] = new DACRequest.Parameter("@psspc_iNum_Sub_Prd", DbType.String, pobjCotizacionSubPrd.Psspc_iNum_Sub_Prd);
                    arrParam[5] = new DACRequest.Parameter("@cospc_vNumero_Telefono", DbType.String, 10, pobjCotizacionSubPrd.Cospc_vNumero_Telefono);
                    arrParam[6] = new DACRequest.Parameter("@cospc_vNumero_Inscripcion", DbType.String, 20, pobjCotizacionSubPrd.Cospc_vNumero_Inscripcion);
                    arrParam[7] = new DACRequest.Parameter("@cospc_nPrecio", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nPrecio);
                    arrParam[8] = new DACRequest.Parameter("@cospc_nPorc_Igv", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nPorc_Igv);
                    arrParam[9] = new DACRequest.Parameter("@cospc_nMonto_IGV", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nMonto_IGV);
                    arrParam[10] = new DACRequest.Parameter("@cospc_nMonto_Total", DbType.Decimal, 10, pobjCotizacionSubPrd.Cospc_nMonto_Total);
                    arrParam[11] = new DACRequest.Parameter("@cospc_iEstado_Registro", DbType.Int32, pobjCotizacionSubPrd.Cospc_iEstado_Registro);
                    arrParam[12] = new DACRequest.Parameter("@cospc_iIdUsuario_Modifica", DbType.Int32, pobjCotizacionSubPrd.Cospc_iIdUsuario_Modifica);
                    
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prdDL.Modificar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prdDL.Modificar: " + ex.Message, ex);
            }
        }

        public int EliminarPorCotizacion(int pintIdCotizacion)
        /* Objetivo	:	Permite eliminar los datos de los sub productos de una cotización
        * Author	:	Comsa/MD
        * Fecha	:	31/09/2008
        */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSD_COTIZACION_PRD_SPR";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prd_sprDL.EliminarPorCotizacion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prd_sprDL.EliminarPorCotizacion: " + ex.Message, ex);
            }
        }
    }
}
