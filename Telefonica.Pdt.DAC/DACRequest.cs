using System;
using System.Data;
using System.Collections;
using System.ComponentModel;

namespace Telefonica.Pdt.DAC
{
    public class DACRequest
    {

    public class Parameter  : IDbDataParameter 
	{ 
		private DbType m_TipoBD; 
		private ParameterDirection m_Direccion; 
		private bool m_bEsNulo=false; 
		private string m_sParamName; 
		private object m_oParamValue; 
		private string m_sColumnaOrigen; 
		private DataRowVersion m_VersionDato;
		private byte m_iPrecision; 
		private byte m_iScale; 
		private int m_iSize; 

		public Parameter() 
		{ 
			m_TipoBD = DbType.AnsiString; 
			m_Direccion = ParameterDirection.Input; 
			m_sParamName = ""; 
			m_oParamValue = DBNull.Value; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
			m_iSize = 0; 
		} 

		public Parameter(string sParameterName, object oValue) 
		{ 
			m_sParamName = sParameterName; 
			m_oParamValue = oValue; 
			m_TipoBD = DbType.AnsiString; 
			m_Direccion = ParameterDirection.Input; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
			m_iSize = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_oParamValue = DBNull.Value; 
			m_Direccion = ParameterDirection.Input; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
			m_iSize = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, object oValue) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_oParamValue = oValue; 
			m_Direccion = ParameterDirection.Input; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
			m_iSize = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, int oSize) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = oSize; 
			m_oParamValue = DBNull.Value; 
			m_Direccion = ParameterDirection.Input; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, int oSize, object oValue) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = oSize; 
			m_oParamValue = oValue; 
			m_Direccion = ParameterDirection.Input; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, int oSize,  ParameterDirection oDirection) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = oSize; 
			m_oParamValue =  DBNull.Value; 
			m_Direccion = oDirection; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 
		public Parameter(string sParameterName, DbType oDbType, object oValue, ParameterDirection oDirection) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = 0; 
			m_oParamValue = oValue; 
			m_Direccion = oDirection; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, ParameterDirection oDirection) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = 0; 
			m_oParamValue = DBNull.Value; 
			m_Direccion = oDirection; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 

		public Parameter(string sParameterName, DbType oDbType, int oSize, object oValue, ParameterDirection oDirection) 
		{ 
			m_sParamName = sParameterName; 
			m_TipoBD = oDbType; 
			m_iSize = oSize; 
			m_oParamValue = oValue; 
			m_Direccion = oDirection; 
			m_sColumnaOrigen = ""; 
			m_VersionDato = DataRowVersion.Current; 
			m_iPrecision = 0; 
			m_iScale = 0; 
		} 

		public DbType DbType 
		{ 
			get 
			{ 
				return m_TipoBD; 
			} 
			set 
			{ 
				m_TipoBD = value; 
			} 
		} 

		public ParameterDirection Direction 
		{ 
			get 
			{ 
				return m_Direccion; 
			} 
			set 
			{ 
				m_Direccion = value; 
			} 
		} 

		public bool IsNullable 
		{ 
			get 
			{ 
				return m_bEsNulo; 
			} 
		} 

		public string ParameterName 
		{ 
			get 
			{ 
				return m_sParamName; 
			 } 
			set 
			{ 
				m_sParamName = value; 
			} 
		} 

		public string SourceColumn 
		{ 
			get 
			{ 
				return m_sColumnaOrigen; 
			} 
			set 
			{ 
				m_sColumnaOrigen = value; 
			} 
		} 

		public DataRowVersion SourceVersion 
		{ 
			get 
			{ 
				return m_VersionDato; 
			} 
			set 
			{ 
				m_VersionDato = value; 
			} 
		} 

		public object Value 
		{ 
			get 
			{ 
				return m_oParamValue; 
			} 
			set 
			{ 
				m_oParamValue = value; 
			} 
		} 

		public int Size 
		{ 
			get 
			{ 
				return m_iSize; 
			} 
			set 
			{ 
				m_iSize = value; 
			} 
		} 

		public byte Scale 
		{ 
			get 
			{ 
				return m_iScale; 
			} 
			set 
			{ 
				m_iScale = value; 
			} 
		} 

		public byte Precision 
		{ 
			get 
			{ 
				return m_iPrecision; 
			} 
			set 
			{ 
				m_iPrecision = value; 
			} 
		} 
	} 

	public enum TipoOrigenDatos 
	{ 
		SQL = 1, 
		ORACLE = 2,
        MYSQL = 3,
        INFORMIX=4
	} 
	private CommandType m_lCommandType; 
	private string m_sCommand; 
	private bool m_bTransactional; 
	private ArrayList m_colParameters = new ArrayList(); 
	private Exception m_oException; 
	private DataSet m_DataSet;
    private DACAbstracFactory m_Factory; 
	private string m_CadCon; 
	private string[] m_aTablesName;

    public DACRequest() 
    { 
    } 

    public DACRequest(TipoOrigenDatos oTypoOrigen, string p_c_CadConexion) 
	{ 
        if (oTypoOrigen == TipoOrigenDatos.SQL) 
        {
            m_Factory = new DACSQLFactory(); 
        } 
		else
            if (oTypoOrigen == TipoOrigenDatos.INFORMIX)
            {
                //m_Factory = new DACInformixFactory();
            }
		m_CadCon = p_c_CadConexion; 
	}

	public DACAbstracFactory GeneraFactory(TipoOrigenDatos oTypoOrigen, string p_c_CadConexion) 
	{ 
		if (oTypoOrigen == TipoOrigenDatos.SQL) 
		{ 
			m_Factory = new DACSQLFactory(); 
		} 
		else 
		if (oTypoOrigen == TipoOrigenDatos.INFORMIX ) 
		{ 
            //m_Factory = new DACInformixFactory(); 
		} 
		m_CadCon = p_c_CadConexion; 
		return m_Factory; 
	} 

	[Description("Contiene el Objeto Factory del origen de datos seleccionado")] 
	public DACAbstracFactory Factory 
	{ 
		get 
		{ 
			if (m_Factory == null) 
			{ 
				throw new ApplicationException("La clase Factory no se ha instanciado...!!"); 
			} 
			return m_Factory; 
		} 
	} 
[Description("Se establece el tipo de comando que se va a ejecutar")] 
	public CommandType CommandType 
	{ 
		get 
		{ 
			return m_lCommandType; 
		} 
		set 
		{ 
			m_lCommandType = value; 
		} 
	} 

	[Description("Contiene la instrucci?n SQL o nombre del store procedure")] 
	public string Command 
	{ 
		get 
		{ 
			return m_sCommand; 
		} 
		set 
		{ 
			m_sCommand = value; 
		} 
	} 

	[Description("Array de Objetos Parameter")] 
	public ArrayList Parameters 
	{ 
		get 
		{ 
			return m_colParameters; 
		} 
		set 
		{ 
			m_colParameters = value; 
		} 
	} 

	[Description("Si la llamada al acceso a datos va ha ser transaccional")] 
	public bool Transactional 
	{ 
		get 
		{ 
			return m_bTransactional; 
		} 
		set 
		{ 
			m_bTransactional = value; 
		} 
	} 

	[Description("Contiene la ultima excepci?n del acceso a datos")] 
	public Exception Exception 
	{ 
		get 
		{ 
			return m_oException; 
		} 
		set 
		{ 
			m_oException = value; 
		} 
	} 

	[Description("Cuando necesita llenar un DataSet existente")] 
	public DataSet RequestDataSet 
	{ 
		get 
		{ 
			return m_DataSet; 
		} 
		set 
		{ 
			m_DataSet = value; 
		} 
	} 

	[Description("Contiene la Cadena de Conexion")] 
	public string ConnectionString 
	{ 
		get 
		{ 
			return m_CadCon; 
		} 
		set 
		{ 
			m_CadCon = value; 
		} 
	} 

	[Description("Devuelve el valor de retorno de un Procedimiento Almacenado")] 
	public int ReturnValue 
	{ 
		get 
		{ 
			if (m_colParameters.Count > 0) 
			{ 
				IDbDataParameter obPara = ((IDbDataParameter)(m_colParameters[ m_colParameters.Count - 1])); 
				if (obPara.Direction == ParameterDirection.ReturnValue) 
				{ 
					return ((int)(obPara.Value)); 
				} 
				else 
				{ 
					return 0; 
				} 
			} 
			else 
			{ 
				return 0; 
			} 
		} 
	}

	[Description("Array que contiene los nombres de las tablas con las que se van a crear un dataset")] 
	public string[] TableNames 
	{ 
		get 
		{ 
			return m_aTablesName; 
		} 
		set 
		{ 
			m_aTablesName = value; 
		} 
	}  

    }
 }


