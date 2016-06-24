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
    public class Comment : IComment
    {
        public void Add(Models.Entities.Comment model)
        {
            string sql = "insert into Comment(ArticleID,[Content],[Creator]) values (@ArticleID,@Content,@Creator)";

            OleDbParameter[] parameter = { new OleDbParameter("@Title", OleDbType.Integer, 4),
                                             new OleDbParameter("@Content",OleDbType.VarChar,-1),
                                         new OleDbParameter("@Content",OleDbType.VarChar,50)};

            parameter[0].Value = model.ArticleID;
            parameter[1].Value = model.Content;
            parameter[2].Value = model.Creator;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void Delete(int ID)
        {
            string sql = "delete from Comment where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public Models.Entities.Comment GetModel(int ID)
        {
            string sql = "select * from Comment where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.Comment model = new Models.Entities.Comment();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.ArticleID = int.Parse(ds.Tables[0].Rows[0]["ArticleID"].ToString());
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
            sql.Append("select * from Comment");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }
    }
}