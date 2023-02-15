using System;

namespace Telefonica.Pdt.Entities
{
    public class COTIZACION_PRD_SPR
    {

        public COTIZACION_PRD_SPR()
        {
        }

        #region "Atributos"

        private int cospr_iIdCotizacion_Spr;
        private int? coprc_iIdCotizacion_Prd;
        private int? cotic_iIdCotizacion;
        private int? prsec_iIdPrd_Servicio;
        private int? psspc_iNum_Sub_Prd;
        private string cospc_vNumero_Telefono;
        private string cospc_vNumero_Inscripcion;
        private decimal? cospc_nPrecio;
        private decimal? cospc_nPorc_Descuento;
        private decimal? cospc_nMonto_Descuento;
        private decimal? cospc_nPorc_Igv;
        private decimal? cospc_nMonto_IGV;
        private decimal? cospc_nMonto_Total;
        private int? cospc_iEstado_Registro;
        private DateTime? cospc_dFec_Registro;
        private int? cospc_iIdUsuario_Registro;
        private DateTime? cospc_dFec_Modifica;
        private int? cospc_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Cospr_iIdCotizacion_Spr
        {
            get
            {
                return this.cospr_iIdCotizacion_Spr;
            }
            set
            {
                this.cospr_iIdCotizacion_Spr = value;
            }
        }

        public int? Coprc_iIdCotizacion_Prd
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

        public int? Cotic_iIdCotizacion
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

        public int? Prsec_iIdPrd_Servicio
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

        public int? Psspc_iNum_Sub_Prd
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

        public string Cospc_vNumero_Telefono
        {
            get
            {
                return this.cospc_vNumero_Telefono;
            }
            set
            {
                this.cospc_vNumero_Telefono = value;
            }
        }

        public string Cospc_vNumero_Inscripcion
        {
            get
            {
                return this.cospc_vNumero_Inscripcion;
            }
            set
            {
                this.cospc_vNumero_Inscripcion = value;
            }
        }

        public decimal? Cospc_nPrecio
        {
            get
            {
                return this.cospc_nPrecio;
            }
            set
            {
                this.cospc_nPrecio = value;
            }
        }

        public decimal? Cospc_nPorc_Descuento
        {
            get
            {
                return this.cospc_nPorc_Descuento;
            }
            set
            {
                this.cospc_nPorc_Descuento = value;
            }
        }

        public decimal? Cospc_nMonto_Descuento
        {
            get
            {
                return this.cospc_nMonto_Descuento;
            }
            set
            {
                this.cospc_nMonto_Descuento = value;
            }
        }

        public decimal? Cospc_nPorc_Igv
        {
            get
            {
                return this.cospc_nPorc_Igv;
            }
            set
            {
                this.cospc_nPorc_Igv = value;
            }
        }

        public decimal? Cospc_nMonto_IGV
        {
            get
            {
                return this.cospc_nMonto_IGV;
            }
            set
            {
                this.cospc_nMonto_IGV = value;
            }
        }

        public decimal? Cospc_nMonto_Total
        {
            get
            {
                return this.cospc_nMonto_Total;
            }
            set
            {
                this.cospc_nMonto_Total = value;
            }
        }

        public int? Cospc_iEstado_Registro
        {
            get
            {
                return this.cospc_iEstado_Registro;
            }
            set
            {
                this.cospc_iEstado_Registro = value;
            }
        }

        public DateTime? Cospc_dFec_Registro
        {
            get
            {
                return this.cospc_dFec_Registro;
            }
            set
            {
                this.cospc_dFec_Registro = value;
            }
        }

        public int? Cospc_iIdUsuario_Registro
        {
            get
            {
                return this.cospc_iIdUsuario_Registro;
            }
            set
            {
                this.cospc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Cospc_dFec_Modifica
        {
            get
            {
                return this.cospc_dFec_Modifica;
            }
            set
            {
                this.cospc_dFec_Modifica = value;
            }
        }

        public int? Cospc_iIdUsuario_Modifica
        {
            get
            {
                return this.cospc_iIdUsuario_Modifica;
            }
            set
            {
                this.cospc_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}