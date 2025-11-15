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

namespace BPDWeb.JobTrackerAdmin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["sesUser"] != null)
                {
                    EstruturaUsuario usuario = (EstruturaUsuario)Session["sesUser"];

                    if (usuario.IdUsuario <= 0 || usuario.Tipo != 1)
                    {
                        Response.Redirect("./Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        ltrIdUsuario.Text = usuario.IdUsuario.ToString();
                        lblUsuario.Text = usuario.Nome;
                    }
                }
                else
                {
                    Response.Redirect("./Login.aspx?Page=" + Request.Url.AbsoluteUri);
                }
            }
        }

        protected void lkbInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Default.aspx");
        }
        protected void lkbUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Usuario/PesquisarUsuario.aspx");
        }
        protected void lkbAprovarJob_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Aprovacao/EnviarAprovacao.aspx");
        }
        protected void lkbAcompanhamento_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Job/AcompanhamentoJob.aspx");
        }
        protected void lkbSair_Click(object sender, EventArgs e)
        {
            Session["sesUser"] = null;
            Response.Redirect(ConfigurationManager.AppSettings["Url"].ToString());
        }
    }
}