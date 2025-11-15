using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Npgsql;

namespace BPDWeb.Kernel.DB
{
    public class Persistencia
    {
        #region---------------------------------Métodos Costrutores-------------------------------------

        /// <summary>
        /// Método costrutor sem parametros
        /// </summary>
        /// <param name="tabela"></param>
        public Persistencia(string tabela)
        {
            //joedata
            //Cria uma uma string de conexão
            stringConexao = "Server=" + System.Configuration.ConfigurationSettings.AppSettings["NomeServidor"] + ";";
            stringConexao += "Port=5432;";
            stringConexao += "User Id=" + System.Configuration.ConfigurationSettings.AppSettings["Usuario"] + ";";
            stringConexao += "Password=" + System.Configuration.ConfigurationSettings.AppSettings["Senha"] + ";";
            stringConexao += "Database=" + System.Configuration.ConfigurationSettings.AppSettings["NomeBanco"] + ";";
            NomeTabela = tabela;
        }

        public Persistencia(string tabela, string nomeBanco)
        {
            //joedata
            //Cria uma uma string de conexão
            stringConexao = "Server=" + System.Configuration.ConfigurationSettings.AppSettings["NomeServidor"] + ";";
            stringConexao += "Port=5432;";
            stringConexao += "User Id=" + System.Configuration.ConfigurationSettings.AppSettings["Usuario"] + ";";
            stringConexao += "Password=" + System.Configuration.ConfigurationSettings.AppSettings["Senha"] + ";";
            stringConexao += "Database=" + nomeBanco + ";";
            NomeTabela = tabela;
        }
        #endregion

        #region---------------------------------Atributos-------------------------------------

        /// <summary>
        /// String para criar uma conexão com o banco de dados
        /// </summary>
        public string stringConexao;


        /// <summary>
        /// Objeto de conexão
        /// </summary>
        private NpgsqlConnection conn;

        /// <summary>
        /// Adaptador Generico de consulta
        /// </summary>
        private NpgsqlDataAdapter daGenerico;


        /// <summary>
        /// Dados retornado das consultas
        /// </summary>
        private DataSet dsGenerico;

        /// <summary>
        /// Nome da tabela
        /// </summary>
        private string NomeTabela;

        private string _valor;
        /// <summary>
        /// 
        /// </summary>
        public string Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                _valor = value;
            }

        }


        private string _coluna;
        /// <summary>
        /// Nome das colunas a serem usadas para as querys
        /// </summary>
        public string Coluna
        {
            get
            {
                return _coluna;
            }
            set
            {
                _coluna = value;
            }
        }


        private string _chaveTabela;
        /// <summary>
        /// Chave da tabela a ser montada a query
        /// </summary>
        public string ChaveTabela
        {
            get
            {
                return _chaveTabela;
            }
            set
            {
                _chaveTabela = value;
            }
        }


        private string _valorChaveTabela;
        /// <summary>
        /// Valor da Chave da tabela a ser montada a query
        /// </summary>
        public string ValorChaveTabela
        {
            get
            {
                return _valorChaveTabela;
            }
            set
            {
                _valorChaveTabela = value;
            }
        }


        private string _chaveSequencia;
        /// <summary>
        /// Chava da tabel a ser montada a query
        /// </summary>
        public string ChaveSequencia
        {
            get
            {
                return _chaveSequencia;
            }
            set
            {
                _chaveSequencia = value;
            }
        }

        #endregion

        #region ------------------------------- Operações-------------------------------

        /// <summary>
        /// Método para abrir uma conexão com a string de conexão montada no web.config
        /// </summary>
        /// <returns>retorna true se a conexão foi aberta</returns>
        private bool AbrirConexao()
        {
            try
            {
                // cria conexão com a string declarada anteriormente
                conn = new NpgsqlConnection(stringConexao);

                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }

        }


        /// <summary>
        /// Método para executar uma consulta sql
        /// </summary>
        /// <returns>retorna um conjunto de dados da consulta</returns>
        public DataSet ExecutarConsulta(string sqlConsulta)
        {
            this.AbrirConexao();

            try
            {
                // liga o adaptador com a consulta e a conexao

                daGenerico = new NpgsqlDataAdapter(sqlConsulta, conn);
                // instancia o dataset
                dsGenerico = new DataSet();
                //Executa os dados
                daGenerico.Fill(dsGenerico, NomeTabela);
            }
            finally
            {
                this.FecharConexao();
            }

            return dsGenerico;
        }

        /// <summary>
        /// Método para fechar a conexão
        /// </summary>
        /// <returns>retorna true se a conexão foi fehada ou nã0</returns>
        private bool FecharConexao()
        {
            try
            {
                conn.Close();


                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Incluir()
        {
            string sql = "";
            sql += " INSERT INTO " + NomeTabela;
            sql += " ( ";

            //Capturando o valores das colunas
            string[] AuxColuna = Coluna.Split('|');
            for (int linha = 0; linha < AuxColuna.Length; linha++)
            {
                sql += AuxColuna[linha].ToString() + ", ";
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += " ) ";
            sql += "VALUES( ";

            //Capturando os valores para incluir
            string[] AuxValor = Valor.Split('|');
            for (int linha = 0; linha < AuxValor.Length; linha++)
            {
                sql += AuxValor[linha].ToString() + ", ";
            }

            sql = sql.Substring(0, sql.Length - 2);

            sql += " );  SELECT currval ('" + this._chaveSequencia + "') as Chave ";

            //			this.AbrirConexao();
            DataSet dsInserir = this.ExecutarConsulta(sql);
            //			this.FecharConexao();
            return dsInserir.Tables[0].Rows[0]["chave"].ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Alterar()
        {
            string sql = "";
            sql += "UPDATE " + this.NomeTabela + " SET ";
            string[] AuxColuna = Coluna.Split('|');
            string[] AuxValor = Valor.Split('|');
            for (int linha = 0; linha < AuxColuna.Length; linha++)
            {
                sql += AuxColuna[linha].ToString() + "= " + AuxValor[linha].ToString() + ", ";
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += "WHERE " + this.ChaveTabela + " = " + this.ValorChaveTabela;
            //			this.AbrirConexao();
            this.ExecutarConsulta(sql);
            //			this.FecharConexao();			
        }

        /// <summary>
        /// 
        /// </summary>
        public void Excluir()
        {
            string sql = "DELETE FROM " + this.NomeTabela + " WHERE " + this.ChaveTabela + " = " + this.ValorChaveTabela;
            //			this.AbrirConexao();
            this.ExecutarConsulta(sql);
            //			this.FecharConexao();		
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet Materializar()
        {
            string sql = "";
            sql += "SELECT ";
            string[] AuxColuna = Coluna.Split('|');
            for (int linha = 0; linha < AuxColuna.Length; linha++)
            {
                sql += AuxColuna[linha].ToString() + ", ";
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += " FROM " + this.NomeTabela + " ";
            sql += " WHERE " + this.ChaveTabela + " = " + this.ValorChaveTabela;
            //			this.AbrirConexao();
            DataSet dsMaterializar = this.ExecutarConsulta(sql);
            //			this.FecharConexao();
            return dsMaterializar;

        }
    }
}
