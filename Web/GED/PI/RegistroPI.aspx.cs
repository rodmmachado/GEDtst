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
    public partial class RegistroPI : PaginaWeb
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.LimparCampos();
                
                if (Session["sesUser"] != null)
                {
                    EstruturaUsuario usuario = (EstruturaUsuario)Session["sesUser"];

                    if (usuario.IdUsuario <= 0 || usuario.Tipo != 2)
                    {
                        Response.Redirect("../../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                }
                else
                {
                    Response.Redirect("../../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                }
            }
        }
               
        protected void lkbInicio_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("../Default.aspx");
        }
        protected void lkbUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Usuario/EditarUsuario.aspx");
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

        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.Pesquisar();
        }

        private void Pesquisar()
        {
            try
            {             
                string numeroLocalizador = txtNumeroLocalizador.Text.Trim();
                
                DataSet dsRegistros = RegistroCONTROLADOR.RecuperarRegistroPeloNumeroLocalizador(numeroLocalizador);

                if (dsRegistros.Tables[0].Rows.Count > 0)
                {
                    
                    int status = Convert.ToInt32(dsRegistros.Tables[0].Rows[0]["status"].ToString());
                    string statusDesc = String.Empty;

                    switch (status)
                    {
                        case 0: statusDesc = "-";
                                break;

                        case 1: statusDesc = "Postado";
                                break;

                        case 2: statusDesc = "Aguardando Classificação";
                                break;

                        case 3: statusDesc = "Positivo";
                                break;

                        case 4: statusDesc = "Negativo - Devolvido";
                                break;

                        case 5: statusDesc = "PI";
                                break;
                    }

                    ltrIdRegistro.Text = dsRegistros.Tables[0].Rows[0]["id_registro"].ToString();

                    lblNumeroLocalizador.Text = dsRegistros.Tables[0].Rows[0]["numero_localizador"].ToString();
                    lblNome.Text = dsRegistros.Tables[0].Rows[0]["nome"].ToString();
                    lblDataProcessamento.Text = Convert.ToDateTime(dsRegistros.Tables[0].Rows[0]["data_processamento"]).ToString("dd/MM/yyyy HH:mm");
                    lblDataPostagem.Text = Convert.ToDateTime(dsRegistros.Tables[0].Rows[0]["data_postagem"]).ToString("dd/MM/yyyy HH:mm");
                    lblStatus.Text = statusDesc;
                    txtNumeroPI.Text = string.Empty;

                    if (status > Registro.POSTADO)
                    {
                        btnRegistrarPI.Enabled = false;
                        txtNumeroPI.Enabled = false;
                        lblResultado.Text = "AR já retornou, o registro de PI não é permitido.";
                    }
                    else
                    {
                        btnRegistrarPI.Enabled = true;
                        txtNumeroPI.Enabled = true;
                        lblResultado.Text = "[" + dsRegistros.Tables[0].Rows.Count + "] resultado(s) encontrado(s).";
                    }
                }
                else
                {
                    this.LimparCampos();
                    lblResultado.Text = "[" + dsRegistros.Tables[0].Rows.Count + "] resultado(s) encontrado(s).";
                }        
            }
            catch (Exception ex)
            {
                this.ExibirMensagemAlerta(ex.Message);
            }             
        }

        private void LimparCampos()
        {
            lblNumeroLocalizador.Text = String.Empty;
            lblNome.Text = String.Empty;
            lblDataProcessamento.Text = String.Empty;
            lblDataPostagem.Text = String.Empty;
            lblStatus.Text = String.Empty;
            btnRegistrarPI.Enabled = false;
            txtNumeroPI.Enabled = false;
            txtNumeroPI.Text = string.Empty;
            ltrIdRegistro.Text = "0";
        }

        protected void btnRegistrarPI_Click(object sender, EventArgs e)
        {
            try 
	        {	   
                int idRegistro = Convert.ToInt32(ltrIdRegistro.Text);

                RegistroDAO dao = new RegistroDAO();
                dao.IdRegistro = idRegistro;
                dao = RegistroCONTROLADOR.RecuperarDao(dao);

                if (dao.Status <= Registro.POSTADO)
                {
                    dao.Status = Registro.PI;
                    dao.NumeroPI = txtNumeroPI.Text;
                    RegistroCONTROLADOR.Manter(dao);
                    this.ExibirMensagemAlerta("Registro feito com sucesso!"); 
                    this.LimparCampos();
                }
                else
                {
                    this.ExibirMensagemAlerta("Não foi possível registrar, STATUS inválido!"); 
                }
	        }
	        catch (Exception ex)
	        {
        		this.ExibirMensagemAlerta("ERRO: " + ex.Message); 
	        }
        }
    }
}