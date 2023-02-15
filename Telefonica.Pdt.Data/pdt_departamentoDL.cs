using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;

namespace Telefonica.Pdt.Data
{
    public class pdt_departamentoDL
    {

        public DataTable Listar()
        /* Objetivo	:	Permite listar las provincias.
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
                    string NombreStored = "PDTSS_LISTA_DEPARTAMENTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

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
                    throw new Exception("pdt_DepartamentoDL.Listar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_DepartamentoDL.Listar: " + ex.Message, ex);
            }
        }
    }
}
