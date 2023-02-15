using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class PAQUETE
    {

        public PAQUETE()
        {
        }

        #region "Atributos"

        private int paqtc_iIdPaquete;
        private string paqtc_vDescripcion;
        private int vfamc_iIdFamilia_Paquete;
        private string paqtc_vDescripcion_Detalle;
        private string paqtc_vDuo_Trio_Tipo_Speedy;
        private string paqtc_vDuo_Trio_Tipo_Linea;
        private string paqtc_vDuo_Trio_Tipo_Cable;
        private string paqtc_vDuo_Trio_Tipo_Pdti;
        private decimal? paqtc_nDuo_Trio_Descuento;
        private decimal? paqtc_nRenta_Linea;
        private decimal? paqtc_nRenta_Speedy;
        private decimal? paqtc_nRenta_Cable;
        private decimal? paqtc_nRenta_Pdti;
        private int paqtc_iInd_Activo;
        private int? paqtc_nOrden_Oferta;
        private int paqtc_iEstado_Registro;
        private DateTime paqtc_dFec_Registro;
        private int paqtc_iUsuario_Registro;
        private DateTime? paqtc_dFec_Modifica;
        private int? paqtc_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

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

        public string Paqtc_vDescripcion
        {
            get
            {
                return this.paqtc_vDescripcion;
            }
            set
            {
                this.paqtc_vDescripcion = value;
            }
        }

        public int Vfamc_iIdFamilia_Paquete
        {
            get
            {
                return this.vfamc_iIdFamilia_Paquete;
            }
            set
            {
                this.vfamc_iIdFamilia_Paquete = value;
            }
        }

        public string Paqtc_vDescripcion_Detalle
        {
            get
            {
                return this.paqtc_vDescripcion_Detalle;
            }
            set
            {
                this.paqtc_vDescripcion_Detalle = value;
            }
        }

        public string Paqtc_vDuo_Trio_Tipo_Speedy
        {
            get
            {
                return this.paqtc_vDuo_Trio_Tipo_Speedy;
            }
            set
            {
                this.paqtc_vDuo_Trio_Tipo_Speedy = value;
            }
        }

        public string Paqtc_vDuo_Trio_Tipo_Linea
        {
            get
            {
                return this.paqtc_vDuo_Trio_Tipo_Linea;
            }
            set
            {
                this.paqtc_vDuo_Trio_Tipo_Linea = value;
            }
        }

        public string Paqtc_vDuo_Trio_Tipo_Cable
        {
            get
            {
                return this.paqtc_vDuo_Trio_Tipo_Cable;
            }
            set
            {
                this.paqtc_vDuo_Trio_Tipo_Cable = value;
            }
        }

        public string Paqtc_vDuo_Trio_Tipo_Pdti
        {
            get
            {
                return this.paqtc_vDuo_Trio_Tipo_Pdti;
            }
            set
            {
                this.paqtc_vDuo_Trio_Tipo_Pdti = value;
            }
        }

        public decimal? Paqtc_nDuo_Trio_Descuento
        {
            get
            {
                return this.paqtc_nDuo_Trio_Descuento;
            }
            set
            {
                this.paqtc_nDuo_Trio_Descuento = value;
            }
        }

        public decimal? Paqtc_nRenta_Linea
        {
            get
            {
                return this.paqtc_nRenta_Linea;
            }
            set
            {
                this.paqtc_nRenta_Linea = value;
            }
        }

        public decimal? Paqtc_nRenta_Speedy
        {
            get
            {
                return this.paqtc_nRenta_Speedy;
            }
            set
            {
                this.paqtc_nRenta_Speedy = value;
            }
        }

        public decimal? Paqtc_nRenta_Cable
        {
            get
            {
                return this.paqtc_nRenta_Cable;
            }
            set
            {
                this.paqtc_nRenta_Cable = value;
            }
        }

        public decimal? Paqtc_nRenta_Pdti
        {
            get
            {
                return this.paqtc_nRenta_Pdti;
            }
            set
            {
                this.paqtc_nRenta_Pdti = value;
            }
        }

        public int Paqtc_iInd_Activo
        {
            get
            {
                return this.paqtc_iInd_Activo;
            }
            set
            {
                this.paqtc_iInd_Activo = value;
            }
        }

        public int? Paqtc_nOrden_Oferta
        {
            get
            {
                return this.paqtc_nOrden_Oferta;
            }
            set
            {
                this.paqtc_nOrden_Oferta = value;
            }
        }

        public int Paqtc_iEstado_Registro
        {
            get
            {
                return this.paqtc_iEstado_Registro;
            }
            set
            {
                this.paqtc_iEstado_Registro = value;
            }
        }

        public DateTime Paqtc_dFec_Registro
        {
            get
            {
                return this.paqtc_dFec_Registro;
            }
            set
            {
                this.paqtc_dFec_Registro = value;
            }
        }

        public int Paqtc_iUsuario_Registro
        {
            get
            {
                return this.paqtc_iUsuario_Registro;
            }
            set
            {
                this.paqtc_iUsuario_Registro = value;
            }
        }

        public DateTime? Paqtc_dFec_Modifica
        {
            get
            {
                return this.paqtc_dFec_Modifica;
            }
            set
            {
                this.paqtc_dFec_Modifica = value;
            }
        }

        public int? Paqtc_iIdUsuario_Modifica
        {
            get
            {
                return this.paqtc_iIdUsuario_Modifica;
            }
            set
            {
                this.paqtc_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }
}
