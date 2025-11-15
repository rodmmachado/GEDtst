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
using BPDWeb.Util;

namespace BPDWeb.JobTrackerAdmin
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

            //DataSet dsUsuario = UsuarioCONTROLADOR.EfetuarLoginAdministrativo(email, senha);

            //if (dsUsuario.Tables[0].Rows.Count > 0)
            //{
            //    EstruturaUsuario usuario = new EstruturaUsuario();

            //    usuario.IdUsuario = Convert.ToInt32("0" + dsUsuario.Tables[0].Rows[0]["id_usuario"]);
            //    usuario.Nome = dsUsuario.Tables[0].Rows[0]["nome"].ToString();
            //    usuario.Email = dsUsuario.Tables[0].Rows[0]["email"].ToString();
            //    usuario.Tipo = Convert.ToInt32("0" + dsUsuario.Tables[0].Rows[0]["tipo"]);
               
            //    if (usuario.IdUsuario > 0)
            //    {
            //        Session["sesUser"] = usuario;

            //        if (this.Request["Page"] != null && this.Request["Page"].Length > 0)
            //        {
            //            Response.Redirect(this.Request["Page"].ToString());
            //        }
            //        else
            //        {
            //            Response.Redirect("./Default.aspx");
            //        }    
            //    }
            //    else
            //    {
            //        this.ExibirMensagemAlerta("Usuário Inválido");
            //    }
            //}
            //else
            //{
            //    this.ExibirMensagemAlerta("Usuário Inválido");
            //}
        }

        private string TratarCampo(string valorCampo)
        {
            valorCampo = valorCampo.ToLower();

            valorCampo = valorCampo.Replace("'", "''");
            valorCampo = valorCampo.Replace(" select ", "");
            valorCampo = valorCampo.Replace("-", "");
            valorCampo = valorCampo.Replace("=", "");
            valorCampo = valorCampo.Replace(" or ", "");
            valorCampo = valorCampo.Replace(" from ", "");
            valorCampo = valorCampo.Replace(" delete ", "");
            valorCampo = valorCampo.Replace(" create ", "");

            return valorCampo;
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.EfetuarLogin();
        }
    }
}