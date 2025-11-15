using System;
using System.Collections.Generic;
using System.Text;
using BPDWeb.Kernel.Dominio;
using BPDWeb.Kernel.DB.Sql;
using System.Data;


namespace BPDWeb.Kernel.Dominio
{
    public abstract  class Dominio
    {

        private DominioDAO _dao;
        protected DominioDAO Dao
        {
            get { return _dao; }
            set { _dao = value; }
        }

        public Dominio(DominioDAO dao)
        {
            this._dao = dao;
        }

        public Dominio()
        {
            this.Dao = new DominioDAO();
        }


        public virtual int Incluir()
        {
            SqlInclusao sql = new SqlInclusao(this.Dao);
            return sql.Incluir();

        }

        public virtual bool Excluir()
        {
            SqlExclusao sqlExclusao = new SqlExclusao(this.Dao);
            return sqlExclusao.Excluir();
        }

        public virtual int Alterar()
        {
            SqlUpdate sqlUpdate = new SqlUpdate(this.Dao);
            return sqlUpdate.Alterar();
        }

        public  DominioDAO RecuperarDao()
        {
            Sql sql = new Sql(this.Dao);
            return sql.RecuperarDao();
        }

        public  DataSet RecuperarLista()
        {
            Sql sql = new Sql(this.Dao);
            return sql.RecuperarListaDao();
        }
    }
}
