using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
	public class pdt_tabla_tablasBL
	{
		public DataTable Listar_PorCabecera(int piIdCabecera)
		{
            pdt_tabla_tablasDL opdt_tabla_tablasDL = new pdt_tabla_tablasDL();
            return opdt_tabla_tablasDL.Listar_PorCabecera(piIdCabecera);
		}
        public TABLA_TABLAS Detalle(int piIdCabecera, int iCodigo)
        {
            pdt_tabla_tablasDL opdt_tabla_tablasDL = new pdt_tabla_tablasDL();
            return opdt_tabla_tablasDL.Detalle(piIdCabecera, iCodigo);
        }
	}
}
