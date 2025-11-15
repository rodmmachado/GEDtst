using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using System.Reflection;
using BPDWeb.Kernel.DB;
using System.Data;
using BPDWeb.Kernel.DB.Atributo;

namespace BPDWeb.Kernel.DB.Sql
{
    public class SqlExclusao
    {
        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }

        public SqlExclusao(DominioDAO dao)
        {
            this._daoDominio = dao;
        }

        public bool Excluir()
        {

            Type tipo = this.DaoDominio.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (PropertyInfo propiedade in propiedades)
            {
                object atributo = propiedade.GetCustomAttributes(typeof(Coluna), false)[0];
                Type tipoAtributo = atributo.GetType();
                PropertyInfo propiedadeNomeBanco = tipoAtributo.GetProperty("NomeColuna");

                string nomeBanco = propiedadeNomeBanco.GetValue(atributo, null).ToString();
                PropertyInfo propiedadeChavePrimaria = tipoAtributo.GetProperty("ChavePrimaria");
                PropertyInfo propiedadeNomeMensagemErro = tipoAtributo.GetProperty("NomeMenssagem");

                bool chavePrimaria = Convert.ToBoolean(propiedadeChavePrimaria.GetValue(atributo, null));
                if (chavePrimaria == true)
                {
                    string valorChave = propiedade.GetValue(DaoDominio, null).ToString();
                    string sqlExclusao = "DELETE FROM {0} WHERE {1} = {2}";
                    sqlExclusao = string.Format(sqlExclusao, this.RecuperarNomeTabela(), nomeBanco, valorChave);
                    Persistencia p = new Persistencia(this.RecuperarNomeTabela());
                    p.ExecutarConsulta(sqlExclusao);
                    return true;


                }
                //else
                //{
                //    return false;
                //}
            }
            return false;
        }

        private string RecuperarNomeTabela()
        {
            Type tipoClasse = DaoDominio.GetType();
            object objeto = tipoClasse.GetCustomAttributes(typeof(Tabela), false)[0];
            Type tipoAtributo = objeto.GetType();
            PropertyInfo propiedadeAtributo = tipoAtributo.GetProperty("NomeTabela");
            return propiedadeAtributo.GetValue(objeto, null).ToString();

        }

     
    }
}
