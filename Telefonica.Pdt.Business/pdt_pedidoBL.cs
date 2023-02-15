using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
	public class pdt_pedidoBL
	{

        public int Registrar_Pedido_Manual(PEDIDO pobjPedido)
        {
            pdt_pedidoDL objpdt_pedidoDL = new pdt_pedidoDL();
            return objpdt_pedidoDL.Registrar_Pedido_Manual(pobjPedido); 

        }

        public int Actualiza_PEDIDO_CRITICO
                    (int pi_iIdPedido,
                     int pi_iIdUsuario_Modifica)
        {
            pdt_pedidoDL objPedido = new pdt_pedidoDL();
            return objPedido.Actualiza_PEDIDO_CRITICO
                    (pi_iIdPedido,
                     pi_iIdUsuario_Modifica);

        }

        public DataTable DETALLE_DOCUMENTOS_PENDIENTES(int pi_iIdPedido)
        {
            pdt_pedidoDL objPedido = new pdt_pedidoDL();
            return objPedido.DETALLE_DOCUMENTOS_PENDIENTES(pi_iIdPedido);
        }

        public DataTable Detalle_Estado_Pedido(int pi_iEstadoPedido)
        {
            pdt_pedidoDL objPedido = new pdt_pedidoDL();
            return objPedido.Detalle_Estado_Pedido(pi_iEstadoPedido);
        }

        public int Actualiza_ESTADO_VALIDACION_CONTROL
                    (int pi_iIdPedido_Prd,
                     int pi_iIdEstado_Pedido,
                     int pi_iIdUsuario_Modifica)
        {
            pdt_pedidoDL objPedido = new pdt_pedidoDL();
            return objPedido.Actualiza_ESTADO_VALIDACION_CONTROL
                (pi_iIdPedido_Prd,
                 pi_iIdEstado_Pedido,
                 pi_iIdUsuario_Modifica);
        }

        public DataTable Listar_Pedido
                    (
                    int pi_iCod_Gesneg,
                    int pi_iIdPedido,
                    string pi_vTelefono_Contacto,
                    string pi_vNombre_Cliente,
                    int pi_iIdEstado_Pedido,
                    int pi_iIdZona,
                    int pi_iIdPaquete,
                    int pi_iIdFuente_Pedido,
                    int pi_iIdSegmento,
                    int pi_iIdPrd_Servicio,
                    int pi_iIdGrp_Prd,
                    int pi_iInd_Marca_Critico
                    )
        {
            pdt_pedidoDL objPedido = new pdt_pedidoDL();
            return objPedido.Listar_Pedido
                    (
                    pi_iCod_Gesneg,
                    pi_iIdPedido,
                    pi_vTelefono_Contacto,
                    pi_vNombre_Cliente,
                    pi_iIdEstado_Pedido,
                    pi_iIdZona,
                    pi_iIdPaquete,
                    pi_iIdFuente_Pedido,
                    pi_iIdSegmento,
                    pi_iIdPrd_Servicio,
                    pi_iIdGrp_Prd,
                    pi_iInd_Marca_Critico
                    );
        }
                
                
        public DataTable Listar_DatosWebSeguimiento(int intNumeroPedidoWeb)
        {
            pdt_pedidoDL obj = new pdt_pedidoDL();
            return obj.Listar_DatosWebSeguimiento(intNumeroPedidoWeb);
        }

        public int Actualiza_ESTADO_PEDIDO_ADMINISTRACION
            (int pi_iIdPedido, 
             int pi_iIdEstado_Pedido, 
             int pi_iIdUsuario_Modifica)
        {
            pdt_pedidoDL obj = new pdt_pedidoDL();
            return obj.Actualiza_ESTADO_PEDIDO_ADMINISTRACION
                (pi_iIdPedido,
                pi_iIdEstado_Pedido,
                pi_iIdUsuario_Modifica);
        }

        public int Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION
                (int pi_iIdPedido,
                 int pi_iIdTip_Ope_Com,
                 int pi_iIdUsuario_Modifica)
        {
            pdt_pedidoDL obj = new pdt_pedidoDL();
            return obj.Actualiza_TIPO_OPERACION_COMERCIAL_PEDIDO_ADMINISTRACION
                (pi_iIdPedido,
                pi_iIdTip_Ope_Com,
                pi_iIdUsuario_Modifica);
        }

	}
}
