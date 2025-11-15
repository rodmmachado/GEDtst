using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BPDWeb.Kernel.Cadastro
{
    public class HistoricoRastreamentoCONTROLADOR
    {

        public static HistoricoRastreamentoDAO RecuperarDao(HistoricoRastreamentoDAO dao)
        {
            HistoricoRastreamento dominio = new HistoricoRastreamento(dao);
            return (HistoricoRastreamentoDAO)dominio.RecuperarDao();
        }

        public static int Manter(HistoricoRastreamentoDAO dao)
        {
            HistoricoRastreamento dominio = new HistoricoRastreamento(dao);
            if (dao.IdHistoricoRastreamento <= 0)
            {
                return dominio.Incluir();
            }
            else
            {
                return dominio.Alterar();
            }
        }

        public static void Excluir(HistoricoRastreamentoDAO dao)
        {
            HistoricoRastreamento dominio = new HistoricoRastreamento(dao);
            dominio.Excluir();
        }

        public static DataSet RecuperarListaHistoricoRastreamento()
        {
            HistoricoRastreamento historicoRastreamento = new HistoricoRastreamento();
            return historicoRastreamento.RecuperarListaHistoricoRastreamento();
        }

        public static DataSet RecuperarListaHistoricoRastreamento(int idRegistro)
        {
            HistoricoRastreamento historicoRastreamento = new HistoricoRastreamento();
            return historicoRastreamento.RecuperarListaHistoricoRastreamento(idRegistro);
        }

        public static DataSet RecuperarListaHistoricoRastreamento(string numeroLocalizador)
        {
            HistoricoRastreamento historicoRastreamento = new HistoricoRastreamento();
            return historicoRastreamento.RecuperarListaHistoricoRastreamento(numeroLocalizador);
        }

        public static bool VerificarExistenciaHistoricoRastreamento(string numeroLocalizador, DateTime dataEvento, string localEvento, string situacao)
        {
            HistoricoRastreamento historicoRastreamento = new HistoricoRastreamento();
            return historicoRastreamento.VerificarExistenciaHistoricoRastreamento(numeroLocalizador, dataEvento,localEvento,situacao);
        }
    }
}

