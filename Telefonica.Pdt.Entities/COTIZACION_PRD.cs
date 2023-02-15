using System;

namespace Telefonica.Pdt.Entities
{
    public class COTIZACION_PRD
    {

        public COTIZACION_PRD()
        {
        }

        #region "Atributos"

        private int coprc_iIdCotizacion_Prd;
        private int cotic_iIdCotizacion;
        private int coprc_iCantidad_Prd;
        private int prsec_iIdPrd_Servicio;
        private int paqtc_iIdPaquete;
        private int tococ_iIdTip_Ope_Com;
        private int vfadc_iIdForma_Adquisicion;
        private decimal? coprc_nPorc_Igv;
        private decimal? coprc_nMonto_IGV;
        private int? descc_iIdDescuento;
        private decimal? coprc_nPorc_Descuento;
        private decimal? coprc_nMonto_Descuento;
        private decimal? coprc_nMonto_Total;
        private int coprc_iEstado_Registro;
        private DateTime coprc_dFec_Registro;
        private int coprc_iIdUsuario_Registro;
        private DateTime? coprc_dFec_Modifica;
        private int? coprc_iIdUsuario_Modifica;
        private decimal? coprc_nPrecio;
        private int? vtctc_iIdTiempo_Contrato;

        #endregion"Atributos"

        #region "Propiedades"

        public int Coprc_iIdCotizacion_Prd
        {
            get
            {
                return this.coprc_iIdCotizacion_Prd;
            }
            set
            {
                this.coprc_iIdCotizacion_Prd = value;
            }
        }

        public int Cotic_iIdCotizacion
        {
            get
            {
                return this.cotic_iIdCotizacion;
            }
            set
            {
                this.cotic_iIdCotizacion = value;
            }
        }

        public int Coprc_iCantidad_Prd
        {
            get
            {
                return this.coprc_iCantidad_Prd;
            }
            set
            {
                this.coprc_iCantidad_Prd = value;
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

        public int Paqtc_iIdPaquete
        {
            get
            {
                return this.paqtc_iIdPaquete;
            }
            set
            {
                this.paqtc_iIdPaquete = value;
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

        public decimal? Coprc_nPorc_Igv
        {
            get
            {
                return this.coprc_nPorc_Igv;
            }
            set
            {
                this.coprc_nPorc_Igv = value;
            }
        }

        public decimal? Coprc_nMonto_IGV
        {
            get
            {
                return this.coprc_nMonto_IGV;
            }
            set
            {
                this.coprc_nMonto_IGV = value;
            }
        }

        public int? Descc_iIdDescuento
        {
            get
            {
                return this.descc_iIdDescuento;
            }
            set
            {
                this.descc_iIdDescuento = value;
            }
        }

        public decimal? Coprc_nPorc_Descuento
        {
            get
            {
                return this.coprc_nPorc_Descuento;
            }
            set
            {
                this.coprc_nPorc_Descuento = value;
            }
        }

        public decimal? Coprc_nMonto_Descuento
        {
            get
            {
                return this.coprc_nMonto_Descuento;
            }
            set
            {
                this.coprc_nMonto_Descuento = value;
            }
        }

        public decimal? Coprc_nMonto_Total
        {
            get
            {
                return this.coprc_nMonto_Total;
            }
            set
            {
                this.coprc_nMonto_Total = value;
            }
        }

        public int Coprc_iEstado_Registro
        {
            get
            {
                return this.coprc_iEstado_Registro;
            }
            set
            {
                this.coprc_iEstado_Registro = value;
            }
        }

        public DateTime Coprc_dFec_Registro
        {
            get
            {
                return this.coprc_dFec_Registro;
            }
            set
            {
                this.coprc_dFec_Registro = value;
            }
        }

        public int Coprc_iIdUsuario_Registro
        {
            get
            {
                return this.coprc_iIdUsuario_Registro;
            }
            set
            {
                this.coprc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Coprc_dFec_Modifica
        {
            get
            {
                return this.coprc_dFec_Modifica;
            }
            set
            {
                this.coprc_dFec_Modifica = value;
            }
        }

        public int? Coprc_iIdUsuario_Modifica
        {
            get
            {
                return this.coprc_iIdUsuario_Modifica;
            }
            set
            {
                this.coprc_iIdUsuario_Modifica = value;
            }
        }

        public decimal? Coprc_nPrecio
        {
            get
            {
                return this.coprc_nPrecio;
            }
            set
            {
                this.coprc_nPrecio = value;
            }
        }

        public int? Vtctc_iIdTiempo_Contrato
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

        #endregion "Propiedades"
    }
}