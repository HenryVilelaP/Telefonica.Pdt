using System;

namespace Telefonica.Pdt.Entities
{
    public class SG_PERFIL
    {

        public SG_PERFIL()
        {
        }

        #region "Atributos"

        private int perfc_iIdPerfil;
        private string perfc_vDescripcion;
        private string perfc_vNemotecnico;
        private int perfc_iEstado_Registro;
        private int? perfc_iIdUsuario_Registro;
        private DateTime? perfc_dFec_Registro;
        private int? perfc_iIdUsuario_Modifica;
        private int? perfc_dFec_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Perfc_iIdPerfil
        {
            get
            {
                return this.perfc_iIdPerfil;
            }
            set
            {
                this.perfc_iIdPerfil = value;
            }
        }

        public string Perfc_vDescripcion
        {
            get
            {
                return this.perfc_vDescripcion;
            }
            set
            {
                this.perfc_vDescripcion = value;
            }
        }

        public string Perfc_vNemotecnico
        {
            get
            {
                return this.perfc_vNemotecnico;
            }
            set
            {
                this.perfc_vNemotecnico = value;
            }
        }

        public int Perfc_iEstado_Registro
        {
            get
            {
                return this.perfc_iEstado_Registro;
            }
            set
            {
                this.perfc_iEstado_Registro = value;
            }
        }

        public int? Perfc_iIdUsuario_Registro
        {
            get
            {
                return this.perfc_iIdUsuario_Registro;
            }
            set
            {
                this.perfc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Perfc_dFec_Registro
        {
            get
            {
                return this.perfc_dFec_Registro;
            }
            set
            {
                this.perfc_dFec_Registro = value;
            }
        }

        public int? Perfc_iIdUsuario_Modifica
        {
            get
            {
                return this.perfc_iIdUsuario_Modifica;
            }
            set
            {
                this.perfc_iIdUsuario_Modifica = value;
            }
        }

        public int? Perfc_dFec_Modifica
        {
            get
            {
                return this.perfc_dFec_Modifica;
            }
            set
            {
                this.perfc_dFec_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
