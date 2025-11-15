using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB;

namespace BPDWeb.Kernel.Cadastro
{
    public class Cliente : Dominio.Dominio
    {

        #region ___________________Propiedades_______________________

        public ClienteDAO ClienteDAO
        {
            get { return (ClienteDAO)base.Dao; }
            set { base.Dao = value; }
        }
        #endregion

        #region ____________________Construtores_____________________

        public Cliente(DominioDAO dao)
            : base(dao)
        {
        }

        public Cliente()
            : base()
        {
        }
        #endregion

        #region 

        public override int Incluir()
        {
            //Verificar existencia de um cliente com o mesmo idClienteBPDSystem

            return base.Incluir();
        }
        
        public override bool Excluir()
        {
            //Excluir todos os Produtos
            //Excluit todos os Usuarios

            return base.Excluir();
        }

        #endregion

        #region ______________________SQL___________________________

        public DataSet RecuperarListaCliente()
        {
            string sql = @" SELECT * 
                            FROM cliente 
                            WHERE ativo IS TRUE
                            ORDER BY nome_fantasia";
            Persistencia persistencia = new Persistencia("cliente");
            return persistencia.ExecutarConsulta(sql);
        }

        public int RetornarIdCliente(int idClienteBPDSystem)
        {
            string sql = @" SELECT id_cliente 
                            FROM cliente 
                            WHERE id_cliente_bpdsystem = {0} ";

            sql = String.Format(sql, idClienteBPDSystem);
            Persistencia persistencia = new Persistencia("cliente");
            DataSet dsCliente = persistencia.ExecutarConsulta(sql);

            if (dsCliente.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32("0" + dsCliente.Tables[0].Rows[0]["id_cliente"]);
            }
            else
            {
                return 0;
            }
        }        

        #endregion


    }
}

