using System.Data;
namespace Telefonica.Pdt.DAC
	{ 

	/// <summary>
	/// Summary description for DAABDataReader.
	/// </summary>
	public abstract class DACDataReader 
	{ 

		public abstract IDataReader ReturnDataReader 
		{ 
			get; 
			set; 
		} 
	}
	}

