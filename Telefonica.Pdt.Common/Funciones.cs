using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
namespace Telefonica.Pdt.Common
{
	/// <summary>
	/// Summary description for SIACFunciones.
	/// </summary>
	public class Funciones
	{
		public Funciones()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		static public bool isNumeric(object value) 
		{
			bool resultado;
			double numero;

			resultado = Double.TryParse(Convert.ToString(value), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numero);
			return resultado;

		}

		static public bool IsNumeric(string input)
		{
			bool flag = true;
			//Valid user input 
			string pattern = @"^[0-9]*$";
			Regex validate = new Regex(pattern);
			//Check the user input format 
			if (!validate.IsMatch(input))
			{
				flag = false;
			}
			return flag;
		}
		bool IsNumeric2(string inputString)
		{
			return Regex.IsMatch(inputString, "^[0-9]+$");
		}


		static public string CheckStr(object value) 
		{ 
			string salida="";
			if (value == null || value == System.DBNull.Value)
				salida = "";			
			else
				salida = value.ToString();			
			return salida.Trim();
		}

		static public Int64 CheckInt64(object value)
		{
			Int64 salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = 0;
				else
					salida = Convert.ToInt64(value);
			}            
			return salida;
		}

		static public float CheckFloat(object value)
		{
			int salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "")
					salida = 0;
				else
					salida = Convert.ToInt32(value);
			}            
			return salida;
		}


		static public int CheckInt(object value)
		{
			int salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida = Convert.ToInt32(value);
			}            
			return salida;
		}

		static public double CheckDbl(object value)
		{
			double salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida =  Convert.ToDouble(value);
			}            
			return salida;
		}		
		static public double CheckDbl(object value, int nroDecimales)
		{
			double salida = CheckDbl(value);
			if (salida==0) return salida;
			return redondearMontos(salida, nroDecimales);
		}
		static public decimal CheckDecimal(object value)
		{
			decimal salida = 0;
			if (value == null || value == System.DBNull.Value)
			{
				salida = 0;
			}
			else 
			{
				if (Convert.ToString(value) == "" || Convert.ToString(value) == "&nbsp;" || Convert.ToString(value) == "&nbsp")
					salida = 0;
				else
					salida =  Convert.ToDecimal(value);
			}            
			return salida;
		}				
		
		static public double redondearMontos(double value,int nroDecimales) 
		{
			return Math.Round(value, nroDecimales);
		}
		static public DateTime CheckDate(object value)
		{
			
			if (value == null || value == System.DBNull.Value )
				return new DateTime(1,1,1);
			
			if ( value.ToString() == "" )
				return new DateTime(1,1,1);
			return Convert.ToDateTime(value);			
		}	
		public static System.Data.DataTable dtParams()
		{
			System.Data.DbType tipo = new System.Data.DbType();
			System.Data.ParameterDirection direccion = new System.Data.ParameterDirection();
			System.Data.DataTable dt = new System.Data.DataTable();
			dt.Columns.Add("Nombre", System.Type.GetType("System.String"));
			dt.Columns.Add("Tipo", tipo.GetType());
			dt.Columns.Add("Size", System.Type.GetType("System.Int32"));
			dt.Columns.Add("Direccion", direccion.GetType());
			dt.Columns.Add("Valor", System.Type.GetType("System.Object"));
            
			return dt;
		}
		public static bool InsertarParam(System.Data.DataTable vdtParams, 
			string vName , 
			System.Data.DbType vType , 
			int vSize , 
			System.Data.ParameterDirection vDirection , 
			object vValue )
		{

			System.Data.DataRow dr = vdtParams.NewRow();            
			dr["Nombre"] = vName;
			dr["Tipo"] = vType;
			if (vSize == 0) 
				dr["Size"] = 0;
			else
				dr["Size"] = vSize;

			dr["Direccion"] = vDirection;
                
			if (vValue == null)
				dr["Valor"] = DBNull.Value;
			else
				dr["Valor"] = vValue;
                            
			vdtParams.Rows.Add(dr);
			return true;
		}

		public static double ConvertSolesToCentimos(double vMonto)
		{
			return (vMonto * 100);
		}

		public static int UltimoDiaMes(int mes,int anno)
		{
			int dia=0;
			if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 10 || mes == 12) 
			{ 
				dia = 31; 
			} 
			else if (mes == 4 || mes == 6 || mes == 8 || mes == 9 || mes == 11) 
			{ 
				dia = 30; 
			} 
			else if (mes == 2)
			{ 
				if ((anno % 4) == 0 & (anno % 100) == 0) 
				{ 
					dia = 29; 
				} 
				else 
				{ 
					dia = 28; 
				} 
			}
			return dia;
		}
		public static string NVLString(string valor1, string valor2)
		{
			string v1 = CheckStr(valor1);
			string v2 =CheckStr(valor2);
			if (v1!="")
				return v1;
			else
				return v2;
		}
		public static DateTime NVLDate(DateTime valor1, DateTime valor2)
		{
			DateTime v1 = CheckDate(valor1);
			DateTime v2 = CheckDate(valor2);
			if (v1 != new DateTime(1,1,1))
				return v1;
			else
				return v2;
		}
		public static string FormarNroDocumentoIdentidad(string nro)
		{
			string salida =  nro;
			if (salida.Equals("")) return "";
			salida = nro.PadLeft(16,'0');
			return salida;
		}

		public static void Documentar_Tabla(ref DataTable Dt,params string[] Nombres)
		{
			for (int i = 0; i <= Nombres.Length-1; i++)
			{
				Dt.Columns[i].ColumnName=Nombres[i];
			}
		
			//return true;
        }


        #region "Helper Solucion PDT GdC"

        public static int ArchivoGrabarServidor(string RutaGrabarNombreArchivo, byte[] Buffer)
        {
            System.IO.FileStream newFile = new System.IO.FileStream(RutaGrabarNombreArchivo, System.IO.FileMode.Create);
            newFile.Write(Buffer, 0, Buffer.Length);
            newFile.Close();
            return 1;

        }
        #endregion
    }
}
