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
using BPDWeb.Kernel.Seguranca;
using BPDWeb.Kernel.Cadastro;
using BPDWeb.Util;
using BPDWeb.Kernel.Util;
using System.IO;
using System.Collections.Generic;

namespace BPDWeb.JobTrackerAdmin.Seguranca
{
    public partial class EditarUsuario : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["sesUser"] != null)
                    {
                        EstruturaUsuario usuario = (EstruturaUsuario)Session["sesUser"];

                        if (usuario.IdUsuario <= 0 || usuario.Tipo != 1)
                        {
                            Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            this.ListarClientes();

                            int IdUsuario = Convert.ToInt32(RecuperarParametros("idUsuario"));

                            ltrIdUsuario.Text = IdUsuario.ToString();

                            if (IdUsuario > 0)
                            {
                                PreencherCampos(IdUsuario);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagemAlerta("Desculpe, ocorreu um erro: " + ex.Message);
            }
        }


        private void ListarClientes()
        {
            DataSet dsClientes = ClienteCONTROLADOR.RecuperarListaCliente();

            DataRow row = dsClientes.Tables[0].NewRow();
            row["id_cliente"] = "0";
            row["nome_fantasia"] = "Selecione um Cliente";
            dsClientes.Tables[0].Rows.InsertAt(row, 0);

            ddlCliente.DataSource = dsClientes;
            ddlCliente.DataMember = dsClientes.Tables[0].TableName;
            ddlCliente.DataValueField = "id_cliente";
            ddlCliente.DataTextField = "nome_fantasia";
            ddlCliente.DataBind();
        }        


        private void Salvar()
        {           
            int idUsuario = Convert.ToInt32(ltrIdUsuario.Text);

            UsuarioDAO usuarioDao = new UsuarioDAO();
            
            usuarioDao.IdUsuario = idUsuario;
            usuarioDao.Nome = txtNome.Text.Trim();
            usuarioDao.Email = txtEmail.Text.Trim();
            usuarioDao.Senha = txtSenha.Text.Trim();
            usuarioDao.Tipo = 2;

            usuarioDao.IdUsuario = UsuarioCONTROLADOR.Manter(usuarioDao);

            //Associando o Usuário aos Clientes
            foreach (DataGridItem row in dgrClientes.Items)
            {
                if (Convert.ToInt32("0" + row.Cells[0].Text) == 0)
	            {
            		UsuarioClienteDAO usuarioClienteDao = new UsuarioClienteDAO();
                    usuarioClienteDao.IdUsuario = usuarioDao.IdUsuario;
                    usuarioClienteDao.IdCliente = Convert.ToInt32("0" + row.Cells[1].Text);

                    UsuarioClienteCONTROLADOR.Manter(usuarioClienteDao);
	            }                
            }

            if (chkEnviarSenha.Checked)
            {
                this.EnviarEmailDadosAcesso(usuarioDao.IdUsuario);
            }

            ExibirMensagemAlerta("Seus dados foram salvos com sucesso!");

            this.LimparTela();
        }

        private void EnviarEmailDadosAcesso(int idUsuario)
        {
            try
            {
                UsuarioDAO usuarioDao = new UsuarioDAO();
                usuarioDao.IdUsuario = idUsuario;
                usuarioDao = UsuarioCONTROLADOR.RecuperarDao(usuarioDao);

                string mensagemHtml = String.Empty;

                string pathModelo = Server.MapPath(Request.ApplicationPath + "/JobTrackerAdmin/Usuario/ModeloEmailSenha.htm");
                StreamReader arquivoModeloEmail = new StreamReader(pathModelo, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                mensagemHtml = arquivoModeloEmail.ReadToEnd();
                arquivoModeloEmail.Close();

                mensagemHtml = mensagemHtml.Replace("[%usuario%]", usuarioDao.Nome);
                mensagemHtml = mensagemHtml.Replace("[%email%]", usuarioDao.Email);
                mensagemHtml = mensagemHtml.Replace("[%senha%]", usuarioDao.Senha);

                string tituloEmail = "Acesso ao site da BPD";

                string remetente = ConfigurationManager.AppSettings["remetente_suporte"];
                string destinatario = usuarioDao.Email;
                string login = ConfigurationManager.AppSettings["login"];
                string senha = ConfigurationManager.AppSettings["senhaEmail"];
                string servidorSmtp = ConfigurationManager.AppSettings["servidorSmtp"];
                int porta = Convert.ToInt32(ConfigurationManager.AppSettings["porta"]);

                List<string> listaDestinatario = new List<string>();
                listaDestinatario.Add(destinatario);

                Email email = new Email(tituloEmail, mensagemHtml, remetente, "BPD Impressão de Dados", listaDestinatario, login, senha, servidorSmtp, porta);
                email.Enviar();
            }
            catch (Exception ex)
            {
                this.ExibirMensagemAlerta("Falha ao enviar o e-mail, por favor avisar a equipe de suporte!");
            }
                    
        }

        private void LimparTela()
        {
            dgrClientes.Controls.Clear();
            dgrClientes.DataSource = null;
            txtNome.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtSenha.Attributes.Add("value", String.Empty);
            ltrIdUsuario.Text = "0";
        }


        private void PreencherCampos(int idUsuario)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            usuarioDao.IdUsuario = idUsuario;
            usuarioDao = UsuarioCONTROLADOR.RecuperarDao(usuarioDao);

            txtNome.Text = usuarioDao.Nome;
            txtEmail.Text = usuarioDao.Email;
            txtSenha.Attributes.Add("value", usuarioDao.Senha);

            DataSet dsClientes = UsuarioClienteCONTROLADOR.RecuperarListaPeloUsuario(idUsuario);
            ListarGrid(dsClientes.Tables[0]);
        }

        protected void btnSalvar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Salvar();
            }
            catch (Exception ex)
            {
                ExibirMensagemAlerta("Desculpe ocorreu um erro: " + ex.Message);

            }
        }

        protected void lkbInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
        protected void lkbUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Usuario/PesquisarUsuario.aspx");
        }
        protected void lkbAprovarJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Aprovacao/EnviarAprovacao.aspx");
        }
        protected void lkbAcompanhamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Job/AcompanhamentoJob.aspx");
        }
        protected void lkbSair_Click(object sender, EventArgs e)
        {
            Session["sesUser"] = null;
            Response.Redirect(ConfigurationManager.AppSettings["Url"].ToString());
        }
        protected void btnNovo_Click(object sender, ImageClickEventArgs e)
        {
            this.LimparTela();
        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = RecuperarDataTable();
                              
                DataRow dr = dt.NewRow();

                dr["id_usuario_cliente"] = 0;
                dr["id_cliente"] = Convert.ToInt32("0" + ddlCliente.SelectedValue);
                dr["nome_fantasia"] = ddlCliente.SelectedItem.Text;

                dt.Rows.Add(dr);

                ListarGrid(dt);
            }
            catch (Exception ex)
            {

                this.ExibirMensagemAlerta(ex.Message);
            }
        }

        private void ListarGrid(DataTable dt)
        {
            dgrClientes.DataSource = dt;
            dgrClientes.DataMember = dt.TableName;
            dgrClientes.DataBind();
        }

        private DataTable RecuperarDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_usuario_cliente");
            dt.Columns.Add("id_cliente");
            dt.Columns.Add("nome_fantasia");

            foreach (DataGridItem row in dgrClientes.Items)
            {
                DataRow row2 = dt.NewRow();

                row2["id_usuario_cliente"] = row.Cells[0].Text;
                row2["id_cliente"] = row.Cells[1].Text;
                row2["nome_fantasia"] = row.Cells[2].Text;

                dt.Rows.Add(row2);
            }

            return dt;
        }

        protected void dgrClientes_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            DataTable dt = RecuperarDataTable();            
            
            int idUsuarioCliente = Convert.ToInt32("0" + e.Item.Cells[0].Text);

            if (idUsuarioCliente > 0)
            {
                try
                {
                    UsuarioClienteDAO dao = new UsuarioClienteDAO();
                    dao.IdUsuarioCliente = idUsuarioCliente;

                    UsuarioClienteCONTROLADOR.Excluir(dao);

                    dt.Rows[e.Item.ItemIndex].Delete();

                    ListarGrid(dt);
                }
                catch (Exception ex)
                {
                    this.ExibirMensagemAlerta("Não foi possível remover o Cliente!");
                }
            }
            else
            {
                dt.Rows[e.Item.ItemIndex].Delete();
                ListarGrid(dt);
            }
        }
        protected void lkbEnviarSenhaAgora_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(ltrIdUsuario.Text);

            if (idUsuario > 0)
            {
                this.EnviarEmailDadosAcesso(idUsuario);
                this.ExibirMensagemAlerta("E-mail enviado com sucesso!");
            }
            else
            {
                this.ExibirMensagemAlerta("O usuário ainda não foi cadastrado!");
            }
        }
        protected void lkbGerarSenha_Click(object sender, EventArgs e)
        {
            txtSenha.Attributes.Add("value", this.GerarSenhaAleatoria(6));
        }

        private string GerarSenhaAleatoria(int quantidadeCaracteres)
        {
            string carac = "abcdefhijkmnopqrstuvxwyz123456789";

            char[] letras = carac.ToCharArray();

            Embaralhar(ref letras, 5);

            return new String(letras).Substring(0, quantidadeCaracteres);
        }

        private void Embaralhar(ref char[] array, int vezes)
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            for (int i = 1; i <= vezes; i++)
            {
                for (int x = 1; x <= array.Length; x++)
                {
                    Trocar(ref array[rand.Next(0, array.Length)],
                      ref array[rand.Next(0, array.Length)]);
                }
            }
        }

        private void Trocar(ref char arg1, ref char arg2)
        {
            char strTemp = arg1;
            arg1 = arg2;
            arg2 = strTemp;
        }


    }
}