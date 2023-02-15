using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_tip_opcionBL
    {
        public pdt_sg_tip_opcionBL()
        {
        }

        public DataTable Lista_Tipo_Opcion()
        {
            pdt_sg_tip_opcionDL oTipoOpcion = new pdt_sg_tip_opcionDL();
            return oTipoOpcion.Lista_Tipo_Opcion();
        }

        public SG_TIP_OPCION Detalle(int piIdTip_Opcion)
        {
            pdt_sg_tip_opcionDL oTipoOpcion = new pdt_sg_tip_opcionDL();
            return oTipoOpcion.Detalle(piIdTip_Opcion);
        }

        public int Insertar(SG_TIP_OPCION poTipoOpcion)
        {
            pdt_sg_tip_opcionDL oTipoOpcion = new pdt_sg_tip_opcionDL();
            return oTipoOpcion.Insertar(poTipoOpcion);
        }

        public int Modificar(SG_TIP_OPCION poTipoOpcion)
        {
            pdt_sg_tip_opcionDL oTipoOpcion = new pdt_sg_tip_opcionDL();
            return oTipoOpcion.Modificar(poTipoOpcion);
        }

    }
}
