using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class TIP_OPE_COM
    {

        public TIP_OPE_COM()
        {
        }

        #region "Atributos"

        private int tococ_iIdTip_Ope_Com;
        private int vgtoc_iIdGrp_Tip_Ope_Com;
        private string tococ_vDescripcion;
        private int vgdoc_iIdGrp_Tip_Doc;
        private int tococ_iEstado_Registro;
        private DateTime tococ_dFec_Registro;
        private int tococ_iIdUsuario_Registro;
        private DateTime? tococ_dFec_Modifica;
        private int? tococ_iIdUsuario_Modifica;
        private int tococ_iInd_Hacer_Seguimiento;

        #endregion"Atributos"

        #region "Propiedades"

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

        public int Vgtoc_iIdGrp_Tip_Ope_Com
        {
            get
            {
                return this.vgtoc_iIdGrp_Tip_Ope_Com;
            }
            set
            {
                this.vgtoc_iIdGrp_Tip_Ope_Com = value;
            }
        }

        public string Tococ_vDescripcion
        {
            get
            {
                return this.tococ_vDescripcion;
            }
            set
            {
                this.tococ_vDescripcion = value;
            }
        }

        public int Vgdoc_iIdGrp_Tip_Doc
        {
            get
            {
                return this.vgdoc_iIdGrp_Tip_Doc;
            }
            set
            {
                this.vgdoc_iIdGrp_Tip_Doc = value;
            }
        }

        public int Tococ_iEstado_Registro
        {
            get
            {
                return this.tococ_iEstado_Registro;
            }
            set
            {
                this.tococ_iEstado_Registro = value;
            }
        }

        public DateTime Tococ_dFec_Registro
        {
            get
            {
                return this.tococ_dFec_Registro;
            }
            set
            {
                this.tococ_dFec_Registro = value;
            }
        }

        public int Tococ_iIdUsuario_Registro
        {
            get
            {
                return this.tococ_iIdUsuario_Registro;
            }
            set
            {
                this.tococ_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Tococ_dFec_Modifica
        {
            get
            {
                return this.tococ_dFec_Modifica;
            }
            set
            {
                this.tococ_dFec_Modifica = value;
            }
        }

        public int? Tococ_iIdUsuario_Modifica
        {
            get
            {
                return this.tococ_iIdUsuario_Modifica;
            }
            set
            {
                this.tococ_iIdUsuario_Modifica = value;
            }
        }

        public int Tococ_iInd_Hacer_Seguimiento
        {
            get
            {
                return this.tococ_iInd_Hacer_Seguimiento;
            }
            set
            {
                this.tococ_iInd_Hacer_Seguimiento = value;
            }
        }

        #endregion "Propiedades"

    }
}
