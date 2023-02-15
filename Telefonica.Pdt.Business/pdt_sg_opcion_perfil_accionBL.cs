using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_opcion_perfil_accionBL
    {
        public pdt_sg_opcion_perfil_accionBL()
        {
        }

        public DataTable Lista_Opcion_Perfil_Accion(Int32 piIdPerfil, Int32 piIdOpcion, Int32 piIdAccion)
        {
            pdt_sg_opcion_perfil_accionDL oOpcionPerfilAccion = new pdt_sg_opcion_perfil_accionDL();
            return oOpcionPerfilAccion.Lista_Opcion_Perfil_Accion(piIdPerfil, piIdOpcion, piIdAccion);
        }

        public int Insertar(SG_OPCION_PERFIL_ACCION poOpcionPerfilAccion)
        {
            pdt_sg_opcion_perfil_accionDL oOpcionPerfilAccion = new pdt_sg_opcion_perfil_accionDL();
            return oOpcionPerfilAccion.Insertar(poOpcionPerfilAccion);
        }

    }
}
