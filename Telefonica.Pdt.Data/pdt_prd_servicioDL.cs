using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
    public class pdt_prd_servicioDL
    {
        public DataTable Listar_PRD_SERVICIO(int pi_iIdGrp_Prd)
        /* Objetivo	:	Permite listar productos servicios.
         * Author	:	Comsa/CC
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
                    string NombreStored = "PDTSS_LISTA_PRD_SERVICIO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@vgprc_iIdGrp_Prd", pi_iIdGrp_Prd);
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

        public DataTable Listar_PRD_SERVICIO_AGENDABLE(int prsec_iIdPrd_Servicio, int tococ_iInd_Req_Agendamiento)       
        {
            
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PRD_SERVICIO_AGENDABLE";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, prsec_iIdPrd_Servicio);
                    arrParam[1] = new DACRequest.Parameter("@tococ_iInd_Req_Agendamiento",DbType.Int32,4, tococ_iInd_Req_Agendamiento);
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

        public DataTable Listar_PSPorPaqueteOC(int pintIdPaquete, int pintOperacionComercial)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PS_POR_PAQUETE_OPERACION_COMERCIAL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@paqtc_iIdPaquete", DbType.Int32, 4, pintIdPaquete);
                    arrParam[1] = new DACRequest.Parameter("@tococ_iIdTip_Ope_Com", DbType.Int32, 4, pintOperacionComercial);
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
                    throw new Exception("pdt_prd_servicioDL.Listar_PSPorPaqueteOC: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_prd_servicioDL.Listar_PSPorPaqueteOC: " + ex.Message, ex);
            }
        }
    }
}
