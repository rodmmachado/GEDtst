using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB;

namespace BPDWeb.Kernel.Cadastro
{
    public class HistoricoRastreamento : Dominio.Dominio
    {

        public HistoricoRastreamentoDAO HistoricoRastreamentoDAO
        {
            get { return (HistoricoRastreamentoDAO)base.Dao; }
            set { base.Dao = value; }
        }
  

        public HistoricoRastreamento(DominioDAO dao)
            : base(dao)
        {
        }

        public HistoricoRastreamento()
            : base()
        {
        }
     

        public override int Incluir()
        {
            //Verificar existencia de um ar com o mesmo idArBpdSystem
            
            return base.Incluir();
        }
        
        public override bool Excluir()
        {
            //Excluir todos as Aprovacoes
            //Excluir todos os Protocolos
            
            return base.Excluir();
        }

        public DataSet RecuperarListaHistoricoRastreamento()
        {
            string sql = @" SELECT * 
                            FROM historico_rastreamento 
                            ORDER BY id_historico_rastreamento";

            Persistencia persistencia = new Persistencia("historico_rastreamento");
            return persistencia.ExecutarConsulta(sql);
        }

        /// <summary>
        /// Método que retorna uma Lista de HistoricoRastreamentos por Cliente
        /// </summary>
        /// <param name="idCliente">Identificador do Cliente</param>
        /// <returns>Retorna um DataSet contendo os dados dos itens</returns>
        public DataSet RecuperarListaHistoricoRastreamento(int idRegistro)
        {
            Persistencia persistencia = new Persistencia("historico_rastreamento");

            string sql = @" SELECT * 
                            FROM historico_rastreamento
                            WHERE id_registro = {0} 
                            ORDER BY data_evento ";

            sql = String.Format(sql, idRegistro);
            DataSet dsHistoricoRastreamento = persistencia.ExecutarConsulta(sql.ToString());

            return dsHistoricoRastreamento;
        }


        /// <summary>
        /// Método que retorna uma Lista de HistoricoRastreamentos por Cliente
        /// </summary>
        /// <param name="idCliente">Identificador do Cliente</param>
        /// <returns>Retorna um DataSet contendo os dados dos itens</returns>
        public DataSet RecuperarListaHistoricoRastreamento(string numeroLocalizador)
        {
            Persistencia persistencia = new Persistencia("historico_rastreamento");

            string sql = @" SELECT * 
                            FROM historico_rastreamento as hr
                            INNER JOIN registro as r ON (hr.id_registro = r.id_registro)
                            WHERE r.numero_localizador = '{0}'
                            ORDER BY hr.data_evento ";

            sql = String.Format(sql, numeroLocalizador);
            DataSet dsHistoricoRastreamento = persistencia.ExecutarConsulta(sql.ToString());

            return dsHistoricoRastreamento;
        }


        /// <summary>
        /// Método que retorna uma Lista de HistoricoRastreamentos por Cliente
        /// </summary>
        /// <param name="idCliente">Identificador do Cliente</param>
        /// <returns>Retorna um DataSet contendo os dados dos itens</returns>
        public bool VerificarExistenciaHistoricoRastreamento(string numeroLocalizador, DateTime dataEvento, string localEvento, string situacao)
        {
            Persistencia persistencia = new Persistencia("historico_rastreamento");

            string sql = @" SELECT * 
                            FROM historico_rastreamento as hr
                            INNER JOIN registro as r ON (hr.id_registro = r.id_registro)
                            WHERE (r.numero_localizador = '{0}')
                              AND (hr.data_evento = '{1}')
                              AND (hr.local_evento = '{2}')
                              AND (hr.situacao = '{3}')                              
                            ORDER BY hr.data_evento ";

            sql = String.Format(sql, numeroLocalizador, dataEvento.ToString("yyyy-MM-dd HH:mm:ss"),localEvento.Trim(),situacao.Trim());
            DataSet dsHistoricoRastreamento = persistencia.ExecutarConsulta(sql.ToString());

            if (dsHistoricoRastreamento.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}

