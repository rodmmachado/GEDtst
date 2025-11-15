using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using BPDWeb.Kernel.Cadastro;
using BPDWeb.Kernel.Util;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Seguranca;
using BPDWeb.Kernel.Cadastro;
using BPDWeb.Util;
using System.IO;

namespace BPDWeb.JobTracker.Job
{
    public partial class LocalizarRegistros : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sesUser"] != null)
                {
                    EstruturaUsuario usuario = (EstruturaUsuario)Session["sesUser"];

                    if (usuario.IdUsuario <= 0 || usuario.Tipo != 2)
                    {
                        Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        ltrIdEntidade.Text = usuario.IdEntidade.ToString();
                    }
                }
                else
                {
                    Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                }
            }
        }
                
        
        protected void dgrAtividade_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idRegistro = Convert.ToInt32(dgrRegistros.SelectedItem.Cells[0].Text);
            
            Response.Redirect("ARInfo.aspx" + MontarParametros("idRegistro=" + idRegistro), false);
        }


        protected void dgrProtocolo_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int idRegistro = Convert.ToInt32(e.Item.Cells[0].Text);

            try
            {
                RegistroDAO registroDao = new RegistroDAO();
                registroDao.IdRegistro = idRegistro;
                registroDao = RegistroCONTROLADOR.RecuperarDao(registroDao);

                this.EfetuarDownload(registroDao.ArquivoEspelho, registroDao.PdfUrl);                
            }
            catch (Exception ex)
            {
                this.ExibirMensagemAlerta(ex.Message);
            }            
        }

        private void EfetuarDownload(string nomeArquivo, string pdfUrl)
        {
            try
            {
               //Versão até 12/11/2025
               //FileInfo arquivoInfo = new FileInfo(Server.MapPath(Request.ApplicationPath + ConfigurationManager.AppSettings["PDFFiles"] + nomeArquivo));

                
               //Response.Clear();
               //Response.AddHeader("Content-Disposition", "attachment; filename=" + arquivoInfo.Name);
               //Response.AddHeader("Content-Length", arquivoInfo.Length.ToString());
               //Response.ContentType = "application/octet-stream";
               //Response.WriteFile(arquivoInfo.FullName);



               //Versão 12/11/2025
                // Cria uma requisição web para a URL externa

               try
               {
                  HttpWebRequest requestCheck = (HttpWebRequest)WebRequest.Create(pdfUrl);
                  requestCheck.Method = "HEAD"; // Usa HEAD para verificar sem baixar o corpo
                  using (HttpWebResponse responseCheck = (HttpWebResponse)requestCheck.GetResponse())
                  {
                     if (responseCheck.StatusCode != HttpStatusCode.OK)
                     {
                        ExibirMensagemAlerta("O arquivo remoto não está acessível ou não existe.");
                        return;
                     }
                  }
               }
               catch (WebException ex)
               {
                  throw new Exception("Erro ao verificar o arquivo remoto: " + ex.Message);                  
               }


               // --- 4. Início do Processo de Download Real
               try
               {
                  HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pdfUrl);
                  System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();

                  // Obtém o stream da resposta
                  System.IO.Stream stream = response.GetResponseStream();


                  Response.Clear(); // Limpa a resposta HTTP atual                
                  // Define o cabeçalho Content-Disposition para forçar o download
                  // "attachment" indica que o navegador deve tratar o arquivo como anexo
                  // "filename" sugere o nome do arquivo a ser salvo pelo usuário
                  Response.AddHeader("Content-Disposition", "attachment; filename=" + nomeArquivo);

                  // Define o tipo de conteúdo (MIME type)
                  // Um tipo genérico como "application/octet-stream" funciona para a maioria dos arquivos
                  // ou você pode usar um tipo específico se souber a extensão (ex: "application/pdf")
                  Response.ContentType = "application/octet-stream";

                  // Escreve o conteúdo do stream na resposta HTTP
                  byte[] buffer = new byte[1024];
                  int bytesRead;
                  while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                  {
                     //Response.BinaryWrite(buffer, 0, bytesRead);
                     Response.BinaryWrite(buffer);
                  }

                  // Finaliza a resposta para evitar que qualquer outro código HTML da página seja incluído

                  Response.Flush();
                  Response.End();
               }
               catch (Exception ex)
               {
                  throw new Exception("Ocorreu um erro durante o download: " + ex.Message);
               }             
            }
            catch (Exception e)
            {
               Response.ClearContent();
               Response.ClearHeaders();
               Response.End();

               this.ExibirMensagemAlerta("Arquivo inexistente!");
               
            }
        }

        protected void lkbInicio_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("./Default.aspx");
        }
        protected void lkbUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Usuario/EditarUsuario.aspx");
        }
        protected void lkbAcompanhamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("./LocalizarRegistros.aspx");
        }
        protected void lkbRelatorioPendencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("./RelatorioPendencias.aspx");
        }
        protected void lkbSair_Click(object sender, EventArgs e)
        {
            Session["sesUser"] = null;
            Response.Redirect(ConfigurationManager.AppSettings["Url"].ToString());
        }

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {
                int idEntidade = Convert.ToInt32(ltrIdEntidade.Text);
                
                DateTime dataInicial = DateTime.MinValue;

                if (txtDataInicial.Text.Trim() != String.Empty)
                {
                    try
                    {
                        dataInicial = Convert.ToDateTime(txtDataInicial.Text);
                    }
                    catch 
                    {
                        throw new Exception("Data inicial inválida!");
                    }
                }

                DateTime dataFinal = DateTime.MaxValue;

                if (txtDataFinal.Text.Trim() != String.Empty)
                {
                    try
                    {
                        dataFinal = Convert.ToDateTime(txtDataFinal.Text);
                    }
                    catch 
                    {
                        throw new Exception("Data final inválida!");
                    }
                }

                string nome = txtNome.Text.Trim();
                string cpfCnpj = txtCpfCnpj.Text.Trim();
                string numeroContrato = txtNumeroContrato.Text.Trim();
                int status = Convert.ToInt32(ddlStatus.SelectedValue);


                DataSet dsRegistros = RegistroCONTROLADOR.RecuperarListaRegistro(idEntidade, dataInicial, dataFinal, nome, cpfCnpj, numeroContrato, status, String.Empty);

                dgrRegistros.DataSource = dsRegistros;
                dgrRegistros.DataMember = dsRegistros.Tables[0].TableName;
                dgrRegistros.DataKeyField = "id_registro";
                dgrRegistros.DataBind();

                lblResultado.Text = "[" + dsRegistros.Tables[0].Rows.Count + "] resultado(s) encontrado(s).";


            }
            catch (Exception ex)
            {
                this.ExibirMensagemAlerta(ex.Message);
            }             
        }
        protected void dgrRegistros_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                if (e.Item.Cells[5].Text != "&nbsp;")
                {
                    try
                    {
                        if (e.Item.Cells[5].Text.Length > 11)
                        {
                            e.Item.Cells[5].Text = Convert.ToUInt64(e.Item.Cells[5].Text).ToString(@"00\.000\.000\/0000\-00");
                        }
                        else
                        {
                            e.Item.Cells[5].Text = Convert.ToUInt64(e.Item.Cells[5].Text).ToString(@"000\.000\.000\-00");
                        }
                    }
                    catch 
                    {
                        e.Item.Cells[5].Text = "&nbsp;";
                    }
                    
                }                
                
                int status = 0;

                if (e.Item.Cells[6].Text != "&nbsp;")
                {
                    status = Convert.ToInt32(e.Item.Cells[6].Text);
                }
                
                if (status <= 2)
                {
                    e.Item.Cells[9].Visible = false;
                }                

                int codigoMotivoDevolucao = 0;

                if (e.Item.Cells[10].Text != "&nbsp;")
                {
                    codigoMotivoDevolucao = Convert.ToInt32(e.Item.Cells[10].Text);
                }

                
                switch (status)
                {
                    case 0: e.Item.Cells[6].Text = "-";
                             break;

                    case 1: e.Item.Cells[6].Text = "Postado";
                             break;

                    case 2: e.Item.Cells[6].Text = "Aguardando Classificação";
                             break;

                    case 3: e.Item.Cells[6].Text = "Positivo";
                             break;

                    case 4: e.Item.Cells[6].Text = "Negativo - " + RetornarMotivoDevolucao(codigoMotivoDevolucao);
                             break;

                    case 5: e.Item.Cells[6].Text = "PI - " + e.Item.Cells[11].Text;
                             break;
                }

            }
        }


        private string RetornarMotivoDevolucao(int codigoDevolucao)
        {
            switch (codigoDevolucao)
            {
                case 1: return "MUDOU-SE";
                        break;

                case 2: return "ENDEREÇO INSUFICIENTE";
                        break;

                case 3: return "NÃO EXISTE O Nº INDICADO";
                        break;

                case 4: return "DESCONHECIDO";
                        break;

                case 5: return "RECUSADO";
                        break;

                case 6: return "NÃO PROCURADO";
                        break;

                case 7: return "AUSENTE";
                        break;
                    
                case 8: return "FALECIDO";
                        break;

                case 9: return "OUTROS";
                        break;

                case 10: return "NÃO POSTADO (CEP)";
                        break;

                default: return "MOTIVO DESCONHECIDO";
            }
        }

        protected void lkbExportarCsv_Click(object sender, EventArgs e)
        {
            //DataTable dsDados = (DataTable)grvRegistros.DataSource;

            ////this.ExibirMensagemAlerta("TEste");


            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            ////grvRegistros.AllowPaging = false;
            ////grvRegistros.DataBind();
                        
            //grvRegistros.HeaderRow.Style.Add("background-color", "#FFFFFF");
            //grvRegistros.HeaderRow.Cells[0].Style.Add("background-color", "green");
            //grvRegistros.HeaderRow.Cells[1].Style.Add("background-color", "green");
            //grvRegistros.HeaderRow.Cells[2].Style.Add("background-color", "green");
            //grvRegistros.HeaderRow.Cells[3].Style.Add("background-color", "green");
            //for (int i = 0; i < grvRegistros.Rows.Count; i++)
            //{
            //    GridViewRow row = grvRegistros.Rows[i];
            //    row.BackColor = System.Drawing.Color.White;
            //    row.Attributes.Add("class", "textmode");
            //    if (i % 2 != 0)
            //    {
            //        row.Cells[0].Style.Add("background-color", "#C2D69B");
            //        row.Cells[1].Style.Add("background-color", "#C2D69B");
            //        row.Cells[2].Style.Add("background-color", "#C2D69B");
            //        row.Cells[3].Style.Add("background-color", "#C2D69B");
            //    }
            //}
            //grvRegistros.RenderControl(hw);
            ////style to format numbers to string
            //string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //Response.Write(style);
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();


        }

               
}
}