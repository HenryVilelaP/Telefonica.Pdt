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
    public class pdt_usuarioDL
    {
        public pdt_usuarioDL()
        {
        }

 #region "No Transaccional"

        public DataTable Listar_PorNombre(SG_USUARIO poUsuario)
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
                    string NombreStored = "PDTSS_LISTA_USUARIO_POR_NOMBRE";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@usuac_vLogin", DbType.String, 50, poUsuario.Usuac_vLogin);
                    arrParam[1] = new DACRequest.Parameter("@usuac_vNombre", DbType.String, 150, poUsuario.Usuac_vNombre);
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
                    throw new Exception("Listar_Usuario: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Usuario: " + ex.Message, ex);
            }
        }

        public SG_USUARIO Detalle(Int32 piIdUsuario)
        /* 
         * Objetivo	:	Permite obtener usuario por su Id.
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
                    string NombreStored = "PDTSS_DETALLE_SG_USUARIO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@usuac_iId_Usuario", DbType.Int32, 4, piIdUsuario);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_USUARIO oSG_USUARIO=null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while(dr.Read())
                    {
                        oSG_USUARIO = new SG_USUARIO();

                        oSG_USUARIO.Usuac_iId_Usuario=Convert.ToInt32(dr[Enumeradores.Col_SG_USUARIO.usuac_iId_Usuario.ToString()]);
                        oSG_USUARIO.Usuac_vApellido_Paterno = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vApellido_Paterno.ToString()]);
                        oSG_USUARIO.Usuac_vApellido_Materno = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vApellido_Materno.ToString()]);
                        oSG_USUARIO.Usuac_vNombre = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vNombre.ToString()]);
                        oSG_USUARIO.Usuac_vCorreo = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vCorreo.ToString()]);
                        oSG_USUARIO.Usuac_vLogin = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vLogin.ToString()]);
                        oSG_USUARIO.Vtdoc_iIdTip_Doc = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_SG_USUARIO.vtdoc_iIdTip_Doc.ToString()]);
                        oSG_USUARIO.Usuac_vNum_Doc = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vNum_Doc.ToString()]);
                        oSG_USUARIO.Usuac_vPassword = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vPassword.ToString()]);
                        oSG_USUARIO.Usuac_vIp_Estacion = Convert.ToString(dr[Enumeradores.Col_SG_USUARIO.usuac_vIp_Estacion.ToString()]);
                        oSG_USUARIO.Usuac_iNum_Intento_Accesos =NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_SG_USUARIO.usuac_iNum_Intento_Accesos.ToString()]);
                        oSG_USUARIO.Usuac_iIdEstado_Usuario = Convert.ToInt32(dr[Enumeradores.Col_SG_USUARIO.usuac_iIdEstado_Usuario.ToString()]);
                        oSG_USUARIO.Usuac_iIdEstado_Bloqueado = Convert.ToInt32(dr[Enumeradores.Col_SG_USUARIO.usuac_iIdEstado_Bloqueado.ToString()]);
                        oSG_USUARIO.Perfc_iIdPerfil = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_SG_USUARIO.perfc_iIdPerfil.ToString()]);
                        oSG_USUARIO.Turnc_iIdTurno = Convert.ToInt32(dr[Enumeradores.Col_SG_USUARIO.turnc_iIdTurno.ToString()]);
                        oSG_USUARIO.Usuac_dFec_Ultimo_Acceso = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_USUARIO.usuac_dFec_Ultimo_Acceso.ToString()]);
                        oSG_USUARIO.Usuac_dFec_Ultimo_Acceso_Fallido = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_USUARIO.usuac_dFec_Ultimo_Acceso_Fallido.ToString()]);

                        return oSG_USUARIO;

                    }

                    dr.Close();

                    return oSG_USUARIO;

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

        public DataTable Detalle(String pstrLogin, String pstrClave)
        /* 
         * Objetivo	:	Permite obtener usuario por su Nombre y Clave.
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
                    string NombreStored = "PDTSS_DETALLE_SG_USUARIO_POR_CLAVE";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@usuac_vLogin", DbType.String, 50, pstrLogin);
                    arrParam[1] = new DACRequest.Parameter("@usuac_vPassword", DbType.String, 50, pstrClave);
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

        public int Insertar(SG_USUARIO poUsuario)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_USUARIO.
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
                    string NombreStored = "PDTSI_USUARIO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[14];
                    arrParam[0] = new DACRequest.Parameter("@usuac_vApellido_Paterno", DbType.String, 60, poUsuario.Usuac_vApellido_Paterno);
                    arrParam[1] = new DACRequest.Parameter("@usuac_vApellido_Materno", DbType.String, 60, poUsuario.Usuac_vApellido_Materno);
                    arrParam[2] = new DACRequest.Parameter("@usuac_vNombre", DbType.String, 100, poUsuario.Usuac_vNombre);
                    arrParam[3] = new DACRequest.Parameter("@usuac_vLogin", DbType.String, 50, poUsuario.Usuac_vLogin);
                    arrParam[4] = new DACRequest.Parameter("@usuac_iIdTip_Doc", DbType.Int32, 4, poUsuario.Vtdoc_iIdTip_Doc);
                    arrParam[5] = new DACRequest.Parameter("@usuac_vNum_Doc", DbType.String, 20, poUsuario.Usuac_vNum_Doc);
                    arrParam[6] = new DACRequest.Parameter("@usuac_iIdTurno", DbType.Int32, 4, poUsuario.Turnc_iIdTurno);
                    arrParam[7] = new DACRequest.Parameter("@usuac_iIdEstadoUsuario", DbType.Int32, 4, poUsuario.Usuac_iIdEstado_Usuario);
                    arrParam[8] = new DACRequest.Parameter("@usuac_iIdEstadoBloqueado", DbType.Int32, 4, poUsuario.Usuac_iIdEstado_Bloqueado);
                    arrParam[9] = new DACRequest.Parameter("@usuac_vIp_Estacion", DbType.String, 20, poUsuario.Usuac_vIp_Estacion);
                    arrParam[10] = new DACRequest.Parameter("@usuac_vCorreo", DbType.String, 20, poUsuario.Usuac_vCorreo);
                    arrParam[11] = new DACRequest.Parameter("@usuac_iIdUsuario_Registro", DbType.Int32, 4, poUsuario.Usuac_iIdUsuario_Registro);
                    arrParam[12] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, poUsuario.Perfc_iIdPerfil);
                    arrParam[13] = new DACRequest.Parameter("@usuac_vPassword", DbType.String, 50, poUsuario.Usuac_vPassword);

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

        public int Modificar(SG_USUARIO poUsuario)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_USUARIO.
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
                    string NombreStored = "PDTSU_USUARIO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[15];
                    arrParam[0] = new DACRequest.Parameter("@usuac_iId_Usuario", DbType.Int32, 4, poUsuario.Usuac_iId_Usuario);
                    arrParam[1] = new DACRequest.Parameter("@usuac_vApellido_Paterno", DbType.String, 60, poUsuario.Usuac_vApellido_Paterno);
                    arrParam[2] = new DACRequest.Parameter("@usuac_vApellido_Materno", DbType.String, 60, poUsuario.Usuac_vApellido_Materno);
                    arrParam[3] = new DACRequest.Parameter("@usuac_vNombre", DbType.String, 100, poUsuario.Usuac_vNombre);
                    arrParam[4] = new DACRequest.Parameter("@usuac_vLogin", DbType.String, 50, poUsuario.Usuac_vLogin);
                    arrParam[5] = new DACRequest.Parameter("@usuac_vPassword", DbType.String, 50, poUsuario.Usuac_vPassword);
                    arrParam[6] = new DACRequest.Parameter("@usuac_iIdTip_Doc", DbType.Int32, 4, poUsuario.Vtdoc_iIdTip_Doc);
                    arrParam[7] = new DACRequest.Parameter("@usuac_vNum_Doc", DbType.String, 20, poUsuario.Usuac_vNum_Doc);
                    arrParam[8] = new DACRequest.Parameter("@usuac_iIdTurno", DbType.Int32, 4, poUsuario.Turnc_iIdTurno);
                    arrParam[9] = new DACRequest.Parameter("@usuac_iIdEstadoUsuario", DbType.Int32, 4, poUsuario.Usuac_iIdEstado_Usuario);
                    arrParam[10] = new DACRequest.Parameter("@usuac_iIdEstadoBloqueado", DbType.Int32, 4, poUsuario.Usuac_iIdEstado_Bloqueado);
                    arrParam[11] = new DACRequest.Parameter("@usuac_vIp_Estacion", DbType.String, 20, poUsuario.Usuac_vIp_Estacion);
                    arrParam[12] = new DACRequest.Parameter("@usuac_vCorreo", DbType.String, 200, poUsuario.Usuac_vCorreo);
                    arrParam[13] = new DACRequest.Parameter("@usuac_iIdUsuario_Modifica", DbType.Int32, 4, poUsuario.Usuac_iIdUsuario_Registro);
                    arrParam[14] = new DACRequest.Parameter("@perfc_iIdPerfil", DbType.Int32, 4, poUsuario.Perfc_iIdPerfil);

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
                throw new Exception("Insertar: " + ex.Message, ex);
            }
        }

 #endregion "Transaccional"

    }
}
