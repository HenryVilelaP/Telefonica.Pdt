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
    public class pdt_sg_opcion_accionDL
    {
        public pdt_sg_opcion_accionDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Opcion_Accion(Int32 piIdOpcion, Int32 piIdAccion)
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
                    string NombreStored = "PDTSS_LISTA_SG_OPCION_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, piIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, piIdAccion);
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
                    throw new Exception("Lista_Opcion_Accion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Opcion_Accion: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_OPCION_ACCION poOpcionAccion)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_OPCION.
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
                    string NombreStored = "PDTSI_SG_OPCION_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, poOpcionAccion.Opcic_iIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, poOpcionAccion.Accic_iIdAccion);
                    arrParam[2] = new DACRequest.Parameter("@oaccc_iIdUsuario_Registro", DbType.Int32, 4, poOpcionAccion.Oaccc_iIdUsuario_Registro);
                    arrParam[3] = new DACRequest.Parameter("@oaccc_iEstado_Registro", DbType.Int32, 4, poOpcionAccion.Oaccc_iEstado_Registro);

                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    int lintUltimoReg;

                    //Ejecutar Comando.                    
                    lintUltimoReg = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));
                    if (lintUltimoReg > 0)
                    {
                        return lintUltimoReg;
                    }
                    return 0;

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
