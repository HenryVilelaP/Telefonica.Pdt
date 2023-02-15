using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_bitacoraBL
    {
        public DataTable Listar_Datos_Historico_Seguimiento(int pi_iIdPedido_Prd)
        {
            pdt_bitacoraDL obj = new pdt_bitacoraDL();
            return obj.Listar_Datos_Historico_Seguimiento(pi_iIdPedido_Prd);
        }

        public int Insertar(BITACORA poBitacora)
        {
            pdt_bitacoraDL obj = new pdt_bitacoraDL();
            return obj.Insertar(poBitacora);
        }

    }

}
