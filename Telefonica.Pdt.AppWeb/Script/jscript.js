// **************************************************************************************************
// BEGIN==INICIO. FUNCIONES Y VARIALES USADAS PARA CONFIGURAR LA GRILLA. AL HACER CLICK O AL MOVER EL RATON.
// **************************************************************************************************

		var CssClassNombreItemGrillaXgYzk37H;
		var ObjetoSelectClickAnteriorXgYzk37H;
		var CssClassNombreAnteriorItemGrillaXgYzk37H;
		var ObjetoSelectClickActualXgYzk37H;
		
		function CambiarColorPasarMouseOver(ObjetoSelect)
		{
			ObjetoSelect.style.cursor='hand';
			if(ObjetoSelect!=ObjetoSelectClickAnteriorXgYzk37H)
			{
				CssClassNombreItemGrillaXgYzk37H=ObjetoSelect.className;
				ObjetoSelect.className="ItemGrillaPasarMouse";
				ObjetoSelectClickActualXgYzk37H=ObjetoSelect;
			}
		}
		
		function CambiarColorPasarMouseOut(ObjetoSelect)
		{
			if(ObjetoSelect!=ObjetoSelectClickAnteriorXgYzk37H)
			{
				ObjetoSelect.className=CssClassNombreItemGrillaXgYzk37H;
			}
		}
		
		function CambiarColorSeleccion()
		{
		//Codigo comentado con la finalidad que ya no se selecciones las filas de los items.
        			if(ObjetoSelectClickAnteriorXgYzk37H!=null)
        			{
        				if(ObjetoSelectClickActualXgYzk37H!=ObjetoSelectClickAnteriorXgYzk37H)
        				{
        					ObjetoSelectClickAnteriorXgYzk37H.className=CssClassNombreAnteriorItemGrillaXgYzk37H;

        					ObjetoSelectClickAnteriorXgYzk37H=ObjetoSelectClickActualXgYzk37H;
        					CssClassNombreAnteriorItemGrillaXgYzk37H=CssClassNombreItemGrillaXgYzk37H;
        				}
        			}
        			else
        			{
        					ObjetoSelectClickAnteriorXgYzk37H=ObjetoSelectClickActualXgYzk37H;
        					CssClassNombreAnteriorItemGrillaXgYzk37H=CssClassNombreItemGrillaXgYzk37H;
        			}
        			ObjetoSelectClickActualXgYzk37H.className="ItemGrillaHacerClick";
		}				

// **************************************************************************************************
// END==FIN. FUNCIONES Y VARIALES USADAS PARA CONFIGURAR LA GRILLA. AL HACER CLICK O AL MOVER EL RATON.
// **************************************************************************************************

		function MostrarDatosEnCajaTexto(ptxtObjeto,ptxtValor)
		{
			//document.forms[0].elements[ptxtObjeto].value="";
			document.forms[0].elements[ptxtObjeto].value=ptxtValor;
			return;
		}
		
		function VerificarSeleccionControl(NombreControl,Mensaje)
		{
			if(document.forms[0].elements[NombreControl].value=='') 
			{
				alert (Mensaje);
				return false;
			}
			else
			{
				return true;
			}
		}		
		
		function ConfimarEliminarRegistroWeb(NombreIdControl,MensajeErrorSeleccionar,MensajeConfirmacionEliminar)
		{ 
			if(document.forms[0].elements[NombreIdControl].value!= '') 
			{
				if(confirm(MensajeConfirmacionEliminar)==false)
				{
					return false;
				}				
				return true;
			}
			else
			{
				alert (MensajeErrorSeleccionar);
				return false;
			}
		}
		
		function ConfimarSeleccionarRegistro(NombreIdControl,MensajeErrorSeleccionar,MensajeConfirmacionSeleccionar)
		{ 
			if(document.forms[0].elements[NombreIdControl].value!= '') 
			{
				return confirm(MensajeConfirmacionSeleccionar);
			}
			else
			{
				alert (MensajeErrorSeleccionar);
				return false;
			}
		}
		
		function ConfirmarAccionProceso(MensajeConfirmacion)
		{
			return confirm(MensajeConfirmacion);
		}
		
		function BloquearPostBackAlPrecionarTecla()
		{
			if(event.keyCode==13) return false;
			//if(event.keyCode==9) return false;
			//if(event.keyCode==11) return false;
		}
		
		function ConfigurarPaginaWebAlCargarla()
		{
			return false;
		}
		
		function ConfigurarPaginaWebAlDescargarla()
		{
			return false;
		}
		
		function trim(argvalue)
		{
			var tmpstr = ltrim(argvalue);
			return rtrim(tmpstr);
		}

		function rtrim(argvalue) 
		{
			while (1) 
			{
				if (argvalue.substring(argvalue.length - 1, argvalue.length) != " ")
				break;
				argvalue = argvalue.substring(0, argvalue.length - 1);
			}
			return argvalue;
		}

		function ltrim(argvalue) 
		{
			while (1) 
			{
				if (argvalue.substring(0, 1) != " ")
				break;
				argvalue = argvalue.substring(1, argvalue.length);
			}
			return argvalue;
		}

		function CargarFormularioEnFrame(UrlReporte)
		{
			document.write("<iframe src=" + UrlReporte +" width=100% height=100% scrolling=no></iframe> <inoframes > </inoframes>");
		}
		
		function SetFocusControlHtml(IdControl)
		{
			document.getElementById(IdControl).focus();
		}