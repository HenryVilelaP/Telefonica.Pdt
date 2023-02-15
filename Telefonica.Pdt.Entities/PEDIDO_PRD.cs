using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class PEDIDO_PRD
    {

        public PEDIDO_PRD()
        {
        }

        #region "Atributos"

        private int pdppc_iIdPedido_Prd;
        private int pdtic_iIdPedido;
        private int vetdc_iIdEstado_Pedido;
        private int? pdtic_iCantidad_Prd;
        private int prsec_iIdPrd_Servicio;
        private decimal? pdtic_nCod_Pedido_Legacie;
        private int psspc_iNum_Sub_Prd;
        private int vpaqc_iIdPaquete;
        private int vtctc_iIdTiempo_Contrato;
        private int? vmrpc_iIdMotivo_Rechazo_Pdti;
        private int tococ_iIdTip_Ope_Com;
        private int vfadc_iIdForma_Adquisicion;
        private int pdppc_iIdRequiere_Llamada_Calidad;
        private int pdppc_iInd_Marca_Critico;
        private int? pdtic_dFec_Marca_Critico;
        private int? pdtic_iIdUsuario_Marca_Critico;
        private string pdtic_vObservacion_Usuario_Marca_Critico;
        private int pdppc_iEstado_Registro;
        private DateTime pdppc_dFec_Registro;
        private int pdppc_iIdUsuario_Registro;
        private DateTime? pdppc_dFecha_Modifica;
        private int? pdppc_iIdUsuario_Modifica;
        private int? cupoc_iIdCuota;

        #endregion"Atributos"

        #region "Propiedades"

        public int Pdppc_iIdPedido_Prd
        {
            get
            {
                return this.pdppc_iIdPedido_Prd;
            }
            set
            {
                this.pdppc_iIdPedido_Prd = value;
            }
        }

        public int Pdtic_iIdPedido
        {
            get
            {
                return this.pdtic_iIdPedido;
            }
            set
            {
                this.pdtic_iIdPedido = value;
            }
        }

        public int Vetdc_iIdEstado_Pedido
        {
            get
            {
                return this.vetdc_iIdEstado_Pedido;
            }
            set
            {
                this.vetdc_iIdEstado_Pedido = value;
            }
        }

        public int? Pdtic_iCantidad_Prd
        {
            get
            {
                return this.pdtic_iCantidad_Prd;
            }
            set
            {
                this.pdtic_iCantidad_Prd = value;
            }
        }

        public int Prsec_iIdPrd_Servicio
        {
            get
            {
                return this.prsec_iIdPrd_Servicio;
            }
            set
            {
                this.prsec_iIdPrd_Servicio = value;
            }
        }

        public decimal? Pdtic_nCod_Pedido_Legacie
        {
            get
            {
                return this.pdtic_nCod_Pedido_Legacie;
            }
            set
            {
                this.pdtic_nCod_Pedido_Legacie = value;
            }
        }

        public int Psspc_iNum_Sub_Prd
        {
            get
            {
                return this.psspc_iNum_Sub_Prd;
            }
            set
            {
                this.psspc_iNum_Sub_Prd = value;
            }
        }

        public int Vpaqc_iIdPaquete
        {
            get
            {
                return this.vpaqc_iIdPaquete;
            }
            set
            {
                this.vpaqc_iIdPaquete = value;
            }
        }

        public int Vtctc_iIdTiempo_Contrato
        {
            get
            {
                return this.vtctc_iIdTiempo_Contrato;
            }
            set
            {
                this.vtctc_iIdTiempo_Contrato = value;
            }
        }

        public int? Vmrpc_iIdMotivo_Rechazo_Pdti
        {
            get
            {
                return this.vmrpc_iIdMotivo_Rechazo_Pdti;
            }
            set
            {
                this.vmrpc_iIdMotivo_Rechazo_Pdti = value;
            }
        }

        public int Tococ_iIdTip_Ope_Com
        {
            get
            {
                return this.tococ_iIdTip_Ope_Com;
            }
            set
            {
                this.tococ_iIdTip_Ope_Com = value;
            }
        }

        public int Vfadc_iIdForma_Adquisicion
        {
            get
            {
                return this.vfadc_iIdForma_Adquisicion;
            }
            set
            {
                this.vfadc_iIdForma_Adquisicion = value;
            }
        }

        public int Pdppc_iIdRequiere_Llamada_Calidad
        {
            get
            {
                return this.pdppc_iIdRequiere_Llamada_Calidad;
            }
            set
            {
                this.pdppc_iIdRequiere_Llamada_Calidad = value;
            }
        }

        public int Pdppc_iInd_Marca_Critico
        {
            get
            {
                return this.pdppc_iInd_Marca_Critico;
            }
            set
            {
                this.pdppc_iInd_Marca_Critico = value;
            }
        }

        public int? Pdtic_dFec_Marca_Critico
        {
            get
            {
                return this.pdtic_dFec_Marca_Critico;
            }
            set
            {
                this.pdtic_dFec_Marca_Critico = value;
            }
        }

        public int? Pdtic_iIdUsuario_Marca_Critico
        {
            get
            {
                return this.pdtic_iIdUsuario_Marca_Critico;
            }
            set
            {
                this.pdtic_iIdUsuario_Marca_Critico = value;
            }
        }

        public string Pdtic_vObservacion_Usuario_Marca_Critico
        {
            get
            {
                return this.pdtic_vObservacion_Usuario_Marca_Critico;
            }
            set
            {
                this.pdtic_vObservacion_Usuario_Marca_Critico = value;
            }
        }

        public int Pdppc_iEstado_Registro
        {
            get
            {
                return this.pdppc_iEstado_Registro;
            }
            set
            {
                this.pdppc_iEstado_Registro = value;
            }
        }

        public DateTime Pdppc_dFec_Registro
        {
            get
            {
                return this.pdppc_dFec_Registro;
            }
            set
            {
                this.pdppc_dFec_Registro = value;
            }
        }

        public int Pdppc_iIdUsuario_Registro
        {
            get
            {
                return this.pdppc_iIdUsuario_Registro;
            }
            set
            {
                this.pdppc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Pdppc_dFecha_Modifica
        {
            get
            {
                return this.pdppc_dFecha_Modifica;
            }
            set
            {
                this.pdppc_dFecha_Modifica = value;
            }
        }

        public int? Pdppc_iIdUsuario_Modifica
        {
            get
            {
                return this.pdppc_iIdUsuario_Modifica;
            }
            set
            {
                this.pdppc_iIdUsuario_Modifica = value;
            }
        }

        public int? Cupoc_iIdCuota
        {
            get
            {
                return this.cupoc_iIdCuota;
            }
            set
            {
                this.cupoc_iIdCuota = value;
            }
        }

        #endregion "Propiedades"

    }

}
