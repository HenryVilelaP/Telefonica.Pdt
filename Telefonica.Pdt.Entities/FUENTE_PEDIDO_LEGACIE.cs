using System;

namespace Telefonica.Pdt.Entities
{
    public class FUENTE_PEDIDO_LEGACIE
    {
        private int pdppc_iIdPedido_Prd;
        private int? vfrec_iIdFuente_Pedido;
        private decimal? pdtic_nCod_Pedido_Legacie;

        public int Pdppc_iIdPedido_Prd
        {
            get { return this.pdppc_iIdPedido_Prd; }
            set { this.pdppc_iIdPedido_Prd = value; }
        }
        public int? Vfrec_iIdFuente_Pedido
        {
            get { return this.vfrec_iIdFuente_Pedido;}
            set { this.vfrec_iIdFuente_Pedido = value; }
        }
        public decimal? Pdtic_nCod_Pedido_Legacie
        {
            get { return this.pdtic_nCod_Pedido_Legacie;}
            set { this.pdtic_nCod_Pedido_Legacie = value; }
        }
    }
}
