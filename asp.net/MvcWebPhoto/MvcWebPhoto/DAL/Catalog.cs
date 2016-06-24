using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text;
using MvcWebPhoto.Models.Interfaces;

namespace MvcWebPhoto.DAL
{
    public class Catalog : ICatalog
    {
        public void Add(Models.Entities.Catalog model)
        {
            string sql = "insert into [Catalog](CatalogName) values (@CatalogName)";

            OleDbParameter[] parameters = { new OleDbParameter("@CatalogName", OleDbType.VarChar, 50) };
            parameters[0].Value = model.CatalogName;

            DBUtility.ExecuteNonQuery(sql, parameters);
        }

        public void Update(Models.Entities.Catalog model)
        {
            string sql = "update [Catalog] set CatalogName=@CatalogName where ID=@ID";

            OleDbParameter[] parameters = { new OleDbParameter("@CatalogName", OleDbType.VarChar, 50),
                                          new OleDbParameter("@ID",OleDbType.Integer,4)};

            parameters[0].Value = model.CatalogName;
            parameters[1].Value = model.ID;

            DBUtility.ExecuteNonQuery(sql, parameters);
        }

        public void Delete(int ID)
        {
            string sql = "delete from [Catalog] where ID=" + ID;

            DBUtility.ExecuteNonQuery(sql);
        }

        public Models.Entities.Catalog GetModel(int ID)
        {
            string sql = "select * from [Catalog] where ID=" + ID;
            DataTable dt = DBUtility.Query(sql).Tables[0];

            if (dt.Rows.Count != 0)
            {
                Models.Entities.Catalog model = new Models.Entities.Catalog();
                model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                model.CatalogName = dt.Rows[0]["CatalogName"].ToString();
                model.CreateDate = DateTime.Parse(dt.Rows[0]["CreateDate"].ToString());

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
            sql.Append("select * from [Catalog] ");
            if (!string.IsNullOrEmpty(iswhere))
            {
                sql.Append(" where ").Append(iswhere);
            }

            return DBUtility.Query(sql.ToString()).Tables[0];
        }

        public int GetMaxID()
        {
            string sql = "select Max(ID) from [Catalog]";

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
    }
}