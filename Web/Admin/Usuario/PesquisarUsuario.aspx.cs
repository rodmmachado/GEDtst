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
using BPDWeb.Util;

namespace BPDWeb.JobTrackerAdmin.Seguranca
{
    public partial class PesquisarUsuario : PaginaWeb
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
                        Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                    }
                    else
                    {
                        this.ListarClientes();
                    }
                }
                else
                {
                    Response.Redirect("../Login.aspx?Page=" + Request.Url.AbsoluteUri);
                }
            }
        }

        private void ListarClientes()
        {
            DataSet dsClientes = ClienteCONTROLADOR.RecuperarListaCliente();

            DataRow row = dsClientes.Tables[0].NewRow();
            row["id_cliente"] = "0";
            row["nome_fantasia"] = "Todos os Clientes";
            dsClientes.Tables[0].Rows.InsertAt(row, 0);

            ddlCliente.DataSource = dsClientes;
            ddlCliente.DataMember = dsClientes.Tables[0].TableName;
            ddlCliente.DataValueField = "id_cliente";
            ddlCliente.DataTextField = "nome_fantasia";
            ddlCliente.DataBind();
        }


        
        protected void dgrUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(dgrUsuarios.DataKeys[dgrUsuarios.SelectedIndex]);

            Response.Redirect("./EditarUsuario.aspx" + this.MontarParametros("idUsuario=" + idUsuario),false);
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

        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void ddlUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnPesquisar_Click(object sender, ImageClickEventArgs e)
        {
            this.Pesquisar();
        }

        private void Pesquisar()
        {
            int idCliente = Convert.ToInt32(ddlCliente.SelectedValue);

            DataSet dsUsuarios = UsuarioCONTROLADOR.RecuperarListaUsuario(idCliente);

            dgrUsuarios.DataSource = dsUsuarios;
            dgrUsuarios.DataMember = dsUsuarios.Tables[0].TableName;
            dgrUsuarios.DataKeyField = "id_usuario";

            dgrUsuarios.DataBind();
        }
        protected void btnNovo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./EditarUsuario.aspx" + this.MontarParametros("idUsuario=0"), false);
        }
        protected void dgrUsuarios_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
            {
                int idUsuario = Convert.ToInt32("0" + e.Item.Cells[0].Text);

                DataSet dsClientes = UsuarioClienteCONTROLADOR.RecuperarListaPeloUsuario(idUsuario);

                foreach (DataRow row in dsClientes.Tables[0].Rows)
                {
                    e.Item.Cells[3].Text += row["nome_fantasia"].ToString() + "<br/>";
                }
            }
        }
    }
}