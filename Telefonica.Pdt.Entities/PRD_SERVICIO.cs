using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class PRD_SERVICIO
    {

        public PRD_SERVICIO()
        {
        }

        #region "Atributos"

        private int prsec_iIdPrd_Servicio;
        private string prsec_vDescripcion;
        private int num_Sla;
        private int? vsisc_iIdSistema;
        private int vgprc_iIdGrp_Prd;
        private int prsec_iIdMostrar_Registro;
        private int prsec_iEstado_Registro;
        private DateTime prsec_dFec_Registro;
        private int prsec_iIdUsuario_Registro;
        private DateTime? prsec_dFec_Modifica;
        private int? prsec_iIdUsuario_Modifica;

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

        public string Prsec_vDescripcion
        {
            get
            {
                return this.prsec_vDescripcion;
            }
            set
            {
                this.prsec_vDescripcion = value;
            }
        }

        public int Num_Sla
        {
            get
            {
                return this.num_Sla;
            }
            set
            {
                this.num_Sla = value;
            }
        }

        public int? Vsisc_iIdSistema
        {
            get
            {
                return this.vsisc_iIdSistema;
            }
            set
            {
                this.vsisc_iIdSistema = value;
            }
        }

        public int Vgprc_iIdGrp_Prd
        {
            get
            {
                return this.vgprc_iIdGrp_Prd;
            }
            set
            {
                this.vgprc_iIdGrp_Prd = value;
            }
        }

        public int Prsec_iIdMostrar_Registro
        {
            get
            {
                return this.prsec_iIdMostrar_Registro;
            }
            set
            {
                this.prsec_iIdMostrar_Registro = value;
            }
        }

        public int Prsec_iEstado_Registro
        {
            get
            {
                return this.prsec_iEstado_Registro;
            }
            set
            {
                this.prsec_iEstado_Registro = value;
            }
        }

        public DateTime Prsec_dFec_Registro
        {
            get
            {
                return this.prsec_dFec_Registro;
            }
            set
            {
                this.prsec_dFec_Registro = value;
            }
        }

        public int Prsec_iIdUsuario_Registro
        {
            get
            {
                return this.prsec_iIdUsuario_Registro;
            }
            set
            {
                this.prsec_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Prsec_dFec_Modifica
        {
            get
            {
                return this.prsec_dFec_Modifica;
            }
            set
            {
                this.prsec_dFec_Modifica = value;
            }
        }

        public int? Prsec_iIdUsuario_Modifica
        {
            get
            {
                return this.prsec_iIdUsuario_Modifica;
            }
            set
            {
                this.prsec_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
