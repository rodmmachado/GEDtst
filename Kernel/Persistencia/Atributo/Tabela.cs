using System;
using System.Collections.Generic;
using System.Text;


namespace BPDWeb.Kernel.DB.Atributo
{
    public class Tabela : Attribute
    {
        /// <summary>
        /// Nome da tabela no banco de dados
        /// </summary>
        private string _nomeTabela;
        public string NomeTabela
        {
            get { return _nomeTabela; }
            set { _nomeTabela = value; }
        }

        
        private string _chaveTabela;
        /// <summary>
        /// Nome da chave sequencial da tabela no banco de dados
        /// </summary>
        public string ChaveTabela
        {
            get { return _chaveTabela; }
            set { _chaveTabela = value; }
        }


        public Tabela(string tabela, string chaveTabela)
        {
            this._nomeTabela = tabela;
            this._chaveTabela = chaveTabela;
        }
    }
}
