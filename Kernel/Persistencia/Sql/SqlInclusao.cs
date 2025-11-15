using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using System.Reflection;
using System.Data;
using BPDWeb.Kernel.DB.Atributo;

namespace BPDWeb.Kernel.DB.Sql
{
    public class SqlInclusao
    {
        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }

        public SqlInclusao(DominioDAO dao)
        {
            this._daoDominio = dao;
        }

        public int Incluir()
        {
            string nomesAtributos = "";
            string valoresAtributos = "";


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

                if (valor.Length > 0)
                {
                    valoresAtributos += "," + valor;
                    nomesAtributos += "," + nomeBanco;
                }
                else
                {
                    if (!chavePrimaria)
                    {
                        valoresAtributos += "," + "null";
                        nomesAtributos += "," + nomeBanco;
                    }
                }
            }
            if (valoresAtributos.Length > 0)
            {
                valoresAtributos = valoresAtributos.Substring(1, valoresAtributos.Length - 1);
            }

            if (nomesAtributos.Length > 0)
            {
                nomesAtributos = nomesAtributos.Substring(1, nomesAtributos.Length - 1);
            }

            string nomeTabela = this.RecuperarNomeTabela();
            string chaveSequencia = this.RecuperarChaveSequencia();

            string sqlInsert = @"
                INSERT INTO {0}
                ( {1} )
                VALUES( {2} );
                SELECT currval ('" + chaveSequencia + "') as Chave";
            sqlInsert = string.Format(sqlInsert,nomeTabela,nomesAtributos,valoresAtributos);
            Persistencia p  = new Persistencia(nomeTabela);
            DataSet dsResultado = p.ExecutarConsulta(sqlInsert);
           
            return Convert.ToInt32(dsResultado.Tables[0].Rows[0]["Chave"].ToString());

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
