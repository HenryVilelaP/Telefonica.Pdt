using System.Data;

namespace Telefonica.Pdt.DAC
{ 
	
	public class DACSQLDataReader : DACDataReader 
	{ 
		IDataReader m_oReturnedDataReader; 

		public override System.Data.IDataReader ReturnDataReader 
		{ 
			get 
			{ 
				return m_oReturnedDataReader; 
			} 
			set 
			{ 
				m_oReturnedDataReader = value; 
			} 
		} 
	}
}