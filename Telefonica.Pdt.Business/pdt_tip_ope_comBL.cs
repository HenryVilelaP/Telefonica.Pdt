using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_tip_ope_comBL
    {
        public pdt_tip_ope_comBL()
        {
        }

        public DataTable Listar_TIP_OPE_COM(int pi_IdGrp_Tip_Ope_Com)
        {
            pdt_tip_ope_comDL obj = new pdt_tip_ope_comDL();
            return obj.Listar_TIP_OPE_COM(pi_IdGrp_Tip_Ope_Com);
        }

    }
}
