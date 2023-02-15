using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    /// <summary>
    /// Descripción breve de pdt_seguimientoBL.
    /// </summary>

    public class pdt_perfilBL
    {

        public pdt_perfilBL()
        {
            //
            // TODO: agregar aquí la lógica del constructor
            //
        }

        public DataTable Listar_Perfil()
        {
            pdt_perfilDL oPerfil = new pdt_perfilDL();
            return oPerfil.Listar_Perfil();
        }

        public SG_PERFIL Detalle(int piiIdPerfil)
        {
            pdt_perfilDL oPerfil = new pdt_perfilDL();
            return oPerfil.Detalle(piiIdPerfil);
        }

        public int Insertar(SG_PERFIL poPerfil)
        {
            pdt_perfilDL oPerfil = new pdt_perfilDL();
            return oPerfil.Insertar(poPerfil);
        }

        public int Modificar(SG_PERFIL poPerfil)
        {
            pdt_perfilDL oPerfil = new pdt_perfilDL();
            return oPerfil.Modificar(poPerfil);
        }

    }
}
