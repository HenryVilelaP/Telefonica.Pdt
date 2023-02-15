using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Telefonica.Pdt.Data;

namespace Telefonica.Pdt.Business
{
    public class pdt_ubigeoBL
    {
        public DataTable Listar_Departamentos()
        {
            DataTable dtDepartamento;

            pdt_departamentoDL objDepartamento= new pdt_departamentoDL();
            dtDepartamento = objDepartamento.Listar();
            return dtDepartamento;
        }

        public DataTable Listar_ProvinciaPorDepartamento(string pstrIdDepartamento)
        {
            DataTable dtProvincia;

            pdt_provinciaDL objDepartamento = new pdt_provinciaDL();
            dtProvincia = objDepartamento.Listar_Por_Departamento(pstrIdDepartamento);
            return dtProvincia;
        }

        public DataTable Listar_DistritoPorProvincia(string pstrIdDepartamento, string pstrIdProvincia)
        {
            DataTable dtDistrito;

            pdt_distritoDL objDepartamento = new pdt_distritoDL();
            dtDistrito = objDepartamento.Listar_Por_Provincia(pstrIdDepartamento, pstrIdProvincia);
            return dtDistrito;
        }
    }
}
