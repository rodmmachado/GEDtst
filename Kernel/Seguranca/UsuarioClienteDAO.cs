using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB.Atributo;
using System;

namespace BPDWeb.Kernel.Seguranca
{
    [Tabela("usuario_cliente", "usuario_cliente_id_usuario_cliente_seq")]
    public class UsuarioClienteDAO : DominioDAO
    {

        private int _idUsuarioCliente;
        [Coluna("id_usuario_cliente", false, true, false, "Identificador do Usuario Cliente")]
        public int IdUsuarioCliente
        {
            get { return _idUsuarioCliente; }
            set { _idUsuarioCliente = value; }
        }

        private int _idUsuario;
        [Coluna("id_usuario", true, false, true, "Identificador do Usuario")]
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private int _idCliente;
        [Coluna("id_cliente", true, false, true, "Identificador do Cliente")]
        public int IdCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }        
    }
}
