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
    public class pdt_sg_tip_opcionDL
    {
        public pdt_sg_tip_opcionDL()
        {
        }

        #region "No Transaccional"

        public DataTable Lista_Tipo_Opcion()
        /* 
         * Objetivo	:	Permite listar los tipos de opciones de seguridad.
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
                    string NombreStored = "PDTSS_LISTA_TIP_OPCION";
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
                    throw new Exception("Lista_Tipo_Opcion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lista_Tipo_Opcion: " + ex.Message, ex);
            }
        }

        public SG_TIP_OPCION Detalle(Int32 piIdTip_Opcion)
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
                    string NombreStored = "PDTSS_DETALLE_TIP_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@vtopc_iIdTip_Opcion", DbType.Int32, 4, piIdTip_Opcion);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_TIP_OPCION oSG_TIP_OPCION = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oSG_TIP_OPCION = new SG_TIP_OPCION();

                        oSG_TIP_OPCION.Vtopc_iIdTip_Opcion = Convert.ToInt32(dr[Enumeradores.Col_SG_TIP_OPCION.vtopc_iIdTip_Opcion.ToString()]);
                        oSG_TIP_OPCION.VDescripcion = Convert.ToString(dr[Enumeradores.Col_SG_TIP_OPCION.vDescripcion.ToString()]);

                        return oSG_TIP_OPCION;

                    }

                    dr.Close();

                    return oSG_TIP_OPCION;

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

        public int Insertar(SG_TIP_OPCION poTipoOpcion)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_TIP_OPCION.
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
                    string NombreStored = "PDTSI_SG_TIP_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@vDescripcion", DbType.String, 100, poTipoOpcion.VDescripcion);

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

        public int Modificar(SG_TIP_OPCION poTipoOpcion)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_TIP_OPCION.
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
                    string NombreStored = "PDTSU_SG_TIP_OPCION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@vtopc_iIdTip_Opcion", DbType.Int32, 4, poTipoOpcion.Vtopc_iIdTip_Opcion);
                    arrParam[1] = new DACRequest.Parameter("@vDescripcion", DbType.String, 100, poTipoOpcion.VDescripcion);

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
