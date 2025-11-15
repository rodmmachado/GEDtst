using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BPDWeb.Kernel.Cadastro
{
    public class ClienteCONTROLADOR
    {

        public static ClienteDAO RecuperarDao(ClienteDAO dao)
        {
            Cliente dominio = new Cliente(dao);
            return (ClienteDAO)dominio.RecuperarDao();
        }

        public static int Manter(ClienteDAO dao)
        {
            Cliente dominio = new Cliente(dao);
            if (dao.IdCliente <= 0)
            {
                return dominio.Incluir();
            }
            else
            {
                return dominio.Alterar();
            }
        }

        public static void Excluir(ClienteDAO dao)
        {
            Cliente dominio = new Cliente(dao);
            dominio.Excluir();
        }

        public static DataSet RecuperarListaCliente()
        {
            Cliente cliente = new Cliente();
            return cliente.RecuperarListaCliente();
        }

        public static int RetornarIdCliente(int idClienteBPDSystem)
        {
            Cliente cliente = new Cliente();
            return cliente.RetornarIdCliente(idClienteBPDSystem);
        }
    }
}

