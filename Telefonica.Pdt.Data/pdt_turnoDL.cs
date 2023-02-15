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
    public class pdt_turnoDL
    {
        public pdt_turnoDL()
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
                    string NombreStored = "PDTSS_LISTA_TURNO";
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

        public SG_TURNO Detalle(Int32 piIdTurno)
        /* 
         * Objetivo	:	Permite obtener un turno por su Id.
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
                    string NombreStored = "PDTSS_DETALLE_SG_TURNO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@turnc_iIdTurno", DbType.Int32, 4, piIdTurno);
                    obRequest.Parameters.AddRange(arrParam);

                    SG_TURNO oSG_TURNO = null;
                    IDataReader dr;

                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oSG_TURNO = new SG_TURNO();

                        oSG_TURNO.Turnc_iIdTurno = Convert.ToInt32(dr[Enumeradores.Col_SG_TURNO.turnc_iIdTurno.ToString()]);
                        oSG_TURNO.Turnc_vDescripcion_Turno = Convert.ToString(dr[Enumeradores.Col_SG_TURNO.turnc_vDescripcion_Turno.ToString()]);
                        
                        oSG_TURNO.Turnc_dHora_Ingreso_Lunes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Lunes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Martes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Martes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Miercoles = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Miercoles.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Jueves = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Jueves.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Viernes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Viernes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Sabado = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Sabado.ToString()]);
                        oSG_TURNO.Turnc_dHora_Ingreso_Domingo = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Ingreso_Domingo.ToString()]);

                        oSG_TURNO.Turnc_dHora_Salida_Lunes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Lunes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Martes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Martes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Miercoles = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Miercoles.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Jueves = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Jueves.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Viernes = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Viernes.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Sabado = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Sabado.ToString()]);
                        oSG_TURNO.Turnc_dHora_Salida_Domingo = NullableTypes.ConvertNullDateTime(dr[Enumeradores.Col_SG_TURNO.turnc_dHora_Salida_Domingo.ToString()]);

                        oSG_TURNO.Turnc_iInd_Estado_Turno = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_SG_TURNO.turnc_iInd_Estado_Turno.ToString()]);

                        return oSG_TURNO;

                    }

                    dr.Close();

                    return oSG_TURNO;

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

        public int Insertar(SG_TURNO poTurno)
        /* 
        *  Objetivo	:	Permite insertar datos nuevos en PDTT_SG_TURNO.
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
                    string NombreStored = "PDTSI_TURNO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[17];
                    arrParam[0] = new DACRequest.Parameter("@turnc_vDescripcion_Turno", DbType.String, 50, poTurno.Turnc_vDescripcion_Turno );
                    arrParam[1] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Lunes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Lunes);
                    arrParam[2] = new DACRequest.Parameter("@turnc_dHora_Salida_Lunes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Lunes);
                    arrParam[3] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Martes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Martes);
                    arrParam[4] = new DACRequest.Parameter("@turnc_dHora_Salida_Martes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Martes);
                    arrParam[5] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Miercoles", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Miercoles);
                    arrParam[6] = new DACRequest.Parameter("@turnc_dHora_Salida_Miercoles", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Miercoles);
                    arrParam[7] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Jueves", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Jueves);
                    arrParam[8] = new DACRequest.Parameter("@turnc_dHora_Salida_Jueves", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Jueves);
                    arrParam[9] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Viernes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Viernes);
                    arrParam[10] = new DACRequest.Parameter("@turnc_dHora_Salida_Viernes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Viernes);
                    arrParam[11] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Sabado", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Sabado);
                    arrParam[12] = new DACRequest.Parameter("@turnc_dHora_Salida_Sabado", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Sabado);
                    arrParam[13] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Domingo", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Domingo);
                    arrParam[14] = new DACRequest.Parameter("@turnc_dHora_Salida_Domingo", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Domingo);
                    arrParam[15] = new DACRequest.Parameter("@turnc_iInd_Estado_Turno", DbType.Int32, 4, poTurno.Turnc_iEstado_Registro);
                    arrParam[16] = new DACRequest.Parameter("@turnc_iIdUsuario_Registro", DbType.Int32, 4, poTurno.Turnc_iIdUsuario_Registro);

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

        public int Modificar(SG_TURNO poTurno)
        /* 
        *  Objetivo	:	Permite modificar datos en PDTT_SG_TURNO.
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
                    string NombreStored = "PDTSU_SG_TURNO";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[18];
                    arrParam[0] = new DACRequest.Parameter("@turnc_iIdTurno", DbType.Int32, 4, poTurno.Turnc_iIdTurno);
                    arrParam[1] = new DACRequest.Parameter("@turnc_vDescripcion_Turno", DbType.String, 50, poTurno.Turnc_vDescripcion_Turno);
                    arrParam[2] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Lunes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Lunes);
                    arrParam[3] = new DACRequest.Parameter("@turnc_dHora_Salida_Lunes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Lunes);
                    arrParam[4] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Martes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Martes);
                    arrParam[5] = new DACRequest.Parameter("@turnc_dHora_Salida_Martes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Martes);
                    arrParam[6] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Miercoles", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Miercoles);
                    arrParam[7] = new DACRequest.Parameter("@turnc_dHora_Salida_Miercoles", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Miercoles);
                    arrParam[8] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Jueves", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Jueves);
                    arrParam[9] = new DACRequest.Parameter("@turnc_dHora_Salida_Jueves", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Jueves);
                    arrParam[10] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Viernes", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Viernes);
                    arrParam[11] = new DACRequest.Parameter("@turnc_dHora_Salida_Viernes", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Viernes);
                    arrParam[12] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Sabado", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Sabado);
                    arrParam[13] = new DACRequest.Parameter("@turnc_dHora_Salida_Sabado", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Sabado);
                    arrParam[14] = new DACRequest.Parameter("@turnc_dHora_Ingreso_Domingo", DbType.DateTime, 16, poTurno.Turnc_dHora_Ingreso_Domingo);
                    arrParam[15] = new DACRequest.Parameter("@turnc_dHora_Salida_Domingo", DbType.DateTime, 16, poTurno.Turnc_dHora_Salida_Domingo);
                    arrParam[16] = new DACRequest.Parameter("@turnc_iInd_Estado_Turno", DbType.Int32, 4, poTurno.Turnc_iEstado_Registro);
                    arrParam[17] = new DACRequest.Parameter("@turnc_iIdUsuario_Modifica", DbType.Int32, 4, poTurno.Turnc_iIdUsuario_Modifica);

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
