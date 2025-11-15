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
using System.Net;

namespace BPDWeb.JobTracker
{

    public partial class EnviarSenha : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            IPHostEntry ipEntry = Dns.GetHostByName(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;
            string ip = addr[0].ToString();

            string path = Server.MapPath(Request.ApplicationPath + "/ModeloEmailSenha.htm");
            string email = TratarCampo(txtEmail.Text);

            UsuarioCONTROLADOR.EnviarSenha(email, ip, path);

            this.ExibirMensagemAlerta("Solicitação enviada com sucesso!");
        }

        protected void lkbRetornar_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Login.aspx");
        }
}
}