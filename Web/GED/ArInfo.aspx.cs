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
using BPDWeb.Kernel.DB;
using BPDWeb.Kernel.Cadastro;

namespace BPDWeb.JobTracker.Job
{
    public partial class ArInfo : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ltrIdRegistro.Text = RecuperarParametros("idRegistro");

                this.MontarTela();
            }
        }

        private void MontarTela()
        {
            int idRegistro = Convert.ToInt32(ltrIdRegistro.Text);

            RegistroDAO registroDao = new RegistroDAO();
            registroDao.IdRegistro = idRegistro;
            registroDao = RegistroCONTROLADOR.RecuperarDao(registroDao);
            
            if (registroDao.Nome != String.Empty)
            {
                lblNumeroLocalizador.Text = registroDao.NumeroLocalizador;
                lblNome.Text = registroDao.Nome;
                lblDataProcessamento.Text = registroDao.DataProcessamento.ToString("dd/MM/yyyy HH:mm");
                lblDataPostagem.Text = registroDao.DataPostagem.ToString("dd/MM/yyyy HH:mm");
                if (registroDao.DataRetorno != DateTime.MinValue)
                {
                    lblDataRetorno.Text = registroDao.DataRetorno.ToString("dd/MM/yyyy HH:mm");    
                }              
                
                lblCpfCnpj.Text = registroDao.CpfCnpj;
                lblNumeroContrato.Text = registroDao.NumeroContrato;
                //imgArquivoDigitalizado.ImageUrl = ConfigurationManager.AppSettings["ArFiles"].ToString() + registroDao.ArquivoDigitalizado;
                imgArquivoDigitalizado.ImageUrl = registroDao.ImgUrl;
              
                
            }
        }

        protected void btnImprimir_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImprimirTela();
            }
            catch (Exception ex)
            {

                ExibirMensagemAlerta("Desculpe ocorreu um erro: " + ex.Message);
            }
        }
        protected void btnSair_Click(object sender, ImageClickEventArgs e)
        {
            Session["sesUser"] = null;
            Response.Redirect(ConfigurationManager.AppSettings["Url"].ToString());
        }
        protected void btnVoltar_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}