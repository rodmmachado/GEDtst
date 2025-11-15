using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using System.Reflection;
using BPDWeb.Kernel.DB.Atributo;
using System.Data;

namespace BPDWeb.Kernel.DB.Sql
{
    public class SqlUpdate
    {
        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }

        public SqlUpdate(DominioDAO dao)
        {
            this._daoDominio = dao;
        }

        public int Alterar()
        {
            string valorUpdate = "";
            string campoChavePrimaria = "";
            string valorCampoChavePrimaria = "";


            Type tipo = this.DaoDominio.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            ValidarAtributo validarAtributo;
            foreach (PropertyInfo propiedade in propiedades)
            {
                
                object atributo = propiedade.GetCustomAttributes(typeof(Coluna), false)[0];

                Type tipoAtributo = atributo.GetType();
                PropertyInfo propiedadeNomeBanco = tipoAtributo.GetProperty("NomeColuna");
                PropertyInfo propiedadeCampoObrigatorio = tipoAtributo.GetProperty("Obrigatoria");
                PropertyInfo propiedadeChavePrimaria = tipoAtributo.GetProperty("ChavePrimaria");
                PropertyInfo propiedadeChaveEstrangeira = tipoAtributo.GetProperty("ChaveEstrangeira");
                PropertyInfo propiedadeNomeMensagemErro = tipoAtributo.GetProperty("NomeMenssagem");
                PropertyInfo propiedadeValorBase = tipoAtributo.GetProperty("ValorBase");

                string nomeBanco = propiedadeNomeBanco.GetValue(atributo, null).ToString();
                bool campoObrigatorio = Convert.ToBoolean(propiedadeCampoObrigatorio.GetValue(atributo, null));
                bool chavePrimaria = Convert.ToBoolean(propiedadeChavePrimaria.GetValue(atributo, null));
                bool chaveEstrangeira = Convert.ToBoolean(propiedadeChaveEstrangeira.GetValue(atributo, null));
                bool valorBase = Convert.ToBoolean(propiedadeValorBase.GetValue(atributo, null));
                string mensagemErro = propiedadeNomeMensagemErro.GetValue(atributo, null).ToString();
                validarAtributo = new ValidarAtributo();
                string valor = validarAtributo.ValidarInclusao(propiedade, campoObrigatorio, mensagemErro, this.DaoDominio, true, valorBase);

                if ((valor.Length > 0) && (!chavePrimaria))
                {
                    valorUpdate += "," + nomeBanco + " = " + valor;
                }
                else
                {
                    if (!chavePrimaria)
                    {
                        valorUpdate += "," + nomeBanco + " = null";
                    }
                }

                if (chavePrimaria)
                {
                    campoChavePrimaria = nomeBanco;
                    valorCampoChavePrimaria = valor;
                }
            }
            if (valorUpdate.Length > 0)
            {
                valorUpdate = valorUpdate.Substring(1, valorUpdate.Length - 1);
            }
        
            string nomeTabela = this.RecuperarNomeTabela();
            string chaveSequencia = this.RecuperarChaveSequencia();

            string sqlUpdate = @"
                UPDATE {0} SET
                 {1} 
                WHERE {2} = {3} ";
            sqlUpdate = string.Format(sqlUpdate, nomeTabela, valorUpdate,campoChavePrimaria,valorCampoChavePrimaria);
            Persistencia p  = new Persistencia(nomeTabela);
            DataSet dsResultado = p.ExecutarConsulta(sqlUpdate);
            return Convert.ToInt32(valorCampoChavePrimaria);
        }

        private string RecuperarNomeTabela()
        {
            Type tipoClasse = DaoDominio.GetType();
            object objeto =  tipoClasse.GetCustomAttributes(typeof(Tabela), false)[0];
            Type tipoAtributo =  objeto.GetType();
            PropertyInfo propiedadeAtributo =  tipoAtributo.GetProperty("NomeTabela");
            return propiedadeAtributo.GetValue(objeto,null).ToString();

        }

        private string RecuperarChaveSequencia()
        {
            Type tipoClasse = DaoDominio.GetType();
            object objeto = tipoClasse.GetCustomAttributes(typeof(Tabela), false)[0];
            Type tipoAtributo = objeto.GetType();
            PropertyInfo propiedadeAtributo = tipoAtributo.GetProperty("ChaveTabela");
            return propiedadeAtributo.GetValue(objeto, null).ToString();

        }
    }
}
