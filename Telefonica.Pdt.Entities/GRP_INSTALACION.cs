using System;
using System.Collections.Generic;
using System.Text;


namespace Telefonica.Pdt.Entities
{
    public class GRP_INSTALACION
    {

        public GRP_INSTALACION()
        {
        }

        #region "Atributos"

        private int grpic_iIdGrp_Instalacion;
        private string grpic_vDescripcion;
        private int zgrpc_iIdZona_Grp_Instalacion;
        private int grpic_iEstado_Registro;
        private DateTime grpic_dFec_Registro;
        private int grpic_iIdUsuario_Registro;
        private DateTime? grpic_dFec_Modifica;
        private int? grpic_iIdUsuario_Modifica;

        #endregion"Atributos"

        #region "Propiedades"

        public int Grpic_iIdGrp_Instalacion
        {
            get
            {
                return this.grpic_iIdGrp_Instalacion;
            }
            set
            {
                this.grpic_iIdGrp_Instalacion = value;
            }
        }

        public string Grpic_vDescripcion
        {
            get
            {
                return this.grpic_vDescripcion;
            }
            set
            {
                this.grpic_vDescripcion = value;
            }
        }

        public int Zgrpc_iIdZona_Grp_Instalacion
        {
            get
            {
                return this.zgrpc_iIdZona_Grp_Instalacion;
            }
            set
            {
                this.zgrpc_iIdZona_Grp_Instalacion = value;
            }
        }

        public int Grpic_iEstado_Registro
        {
            get
            {
                return this.grpic_iEstado_Registro;
            }
            set
            {
                this.grpic_iEstado_Registro = value;
            }
        }

        public DateTime Grpic_dFec_Registro
        {
            get
            {
                return this.grpic_dFec_Registro;
            }
            set
            {
                this.grpic_dFec_Registro = value;
            }
        }

        public int Grpic_iIdUsuario_Registro
        {
            get
            {
                return this.grpic_iIdUsuario_Registro;
            }
            set
            {
                this.grpic_iIdUsuario_Registro = value;
            }
        }

        public DateTime? Grpic_dFec_Modifica
        {
            get
            {
                return this.grpic_dFec_Modifica;
            }
            set
            {
                this.grpic_dFec_Modifica = value;
            }
        }

        public int? Grpic_iIdUsuario_Modifica
        {
            get
            {
                return this.grpic_iIdUsuario_Modifica;
            }
            set
            {
                this.grpic_iIdUsuario_Modifica = value;
            }
        }

        #endregion "Propiedades"

    }

}
