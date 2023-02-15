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
    public class pdt_sg_opcion_perfil_accionDL
    {
        public pdt_sg_opcion_perfil_accionDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Opcion_Perfil_Accion(Int32 piIdPerfil, Int32 piIdOpcion, Int32 piIdAccion)
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
                    string NombreStored = "PDTSS_LISTA_SG_OPCION_PERFIL_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, piIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, piIdAccion);
                    arrParam[2] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, piIdPerfil);
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
                    throw new Exception("Lista_Opcion_Perfil_Accion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Opcion_Perfil_Accion: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_OPCION_PERFIL_ACCION poOpcionPerfilAccion)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_OPCION_PERFIL.
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
                    string NombreStored = "PDTSI_SG_OPCION_PERFIL_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[5];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, poOpcionPerfilAccion.Opcic_iIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, poOpcionPerfilAccion.Accic_iIdAccion);
                    arrParam[2] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, poOpcionPerfilAccion.Perfc_iIdPerfil);
                    arrParam[3] = new DACRequest.Parameter("@ppacc_iIdUsuario_Registro", DbType.Int32, 4, poOpcionPerfilAccion.Ppacc_iIdUsuario_Registro);
                    arrParam[4] = new DACRequest.Parameter("@ppacc_iEstado_Registro", DbType.Int32, 4, poOpcionPerfilAccion.Ppacc_iEstado_Registro);

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
