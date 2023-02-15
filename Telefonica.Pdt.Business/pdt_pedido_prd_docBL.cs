using System;
using System.Data;
using System.Collections;
using System.Text;
using Telefonica.Pdt.Entities;
using Telefonica.Pdt.Data;
using Telefonica.Pdt.Common;

namespace Telefonica.Pdt.Business
{
   public class pdt_pedido_prd_docBL
    {
        public pdt_pedido_prd_docBL()
        {
        }

        public DataTable Listar_DocumentoPorPedidoProducto(int pdppc_iIdPedido_Prd)
        {
            pdt_pedido_prd_docDL opdt_pedido_prd_docDL = new pdt_pedido_prd_docDL();
            return opdt_pedido_prd_docDL.Listar_DocumentoPorPedidoProducto(pdppc_iIdPedido_Prd);
        }

       public DataTable Listar_DocumentoPorPedidoProductoTipoDocumetoAdicional(int pdppc_iIdPedido_Prd)
       {
            pdt_pedido_prd_docDL opdt_pedido_prd_docDL = new pdt_pedido_prd_docDL();
            return opdt_pedido_prd_docDL.Listar_DocumentoPorPedidoProductoTipoDocumetoAdicional(pdppc_iIdPedido_Prd);
       }

       public int ModificarEstadoDocumento(int ppdoc_iIdPedido_Doc, int vedoc_iIdEstado_Doc, int pptdc_iIdUsuario_Modifica)
       {
           pdt_pedido_prd_docDL opdt_pedido_prd_docDL = new pdt_pedido_prd_docDL();
           return opdt_pedido_prd_docDL.ModificarEstadoDocumento(ppdoc_iIdPedido_Doc, vedoc_iIdEstado_Doc, pptdc_iIdUsuario_Modifica);
       }

       public int ModificarPublicarDocumento(int ppdoc_iIdPedido_Doc,string Nombre_Ruta_Archivo,byte[] DataArchivo, int pptdc_iIdUsuario_Modifica)
       {
           // Implementar Manejador de Trasacciones.
           string NombreDigitalArchivo = this.NombreDocumentoPublicar(ppdoc_iIdPedido_Doc, Nombre_Ruta_Archivo);
           pdt_pedido_prd_docDL opdt_pedido_prd_docDL = new pdt_pedido_prd_docDL();
           int retorno=opdt_pedido_prd_docDL.ModificarPublicarDocumento(ppdoc_iIdPedido_Doc, NombreDigitalArchivo, pptdc_iIdUsuario_Modifica);
           if (retorno > 0)
           {
               retorno = Funciones.ArchivoGrabarServidor(Nombre_Ruta_Archivo, DataArchivo);
           }

           //if (retorno > 0)
           //{
           //    //implementar Commit;
           //}
           //else
           //{
           //    //implemetar Rollback
           //}

           return retorno;
       }

       public int InsertarPublicarDocumentoAdicional(int pdppc_iIdPedido_Prd, int vtdoc_iIdTip_Doc, string Nombre_Ruta_Archivo,byte[] DataArchivo, int pptdc_iIdUsuario_Registro)
       {
           // Implementar Manejador de Trasacciones.
           int retorno = 0;
           pdt_pedido_prd_docDL opdt_pedido_prd_docDL = new pdt_pedido_prd_docDL();
           retorno = opdt_pedido_prd_docDL.InsertarPublicarDocumentoAdicional(pdppc_iIdPedido_Prd, vtdoc_iIdTip_Doc,null, pptdc_iIdUsuario_Registro);
           if (retorno > 0)
           {
               int ppdoc_iIdPedido_Doc = retorno;
               string NombreDigitalArchivo = this.NombreDocumentoPublicar(ppdoc_iIdPedido_Doc, Nombre_Ruta_Archivo);
               retorno = opdt_pedido_prd_docDL.ModificarPublicarDocumento(ppdoc_iIdPedido_Doc, NombreDigitalArchivo, pptdc_iIdUsuario_Registro);
               if (retorno > 0)
               {
                   retorno = Funciones.ArchivoGrabarServidor(Nombre_Ruta_Archivo, DataArchivo);
               }
           }

           //if (retorno > 0)
           //{
           //    //implementar Commit;
           //}
           //else
           //{
           //    //implemetar Rollback
           //}

           return retorno;
       }

       private string NombreDocumentoPublicar(int IdPedidoDocumento, string NombreRealDocumento)
       {
           const string PrefigoDocumentoArchivo = "PRD-";
           string strNombre=IdPedidoDocumento.ToString("000000000");
           strNombre=PrefigoDocumentoArchivo + strNombre;

           string[] str = NombreRealDocumento.Split('.');

           if (str.Length > 0)
           {
               strNombre =strNombre + "." + str[str.Length - 1];
           }

           return strNombre;
       }
    }
}
