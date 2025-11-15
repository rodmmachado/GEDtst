using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BPDWeb.Util;
using BPDWeb.Kernel.Seguranca;

namespace BPDWeb.JobTracker
{

    public partial class Login : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void EfetuarLogin()
        {
            string email = TratarCampo(txtEmail.Text);
            string senha = TratarCampo(txtSenha.Text);

            DataSet dsUsuario = UsuarioCONTROLADOR.EfetuarLogin(email, senha);

            if (dsUsuario.Tables[0].Rows.Count > 0)
            {
                EstruturaUsuario usuario = new EstruturaUsuario();

                usuario.IdUsuario = Convert.ToInt32("0" + dsUsuario.Tables[0].Rows[0]["id_usuario"]);
                usuario.IdEntidade = Convert.ToInt32("0" + dsUsuario.Tables[0].Rows[0]["id_entidade"]);
                usuario.Nome = dsUsuario.Tables[0].Rows[0]["nome"].ToString();
                usuario.Email = dsUsuario.Tables[0].Rows[0]["email"].ToString();
                usuario.Tipo = Convert.ToInt32("0" + dsUsuario.Tables[0].Rows[0]["tipo"]);

                if (usuario.IdUsuario > 0)
                {
                    Session["sesUser"] = usuario;

                    bool usuarioRespondePesquisa = false;// PesquisaSatisfacaoCONTROLADOR.UsuarioDeveResponderPesquisaSatisfacao(usuario.IdUsuario);

                    if (this.Request["Page"] != null && this.Request["Page"].Length > 0)
                    {
                        if (usuarioRespondePesquisa)
                        {
                            Response.Redirect("./Ged/PesquisaSatisfacao.aspx?Page=" + this.Request["Page"].ToString());
                        }
                        else
                        {
                            Response.Redirect(this.Request["Page"].ToString());
                        }
                    }
                    else
                    {
                        if (usuario.Tipo == 1)
                        {
                            Response.Redirect("./Admin/");
                        }
                        else
                        {
                            if (usuarioRespondePesquisa)
                            {
                                Response.Redirect("./Ged/PesquisaSatisfacao.aspx");
                            }
                            else
                            {
                                Response.Redirect("./Ged/");
                            }
                        }
                    }
                }
                else
                {
                    this.ExibirMensagemAlerta("Usuário Inválido");
                }
            }
            else
            {
                this.ExibirMensagemAlerta("Usuário Inválido");
            }
        }

        private string TratarCampo(string valorCampo)
        {
            valorCampo = valorCampo.ToLower();

            valorCampo = valorCampo.Replace("'", "''");
            valorCampo = valorCampo.Replace(" select ", "");
            valorCampo = valorCampo.Replace("--", "");
            valorCampo = valorCampo.Replace("=", "");
            valorCampo = valorCampo.Replace(" or ", "");
            valorCampo = valorCampo.Replace(" from ", "");
            valorCampo = valorCampo.Replace(" delete ", "");
            valorCampo = valorCampo.Replace(" create ", "");

            return valorCampo;
        }

        protected void ImageButton1_Click1(object sender, EventArgs e)
        {
            this.EfetuarLogin();
        }
       
}
}