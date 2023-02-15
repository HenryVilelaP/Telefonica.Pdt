using System;

namespace Telefonica.Pdt.Entities
{
    public class DESCUENTO
    {

        public DESCUENTO()
        {
        }

        #region "Atributos"

        private int descc_iIdDescuento;
        private int? prsec_iIdPrd_Servicio;
        private decimal descc_nMonto_Inicial;
        private decimal descc_nMonto_Final;
        private decimal descc_nPorc_Descuento;
        private int descc_iInd_Actividad_Descuento;
        private int descc_iEstado_Registro;
        private int descc_iIdUsuario_Ingreso;
        private DateTime descc_dFec_Registro;
        private DateTime? descc_dFec_Modifica;
        private int? descc_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Descc_iIdDescuento
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

        public decimal Descc_nMonto_Inicial
        {
            get
            {
                return this.descc_nMonto_Inicial;
            }
            set
            {
                this.descc_nMonto_Inicial = value;
            }
        }

        public decimal Descc_nMonto_Final
        {
            get
            {
                return this.descc_nMonto_Final;
            }
            set
            {
                this.descc_nMonto_Final = value;
            }
        }

        public decimal Descc_nPorc_Descuento
        {
            get
            {
                return this.descc_nPorc_Descuento;
            }
            set
            {
                this.descc_nPorc_Descuento = value;
            }
        }

        public int Descc_iInd_Actividad_Descuento
        {
            get
            {
                return this.descc_iInd_Actividad_Descuento;
            }
            set
            {
                this.descc_iInd_Actividad_Descuento = value;
            }
        }

        public int Descc_iEstado_Registro
        {
            get
            {
                return this.descc_iEstado_Registro;
            }
            set
            {
                this.descc_iEstado_Registro = value;
            }
        }

        public int Descc_iIdUsuario_Ingreso
        {
            get
            {
                return this.descc_iIdUsuario_Ingreso;
            }
            set
            {
                this.descc_iIdUsuario_Ingreso = value;
            }
        }

        public DateTime Descc_dFec_Registro
        {
            get
            {
                return this.descc_dFec_Registro;
            }
            set
            {
                this.descc_dFec_Registro = value;
            }
        }

        public DateTime? Descc_dFec_Modifica
        {
            get
            {
                return this.descc_dFec_Modifica;
            }
            set
            {
                this.descc_dFec_Modifica = value;
            }
        }

        public int? Descc_iIdUsuario_Modifica
        {
            get
            {
                return this.descc_iIdUsuario_Modifica;
            }
            set
            {
                this.descc_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}