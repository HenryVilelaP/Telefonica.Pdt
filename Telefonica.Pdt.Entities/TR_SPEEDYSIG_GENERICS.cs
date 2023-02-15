using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class TR_SPEEDYSIG_GENERICS
    {

        public TR_SPEEDYSIG_GENERICS()
        {
            this.generic_TR_SPEEDYSIG = new List<TR_SPEEDYSIG>();
        }
     
        private TR_SPEEDYSIG _tR_SPEEDYSIG = null;
        private List<TR_SPEEDYSIG> generic_TR_SPEEDYSIG = null;

        public TR_SPEEDYSIG Cabecera_TR_SPEEDYSIG
        {
            get
            {
                return _tR_SPEEDYSIG;
            }
            set
            {
                this._tR_SPEEDYSIG = value;
            }
        }
        public List<TR_SPEEDYSIG> DetalleItemsPedidos
        {
            get
            {
                return this.generic_TR_SPEEDYSIG;
            }
            set
            {
                this.generic_TR_SPEEDYSIG = value;
            }
        }
    }
}
