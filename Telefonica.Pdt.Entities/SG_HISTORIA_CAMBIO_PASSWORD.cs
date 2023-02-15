using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
	public class SG_HISTORIA_CAMBIO_PASSWORD
	{

		public SG_HISTORIA_CAMBIO_PASSWORD()
		{
		}

		#region "Atributos"

		private int hcapc_iIdHistoria_Cambio_Password;
		private int usuac_iId_Usuario;
		private string hcapc_vPassword;
		private int hcapc_iEstado_Registro;
		private int hcapc_iIdUsuario_Registro;
		private DateTime hcapc_dFec_Registro;

		#endregion"Atributos"

		#region "Propiedades"

		public int Hcapc_iIdHistoria_Cambio_Password
		{
			get
			{
				return this.hcapc_iIdHistoria_Cambio_Password;
			}
			set
			{
				this.hcapc_iIdHistoria_Cambio_Password=value;
			}
		}

		public int Usuac_iId_Usuario
		{
			get
			{
				return this.usuac_iId_Usuario;
			}
			set
			{
				this.usuac_iId_Usuario=value;
			}
		}

		public string Hcapc_vPassword
		{
			get
			{
				return this.hcapc_vPassword;
			}
			set
			{
				this.hcapc_vPassword=value;
			}
		}

		public int Hcapc_iEstado_Registro
		{
			get
			{
				return this.hcapc_iEstado_Registro;
			}
			set
			{
				this.hcapc_iEstado_Registro=value;
			}
		}

		public int Hcapc_iIdUsuario_Registro
		{
			get
			{
				return this.hcapc_iIdUsuario_Registro;
			}
			set
			{
				this.hcapc_iIdUsuario_Registro=value;
			}
		}

		public DateTime Hcapc_dFec_Registro
		{
			get
			{
				return this.hcapc_dFec_Registro;
			}
			set
			{
				this.hcapc_dFec_Registro=value;
			}
		}

		#endregion "Propiedades"

	}

}

