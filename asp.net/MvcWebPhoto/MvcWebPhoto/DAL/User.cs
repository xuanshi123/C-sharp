using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using MvcWebPhoto.Models.Interfaces;
using System.Data;

namespace MvcWebPhoto.DAL
{
    public class User : IUser
    {
        public Models.Entities.User GetModel(string userid)
        {
            string sql = "select * from [User] where ID=@ID";

            OleDbParameter[] parameters = { new OleDbParameter("@ID", OleDbType.VarChar, 50) };

            parameters[0].Value = userid;

            DataSet ds = DBUtility.Query(sql, parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.User model = new Models.Entities.User();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["ID"].ToString()))
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.UserID = ds.Tables[0].Rows[0]["UserID"].ToString();
                model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["CreateDate"].ToString()))
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public void Update(string userid, string password)
        {
            string sql = "update [User] set PassWord=@password where UserID=@userid";

            OleDbParameter[] parameter ={new OleDbParameter("@userid",OleDbType.VarChar,50),
                                       new OleDbParameter("@password",OleDbType.VarChar,50)};

            parameter[0].Value = userid;
            parameter[1].Value = password;

            DBUtility.ExecuteNonQuery(sql);
        }

        public bool Login(string userid, string password)
        {
            string sql = "select 1 from [User] where UserID=@UserID and PassWord=@PassWord";

            OleDbParameter[] parameter ={new OleDbParameter("@UserID",OleDbType.VarChar,50),
                                       new OleDbParameter("@PassWord",OleDbType.VarChar,50)};
            parameter[0].Value = userid;
            parameter[1].Value = password;

            return DBUtility.Exists(sql, parameter);
        }
    }
}