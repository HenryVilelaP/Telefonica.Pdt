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
    public class pdt_prd_servicio_sub_prdDL
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
                    string NombreStored = "PDTSS_LISTA_SUB_PS_POR_PS";
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
                    throw new Exception("Listar_PRD_SERVICIO: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_PRD_SERVICIO: " + ex.Message, ex);
            }
        }

        public PRD_SERVICIO_SUB_PRD Obtener(int pintIdProducto, int pintIdSubProducto)
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
                    string NombreStored = "PDTSS_DETALLE_SUB_PRODUCTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pintIdProducto);
                    arrParam[1] = new DACRequest.Parameter("@psspc_iNum_Sub_Prd", DbType.Int32, 4, pintIdSubProducto);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    PRD_SERVICIO_SUB_PRD objSubProducto;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objSubProducto = new PRD_SERVICIO_SUB_PRD();
                        objSubProducto.Prsec_iIdPrd_Servicio = reader.GetInt32(0);
                        objSubProducto.Psspc_iNum_Sub_Prd = reader.GetInt32(1);
                        objSubProducto.Pspsc_vDescripcion = reader.GetString(2);
                        objSubProducto.Pspsc_nMonto_Renta = NullableTypes.ConvertNullDecimal(reader[3]);
                        objSubProducto.Pspsc_iEstado_Registro = reader.GetInt32(4);
                        objSubProducto.Pspsc_dFec_Registro = reader.GetDateTime(5);
                        objSubProducto.Pspsc_iIdUsuario_Registro = reader.GetInt32(6);
                        objSubProducto.Pspsc_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[7]);
                        objSubProducto.Pspsc_iIdUsuario_Modifica =  NullableTypes.ConvertNullInt32(reader[8]);
                        
                        return objSubProducto;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_prd_servicio_sub_prdDL.Obtener: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_prd_servicio_sub_prdDL.Obtener: " + ex.Message, ex);
            }
        }
    }
}
