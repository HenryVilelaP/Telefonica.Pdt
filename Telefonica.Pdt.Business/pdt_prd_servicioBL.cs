using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_prd_servicioBL
    {
        public DataTable Listar_PRD_SERVICIO(int pi_iIdGrp_Prd)
        {
            pdt_prd_servicioDL obj = new pdt_prd_servicioDL();
            return obj.Listar_PRD_SERVICIO(pi_iIdGrp_Prd);
        }

        public DataTable Listar_PRD_SERVICIO_AGENDABLE(int prsec_iIdPrd_Servicio, int tococ_iInd_Req_Agendamiento)
        {
            pdt_prd_servicioDL obj = new pdt_prd_servicioDL();
            return obj.Listar_PRD_SERVICIO_AGENDABLE(prsec_iIdPrd_Servicio,tococ_iInd_Req_Agendamiento);
        }
    }
}
