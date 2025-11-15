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
    public partial class RelatorioPendencias : PaginaWeb
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

     

        protected void btnExportarCSV_Click(object sender, EventArgs e)
        {
            int idEntidade = Convert.ToInt32(ltrIdEntidade.Text);
            
            int quantidadeDias = Convert.ToInt32("0" + txtDataInicial.Text);

            DataSet dsDados = RegistroCONTROLADOR.RecuperarListaRegistrosPendentesRetorno(idEntidade, quantidadeDias);

            if (dsDados.Tables[0].Rows.Count > 0)
            {
                Response.ContentType = "Application/x-msexcel";
                Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + txtDataInicial.Text + "_dia(s).csv");
                Response.Write(ExportToCSVFile(dsDados.Tables[0]));
                Response.End();
            }
            else
            {
                this.ExibirMensagemAlerta("Não há dados para serem exportados!");
            }
        }


        private string ExportToCSVFile(DataTable dtTable)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append("\"" + col.ColumnName + "\";");
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        sbldr.Append("\"" + row[column].ToString() + "\";");
                    }
                    sbldr.Append("\r\n");
                }
            }
            return sbldr.ToString();
        }
        
}
}