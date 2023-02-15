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
        public class pdt_bitacoraDL
    {

        #region "No Transaccional"

            public DataTable Listar_Datos_Historico_Seguimiento(int pi_iIdPedido_Prd)
        /* Objetivo	:	Obtiene un listado de observaciones de un pedido.
         * Author	:	Comsa/CSCA
         * Fecha	:	25/08/2008
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_DATOS_HISTORICO_SEGUIMIENTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", pi_iIdPedido_Prd);
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
                    throw new Exception("Listar_Datos_Historico_Seguimiento: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Datos_Historico_Seguimiento: " + ex.Message, ex);
            }
        }
        #endregion "No Transaccional"

        #region "Transaccional"

            public int Insertar(BITACORA poBitacora)
            /* 
            *  Objetivo	:	Permite insertar datos nuevos en la tabla BITACORA.
            *  Author	:	Comsa/Christian Cotaquispe
            *  Fecha	:	26/08/2008
            */
            {
                //Establecer la Conexion.
                try
                {
                    DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                    try
                    {
                        //Identificar Tipo de Comando.
                        string NombreStored = "PDTSI_NUEVA_BITACORA";
                        obRequest.CommandType = CommandType.StoredProcedure;
                        obRequest.Command = NombreStored;
                        obRequest.Parameters.Clear();

                        //Agregar los Parametros al comando.
                        DACRequest.Parameter[] arrParam = new DACRequest.Parameter[5];
                        arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, poBitacora.Pdtic_iIdPedido);
                        arrParam[1] = new DACRequest.Parameter("@cobic_vDescripcion", DbType.String, 200, poBitacora.Cobic_vDescripcion);
                        arrParam[2] = new DACRequest.Parameter("@vdesc_iIdDestino", DbType.Int32, 4, poBitacora.Vdesc_iIdDestino);
                        arrParam[3] = new DACRequest.Parameter("@vtrac_iIdTratamiento", DbType.Int32, 4, poBitacora.Vtrac_iIdTratamiento);
                        arrParam[4] = new DACRequest.Parameter("@cobic_iIdUsuario_Registro", DbType.Int32, 4, poBitacora.Cobic_iIdUsuario_Registro);

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
