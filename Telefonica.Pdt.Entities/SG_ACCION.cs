using System;

namespace Telefonica.Pdt.Entities
{
    public class SG_ACCION
    {

        public SG_ACCION()
        {
        }

        #region "Atributos"

        private int accic_iIdAccion;
        private string accic_vDescripcion;
        private string accic_vNombre_Accion;
        private int accic_iEstado_Registro;
        private int accic_iUsuario_Registro;
        private DateTime accic_dFec_Registro;
        private int? accic_iUsuario_Modifica;
        private DateTime? accic_dFec_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Accic_iIdAccion
        {
            get
            {
                return this.accic_iIdAccion;
            }
            set
            {
                this.accic_iIdAccion = value;
            }
        }

        public string Accic_vDescripcion
        {
            get
            {
                return this.accic_vDescripcion;
            }
            set
            {
                this.accic_vDescripcion = value;
            }
        }

        public string Accic_vNombre_Accion
        {
            get
            {
                return this.accic_vNombre_Accion;
            }
            set
            {
                this.accic_vNombre_Accion = value;
            }
        }

        public int Accic_iEstado_Registro
        {
            get
            {
                return this.accic_iEstado_Registro;
            }
            set
            {
                this.accic_iEstado_Registro = value;
            }
        }

        public int Accic_iUsuario_Registro
        {
            get
            {
                return this.accic_iUsuario_Registro;
            }
            set
            {
                this.accic_iUsuario_Registro = value;
            }
        }

        public DateTime Accic_dFec_Registro
        {
            get
            {
                return this.accic_dFec_Registro;
            }
            set
            {
                this.accic_dFec_Registro = value;
            }
        }

        public int? Accic_iUsuario_Modifica
        {
            get
            {
                return this.accic_iUsuario_Modifica;
            }
            set
            {
                this.accic_iUsuario_Modifica = value;
            }
        }

        public DateTime? Accic_dFec_Modifica
        {
            get
            {
                return this.accic_dFec_Modifica;
            }
            set
            {
                this.accic_dFec_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
