using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using System.Reflection;

namespace BPDWeb.Kernel.DB.Atributo
{
    public class ManipuladorPropiedade
    {
        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }

        public ManipuladorPropiedade(DominioDAO daoDominio)
        {
            this.DaoDominio = daoDominio;
        }

        public string RetornaListaValoresAtributosPropiedades(string nomeAtributo)
        {
            string valoresAtributos = "";
            Type tipo = this.DaoDominio.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (PropertyInfo propiedade in propiedades)	
            {
                object[] atributos = propiedade.GetCustomAttributes(typeof(Coluna),false);
                foreach (object atributo in atributos)
                {
                    Type tipoAtributo = atributo.GetType();
                    PropertyInfo propiedadeAtributo = tipoAtributo.GetProperty(nomeAtributo);
                    valoresAtributos += propiedadeAtributo.GetValue(atributo, null).ToString();                   
                }   
            }
            return valoresAtributos;
        }
    }
}
