using System.Data; 
using System.Xml; 
using System;
namespace Telefonica.Pdt.DAC
{
	public abstract class DACAbstracFactory : IDisposable 
	{ 

		public abstract int ExecuteNonQuery(ref DACRequest Request); 

		public abstract DataSet ExecuteDataset(ref DACRequest Request); 

		public abstract void FillDataset(ref DACRequest Request); 

		public abstract void UpdateDataSet(ref DACRequest RequestInsert, ref DACRequest RequestUpdate, ref DACRequest RequestDelete); 

		public abstract DACDataReader ExecuteReader(ref DACRequest Repuest); 

		public abstract object ExecuteScalar(ref DACRequest Request); 

		public abstract void CommitTransaction(); 

		public abstract void RollBackTransaction(); 

		public abstract void Dispose(); 
	}
}

