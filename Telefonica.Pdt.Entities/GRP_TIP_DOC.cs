using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class GRP_TIP_DOC
    {

        public GRP_TIP_DOC()
        {
        }

        #region "Atributos"

        private int vgdoc_iIdGrp_Tip_Doc;
        private int? vgdoc_vDescripcion;

        #endregion"Atributos"

        #region "Propiedades"

        public int Vgdoc_iIdGrp_Tip_Doc
        {
            get
            {
                return this.vgdoc_iIdGrp_Tip_Doc;
            }
            set
            {
                this.vgdoc_iIdGrp_Tip_Doc = value;
            }
        }

        public int? Vgdoc_vDescripcion
        {
            get
            {
                return this.vgdoc_vDescripcion;
            }
            set
            {
                this.vgdoc_vDescripcion = value;
            }
        }

        #endregion "Propiedades"

    }
}
