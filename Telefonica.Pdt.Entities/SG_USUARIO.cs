using System;

namespace Telefonica.Pdt.Entities
{
    public class SG_USUARIO
    {

        public SG_USUARIO()
        {
        }

        #region "Atributos"

        private int usuac_iId_Usuario;
        private string usuac_vApellido_Paterno;
        private string usuac_vApellido_Materno;
        private string usuac_vNombre;
        private string usuac_vLogin;
        private string usuac_vPassword;
        private int? vtdoc_iIdTip_Doc;
        private string usuac_vNum_Doc;
        private int? usuac_iNum_Intento_Accesos;
        private int turnc_iIdTurno;
        private int usuac_iIdEstado_Usuario;
        private int usuac_iIdEstado_Bloqueado;
        private string usuac_vIp_Estacion;
        private DateTime? usuac_dFec_Ultimo_Acceso;
        private DateTime? usuac_dFec_Ultimo_Acceso_Fallido;
        private string usuac_vCorreo;
        private int usuac_iEstado_Registro;
        private int usuac_iIdUsuario_Registro;
        private DateTime usuac_dFec_Registro;
        private int? usuac_iIdUsuario_Modifica;
        private DateTime? usuac_dFec_Modifica;
        private int? perfc_iIdPerfil;

        #endregion"Atributos"

        #region "Propiedades"

        public int Usuac_iId_Usuario
        {
            get
            {
                return this.usuac_iId_Usuario;
            }
            set
            {
                this.usuac_iId_Usuario = value;
            }
        }

        public string Usuac_vApellido_Paterno
        {
            get
            {
                return this.usuac_vApellido_Paterno;
            }
            set
            {
                this.usuac_vApellido_Paterno = value;
            }
        }

        public string Usuac_vApellido_Materno
        {
            get
            {
                return this.usuac_vApellido_Materno;
            }
            set
            {
                this.usuac_vApellido_Materno = value;
            }
        }

        public string Usuac_vNombre
        {
            get
            {
                return this.usuac_vNombre;
            }
            set
            {
                this.usuac_vNombre = value;
            }
        }

        public string Usuac_vLogin
        {
            get
            {
                return this.usuac_vLogin;
            }
            set
            {
                this.usuac_vLogin = value;
            }
        }

        public string Usuac_vPassword
        {
            get
            {
                return this.usuac_vPassword;
            }
            set
            {
                this.usuac_vPassword = value;
            }
        }

        public int? Vtdoc_iIdTip_Doc
        {
            get
            {
                return this.vtdoc_iIdTip_Doc;
            }
            set
            {
                this.vtdoc_iIdTip_Doc = value;
            }
        }

        public string Usuac_vNum_Doc
        {
            get
            {
                return this.usuac_vNum_Doc;
            }
            set
            {
                this.usuac_vNum_Doc = value;
            }
        }

        public int? Usuac_iNum_Intento_Accesos
        {
            get
            {
                return this.usuac_iNum_Intento_Accesos;
            }
            set
            {
                this.usuac_iNum_Intento_Accesos = value;
            }
        }

        public int Turnc_iIdTurno
        {
            get
            {
                return this.turnc_iIdTurno;
            }
            set
            {
                this.turnc_iIdTurno = value;
            }
        }

        public int Usuac_iIdEstado_Usuario
        {
            get
            {
                return this.usuac_iIdEstado_Usuario;
            }
            set
            {
                this.usuac_iIdEstado_Usuario = value;
            }
        }

        public int Usuac_iIdEstado_Bloqueado
        {
            get
            {
                return this.usuac_iIdEstado_Bloqueado;
            }
            set
            {
                this.usuac_iIdEstado_Bloqueado = value;
            }
        }

        public string Usuac_vIp_Estacion
        {
            get
            {
                return this.usuac_vIp_Estacion;
            }
            set
            {
                this.usuac_vIp_Estacion = value;
            }
        }

        public DateTime? Usuac_dFec_Ultimo_Acceso
        {
            get
            {
                return this.usuac_dFec_Ultimo_Acceso;
            }
            set
            {
                this.usuac_dFec_Ultimo_Acceso = value;
            }
        }

        public DateTime? Usuac_dFec_Ultimo_Acceso_Fallido
        {
            get
            {
                return this.usuac_dFec_Ultimo_Acceso_Fallido;
            }
            set
            {
                this.usuac_dFec_Ultimo_Acceso_Fallido = value;
            }
        }

        public string Usuac_vCorreo
        {
            get
            {
                return this.usuac_vCorreo;
            }
            set
            {
                this.usuac_vCorreo = value;
            }
        }

        public int Usuac_iEstado_Registro
        {
            get
            {
                return this.usuac_iEstado_Registro;
            }
            set
            {
                this.usuac_iEstado_Registro = value;
            }
        }

        public int Usuac_iIdUsuario_Registro
        {
            get
            {
                return this.usuac_iIdUsuario_Registro;
            }
            set
            {
                this.usuac_iIdUsuario_Registro = value;
            }
        }

        public DateTime Usuac_dFec_Registro
        {
            get
            {
                return this.usuac_dFec_Registro;
            }
            set
            {
                this.usuac_dFec_Registro = value;
            }
        }

        public int? Usuac_iIdUsuario_Modifica
        {
            get
            {
                return this.usuac_iIdUsuario_Modifica;
            }
            set
            {
                this.usuac_iIdUsuario_Modifica = value;
            }
        }

        public DateTime? Usuac_dFec_Modifica
        {
            get
            {
                return this.usuac_dFec_Modifica;
            }
            set
            {
                this.usuac_dFec_Modifica = value;
            }
        }

        public int? Perfc_iIdPerfil
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

        #endregion "Propiedades"

    }

}
