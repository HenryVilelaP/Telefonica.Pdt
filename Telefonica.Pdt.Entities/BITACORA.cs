using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class BITACORA
    {

        public BITACORA()
        {
        }

        #region "Atributos"

        private int pdtic_iIdPedido;
        private int cobic_iNumBitacora;
        private string cobic_vDescripcion;
        private int vdesc_iIdDestino;
        private int vtrac_iIdTratamiento;
        private DateTime? cobic_dFec_Atencion;
        private int cobic_iEstado_Registro;
        private DateTime diafc_dFec_Registro;
        private int cobic_iIdUsuario_Registro;
        private int? cobic_iIdUsuario_Modifica;
        private DateTime? cobic_dFec_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

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

        public int Cobic_iNumBitacora
        {
            get
            {
                return this.cobic_iNumBitacora;
            }
            set
            {
                this.cobic_iNumBitacora = value;
            }
        }

        public string Cobic_vDescripcion
        {
            get
            {
                return this.cobic_vDescripcion;
            }
            set
            {
                this.cobic_vDescripcion = value;
            }
        }

        public int Vdesc_iIdDestino
        {
            get
            {
                return this.vdesc_iIdDestino;
            }
            set
            {
                this.vdesc_iIdDestino = value;
            }
        }

        public int Vtrac_iIdTratamiento
        {
            get
            {
                return this.vtrac_iIdTratamiento;
            }
            set
            {
                this.vtrac_iIdTratamiento = value;
            }
        }

        public DateTime? Cobic_dFec_Atencion
        {
            get
            {
                return this.cobic_dFec_Atencion;
            }
            set
            {
                this.cobic_dFec_Atencion = value;
            }
        }

        public int Cobic_iEstado_Registro
        {
            get
            {
                return this.cobic_iEstado_Registro;
            }
            set
            {
                this.cobic_iEstado_Registro = value;
            }
        }

        public DateTime Diafc_dFec_Registro
        {
            get
            {
                return this.diafc_dFec_Registro;
            }
            set
            {
                this.diafc_dFec_Registro = value;
            }
        }

        public int Cobic_iIdUsuario_Registro
        {
            get
            {
                return this.cobic_iIdUsuario_Registro;
            }
            set
            {
                this.cobic_iIdUsuario_Registro = value;
            }
        }

        public int? Cobic_iIdUsuario_Modifica
        {
            get
            {
                return this.cobic_iIdUsuario_Modifica;
            }
            set
            {
                this.cobic_iIdUsuario_Modifica = value;
            }
        }

        public DateTime? Cobic_dFec_Modifica
        {
            get
            {
                return this.cobic_dFec_Modifica;
            }
            set
            {
                this.cobic_dFec_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
