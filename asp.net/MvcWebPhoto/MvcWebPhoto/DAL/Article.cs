using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;
using System.Data.OleDb;
using System.Text;
using System.Data;

namespace MvcWebPhoto.DAL
{
    public class Article : IArticle
    {
        public void Add(Models.Entities.Article model)
        {
            string sql = "insert into Article(Title,CatalogID,Content) values (@Title,@CatalogID,@Content)";

            OleDbParameter[] parameter = { new OleDbParameter("@Title", OleDbType.VarChar, 50),
                                             new OleDbParameter("@CatalogID",OleDbType.Integer,4),
                                         new OleDbParameter("@Content",OleDbType.VarChar,-1)};

            parameter[0].Value = model.Title;
            parameter[1].Value = model.CatalogID;
            parameter[2].Value = model.Content;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void Update(Models.Entities.Article model)
        {
            string sql = "update Article set Title=@Title,CatalogID=@CatalogID,Content=@Content where ID=@ID";

            OleDbParameter[] paramter ={new OleDbParameter("@Title",OleDbType.VarChar,50),
                                           new OleDbParameter("@CatalogID",OleDbType.Integer,4),
                                      new OleDbParameter("@Content",OleDbType.VarChar,-1),
                                      new OleDbParameter("@ID",OleDbType.Integer,4)};

            paramter[0].Value = model.Title;
            paramter[1].Value = model.CatalogID;
            paramter[2].Value = model.Content;
            paramter[3].Value = model.ID;

            DBUtility.ExecuteNonQuery(sql, paramter);
        }

        public void Delete(int ID)
        {
            string sql = "Delete from Article where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public Models.Entities.Article GetModel(int ID)
        {
            string sql = "select * from Article where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.Article model = new Models.Entities.Article();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.CatalogID = int.Parse(ds.Tables[0].Rows[0]["CatalogID"].ToString());
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataTable GetList(string iswhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ID,CatalogID,Title,CreateDate from Article");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }

        public DataTable GetWholeList(string iswhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ID,CatalogID,Title,Content,CreateDate from Article");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }

        public DataTable GetWholeList(string iswhere, int number)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select top " + number + " ID,CatalogID,Title,Content,CreateDate from Article");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }

        public int GetMaxID()
        {
            string sql = "select Max(ID) from Article";

            object result = DBUtility.ExecuteScalar(sql);

            if (result == null || result.ToString().Length == 0)
            {
                return 0;
            }
            else
            {
                return int.Parse(result.ToString());
            }
        }

        public System.Data.DataTable GetList(string iswhere, int pagesize, int page)
        {
            StringBuilder sql = new StringBuilder();
            if (page == 1)
            {
                sql.Append("select top " + pagesize + " * from Article ");
                if (iswhere.Length != 0)
                {
                    sql.Append(" where ").Append(iswhere);
                }
                sql.Append(" order by id desc");
            }
            else
            {
                sql.Append("select top " + pagesize + " * from Article where id not in (select top " + pagesize * (page - 1) + " id from Article ");
                if (iswhere.Length != 0)
                {
                    sql.Append(" where ").Append(iswhere);
                }
                sql.Append(" order by id desc)");
                if (iswhere.Length != 0)
                {
                    sql.Append(" and ").Append(iswhere);
                }
                sql.Append(" order by id desc");
            }

            return DBUtility.Query(sql.ToString()).Tables[0];

        }

        public int GetCount(string iswhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select count(1) from Article");
            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            object result = DBUtility.ExecuteScalar(sql.ToString());

            if (result == null || result.ToString().Length == 0)
            {
                return 0;
            }
            else
            {
                return int.Parse(result.ToString());
            }
        }
    }
}