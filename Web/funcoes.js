function posiciona(ident)
{
  x = 399;
  y = 400;
  pos_y = (screen.availHeight/2)-(y/2);
  pos_x = (screen.availWidth/2)-(x/2);
  document.getElementById(ident).style.top = pos_y+"px";	
  document.getElementById(ident).style.left = pos_x+"px";
  document.getElementById('desliga').style.display = 'inline';
}

function div_pop_conteudo(ident,conteudo,titulo,texto,textotitulo)
{
   document.getElementById(ident).style.display = 'inline';
   var conteudo = document.getElementById(conteudo);
   var conteudotitulo = document.getElementById(titulo);
   conteudo.innerHTML = texto;
   conteudotitulo.innerHTML = textotitulo;
}

function iframeTamanhoTela(quem, ajuste)
{
    var tamanho = screen.availHeight - ajuste;
    
    if(navigator.appName.indexOf("Internet Explorer")>-1)//ie sucks
    { 
        var func_temp = function()
        {
            quem.style.height = tamanho + "px";
        }
        setTimeout(function() { func_temp() },100) //ie sucks
    }
    else
    {
        quem.style.height= tamanho + "px";
    }
}

function iframeAutoHeight(quem)
{
    if(navigator.appName.indexOf("Internet Explorer")>-1){ //ie sucks
        var func_temp = function(){
            var val_temp = quem.contentWindow.document.body.scrollHeight + 5
            quem.style.height = val_temp + "px";
        }
        setTimeout(function() { func_temp() },100) //ie sucks
    }else{
        var val = quem.contentWindow.document.body.parentNode.offsetHeight + 5
        quem.style.height= val + "px";
    }
}

function recalcularValorPagar(form) {
    var desconto = 0;
    var desconto = 0;
    var acrescimo = 0;
    var valorPagar = parseFloat(form['txtValorPagar'].value.replace(",", "."));
    var valorAtualizado = 0;
    var valorInicial = 0;
    var descontoAnt = parseFloat(form['txtDescontoAnt'].value.replace(",", "."));
    var acrescimoAnt = parseFloat(form['txtAcrescimoAnt'].value.replace(",", "."));
    

    if (form['txt_1_Desconto'].value.length > 0)
        desconto = parseFloat(form['txt_1_Desconto'].value.replace(",", "."));

    if (form['txt_1_Acrescimo'].value.length > 0)
        acrescimo = parseFloat(form['txt_1_Acrescimo'].value.replace(",", "."));

    
    if (form['txtValorInicial'].value.length == 0) {
        form['txtValorInicial'].value = valorPagar.toString().replace(".", ",");
        valorInicial = valorPagar;
    }
    else {
        valorInicial = parseFloat(form['txtValorInicial'].value.replace(",", "."));
    }

    if (desconto == descontoAnt)
        desconto = 0;

    if (acrescimo == acrescimoAnt)
        acrescimo = 0;

    valorAtualizado = valorInicial - desconto + acrescimo;             
    valorAtualizado = valorAtualizado.toFixed(2);
    form['txtValorPagar'].value = valorAtualizado.toString().replace(".", ",");
}

var nomeObjetoBotaoPesquisar = "btnPesquisar";

String.prototype.trim = function() {
a = this.replace(/^\s+/, '');
return a.replace(/\s+$/, '');
};

function kH(e)
{
    var pK = e ? e.which : window.event.keyCode;
    var isEnter = (pK == 13);
    
    if(isEnter)
        document.all(nomeObjetoBotaoPesquisar).click();
    
    return !isEnter;
}
document.onkeypress = kH;

if (document.layers)
{
    document.captureEvents(Event.KEYPRESS);
}

function FormatarCampoMoeda(fld, milSep, decSep, e){
	var sep = 0;
	var key = '';
	var i = j = 0;
	var len = len2 = 0;
	var strCheck = '0123456789';
	var aux = aux2 = '';
	var whichCode = (window.Event) ? e.which : e.keyCode;
	if (whichCode == 13) return true;
	key = String.fromCharCode(whichCode);  // Valor para o código da Chave
	if (strCheck.indexOf(key) == -1) return false;  // Chave inválida
	len = fld.value.length;
	for(i = 0; i < len; i++)
	if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;
	aux = '';
	for(; i < len; i++)
		if (strCheck.indexOf(fld.value.charAt(i))!=-1) aux += fld.value.charAt(i);
			aux += key;
	len = aux.length;
	if (len == 0) fld.value = '';
	if (len == 1) fld.value = '0'+ decSep + '0' + aux;
	if (len == 2) fld.value = '0'+ decSep + aux;
	if (len > 2) {
	aux2 = '';
	for (j = 0, i = len - 3; i >= 0; i--) {
		if (j == 3) {
			aux2 += milSep;
			j = 0;
		}
		aux2 += aux.charAt(i);
		j++;
	}
	fld.value = '';
	len2 = aux2.length;
	for (i = len2 - 1; i >= 0; i--)
		fld.value += aux2.charAt(i);
	fld.value += decSep + aux.substr(len - 2, len);
	}
	return false;
}

function FormataValor(campo,tammax,teclapres,casasDecimais) {
	var tamSeparador = 3;
	var separador1 = casasDecimais	+ tamSeparador;
	var separador2 = separador1		+ tamSeparador;
	var separador3 = separador2		+ tamSeparador;
	var separador4 = separador3		+ tamSeparador;

	var tecla = teclapres.keyCode;
	vr = campo.value;//document.form[campo].value;
	vr = vr.replace( "/", "" );
	vr = vr.replace( "/", "" );
	vr = vr.replace( ",", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	vr = vr.replace( ".", "" );
	tam = vr.length;
	tammax -= 1;
	
	if (tam < tammax && tecla != 8){ tam = vr.length + 1 ; }

	if (tecla == 8 ){	tam = tam - 1 ; }
		
	if ( tecla == 8 || tecla >= 48 && tecla <= 57 || tecla >= 96 && tecla <= 105 ){
		if ( tam <= casasDecimais ){ 
	 		campo.value = vr ; }
	 	if ( (tam > casasDecimais) && (tam <= separador1) ){
	 		campo.value = vr.substr( 0, tam - casasDecimais ) + ',' + vr.substr( tam - casasDecimais, tam ) ; }
	 	if ( (tam > separador1) && (tam <= separador2) ){
	 		campo.value = vr.substr( 0, tam - separador1 ) + '.' + vr.substr( tam - separador1, 3 ) + ',' + vr.substr( tam - casasDecimais, tam ) ; }
	 	if ( (tam > separador2) && (tam <= separador3) ){
	 		campo.value = vr.substr( 0, tam - separador2 ) + '.' + vr.substr( tam - separador2, 3 ) + '.' + vr.substr( tam - separador1, 3 ) + ',' + vr.substr( tam - casasDecimais, tam ) ; }
	 	if ( (tam > separador3) && (tam <= separador4) ){
	 		campo.value = vr.substr( 0, tam - separador3 ) + '.' + vr.substr( tam - separador3, 3 ) + '.' + vr.substr( tam - separador2, 3 ) + '.' + vr.substr( tam - separador1, 3 ) + ',' + vr.substr( tam - casasDecimais, tam ) ; }
	 	if ( (tam > separador4) && (tam <= separador5) ){
	 		campo.value = vr.substr( 0, tam - separador4 ) + '.' + vr.substr( tam - separador4, 3 ) + '.' + vr.substr( tam - separador3, 3 ) + '.' + vr.substr( tam - separador2, 3 ) + '.' + vr.substr( tam - separador1, 3 ) + ',' + vr.substr( tam - casasDecimais, tam ) ;}
	}
	
}

function ValidarCampoNota(campo, notaMinima, notaMaxima)
{
	var retorno = true;
	var valorCampo = campo.value.replace('.', '').replace(',', '.');
	var valorNota = parseFloat(valorCampo);
	var valorNotaMinima = parseFloat(notaMinima);
	var valorNotaMaxima = parseFloat(notaMaxima);
	
	if( isNaN(valorNota) )
	{
		if(campo.value.length > 0)
		{
			retorno = false;
			campo.focus();
			alert('Digite apenas algarismos numericos.\nPreencha a nota com valores entre ' + valorNotaMinima + ' e ' + valorNotaMaxima + '.');
		}
		else
			if(campo.value.length == 0)
				retorno = false;
	}
	else
	{
		if( !((valorNota >= valorNotaMinima) && (valorNota <= valorNotaMaxima)) )
		{
			retorno = false;
			campo.focus();
			alert('Preencha a nota com valores entre ' + valorNotaMinima + ' e ' + valorNotaMaxima + '.');
		}	
	}
	
	return retorno;
}

function PreencherNota(campo, valor)
{
	var txtValorNota = campo.value.replace('.', '').replace(',', '.');
	if(txtValorNota.length > 0)
	{
		if( txtValorNota.indexOf('.') <= 0)
			campo.value += ','
			
		var valorNota = parseFloat(txtValorNota);
		if( !isNaN(valorNota) )
		{
			campo.value += '' + valor;
		}
	}
}

function Sqr(numero, potencia)
{
	var retorno = numero;
	
	if(potencia <= 0)
		retorno = 1;
	else
		for(var contador = 1 ; contador < potencia ; contador++)
			retorno = (retorno * numero);
		
	return retorno;
}

function Arredondar(numero, casasDecimais)
{

	var retorno = numero;
	retorno = retorno.replace('.', '').replace(',', '.');
	retorno = parseFloat(retorno);
	
	if(casasDecimais <= 0)
	{
		retorno = Math.round( retorno );
	}
	else
	{
		var posVirgula = retorno.toString().indexOf(".");
		var totalCasas = ((retorno.toString().length-1) - posVirgula);
		var multCasas = 0;
		
		for(var cont = 1 ; totalCasas > casasDecimais && posVirgula > 0 ; cont++)
		{
			
			posVirgula = retorno.toString().indexOf(".");
			totalCasas = ((retorno.toString().length-1) - posVirgula);

			multCasas = (totalCasas - 1);
			retorno = (retorno * Sqr(10, multCasas) );
			
			retorno = Math.round(retorno);
			retorno = (retorno / Sqr(10, multCasas) );
		
			posVirgula = retorno.toString().indexOf(".");
			totalCasas = ((retorno.toString().length-1) - posVirgula);
		}
	}
	retorno = retorno.toString().replace('.', ',');
	return retorno;
}

function ArredondarNumeroCampo(campo, casasDecimais, notaMinima, notaMaxima)
{
	var arrendondarNota = ValidarCampoNota(campo, notaMinima, notaMaxima);
	if( arrendondarNota == true )
	{
		campo.value = Arredondar(campo.value, casasDecimais);
		
		var posVirgula = campo.value.toString().indexOf(",");
		var totalCasas = 0;
		
		if(posVirgula > 0)
		{
			totalCasas = ((campo.value.toString().length-1) - posVirgula);
		}
		
		casasDecimais = (casasDecimais - totalCasas);
		
		var strPreencherComZero = '';
		for(cnt = 0 ; cnt < casasDecimais ; cnt++) strPreencherComZero += '0';
		
		PreencherNota(campo, strPreencherComZero);
	}
}

function AbrirJanelaNoCentroTela(strUrl, nomeJanela, intLargura, intAltura)
{
	var intHeight	= screen.availHeight;
	var intWidth	= screen.availWidth;
	
	var metadeAlt	= (intHeight/2);
	var metadeLarg	= (intWidth/2);
	
	var metadeTopo	= (intAltura/2);
	var metadeEsq	= (intLargura/2);
	
	var posTopo	= ( metadeAlt - metadeTopo );
	var posEsq	= ( metadeLarg - metadeEsq );
	
	posTopo -= (posTopo / 2);

	var objJanela = window.open(strUrl, nomeJanela, 'top=' + posTopo + ', left=' + posEsq + ',width=' + intLargura + ', height=' + intAltura + ', scrollbars=1, resizable=1, status=1, menubar=1');
	objJanela.focus();
	return objJanela;
}

function AbrirJanelaTelaCheia(strUrl, nomeJanela)
{
	var objJanela = window.open(strUrl, nomeJanela, 'scrollbars=1, resizable=1, status=1, menubar=1');
	if(objJanela != null)
	{
	    objJanela.moveTo(0,0);
	    objJanela.resizeTo(screen.availWidth, screen.availHeight);

	    objJanela.focus();
	}
	return objJanela;
}

function RecuperarValoresSelecionadosCheckBox(nomeObjetoCheckBox)
{
	var qtdObjetos = this.document.all(nomeObjetoCheckBox).length;
	if(qtdObjetos == null) qtdObjetos=1;
	var listaRetorno = "";
	for(idxObjeto = 0 ; idxObjeto < qtdObjetos ; idxObjeto++)
	{
		var valor = this.document.all(nomeObjetoCheckBox, idxObjeto).value;
		var selecionado = this.document.all(nomeObjetoCheckBox, idxObjeto).checked;
		
		if(selecionado == true)
		{
			if(listaRetorno.length > 0) listaRetorno += ",";
			listaRetorno += valor;
		}

	}
	return listaRetorno;
}

function EscreverTituloDaPagina()
{
	document.write( document.title );
}

function CriarJanelaDeImpressao(tituloPagina, tituloConteudo, conteudoPagina)
{
    var janela = window.open('about:blank', 'ImpressaoFichaAcademica', 'resizable=1, scrollbars=yes, menubar=yes, status=yes');
    janela.document.write('<html>');
    janela.document.write('  <head>');
    janela.document.write('    <title>' + tituloPagina + '</title>');
    janela.document.write('    <LINK href="./_content/StyleSheets/sgain.css" type="text/css" rel="stylesheet">');
    janela.document.write('  </head>');
    janela.document.write('  <body>');
    janela.document.write('    <center><font face=verdana size=2><b>' + tituloConteudo + '</b></font></center>');
    janela.document.write('    <br>');
    janela.document.write('    ' + conteudoPagina + '');
//    janela.document.write('    <br><br>');
//    janela.document.write('    <center><input id="btnImprimir" type="image" src="./_content/imagens/icoImprimir.gif" name="btnImprimir" onclick="window.print();"></center>');
//    janela.document.write('    <br>');
    janela.document.write('  </body>');
    janela.document.write('</html>');
}

//--------------------------------------------------------
function formataMascara(format, field)
{
	var result = "";
	var maskIdx = format.length - 1;
	var error = false;
	var valor = field.value;
	var posFinal = false;
	if( field.setSelectionRange ) 
	{
    	if(field.selectionStart == valor.length)
    		posFinal = true;
    }
	valor = valor.replace(/[^0123456789Xx]/g,'')
	for (var valIdx = valor.length - 1; valIdx >= 0 && maskIdx >= 0; --maskIdx)
	{
		var chr = valor.charAt(valIdx);
		var chrMask = format.charAt(maskIdx);
		switch (chrMask)
		{
		case '#':
			if(!(/\d/.test(chr)))
				error = true;
			result = chr + result;
			--valIdx;
			break;
		case '@':
			result = chr + result;
			--valIdx;
			break;
		default:
			result = chrMask + result;
		}
	}

	field.value = result;
	field.style.color = error ? 'red' : '';
	if(posFinal)
	{
		field.selectionStart = result.length;
		field.selectionEnd = result.length;
	}
	return result;
}

function getTeclaPressionada(evt)
{
	if(typeof(evt)=='undefined')
		evt = window.event;
	return(evt.keyCode ? evt.keyCode : (evt.which ? evt.which : evt.charCode));
}

// teclas 63230 a 63240 = safari
function isTeclaEspecial(key)
{
	return key<32||(key>=35&&key<=36)||(key>=37&&key<=40)||key==46||(key>=63230&&key<=63240);
}

function isTeclaRelevante(key)
{
	return (key == 8)||(key == 46)||(key>=48&&key<=57)||(key>=96&&key<=105);
}

function isCaracterRelevante(key)
{
	return (key == 120)||(key>=48&&key<=57);
}

function StopEvent(evt)
{
	if(document.all)evt.returnValue=false;
	else if(evt.preventDefault)evt.preventDefault();
}

function filtraTeclas(evt)
{
	var key = getTeclaPressionada(evt);
	if(isTeclaEspecial(key) || isTeclaRelevante(key))
		return true;
	StopEvent(evt);
	return false;
}

function filtraCaracteres(evt)
{
	var key = getTeclaPressionada(evt);
	if(isTeclaEspecial(key) || isCaracterRelevante(key))
		return true;
	StopEvent(evt);
	return false;
}

function saltaCampo(campo,proxCampo,tamanhoMaximo){
	var vr = campo.value;
	var tam = vr.length;
	if (tam >= tamanhoMaximo)
	{
		proxCampo.focus();
	}
}

       
