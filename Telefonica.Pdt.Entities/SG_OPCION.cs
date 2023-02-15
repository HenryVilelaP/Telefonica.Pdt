using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class SG_OPCION
    {

        public SG_OPCION()
        {
        }

        #region "Atributos"

        private int opcic_iIdOpcion;
        private string opcic_vEtiqueta;
        private string opcic_vNombre_Pagina;
        private string opcic_vRuta_Url_Pagina;
        private int opcic_iId_Opcion_Padre;
        private int opcic_iNum_Orden;
        private int opcic_iInd_Opcion_Critica;
        private int opcic_iEstado_Registro;
        private int opcic_iIdUsuario_Registro;
        private DateTime opcic_dFec_Registro;
        private int? opcic_iIdUsuario_Modifica;
        private DateTime? opcic_dFec_Modifica;
        private int vtopc_iIdTip_Opcion;
        private string opcic_vDescripcion;

        #endregion"Atributos"

        #region "Propiedades"

        public int Opcic_iIdOpcion
        {
            get
            {
                return this.opcic_iIdOpcion;
            }
            set
            {
                this.opcic_iIdOpcion = value;
            }
        }

        public string Opcic_vEtiqueta
        {
            get
            {
                return this.opcic_vEtiqueta;
            }
            set
            {
                this.opcic_vEtiqueta = value;
            }
        }

        public string Opcic_vNombre_Pagina
        {
            get
            {
                return this.opcic_vNombre_Pagina;
            }
            set
            {
                this.opcic_vNombre_Pagina = value;
            }
        }

        public string Opcic_vRuta_Url_Pagina
        {
            get
            {
                return this.opcic_vRuta_Url_Pagina;
            }
            set
            {
                this.opcic_vRuta_Url_Pagina = value;
            }
        }

        public int Opcic_iId_Opcion_Padre
        {
            get
            {
                return this.opcic_iId_Opcion_Padre;
            }
            set
            {
                this.opcic_iId_Opcion_Padre = value;
            }
        }

        public int Opcic_iNum_Orden
        {
            get
            {
                return this.opcic_iNum_Orden;
            }
            set
            {
                this.opcic_iNum_Orden = value;
            }
        }

        public int Opcic_iInd_Opcion_Critica
        {
            get
            {
                return this.opcic_iInd_Opcion_Critica;
            }
            set
            {
                this.opcic_iInd_Opcion_Critica = value;
            }
        }

        public int Opcic_iEstado_Registro
        {
            get
            {
                return this.opcic_iEstado_Registro;
            }
            set
            {
                this.opcic_iEstado_Registro = value;
            }
        }

        public int Opcic_iIdUsuario_Registro
        {
            get
            {
                return this.opcic_iIdUsuario_Registro;
            }
            set
            {
                this.opcic_iIdUsuario_Registro = value;
            }
        }

        public DateTime Opcic_dFec_Registro
        {
            get
            {
                return this.opcic_dFec_Registro;
            }
            set
            {
                this.opcic_dFec_Registro = value;
            }
        }

        public int? Opcic_iIdUsuario_Modifica
        {
            get
            {
                return this.opcic_iIdUsuario_Modifica;
            }
            set
            {
                this.opcic_iIdUsuario_Modifica = value;
            }
        }

        public DateTime? Opcic_dFec_Modifica
        {
            get
            {
                return this.opcic_dFec_Modifica;
            }
            set
            {
                this.opcic_dFec_Modifica = value;
            }
        }

        public int Vtopc_iIdTip_Opcion
        {
            get
            {
                return this.vtopc_iIdTip_Opcion;
            }
            set
            {
                this.vtopc_iIdTip_Opcion = value;
            }
        }

        public string Opcic_vDescripcion
        {
            get
            {
                return this.opcic_vDescripcion;
            }
            set
            {
                this.opcic_vDescripcion = value;
            }
        }

        #endregion "Propiedades"

    }

}

