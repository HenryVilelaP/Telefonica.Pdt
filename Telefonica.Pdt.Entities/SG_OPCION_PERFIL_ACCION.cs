using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
	public class SG_OPCION_PERFIL_ACCION
	{

		public SG_OPCION_PERFIL_ACCION()
		{
		}

		#region "Atributos"

		private int opcic_iIdOpcion;
		private int accic_iIdAccion;
		private int perfc_iIdPerfil;
		private int ppacc_iEstado_Registro;
		private int ppacc_iIdUsuario_Registro;
		private DateTime ppacc_dFecha_Registro;
		private int? ppacc_iIdUsuario_Modifica;
		private DateTime? ppacc_dFecha_Modifica;

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

		public int Accic_iIdAccion
		{
			get
			{
				return this.accic_iIdAccion;
			}
			set
			{
				this.accic_iIdAccion=value;
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

		public int Ppacc_iEstado_Registro
		{
			get
			{
				return this.ppacc_iEstado_Registro;
			}
			set
			{
				this.ppacc_iEstado_Registro=value;
			}
		}

		public int Ppacc_iIdUsuario_Registro
		{
			get
			{
				return this.ppacc_iIdUsuario_Registro;
			}
			set
			{
				this.ppacc_iIdUsuario_Registro=value;
			}
		}

		public DateTime Ppacc_dFecha_Registro
		{
			get
			{
				return this.ppacc_dFecha_Registro;
			}
			set
			{
				this.ppacc_dFecha_Registro=value;
			}
		}

		public int? Ppacc_iIdUsuario_Modifica
		{
			get
			{
				return this.ppacc_iIdUsuario_Modifica;
			}
			set
			{
				this.ppacc_iIdUsuario_Modifica=value;
			}
		}

		public DateTime? Ppacc_dFecha_Modifica
		{
			get
			{
				return this.ppacc_dFecha_Modifica;
			}
			set
			{
				this.ppacc_dFecha_Modifica=value;
			}
		}

		#endregion "Propiedades"

	}

}
