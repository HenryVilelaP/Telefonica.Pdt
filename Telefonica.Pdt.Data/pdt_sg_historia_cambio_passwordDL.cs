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
    public class pdt_sg_historia_cambio_passwordDL
    {
        public pdt_sg_historia_cambio_passwordDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Historia_Cambio_Password(Int32 piIdUsuario)
        /* 
         * Objetivo	:	Permite listar las opciones de seguridad.
         * Author	:	Comsa/CC
         * Fecha	:	17/07/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_SG_HISTORIA_CAMBIO_PASSWORD";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@usuac_iId_Usuario", DbType.Int32, 4, piIdUsuario);
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
                    throw new Exception("Lista_Historia_Cambio_Password: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Historia_Cambio_Password: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_HISTORIA_CAMBIO_PASSWORD poHistoriaCambioPassword, String pstrClaveActual)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_HISTORIA_CAMBIO_PASSWORD.
        *  Author	:	Comsa/CC
        *  Fecha	:	17/07/2008
        */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_SG_HISTORIA_CAMBIO_PASSWORD";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                    arrParam[0] = new DACRequest.Parameter("@usuac_iId_Usuario", DbType.Int32, 4, poHistoriaCambioPassword.Usuac_iId_Usuario);
                    arrParam[1] = new DACRequest.Parameter("@hcapc_vPassword", DbType.String, 50, poHistoriaCambioPassword.Hcapc_vPassword);
                    arrParam[2] = new DACRequest.Parameter("@hcapc_iIdUsuario_Registro", DbType.Int32, 4, poHistoriaCambioPassword.Hcapc_iIdUsuario_Registro);
                    arrParam[3] = new DACRequest.Parameter("@hcapc_vPassword_Actual", DbType.String, 50, pstrClaveActual);

                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    int lintUltimoReg;

                    //Ejecutar Comando.                    
                    lintUltimoReg = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                    return lintUltimoReg;

                }
                catch (Exception ex)
                {
                    throw new Exception("Insertar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Insertar: " + ex.Message, ex);
            }
        }

        #endregion "Transaccional"    

    }
}
