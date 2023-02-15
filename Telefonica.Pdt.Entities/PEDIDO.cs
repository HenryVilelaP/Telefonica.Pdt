using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    
    public class PEDIDO
	{

		public PEDIDO()
		{
		}

		#region "Atributos"

		private int pdtic_iIdPedido;
		private int? vfrec_iIdFuente_Pedido;
		private int? pdtic_iCod_Gesneg;
		private int? pdtic_iIdUsuario_Vendedor;
		private string pdtic_vNombre_Cliente;
		private int? vtdoc_iIdTip_Doc;
		private string pdtic_vNum_Doc;
		private int vzonc_iIdZona;
		private int vtpec_iIdTip_Pedido;
		private int vetdc_iIdEstado_Pedido;
		private string pdtic_vNombre_Contacto;
		private string pdtic_vTelefono_Contacto;
		private int segmc_iIdSegmento;
		private int sessc_iIdSub_Segmento;
		private int? vpaqc_iIdPaquete;
		private DateTime? pdtic_dFec_Contrato;
		private string pdtic_vTelefono_Vendedor;
		private string pdtic_vTelefono_Adicional;
		private int pdtic_iEstado_Registro;
		private DateTime pdtic_dFec_Registro;
		private int pdtic_iIdUsuario_Registro;
		private DateTime? pdtic_dFec_Modifica;
		private int? pdtic_iIdUsuario_Modifica;

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
				this.pdtic_iIdPedido=value;
			}
		}

		public int? Vfrec_iIdFuente_Pedido
		{
			get
			{
				return this.vfrec_iIdFuente_Pedido;
			}
			set
			{
				this.vfrec_iIdFuente_Pedido=value;
			}
		}

		public int? Pdtic_iCod_Gesneg
		{
			get
			{
				return this.pdtic_iCod_Gesneg;
			}
			set
			{
				this.pdtic_iCod_Gesneg=value;
			}
		}

		public int? Pdtic_iIdUsuario_Vendedor
		{
			get
			{
				return this.pdtic_iIdUsuario_Vendedor;
			}
			set
			{
				this.pdtic_iIdUsuario_Vendedor=value;
			}
		}

		public string Pdtic_vNombre_Cliente
		{
			get
			{
				return this.pdtic_vNombre_Cliente;
			}
			set
			{
				this.pdtic_vNombre_Cliente=value;
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
				this.vtdoc_iIdTip_Doc=value;
			}
		}

		public string Pdtic_vNum_Doc
		{
			get
			{
				return this.pdtic_vNum_Doc;
			}
			set
			{
				this.pdtic_vNum_Doc=value;
			}
		}

		public int Vzonc_iIdZona
		{
			get
			{
				return this.vzonc_iIdZona;
			}
			set
			{
				this.vzonc_iIdZona=value;
			}
		}

		public int Vtpec_iIdTip_Pedido
		{
			get
			{
				return this.vtpec_iIdTip_Pedido;
			}
			set
			{
				this.vtpec_iIdTip_Pedido=value;
			}
		}

		public int Vetdc_iIdEstado_Pedido
		{
			get
			{
				return this.vetdc_iIdEstado_Pedido;
			}
			set
			{
				this.vetdc_iIdEstado_Pedido=value;
			}
		}

		public string Pdtic_vNombre_Contacto
		{
			get
			{
				return this.pdtic_vNombre_Contacto;
			}
			set
			{
				this.pdtic_vNombre_Contacto=value;
			}
		}

		public string Pdtic_vTelefono_Contacto
		{
			get
			{
				return this.pdtic_vTelefono_Contacto;
			}
			set
			{
				this.pdtic_vTelefono_Contacto=value;
			}
		}

		public int Segmc_iIdSegmento
		{
			get
			{
				return this.segmc_iIdSegmento;
			}
			set
			{
				this.segmc_iIdSegmento=value;
			}
		}

        public int Sessc_iIdSub_Segmento
		{
			get
			{
                return this.sessc_iIdSub_Segmento;
			}
			set
			{
                this.sessc_iIdSub_Segmento = value;
			}
		}

		public int? Vpaqc_iIdPaquete
		{
			get
			{
				return this.vpaqc_iIdPaquete;
			}
			set
			{
				this.vpaqc_iIdPaquete=value;
			}
		}

		public DateTime? Pdtic_dFec_Contrato
		{
			get
			{
				return this.pdtic_dFec_Contrato;
			}
			set
			{
				this.pdtic_dFec_Contrato=value;
			}
		}

		public string Pdtic_vTelefono_Vendedor
		{
			get
			{
				return this.pdtic_vTelefono_Vendedor;
			}
			set
			{
				this.pdtic_vTelefono_Vendedor=value;
			}
		}

		public string Pdtic_vTelefono_Adicional
		{
			get
			{
				return this.pdtic_vTelefono_Adicional;
			}
			set
			{
				this.pdtic_vTelefono_Adicional=value;
			}
		}

		public int Pdtic_iEstado_Registro
		{
			get
			{
				return this.pdtic_iEstado_Registro;
			}
			set
			{
				this.pdtic_iEstado_Registro=value;
			}
		}

		public DateTime Pdtic_dFec_Registro
		{
			get
			{
				return this.pdtic_dFec_Registro;
			}
			set
			{
				this.pdtic_dFec_Registro=value;
			}
		}

		public int Pdtic_iIdUsuario_Registro
		{
			get
			{
				return this.pdtic_iIdUsuario_Registro;
			}
			set
			{
				this.pdtic_iIdUsuario_Registro=value;
			}
		}

		public DateTime? Pdtic_dFec_Modifica
		{
			get
			{
				return this.pdtic_dFec_Modifica;
			}
			set
			{
				this.pdtic_dFec_Modifica=value;
			}
		}

		public int? Pdtic_iIdUsuario_Modifica
		{
			get
			{
				return this.pdtic_iIdUsuario_Modifica;
			}
			set
			{
				this.pdtic_iIdUsuario_Modifica=value;
			}
		}

		#endregion "Propiedades"

	}

}
