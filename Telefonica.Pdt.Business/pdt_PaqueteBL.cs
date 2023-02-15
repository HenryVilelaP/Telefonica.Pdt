using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
	/// <summary>
	/// Descripción breve de pdt_PaqueteBL.
	/// </summary>
	public class pdt_paqueteBL
	{
		public DataTable Listar_Paquete()
		{
			pdt_paqueteDL obj = new pdt_paqueteDL();
			return obj.Listar_Paquete();
		}

        public DataTable Listar_PaquetePorFamilia(int pintIdFamilia)
        {
            pdt_paqueteDL obj = new pdt_paqueteDL();
            return obj.Listar_PorFamilia(pintIdFamilia);
        }
	}
}
