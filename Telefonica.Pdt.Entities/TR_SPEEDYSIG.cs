using System;

namespace Telefonica.Pdt.Entities
{
    public class TR_SPEEDYSIG
    {

        public TR_SPEEDYSIG()
        {
        }

        #region "Atributos"

        private string pedido;
        private string empresa;
        private string segmento;
        private string estado;
        private decimal telefono;
        private decimal? inscripcion;
        private DateTime? fecha_Registro;
        private DateTime? fecha_liquidacion;
        private string fecha_Devolucion;
        private string motivo_Devolucion;
        private DateTime? fecha_Reprogramacion;
        private string motivo_Reprogramacion;
        private DateTime? fecha_Cancelacion;
        private string motivo_Cancelacion;
        private string ciudad;
        private int? ciclo_Fact;
        private decimal? cod_Cliente;
        private string cliente;
        private string direccion;
        private string referencia;
        private decimal? cod_Facturacion;
        private string persona_Contacto;
        private decimal? fono_Contacto;
        private decimal? cod_Vendedor;
        private string vendedor;
        private string tipo_cliente;
        private string canal_de_venta;
        private decimal? pedido_Numerico;
        private int? q_pcs;

        private string producto;
        private string paquete;
        private int? cant;
        private string nroSerie;
        private string peroodo;
        private string estado1;
        //private string tipo_Cliente;
        private string cpu;
        private string rAM;
        private string sistemaOperativo;
        private string procesador;

        #endregion"Atributos"

        #region "Propiedades"

        public string Pedido
        {
            get
            {
                return this.pedido;
            }
            set
            {
                this.pedido = value;
            }
        }

        public string Empresa
        {
            get
            {
                return this.empresa;
            }
            set
            {
                this.empresa = value;
            }
        }

        public string Segmento
        {
            get
            {
                return this.segmento;
            }
            set
            {
                this.segmento = value;
            }
        }

        public string Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public decimal Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public decimal? Inscripcion
        {
            get
            {
                return this.inscripcion;
            }
            set
            {
                this.inscripcion = value;
            }
        }

        public DateTime? Fecha_Registro
        {
            get
            {
                return this.fecha_Registro;
            }
            set
            {
                this.fecha_Registro = value;
            }
        }

        public DateTime? Fecha_liquidacion
        {
            get
            {
                return this.fecha_liquidacion;
            }
            set
            {
                this.fecha_liquidacion = value;
            }
        }

        public string Fecha_Devolucion
        {
            get
            {
                return this.fecha_Devolucion;
            }
            set
            {
                this.fecha_Devolucion = value;
            }
        }

        public string Motivo_Devolucion
        {
            get
            {
                return this.motivo_Devolucion;
            }
            set
            {
                this.motivo_Devolucion = value;
            }
        }

        public DateTime? Fecha_Reprogramacion
        {
            get
            {
                return this.fecha_Reprogramacion;
            }
            set
            {
                this.fecha_Reprogramacion = value;
            }
        }

        public string Motivo_Reprogramacion
        {
            get
            {
                return this.motivo_Reprogramacion;
            }
            set
            {
                this.motivo_Reprogramacion = value;
            }
        }

        public DateTime? Fecha_Cancelacion
        {
            get
            {
                return this.fecha_Cancelacion;
            }
            set
            {
                this.fecha_Cancelacion = value;
            }
        }

        public string Motivo_Cancelacion
        {
            get
            {
                return this.motivo_Cancelacion;
            }
            set
            {
                this.motivo_Cancelacion = value;
            }
        }

        public string Ciudad
        {
            get
            {
                return this.ciudad;
            }
            set
            {
                this.ciudad = value;
            }
        }

        public int? Ciclo_Fact
        {
            get
            {
                return this.ciclo_Fact;
            }
            set
            {
                this.ciclo_Fact = value;
            }
        }

        public decimal? Cod_Cliente
        {
            get
            {
                return this.cod_Cliente;
            }
            set
            {
                this.cod_Cliente = value;
            }
        }

        public string Cliente
        {
            get
            {
                return this.cliente;
            }
            set
            {
                this.cliente = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

        public string Referencia
        {
            get
            {
                return this.referencia;
            }
            set
            {
                this.referencia = value;
            }
        }

        public decimal? Cod_Facturacion
        {
            get
            {
                return this.cod_Facturacion;
            }
            set
            {
                this.cod_Facturacion = value;
            }
        }

        public string Persona_Contacto
        {
            get
            {
                return this.persona_Contacto;
            }
            set
            {
                this.persona_Contacto = value;
            }
        }

        public decimal? Fono_Contacto
        {
            get
            {
                return this.fono_Contacto;
            }
            set
            {
                this.fono_Contacto = value;
            }
        }

        public decimal? Cod_Vendedor
        {
            get
            {
                return this.cod_Vendedor;
            }
            set
            {
                this.cod_Vendedor = value;
            }
        }

        public string Vendedor
        {
            get
            {
                return this.vendedor;
            }
            set
            {
                this.vendedor = value;
            }
        }

        public string Tipo_cliente
        {
            get
            {
                return this.tipo_cliente;
            }
            set
            {
                this.tipo_cliente = value;
            }
        }

        public string Canal_de_venta
        {
            get
            {
                return this.canal_de_venta;
            }
            set
            {
                this.canal_de_venta = value;
            }
        }

        public decimal? Pedido_Numerico
        {
            get
            {
                return this.pedido_Numerico;
            }
            set
            {
                this.pedido_Numerico = value;
            }
        }

        public int? Q_pcs
        {
            get
            {
                return this.q_pcs;
            }
            set
            {
                this.q_pcs = value;
            }
        }


        public string Producto
        {
            get { return this.producto; }
            set { this.producto = value; }
        }
        public string Paquete
        {
            get { return this.paquete;}
            set { this.paquete = value; }
        }
        public int? Cant
        {
            get { return this.cant;}
            set { this.cant = value; }
        }
        public string NroSerie
        {
            get { return this.nroSerie;}
            set { this.nroSerie = value; }
        }
        public string Peroodo
        {
            get { return this.peroodo;}
            set { this.peroodo = value; }
        }
        public string Estado1
        {
            get { return this.estado1;}
            set { this.estado1 = value; }
        }
        //public string Tipo_Cliente
        //{
        //    get { return this.tipo_Cliente;}
        //    set { this.tipo_Cliente = value; }
        //}
        public string Cpu
        {
            get { return this.cpu;}
            set { this.cpu = value; }
        }
        public string RAM
        {
            get { return this.rAM;}
            set { this.rAM = value; }
        }
        public string SistemaOperativo
        {
            get { return this.sistemaOperativo;}
            set { this.sistemaOperativo = value; }
        }
        public string Procesador
        {
            get { return this.procesador;}
            set { this.procesador = value; }
        }

        #endregion "Propiedades"

    }

}
