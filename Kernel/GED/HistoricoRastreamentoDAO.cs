using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB.Atributo;
using System;

namespace BPDWeb.Kernel.Cadastro
{
    [Tabela("historico_rastreamento", "historico_rastreamento_id_historico_rastreamento_seq")]
    public class HistoricoRastreamentoDAO : DominioDAO
    {

        private int _idHistoricoRastreamento;
        [Coluna("id_historico_rastreamento", false, true, false, "Identificador do HistoricoRastreamento")]
        public int IdHistoricoRastreamento
        {
            get { return _idHistoricoRastreamento; }
            set { _idHistoricoRastreamento = value; }
        }

       
        private int _idRegistro;
        [Coluna("id_registro", false, false, true, "Identificador do Registro")]
        public int IdRegistro
        {
            get { return _idRegistro; }
            set { _idRegistro = value; }
        }

        private DateTime _dataEvento;
        [Coluna("data_evento", false, false, false, "Data do Evento")]
        public DateTime DataEvento
        {
            get { return _dataEvento; }
            set { _dataEvento = value; }
        }

        private string _localEvento;
        [Coluna("local_evento", true, false, false, "Local do Evento ")]
        public string LocalEvento
        {
            get { return _localEvento; }
            set { _localEvento = value; }
        }

        private string _situacao;
        [Coluna("situacao", false, false, false, "Situação")]
        public string Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }
    }
}
