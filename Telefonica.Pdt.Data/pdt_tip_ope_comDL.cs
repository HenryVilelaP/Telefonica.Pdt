using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
    public class pdt_tip_ope_comDL
    {
        public DataTable Listar_TIP_OPE_COM(int pi_IdGrp_Tip_Ope_Com)
        /* Objetivo	:	Permite listar tipo de operacion comercial.
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
                    string NombreStored = "[PDTSS_LISTA_TIP_OPE_COM]";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@vgtoc_iIdGrp_Tip_Ope_Com", pi_IdGrp_Tip_Ope_Com);
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
                    throw new Exception("Listar_TIP_OPE_COM: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_TIP_OPE_COM: " + ex.Message, ex);
            }
        }
    }
}
