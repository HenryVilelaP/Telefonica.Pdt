using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;

namespace Telefonica.Pdt.Data
{
    public class pdt_provinciaDL
    {

        public DataTable Listar_Por_Departamento(string pstrIdDepartamento)
        /* Objetivo	:	Permite listar las provincias de un departamento.
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
                    string NombreStored = "PDTSS_PROVINCIA_POR_DEPARTAMENTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@vdepc_vIdDepartamento", DbType.String, 6, pstrIdDepartamento);
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
                    throw new Exception("pdt_ProvinciaDL.Listar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_ProvinciaDL.Listar: " + ex.Message, ex);
            }
        }
    }
}
