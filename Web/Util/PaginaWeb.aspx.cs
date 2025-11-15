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


namespace BPDWeb.Util
{
    public partial class PaginaWeb : System.Web.UI.Page
    {
        private string nome;
        /// <summary>
        /// O nome do Usuario Logado
        /// </summary>
        public string Nome
        {
            get { return nome; }
        }

        private string email;
        /// <summary>
        /// O Email do Usuario Logado
        /// </summary>
        public string Email
        {
            get { return email; }
        }


        private string login;
        /// <summary>
        /// O Login do Usuario Logado
        /// </summary>
        public string Login
        {
            get { return login; }
        }

        public int idUsuario;
        /// <summary>
        /// O Id do Usuario Logado
        /// </summary>
        public int IdUsuario
        {
            get { return idUsuario; }
        }

        private int idCliente;
        /// <summary>
        /// O Id da Empresa do Usuario logado
        /// </summary>
        public int IdCliente
        {
            get { return idCliente; }
        }


        protected override void OnInit(EventArgs e)
        {
            ////Tem que ser aqui pois o evento pageLoad dessa pagina (PaginaWeb) ocorre
            ////depois do pageLoad da PaginaFilha
            ////Esse evento (OnInit) ocorre no inicio do ciclo da pagina e antes do PageLoad
            
            //InicializaUsuario();


            base.OnInit(e);
            ////this.Load += new EventHandler(Page_Load);
        }

        //private void InicializaUsuario()
        //{       //Se o usuario esta auteticado
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        Usuario user = (Usuario)Session["usuario"];

        //        nome = user.Nome;
        //        email = user.Email;
        //        login = user.Login;
        //        idUsuario = user.IdUsuario;
        //        idCliente = user.Cliente.IdCliente;
        //    }
        //}


        public void RedirecionarServer(string caminho)
        {
            Server.Transfer(caminho);
        }

        public void RedirecionarResponse(string caminho)
        {
            Response.Redirect(caminho, false);
        }
        /// <summary>
        /// Exibe uma mensagem em uma função alert
        /// </summary>
        /// <param name="Msg">A mensagem a ser exibida.
        /// Trim em Msg remove o \n e \r e espaços em branco 
        ///</param>
        public void ExibirMensagemAlerta(string Msg)
        {
            string mensagem = " <script language='javascript'> ";
            mensagem += " alert( '" + Msg.Trim().Replace("'", "").Replace("\n", " ").Replace("\r", " ") + "');";
            mensagem += "</script>";
            this.RegisterStartupScript("alerta", mensagem.Trim());
        }



        //public string RecuperarParametros(string parametro)
        // {
        //     return Request.QueryString.Get(parametro);
        // }


        /// <summary>
        /// Imprime o conteudo da tela
        /// </summary>
        public void ImprimirTela()
        {
            string mensagem = " <script language='javascript'> window.print();</script>";

            this.RegisterStartupScript("imprimir", mensagem);
        }

        /// <summary>
        /// Monta os parametros para uma URL:param1=valor1&param2=valor2
        /// </summary>
        /// <param name="parametro">String contendo os paramentros</param>
        /// <returns>A string Criptografada</returns>
        public string MontarParametros(string parametro)
        {
            Acesso acesso = new Acesso();
            return "?parametros=" + acesso.CriptografarParametros(parametro);
        }

        /// <summary>
        /// Recupera os parametros passados
        /// </summary>
        /// <param name="variavel">O nome do paramentros</param>
        /// <returns>O valor do parâmentro</returns>
        public string RecuperarParametros(string variavel)
        {
            string parametro = Request.QueryString["parametros"].ToString();
            Acesso acesso = new Acesso();
            return acesso.DesCriptografarParametros(parametro, variavel);
        }
        /// <summary>
        /// Termina a sessão do usuário e leva-o para a página inicial.
        /// </summary>
        public void SairDaAreaDeLogin()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            ///Response.Redirect("../../index.aspx", false);
        }
    }
}