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
    public class pdt_accionDL
    {
        public pdt_accionDL()
        {
        }

        #region "No Transaccional"

        public DataTable Listar()
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
                    string NombreStored = "PDTSS_LISTA_ACCION";
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
                    throw new Exception("Listar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar: " + ex.Message, ex);
            }
        }

        public SG_ACCION Detalle(Int32 piIdAccion)
        /* 
         * Objetivo	:	Permite obtener una accion por su Id.
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
                    string NombreStored = "PDTSS_DETALLE_SG_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, piIdAccion);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_ACCION oSG_ACCION = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oSG_ACCION = new SG_ACCION();

                        oSG_ACCION.Accic_iIdAccion = Convert.ToInt32(dr[Enumeradores.Col_SG_ACCION.accic_iIdAccion.ToString()]);
                        oSG_ACCION.Accic_vNombre_Accion = Convert.ToString(dr[Enumeradores.Col_SG_ACCION.accic_vNombre_Accion.ToString()]);
                        oSG_ACCION.Accic_vDescripcion = Convert.ToString(dr[Enumeradores.Col_SG_ACCION.accic_vDescripcion.ToString()]);

                        return oSG_ACCION;

                    }

                    dr.Close();

                    return oSG_ACCION;

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

        #endregion

        #region "Transaccional"

        public int Insertar(SG_ACCION poAccion)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_ACCION.
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
                    string NombreStored = "PDTSI_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@accic_vDescripcion", DbType.String, 200, poAccion.Accic_vDescripcion);
                    arrParam[1] = new DACRequest.Parameter("@accic_vNombre_Accion", DbType.String, 40, poAccion.Accic_vNombre_Accion);
                    arrParam[2] = new DACRequest.Parameter("@accic_iUsuario_Registro", DbType.Int32, 4, poAccion.Accic_iUsuario_Registro);

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

        public int Modificar(SG_ACCION poAccion)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_ACCION.
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
                    string NombreStored = "PDTSU_SG_ACCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                    arrParam[0] = new DACRequest.Parameter("@accic_iIdAccion", DbType.Int32, 4, poAccion.Accic_iIdAccion);
                    arrParam[1] = new DACRequest.Parameter("@accic_vDescripcion", DbType.String, 200, poAccion.Accic_vDescripcion);
                    arrParam[2] = new DACRequest.Parameter("@accic_vNombre_Accion", DbType.String, 40, poAccion.Accic_vNombre_Accion);
                    arrParam[3] = new DACRequest.Parameter("@accic_iUsuario_Modifica", DbType.Int32, 4, poAccion.Accic_iUsuario_Modifica);

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

        #endregion


    }
}
