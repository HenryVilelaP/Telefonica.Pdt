using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_historia_cambio_passwordBL
    {
        public pdt_sg_historia_cambio_passwordBL()
        {
        }

        public DataTable Lista_Historia_Cambio_Password(Int32 piIdUsuario)
        {
            pdt_sg_historia_cambio_passwordDL oHistoriaCambioPassword = new pdt_sg_historia_cambio_passwordDL();
            return oHistoriaCambioPassword.Lista_Historia_Cambio_Password(piIdUsuario);
        }

        public int Insertar(SG_HISTORIA_CAMBIO_PASSWORD poHistoriaCambioPassword, String pstrClaveActual)
        {
            pdt_sg_historia_cambio_passwordDL oHistoriaCambioPassword = new pdt_sg_historia_cambio_passwordDL();
            return oHistoriaCambioPassword.Insertar(poHistoriaCambioPassword, pstrClaveActual);
        }

    }
}
