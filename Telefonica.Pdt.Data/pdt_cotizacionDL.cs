using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
    public class pdt_cotizacionDL
    {
        public DataTable Listar(string pstrRUC, string pstrCodigoClienteAtis, string pstrNumeroCotizacion,
                                int pintEstadoCotizacion, string pstrNombreCliente,
                                DateTime? pdtFechaInicio, DateTime? pdtFechaFin)
        /* Objetivo	:	Permite listar los datos de varias cotizaciones.
         * Author	:	Comsa/MD
         * Fecha	:	14/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_COTIZACION_POR_FILTROS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[6];
                    arrParam[0] = new DACRequest.Parameter("@cotic_vRuc", DbType.String, 15, pstrRUC);
                    arrParam[1] = new DACRequest.Parameter("@cotic_vNum_Cotizacion", DbType.String, 20, pstrNumeroCotizacion);
                    arrParam[2] = new DACRequest.Parameter("@vectc_iIdEstado_Cotizacion", DbType.Int32, 4, pintEstadoCotizacion);
                    arrParam[3] = new DACRequest.Parameter("@cotic_vNombre_Cliente", DbType.String, 120, pstrNombreCliente);
                    arrParam[4] = new DACRequest.Parameter("@cotic_dFec_Registro_Inicio", DbType.DateTime, pdtFechaInicio);
                    arrParam[5] = new DACRequest.Parameter("@cotic_dFec_Registro_Fin", DbType.DateTime, pdtFechaFin);
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
                    throw new Exception("pdt_CotizacionDL.Listar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Listar: " + ex.Message, ex);
            }
        }

        public COTIZACION Obtener(int pintIdCotizacion)
        /* Objetivo	:	Permite obtener los datos de una cotización.
         * Author	:	Comsa/MD
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
                    string NombreStored = "PDTSS_OBTENER_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    COTIZACION objCotizacion;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objCotizacion = new COTIZACION();
                        objCotizacion.Cotic_iIdCotizacion = reader.GetInt32(0);
                        objCotizacion.Cotic_iNum_Cotizacion = reader.GetInt32(1);
                        objCotizacion.Cotic_iNum_Cotizacion_Version = reader.GetInt32(2);
                        objCotizacion.Vtpec_iIdTip_Persona = reader.GetInt32(3);
                        objCotizacion.Vtidc_iIdTip_Doc_Identidad = reader.GetInt32(4);
                        objCotizacion.Cotic_vNum_Doc = reader.GetString(5);
                        objCotizacion.Cotic_vRazon_Social = reader.GetString(6);
                        objCotizacion.Cotic_vNombre_Cliente =  reader.GetString(7);
                        objCotizacion.Cotic_vApellido_Paterno = reader.GetString(8);
                        objCotizacion.Cotic_vApellido_Materno = reader.GetString(9);
                        objCotizacion.Cotic_vTelefono_Referencia = reader.GetString(10);
                        objCotizacion.Cotic_vTelefono_Contacto = reader.GetString(11);
                        objCotizacion.Cotic_iCodigo_Carterizado = NullableTypes.ConvertNullInt32(reader[12]);
                        objCotizacion.Cotic_vNombre_Persona_Contacto = reader.GetString(13);
                        objCotizacion.Vcavc_iIdCanal_Venta = NullableTypes.ConvertNullInt32(reader[14]);
                        objCotizacion.Cotic_vCuc = reader.GetString(15);
                        objCotizacion.Cotic_iIdCliente_Atis = NullableTypes.ConvertNullInt32(reader[16]);
                        objCotizacion.Vviac_iIdTip_Via_Instalacion = NullableTypes.ConvertNullInt32(reader[17]);
                        objCotizacion.Cotic_vNombre_Via_Instalacion = reader.GetString(18);
                        objCotizacion.Cotic_iNum_Via_Instalacion = NullableTypes.ConvertNullInt32(reader[19]);
                        objCotizacion.Vdepc_vIdDepartamento_Instalacion = Convert.ToString(reader[20]);
                        objCotizacion.Vproc_vIdProvincia_Instalacion = Convert.ToString(reader[21]);
                        objCotizacion.Vdisc_vIdDistrito_Instalacion = Convert.ToString(reader[22]);
                        objCotizacion.Vviac_iIdTip_Via_Facturacion = NullableTypes.ConvertNullInt32(reader[23]);
                        objCotizacion.Cotic_vNombre_Via_Facturacion = Convert.ToString(reader[24]);
                        objCotizacion.Cotic_iNum_Via_Facturacion = NullableTypes.ConvertNullInt32(reader[25]);
                        objCotizacion.Vdepc_vIdDepartamento_Facturacion = Convert.ToString(reader[26]);
                        objCotizacion.Vproc_vIdProvincia_Facturacion = Convert.ToString(reader[27]);
                        objCotizacion.Vdisc_vIdDistrito_Facturacion = Convert.ToString(reader[28]);
                        objCotizacion.Paqtc_iIdPaquete = NullableTypes.ConvertNullInt32(reader[29]);
                        objCotizacion.Segmc_iIdSegmento = NullableTypes.ConvertNullInt32(reader[30]);
                        objCotizacion.Sessc_iNum_Sub_Segmento = NullableTypes.ConvertNullInt32(reader[31]);
                        objCotizacion.Vectc_iIdEstado_Cotizacion = reader.GetInt32(32);
                        objCotizacion.Cotic_iEstado_Registro = reader.GetInt32(33);
                        objCotizacion.Cotic_dFec_Registro = reader.GetDateTime(34);
                        objCotizacion.Cotic_iIdUsuario_Registro = reader.GetInt32(35);
                        objCotizacion.Cotic_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[36]);
                        objCotizacion.Cotic_iIdUsuario_Modifica = NullableTypes.ConvertNullInt32(reader[37]);
                        return objCotizacion;
                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.Obtener: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Obtener: " + ex.Message, ex);
            }
        }

        public COTIZACION ObtenerPorDocumentoCliente(int pintTipoDocumento, string pstrNumeroDocumento)
        /* Objetivo	:	Permite obtener los datos de una cotización dado el documento del usuario.
         * Author	:	Comsa/MD
         * Fecha	:	20/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_OBTENER_COTIZACION_POR_CLIENTE";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@vtidc_iIdTip_Doc_Identidad", DbType.Int32, 4, pintTipoDocumento);
                    arrParam[1] = new DACRequest.Parameter("@cotic_vNum_Doc", DbType.String, pstrNumeroDocumento);
                    obRequest.Parameters.AddRange(arrParam);

                    //DataSet ds;
                    COTIZACION objCotizacion;

                    //Ejecutar Comando.
                    DACDataReader DACReader = obRequest.Factory.ExecuteReader(ref obRequest);
                    IDataReader reader = DACReader.ReturnDataReader;
                    while (reader.Read())
                    {
                        objCotizacion = new COTIZACION();
                        objCotizacion.Cotic_iIdCotizacion = reader.GetInt32(0);
                        objCotizacion.Cotic_iNum_Cotizacion = reader.GetInt32(1);
                        objCotizacion.Cotic_iNum_Cotizacion_Version = reader.GetInt32(2);
                        objCotizacion.Vtpec_iIdTip_Persona = reader.GetInt32(3);
                        objCotizacion.Vtidc_iIdTip_Doc_Identidad = reader.GetInt32(4);
                        objCotizacion.Cotic_vNum_Doc = reader.GetString(5);
                        objCotizacion.Cotic_vRazon_Social = reader.GetString(6);
                        objCotizacion.Cotic_vNombre_Cliente = reader.GetString(7);
                        objCotizacion.Cotic_vApellido_Paterno = reader.GetString(8);
                        objCotizacion.Cotic_vApellido_Materno = reader.GetString(9);
                        objCotizacion.Cotic_vTelefono_Referencia = reader.GetString(10);
                        objCotizacion.Cotic_vTelefono_Contacto = reader.GetString(11);
                        objCotizacion.Cotic_iCodigo_Carterizado = NullableTypes.ConvertNullInt32(reader[12]);
                        objCotizacion.Cotic_vNombre_Persona_Contacto = reader.GetString(13);
                        objCotizacion.Vcavc_iIdCanal_Venta = NullableTypes.ConvertNullInt32(reader[14]);
                        objCotizacion.Cotic_vCuc = reader.GetString(15);
                        objCotizacion.Cotic_iIdCliente_Atis = NullableTypes.ConvertNullInt32(reader[16]);
                        objCotizacion.Vviac_iIdTip_Via_Instalacion = NullableTypes.ConvertNullInt32(reader[17]);
                        objCotizacion.Cotic_vNombre_Via_Instalacion = reader.GetString(18);
                        objCotizacion.Cotic_iNum_Via_Instalacion = NullableTypes.ConvertNullInt32(reader[19]);
                        objCotizacion.Vdepc_vIdDepartamento_Instalacion = Convert.ToString(reader[20]);
                        objCotizacion.Vproc_vIdProvincia_Instalacion = Convert.ToString(reader[21]);
                        objCotizacion.Vdisc_vIdDistrito_Instalacion = Convert.ToString(reader[22]);
                        objCotizacion.Vviac_iIdTip_Via_Facturacion = NullableTypes.ConvertNullInt32(reader[23]);
                        objCotizacion.Cotic_vNombre_Via_Facturacion = Convert.ToString(reader[24]);
                        objCotizacion.Cotic_iNum_Via_Facturacion = NullableTypes.ConvertNullInt32(reader[25]);
                        objCotizacion.Vdepc_vIdDepartamento_Facturacion = Convert.ToString(reader[26]);
                        objCotizacion.Vproc_vIdProvincia_Facturacion = Convert.ToString(reader[27]);
                        objCotizacion.Vdisc_vIdDistrito_Facturacion = Convert.ToString(reader[28]);
                        objCotizacion.Paqtc_iIdPaquete = NullableTypes.ConvertNullInt32(reader[29]);
                        objCotizacion.Segmc_iIdSegmento = NullableTypes.ConvertNullInt32(reader[30]);
                        objCotizacion.Sessc_iNum_Sub_Segmento = NullableTypes.ConvertNullInt32(reader[21]);
                        objCotizacion.Vectc_iIdEstado_Cotizacion = reader.GetInt32(32);
                        objCotizacion.Cotic_iEstado_Registro = reader.GetInt32(33);
                        objCotizacion.Cotic_dFec_Registro = reader.GetDateTime(34);
                        objCotizacion.Cotic_iIdUsuario_Registro = reader.GetInt32(35);
                        objCotizacion.Cotic_dFec_Modifica = NullableTypes.ConvertNullDateTime(reader[36]);
                        objCotizacion.Cotic_iIdUsuario_Modifica = NullableTypes.ConvertNullInt32(reader[37]);
                        return objCotizacion;

                    }
                    return null;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.ObtenerPorDocumentoCliente: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.ObtenerPorDocumentoCliente: " + ex.Message, ex);
            }
        }

        public int Insertar(COTIZACION pobjCotizacion)
        /* Objetivo	:	Permite insertar los datos de una cotizacion.
         * Author	:	Comsa/MD
         * Fecha	:	14/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[32];
                    arrParam[0] = new DACRequest.Parameter("@vtpec_iIdTip_Persona", DbType.Int32, 4, pobjCotizacion.Vtpec_iIdTip_Persona);
                    arrParam[1] = new DACRequest.Parameter("@vtIdc_iIdTip_Doc_Identidad", DbType.Int32, 4, pobjCotizacion.Vtidc_iIdTip_Doc_Identidad);
                    arrParam[2] = new DACRequest.Parameter("@cotic_vNum_Doc", DbType.String, 120, pobjCotizacion.Cotic_vNum_Doc);
                    arrParam[3] = new DACRequest.Parameter("@cotic_vRazon_Social", DbType.String, pobjCotizacion.Cotic_vRazon_Social);
                    arrParam[4] = new DACRequest.Parameter("@cotic_vNombre_Cliente", DbType.String, pobjCotizacion.Cotic_vNombre_Cliente);
                    arrParam[5] = new DACRequest.Parameter("@cotic_vApellido_Paterno", DbType.String, pobjCotizacion.Cotic_vApellido_Paterno);
                    arrParam[6] = new DACRequest.Parameter("@cotic_vApellido_Materno", DbType.String, pobjCotizacion.Cotic_vApellido_Materno);
                    arrParam[7] = new DACRequest.Parameter("@cotic_vTelefono_Referencia", DbType.String, pobjCotizacion.Cotic_vTelefono_Referencia);
                    arrParam[8] = new DACRequest.Parameter("@cotic_vTelefono_Contacto", DbType.String, pobjCotizacion.Cotic_vTelefono_Contacto);
                    arrParam[9] = new DACRequest.Parameter("@cotic_iCodigo_Carterizado", DbType.Int32, pobjCotizacion.Cotic_iCodigo_Carterizado);
                    arrParam[10] = new DACRequest.Parameter("@cotic_vNombre_Persona_Contacto", DbType.String, pobjCotizacion.Cotic_vNombre_Persona_Contacto);
                    arrParam[11] = new DACRequest.Parameter("@vcavc_iIdCanal_Venta", DbType.Int32, pobjCotizacion.Vcavc_iIdCanal_Venta);
                    arrParam[12] = new DACRequest.Parameter("@cotic_vCuc", DbType.String, pobjCotizacion.Cotic_vCuc);
                    arrParam[13] = new DACRequest.Parameter("@cotic_iIdCliente_Atis", DbType.Int32, 4, pobjCotizacion.Cotic_iIdCliente_Atis);
                    arrParam[14] = new DACRequest.Parameter("@vviac_iIdTip_Via_Instalacion", DbType.Int32, 4, pobjCotizacion.Vviac_iIdTip_Via_Instalacion);
                    arrParam[15] = new DACRequest.Parameter("@cotic_vNombre_Via_Instalacion", DbType.String, pobjCotizacion.Cotic_vNombre_Via_Instalacion);
                    arrParam[16] = new DACRequest.Parameter("@cotic_iNum_Via_Instalacion", DbType.Int32, 4, pobjCotizacion.Cotic_iNum_Via_Instalacion);
                    arrParam[17] = new DACRequest.Parameter("@vdepc_vIdDepartamento_Instalacion", DbType.String, pobjCotizacion.Vdepc_vIdDepartamento_Instalacion);
                    arrParam[18] = new DACRequest.Parameter("@vproc_vIdProvincia_Instalacion", DbType.String, pobjCotizacion.Vproc_vIdProvincia_Instalacion);
                    arrParam[19] = new DACRequest.Parameter("@vdisc_vIdDistrito_Instalacion", DbType.String, pobjCotizacion.Vdisc_vIdDistrito_Instalacion);
                    arrParam[20] = new DACRequest.Parameter("@vviac_iIdTip_Via_Facturacion", DbType.Int32, pobjCotizacion.Vviac_iIdTip_Via_Facturacion);
                    arrParam[21] = new DACRequest.Parameter("@cotic_vNombre_Via_Facturacion", DbType.String, pobjCotizacion.Cotic_vNombre_Via_Facturacion);
                    arrParam[22] = new DACRequest.Parameter("@cotic_iNum_Via_Facturacion", DbType.Int32, 4, pobjCotizacion.Cotic_iNum_Via_Facturacion);
                    arrParam[23] = new DACRequest.Parameter("@vdepc_vIdDepartamento_Facturacion", DbType.String, pobjCotizacion.Vdepc_vIdDepartamento_Facturacion);
                    arrParam[24] = new DACRequest.Parameter("@vproc_vIdProvincia_Facturacion", DbType.String, pobjCotizacion.Vproc_vIdProvincia_Facturacion);
                    arrParam[25] = new DACRequest.Parameter("@vdisc_vIdDistrito_Facturacion", DbType.String, pobjCotizacion.Vdisc_vIdDistrito_Facturacion);
                    arrParam[26] = new DACRequest.Parameter("@paqtc_iIdPaquete", DbType.Int32, 4, pobjCotizacion.Paqtc_iIdPaquete);
                    arrParam[27] = new DACRequest.Parameter("@vsegc_iIdSegmento", DbType.Int32, pobjCotizacion.Segmc_iIdSegmento);
                    arrParam[28] = new DACRequest.Parameter("@vsubc_iIdSub_Segmento", DbType.Int32, 4, pobjCotizacion.Sessc_iNum_Sub_Segmento);
                    arrParam[29] = new DACRequest.Parameter("@vectc_iIdEstado_Cotizacion", DbType.Int32, 4, pobjCotizacion.Vectc_iIdEstado_Cotizacion);
                    arrParam[30] = new DACRequest.Parameter("@cotic_iEstado_Registro", DbType.Int32, 4, pobjCotizacion.Cotic_iEstado_Registro);
                    arrParam[31] = new DACRequest.Parameter("@cotic_iIdUsuario_Registro", DbType.Int32, 4, pobjCotizacion.Cotic_iIdUsuario_Registro);
                  
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = Convert.ToInt32(obRequest.Factory.ExecuteScalar(ref obRequest));

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.Insertar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Insertar: " + ex.Message, ex);
            }
        }

        public int InsertarNuevaVersion(int pintIdCotizacion, int pintIdUsuario)
        /* Objetivo	:	Permite insertar los datos de una cotizacion.
         * Author	:	Comsa/MD
         * Fecha	:	14/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSI_COTIZACION_NUEVA_VERSION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@cotic_iIdUsuario_Registro", DbType.Int32, 4, pintIdUsuario);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.InsertarNuevaVersion: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.InsertarNuevaVersion: " + ex.Message, ex);
            }
        }

        public int Modificar(COTIZACION pobjCotizacion)
        /* Objetivo	:	Permite modificar los datos de una cotización.
         * Author	:	Comsa/MD
         * Fecha	:	20/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[33];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pobjCotizacion.Cotic_iIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@vtpec_iIdTip_Persona", DbType.Int32, 4, pobjCotizacion.Vtpec_iIdTip_Persona);
                    arrParam[2] = new DACRequest.Parameter("@vtIdc_iIdTip_Doc_Identidad", DbType.Int32, 4, pobjCotizacion.Vtidc_iIdTip_Doc_Identidad);
                    arrParam[3] = new DACRequest.Parameter("@cotic_vNum_Doc", DbType.String, 120, pobjCotizacion.Cotic_vNum_Doc);
                    arrParam[4] = new DACRequest.Parameter("@cotic_vRazon_Social", DbType.String, pobjCotizacion.Cotic_vRazon_Social);
                    arrParam[5] = new DACRequest.Parameter("@cotic_vNombre_Cliente", DbType.String, pobjCotizacion.Cotic_vNombre_Cliente);
                    arrParam[6] = new DACRequest.Parameter("@cotic_vApellido_Paterno", DbType.String, pobjCotizacion.Cotic_vApellido_Paterno);
                    arrParam[7] = new DACRequest.Parameter("@cotic_vApellido_Materno", DbType.String, pobjCotizacion.Cotic_vApellido_Materno);
                    arrParam[8] = new DACRequest.Parameter("@cotic_vTelefono_Referencia", DbType.String, pobjCotizacion.Cotic_vTelefono_Referencia);
                    arrParam[9] = new DACRequest.Parameter("@cotic_vTelefono_Contacto", DbType.String, pobjCotizacion.Cotic_vTelefono_Contacto);
                    arrParam[10] = new DACRequest.Parameter("@cotic_iCodigo_Carterizado", DbType.Int32, pobjCotizacion.Cotic_iCodigo_Carterizado);
                    arrParam[11] = new DACRequest.Parameter("@cotic_vNombre_Persona_Contacto", DbType.String, pobjCotizacion.Cotic_vNombre_Persona_Contacto);
                    arrParam[12] = new DACRequest.Parameter("@vcavc_iIdCanal_Venta", DbType.Int32, pobjCotizacion.Vcavc_iIdCanal_Venta);
                    arrParam[13] = new DACRequest.Parameter("@cotic_vCuc", DbType.String, pobjCotizacion.Cotic_vCuc);
                    arrParam[14] = new DACRequest.Parameter("@cotic_iIdCliente_Atis", DbType.Int32, 4, pobjCotizacion.Cotic_iIdCliente_Atis);
                    arrParam[15] = new DACRequest.Parameter("@vviac_iIdTip_Via_Instalacion", DbType.Int32, 4, pobjCotizacion.Vviac_iIdTip_Via_Instalacion);
                    arrParam[16] = new DACRequest.Parameter("@cotic_vNombre_Via_Instalacion", DbType.String, pobjCotizacion.Cotic_vNombre_Via_Instalacion);
                    arrParam[17] = new DACRequest.Parameter("@cotic_iNum_Via_Instalacion", DbType.Int32, 4, pobjCotizacion.Cotic_iNum_Via_Instalacion);
                    arrParam[18] = new DACRequest.Parameter("@vdepc_vIdDepartamento_Instalacion", DbType.String, pobjCotizacion.Vdepc_vIdDepartamento_Instalacion);
                    arrParam[19] = new DACRequest.Parameter("@vproc_vIdProvincia_Instalacion", DbType.String, pobjCotizacion.Vproc_vIdProvincia_Instalacion);
                    arrParam[20] = new DACRequest.Parameter("@vdisc_vIdDistrito_Instalacion", DbType.String, pobjCotizacion.Vdisc_vIdDistrito_Instalacion);
                    arrParam[21] = new DACRequest.Parameter("@vviac_iIdTip_Via_Facturacion", DbType.Int32, pobjCotizacion.Vviac_iIdTip_Via_Facturacion);
                    arrParam[22] = new DACRequest.Parameter("@cotic_vNombre_Via_Facturacion", DbType.String, pobjCotizacion.Cotic_vNombre_Via_Facturacion);
                    arrParam[23] = new DACRequest.Parameter("@cotic_iNum_Via_Facturacion", DbType.Int32, 4, pobjCotizacion.Cotic_iNum_Via_Facturacion);
                    arrParam[24] = new DACRequest.Parameter("@vdepc_vIdDepartamento_Facturacion", DbType.String, pobjCotizacion.Vdepc_vIdDepartamento_Facturacion);
                    arrParam[25] = new DACRequest.Parameter("@vproc_vIdProvincia_Facturacion", DbType.String, pobjCotizacion.Vproc_vIdProvincia_Facturacion);
                    arrParam[26] = new DACRequest.Parameter("@vdisc_vIdDistrito_Facturacion", DbType.String, pobjCotizacion.Vdisc_vIdDistrito_Facturacion);
                    arrParam[27] = new DACRequest.Parameter("@paqtc_iIdPaquete", DbType.Int32, 4, pobjCotizacion.Paqtc_iIdPaquete);
                    arrParam[28] = new DACRequest.Parameter("@vsegc_iIdSegmento", DbType.Int32, pobjCotizacion.Segmc_iIdSegmento);
                    arrParam[29] = new DACRequest.Parameter("@vsubc_iIdSub_Segmento", DbType.Int32, 4, pobjCotizacion.Sessc_iNum_Sub_Segmento);
                    arrParam[30] = new DACRequest.Parameter("@vectc_iIdEstado_Cotizacion", DbType.Int32, 4, pobjCotizacion.Vectc_iIdEstado_Cotizacion);
                    arrParam[31] = new DACRequest.Parameter("@cotic_iEstado_Registro", DbType.Int32, 4, pobjCotizacion.Cotic_iEstado_Registro);
                    arrParam[32] = new DACRequest.Parameter("@cotic_iIdUsuario_Modifica", DbType.Int32, 4, pobjCotizacion.Cotic_iIdUsuario_Registro);

                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;

                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.Modificar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Modificar: " + ex.Message, ex);
            }
        }

        public int CambiarEstado(int pintIdCotizacion, int pintIdEstadoCotizacion,int pintIdUsuario)
        /* Objetivo	:	Permite obtener los datos de una cotización dado el documento del usuario.
         * Author	:	Comsa/MD
         * Fecha	:	22/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_CERRAR_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[3];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@vectc_iIdEstado_Cotizacion", DbType.Int32, 4, pintIdEstadoCotizacion);
                    arrParam[2] = new DACRequest.Parameter("@cotic_iIdUsuario", DbType.Int32, 4, pintIdUsuario);
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.Cerrar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Cerrar: " + ex.Message, ex);
            }
        }

        public int Aprobar(int pintIdCotizacion, int pintIdUsuario)
        /* Objetivo	:	Permite obtener los datos de una cotización dado el documento del usuario.
         * Author	:	Comsa/MD
         * Fecha	:	22/08/2008
         */
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSU_APROBAR_COTIZACION";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@cotic_iIdCotizacion", DbType.Int32, 4, pintIdCotizacion);
                    arrParam[1] = new DACRequest.Parameter("@cotic_iIdUsuario", DbType.Int32, 4, pintIdUsuario);
                    obRequest.Parameters.AddRange(arrParam);

                    int i;

                    //Ejecutar Comando.
                    i = obRequest.Factory.ExecuteNonQuery(ref obRequest);

                    return i;
                }
                catch (Exception ex)
                {
                    throw new Exception("pdt_CotizacionDL.Aprobar: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("pdt_CotizacionDL.Aprobar: " + ex.Message, ex);
            }
        }
    }
}
