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
    public class pdt_pedidoDL
    {

#region "No Transactional"

        public DataTable DETALLE_DOCUMENTOS_PENDIENTES
                (
                int pi_iIdPedido
                )
        /* Objetivo	:	Devuelte la cantidad de documentos pendientes de un pedido
         * Author	:	Comsa/Christian Cotaquispe
         * Fecha	:	28/08/2008 - 16:52pm.
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_DOCUMENTOS_PENDIENTES";
                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;

                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iIdPedido);

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
                    throw new Exception("DETALLE_DOCUMENTOS_PENDIENTES: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("DETALLE_DOCUMENTOS_PENDIENTES: " + ex.Message, ex);
            }
        }

        public DataTable Detalle_Estado_Pedido
                    (
                    int pi_iEstadoPedido
                    )
        /* Objetivo	:	Devuelve el estado de un pedido
         * Author	:	Comsa/CC
         * Fecha	:	18/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_ESTADO_PEDIDO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iEstadoPedido);
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
                    throw new Exception("Detalle_Estado_Pedido: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Detalle_Estado_Pedido: " + ex.Message, ex);
            }
        }

        public DataTable Listar_Pedido
            (
            int pi_iCod_Gesneg,
            int pi_iIdPedido,
            string pi_vTelefono_Contacto,
            string pi_vNombre_Cliente,
            int pi_iIdEstado_Pedido,
            int pi_iIdZona,
            int pi_iIdPaquete,
            int pi_iIdFuente_Pedido,
            int pi_iIdSegmento,
            int pi_iIdPrd_Servicio,
            int pi_iIdGrp_Prd,
            int pi_iInd_Marca_Critico
            )
        /* Objetivo	:	Permite listar pedidod.
         * Author	:	Comsa/CC
         * Fecha	:	18/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PEDIDO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[12];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iCod_Gesneg", DbType.Int32, 4, pi_iCod_Gesneg);
                    arrParam[1] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iIdPedido);
                    arrParam[2] = new DACRequest.Parameter("@pdtic_vTelefono_Contacto", DbType.String, 15, pi_vTelefono_Contacto);
                    arrParam[3] = new DACRequest.Parameter("@pdtic_vNombre_Cliente", DbType.String, 120, pi_vNombre_Cliente);
                    arrParam[4] = new DACRequest.Parameter("@vetdc_iIdEstado_Pedido", DbType.Int32, 4, pi_iIdEstado_Pedido);
                    arrParam[5] = new DACRequest.Parameter("@vzonc_iIdZona", DbType.Int32, 4, pi_iIdZona);
                    arrParam[6] = new DACRequest.Parameter("@vpaqc_iIdPaquete", DbType.Int32, 4, pi_iIdPaquete);
                    arrParam[7] = new DACRequest.Parameter("@vfrec_iIdFuente_Pedido", DbType.Int32, 4, pi_iIdFuente_Pedido);
                    arrParam[8] = new DACRequest.Parameter("@segmc_iIdSegmento", DbType.Int32, 4, pi_iIdSegmento);
                    arrParam[9] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pi_iIdPrd_Servicio);
                    arrParam[10] = new DACRequest.Parameter("@vgprc_iIdGrp_Prd", DbType.Int32, 4, pi_iIdGrp_Prd);
                    arrParam[11] = new DACRequest.Parameter("@pdppc_iInd_Marca_Critico", DbType.Int32, 4, pi_iInd_Marca_Critico);
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
                    throw new Exception("Listar_Pedido: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Pedido: " + ex.Message, ex);
            }
        }

        public DataTable Listar_DatosWebSeguimiento(int intNumeroPedidoWeb)
        /* Objetivo	:	Permite listar los pedidos del sistema.
         * Author	:	Comsa/MADC
         * Fecha	:	25/07/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_DATOS_SEGUIMIENTO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", intNumeroPedidoWeb);
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
                    throw new Exception("Listar_DatosWebSeguimiento: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_DatosWebSeguimiento: " + ex.Message, ex);
            }
        }

        public DataTable Listar_DatosGestel(string strNumeroPedidoWeb)
        /* Objetivo	:	Permite listar los pedidos del sistema.
         * Author	:	Comsa/MADC
         * Fecha	:	25/07/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "sp_Listar_DatosGestel";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@strNumeroPedidoWeb", strNumeroPedidoWeb);
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
                    throw new Exception("Listar_Pedidos: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Pedidos: " + ex.Message, ex);
            }
        }

        public DataTable Listar_DatosGesneg(string strNumeroPedidoWeb)
        /* Objetivo	:	Permite listar los pedidos del sistema.
         * Author	:	Comsa/MADC
         * Fecha	:	25/07/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "sp_Listar_DatosGesneg";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@strNumeroPedidoWeb", strNumeroPedidoWeb);
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
                    throw new Exception("Listar_Pedidos: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Pedidos: " + ex.Message, ex);
            }
        }

        public DataTable Listar_HistoricoISIS(string strNumeroPedidoWeb)
        /* Objetivo	:	Permite obtener un registro de gesneg.
         * Author	:	Comsa/MADC
         * Fecha	:	01/08/2008
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "pdt_sp_ListarHistoricoISIS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@strNumeroPedidoWeb", strNumeroPedidoWeb);
                    obRequest.Parameters.AddRange(arrParam);

                    DataSet ds;

                    //Ejecutar Comando.
                    ds = obRequest.Factory.ExecuteDataset(ref obRequest);
                    if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        DataTable dt = ds.Tables[0];
                        //Funciones.Documentar_Tabla(ref dt, "Codigo","Nombre");
                        return dt;

                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception("Obtener_DatosSeguimiento: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Obtener_DatosGesneg: " + ex.Message, ex);
            }
        }

#endregion "No Transactional"


#region "Transactional"

        public int Actualiza_PEDIDO_CRITICO
                    (int pi_iIdPedido,
                     int pi_iIdUsuario_Modifica)
        /* Objetivo	:	Cambia a pedido critico 
         * Author	:	Comsa/Christian Cotaquispe
         * Fecha	:	27/08/2008 - 12:16pm.
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_CAMBIA_PEDIDO_CRITICO";
                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;

                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iIdPedido);
                    arrParam[1] = new DACRequest.Parameter("@pdtic_iIdUsuario_Modifica", DbType.Int32, 4, pi_iIdUsuario_Modifica);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("Actualiza_PEDIDO_CRITICO: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Actualiza_PEDIDO_CRITICO: " + ex.Message, ex);
            }
        }

        
        public int Actualiza_ESTADO_VALIDACION_CONTROL
            (int pi_iIdPedido_Prd,
             int pi_iIdEstado_Pedido,
             int pi_iIdUsuario_Modifica)
        /* Objetivo	:	Actualiza el estado a APROBADO POR CONTROL ó RECHAZADO
         * Author	:	Comsa/Christian Cotaquispe
         * Fecha	:	27/08/2008 - 12:16pm.
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_ESTADO_VALIDACION_CONTROL";
                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;

                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, pi_iIdPedido_Prd);
                    arrParam[1] = new DACRequest.Parameter("@vetdc_iIdEstado_Pedido", DbType.Int32, 4, pi_iIdEstado_Pedido);
                    arrParam[2] = new DACRequest.Parameter("@pdtic_iIdUsuario_Modifica", DbType.Int32, 4, pi_iIdUsuario_Modifica);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("Actualiza_ESTADO_VALIDACION_CONTROL: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Actualiza_ESTADO_VALIDACION_CONTROL: " + ex.Message, ex);
            }
        }

        public int Registrar_Pedido_Manual(PEDIDO pobjPedido)
        /* Objetivo	:	Permite Insertar un nuevo pedido manual.
         * Author	:	Comsa/Christian Cotaquispe A.
         * Fecha	:	01/09/2008
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_PEDIDO_MANUAL";

                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;

                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[11];
                    arrParam[0] = new DACRequest.Parameter("@vzonc_iIdZona", DbType.Int32, 4, pobjPedido.Vzonc_iIdZona);
                    arrParam[1] = new DACRequest.Parameter("@pdtic_vNombre_Contacto", DbType.String, 120, pobjPedido.Pdtic_vNombre_Contacto);
                    arrParam[2] = new DACRequest.Parameter("@pdtic_vTelefono_Contacto", DbType.String, 30, pobjPedido.Pdtic_vTelefono_Contacto);
                    arrParam[3] = new DACRequest.Parameter("@pdtic_iIdUsuario_Vendedor", DbType.Int32, 4, pobjPedido.Pdtic_iIdUsuario_Vendedor);
                    arrParam[4] = new DACRequest.Parameter("@pdtic_vNombre_Cliente", DbType.String, 120, pobjPedido.Pdtic_vNombre_Cliente);
                    arrParam[5] = new DACRequest.Parameter("@vtidc_iIdTip_Doc_Identidad", DbType.Int32, 4, pobjPedido.Vtdoc_iIdTip_Doc);
                    arrParam[6] = new DACRequest.Parameter("@pdtic_vNum_Doc", DbType.String, 20, pobjPedido.Pdtic_vNum_Doc);
                    arrParam[7] = new DACRequest.Parameter("@vpaqc_iIdPaquete", DbType.Int32, 4, pobjPedido.Vpaqc_iIdPaquete);
                    arrParam[8] = new DACRequest.Parameter("@vsegc_iIdSegmento", DbType.Int32, 4, pobjPedido.Segmc_iIdSegmento);
                    arrParam[9] = new DACRequest.Parameter("@vsubc_iIdSub_Segmento", DbType.Int32, 4, pobjPedido.Sessc_iIdSub_Segmento);
                    arrParam[10] = new DACRequest.Parameter("@pdtic_iIdUsuario_Registro", DbType.Int32, 4, pobjPedido.Pdtic_iIdUsuario_Registro);
                    obRequest.Parameters.AddRange(arrParam);

                    //Ejecutar Comando.
                    int res;
                    res = Funciones.CheckInt(obRequest.Factory.ExecuteScalar(ref obRequest));
                    return res;
                }
                catch (Exception ex)
                {
                    throw new Exception("Registrar_Pedido_Manual: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Registrar_Pedido_Manual: " + ex.Message, ex);
            }
        }

        public int Actualiza_ESTADO_PEDIDO_ADMINISTRACION
            (int pi_iIdPedido, 
             int pi_iIdEstado_Pedido, 
             int pi_iIdUsuario_Modifica) 
        /* Objetivo	:	Actualiza Estado Pedido Pedido - pedido_prd 
         * Author	:	Comsa/Christian Cotaquispe
         * Fecha	:	27/08/2008 - 12:16pm.
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_ESTADO_PEDIDO_ADMINISTRACION";
                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;


                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iIdPedido);
                    arrParam[1] = new DACRequest.Parameter("@vetdc_iIdEstado_Pedido", DbType.Int32, 4, pi_iIdEstado_Pedido);
                    arrParam[2] = new DACRequest.Parameter("@pdtic_iIdUsuario_Modifica", DbType.Int32, 4, pi_iIdUsuario_Modifica);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("Actualiza_ESTADO_PEDIDO_ADMINISTRACION: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Actualiza_ESTADO_PEDIDO_ADMINISTRACION: " + ex.Message, ex);
            }
        }

        public int Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION
                    (int pi_iIdPedido,
                     int pi_iIdTip_Ope_Com,
                     int pi_iIdUsuario_Modifica)
        /* Objetivo	:	Actualiza Estado Pedido Pedido - pedido_prd 
         * Author	:	Comsa/Christian Cotaquispe
         * Fecha	:	27/08/2008 - 12:16pm.
         */
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION";
                    obRequest.Parameters.Clear();
                    obRequest.Command = NombreStored;
                    obRequest.CommandType = CommandType.StoredProcedure;


                    //Agregar los Parametros al comando.

                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@pdtic_iIdPedido", DbType.Int32, 4, pi_iIdPedido);
                    arrParam[1] = new DACRequest.Parameter("@tococ_iIdTip_Ope_Com", DbType.Int32, 4, pi_iIdTip_Ope_Com);
                    arrParam[2] = new DACRequest.Parameter("@pdtic_iIdUsuario_Modifica", DbType.Int32, 4, pi_iIdUsuario_Modifica);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION: " + ex.Message, ex);
            }
        }

#endregion "Transactional"

    }
}
