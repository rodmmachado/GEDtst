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
    public class Sql
    {
        private DominioDAO _daoDominio;
        public DominioDAO DaoDominio
        {
            get { return _daoDominio; }
            set { _daoDominio = value; }
        }

        public Sql(DominioDAO dao)
        {
            this._daoDominio = dao;
        }

        public Sql()
        {
            this._daoDominio = new DominioDAO();
        }

        public DominioDAO RecuperarDao()
        {            
            string nomesAtributos = "";
            string campoChave = "";
            string valorCampoChave = "";


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
                PropertyInfo propiedadeChaveEstrangeira = tipoAtributo.GetProperty("ChavePrimaria");
                PropertyInfo propiedadeNomeMensagemErro = tipoAtributo.GetProperty("NomeMenssagem");
                PropertyInfo propiedadeValorBase = tipoAtributo.GetProperty("ValorBase");

                string nomeBanco = propiedadeNomeBanco.GetValue(atributo, null).ToString();
                bool campoObrigatorio = Convert.ToBoolean(propiedadeCampoObrigatorio.GetValue(atributo, null));
                bool chavePrimaria = Convert.ToBoolean(propiedadeChavePrimaria.GetValue(atributo, null));
                bool chaveEstrangeira = Convert.ToBoolean(propiedadeChaveEstrangeira.GetValue(atributo, null));
                bool valorBase = Convert.ToBoolean(propiedadeValorBase.GetValue(atributo, null));
                string mensagemErro = propiedadeNomeMensagemErro.GetValue(atributo, null).ToString();
                validarAtributo = new ValidarAtributo();
                string valor = validarAtributo.ValidarInclusao(propiedade, campoObrigatorio, mensagemErro, this.DaoDominio, false, valorBase);
                                
                    nomesAtributos += "," + nomeBanco;
                    if (chavePrimaria)
                    {
                        campoChave = nomeBanco;
                        valorCampoChave = valor;
                    }
            }
          
            if (nomesAtributos.Length > 0)
            {
                nomesAtributos = nomesAtributos.Substring(1, nomesAtributos.Length - 1);
            }

            string nomeTabela = this.RecuperarNomeTabela();
           

            string sql = @"
                SELECT {0}
                FROM {1}                
                WHERE {2} = {3}";
            if (valorCampoChave.Length <= 0)
            {
                valorCampoChave = "0";
            }
            sql = string.Format(sql, nomesAtributos, nomeTabela, campoChave,valorCampoChave);
            Persistencia p = new Persistencia(nomeTabela);
            DataSet dsResultado = p.ExecutarConsulta(sql);
            if (dsResultado.Tables[0].Rows.Count > 0)
            {
                MontarDaoDataRow m = new MontarDaoDataRow(this.DaoDominio,dsResultado.Tables[0].Rows[0]);
                this.DaoDominio = m.PopularDao();
            }
            return this.DaoDominio;
        }

        public DataSet RecuperarListaDao()
        {
            List<DominioDAO> lista = new List<DominioDAO>();
            string nomesAtributos = "";
            string campoChave = "";
            string valorCampoChave = "";

           
            Type tipo = this.DaoDominio.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach (PropertyInfo propiedade in propiedades)
            {

                object atributo = propiedade.GetCustomAttributes(typeof(Coluna), false)[0];

                Type tipoAtributo = atributo.GetType();
                PropertyInfo propiedadeNomeBanco = tipoAtributo.GetProperty("NomeColuna");


                string nomeBanco = propiedadeNomeBanco.GetValue(atributo, null).ToString();


                nomesAtributos += "," + nomeBanco;

            }

            if (nomesAtributos.Length > 0)
            {
                nomesAtributos = nomesAtributos.Substring(1, nomesAtributos.Length - 1);
            }

            string nomeTabela = this.RecuperarNomeTabela();


            string sql = @"
                SELECT {0}
                FROM {1}";


            sql = string.Format(sql, nomesAtributos, nomeTabela, campoChave, valorCampoChave);
            Persistencia p = new Persistencia(nomeTabela);
            DataSet dsResultado = p.ExecutarConsulta(sql);
            return dsResultado;
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
