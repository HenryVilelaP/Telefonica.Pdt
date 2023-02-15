using System;
using System.Collections.Generic;
using System.Text;

namespace Telefonica.Pdt.Entities
{
    public class DEPARTAMENTO
    {
        #region "Atributos"

        private string vdepc_vIdDepartamento;
        private string vdepc_vNombre;

        #endregion "Atributos"

        #region "Propiedades"

        public string Vdepc_vIdDepartamento
        {
            get
            {
                return this.vdepc_vIdDepartamento;
            }
            set
            {
                this.vdepc_vIdDepartamento = value;
            }
        }

        public string Vdepc_vNombre
        {
            get
            {
                return this.vdepc_vNombre;
            }
            set
            {
                this.vdepc_vNombre = value;
            }
        }
        
        #endregion "Propiedades"
    }
}
