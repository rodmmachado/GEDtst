using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BPDWeb.Kernel.Cadastro
{
    public class RegistroCONTROLADOR
    {

        public static RegistroDAO RecuperarDao(RegistroDAO dao)
        {
            Registro dominio = new Registro(dao);
            return (RegistroDAO)dominio.RecuperarDao();
        }

        public static int Manter(RegistroDAO dao)
        {
            Registro dominio = new Registro(dao);
            if (dao.IdRegistro <= 0)
            {
                return dominio.Incluir();
            }
            else
            {
                return dominio.Alterar();
            }
        }

        public static void Excluir(RegistroDAO dao)
        {
            Registro dominio = new Registro(dao);
            dominio.Excluir();
        }

        public static DataSet RecuperarListaRegistro(int idEntidade, DateTime dataInicial, DateTime dataFinal, string nome, string cpfCnpj, string numeroContrato, int status, string numeroLocalizador)
        {
            Registro Registro = new Registro();
            return Registro.RecuperarListaRegistro(idEntidade, dataInicial, dataFinal, nome, cpfCnpj, numeroContrato, status, numeroLocalizador);
        }

        public static DataSet RecuperarListaRegistro(int idCliente)
        {
            Registro registro = new Registro();
            return registro.RecuperarListaRegistro(idCliente);
        }


        public static DataSet RecuperarListaRegistro(int idEntidade, string nome, string cpf, string numeroContrato, DateTime dataPostagem)
        {
            Registro registro = new Registro();
            return registro.LocalizarRegistroSite(idEntidade, nome, cpf, numeroContrato, dataPostagem);
        }

        public static DataSet RecuperarRegistroPeloNumeroLocalizador(string numeroLocalizador)
        {
            Registro registro = new Registro();
            return registro.RecuperarRegistroPeloNumeroLocalizador(numeroLocalizador);
        }

        public static DataSet RecuperarListaPorStatus(int idEntidade, int status, string pathArquivo)
        {
            Registro registro = new Registro();
            return registro.RecuperarListaArPorStatus(idEntidade, status, pathArquivo);
        }

        public static DataSet RecuperarListaArParaBaixarHistorico(int idEntidade)     
        {
            Registro registro = new Registro();
            return registro.RecuperarListaArParaBaixarHistorico(idEntidade);
        }

        public static DataSet RecuperarListaRegistrosDevolvidosPendentesEmail(int idEntidade)
        {
            Registro registro = new Registro();
            return registro.RecuperarListaRegistrosDevolvidosPendentesEmail(idEntidade);
        }

        public static DataSet RecuperarListaRegistrosPendentesRetorno(int idEntidade, int quantidadeDias)
        {
            Registro registro = new Registro();
            return registro.RecuperarListaRegistrosPendentesRetorno(idEntidade, quantidadeDias);
        }

        public static void MarcarRegistrosComoRelatorioEnviado(int idEntidade)
        {
            Registro registro = new Registro();
            registro.MarcarRegistrosComoRelatorioEnviado(idEntidade);
        }

        public static bool VerificarExistenciaExportacao(string numeroLocalizador)
        {
            Registro registro = new Registro();
            return registro.VerificarExistenciaExportacao(numeroLocalizador);
        }

        public static string ImportarArquivoControleRetorno(string nomeArquivo, DateTime dataRetorno)
        {
            Registro registro = new Registro();
            return registro.ImportarArquivoControleRetorno(nomeArquivo, dataRetorno);
        }

        public static string ImportarArquivoControleRetornoXLS(string numeroLocalizador)
        {
           Registro registro = new Registro();
           return registro.ImportarArquivoControleRetornorXLS(numeroLocalizador);
        }

        


    }
}

