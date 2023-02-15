using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
	public class SG_OPCION_ACCION
	{

		public SG_OPCION_ACCION()
		{
		}

		#region "Atributos"

		private int opcic_iIdOpcion;
		private int accic_iIdAccion;
		private int oaccc_iEstado_Registro;
		private int oaccc_iIdUsuario_Registro;
		private DateTime oaccc_dFecha_Registro;
		private int? oaccc_iIdUsuario_Modifica;
		private DateTime? oaccc_dFecha_Modifica;

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

		public int Oaccc_iEstado_Registro
		{
			get
			{
				return this.oaccc_iEstado_Registro;
			}
			set
			{
				this.oaccc_iEstado_Registro=value;
			}
		}

		public int Oaccc_iIdUsuario_Registro
		{
			get
			{
				return this.oaccc_iIdUsuario_Registro;
			}
			set
			{
				this.oaccc_iIdUsuario_Registro=value;
			}
		}

		public DateTime Oaccc_dFecha_Registro
		{
			get
			{
				return this.oaccc_dFecha_Registro;
			}
			set
			{
				this.oaccc_dFecha_Registro=value;
			}
		}

		public int? Oaccc_iIdUsuario_Modifica
		{
			get
			{
				return this.oaccc_iIdUsuario_Modifica;
			}
			set
			{
				this.oaccc_iIdUsuario_Modifica=value;
			}
		}

		public DateTime? Oaccc_dFecha_Modifica
		{
			get
			{
				return this.oaccc_dFecha_Modifica;
			}
			set
			{
				this.oaccc_dFecha_Modifica=value;
			}
		}

		#endregion "Propiedades"

	}

}
