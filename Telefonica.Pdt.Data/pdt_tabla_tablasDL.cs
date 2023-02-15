using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.DAC;
using Telefonica.Pdt.Configuration;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Data
{
	public class pdt_tabla_tablasDL
	{

		public DataTable Listar_PorCabecera(int piIdCabecera)
			/* Objetivo	:	Permite listar parametros registrados.
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
					string NombreStored="PDTSS_LISTA_TABLA_POR_CABECERA";
					obRequest.CommandType = CommandType.StoredProcedure;
					obRequest.Command = NombreStored;
					obRequest.Parameters.Clear();

					//Agregar los Parametros al comando.
					DACRequest.Parameter[] arrParam = new DACRequest.Parameter[1];
                    arrParam[0] = new DACRequest.Parameter("@tablc_iIdTabla_Tablas", piIdCabecera);
					obRequest.Parameters.AddRange(arrParam);

					DataSet ds;

					//Ejecutar Comando.
					ds = obRequest.Factory.ExecuteDataset(ref obRequest);
					if ((ds.Tables.Count>0)&&(ds.Tables[0].Rows.Count>0))					
					{
						DataTable dt = ds.Tables[0];						
						return dt;

					}
					return null;

				}
				catch (Exception ex)
				{
                    throw new Exception("Listar_Parametro: " + ex.Message, ex);
				}
				finally
				{
					obRequest.Parameters.Clear();
					obRequest.Factory.Dispose();
				}
			}
			catch (Exception ex)
			{
                throw new Exception("Listar_Parametro: " + ex.Message, ex);
			}
		}

        public TABLA_TABLAS Detalle(int piIdCabecera, int iCodigo)
        {
            //Establecer la Conexion.
            try
            {
                DACRequest obRequest = new DACRequest(Configuracion.Tipo_Conexion(), Configuracion.Cadena_Conexion());
                try
                {
                    //Identificar Tipo de Comando.
                    string NombreStored = "PDTSS_DETALE_TABLA_TABLAS";
                    obRequest.CommandType = CommandType.StoredProcedure;
                    obRequest.Command = NombreStored;
                    obRequest.Parameters.Clear();

                    //Agregar los Parametros al comando.
                    DACRequest.Parameter[] arrParam = new DACRequest.Parameter[2];
                    arrParam[0] = new DACRequest.Parameter("@tablc_iIdTabla_Tablas",DbType.Int32,4, piIdCabecera);
                    arrParam[1] = new DACRequest.Parameter("@tablc_iCodigo",DbType.Int32,4, iCodigo);

                    obRequest.Parameters.AddRange(arrParam);

                    TABLA_TABLAS oBE=null;
                    IDataReader dr;
                    
                    //Ejecutar Comando.
                    dr = obRequest.Factory.ExecuteReader(ref obRequest).ReturnDataReader;
                    while (dr.Read())
                    {
                        oBE = new TABLA_TABLAS();

                        oBE.Tablc_IdTabla_Tablas = Convert.ToInt32(dr[Enumeradores.Col_TABLA_TABLAS.tablc_iIdTabla_Tablas.ToString()]);
                        oBE.Tablc_iCodigo = Convert.ToInt32(dr[Enumeradores.Col_TABLA_TABLAS.tablc_iCodigo.ToString()]);
                        oBE.Tablc_vDescripcion = Convert.ToString(dr[Enumeradores.Col_TABLA_TABLAS.tablc_vDescripcion.ToString()]);
                        oBE.Tablc_vDescripcion_Detalle = Convert.ToString(dr[Enumeradores.Col_TABLA_TABLAS.tablc_vDescripcion_Detalle.ToString()]);
                        oBE.Tablc_vAbreviatura1=Convert.ToString(dr[Enumeradores.Col_TABLA_TABLAS.tablc_vAbreviatura1.ToString()]);
                        oBE.Tablc_vAbreviatura2 = Convert.ToString(dr[Enumeradores.Col_TABLA_TABLAS.tablc_vAbreviatura2.ToString()]);
                        oBE.Tablc_nValor1 = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TABLA_TABLAS.tablc_nValor1.ToString()]);
                        oBE.Tablc_nValor2 = NullableTypes.ConvertNullDecimal(dr[Enumeradores.Col_TABLA_TABLAS.tablc_nValor2.ToString()]);
                        oBE.Tablc_iEditable = Convert.ToInt32(dr[Enumeradores.Col_TABLA_TABLAS.tablc_iEditable.ToString()]);
                        oBE.Tablc_iOrden = NullableTypes.ConvertNullInt32(dr[Enumeradores.Col_TABLA_TABLAS.tablc_iOrden.ToString()]);
                        
                        return oBE;

                    }

                    dr.Close();

                    return oBE;

                }
                catch (Exception ex)
                {
                    throw new Exception("Listar_Parametro: " + ex.Message, ex);
                }
                finally
                {
                    obRequest.Parameters.Clear();
                    obRequest.Factory.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Listar_Parametro: " + ex.Message, ex);
            }
        }
	}
}
