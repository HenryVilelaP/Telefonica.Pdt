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
    public class pdt_tr_origenesDL
    {

  #region "No Transaccionales"

        public FUENTE_PEDIDO_LEGACIE DetalleFuentePedidoLegacie(int IdPedidoProducto)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_OBTENER_FUENTE_PEDIDO_LEGACIE";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, IdPedidoProducto);

                    obRequest.Parameters.AddRange(arrParam);

                    FUENTE_PEDIDO_LEGACIE oBE = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oBE = new FUENTE_PEDIDO_LEGACIE();

                        oBE.Pdppc_iIdPedido_Prd = Convert.ToInt32(dr["Pdppc_iIdPedido_Prd"]);
                        oBE.Vfrec_iIdFuente_Pedido = NullableTypes.ConvertNullInt32(dr["Vfrec_iIdFuente_Pedido"]);
                        oBE.Pdtic_nCod_Pedido_Legacie = NullableTypes.ConvertNullDecimal(dr["Pdtic_nCod_Pedido_Legacie"]);

                        return oBE;

                    }

                    dr.Close();

                    return oBE;

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

        public TR_ISIS Detalle_TR_ISIS(int CodigoRegistro)
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_TR_ISIS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@codreg", DbType.Int32, 4, CodigoRegistro);

                    obRequest.Parameters.AddRange(arrParam);

                    TR_ISIS oBE = null;
                    IDataReader dr;
                    
                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oBE = new TR_ISIS();

                        oBE.Codreg = Convert.ToInt32(dr[Enumeradores.Col_TR_ISIS.codreg.ToString()]);
                        oBE.FechaEmision = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_TR_ISIS.FechaEmision.ToString()]);
                        oBE.HoraEmision = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.HoraEmision.ToString()]);
                        oBE.Servicio = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.servicio.ToString()]);
                        oBE.Codcliente=Convert.ToDecimal(dr[Enumeradores.Col_TR_ISIS.codcliente.ToString()]);
                        oBE.Nombrecliente = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.Nombrecliente.ToString()]);
                        oBE.NombreSituacion = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.NombreSituacion.ToString()]);
                        oBE.Segmento = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.segmento.ToString()]);
                        oBE.SubSegmento = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.SubSegmento.ToString()]);
                        oBE.Circuito = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TR_ISIS.circuito.ToString()]);
                        oBE.CodAccion1 = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.CodAccion1.ToString()]);
                        oBE.Accion1 = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.Accion1.ToString()]);
                        oBE.Fechapedido = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_TR_ISIS.Fechapedido.ToString()]);
                        oBE.NroPedido = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TR_ISIS.NroPedido.ToString()]);
                        oBE.CodAccion2 = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.CodAccion2.ToString()]);
                        oBE.Accion2 = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.Accion2.ToString()]);
                        oBE.Prereg = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.Prereg.ToString()]);
                        oBE.EjecutivoServicio = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.EjecutivoServicio.ToString()]);
                        oBE.EjecutivoAtencion = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.EjecutivoAtencion.ToString()]);
                        oBE.PreDoc = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.PreDoc.ToString()]);
                        oBE.NoDoc = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_ISIS.NoDoc.ToString()]);
                        oBE.FecRegistro = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_TR_ISIS.FecRegistro.ToString()]);
                        oBE.FecDoc=NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_TR_ISIS.FecDoc.ToString()]);
                        oBE.PendLiq = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.PendLiq.ToString()]);
                        oBE.Marca = Convert.ToString(dr[Enumeradores.Col_TR_ISIS.Marca.ToString()]);
                        oBE.UltimaSecEst = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TR_ISIS.UltimaSecEst.ToString()]);
         
                        return oBE;

                    }

                    dr.Close();

                    return oBE;

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

        public TR_GESTEL Detalle_TR_GESTEL(int CodigoRegistro)
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_TR_GESTEL";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pedido", DbType.Int32, 4, CodigoRegistro);

                    obRequest.Parameters.AddRange(arrParam);

                    TR_GESTEL oBE = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oBE = new TR_GESTEL();

                        oBE.Zonal = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.zonal.ToString()]);
                        oBE.Ciudad = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.ciudad.ToString()]);
                        oBE.Pedido = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.pedido.ToString()]);
                        oBE.Inscripcion = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Inscripcion.ToString()]);
                        oBE.Telefono = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.telefono.ToString()]);
                        oBE.Servicio = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.servicio.ToString()]);
                        oBE.Movimiento = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.movimiento.ToString()]);
                        oBE.FecRegistro = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.fecRegistro.ToString()]);
                        oBE.Cod_negocio = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Cod_negocio.ToString()]);
                        oBE.Estado = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.estado.ToString()]);
                        oBE.Prom_mig = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.prom_mig.ToString()]);
                        oBE.Prom_act = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.prom_act.ToString()]);
                        oBE.Ooss = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.ooss.ToString()]);
                        oBE.Fec_planta_interna = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.fec_planta_interna.ToString()]);
                        oBE.Planta_interna = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.planta_interna.ToString()]);
                        oBE.Estado_planta_interna = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.estado_planta_interna.ToString()]);
                        oBE.Urd_planta_interna = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.urd_planta_interna.ToString()]);
                        oBE.Fec_planta_externa = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.fec_planta_externa.ToString()]);
                        oBE.Planta_externa = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.planta_externa.ToString()]);
                        oBE.Estado_planta_externa = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.estado_planta_externa.ToString()]);
                        oBE.Urd_planta_externa = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.urd_planta_externa.ToString()]);
                        oBE.Fec_mdf = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.fec_mdf.ToString()]);
                        oBE.Mdf = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.mdf.ToString()]);
                        oBE.Estado_mdf = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.estado_mdf.ToString()]);
                        oBE.Urd_mdf = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.urd_mdf.ToString()]);
                        oBE.Fec_red_inteligente = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.fec_red_inteligente.ToString()]);
                        oBE.Red_inteligente = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.red_inteligente.ToString()]);
                        oBE.Estado_Red_Inteligente = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Estado_Red_Inteligente.ToString()]);
                        oBE.Urd_red_inteligente = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.urd_red_inteligente.ToString()]);
                        oBE.Cod_observacion = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.cod_observacion.ToString()]);
                        oBE.Col031 = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Col031.ToString()]);
                        oBE.Observacion = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.observacion.ToString()]);
                        oBE.Dice_tecnico = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.dice_tecnico.ToString()]);
                        oBE.Usuario_reg = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.usuario_reg.ToString()]);
                        oBE.Cod_clasificacion = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.cod_clasificacion.ToString()]);
                        oBE.Cod_tecnologia = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.cod_tecnologia.ToString()]);
                        oBE.Tecnologia = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.tecnologia.ToString()]);
                        oBE.Segmento = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.segmento.ToString()]);
                        oBE.Segmento_emp = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.segmento_emp.ToString()]);
                        oBE.Medio_util = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.medio_util.ToString()]);
                        oBE.Cod_circuito = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.cod_circuito.ToString()]);
                        oBE.Col042 = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Col042.ToString()]);
                        oBE.Speedy_tipo = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.speedy_tipo.ToString()]);
                        oBE.Speedy_Velocidad = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Speedy_Velocidad.ToString()]);
                        oBE.Speedy_Equipo = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Speedy_Equipo.ToString()]);
                        oBE.Ruta_Cobro = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Ruta_Cobro.ToString()]);
                        oBE.Cod_Central = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Cod_Central.ToString()]);
                        oBE.Col048 = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Col048.ToString()]);
                        oBE.Desc_Segmento = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Desc_Segmento.ToString()]);
                        oBE.Cliente = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Cliente.ToString()]);
                        oBE.Cuc = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Cuc.ToString()]);
                        oBE.Tipo_operacion_comercial = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.tipo_operacion_comercial.ToString()]);
                        oBE.Modalidad = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.modalidad.ToString()]);
                        oBE.Producto = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.producto.ToString()]);
                        oBE.Cod_registro_manual = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_GESTEL.cod_registro_manual.ToString()]);
                        oBE.Subsegmento = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.subsegmento.ToString()]);
                        oBE.Cruce_segmento = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.Cruce_segmento.ToString()]);
                        oBE.Id_tipo_Operacion_Comercial = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_GESTEL.id_tipo_Operacion_Comercial.ToString()]);
                        oBE.Id_producto = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_GESTEL.id_producto.ToString()]);
                        oBE.Id_vendedor = Convert.ToString(dr[Enumeradores.Col_TR_GESTEL.id_vendedor.ToString()]);
                        oBE.Id_segmento = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_GESTEL.id_segmento.ToString()]);
                        oBE.Ind_ya_registrado = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TR_GESTEL.Ind_ya_registrado.ToString()]);
                        oBE.Id_zonal = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TR_GESTEL.id_zonal.ToString()]);

                        return oBE;

                    }

                    dr.Close();

                    return oBE;

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

        public TR_SPEEDYSIG_GENERICS Detalle_TR_SPEEDYSIG(decimal CodigoRegistro)
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALLE_TR_SPEEDYSIG";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@Pedido_Numerico", DbType.Decimal , 14, CodigoRegistro);

                    obRequest.Parameters.AddRange(arrParam);

                    TR_SPEEDYSIG_GENERICS oTR_SPEEDYSIG_GENERICS = new TR_SPEEDYSIG_GENERICS();

                    TR_SPEEDYSIG oBE = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oBE = new TR_SPEEDYSIG();

                        oBE.Pedido=Convert.ToString(dr["Pedido"]);
                        oBE.Empresa=Convert.ToString(dr["Empresa"]);
                        oBE.Segmento=Convert.ToString(dr["Segmento"]);
                        oBE.Estado=Convert.ToString(dr["Estado"]);
                        oBE.Telefono = Convert.ToDecimal(dr["Telefono"]);
                        oBE.Inscripcion=NullableTypes.ConvertNullDecimal(dr["Inscripcion"]);
                        oBE.Fecha_Registro=NullableTypes.ConvertNullDateTime(dr["Fecha_Registro"]);
                        oBE.Fecha_liquidacion=NullableTypes.ConvertNullDateTime(dr["Fecha_liquidacion"]);
                        oBE.Fecha_Devolucion=Convert.ToString(dr["Fecha_Devolucion"]);
                        oBE.Motivo_Devolucion=Convert.ToString(dr["Motivo_Devolucion"]);
                        oBE.Fecha_Reprogramacion=NullableTypes.ConvertNullDateTime(dr["Fecha_Reprogramacion"]);
                        oBE.Motivo_Reprogramacion=Convert.ToString(dr["Motivo_Reprogramacion"]);
                        oBE.Fecha_Cancelacion=NullableTypes.ConvertNullDateTime(dr["Fecha_Cancelacion"]);
                        oBE.Motivo_Cancelacion=Convert.ToString(dr["Motivo_Cancelacion"]);
                        oBE.Ciudad=Convert.ToString(dr["Ciudad"]);
                        oBE.Ciclo_Fact=NullableTypes.ConvertNullInt32(dr["Ciclo_Fact"]);
                        oBE.Cod_Cliente=NullableTypes.ConvertNullDecimal(dr["Cod_Cliente"]);
                        oBE.Cliente=Convert.ToString(dr["Cliente"]);
                        oBE.Direccion=Convert.ToString(dr["Direccion"]);
                        oBE.Referencia=Convert.ToString(dr["Referencia"]);
                        oBE.Cod_Facturacion=NullableTypes.ConvertNullDecimal(dr["Cod_Facturacion"]);
                        oBE.Persona_Contacto=Convert.ToString(dr["Persona_Contacto"]);
                        oBE.Fono_Contacto=NullableTypes.ConvertNullDecimal(dr["Fono_Contacto"]);
                        oBE.Cod_Vendedor=NullableTypes.ConvertNullDecimal(dr["Cod_Vendedor"]);
                        oBE.Vendedor = Convert.ToString(dr["Vendedor"]);
                        oBE.Tipo_cliente = Convert.ToString(dr["Tipo_cliente"]);
                        oBE.Canal_de_venta = Convert.ToString(dr["Canal_de_venta"]);
                        oBE.Pedido_Numerico=NullableTypes.ConvertNullDecimal(dr["Pedido_Numerico"]);
                        oBE.Q_pcs = NullableTypes.ConvertNullInt32(dr["Q_pcs"]);

                    }

                    oTR_SPEEDYSIG_GENERICS.Cabecera_TR_SPEEDYSIG = oBE;
                    dr.NextResult();

                    oBE = null;
                    while (dr.Read())
                    {
                        oBE = new TR_SPEEDYSIG();
                        oBE.Producto = Convert.ToString(dr["Producto"]);
                        oBE.Paquete = Convert.ToString(dr["Paquete"]);
                        oBE.Cant = NullableTypes.ConvertNullInt32(dr["Cant"]);
                        oBE.NroSerie = Convert.ToString(dr["NroSerie"]);
                        oBE.Peroodo = Convert.ToString(dr["Peroodo"]);
                        oBE.Estado1 = Convert.ToString(dr["Estado1"]);
                        oBE.Tipo_cliente = Convert.ToString(dr["Tipo_Cliente"]);
                        oBE.Cpu = Convert.ToString(dr["Cpu"]);
                        oBE.RAM = Convert.ToString(dr["RAM"]);
                        oBE.SistemaOperativo = Convert.ToString(dr["SistemaOperativo"]);
                        oBE.Procesador = Convert.ToString(dr["Procesador"]);
                        oTR_SPEEDYSIG_GENERICS.DetalleItemsPedidos.Add(oBE);
                    }

                    
                    dr.Close();

                    return oTR_SPEEDYSIG_GENERICS;

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


        public void Listar_TR_WEBRPS_Datos(int pdppc_iIdPedido_Prd,ref DataTable dtCabeceraPedidoWebRPS,ref DataTable dtDetallePedidoWebRPS)
        {
            dtCabeceraPedidoWebRPS = null;
            dtDetallePedidoWebRPS = null;
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_TR_WEBRPS_NUMERO_PEDIDO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, pdppc_iIdPedido_Prd);
                    obRequest.Parameters.AddRange(arrParam);

                    DataSet ds;

                    //Ejecutar Comando.
                    ds = obRequest.Factory.ExecuteDataset(ref obRequest);
                    if((ds!=null)&&(ds.Tables.Count > 0))
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dtCabeceraPedidoWebRPS = ds.Tables[0];
                        }
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            dtDetallePedidoWebRPS = ds.Tables[1];
                        }
                    }
                }
                catch (Exception ex)
                {
                    /* Finalizando Variables de retorno en caso de Error */
                    dtCabeceraPedidoWebRPS = null;
                    dtDetallePedidoWebRPS = null;
                    /* */
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


    #endregion "No Transaccionales"


    }

  
}
