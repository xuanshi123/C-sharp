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
    public class Supplier:ISupplier
    {
        public void Add(Models.Entities.Supplier model)
        {
            string sql = "insert into Supplier(SupplierName,SupplierUrl) values (@SupplierName,@SupplierUrl)";

            OleDbParameter[] parameter = { new OleDbParameter("@SupplierName", OleDbType.VarChar, 50),
                                             new OleDbParameter("@SupplierUrl",OleDbType.VarChar,255)};

            parameter[0].Value = model.SupplierName;
            parameter[1].Value = model.SupplierUrl;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void Update(Models.Entities.Supplier model)
        {
            string sql = "update Supplier set SupplierName=@SupplierName,SupplierUrl=@SupplierUrl where ID=@ID";

            OleDbParameter[] paramter ={new OleDbParameter("@SupplierName",OleDbType.VarChar,50),
                                           new OleDbParameter("@SupplierUrl",OleDbType.VarChar,255),
                                      new OleDbParameter("@ID",OleDbType.Integer,4)};

            paramter[0].Value = model.SupplierName;
            paramter[1].Value = model.SupplierUrl;
            paramter[2].Value = model.ID;

            DBUtility.ExecuteNonQuery(sql, paramter);
        }

        public void Delete(int ID)
        {
            string sql = "Delete from Supplier where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public Models.Entities.Supplier GetModel(int ID)
        {
            string sql = "select * from Supplier where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.Supplier model = new Models.Entities.Supplier();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.SupplierName = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                model.SupplierUrl = ds.Tables[0].Rows[0]["SupplierUrl"].ToString();
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
            sql.Append("select ID,SupplierUrl,SupplierName,CreateDate from Supplier");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }

        public int GetMaxID()
        {
            string sql = "select Max(ID) from Supplier";

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