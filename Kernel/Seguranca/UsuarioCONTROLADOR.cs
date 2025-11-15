using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BPDWeb.Kernel.Seguranca
{
    public class UsuarioCONTROLADOR
    {

        public static UsuarioDAO RecuperarDao(UsuarioDAO dao)
        {
            Usuario dominio = new Usuario(dao);
            return (UsuarioDAO)dominio.RecuperarDao();
        }

        public static int Manter(UsuarioDAO dao)
        {
            Usuario dominio = new Usuario(dao);
            if (dao.IdUsuario <= 0)
            {
                return dominio.Incluir();
            }
            else
            {
                return dominio.Alterar();
            }
        }

        public static void Excluir(UsuarioDAO dao)
        {
            Usuario dominio = new Usuario(dao);
            dominio.Excluir();
        }

        public static DataSet RecuperarListaUsuario()
        {
            Usuario usuario = new Usuario();
            return usuario.RecuperarListaUsuario();
        }

        public static DataSet RetornarDadosCompletosUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();
            return usuario.RetornarDadosCompletosUsuario(idUsuario);
        }

        public static DataSet EfetuarLogin(string email, string senha)
        {
            Usuario usuario = new Usuario();
            return usuario.EfetuarLogin(email, senha);
        }

        //public static DataSet EfetuarLoginAdministrativo(string email, string senha)
        //{
        //    Usuario usuario = new Usuario();
        //    return usuario.EfetuarLoginAdministrativo(email, senha);
        //}

        public static void EnviarSenha(string email, string ip, string path)
        {
            Usuario usuario = new Usuario();
            usuario.EnviarSenha(email, ip, path);
        }

        public static DataSet RecuperarListaUsuario(int idCliente)
        {
            Usuario usuario = new Usuario();
            return usuario.RecuperarListaUsuario(idCliente);
        }
    }
}

