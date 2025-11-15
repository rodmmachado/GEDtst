using System;
using System.Collections.Generic;
using System.Text;

namespace BPDWeb.Kernel.Seguranca
{
    public class EstruturaUsuario
    {
        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }        
        }

        private int _idEntidade;
        public int IdEntidade
        {
            get { return _idEntidade; }
            set { _idEntidade = value; }
        }

        private int _tipo;
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

    }
}
