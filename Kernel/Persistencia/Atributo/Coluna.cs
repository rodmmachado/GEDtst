using System;
using System.Collections.Generic;
using System.Text;


namespace BPDWeb.Kernel.DB.Atributo
{
    public class Coluna : Attribute
    {
        private string _nomeColuna;
        public string NomeColuna
        {
            get { return _nomeColuna; }
            set { _nomeColuna = value; }
        }

        private bool _obrigatoria;
        public bool Obrigatoria
        {
            get { return _obrigatoria; }
            set { _obrigatoria = value; }
        }

        private bool _chavePrimaria;
        public bool ChavePrimaria
        {
            get { return _chavePrimaria; }
            set { _chavePrimaria = value; }
        }

        private string _nomeMensagem;
        public string NomeMenssagem
        {
            get { return _nomeMensagem; }
            set { _nomeMensagem = value; }
        }

        private bool _chaveEstrangeira;
        public bool ChaveEstrangeira
        {
            get { return _chaveEstrangeira; }
            set { _chaveEstrangeira = value; }
        }

        private bool _valorBase;
        public bool ValorBase
        {
            get { return _valorBase; }
            set { _valorBase = value; }
        }	


        public Coluna(string nomeColuna,bool obrigatoria,bool chavePrimaria,bool chaveEstrangeira,string nomeMensagem)
        {
            this._nomeColuna = nomeColuna;
            this.Obrigatoria = obrigatoria;
            this.ChavePrimaria = chavePrimaria;
            this.NomeMenssagem = nomeMensagem;
            this.ChaveEstrangeira = chaveEstrangeira;
        }


        public Coluna(string nomeColuna, bool obrigatoria, bool chavePrimaria, bool chaveEstrangeira, string nomeMensagem, bool valorBase)
        {
            this._nomeColuna = nomeColuna;
            this.Obrigatoria = obrigatoria;
            this.ChavePrimaria = chavePrimaria;
            this.NomeMenssagem = nomeMensagem;
            this.ChaveEstrangeira = chaveEstrangeira;
            this.ValorBase = valorBase;
        }
    }
}
