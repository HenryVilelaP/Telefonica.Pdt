using System;

namespace Telefonica.Pdt.Entities
{
    public class PEDIDO_PRD_DOC
    {

        public PEDIDO_PRD_DOC()
        {
        }

        #region "Atributos"

        private int ppdoc_iIdPedido_Doc;
        private int vtdoc_iIdTip_Doc;
        private int ppdoc_iInd_Doc_Publicado;
        private int? ppdoc_iIdUsuario_Publica;
        private DateTime? pptdc_dFec_Publicacion;
        private int? ppdoc_iIdUsuario_Aprueba;
        private DateTime? pptdc_dFec_Aprobacion;
        private int vedoc_iIdEstado_Doc;
        private int? pdppc_iIdPedido_Prd;
        private string pptdc_vNombre_Doc_Digital;
        private int pptdc_iEstado_Registro;
        private DateTime pptdc_dFec_Registro;
        private int pptdc_iIdUsuario_Registro;
        private DateTime? pptdc_dFec_Modifica;
        private int? pptdc_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Ppdoc_iIdPedido_Doc
        {
            get
            {
                return this.ppdoc_iIdPedido_Doc;
            }
            set
            {
                this.ppdoc_iIdPedido_Doc = value;
            }
        }

        public int Vtdoc_iIdTip_Doc
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

        public int Ppdoc_iInd_Doc_Publicado
        {
            get
            {
                return this.ppdoc_iInd_Doc_Publicado;
            }
            set
            {
                this.ppdoc_iInd_Doc_Publicado = value;
            }
        }

        public int? Ppdoc_iIdUsuario_Publica
        {
            get
            {
                return this.ppdoc_iIdUsuario_Publica;
            }
            set
            {
                this.ppdoc_iIdUsuario_Publica = value;
            }
        }

        public DateTime? Pptdc_dFec_Publicacion
        {
            get
            {
                return this.pptdc_dFec_Publicacion;
            }
            set
            {
                this.pptdc_dFec_Publicacion = value;
            }
        }

        public int? Ppdoc_iIdUsuario_Aprueba
        {
            get
            {
                return this.ppdoc_iIdUsuario_Aprueba;
            }
            set
            {
                this.ppdoc_iIdUsuario_Aprueba = value;
            }
        }

        public DateTime? Pptdc_dFec_Aprobacion
        {
            get
            {
                return this.pptdc_dFec_Aprobacion;
            }
            set
            {
                this.pptdc_dFec_Aprobacion = value;
            }
        }

        public int Vedoc_iIdEstado_Doc
        {
            get
            {
                return this.vedoc_iIdEstado_Doc;
            }
            set
            {
                this.vedoc_iIdEstado_Doc = value;
            }
        }

        public int? Pdppc_iIdPedido_Prd
        {
            get
            {
                return this.pdppc_iIdPedido_Prd;
            }
            set
            {
                this.pdppc_iIdPedido_Prd = value;
            }
        }

        public string Pptdc_vNombre_Doc_Digital
        {
            get
            {
                return this.pptdc_vNombre_Doc_Digital;
            }
            set
            {
                this.pptdc_vNombre_Doc_Digital = value;
            }
        }

        public int Pptdc_iEstado_Registro
        {
            get
            {
                return this.pptdc_iEstado_Registro;
            }
            set
            {
                this.pptdc_iEstado_Registro = value;
            }
        }

        public DateTime Pptdc_dFec_Registro
        {
            get
            {
                return this.pptdc_dFec_Registro;
            }
            set
            {
                this.pptdc_dFec_Registro = value;
            }
        }

        public int Pptdc_iIdUsuario_Registro
        {
            get
            {
                return this.pptdc_iIdUsuario_Registro;
            }
            set
            {
                this.pptdc_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Pptdc_dFec_Modifica
        {
            get
            {
                return this.pptdc_dFec_Modifica;
            }
            set
            {
                this.pptdc_dFec_Modifica = value;
            }
        }

        public int? Pptdc_iIdUsuario_Modifica
        {
            get
            {
                return this.pptdc_iIdUsuario_Modifica;
            }
            set
            {
                this.pptdc_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
