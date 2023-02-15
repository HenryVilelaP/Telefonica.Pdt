using System;

namespace Telefonica.Pdt.Entities
{
    public class TABLA_TABLAS
    {

        public TABLA_TABLAS()
        {
        }

        #region "Atributos"

        private int tablc_IdTabla_Tablas;
        private int tablc_iCodigo;
        private string tablc_vDescripcion;
        private string tablc_vDescripcion_Detalle;
        private string tablc_vAbreviatura1;
        private string tablc_vAbreviatura2;
        private decimal? tablc_nValor1;
        private decimal? tablc_nValor2;
        private int? tablc_iOrden;
        private int tablc_iEditable;

        #endregion"Atributos"

        #region "Propiedades"

        public int Tablc_IdTabla_Tablas
        {
            get
            {
                return this.tablc_IdTabla_Tablas;
            }
            set
            {
                this.tablc_IdTabla_Tablas = value;
            }
        }

        public int Tablc_iCodigo
        {
            get
            {
                return this.tablc_iCodigo;
            }
            set
            {
                this.tablc_iCodigo = value;
            }
        }

        public string Tablc_vDescripcion
        {
            get
            {
                return this.tablc_vDescripcion;
            }
            set
            {
                this.tablc_vDescripcion = value;
            }
        }

        public string Tablc_vDescripcion_Detalle
        {
            get
            {
                return this.tablc_vDescripcion_Detalle;
            }
            set
            {
                this.tablc_vDescripcion_Detalle = value;
            }
        }

        public string Tablc_vAbreviatura1
        {
            get
            {
                return this.tablc_vAbreviatura1;
            }
            set
            {
                this.tablc_vAbreviatura1 = value;
            }
        }

        public string Tablc_vAbreviatura2
        {
            get
            {
                return this.tablc_vAbreviatura2;
            }
            set
            {
                this.tablc_vAbreviatura2 = value;
            }
        }

        public decimal? Tablc_nValor1
        {
            get
            {
                return this.tablc_nValor1;
            }
            set
            {
                this.tablc_nValor1 = value;
            }
        }

        public decimal? Tablc_nValor2
        {
            get
            {
                return this.tablc_nValor2;
            }
            set
            {
                this.tablc_nValor2 = value;
            }
        }

        public int? Tablc_iOrden
        {
            get
            {
                return this.tablc_iOrden;
            }
            set
            {
                this.tablc_iOrden = value;
            }
        }

        public int Tablc_iEditable
        {
            get
            {
                return this.tablc_iEditable;
            }
            set
            {
                this.tablc_iEditable = value;
            }
        }

        #endregion "Propiedades"

    }

}