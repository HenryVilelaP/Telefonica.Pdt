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
    public class pdt_cotizacion_prdDL
    {
        public int Insertar(COTIZACION_PRD pobjCotizacionPrd)
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
                    string NombreStored = "PDTSI_COTIZACION_PRD";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[16];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pobjCotizacionPrd.Cotic_iIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@coprc_iCantidad_Prd", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iCantidad_Prd);
                    arrParam[2] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjCotizacionPrd.Prsec_iIdPrd_Servicio);
                    arrParam[3] = new DACRequest.Parameter("@paqtc_iIdPaquete", DbType.Int32, 4, pobjCotizacionPrd.Paqtc_iIdPaquete);
                    arrParam[4] = new DACRequest.Parameter("@tococ_iIdTip_Ope_Com", DbType.Int32, 4, pobjCotizacionPrd.Tococ_iIdTip_Ope_Com);
                    arrParam[5] = new DACRequest.Parameter("@vfadc_iIdForma_Adquisicion", DbType.Int32, 4, pobjCotizacionPrd.Vfadc_iIdForma_Adquisicion);
                    arrParam[6] = new DACRequest.Parameter("@vtctc_iIdTiempo_Contrato", DbType.Int32, 4, pobjCotizacionPrd.Vtctc_iIdTiempo_Contrato);
                    arrParam[7] = new DACRequest.Parameter("@coprc_nPrecio", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPrecio);
                    arrParam[8] = new DACRequest.Parameter("@coprc_nPorc_Igv", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPorc_Igv);
                    arrParam[9] = new DACRequest.Parameter("@coprc_nMonto_IGV", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_IGV);
                    arrParam[10] = new DACRequest.Parameter("@descc_iIdDescuento", DbType.Int32, 4, pobjCotizacionPrd.Descc_iIdDescuento);
                    arrParam[11] = new DACRequest.Parameter("@coprc_nPorc_Descuento", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPorc_Descuento);
                    arrParam[12] = new DACRequest.Parameter("@coprc_nMonto_Descuento", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_Descuento);
                    arrParam[13] = new DACRequest.Parameter("@coprc_nMonto_Total", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_Total);
                    arrParam[14] = new DACRequest.Parameter("@coprc_iEstado_Registro", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iEstado_Registro);
                    arrParam[15] = new DACRequest.Parameter("@coprc_iIdUsuario_Registro", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iIdUsuario_Registro);
                    
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prdDL.Insertar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prdDL.Insertar: " + ex.Message, ex);
            }
        }

        public int Modificar(COTIZACION_PRD pobjCotizacionPrd)
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
                    string NombreStored = "PDTSU_COTIZACION_PRD";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[17];

                    arrParam[0] = new DACRequest.Parameter("@coprc_iIdCotizacion_Prd", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iIdCotizacion_Prd);
                    arrParam[1] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pobjCotizacionPrd.Cotic_iIdCotizacion);
                    arrParam[2] = new DACRequest.Parameter("@coprc_iCantidad_Prd", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iCantidad_Prd);
                    arrParam[3] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjCotizacionPrd.Prsec_iIdPrd_Servicio);
                    arrParam[4] = new DACRequest.Parameter("@paqtc_iIdPaquete", DbType.Int32, 4, pobjCotizacionPrd.Paqtc_iIdPaquete);
                    arrParam[5] = new DACRequest.Parameter("@tococ_iIdTip_Ope_Com", DbType.Int32, 4, pobjCotizacionPrd.Tococ_iIdTip_Ope_Com);
                    arrParam[6] = new DACRequest.Parameter("@vfadc_iIdForma_Adquisicion", DbType.Int32, 4, pobjCotizacionPrd.Vfadc_iIdForma_Adquisicion);
                    arrParam[7] = new DACRequest.Parameter("@vtctc_iIdTiempo_Contrato", DbType.Int32, 4, pobjCotizacionPrd.Vtctc_iIdTiempo_Contrato);
                    arrParam[8] = new DACRequest.Parameter("@coprc_nPrecio", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPrecio);
                    arrParam[9] = new DACRequest.Parameter("@coprc_nPorc_Igv", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPorc_Igv);
                    arrParam[10] = new DACRequest.Parameter("@coprc_nMonto_IGV", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_IGV);
                    arrParam[11] = new DACRequest.Parameter("@descc_iIdDescuento", DbType.Int32, 4, pobjCotizacionPrd.Descc_iIdDescuento);
                    arrParam[12] = new DACRequest.Parameter("@coprc_nPorc_Descuento", DbType.Decimal, 10, pobjCotizacionPrd.Coprc_nPorc_Descuento);
                    arrParam[13] = new DACRequest.Parameter("@coprc_nMonto_Descuento", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_Descuento);
                    arrParam[14] = new DACRequest.Parameter("@coprc_nMonto_Total", DbType.Decimal, 21, pobjCotizacionPrd.Coprc_nMonto_Total);
                    arrParam[15] = new DACRequest.Parameter("@coprc_iEstado_Registro", DbType.Int32, 4, pobjCotizacionPrd.Coprc_iEstado_Registro);
                    arrParam[16] = new DACRequest.Parameter("@coprc_iIdUsuario_Modifica", DbType.String, pobjCotizacionPrd.Coprc_iIdUsuario_Modifica);
                    
                    

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

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

        public DataTable ListarPorCotizacion(int pintIdCotizacion)
        /* Objetivo	:	Permite listar los datos de diferentes cotizaciones por producto.
         * Author	:	Comsa/MD
         * Fecha	:	28/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_COTIZACION_PRD_POR_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
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
                    throw new Exception("pdt_cotizacion_prdDL.ListarPorCotizacion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prdDL.ListarPorCotizacion: " + ex.Message, ex);
            }
        }

        public int EliminarPorCotizacion(int pintIdCotizacion)
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSD_COTIZACION_PRD";
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
                    throw new Exception("pdt_cotizacion_prdDL.EliminarPorCotizacion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prdDL.EliminarPorCotizacion: " + ex.Message, ex);
            }
        }

        public COTIZACION_PRD Obtener(int pintIdCotizacion, int pintIdProducto)
        /* Objetivo	:	Permite obtener los datos de una cotización.
         * Author	:	Comsa/MD
         * Fecha	:	18/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_OBTENER_COTIZACION_PRD";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pintIdProducto);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    COTIZACION_PRD objCotizacionProducto;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objCotizacionProducto = new COTIZACION_PRD();
                        objCotizacionProducto.Coprc_iIdCotizacion_Prd = reader.GetInt32(0);
                        objCotizacionProducto.Cotic_iIdCotizacion = reader.GetInt32(1);
                        objCotizacionProducto.Coprc_iCantidad_Prd = reader.GetInt32(2);
                        objCotizacionProducto.Prsec_iIdPrd_Servicio = reader.GetInt32(3);
                        objCotizacionProducto.Paqtc_iIdPaquete = reader.GetInt32(4);
                        objCotizacionProducto.Tococ_iIdTip_Ope_Com = reader.GetInt32(5);
                        objCotizacionProducto.Vfadc_iIdForma_Adquisicion = reader.GetInt32(6);
                        objCotizacionProducto.Vtctc_iIdTiempo_Contrato = NullableTypes.ConvertNullInt32(reader[7]);
                        objCotizacionProducto.Coprc_nPrecio = NullableTypes.ConvertNullDecimal(reader[8]);
                        objCotizacionProducto.Coprc_nPorc_Igv = NullableTypes.ConvertNullDecimal(reader[9]);
                        objCotizacionProducto.Coprc_nMonto_IGV = NullableTypes.ConvertNullDecimal(reader[10]);
                        objCotizacionProducto.Descc_iIdDescuento = NullableTypes.ConvertNullInt32(reader[11]);
                        objCotizacionProducto.Coprc_nPorc_Descuento = NullableTypes.ConvertNullDecimal(reader[12]);
                        objCotizacionProducto.Coprc_nMonto_Descuento = NullableTypes.ConvertNullInt32(reader[13]);
                        objCotizacionProducto.Coprc_nMonto_Total = NullableTypes.ConvertNullDecimal(reader[14]);
                        objCotizacionProducto.Coprc_iEstado_Registro = reader.GetInt32(15);
                        objCotizacionProducto.Coprc_dFec_Registro = reader.GetDateTime(16);
                        objCotizacionProducto.Coprc_iIdUsuario_Registro = reader.GetInt32(17);
                        objCotizacionProducto.Coprc_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[18]);
                        objCotizacionProducto.Coprc_iIdUsuario_Modifica = NullableTypes.ConvertNullInt32(reader[19]);
                        return objCotizacionProducto;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_cotizacion_prdDL.Obtener: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_cotizacion_prdDL.Obtener: " + ex.Message, ex);
            }
        }
    }
}