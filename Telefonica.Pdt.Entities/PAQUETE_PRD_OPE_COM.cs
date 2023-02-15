using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class PAQUETE_PRD_OPE_COM
    {

        public PAQUETE_PRD_OPE_COM()
        {
        }

        #region "Atributos"

        private int paqtc_iIdPaquete;
        private int tococ_iIdTip_Ope_Com;
        private int prsec_iIdPrd_Servicio;
        private int ppocc_iNum_Item;
        private int ppocc_iEstado_Registro;
        private DateTime ppocc_dFec_Registro;
        private int ppocc_iIdUsuario_Registro;
        private DateTime? ppocc_dFec_Modifica;
        private int? ppocc_iIdUsuario_Modica;
        private int ppocc_iInd_Obligatorio;

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

        public int Ppocc_iNum_Item
        {
            get
            {
                return this.ppocc_iNum_Item;
            }
            set
            {
                this.ppocc_iNum_Item = value;
            }
        }

        public int Ppocc_iEstado_Registro
        {
            get
            {
                return this.ppocc_iEstado_Registro;
            }
            set
            {
                this.ppocc_iEstado_Registro = value;
            }
        }

        public DateTime Ppocc_dFec_Registro
        {
            get
            {
                return this.ppocc_dFec_Registro;
            }
            set
            {
                this.ppocc_dFec_Registro = value;
            }
        }

        public int Ppocc_iIdUsuario_Registro
        {
            get
            {
                return this.ppocc_iIdUsuario_Registro;
            }
            set
            {
                this.ppocc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Ppocc_dFec_Modifica
        {
            get
            {
                return this.ppocc_dFec_Modifica;
            }
            set
            {
                this.ppocc_dFec_Modifica = value;
            }
        }

        public int? Ppocc_iIdUsuario_Modica
        {
            get
            {
                return this.ppocc_iIdUsuario_Modica;
            }
            set
            {
                this.ppocc_iIdUsuario_Modica = value;
            }
        }

        public int Ppocc_iInd_Obligatorio
        {
            get
            {
                return this.ppocc_iInd_Obligatorio;
            }
            set
            {
                this.ppocc_iInd_Obligatorio = value;
            }
        }

        #endregion "Propiedades"

    }

}
