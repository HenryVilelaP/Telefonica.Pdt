using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Business
{
    public class pdt_tr_origenesBL
    {
        public FUENTE_PEDIDO_LEGACIE DetalleFuentePedidoLegacie(int IdPedidoProducto)
        {
            pdt_tr_origenesDL opdt_tr_origenesDL = new pdt_tr_origenesDL();
            return opdt_tr_origenesDL.DetalleFuentePedidoLegacie(IdPedidoProducto);
        }

        public TR_ISIS Detalle_TR_ISIS(int CodigoRegistro)
        {
            pdt_tr_origenesDL opdt_tr_origenesDL = new pdt_tr_origenesDL();
            return opdt_tr_origenesDL.Detalle_TR_ISIS(CodigoRegistro);
        }

        public TR_GESTEL Detalle_TR_GESTEL(int CodigoRegistro)
        {
            pdt_tr_origenesDL opdt_tr_origenesDL = new pdt_tr_origenesDL();
            return opdt_tr_origenesDL.Detalle_TR_GESTEL(CodigoRegistro);
        }

        public TR_SPEEDYSIG_GENERICS Detalle_TR_SPEEDYSIG(decimal CodigoRegistro)
        {
            pdt_tr_origenesDL opdt_tr_origenesDL = new pdt_tr_origenesDL();
            return opdt_tr_origenesDL.Detalle_TR_SPEEDYSIG(CodigoRegistro);
        }
        public void Listar_TR_WEBRPS_Datos(int pdppc_iIdPedido_Prd, ref DataTable dtCabeceraPedidoWebRPS, ref DataTable dtDetallePedidoWebRPS)
        {
            pdt_tr_origenesDL opdt_tr_origenesDL = new pdt_tr_origenesDL();
            opdt_tr_origenesDL.Listar_TR_WEBRPS_Datos(pdppc_iIdPedido_Prd, ref dtCabeceraPedidoWebRPS, ref dtDetallePedidoWebRPS);
        }
        
    }
}
