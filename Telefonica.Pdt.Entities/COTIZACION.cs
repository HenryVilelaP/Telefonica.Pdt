using System;

namespace Telefonica.Pdt.Entities
{
    public class COTIZACION
    {

        public COTIZACION()
        {
        }

        #region "Atributos"

        private int cotic_iIdCotizacion;
        private int cotic_iNum_Cotizacion;
        private int cotic_iNum_Cotizacion_Version;
        private int vtpec_iIdTip_Persona;
        private int vtidc_iIdTip_Doc_Identidad;
        private string cotic_vNum_Doc;
        private string cotic_vRazon_Social;
        private string cotic_vNombre_Cliente;
        private string cotic_vApellido_Paterno;
        private string cotic_vApellido_Materno;
        private string cotic_vTelefono_Referencia;
        private string cotic_vTelefono_Contacto;
        private int? cotic_iCodigo_Carterizado;
        private string cotic_vNombre_Persona_Contacto;
        private int? vcavc_iIdCanal_Venta;
        private string cotic_vCuc;
        private int? cotic_iIdCliente_Atis;
        private int? vviac_iIdTip_Via_Instalacion;
        private string cotic_vNombre_Via_Instalacion;
        private int? cotic_iNum_Via_Instalacion;
        private string vdepc_vIdDepartamento_Instalacion;
        private string vproc_vIdProvincia_Instalacion;
        private string vdisc_vIdDistrito_Instalacion;
        private int? vviac_iIdTip_Via_Facturacion;
        private string cotic_vNombre_Via_Facturacion;
        private int? cotic_iNum_Via_Facturacion;
        private string vdepc_vIdDepartamento_Facturacion;
        private string vproc_vIdProvincia_Facturacion;
        private string vdisc_vIdDistrito_Facturacion;
        private int? paqtc_iIdPaquete;
        private int? segmc_iIdSegmento;
        private int? sessc_iNum_Sub_Segmento;
        private int vectc_iIdEstado_Cotizacion;
        private int cotic_iEstado_Registro;
        private DateTime cotic_dFec_Registro;
        private int cotic_iIdUsuario_Registro;
        private DateTime? cotic_dFec_Modifica;
        private int? cotic_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Cotic_iIdCotizacion
        {
            get
            {
                return this.cotic_iIdCotizacion;
            }
            set
            {
                this.cotic_iIdCotizacion = value;
            }
        }

        public int Cotic_iNum_Cotizacion
        {
            get
            {
                return this.cotic_iNum_Cotizacion;
            }
            set
            {
                this.cotic_iNum_Cotizacion = value;
            }
        }

        public int Cotic_iNum_Cotizacion_Version
        {
            get
            {
                return this.cotic_iNum_Cotizacion_Version;
            }
            set
            {
                this.cotic_iNum_Cotizacion_Version = value;
            }
        }

        public int Vtpec_iIdTip_Persona
        {
            get
            {
                return this.vtpec_iIdTip_Persona;
            }
            set
            {
                this.vtpec_iIdTip_Persona = value;
            }
        }

        public int Vtidc_iIdTip_Doc_Identidad
        {
            get
            {
                return this.vtidc_iIdTip_Doc_Identidad;
            }
            set
            {
                this.vtidc_iIdTip_Doc_Identidad = value;
            }
        }

        public string Cotic_vNum_Doc
        {
            get
            {
                return this.cotic_vNum_Doc;
            }
            set
            {
                this.cotic_vNum_Doc = value;
            }
        }

        public string Cotic_vRazon_Social
        {
            get
            {
                return this.cotic_vRazon_Social;
            }
            set
            {
                this.cotic_vRazon_Social = value;
            }
        }

        public string Cotic_vNombre_Cliente
        {
            get
            {
                return this.cotic_vNombre_Cliente;
            }
            set
            {
                this.cotic_vNombre_Cliente = value;
            }
        }

        public string Cotic_vApellido_Paterno
        {
            get
            {
                return this.cotic_vApellido_Paterno;
            }
            set
            {
                this.cotic_vApellido_Paterno = value;
            }
        }

        public string Cotic_vApellido_Materno
        {
            get
            {
                return this.cotic_vApellido_Materno;
            }
            set
            {
                this.cotic_vApellido_Materno = value;
            }
        }

        public string Cotic_vTelefono_Referencia
        {
            get
            {
                return this.cotic_vTelefono_Referencia;
            }
            set
            {
                this.cotic_vTelefono_Referencia = value;
            }
        }

        public string Cotic_vTelefono_Contacto
        {
            get
            {
                return this.cotic_vTelefono_Contacto;
            }
            set
            {
                this.cotic_vTelefono_Contacto = value;
            }
        }

        public int? Cotic_iCodigo_Carterizado
        {
            get
            {
                return this.cotic_iCodigo_Carterizado;
            }
            set
            {
                this.cotic_iCodigo_Carterizado = value;
            }
        }

        public string Cotic_vNombre_Persona_Contacto
        {
            get
            {
                return this.cotic_vNombre_Persona_Contacto;
            }
            set
            {
                this.cotic_vNombre_Persona_Contacto = value;
            }
        }

        public int? Vcavc_iIdCanal_Venta
        {
            get
            {
                return this.vcavc_iIdCanal_Venta;
            }
            set
            {
                this.vcavc_iIdCanal_Venta = value;
            }
        }

        public string Cotic_vCuc
        {
            get
            {
                return this.cotic_vCuc;
            }
            set
            {
                this.cotic_vCuc = value;
            }
        }

        public int? Cotic_iIdCliente_Atis
        {
            get
            {
                return this.cotic_iIdCliente_Atis;
            }
            set
            {
                this.cotic_iIdCliente_Atis = value;
            }
        }

        public int? Vviac_iIdTip_Via_Instalacion
        {
            get
            {
                return this.vviac_iIdTip_Via_Instalacion;
            }
            set
            {
                this.vviac_iIdTip_Via_Instalacion = value;
            }
        }

        public string Cotic_vNombre_Via_Instalacion
        {
            get
            {
                return this.cotic_vNombre_Via_Instalacion;
            }
            set
            {
                this.cotic_vNombre_Via_Instalacion = value;
            }
        }

        public int? Cotic_iNum_Via_Instalacion
        {
            get
            {
                return this.cotic_iNum_Via_Instalacion;
            }
            set
            {
                this.cotic_iNum_Via_Instalacion = value;
            }
        }

        public string Vdepc_vIdDepartamento_Instalacion
        {
            get
            {
                return this.vdepc_vIdDepartamento_Instalacion;
            }
            set
            {
                this.vdepc_vIdDepartamento_Instalacion = value;
            }
        }

        public string Vproc_vIdProvincia_Instalacion
        {
            get
            {
                return this.vproc_vIdProvincia_Instalacion;
            }
            set
            {
                this.vproc_vIdProvincia_Instalacion = value;
            }
        }

        public string Vdisc_vIdDistrito_Instalacion
        {
            get
            {
                return this.vdisc_vIdDistrito_Instalacion;
            }
            set
            {
                this.vdisc_vIdDistrito_Instalacion = value;
            }
        }

        public int? Vviac_iIdTip_Via_Facturacion
        {
            get
            {
                return this.vviac_iIdTip_Via_Facturacion;
            }
            set
            {
                this.vviac_iIdTip_Via_Facturacion = value;
            }
        }

        public string Cotic_vNombre_Via_Facturacion
        {
            get
            {
                return this.cotic_vNombre_Via_Facturacion;
            }
            set
            {
                this.cotic_vNombre_Via_Facturacion = value;
            }
        }

        public int? Cotic_iNum_Via_Facturacion
        {
            get
            {
                return this.cotic_iNum_Via_Facturacion;
            }
            set
            {
                this.cotic_iNum_Via_Facturacion = value;
            }
        }

        public string Vdepc_vIdDepartamento_Facturacion
        {
            get
            {
                return this.vdepc_vIdDepartamento_Facturacion;
            }
            set
            {
                this.vdepc_vIdDepartamento_Facturacion = value;
            }
        }

        public string Vproc_vIdProvincia_Facturacion
        {
            get
            {
                return this.vproc_vIdProvincia_Facturacion;
            }
            set
            {
                this.vproc_vIdProvincia_Facturacion = value;
            }
        }

        public string Vdisc_vIdDistrito_Facturacion
        {
            get
            {
                return this.vdisc_vIdDistrito_Facturacion;
            }
            set
            {
                this.vdisc_vIdDistrito_Facturacion = value;
            }
        }

        public int? Paqtc_iIdPaquete
        {
            get
            {
                return this.paqtc_iIdPaquete;
            }
            set
            {
                this.paqtc_iIdPaquete = value;
            }
        }

        public int? Segmc_iIdSegmento
        {
            get
            {
                return this.segmc_iIdSegmento;
            }
            set
            {
                this.segmc_iIdSegmento = value;
            }
        }

        public int? Sessc_iNum_Sub_Segmento
        {
            get
            {
                return this.sessc_iNum_Sub_Segmento;
            }
            set
            {
                this.sessc_iNum_Sub_Segmento = value;
            }
        }

        public int Vectc_iIdEstado_Cotizacion
        {
            get
            {
                return this.vectc_iIdEstado_Cotizacion;
            }
            set
            {
                this.vectc_iIdEstado_Cotizacion = value;
            }
        }

        public int Cotic_iEstado_Registro
        {
            get
            {
                return this.cotic_iEstado_Registro;
            }
            set
            {
                this.cotic_iEstado_Registro = value;
            }
        }

        public DateTime Cotic_dFec_Registro
        {
            get
            {
                return this.cotic_dFec_Registro;
            }
            set
            {
                this.cotic_dFec_Registro = value;
            }
        }

        public int Cotic_iIdUsuario_Registro
        {
            get
            {
                return this.cotic_iIdUsuario_Registro;
            }
            set
            {
                this.cotic_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Cotic_dFec_Modifica
        {
            get
            {
                return this.cotic_dFec_Modifica;
            }
            set
            {
                this.cotic_dFec_Modifica = value;
            }
        }

        public int? Cotic_iIdUsuario_Modifica
        {
            get
            {
                return this.cotic_iIdUsuario_Modifica;
            }
            set
            {
                this.cotic_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
