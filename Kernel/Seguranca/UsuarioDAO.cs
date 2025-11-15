using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB.Atributo;
using System;

namespace BPDWeb.Kernel.Seguranca
{
    [Tabela("usuario", "usuario_id_usuario_seq")]
    public class UsuarioDAO : DominioDAO
    {

        private int _idUsuario;
        [Coluna("id_usuario", false, true, false, "Identificador do Usuario")]
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private int _idEntidade;
        [Coluna("id_entidade", true, false, true, "Id Entidade")]
        public int IdEntidade
        {
            get { return _idEntidade; }
            set { _idEntidade = value; }
        }

        private string _nome;
        [Coluna("nome", true, false, false, "Nome")]
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private string _email;
        [Coluna("email", true, false, false, "E-Mail")]
        public string Email
        {
            get { return _email; }
            set { _email = value.ToLower(); }
        }

        private string _senha;
        [Coluna("senha", true, false, false, "Senha")]
        public string Senha
        {
            get { return _senha; }
            set { _senha = value.ToLower(); }
        }

        private int _tipo;
        [Coluna("tipo", true, false, false, "Tipo")]
        public int Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
    }
}
