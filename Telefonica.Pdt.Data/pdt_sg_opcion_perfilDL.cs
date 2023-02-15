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
    public class pdt_sg_opcion_perfilDL
    {
        public pdt_sg_opcion_perfilDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Opcion_Perfil(Int32 piIdPerfil, Int32 piIdOpcion)
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
                    string NombreStored = "PDTSS_LISTA_SG_OPCION_PERFIL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, piIdPerfil);
                    arrParam[1] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, piIdOpcion);
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
                    throw new Exception("Lista_Opcion_Perfil: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Opcion_Perfil: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_OPCION_PERFIL poOpcionPerfil)
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
                    string NombreStored = "PDTSI_SG_OPCION_PERFIL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, poOpcionPerfil.Opcic_iIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, poOpcionPerfil.Perfc_iIdPerfil);
                    arrParam[2] = new DACRequest.Parameter("@acpac_iIdUsuario_Registro", DbType.Int32, 4, poOpcionPerfil.Acpac_iIdUsuario_Registro);
                    arrParam[3] = new DACRequest.Parameter("@acpac_iEstado_Registro", DbType.Int32, 4, poOpcionPerfil.Acpac_iEstado_Registro);

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
