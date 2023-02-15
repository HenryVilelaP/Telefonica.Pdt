using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class SG_TIP_OPCION
    {

        public SG_TIP_OPCION()
        {
        }

        #region "Atributos"

        private int vtopc_iIdTip_Opcion;
        private string vDescripcion;

        #endregion"Atributos"

        #region "Propiedades"

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

        public string VDescripcion
        {
            get
            {
                return this.vDescripcion;
            }
            set
            {
                this.vDescripcion = value;
            }
        }

        #endregion "Propiedades"

    }

}
