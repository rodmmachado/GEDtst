using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB;
using BPDWeb.Kernel.Util;
using System.IO;
using System.Configuration;
using System.Web.UI;

namespace BPDWeb.Kernel.Seguranca
{
    public class Usuario : Dominio.Dominio
    {

        #region ___________________Propiedades_______________________

        public UsuarioDAO UsuarioDAO
        {
            get { return (UsuarioDAO)base.Dao; }
            set { base.Dao = value; }
        }
        #endregion

        #region ____________________Construtores_____________________

        public Usuario(DominioDAO dao)
            : base(dao)
        {
        }

        public Usuario()
            : base()
        {
        }
        #endregion

        #region ______________________SQL___________________________



        public DataSet RecuperarListaUsuario()
        {
            string sql = @" SELECT * 
                            FROM usuario 
                            ORDER BY id_usuario ";
            Persistencia persistencia = new Persistencia("usuario");
            return persistencia.ExecutarConsulta(sql);
        }

        internal DataSet RecuperarListaUsuario(int idCliente)
        {
            string sql = @" SELECT DISTINCT us.*
                            FROM usuario as us
                            LEFT JOIN usuario_cliente as uc ON (us.id_usuario = uc.id_usuario) 
                            WHERE us.tipo = 2 ";
            if (idCliente > 0)
            {
                sql += " AND uc.id_cliente = {0} ";
            }

            sql += " ORDER BY us.nome ";

            sql = String.Format(sql, idCliente);
            Persistencia persistencia = new Persistencia("usuario");
            return persistencia.ExecutarConsulta(sql);
        }

        public DataSet RetornarDadosCompletosUsuario(int idUsuario)
        {
            string sql = @" SELECT us.*, cl.nome_fantasia, cl.razao_social 
                            FROM usuario as us
                            LEFT JOIN usuario_cliente as uc ON (us.id_usuario = uc.id_usuario)
                            INNER JOIN cliente as cl ON (uc.id_cliente = cl.id_cliente) 
                            WHERE us.id_usuario = {0}                            
                            ";

            sql = String.Format(sql, idUsuario);
            Persistencia persistencia = new Persistencia("usuario");
            return persistencia.ExecutarConsulta(sql);
        }

        internal void EnviarSenha(string email, string ip, string path)
        {
            string sql = @" SELECT us.*, cl.nome_fantasia 
                            FROM usuario as us
                            LEFT JOIN usuario_cliente as uc ON (us.id_usuario = uc.id_usuario)
                            INNER JOIN cliente as cl ON (uc.id_cliente = cl.id_cliente)
                            WHERE (us.email = '{0}')
                              AND (us.tipo = 2)                            
                            ";

            sql = String.Format(sql, email);
            Persistencia persistencia = new Persistencia("usuario");
            DataSet dsUsuario = persistencia.ExecutarConsulta(sql);

            if (dsUsuario.Tables[0].Rows.Count > 0)
            {
                string mensagemHtml = String.Empty;

                StreamReader arquivoModeloEmail = new StreamReader(path, System.Text.Encoding.GetEncoding("ISO-8859-1"));
                mensagemHtml = arquivoModeloEmail.ReadToEnd();
                arquivoModeloEmail.Close();

                mensagemHtml = mensagemHtml.Replace("[%email%]", dsUsuario.Tables[0].Rows[0]["email"].ToString());
                mensagemHtml = mensagemHtml.Replace("[%senha%]", dsUsuario.Tables[0].Rows[0]["senha"].ToString());
                mensagemHtml = mensagemHtml.Replace("[%ip%]", ip);
                mensagemHtml = mensagemHtml.Replace("[%data%]", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                string tituloEmail = "Senha de acesso ao site da BPD";

                string remetente = ConfigurationSettings.AppSettings["de"];
                string destinatario = dsUsuario.Tables[0].Rows[0]["email"].ToString();
                string login = ConfigurationSettings.AppSettings["login"];
                string senha = ConfigurationSettings.AppSettings["senhaEmail"];
                string servidorSmtp = ConfigurationSettings.AppSettings["servidorSmtp"];
                int porta = Convert.ToInt32(ConfigurationSettings.AppSettings["porta"]);

                List<string> listaDestinatario = new List<string>();
                listaDestinatario.Add(destinatario);

                Email mail = new Email(tituloEmail, mensagemHtml, remetente, "BPD Impressão de Dados", listaDestinatario, login, senha, servidorSmtp, porta);
                mail.Enviar();
            }          
        }

        internal DataSet EfetuarLogin(string email, string senha)
        {
            string sql = @" SELECT us.* 
                            FROM usuario as us
                            WHERE (us.email = '{0}') 
                              AND (us.senha = '{1}')                     
                            ";

            sql = String.Format(sql, email, senha);
            Persistencia persistencia = new Persistencia("usuario");
            return persistencia.ExecutarConsulta(sql);
        }

//        internal DataSet EfetuarLoginAdministrativo(string email, string senha)
//        {
//            string sql = @" SELECT us.*, 'Administrador' AS nome_fantasia 
//                            FROM usuario as us
//                            WHERE (us.email = '{0}') 
//                              AND (us.senha = '{1}')
//                              AND (us.tipo = 1)                            
//                            ";

//            sql = String.Format(sql, email, senha);
//            Persistencia persistencia = new Persistencia("usuario");
//            return persistencia.ExecutarConsulta(sql);
//        }

        #endregion

        
    }
}

