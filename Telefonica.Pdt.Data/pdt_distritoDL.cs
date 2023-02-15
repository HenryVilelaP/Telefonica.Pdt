using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;

namespace Telefonica.Pdt.Data
{
    public class pdt_distritoDL
    {
        public DataTable Listar_Por_Provincia(string pstrIdDepartamento, string pstrIdProvincia)
        /* Objetivo	:	Permite listar los usuarios.
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
                    string NombreStored = "PDTSS_DISTRITO_POR_PROVINCIA";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@vdepc_vIdDepartamento", DbType.String, 6, pstrIdDepartamento);
                    arrParam[1] = new DACRequest.Parameter("@vproc_vIdProvincia", DbType.String, 6, pstrIdProvincia);
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
                    throw new Exception("pdt_DistritoDL.Listar_Por_Provincia: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_DistritoDL.Listar_Por_Provincia: " + ex.Message, ex);
            }
        }
    }
}
