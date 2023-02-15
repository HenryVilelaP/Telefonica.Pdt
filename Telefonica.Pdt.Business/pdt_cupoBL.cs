

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Telefonica.Pdt.Data;
using Telefonica.Pdt.Entities;

namespace Telefonica.Pdt.Business
{
    public class pdt_cupoBL 

    {
        #region "No Transaccional"
        public DataTable ListarZonaPedidoAgendado(int provc_iIdProveedor, int prsec_iIdPrd_Servicio, int fechc_iIdFecha)
        {
            DataTable dtCupo;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtCupo = opdt_cupoDL.ListarZonaPedidoAgendado(provc_iIdProveedor, prsec_iIdPrd_Servicio, fechc_iIdFecha);
            return dtCupo;
        }

        public DataTable ListarPedidoAgendado(int provc_iIdProveedor, int prsec_iIdPrd_Servicio, int fechc_iIdFecha, int pdppc_iIdPedido_Prd, int vetdc_iIdEstado_Pedido, int pdppc_iInd_Pedido_Agendado, DateTime? datFechaInicio, DateTime? datFechaFin)
        {
            DataTable dtCupo;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtCupo = opdt_cupoDL.ListarPedidoAgendado(provc_iIdProveedor, prsec_iIdPrd_Servicio, fechc_iIdFecha,pdppc_iIdPedido_Prd,vetdc_iIdEstado_Pedido,pdppc_iInd_Pedido_Agendado,datFechaInicio,datFechaFin);
            return dtCupo;
        }
       
        public DataTable ListarFecha(int fechc_iIdFecha, int provc_iIdProveedor,int prsec_iIdPrd_Servicio,int fechc_iInd_Reg_Abierto, DateTime? datFechaInicio, DateTime? datFechaFin)
        {
            DataTable dtCupo;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtCupo = opdt_cupoDL.ListarFecha(fechc_iIdFecha, provc_iIdProveedor, prsec_iIdPrd_Servicio,fechc_iInd_Reg_Abierto, datFechaInicio, datFechaFin);
            return dtCupo;
        }
        
        public DataSet Listar(int cupoc_iIdCupo, int provc_iIdProveedor, int grpic_iIdGrp_Instalacion, int fechc_iIdFecha, int prsec_iIdPrd_Servicio)
        {
            DataSet dtCupo;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtCupo = opdt_cupoDL.Listar(cupoc_iIdCupo, provc_iIdProveedor, grpic_iIdGrp_Instalacion, fechc_iIdFecha, prsec_iIdPrd_Servicio);
            return dtCupo;
        }
       
        public DataTable ListarProveedores(int provc_iIdProveedor, string provc_vRazon_Social, string provc_vRUC)
        {
            DataTable dtProveedores;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtProveedores = opdt_cupoDL.ListarProveedores(provc_iIdProveedor, provc_vRazon_Social, provc_vRUC);
            return dtProveedores;
        }
       
        public DataTable ListarGrupoInstalacion(int grpic_iIdGrp_Instalacion, int zgrpc_iIdZona_Grp_Instalacion, string grpic_vDescripcion)
        {
            DataTable dtGrupoInstalacion;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            dtGrupoInstalacion = opdt_cupoDL.ListarGrupoInstalacion(grpic_iIdGrp_Instalacion, zgrpc_iIdZona_Grp_Instalacion, grpic_vDescripcion);
            return dtGrupoInstalacion;
        }
       
        #endregion "No Transaccional"


        #region "Transaccional"

        public int AsignarCupo(int pdppc_iIdPedido_Prd, int cupoc_iIdCupo, int pdppc_iIdUsuario_Modifica)
        {
            int retorno;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            retorno = opdt_cupoDL.AsignarCupo(pdppc_iIdPedido_Prd, cupoc_iIdCupo, pdppc_iIdUsuario_Modifica);
            return retorno;
        }

        public int CierraReAbreFecha(int grpic_iIdGrp_Instalacion, int cupoc_iInd_Cierre_Cupo, int cupoc_iEstado_Registro, int cupoc_iIdUsuario_Modifica, int provc_iIdProveedor, int fechc_iIdFecha, int prsec_iIdPrd_Servicio)
        {
            int retorno;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            retorno = opdt_cupoDL.CierraReAbreFecha(grpic_iIdGrp_Instalacion,cupoc_iInd_Cierre_Cupo ,cupoc_iEstado_Registro,cupoc_iIdUsuario_Modifica ,provc_iIdProveedor ,fechc_iIdFecha ,prsec_iIdPrd_Servicio );
            return retorno;
        }

        public int Insertar(CUPO pobjcupo)
        {
            int retorno;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            retorno = opdt_cupoDL.Insertar(pobjcupo);
            return retorno;
        }
        
        public int Modificar(CUPO pobjcupo)
        {
            int retorno;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            retorno = opdt_cupoDL.Modificar(pobjcupo);
            return retorno;
        }
       
        public int Eliminar(int cupoc_iIdCupo, int pdppc_iIdUsuario_Modifica)
        {
            int retorno;
            pdt_cupoDL opdt_cupoDL = new pdt_cupoDL();
            retorno = opdt_cupoDL.Eliminar(cupoc_iIdCupo, pdppc_iIdUsuario_Modifica);
            return retorno;
        }
       
        #endregion "Transaccional"
    }



}
