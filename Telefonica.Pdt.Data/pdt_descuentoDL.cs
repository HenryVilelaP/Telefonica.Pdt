using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.Common;
using Telefonica.Pdt.Entities;

namespace Telefonica.Pdt.Data
{
    public class pdt_descuentoDL
    {
        public DataTable Listar_PorPS(int pintIdPS)
        /* Objetivo	:	Permite listar productos servicios.
         * Author	:	Comsa/MD
         * Fecha	:	25/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_DESCUENTO_POR_PRODUCTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", pintIdPS);
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
                    throw new Exception("pdt_descuentoDL.Listar_PorPS: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_descuentoDL.Listar_PorPS: " + ex.Message, ex);
            }
        }

        public DESCUENTO Obtener(int pintIdProducto)
        /* Objetivo	:	Permite obtener los datos de una cotización.
         * Author	:	Comsa/MD
         * Fecha	:	26/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_DESCUENTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pintIdProducto);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    DESCUENTO objDescuento;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objDescuento = new DESCUENTO();
                        objDescuento.Descc_iIdDescuento = reader.GetInt32(0);
                        objDescuento.Prsec_iIdPrd_Servicio = NullableTypes.ConvertNullInt32(reader[1]);
                        objDescuento.Descc_nMonto_Inicial = reader.GetDecimal(2);
                        objDescuento.Descc_nMonto_Final =  reader.GetDecimal(3);
                        objDescuento.Descc_nPorc_Descuento = reader.GetDecimal(4);
                        objDescuento.Descc_iInd_Actividad_Descuento = reader.GetInt32(5);
                        objDescuento.Descc_iEstado_Registro = reader.GetInt32(6);
                        objDescuento.Descc_dFec_Registro = reader.GetDateTime(7);
                        objDescuento.Descc_iIdUsuario_Ingreso = reader.GetInt32(8);
                        objDescuento.Descc_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[9]);
                        objDescuento.Descc_iIdUsuario_Modifica = NullableTypes.ConvertNullInt32(reader[10]);
                        
                        return objDescuento;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_descuentoDL.PDTSS_DETALLE_DESCUENTO: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_descuentoDL.PDTSS_DETALLE_DESCUENTO: " + ex.Message, ex);
            }
        }

        public DESCUENTO Obtener_PorProductoMonto(int pintIdProducto, decimal pdecMonto)
        /* Objetivo	:	Permite obtener los datos de una cotización.
         * Author	:	Comsa/MD
         * Fecha	:	26/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_DESCUENTO_POR_PRODUCTO_MONTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pintIdProducto);
                    arrParam[1] = new DACRequest.Parameter("@desc_nMonto", DbType.Decimal, 21, pdecMonto);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    DESCUENTO objDescuento;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objDescuento = new DESCUENTO();
                        objDescuento.Descc_iIdDescuento = reader.GetInt32(0);
                        objDescuento.Prsec_iIdPrd_Servicio = NullableTypes.ConvertNullInt32(reader[1]);
                        objDescuento.Descc_nMonto_Inicial = reader.GetDecimal(2);
                        objDescuento.Descc_nMonto_Final = reader.GetDecimal(3);
                        objDescuento.Descc_nPorc_Descuento = reader.GetDecimal(4);
                        objDescuento.Descc_iInd_Actividad_Descuento = reader.GetInt32(5);
                        objDescuento.Descc_iEstado_Registro = reader.GetInt32(6);
                        objDescuento.Descc_iIdUsuario_Ingreso = reader.GetInt32(7);
                        objDescuento.Descc_dFec_Registro = reader.GetDateTime(8);
                        objDescuento.Descc_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[9]);
                        objDescuento.Descc_iIdUsuario_Modifica = NullableTypes.ConvertNullInt32(reader[10]);

                        return objDescuento;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_descuentoDL.PDTSS_DETALLE_DESCUENTO: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_descuentoDL.PDTSS_DETALLE_DESCUENTO: " + ex.Message, ex);
            }
        }
    }
}
