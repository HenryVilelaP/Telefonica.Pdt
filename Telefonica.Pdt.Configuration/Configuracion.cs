using System;
using System.Collections;
using System.Configuration;
using Telefonica.Pdt.DAC;
namespace Telefonica.Pdt.Configuration
{
        public class Configuracion
        {

            public Configuracion() 
            { 

            } 

            static public string Cadena_Conexion()
            {
                return ConfigurationManager.AppSettings["Cadena_Conexion"];
            }

            static public string Sistema()
            {
                return ConfigurationManager.AppSettings["Sistema"];
            }

         
            static public DACRequest.TipoOrigenDatos Tipo_Conexion()
            {

                switch (ConfigurationManager.AppSettings["Tipo_Conexion"])
                {
                    case "1" : return DACRequest.TipoOrigenDatos.SQL; 
                    case "2" :return DACRequest.TipoOrigenDatos.ORACLE;
                    case "3": return DACRequest.TipoOrigenDatos.MYSQL;
                    case "4": return DACRequest.TipoOrigenDatos.INFORMIX;

                    default: return DACRequest.TipoOrigenDatos.SQL;
                }
                
            }


                   
    }


}
