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
using BPDWeb.Util;
using BPDWeb.Kernel.Seguranca;
using BPDWeb.Kernel.Cadastro;

namespace BPDWeb.JobTracker
{
    public partial class Default : PaginaWeb
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

                    this.MontarTela(usuario.IdUsuario, usuario.Nome);
                }
                else
                {
                    Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                }                
            }
        }

        private void MontarTela(int idUsuario, string nome)
        {
            lblUsuario.Text = nome;

            //DataSet dsClientes = UsuarioClienteCONTROLADOR.RecuperarListaPeloUsuario(idUsuario);
            
            //foreach (DataRow row in dsClientes.Tables[0].Rows)
            //{
            //    lblCliente.Text += row["nome_fantasia"].ToString() + "<BR/>";
            //}           

            //int protocolosEmAndamento = ProtocoloCONTROLADOR.RecuperarListaProtocolo();
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
            //Fazer o Logoff
            Session["sesUser"] = null;
            Response.Redirect("../Default.aspx");
        }
    }
}


