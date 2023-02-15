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
    public class pdt_turnoBL
    {
        public pdt_turnoBL()
        {   

        }

        public DataTable Listar()
        {
            pdt_turnoDL oTurno = new pdt_turnoDL();
            return oTurno.Listar();
        }

        public SG_TURNO Detalle(int piiIdTurno)
        {
            pdt_turnoDL oTurno = new pdt_turnoDL();
            return oTurno.Detalle(piiIdTurno);
        }

        public int Insertar(SG_TURNO poTurno)
        {
            pdt_turnoDL oTurno = new pdt_turnoDL();
            return oTurno.Insertar(poTurno);
        }

        public int Modificar(SG_TURNO poTurno)
        {
            pdt_turnoDL oTurno = new pdt_turnoDL();
            return oTurno.Modificar(poTurno);
        }

    }
}
