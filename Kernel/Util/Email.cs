using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace BPDWeb.Kernel.Util
{
    public class Email
    {

        private MailMessage email;
        private NetworkCredential smtpinfo;
        private SmtpClient smtpClient;

        private string mensagem;

        /// <summary>
        /// A mendagem do Email
        /// </summary>
        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }


        private string titulo;
        /// <summary>
        ///  O título do Email.
        /// </summary>
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }



        private string para;

        /// <summary>
        ///  O email destinatário.
        /// </summary>

        public string Para
        {
            get { return para; }
            set { para = value; }
        }


        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        /// <summary>
        /// Quem envia a carta
        /// </summary>
        private string de;

        public string De
        {
            get { return de; }
            set { de = value; }
        }
        private string servidorSmtp;

        public string ServidorSmtp
        {
            get { return servidorSmtp; }
            set { servidorSmtp = value; }
        }
        private int porta;

        public int Porta
        {
            get { return porta; }
            set { porta = value; }
        }

        private string nomeParaExibicao;

        public string NomeParaExibicao
        {
            get { return nomeParaExibicao; }
            set { nomeParaExibicao = value; }
        }

        private IList<string> listaAnexo;

        /// <summary>
        /// Anexo
        /// </summary>
        public IList<string> ListaAnexo
        {
            get { return this.listaAnexo; }
            set { this.listaAnexo = value; }
        }

        ///<summary> Cria uma nova instâcia de Email</summary>
        ///<remarks> titulo: O titulo do Email; mensagem: A mensagem do Email </remarks>
        public Email(string titulo, string mensagem, string de, string nomeExibicao, string para, string login, string senha, string servidorSmtp, int porta)
        {
            this.Titulo = titulo;
            this.Mensagem = mensagem;
            this.De = de;
            this.Para = para;
            this.Login = login;
            this.Senha = senha;
            this.ServidorSmtp = servidorSmtp;
            this.Porta = porta;
            this.NomeParaExibicao = nomeExibicao;

            MontarMensagem();
            ConfigurarEmail();

        }


        public Email(string titulo, string mensagem, string de, string nomeExibicao, List<string> para, string login, string senha, string servidorSmtp, int porta)
        {
            this.Para = "";
            foreach (string email in para)
            {
                this.Para += email +",";
            }


            this.Titulo = titulo;
            this.Mensagem = mensagem;
            this.De = de;

            this.Login = login;
            this.Senha = senha;
            this.ServidorSmtp = servidorSmtp;
            this.Porta = porta;
            this.NomeParaExibicao = nomeExibicao;

            MontarMensagem();
            ConfigurarEmail();

        }

        public Email(string titulo, string mensagem, string de, string nomeExibicao, List<string> para, string login, string senha, string servidorSmtp, int porta, List<string> ListaAnexo)
        {
            this.ListaAnexo = new List<string>();
            this.ListaAnexo = ListaAnexo;

            this.Para = "";
            foreach (string email in para)
            {
                this.Para += email + ",";
            }


            this.Titulo = titulo;
            this.Mensagem = mensagem;
            this.De = de;

            this.Login = login;
            this.Senha = senha;
            this.ServidorSmtp = servidorSmtp;
            this.Porta = porta;
            this.NomeParaExibicao = nomeExibicao;           

            MontarMensagem();
            ConfigurarEmail();

        }

        /// <summary>
        /// Informa quem envia a mensage, o destinatario, a mensagem e o titulo do Email.
        /// </summary>
        private void MontarMensagem()
        {
            email = new MailMessage();

            email.To.Add(para);
            email.From = new MailAddress(this.De, nomeParaExibicao);
            email.IsBodyHtml = true;
            email.Subject = Titulo;
            email.Body = Mensagem;
            
            if (this.ListaAnexo.Count > 0)
            {
                foreach (string Anexo in ListaAnexo)
                {
                    email.Attachments.Add(new Attachment(Anexo));
                }
            }
        }
        /// <summary>
        /// Configura o Email.
        /// </summary>
        private void ConfigurarEmail()
        {
            smtpinfo = new NetworkCredential(this.Login, this.Senha);
            smtpClient = new SmtpClient(this.ServidorSmtp, this.Porta);


            //para gmail/email com ssl ou SMTP STARTTLS descomentar:
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = smtpinfo;
            smtpClient.EnableSsl = false;
        }

        /// <summary>
        /// Envia o Email
        /// </summary>
        public void Enviar()
        {
            smtpClient.Send(email);
            email.Dispose();
        }


        //MailMessage email = new MailMessage();

        //email.To.Add("producao@bpd.com.br");
        //email.From = new MailAddress("producao@bpd.com.br");
        //email.IsBodyHtml = false;
        //email.Subject = "Aprovação de Arquivo de: " + cliente;
        //email.Body = "O Protocolo " + protocolo + " foi aprovado!";


        //System.Net.NetworkCredential smtpinfo = new System.Net.NetworkCredential("producao@bpd.com.br", "producao");

        //SmtpClient smtpClient = new SmtpClient("mail.bpd.com.br", 25);
        //smtpClient.UseDefaultCredentials = false;
        //smtpClient.Credentials = smtpinfo;
        //smtpClient.EnableSsl = true;

        //smtpClient.Send(email);
        //email.Dispose();



    }
}
