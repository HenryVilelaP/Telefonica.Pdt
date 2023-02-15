using System;

namespace Telefonica.Pdt.Entities
{
    public class CUPO
    {

        public CUPO()
        {
        }

        #region "Atributos"

        private int cupoc_iIdCupo;
        private int cupoc_iCanti_Cupo_Asignada;
        private int cupoc_iCanti_Cupo_Disponible;
        private int vfhoc_iIdFranja_Horaria;
        private int grpic_iIdGrp_Instalacion;
        private int? cupoc_iInd_Cierre_Cupo;
        private int cupoc_iEstado_Registro;
        private DateTime cupoc_dFecha_Registro;
        private int cupoc_iIdUsuario_Registro;
        private DateTime? cupoc_dFec_Modifica;
        private int? cupoc_iIdUsuario_Modifica;
        private int provc_iIdProveedor;
        private int fechc_iIdFecha;
        private int? prsec_iIdPrd_Servicio;

        #endregion"Atributos"

        #region "Propiedades"

        public int Cupoc_iIdCupo
        {
            get
            {
                return this.cupoc_iIdCupo;
            }
            set
            {
                this.cupoc_iIdCupo = value;
            }
        }

        public int Cupoc_iCanti_Cupo_Asignada
        {
            get
            {
                return this.cupoc_iCanti_Cupo_Asignada;
            }
            set
            {
                this.cupoc_iCanti_Cupo_Asignada = value;
            }
        }

        public int Cupoc_iCanti_Cupo_Disponible
        {
            get
            {
                return this.cupoc_iCanti_Cupo_Disponible;
            }
            set
            {
                this.cupoc_iCanti_Cupo_Disponible = value;
            }
        }

        public int Vfhoc_iIdFranja_Horaria
        {
            get
            {
                return this.vfhoc_iIdFranja_Horaria;
            }
            set
            {
                this.vfhoc_iIdFranja_Horaria = value;
            }
        }

        public int Grpic_iIdGrp_Instalacion
        {
            get
            {
                return this.grpic_iIdGrp_Instalacion;
            }
            set
            {
                this.grpic_iIdGrp_Instalacion = value;
            }
        }

        public int? Cupoc_iInd_Cierre_Cupo
        {
            get
            {
                return this.cupoc_iInd_Cierre_Cupo;
            }
            set
            {
                this.cupoc_iInd_Cierre_Cupo = value;
            }
        }

        public int Cupoc_iEstado_Registro
        {
            get
            {
                return this.cupoc_iEstado_Registro;
            }
            set
            {
                this.cupoc_iEstado_Registro = value;
            }
        }

        public DateTime Cupoc_dFecha_Registro
        {
            get
            {
                return this.cupoc_dFecha_Registro;
            }
            set
            {
                this.cupoc_dFecha_Registro = value;
            }
        }

        public int Cupoc_iIdUsuario_Registro
        {
            get
            {
                return this.cupoc_iIdUsuario_Registro;
            }
            set
            {
                this.cupoc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Cupoc_dFec_Modifica
        {
            get
            {
                return this.cupoc_dFec_Modifica;
            }
            set
            {
                this.cupoc_dFec_Modifica = value;
            }
        }

        public int? Cupoc_iIdUsuario_Modifica
        {
            get
            {
                return this.cupoc_iIdUsuario_Modifica;
            }
            set
            {
                this.cupoc_iIdUsuario_Modifica = value;
            }
        }

        public int Provc_iIdProveedor
        {
            get
            {
                return this.provc_iIdProveedor;
            }
            set
            {
                this.provc_iIdProveedor = value;
            }
        }

        public int Fechc_iIdFecha
        {
            get
            {
                return this.fechc_iIdFecha;
            }
            set
            {
                this.fechc_iIdFecha = value;
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

        #endregion "Propiedades"

    }

}
