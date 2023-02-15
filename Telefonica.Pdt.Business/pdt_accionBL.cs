using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_accionBL
    {
        public pdt_accionBL()
        {
        }

        public DataTable Listar()
        {
            pdt_accionDL oAccion = new pdt_accionDL();
            return oAccion.Listar();
        }

        public int Insertar(SG_ACCION poAccion)
        {
            pdt_accionDL oAccion = new pdt_accionDL();
            return oAccion.Insertar(poAccion);
        }

        public SG_ACCION Detalle(int piiIdAccion)
        {
            pdt_accionDL oAccion = new pdt_accionDL();
            return oAccion.Detalle(piiIdAccion);
        }

        public int Modificar(SG_ACCION poAccion)
        {
            pdt_accionDL oAccion = new pdt_accionDL();
            return oAccion.Modificar(poAccion);
        }

    }
}
