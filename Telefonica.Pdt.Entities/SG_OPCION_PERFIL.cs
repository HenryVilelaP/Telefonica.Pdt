using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
	public class SG_OPCION_PERFIL
	{

		public SG_OPCION_PERFIL()
		{
		}

		#region "Atributos"

		private int opcic_iIdOpcion;
		private int perfc_iIdPerfil;
		private int acpac_iEstado_Registro;
		private int acpac_iIdUsuario_Registro;
		private DateTime acpac_dFec_Registro;
		private int? acpac_iIdUsuario_Modifica;
		private DateTime? acpac_dFecha_Modifica;

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
				this.opcic_iIdOpcion=value;
			}
		}

		public int Perfc_iIdPerfil
		{
			get
			{
				return this.perfc_iIdPerfil;
			}
			set
			{
				this.perfc_iIdPerfil=value;
			}
		}

		public int Acpac_iEstado_Registro
		{
			get
			{
				return this.acpac_iEstado_Registro;
			}
			set
			{
				this.acpac_iEstado_Registro=value;
			}
		}

		public int Acpac_iIdUsuario_Registro
		{
			get
			{
				return this.acpac_iIdUsuario_Registro;
			}
			set
			{
				this.acpac_iIdUsuario_Registro=value;
			}
		}

		public DateTime Acpac_dFec_Registro
		{
			get
			{
				return this.acpac_dFec_Registro;
			}
			set
			{
				this.acpac_dFec_Registro=value;
			}
		}

		public int? Acpac_iIdUsuario_Modifica
		{
			get
			{
				return this.acpac_iIdUsuario_Modifica;
			}
			set
			{
				this.acpac_iIdUsuario_Modifica=value;
			}
		}

		public DateTime? Acpac_dFecha_Modifica
		{
			get
			{
				return this.acpac_dFecha_Modifica;
			}
			set
			{
				this.acpac_dFecha_Modifica=value;
			}
		}

		#endregion "Propiedades"

	}

}
