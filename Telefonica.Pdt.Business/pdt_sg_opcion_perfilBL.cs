using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_opcion_perfilBL
    {
        public pdt_sg_opcion_perfilBL()
        {
        }

        public DataTable Lista_Opcion_Perfil(Int32 piIdPerfil, Int32 piIdOpcion)
        {
            pdt_sg_opcion_perfilDL oOpcionPerfil = new pdt_sg_opcion_perfilDL();
            return oOpcionPerfil.Lista_Opcion_Perfil(piIdPerfil, piIdOpcion);
        }

        public int Insertar(SG_OPCION_PERFIL poOpcionPerfil)
        {
            pdt_sg_opcion_perfilDL oOpcionPerfil = new pdt_sg_opcion_perfilDL();
            return oOpcionPerfil.Insertar(poOpcionPerfil);
        }

    }
}
