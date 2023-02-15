using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class PROVEEDOR
    {

        public PROVEEDOR()
        {
        }

        #region "Atributos"

        private int provc_iIdProveedor;
        private string provc_vRazon_Social;
        private string provc_vRUC;
        private string provc_vNombreRepresentante;
        private string provc_vCorreo_Representante;
        private string provc_vDireccion;
        private string provc_vTelefono1;
        private string provc_vTelefono2;
        private string provc_vTelefono3;
        private string provc_vFax1;
        private string provc_vFax2;
        private string provc_observacion;
        private int? provc_iEstado_Registro;
        private DateTime provc_dFec_Registro;
        private int provc_iIdUsuario_Registro;
        private DateTime? provc_dFec_Modifica;
        private int? provc_iUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

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

        public string Provc_vRazon_Social
        {
            get
            {
                return this.provc_vRazon_Social;
            }
            set
            {
                this.provc_vRazon_Social = value;
            }
        }

        public string Provc_vRUC
        {
            get
            {
                return this.provc_vRUC;
            }
            set
            {
                this.provc_vRUC = value;
            }
        }

        public string Provc_vNombreRepresentante
        {
            get
            {
                return this.provc_vNombreRepresentante;
            }
            set
            {
                this.provc_vNombreRepresentante = value;
            }
        }

        public string Provc_vCorreo_Representante
        {
            get
            {
                return this.provc_vCorreo_Representante;
            }
            set
            {
                this.provc_vCorreo_Representante = value;
            }
        }

        public string Provc_vDireccion
        {
            get
            {
                return this.provc_vDireccion;
            }
            set
            {
                this.provc_vDireccion = value;
            }
        }

        public string Provc_vTelefono1
        {
            get
            {
                return this.provc_vTelefono1;
            }
            set
            {
                this.provc_vTelefono1 = value;
            }
        }

        public string Provc_vTelefono2
        {
            get
            {
                return this.provc_vTelefono2;
            }
            set
            {
                this.provc_vTelefono2 = value;
            }
        }

        public string Provc_vTelefono3
        {
            get
            {
                return this.provc_vTelefono3;
            }
            set
            {
                this.provc_vTelefono3 = value;
            }
        }

        public string Provc_vFax1
        {
            get
            {
                return this.provc_vFax1;
            }
            set
            {
                this.provc_vFax1 = value;
            }
        }

        public string Provc_vFax2
        {
            get
            {
                return this.provc_vFax2;
            }
            set
            {
                this.provc_vFax2 = value;
            }
        }

        public string Provc_observacion
        {
            get
            {
                return this.provc_observacion;
            }
            set
            {
                this.provc_observacion = value;
            }
        }

        public int? Provc_iEstado_Registro
        {
            get
            {
                return this.provc_iEstado_Registro;
            }
            set
            {
                this.provc_iEstado_Registro = value;
            }
        }

        public DateTime Provc_dFec_Registro
        {
            get
            {
                return this.provc_dFec_Registro;
            }
            set
            {
                this.provc_dFec_Registro = value;
            }
        }

        public int Provc_iIdUsuario_Registro
        {
            get
            {
                return this.provc_iIdUsuario_Registro;
            }
            set
            {
                this.provc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Provc_dFec_Modifica
        {
            get
            {
                return this.provc_dFec_Modifica;
            }
            set
            {
                this.provc_dFec_Modifica = value;
            }
        }

        public int? Provc_iUsuario_Modifica
        {
            get
            {
                return this.provc_iUsuario_Modifica;
            }
            set
            {
                this.provc_iUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
