using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcWebPhoto.Models.Interfaces;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace MvcWebPhoto.DAL
{
    public class ContactUs : IContactUs
    {
        public void Add(Models.Entities.ContactUs model)
        {
            string sql = "insert into ContactUs(Name,Email,Mobile,Content) values (@Name,@Email,@Mobile,@Content)";

            OleDbParameter[] parameter = { new OleDbParameter("@Name", OleDbType.VarChar, 255),
                                             new OleDbParameter("@Email",OleDbType.VarChar,255),
                                             new OleDbParameter("@Mobile",OleDbType.VarChar,255),
                                         new OleDbParameter("@Content",OleDbType.VarChar,-1)};

            parameter[0].Value = model.Name;
            parameter[1].Value = model.Email;
            parameter[2].Value = model.Mobile;
            parameter[3].Value = model.Content;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void UpdateEmailAccounts(Models.Entities.EmailAccounts model)
        {
            string sql = "update EmailAccounts set ReceiveAccounts=@ReceiveAccounts,SendAccounts=@SendAccounts,SendAddress=@SendAddress,SendUser=@SendUser,SendPassword=@SendPassword,Port=@Port";

            OleDbParameter[] parameter = { new OleDbParameter("@ReceiveAccounts", OleDbType.VarChar, 50),
                                             new OleDbParameter("@SendAccounts",OleDbType.VarChar,50),
                                             new OleDbParameter("@SendAddress",OleDbType.VarChar,50),
                                         new OleDbParameter("@SendUser",OleDbType.VarChar,50),
                                         new OleDbParameter("@SendPassword",OleDbType.VarChar,50),
                                         new OleDbParameter("@Port",OleDbType.Integer,4)};

            parameter[0].Value = model.ReceiveAccounts;
            parameter[1].Value = model.SendAccounts;
            parameter[2].Value = model.SendAddress;
            parameter[3].Value = model.SendUser;
            parameter[4].Value = model.SendPassword;
            parameter[5].Value = model.Port;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public void Delete(int ID)
        {
            string sql = "Delete from ContactUs where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DBUtility.ExecuteNonQuery(sql, parameter);
        }

        public Models.Entities.ContactUs GetModel(int ID)
        {
            string sql = "select * from ContactUs where ID=@ID";

            OleDbParameter[] parameter = { new OleDbParameter("@ID", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.ContactUs model = new Models.Entities.ContactUs();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }

        public Models.Entities.EmailAccounts GetModelByEmailAccounts()
        {
            string sql = "select top 1 * from EmailAccounts";

            DataSet ds = DBUtility.Query(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.EmailAccounts model = new Models.Entities.EmailAccounts();

                model.ReceiveAccounts = ds.Tables[0].Rows[0]["ReceiveAccounts"].ToString();
                model.SendAccounts = ds.Tables[0].Rows[0]["SendAccounts"].ToString();
                model.SendAddress = ds.Tables[0].Rows[0]["SendAddress"].ToString();
                model.SendPassword = ds.Tables[0].Rows[0]["SendPassword"].ToString();
                model.SendUser = ds.Tables[0].Rows[0]["SendUser"].ToString();
                model.Port = int.Parse(ds.Tables[0].Rows[0]["Port"].ToString());

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
            sql.Append("selectat ID,Email,Name,Mobile,CreeDate from ContactUs");

            if (iswhere.Length != 0)
            {
                sql.Append(" where ").Append(iswhere);
            }

            sql.Append(" order by CreateDate Desc");

            return DBUtility.Query(sql.ToString()).Tables[0];
        }
    }
}