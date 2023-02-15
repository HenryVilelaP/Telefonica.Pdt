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
    public class pdt_sg_opcionDL
    {
        public pdt_sg_opcionDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Opcion(String piStrDescripcion, Int32 piIntTipoOpcion)
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
                    string NombreStored = "PDTSS_LISTA_SG_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@opcic_vDescripcion", DbType.String, 200, piStrDescripcion);
                    arrParam[1] = new DACRequest.Parameter("@vtopc_iIdTip_Opcion", DbType.Int32, 4, piIntTipoOpcion);
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
                    throw new Exception("Lista_Opcion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Opcion: " + ex.Message, ex);
            }
        }

        public SG_OPCION Detalle(Int32 piIdOpcion)
        /* 
         * Objetivo	:	Permite obtener un tipo de opcion por su Id.
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
                    string NombreStored = "PDTSS_DETALLE_SG_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, piIdOpcion);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_OPCION oSG_OPCION = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oSG_OPCION = new SG_OPCION();

                        oSG_OPCION.Opcic_iIdOpcion = Convert.ToInt32(dr[Enumeradores.Col_SG_OPCION.opcic_iIdOpcion.ToString()]);
                        oSG_OPCION.Opcic_vEtiqueta = Convert.ToString(dr[Enumeradores.Col_SG_OPCION.opcic_vEtiqueta.ToString()]);
                        oSG_OPCION.Opcic_vDescripcion = Convert.ToString(dr[Enumeradores.Col_SG_OPCION.opcic_vDescripcion.ToString()]);
                        oSG_OPCION.Opcic_vNombre_Pagina = Convert.ToString(dr[Enumeradores.Col_SG_OPCION.opcic_vNombre_Pagina.ToString()]);
                        oSG_OPCION.Opcic_vRuta_Url_Pagina = Convert.ToString(dr[Enumeradores.Col_SG_OPCION.opcic_vRuta_Url_Pagina.ToString()]);
                        oSG_OPCION.Opcic_iId_Opcion_Padre = Convert.ToInt32(dr[Enumeradores.Col_SG_OPCION.opcic_iId_Opcion_Padre.ToString()]);
                        oSG_OPCION.Opcic_iNum_Orden = Convert.ToInt32(dr[Enumeradores.Col_SG_OPCION.opcic_iNum_Orden.ToString()]);
                        oSG_OPCION.Opcic_iInd_Opcion_Critica = Convert.ToInt32(dr[Enumeradores.Col_SG_OPCION.opcic_iInd_Opcion_Critica.ToString()]);
                        oSG_OPCION.Vtopc_iIdTip_Opcion = Convert.ToInt32(dr[Enumeradores.Col_SG_OPCION.vtopc_iIdTip_Opcion.ToString()]);

                        return oSG_OPCION;

                    }

                    dr.Close();

                    return oSG_OPCION;

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

        public DataTable Lista_Menu_Opciones(String pStrLogin)
        /* 
         * Objetivo	:	Permite obtener el menu de opciones segun el login del usuario.
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
                    string NombreStored = "PDTSS_LISTA_SG_MENU_OPCIONES";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@usuac_vLogin", DbType.String, 50, pStrLogin);
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
                    throw new Exception("Lista_Menu_Opciones: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Menu_Opciones: " + ex.Message, ex);
            }
        }

        #endregion "No Transaccional"

        #region "Transaccional"

        public int Insertar(SG_OPCION poOpcion)
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
                    string NombreStored = "PDTSI_SG_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[9];
                    arrParam[0] = new DACRequest.Parameter("@opcic_vEtiqueta", DbType.String, 80, poOpcion.Opcic_vEtiqueta);
                    arrParam[1] = new DACRequest.Parameter("@opcic_vNombre_Pagina", DbType.String, 120, poOpcion.Opcic_vNombre_Pagina);
                    arrParam[2] = new DACRequest.Parameter("@opcic_vRuta_Url_Pagina", DbType.String, 200, poOpcion.Opcic_vRuta_Url_Pagina);
                    arrParam[3] = new DACRequest.Parameter("@opcic_iId_Opcion_Padre", DbType.Int32, 4, poOpcion.Opcic_iId_Opcion_Padre);
                    arrParam[4] = new DACRequest.Parameter("@opcic_iNum_Orden", DbType.Int32, 4, poOpcion.Opcic_iNum_Orden);
                    arrParam[5] = new DACRequest.Parameter("@opcic_iInd_Opcion_Critica", DbType.Int32, 4, poOpcion.Opcic_iInd_Opcion_Critica);
                    arrParam[6] = new DACRequest.Parameter("@opcic_iIdUsuario_Registro", DbType.Int32, 4, poOpcion.Opcic_iIdUsuario_Registro);
                    arrParam[7] = new DACRequest.Parameter("@vtopc_iIdTip_Opcion", DbType.Int32, 4, poOpcion.Vtopc_iIdTip_Opcion);
                    arrParam[8] = new DACRequest.Parameter("@opcic_vDescripcion", DbType.String, 200, poOpcion.Opcic_vDescripcion);

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

        public int Modificar(SG_OPCION poOpcion)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_OPCION.
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
                    string NombreStored = "PDTSU_SG_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[10];
                    arrParam[0] = new DACRequest.Parameter("@opcic_iIdOpcion", DbType.Int32, 4, poOpcion.Opcic_iIdOpcion);
                    arrParam[1] = new DACRequest.Parameter("@opcic_vEtiqueta", DbType.String, 80, poOpcion.Opcic_vEtiqueta);
                    arrParam[2] = new DACRequest.Parameter("@opcic_vNombre_Pagina", DbType.String, 120, poOpcion.Opcic_vNombre_Pagina);
                    arrParam[3] = new DACRequest.Parameter("@opcic_vRuta_Url_Pagina", DbType.String, 200, poOpcion.Opcic_vRuta_Url_Pagina);
                    arrParam[4] = new DACRequest.Parameter("@opcic_iId_Opcion_Padre", DbType.Int32, 4, poOpcion.Opcic_iId_Opcion_Padre);
                    arrParam[5] = new DACRequest.Parameter("@opcic_iNum_Orden", DbType.Int32, 4, poOpcion.Opcic_iNum_Orden);
                    arrParam[6] = new DACRequest.Parameter("@opcic_iInd_Opcion_Critica", DbType.Int32, 4, poOpcion.Opcic_iInd_Opcion_Critica);
                    arrParam[7] = new DACRequest.Parameter("@opcic_iIdUsuario_Modifica", DbType.Int32, 4, poOpcion.Opcic_iIdUsuario_Modifica);
                    arrParam[8] = new DACRequest.Parameter("@vtopc_iIdTip_Opcion", DbType.Int32, 4, poOpcion.Vtopc_iIdTip_Opcion);
                    arrParam[9] = new DACRequest.Parameter("@opcic_vDescripcion", DbType.String, 200, poOpcion.Opcic_vDescripcion);

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
