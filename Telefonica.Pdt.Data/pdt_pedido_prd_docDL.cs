using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
   public class pdt_pedido_prd_docDL
   {
       #region "No Transaccionales"
       public DataTable Listar_DocumentoPorPedidoProducto(int pdppc_iIdPedido_Prd)
        {
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_LISTA_PEDIDO_PRD_DOC";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32,4, pdppc_iIdPedido_Prd);
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

       public DataTable Listar_DocumentoPorPedidoProductoTipoDocumetoAdicional(int pdppc_iIdPedido_Prd)
       {
           try
           {
               DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
               try
               {
                   //Identificar Tipo de Comando.
                   string NombreStored = "PDTSS_LISTA_PEDIDO_PRD_DOC_TIP_DOC_ADICIONAL";
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

       #endregion "No Transaccionales"


        #region "Transaccional"

       public int ModificarEstadoDocumento(int ppdoc_iIdPedido_Doc, int vedoc_iIdEstado_Doc, int pptdc_iIdUsuario_Modifica)
       {
           try
           {
               DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
               try
               {
                   //Identificar Tipo de Comando.
                   string NombreStored = "PDTSU_PEDIDO_PRD_DOC_ESTADO_DOCUMENTO";
                   obRequest.CommandType = CommandType.StoredProcedure;
                   obRequest.Command = NombreStored;
                   obRequest.Parameters.Clear();

                   //Agregar los Parametros al comando.
                   DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                   arrParam[0] = new DACRequest.Parameter("@ppdoc_iIdPedido_Doc", DbType.Int32, 4, ppdoc_iIdPedido_Doc);
                   arrParam[1] = new DACRequest.Parameter("@vedoc_iIdEstado_Doc", DbType.Int32, 4, vedoc_iIdEstado_Doc);
                   arrParam[2] = new DACRequest.Parameter("@pptdc_iIdUsuario_Modifica", DbType.Int32, 4, pptdc_iIdUsuario_Modifica);
                   obRequest.Parameters.AddRange(arrParam);

                   //Ejecutar Comando.
                   int retorno = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                   return retorno;

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

       public int ModificarPublicarDocumento(int ppdoc_iIdPedido_Doc,string pptdc_vNombre_Doc_Digital,int pptdc_iIdUsuario_Modifica)
       {
           try
           {
               DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
               try
               {
                   int vedoc_iIdEstado_Doc =Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Publicado);
                   //Identificar Tipo de Comando.
                   string NombreStored = "PDTSU_PEDIDO_PRD_DOC_PUBLICAR_DOCUMENTO";
                   obRequest.CommandType = CommandType.StoredProcedure;
                   obRequest.Command = NombreStored;
                   obRequest.Parameters.Clear();


                   //Agregar los Parametros al comando.
                   DACRequest.Parameter[] arrParam = new DACRequest.Parameter[4];
                   arrParam[0] = new DACRequest.Parameter("@ppdoc_iIdPedido_Doc", DbType.Int32, 4, ppdoc_iIdPedido_Doc);
                   arrParam[1] = new DACRequest.Parameter("@vedoc_iIdEstado_Doc", DbType.Int32, 4, vedoc_iIdEstado_Doc);
                   arrParam[2] = new DACRequest.Parameter("@pptdc_vNombre_Doc_Digital", DbType.String, 20, pptdc_vNombre_Doc_Digital);
                   arrParam[3] = new DACRequest.Parameter("@pptdc_iIdUsuario_Modifica", DbType.Int32, 4, pptdc_iIdUsuario_Modifica);
                   obRequest.Parameters.AddRange(arrParam);

                   //Ejecutar Comando.
                   int retorno = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                   return retorno;

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


       public int InsertarPublicarDocumentoAdicional(int pdppc_iIdPedido_Prd,int vtdoc_iIdTip_Doc, string pptdc_vNombre_Doc_Digital, int pptdc_iIdUsuario_Registro)
       {
           try
           {
               DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
               try
               {
                   int vedoc_iIdEstado_Doc = Convert.ToInt32(Enumeradores.TAB_Val_PedidoProductoEstadoDocumento.Publicado);
                   //Identificar Tipo de Comando.
                   string NombreStored = "PDTSI_PEDIDO_PRD_DOC_PUBLICAR_DOCUMENTO_ADICIONAL";
                   obRequest.CommandType = CommandType.StoredProcedure;
                   obRequest.Command = NombreStored;
                   obRequest.Parameters.Clear();


                   //Agregar los Parametros al comando.
                   DACRequest.Parameter[] arrParam = new DACRequest.Parameter[5];
                   arrParam[0] = new DACRequest.Parameter("@pdppc_iIdPedido_Prd", DbType.Int32, 4, pdppc_iIdPedido_Prd);
                   arrParam[1] = new DACRequest.Parameter("@vedoc_iIdEstado_Doc", DbType.Int32, 4, vedoc_iIdEstado_Doc);
                   arrParam[2] = new DACRequest.Parameter("@vtdoc_iIdTip_Doc", DbType.Int32, 4, vtdoc_iIdTip_Doc);
                   arrParam[3] = new DACRequest.Parameter("@pptdc_vNombre_Doc_Digital", DbType.String, 20, pptdc_vNombre_Doc_Digital);
                   arrParam[4] = new DACRequest.Parameter("@pptdc_iIdUsuario_Registro", DbType.Int32, 4, pptdc_iIdUsuario_Registro);
                   obRequest.Parameters.AddRange(arrParam);

                   //Ejecutar Comando.
                   int retorno = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                   return retorno;

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
