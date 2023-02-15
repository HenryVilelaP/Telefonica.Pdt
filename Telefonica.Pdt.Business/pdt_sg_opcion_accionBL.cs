using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_opcion_accionBL
    {

        public pdt_sg_opcion_accionBL()
        {
        }

        public DataTable Lista_Opcion_Accion(Int32 piIdOpcion, Int32 piIdAccion)
        {
            pdt_sg_opcion_accionDL oOpcionAccion = new pdt_sg_opcion_accionDL();
            return oOpcionAccion.Lista_Opcion_Accion(piIdOpcion, piIdAccion);
        }

        public int Insertar(SG_OPCION_ACCION poOpcionAccion)
        {
            pdt_sg_opcion_accionDL oOpcionAccion = new pdt_sg_opcion_accionDL();
            return oOpcionAccion.Insertar(poOpcionAccion);
        }

    }
}
