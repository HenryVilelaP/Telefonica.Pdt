using System;

namespace Telefonica.Pdt.Entities
{
    public class PRD_SERVICIO_SUB_PRD
    {

        public PRD_SERVICIO_SUB_PRD()
        {
        }

        #region "Atributos"

        private int prsec_iIdPrd_Servicio;
        private int psspc_iNum_Sub_Prd;
        private string pspsc_vDescripcion;
        private decimal? pspsc_nMonto_Renta;
        private int pspsc_iEstado_Registro;
        private DateTime pspsc_dFec_Registro;
        private int pspsc_iIdUsuario_Registro;
        private DateTime? pspsc_dFec_Modifica;
        private int? pspsc_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

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

        public string Pspsc_vDescripcion
        {
            get
            {
                return this.pspsc_vDescripcion;
            }
            set
            {
                this.pspsc_vDescripcion = value;
            }
        }

        public decimal? Pspsc_nMonto_Renta
        {
            get
            {
                return this.pspsc_nMonto_Renta;
            }
            set
            {
                this.pspsc_nMonto_Renta = value;
            }
        }

        public int Pspsc_iEstado_Registro
        {
            get
            {
                return this.pspsc_iEstado_Registro;
            }
            set
            {
                this.pspsc_iEstado_Registro = value;
            }
        }

        public DateTime Pspsc_dFec_Registro
        {
            get
            {
                return this.pspsc_dFec_Registro;
            }
            set
            {
                this.pspsc_dFec_Registro = value;
            }
        }

        public int Pspsc_iIdUsuario_Registro
        {
            get
            {
                return this.pspsc_iIdUsuario_Registro;
            }
            set
            {
                this.pspsc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Pspsc_dFec_Modifica
        {
            get
            {
                return this.pspsc_dFec_Modifica;
            }
            set
            {
                this.pspsc_dFec_Modifica = value;
            }
        }

        public int? Pspsc_iIdUsuario_Modifica
        {
            get
            {
                return this.pspsc_iIdUsuario_Modifica;
            }
            set
            {
                this.pspsc_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
