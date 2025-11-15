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

namespace BPDWeb.JobTracker.Seguranca
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

                        if (usuario.IdUsuario <= 0 || usuario.Tipo != 2)
                        {
                            Response.Redirect("../../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                        }
                        else
                        {
                            ltrIdUsuario.Text = usuario.IdUsuario.ToString();
                            PreencherCampos(usuario.IdUsuario);
                        }
                    }
                    else
                    {
                        Response.Redirect("../../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                }
            }
            catch (Exception ex)
            {
                ExibirMensagemAlerta("Desculpe, ocorreu um erro: " + ex.Message);
            }
        }


        private void Salvar()
        {
            int idUsuario = Convert.ToInt32(ltrIdUsuario.Text);

            UsuarioDAO usuarioDao = new UsuarioDAO();
            usuarioDao.IdUsuario = idUsuario;
            usuarioDao = UsuarioCONTROLADOR.RecuperarDao(usuarioDao);

            usuarioDao.Nome = txtNome.Text.Trim();
            usuarioDao.Email = txtEmail.Text.Trim();
            usuarioDao.Senha = txtSenha.Text.Trim();

            usuarioDao.IdUsuario = UsuarioCONTROLADOR.Manter(usuarioDao);

            ExibirMensagemAlerta("Seus dados foram salvos com sucesso!");            
        }


        private void PreencherCampos(int idUsuario)
        {
            UsuarioDAO usuarioDao = new UsuarioDAO();
            usuarioDao.IdUsuario = idUsuario;
            usuarioDao = UsuarioCONTROLADOR.RecuperarDao(usuarioDao);
            
            txtNome.Text = usuarioDao.Nome;
            txtEmail.Text = usuarioDao.Email;
            txtSenha.Text = usuarioDao.Senha;

            //DataSet dsClientes = UsuarioClienteCONTROLADOR.RecuperarListaPeloUsuario(idUsuario);

            //foreach (DataRow row in dsClientes.Tables[0].Rows)
            //{
            //    lblClientes.Text += row["nome_fantasia"].ToString() + "<BR/>";
            //}
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
            Response.Redirect("./EditarUsuario.aspx");
        }
        protected void lkbAcompanhamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("../LocalizarRegistros.aspx");
        }
        protected void lkbRelatorioPendencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("../RelatorioPendencias.aspx");
        }
        protected void lkbSair_Click(object sender, EventArgs e)
        {
            Session["sesUser"] = null;
            Response.Redirect(ConfigurationManager.AppSettings["Url"].ToString());
        }
    }
}