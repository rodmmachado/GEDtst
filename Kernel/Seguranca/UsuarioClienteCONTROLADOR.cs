using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BPDWeb.Kernel.Seguranca
{
    public class UsuarioClienteCONTROLADOR
    {

        public static UsuarioClienteDAO RecuperarDao(UsuarioClienteDAO dao)
        {
            UsuarioCliente dominio = new UsuarioCliente(dao);
            return (UsuarioClienteDAO)dominio.RecuperarDao();
        }

        public static int Manter(UsuarioClienteDAO dao)
        {
            UsuarioCliente dominio = new UsuarioCliente(dao);
            if (dao.IdUsuarioCliente <= 0)
            {
                return dominio.Incluir();
            }
            else
            {
                return dominio.Alterar();
            }
        }

        public static void Excluir(UsuarioClienteDAO dao)
        {
            UsuarioCliente dominio = new UsuarioCliente(dao);
            dominio.Excluir();
        }

        public static DataSet RecuperarListaUsuarioCliente()
        {
            UsuarioCliente usuarioCliente = new UsuarioCliente();
            return usuarioCliente.RecuperarListaUsuarioCliente();
        }        

        public static DataSet RecuperarListaPeloCliente(int idCliente)
        {
            UsuarioCliente usuarioCliente = new UsuarioCliente();
            return usuarioCliente.RecuperarListaPeloCliente(idCliente);
        }

        public static DataSet RecuperarListaPeloUsuario(int idUsuario)
        {
            UsuarioCliente usuarioCliente = new UsuarioCliente();
            return usuarioCliente.RecuperarListaPeloUsuario(idUsuario);
        }
    }
}

