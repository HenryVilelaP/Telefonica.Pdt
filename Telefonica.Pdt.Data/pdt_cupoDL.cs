
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Entities;

namespace Telefonica.Pdt.Data
{
    public class pdt_cupoDL
    {
        # region "No Transaccional"

        public DataTable ListarZonaPedidoAgendado(int provc_iIdProveedor, int prsec_iIdPrd_Servicio, int fechc_iIdFecha)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_ZONA_PEDIDO_AGENDADO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[1] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, prsec_iIdPrd_Servicio);
                    arrParam[2] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, fechc_iIdFecha);
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
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable ListarPedidoAgendado(int provc_iIdProveedor, int prsec_iIdPrd_Servicio, int fechc_iIdFecha,int pdppc_iIdPedido_Prd,int vetdc_iIdEstado_Pedido,int pdppc_iInd_Pedido_Agendado,DateTime? datFechaInicio,DateTime? datFechaFin)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PEDIDO_AGENDADO_INSTALACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[8];
                    arrParam[0] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[1] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, prsec_iIdPrd_Servicio);
                    arrParam[2] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, fechc_iIdFecha);
                    arrParam[3] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, pdppc_iIdPedido_Prd);
                    arrParam[4] = new DACRequest.Parameter("@vetdc_iIdEstado_Pedido", DbType.Int32, 4, vetdc_iIdEstado_Pedido);
                    arrParam[5] = new DACRequest.Parameter("@pdppc_iInd_Pedido_Agendado", DbType.Int32, 4, pdppc_iInd_Pedido_Agendado);
                    arrParam[6] = new DACRequest.Parameter("@datFechaInicio", DbType.Int32, 4, datFechaInicio);
                    arrParam[7] = new DACRequest.Parameter("@datFechaFin", DbType.Int32, 4, datFechaFin);

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
                throw new Exception(ex.Message, ex);
            }
        }

        public DataTable ListarFecha(int fechc_iIdFecha, int provc_iIdProveedor,int prsec_iIdPrd_Servicio, int fechc_iInd_Reg_Abierto, DateTime? datFechaInicio, DateTime? datFechaFin)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_FECHAS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[6];
                    arrParam[0] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, fechc_iIdFecha);
                    arrParam[1] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[2] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, prsec_iIdPrd_Servicio);
                    arrParam[3] = new DACRequest.Parameter("@fechc_iInd_Reg_Abierto", DbType.Int32, 4, fechc_iInd_Reg_Abierto);
                    arrParam[4] = new DACRequest.Parameter("@datFechaInicio", DbType.DateTime, 16, datFechaInicio);
                    arrParam[5] = new DACRequest.Parameter("@datFechaFin", DbType.DateTime, 16, datFechaFin);
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
                throw new Exception(ex.Message, ex);
            }
        }

        public DataSet Listar(int cupoc_iIdCupo, int provc_iIdProveedor, int grpic_iIdGrp_Instalacion, int fechc_iIdFecha, int prsec_iIdPrd_Servicio)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PROVEEDOR_GRP_INSTALACION_CUPOS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[5];
                    arrParam[0] = new DACRequest.Parameter("@cupoc_iIdCupo", DbType.Int32, 4, cupoc_iIdCupo);
                    arrParam[1] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[2] = new DACRequest.Parameter("@grpic_iIdGrp_Instalacion", DbType.Int32, 4, grpic_iIdGrp_Instalacion);
                    arrParam[3] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, fechc_iIdFecha);
                    arrParam[4] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio",DbType.Int32,4,prsec_iIdPrd_Servicio);
                    obRequest.Parameters.AddRange(arrParam);
                    DataSet ds;
                    //Ejecutar Comando.
                    ds = obRequest.Factory.ExecuteDataset(ref obRequest);
                    if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
                    {
                        return ds;
                    }
                    return null;
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
                throw new Exception(ex.Message, ex);
            }
        }
        
        public DataTable ListarProveedores(int provc_iIdProveedor, string provc_vRazon_Social, string provc_vRUC)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PROVEEDOR";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[1] = new DACRequest.Parameter("@provc_vRazon_Social", DbType.String, 120, provc_vRazon_Social);
                    arrParam[2] = new DACRequest.Parameter("@provc_vRUC", DbType.String, 11, provc_vRUC);
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
                throw new Exception(ex.Message, ex);
            }
        }
        
        public DataTable ListarGrupoInstalacion(int grpic_iIdGrp_Instalacion, int zgrpc_iIdZona_Grp_Instalacion, string grpic_vDescripcion)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_GRP_INSTALACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@grpic_iIdGrp_Instalacion", DbType.Int32, 4, grpic_iIdGrp_Instalacion);
                    arrParam[1] = new DACRequest.Parameter("@zgrpc_iIdZona_Grp_Instalacion", DbType.Int32, 4, zgrpc_iIdZona_Grp_Instalacion);
                    arrParam[2] = new DACRequest.Parameter("@grpic_vDescripcion", DbType.String, 100, grpic_vDescripcion);
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
                throw new Exception(ex.Message, ex);
            }
        }
        
        #endregion "No Transaccional"

        #region "Transaccional"
        
        public int AsignarCupo(int pdppc_iIdPedido_Prd, int cupoc_iIdCupo, int pdppc_iIdUsuario_Modifica)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_ASIGNA_CUPOS_INSTALACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, pdppc_iIdPedido_Prd);
                    arrParam[1] = new DACRequest.Parameter("@cupoc_iIdCupo", DbType.Int32, 4, cupoc_iIdCupo);
                    arrParam[2] = new DACRequest.Parameter("@pdppc_iIdUsuario_Modifica", DbType.Int32, 4, pdppc_iIdUsuario_Modifica);
                    obRequest.Parameters.AddRange(arrParam);
                    int retorno;
                    //Ejecutar Comando.
                    retorno = obRequest.Factory.ExecuteNonQuery(ref obRequest);
                    if (retorno > 0)
                    {
                        return retorno;
                    }
                    return 0;
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
                throw new Exception(ex.Message, ex);
            }
        }

        public int CierraReAbreFecha(int grpic_iIdGrp_Instalacion,int cupoc_iInd_Cierre_Cupo ,int cupoc_iEstado_Registro,int cupoc_iIdUsuario_Modifica ,int provc_iIdProveedor ,int fechc_iIdFecha ,int prsec_iIdPrd_Servicio )
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_CIERRA_REABRE_FECHA";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[7];

                    arrParam[0] = new DACRequest.Parameter("@grpic_iIdGrp_Instalacion", DbType.Int32, 4, grpic_iIdGrp_Instalacion);
                    arrParam[1] = new DACRequest.Parameter("@cupoc_iInd_Cierre_Cupo", DbType.Int32, 4, cupoc_iInd_Cierre_Cupo);
                    arrParam[2] = new DACRequest.Parameter("@cupoc_iEstado_Registro", DbType.Int32, 4, cupoc_iEstado_Registro);
                    arrParam[3] = new DACRequest.Parameter("@cupoc_iIdUsuario_Modifica", DbType.Int32, 4, cupoc_iIdUsuario_Modifica);
                    arrParam[4] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, provc_iIdProveedor);
                    arrParam[5] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, fechc_iIdFecha);
                    arrParam[6] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, prsec_iIdPrd_Servicio);
                    obRequest.Parameters.AddRange(arrParam);
                    int retorno;
                    //Ejecutar Comando.
                    retorno = obRequest.Factory.ExecuteNonQuery(ref obRequest);
                    if (retorno > 0)
                    {
                        return retorno;
                    }
                    return 0;
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
                throw new Exception(ex.Message, ex);
            }
        }

        public int Insertar(CUPO pobjcupo)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_CUPO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[10];
                    arrParam[0] = new DACRequest.Parameter("@cupoc_iCanti_Cupo_Asignada", DbType.Int32, 4, pobjcupo.Cupoc_iCanti_Cupo_Asignada);
                    arrParam[1] = new DACRequest.Parameter("@cupoc_iCanti_Cupo_Disponible", DbType.Int32, 4, pobjcupo.Cupoc_iCanti_Cupo_Disponible);
                    arrParam[2] = new DACRequest.Parameter("@vfhoc_iIdFranja_Horaria", DbType.Int32, 4, pobjcupo.Vfhoc_iIdFranja_Horaria);
                    arrParam[3] = new DACRequest.Parameter("@grpic_iIdGrp_Instalacion", DbType.Int32, 4, pobjcupo.Grpic_iIdGrp_Instalacion);
                    arrParam[4] = new DACRequest.Parameter("@cupoc_iInd_Cierre_Cupo", DbType.Int32, 4, pobjcupo.Cupoc_iInd_Cierre_Cupo);
                    arrParam[5] = new DACRequest.Parameter("@cupoc_iEstado_Registro", DbType.Int32, 4, pobjcupo.Cupoc_iEstado_Registro);
                    arrParam[6] = new DACRequest.Parameter("@cupoc_iIdUsuario_Registro", DbType.Int32, 4, pobjcupo.Cupoc_iIdUsuario_Registro);
                    arrParam[7] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32, 4, pobjcupo.Provc_iIdProveedor);
                    arrParam[8] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, pobjcupo.Fechc_iIdFecha);
                    arrParam[9] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjcupo.Prsec_iIdPrd_Servicio);
                                       
                    obRequest.Parameters.AddRange(arrParam);
                    int retorno;
                    //Ejecutar Comando.
                    retorno = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));
                    if (retorno > 0)
                    {
                        return retorno;
                    }
                    return 0;
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
                throw new Exception(ex.Message, ex);
            }
        }

        public int Modificar(CUPO pobjcupo)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_CUPO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[11];                                        
                    arrParam[0] = new DACRequest.Parameter("@cupoc_iIdCupo", DbType.Int32, 4, pobjcupo.Cupoc_iIdCupo);
                    arrParam[1] = new DACRequest.Parameter("@cupoc_iCanti_Cupo_Asignada", DbType.Int32, 4, pobjcupo.Cupoc_iCanti_Cupo_Asignada);
                    arrParam[2] = new DACRequest.Parameter("@cupoc_iCanti_Cupo_Disponible", DbType.Int32, 4, pobjcupo.Cupoc_iCanti_Cupo_Disponible);
                    arrParam[3] = new DACRequest.Parameter("@vfhoc_iIdFranja_Horaria", DbType.Int32, 4, pobjcupo.Vfhoc_iIdFranja_Horaria);
                    arrParam[4] = new DACRequest.Parameter("@grpic_iIdGrp_Instalacion", DbType.Int32, 4, pobjcupo.Grpic_iIdGrp_Instalacion);
                    arrParam[5] = new DACRequest.Parameter("@cupoc_iInd_Cierre_Cupo", DbType.Int32,4, pobjcupo.Cupoc_iInd_Cierre_Cupo);
                    arrParam[6] = new DACRequest.Parameter("@cupoc_iEstado_Registro", DbType.Int32,4, pobjcupo.Cupoc_iEstado_Registro);
                    arrParam[7] = new DACRequest.Parameter("@cupoc_iIdUsuario_Modifica", DbType.Int32, 4, pobjcupo.Cupoc_iIdUsuario_Modifica);
                    arrParam[8] = new DACRequest.Parameter("@provc_iIdProveedor", DbType.Int32,4, pobjcupo.Provc_iIdProveedor);
                    arrParam[9] = new DACRequest.Parameter("@fechc_iIdFecha", DbType.Int32, 4, pobjcupo.Fechc_iIdFecha);
                    arrParam[10] = new DACRequest.Parameter("@prsec_iIdPrd_Servicio", DbType.Int32, 4, pobjcupo.Prsec_iIdPrd_Servicio);
                                        
                    obRequest.Parameters.AddRange(arrParam);
                    int retorno;
                    //Ejecutar Comando.
                    retorno = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));
                    //if (retorno > 0)
                    //{
                        return retorno;
                    //}
                    //return 0;
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
                throw new Exception(ex.Message, ex);
            }
        }

        public int Eliminar(int cupoc_iIdCupo, int pdppc_iIdUsuario_Modifica)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSD_CUPO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();
                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@cupoc_iIdCupo", DbType.Int32, 4, cupoc_iIdCupo);
                    arrParam[1] = new DACRequest.Parameter("@pdppc_iIdUsuario_Modifica", DbType.Int32, 4, pdppc_iIdUsuario_Modifica);
                    obRequest.Parameters.AddRange(arrParam);
                    int retorno;
                    //Ejecutar Comando.
                    retorno = obRequest.Factory.ExecuteNonQuery(ref obRequest);
                    if (retorno > 0)
                    {
                        return retorno;
                    }
                    return 0;
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
                throw new Exception(ex.Message, ex);
            }
        }

        #endregion "Transaccional"
    }
}
