using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB.Atributo;
using System;

namespace BPDWeb.Kernel.Cadastro
{
    [Tabela("cliente", "cliente_id_cliente_seq")]
    public class ClienteDAO : DominioDAO
    {

        private int _idCliente;
        [Coluna("id_cliente", false, true, false, "Identificador do Cliente")]
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private int _idClienteBpdSystem;
        [Coluna("id_cliente_bpdsystem", true, false, false, "Identificador do Cliente no BPDSystem")]
        public int IdClienteBpdSystem
        {
            get { return _idClienteBpdSystem; }
            set { _idClienteBpdSystem = value; }
        }

        private string _nomeFantasia;
        [Coluna("nome_fantasia", true, false, false, "Nome Fantasia")]
        public string NomeFantasia
        {
            get { return _nomeFantasia; }
            set { _nomeFantasia = value; }
        }

        private string _razaoSocial;
        [Coluna("razao_social", true, false, false, "Razão Social")]
        public string RazaoSocial
        {
            get { return _razaoSocial; }
            set { _razaoSocial = value; }
        }

        private bool _ativo;
        [Coluna("ativo", true, false, false, "Situacão do Cliente")]
        public bool Ativo
        {
            get { return _ativo; }
            set { _ativo = value; }
        }
    }
}
