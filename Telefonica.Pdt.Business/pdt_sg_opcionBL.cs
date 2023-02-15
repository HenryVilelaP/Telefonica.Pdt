using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_sg_opcionBL
    {
        public pdt_sg_opcionBL()
        {
        }

        public DataTable Lista_Opcion(string piStrDescripcion, int piIntTipoOpcion)
        {
            pdt_sg_opcionDL oOpcion = new pdt_sg_opcionDL();
            return oOpcion.Lista_Opcion(piStrDescripcion, piIntTipoOpcion);
        }

        public DataTable Lista_Menu_Opciones(string pStrLogin)
        {
            pdt_sg_opcionDL oOpcion = new pdt_sg_opcionDL();
            return oOpcion.Lista_Menu_Opciones(pStrLogin);
        }

        public SG_OPCION Detalle(int piIdOpcion)
        {
            pdt_sg_opcionDL oOpcion = new pdt_sg_opcionDL();
            return oOpcion.Detalle(piIdOpcion);
        }

        public int Insertar(SG_OPCION poOpcion)
        {
            pdt_sg_opcionDL oOpcion = new pdt_sg_opcionDL();
            return oOpcion.Insertar(poOpcion);
        }

        public int Modificar(SG_OPCION poOpcion)
        {
            pdt_sg_opcionDL oOpcion = new pdt_sg_opcionDL();
            return oOpcion.Modificar(poOpcion);
        }

    }
}
