using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using System.Data;
using System.Reflection;

namespace BPDWeb.Kernel.DB.Atributo
{
    public class MontarDaoDataRow
    {
        private DataRow _linha;

        public DataRow Linha
        {
            get { return _linha; }
            set { _linha = value; }
        }

        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }
	

        public MontarDaoDataRow(DominioDAO dao, DataRow linha)
        {
            this.DaoDominio = dao;
            this._linha = linha;
        }

        public DominioDAO PopularDao()
        {
            Type tipo = this.DaoDominio.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            ValidarAtributo validarAtributo;
            foreach (PropertyInfo propiedade in propiedades)
            {

                object atributo = propiedade.GetCustomAttributes(typeof(Coluna), false)[0];

                Type tipoAtributo = atributo.GetType();
                PropertyInfo propiedadeNomeBanco = tipoAtributo.GetProperty("NomeColuna");
                PropertyInfo propiedadeChaveEstrangeira = tipoAtributo.GetProperty("ChaveEstrangeira");

                string nomeBanco = propiedadeNomeBanco.GetValue(atributo, null).ToString();
                bool chaveEstrangeira = Convert.ToBoolean(propiedadeChaveEstrangeira.GetValue(atributo, null));
                string valor = this.Linha[nomeBanco].ToString();
                propiedade.SetValue(this.DaoDominio, this.ConverterValor(propiedade,valor),null);

            }
            return this.DaoDominio;
        }

        private object ConverterValor(PropertyInfo objeto, string valor)
        {
            switch (objeto.PropertyType.ToString())
            {
                case "System.Int32":
                    {
                        int inteiro = 0;

                        if (valor.Contains("-"))
                        {
                            inteiro = Convert.ToInt32("0" + valor.Replace("-",""))*(-1);
                        }
                        else 
                        {
                            inteiro = Convert.ToInt32("0"+valor);
                        }                       
                         

                        return inteiro;

                    }

                case "System.String":
                    {  
                        return valor;
                    }

                case "System.DateTime":
                    {
                        try
                        {
                            DateTime data = Convert.ToDateTime(valor);
                            return data;
                        }
                        catch { }
                        {
                            return DateTime.MinValue;
                        }
                    }

                case "System.TimeSpan":
                    {
                        try
                        {
                            TimeSpan time = TimeSpan.Parse(valor);
                            return time;
                        }
                        catch { }
                        {
                            return new TimeSpan();
                        }
                    }

                case "System.Decimal":
                    {
                        decimal @decimal = Convert.ToDecimal("0" + valor);

                        return @decimal;
                    }


                case "System.Int64":
                    {
                        long inteiro = Convert.ToInt64(valor);

                        return inteiro;

                    }

                case "System.Boolean":
                    {
                        if (valor == string.Empty)
                        {
                            valor = "False";
                        }
                        bool inteiro = Convert.ToBoolean(valor);
                        
                        return inteiro;

                    }
            }
            return new object();
        }
    }
}
