using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB;
using System.IO;

namespace BPDWeb.Kernel.Cadastro
{
   public class Registro : Dominio.Dominio
   {
      public const int PROCESSADO = 0;
      public const int POSTADO = 1;
      public const int AG_CLASSIFICACAO = 2;
      public const int POSITIVO = 3;
      public const int NEGATIVO = 4;
      public const int PI = 5;

      #region ___________________Propiedades_______________________

      public RegistroDAO RegistroDAO
      {
         get { return (RegistroDAO)base.Dao; }
         set { base.Dao = value; }
      }
      #endregion

      #region ____________________Construtores_____________________

      public Registro(DominioDAO dao)
         : base(dao)
      {
      }

      public Registro()
         : base()
      {
      }
      #endregion

      #region ________________Métodos Sobrescritos_________________

      public override int Incluir()
      {
         //Verificregistro existencia de um registro com o mesmo idRegistroBpdSystem

         return base.Incluir();
      }

      public override bool Excluir()
      {
         //Excluir todos as Aprovacoes
         //Excluir todos os Protocolos

         return base.Excluir();
      }


      #endregion

      #region ______________________SQL_____________________

      public DataSet RecuperarListaRegistro()
      {
         string sql = @" SELECT * 
                            FROM registro 
                            ORDER BY data";
         Persistencia persistencia = new Persistencia("registro");
         return persistencia.ExecutarConsulta(sql);
      }

      /// <summregistroy>
      /// Método que retorna uma Lista de Registros por Cliente
      /// </summregistroy>
      /// <pregistroam name="idCliente">Identificador do Cliente</pregistroam>
      /// <returns>Retorna um DataSet contendo os dados dos itens</returns>
      public DataSet RecuperarListaRegistro(int idRegistro)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" SELECT * 
                            FROM registro
                            WHERE id_registro = {0} 
                            ORDER BY data ";

         sql = String.Format(sql, idRegistro);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;
      }



      #endregion



      internal DataSet RecuperarListaRegistro(int idEntidade, DateTime dataInicial, DateTime dataFinal, string nome, string cpfCnpj, string numeroContrato, int status, string numeroLocalizador)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" SELECT * 
                            FROM registro as r
                            WHERE (1=1) ";



         sql += " AND (data_postagem BETWEEN '{0}' AND '{1}') ";

         if (idEntidade > 0)
         {
            sql += " AND (id_entidade={7}) ";
         }

         if (nome.Trim() != String.Empty)
         {
            sql += " AND (nome ILIKE '%{2}%') ";
         }

         if (cpfCnpj.Trim() != String.Empty)
         {
            sql += " AND (cpf_cnpj ILIKE '%{3}%') ";
         }

         if (numeroContrato.Trim() != String.Empty)
         {
            sql += " AND (numero_contrato ILIKE '%{4}%') ";
         }

         if (numeroLocalizador.Trim() != String.Empty)
         {
            sql += " AND (numero_localizador ILIKE '%{6}%') ";
         }

         if (status > 0)
         {
            if (status == Registro.POSTADO || status == Registro.AG_CLASSIFICACAO)
            {
               sql += " AND (status BETWEEN " + Registro.POSTADO + " AND " + Registro.AG_CLASSIFICACAO + ") ";
            }
            else
            {
               sql += " AND (status = {5}) ";
            }
         }


         sql += " ORDER BY data_processamento, id_registro ";


         sql = String.Format(sql, dataInicial.ToString("yyyy-MM-dd 00:00:00"), dataFinal.ToString("yyyy-MM-dd 23:00:00"), nome, cpfCnpj, numeroContrato, status, numeroLocalizador, idEntidade);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;
      }

      internal DataSet RecuperarRegistroPeloNumeroLocalizador(string numeroLocalizador)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" SELECT * 
                            FROM registro as r
                            WHERE (numero_localizador = '{0}') ";

         sql = String.Format(sql, numeroLocalizador);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;
      }



      internal DataSet RecuperarListaRegistrosDevolvidosPendentesEmail(int idEntidade)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" select numero_contrato, nome, endereco, bairro, cidade, uf, cep, data_postagem, case motivo_devolucao 
                                when 1 then '01-MUDOU-SE'
                                when 2 then '02-ENDERECO INSUFICIENTE'
                                when 3 then '03-NAO EXISTE N INDICADO'
                                when 4 then '04-DESCONHECIDO'
                                when 5 then '05-RECUSADO'
                                when 6 then '06-NAO PROCURADO'
                                when 7 then '07-AUSENTE'
                                when 8 then '08-FALECIDO'
                                when 9 then '09-OUTROS'
                                when 10 then '10-NAO POSTADO (CEP)'
                                end as motivo_devolucao, cpf_cnpj 
                            from registro 
                            where (status = {0}) and (relatorio_devolucao_exportado is false) ";

         if (idEntidade > 0)
         {
            sql += " and (id_entidade={1}) ";
         }

         sql += "order by id_registro ";

         sql = String.Format(sql, Registro.NEGATIVO, idEntidade);

         //            string sql = @" select numero_contrato, nome, endereco, bairro, cidade, uf, cep, data_postagem, case motivo_devolucao 
         //                                when 1 then '01-MUDOU-SE'
         //                                when 2 then '02-ENDERECO INSUFICIENTE'
         //                                when 3 then '03-NAO EXISTE N INDICADO'
         //                                when 4 then '04-DESCONHECIDO'
         //                                when 5 then '05-RECUSADO'
         //                                when 6 then '06-NAO PROCURADO'
         //                                when 7 then '07-AUSENTE'
         //                                when 8 then '08-FALECIDO'
         //                                when 9 then '09-OUTROS'
         //                                when 9 then '10-NAO POSTADO (CEP)'         
         //                                end as motivo_devolucao, cpf_cnpj 
         //                            from registro 
         //                            where (status = {0}) and data_postagem between '{1}' and '{2}' and (id_entidade={3})
         //                            order by id_registro ";


         //            sql = String.Format(sql, Registro.NEGATIVO, "2016-04-01 00:00:00", "2017-01-31 23:00:00", idEntidade);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;
      }

      internal void MarcarRegistrosComoRelatorioEnviado(int idEntidade)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" update registro set relatorio_devolucao_exportado = true
                            where (status = {0}) and (relatorio_devolucao_exportado is false) ";


         if (idEntidade > 0)
         {
            sql += " and (id_entidade={1}) ";
         }

         sql = String.Format(sql, Registro.NEGATIVO, idEntidade);
         persistencia.ExecutarConsulta(sql.ToString());
      }



      internal DataSet LocalizarRegistroSite(int idEntidade, string nome, string cpf, string numeroContrato, DateTime dataPostagem)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = String.Empty;
         sql = @"
                    select id_registro 
                    from registro where 
                    (nome = '{0}') and  (numero_contrato = '{2}') and (data_postagem = '{3}') ";


         if (idEntidade > 0)
         {
            sql += " and (id_entidade={4}) ";
         }

         //(cpf_cnpj = '{1}') and

         sql = String.Format(sql, nome, cpf, numeroContrato, dataPostagem.ToString("yyyy-MM-dd"), idEntidade);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;
      }


      internal DataSet RecuperarListaArParaBaixarHistorico(int idEntidade)
      {
         Persistencia persistencia = new Persistencia("ar");

         string sql =
                                             @" SELECT *
                                                                            FROM registro  
                                                                            WHERE (status in (1,3,4))
                                                                              AND (historico_rastreamento_importado is false)  
                                                                              AND (data_postagem >= '2015-11-01 23:59:59')  ";



         if (idEntidade > 0)
         {
            sql += " AND (id_entidade={2} ) ";
         }

         sql += " ORDER BY id_registro ";

         //            @" SELECT *
         //                                            FROM registro  
         //                                            WHERE ( id_registro between 37738 and 40321)
         //                                            ORDER BY id_registro ";


         //            @" SELECT *
         //                                        FROM registro  
         //                                        WHERE (status in ({0},{1}))
         //                                          AND (historico_rastreamento_importado is false)  
         //                                        ORDER BY id_registro ";

         sql = String.Format(sql, Registro.POSITIVO, Registro.NEGATIVO, idEntidade);
         DataSet dsAr = persistencia.ExecutarConsulta(sql.ToString());

         return dsAr;
      }


      internal DataSet RecuperarListaArPorStatus(int idEntidade, int status, string pathArquivo)
      {
         Persistencia persistencia = new Persistencia("ar");

         string sql = @" SELECT registro.*, '{1}' || registro.arquivo_digitalizado as path_arquivo_digitalizado
                            FROM registro  ";


         sql += " WHERE (1=1) ";

         if (idEntidade > 0)
         {
            sql += " AND (id_entidade={2}) ";
         }

         if (status > 0)
         {
            sql += " AND status = {0} ";
         }


         sql = String.Format(sql, status, pathArquivo, idEntidade);
         DataSet dsAr = persistencia.ExecutarConsulta(sql.ToString());

         return dsAr;
      }

      internal DataSet RecuperarListaRegistrosPendentesRetorno(int idEntidade, int quantidadeDias)
      {

         Persistencia persistencia = new Persistencia("registro");

         string sql = @" 
                            select numero_localizador, nome, endereco, bairro, cidade, uf, cep, data_postagem, cpf_cnpj, numero_contrato, 
                                    (CAST((extract(year from now()) || '-' || extract(month from now()) || '-' || extract(day from now())) as date) -
                                    CAST((extract(year from data_processamento) || '-' || extract(month from data_processamento) || '-' || extract(day from data_processamento)) as date)) as dias_postados
                            from registro 
                            where (id_entidade={2}) and (status <= {0})
                              and (CAST((extract(year from now()) || '-' || extract(month from now()) || '-' || extract(day from now())) as date) -
                                    CAST((extract(year from data_processamento) || '-' || extract(month from data_processamento) || '-' || extract(day from data_processamento)) as date)) >= {1}
                            order by data_processamento, cidade, endereco
                         ";

         sql = String.Format(sql, Registro.POSTADO, quantidadeDias, idEntidade);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         return dsRegistro;

      }

      internal bool VerificarExistenciaExportacao(string numeroLocalizador)
      {
         Persistencia persistencia = new Persistencia("registro");

         string sql = @" 
                            select numero_localizador
                            from registro 
                            where numero_localizador ILIKE '%{0}%'
                         ";

         sql = String.Format(sql, numeroLocalizador);
         DataSet dsRegistro = persistencia.ExecutarConsulta(sql.ToString());

         if (dsRegistro.Tables[0].Rows.Count > 0)
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      internal string ImportarArquivoControleRetorno(string nomeArquivo, DateTime dataRetorno)
      {
         string log = String.Empty;
         StreamReader str = new StreamReader(nomeArquivo);

         while (str.Peek() > 0)
         {
            string linha = str.ReadLine().ToUpper();

            if (linha.Trim() != String.Empty)
            {
               try
               {
                  DataSet dsRegistro = RegistroCONTROLADOR.RecuperarRegistroPeloNumeroLocalizador(linha.Replace("-", "").Replace(" ", ""));

                  if (dsRegistro.Tables[0].Rows.Count > 0)
                  {


                     int idRegistro = Convert.ToInt32(dsRegistro.Tables[0].Rows[0]["id_registro"]);

                     RegistroDAO dao = new RegistroDAO();
                     dao.IdRegistro = idRegistro;
                     dao = RegistroCONTROLADOR.RecuperarDao(dao);

                     if (dao.Status == POSTADO || dao.Status == PI)
                     {
                        dao.Status = AG_CLASSIFICACAO;
                        dao.DataRetorno = dataRetorno;

                        RegistroCONTROLADOR.Manter(dao);

                        log += linha + " = OK" + Environment.NewLine;
                     }
                     else
                     {
                        //if (dao.DataRetorno == DateTime.MinValue)
                        //{
                        //    dao.DataRetorno = dataRetorno;
                        //    RegistroCONTROLADOR.Manter(dao);
                        //}

                        log += linha + " = REGISTRO JÁ FOI IMPORTADO" + Environment.NewLine;
                     }
                  }
                  else
                  {
                     log += linha + " = NÃO ENCONTRATO" + Environment.NewLine;
                  }
               }
               catch (Exception ex)
               {
                  log += linha + " = REGISTRO INVÁLIDO (" + ex.Message + ")" + Environment.NewLine;
               }
            }
         }
         str.Close();

         return log;
      }

      internal string ImportarArquivoControleRetornorXLS(string nomeArquivo)
      {
         String StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", nomeArquivo);
         string log = String.Empty;

         // CSV
         //StreamReader arquivo = new StreamReader(nomeArquivo, Encoding.Default);
         //DataTable dtArquivo = new DataTable();

         // CSV
         //int contadorLinha = 0;

         //while (arquivo.Peek() > 0)
         //{
         //   string[] colunas = arquivo.ReadLine().Split(';');

         //   if (contadorLinha == 1)
         //   {
         //      foreach (string nomeColuna in colunas)
         //      {
         //         dtArquivo.Columns.Add(nomeColuna);
         //      }
         //   }
         //   else if (contadorLinha > 1)
         //   {
         //      DataRow linha = dtArquivo.NewRow();
         //      int indiceColuna = 0;
         //      foreach (string valorColuna in colunas)
         //      {
         //         linha[indiceColuna] = valorColuna;
         //         indiceColuna++;
         //      }
         //      dtArquivo.Rows.Add(linha);
         //   }
         //   contadorLinha++;
         //}

         //arquivo.Close();

         //if (dtArquivo.Rows.Count > 0)
         //{
         //   int linhaRegistro = 0;
         //   try
         //   {
         //      foreach (DataRow linha in dtArquivo.Rows)
         //      {
         //         if (linhaRegistro == 0)
         //         {
         //            log += linhaRegistro + " = NOME COLUNAS" + Environment.NewLine;
         //            linhaRegistro++;
         //         }
         //         else if (linhaRegistro > 0)
         //         {
         //            DataSet dsRegistro = RegistroCONTROLADOR.RecuperarRegistroPeloNumeroLocalizador(linha[0].ToString().Replace("-", "").Replace(" ", ""));

         //            DateTime dataRetorno = new DateTime(Convert.ToInt32(linha[3].ToString().Substring(6, 4)),
         //                                                Convert.ToInt32(linha[3].ToString().Substring(3, 2)),
         //                                                Convert.ToInt32(linha[3].ToString().Substring(0, 2)));

         //            int idRegistro = Convert.ToInt32(dsRegistro.Tables[0].Rows[0]["id_registro"]);

         //            RegistroDAO dao = new RegistroDAO();
         //            dao.IdRegistro = idRegistro;
         //            dao = RegistroCONTROLADOR.RecuperarDao(dao);

         //            if (dao.Status == POSTADO || dao.Status == PI)
         //            {
         //               dao.Status = AG_CLASSIFICACAO;
         //               dao.DataRetorno = dataRetorno;

         //               RegistroCONTROLADOR.Manter(dao);

         //               log += linhaRegistro + " = OK" + Environment.NewLine;
         //               linhaRegistro++;
         //            }
         //            else
         //            {
         //               log += linhaRegistro + " = REGISTRO JÁ FOI IMPORTADO" + Environment.NewLine;
         //               linhaRegistro++;
         //            }
         //         }
         //         else
         //         {
         //            log += linhaRegistro + " = NÃO ENCONTRADO" + Environment.NewLine;
         //            linhaRegistro++;
         //         }
         //      }
         //   }
         //   catch (Exception ex)
         //   {
         //      log += linhaRegistro + " = REGISTRO INVÁLIDO (" + ex.Message + ")" + Environment.NewLine;
         //   }
         //}


         // XLS
         DataSet dsArquivo = new DataSet();
         OleDbConnection conexao = new OleDbConnection(StringConexao);
         conexao.Open();
         string[] abas = Get_dados_planilhas(nomeArquivo);
         if (abas.Length > 1)
         {
            throw new Exception("Arquivo possui mais de uma aba!");
         }
         else
         {
            OleDbDataAdapter da = new OleDbDataAdapter("Select * From [" + abas[0] + "]", conexao);

            da.Fill(dsArquivo);

            conexao.Close();


            // XLS
            if (dsArquivo.Tables[0].Rows.Count > 0)
            {
               int linhaRegistro = 0;
               try
               {
                  foreach (DataRow linha in dsArquivo.Tables[0].Rows)
                  {
                     if (linhaRegistro == 0)
                     {
                        log += linhaRegistro + " = NOME COLUNAS" + Environment.NewLine;
                        linhaRegistro++;
                     }
                     else if (linhaRegistro > 0)
                     {
                        DataSet dsRegistro = RegistroCONTROLADOR.RecuperarRegistroPeloNumeroLocalizador(linha[0].ToString().Replace("-", "").Replace(" ", ""));

                        DateTime dataRetorno = new DateTime(Convert.ToInt32(linha[3].ToString().Substring(6, 4)),
                                                            Convert.ToInt32(linha[3].ToString().Substring(3, 2)),
                                                            Convert.ToInt32(linha[3].ToString().Substring(0, 2)));

                        int idRegistro = Convert.ToInt32(dsRegistro.Tables[0].Rows[0]["id_registro"]);

                        RegistroDAO dao = new RegistroDAO();
                        dao.IdRegistro = idRegistro;
                        dao = RegistroCONTROLADOR.RecuperarDao(dao);

                        if (dao.Status == POSTADO || dao.Status == PI)
                        {
                           dao.Status = AG_CLASSIFICACAO;
                           dao.DataRetorno = dataRetorno;

                           RegistroCONTROLADOR.Manter(dao);

                           log += linhaRegistro + " = OK" + Environment.NewLine;
                           linhaRegistro++;
                        }
                        else
                        {
                           log += linhaRegistro + " = REGISTRO JÁ FOI IMPORTADO" + Environment.NewLine;
                           linhaRegistro++;
                        }
                     }
                     else
                     {
                        log += linhaRegistro + " = NÃO ENCONTRADO" + Environment.NewLine;
                        linhaRegistro++;
                     }
                  }
               }
               catch (Exception ex)
               {
                  log += linhaRegistro + " = REGISTRO INVÁLIDO (" + ex.Message + ")" + Environment.NewLine;
               }
            }
         }
         

         return log;         
      }

      private String[] Get_dados_planilhas(string _arquivo)
      {
         String StringConexao = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;ReadOnly=False';", _arquivo);
         DataTable dtPlanilhas = new DataTable();
         int i = 0;
         OleDbConnection _conexao = new OleDbConnection();
         try
         {
            _conexao = new OleDbConnection(StringConexao);
            _conexao.Open();
            dtPlanilhas = _conexao.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            String[] _planilhas = new String[dtPlanilhas.Rows.Count];

            // Adiciona os nomes na array                
            foreach (DataRow row in dtPlanilhas.Rows)
            {
               _planilhas[i] = row["TABLE_NAME"].ToString();
               i++;
            }
            /*
            // Loop através de todas as planilhas ..
            for (int j = 0; j < excelSheets.Length; j++)
            {
                // Consultar cada planilha de excel
            }
            */
            _conexao.Close();


            return _planilhas;
         }
         catch (Exception ex)
         {
            throw ex;
         }
         finally
         {
            if (_conexao != null)
            {
               _conexao.Close();
               _conexao.Dispose();
            }
            if (dtPlanilhas != null)
            {
               dtPlanilhas.Dispose();
            }
         }
      }


      private OleDbDataAdapter OleDbDataAdapter(string p, OleDbCommand conexao)
      {
         throw new NotImplementedException();
      }

      private OleDbCommand OleDbConnection(string p)
      {
         throw new NotImplementedException();
      }
   }

}