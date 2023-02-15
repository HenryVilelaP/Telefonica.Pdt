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
    public class pdt_perfilDL
    {
        public pdt_perfilDL()
        {

        }

        #region "No Transaccional"

        public DataTable Listar_Perfil()
        /* 
         * Objetivo	:	Permite listar los usuarios.
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
                    string NombreStored = "PDTSS_LISTA_PERFIL";
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
                    throw new Exception("Listar_Perfil: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Perfil: " + ex.Message, ex);
            }
        }

        public SG_PERFIL Detalle(Int32 piIdPerfil)
        /* 
         * Objetivo	:	Permite obtener un perfil por su Id.
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
                    string NombreStored = "PDTSS_DETALLE_SG_PERFIL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, piIdPerfil);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_PERFIL oSG_PERFIL = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oSG_PERFIL = new SG_PERFIL();

                        oSG_PERFIL.Perfc_iIdPerfil = Convert.ToInt32(dr[Enumeradores.Col_SG_PERFIL.perfc_iIdPerfil.ToString()]);
                        oSG_PERFIL.Perfc_vDescripcion = Convert.ToString(dr[Enumeradores.Col_SG_PERFIL.perfc_vDescripcion.ToString()]);
                        oSG_PERFIL.Perfc_vNemotecnico = Convert.ToString(dr[Enumeradores.Col_SG_PERFIL.perfc_vNemotecnico.ToString()]);

                        return oSG_PERFIL;

                    }

                    dr.Close();

                    return oSG_PERFIL;

                }
                catch (Exception ex)
                {
                    throw new Exception("Detalle: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Detalle: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_PERFIL poPerfil)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SEG_USUARIO.
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
                    string NombreStored = "PDTSI_PERFIL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@perfc_vDescripcion", DbType.String, 200, poPerfil.Perfc_vDescripcion);
                    arrParam[1] = new DACRequest.Parameter("@perfc_vNemotecnico", DbType.String, 10, poPerfil.Perfc_vNemotecnico);
                    arrParam[2] = new DACRequest.Parameter("@perfc_iIdUsuario_Registro", DbType.Int32, poPerfil.Perfc_iIdUsuario_Registro);

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

        public int Modificar(SG_PERFIL poPerfil)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_PERFIL.
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
                    string NombreStored = "PDTSU_SG_PERFIL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                    arrParam[0] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, poPerfil.Perfc_iIdPerfil);
                    arrParam[1] = new DACRequest.Parameter("@perfc_vDescripcion", DbType.String, 200, poPerfil.Perfc_vDescripcion);
                    arrParam[2] = new DACRequest.Parameter("@perfc_vNemotecnico", DbType.String, 10, poPerfil.Perfc_vNemotecnico);
                    arrParam[3] = new DACRequest.Parameter("@perfc_iIdUsuario_Modifica", DbType.Int32, 4, poPerfil.Perfc_iIdUsuario_Modifica);

                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    int lintUltimoReg;

                    //Ejecutar Comando.                    
                    lintUltimoReg = Convert.ToInt32(obRequest.Factory.ExecuteNonQuery(ref obRequest));

                    return lintUltimoReg;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Modificar: " + ex.Message, ex);
            }
        }

        #endregion "Transaccional"    

    }

}
