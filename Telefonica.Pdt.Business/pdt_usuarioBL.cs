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
    public class pdt_usuarioBL
    {
        public pdt_usuarioBL()
        {
            //
            // TODO: agregar aquí la lógica del constructor
            //
        }

        public SG_USUARIO Detalle(int piiIdUsuario)
        {
            pdt_usuarioDL oUsuario = new pdt_usuarioDL();
            return oUsuario.Detalle(piiIdUsuario);
        }

        public DataTable Detalle(String pstrLogin, String pstrClave)
        {
            pdt_usuarioDL oUsuario = new pdt_usuarioDL();
            return oUsuario.Detalle(pstrLogin, pstrClave);
        }

        public DataTable Listar_PorNombre(SG_USUARIO poUsuario)
        {
            pdt_usuarioDL oUsuario = new pdt_usuarioDL();
            return oUsuario.Listar_PorNombre(poUsuario);
        }

        public int Insertar(SG_USUARIO poUsuario)
        {
            pdt_usuarioDL oUsuario = new pdt_usuarioDL();
            return oUsuario.Insertar(poUsuario);
        }

        public int Modificar(SG_USUARIO poUsuario)
        {
            pdt_usuarioDL oUsuario = new pdt_usuarioDL();
            return oUsuario.Modificar(poUsuario);
        }

    }
}
