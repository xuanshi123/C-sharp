using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;
using System.Data.OleDb;
using System.Data;
using System.Text;

namespace MvcWebPhoto.DAL
{
    public class FAQ : IFAQ
    {
        public int GetMaxID()
        {
            string sql = "select Max(ID) from FAQ";

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

        public void Add(Models.Entities.FAQ model)
        {
            string sql = "insert into FAQ(Title,Content) values (@Title,@Content)";

            OleDbParameter[] parameter = { new OleDbParameter("@Title", OleDbType.VarChar, 50),
                                         new OleDbParameter("Content",OleDbType.VarChar,-1)};

            parameter[0].Value = model.Title;
            parameter[1].Value = model.Content;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void Update(Models.Entities.FAQ model)
        {
            string sql = "update FAQ set Title=@Title,Content=@Content where ID=@ID";

            OleDbParameter[] paramter ={new OleDbParameter("@Title",OleDbType.VarChar,50),
                                      new OleDbParameter("@Content",OleDbType.VarChar,-1),
                                      new OleDbParameter("@ID",OleDbType.Integer,4)};

            paramter[0].Value = model.Title;
            paramter[1].Value = model.Content;
            paramter[2].Value = model.ID;

            DBUtility.ExecuteNonQuery(sql, paramter);
        }

        public void Delete(int ID)
        {
            string sql = "Delete from FAQ where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public Models.Entities.FAQ GetModel(int ID)
        {
            string sql = "select * from FAQ where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.FAQ model = new Models.Entities.FAQ();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetList(string iswhere)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select ID,Title,CreateDate from FAQ");

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
            sql.Append("select ID,Title,Content,CreateDate from FAQ");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Asc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }
    }
}