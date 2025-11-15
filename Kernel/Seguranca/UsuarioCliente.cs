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
    public class UsuarioCliente : Dominio.Dominio
    {

        #region ___________________Propiedades_______________________

        public UsuarioClienteDAO UsuarioClienteDAO
        {
            get { return (UsuarioClienteDAO)base.Dao; }
            set { base.Dao = value; }
        }
        #endregion

        #region ____________________Construtores_____________________

        public UsuarioCliente(DominioDAO dao)
            : base(dao)
        {
        }

        public UsuarioCliente()
            : base()
        {
        }
        #endregion

        #region ______________________SQL___________________________



        public DataSet RecuperarListaUsuarioCliente()
        {
            string sql = @" SELECT * 
                            FROM usuario_cliente 
                            ORDER BY id_usuario_cliente ";
            Persistencia persistencia = new Persistencia("usuario_cliente");
            return persistencia.ExecutarConsulta(sql);
        }

        internal DataSet RecuperarListaPeloCliente(int idCliente)
        {
            string sql = @" SELECT uc.*, cl.nome_fantasia, u.nome, u.email 
                            FROM usuario_cliente as uc
                            INNER JOIN usuario as u ON (uc.id_usuario = u.id_usuario)
                            INNER JOIN cliente as cl ON (uc.id_cliente = cl.id_cliente) 
                            WHERE cl.id_cliente = {0} ";
                                    
            sql = String.Format(sql, idCliente);
            Persistencia persistencia = new Persistencia("usuario_cliente");
            return persistencia.ExecutarConsulta(sql);
        }

        internal DataSet RecuperarListaPeloUsuario(int idUsuario)
        {
            string sql = @" SELECT uc.*, cl.nome_fantasia, u.nome, u.email 
                            FROM usuario_cliente as uc
                            INNER JOIN usuario as u ON (uc.id_usuario = u.id_usuario)
                            INNER JOIN cliente as cl ON (uc.id_cliente = cl.id_cliente)
                            WHERE u.id_usuario = {0} ";

            sql = String.Format(sql, idUsuario);
            Persistencia persistencia = new Persistencia("usuario_cliente");
            return persistencia.ExecutarConsulta(sql);
        }

        #endregion

        
    }
}

