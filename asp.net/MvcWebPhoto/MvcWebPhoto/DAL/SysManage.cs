using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using MvcWebPhoto.Models.Interfaces;
using System.Data;

namespace MvcWebPhoto.DAL
{
    public class SysManage : ISysManage
    {
        public void Update(Models.Entities.SysManage model)
        {
            string sql = "update SysManage set Content=@Content where Identity=@Identity";

            OleDbParameter[] paramter ={new OleDbParameter("@Content",OleDbType.VarChar,-1),
                                      new OleDbParameter("@Identity",OleDbType.Integer,4)};

            paramter[0].Value = model.Content;
            paramter[1].Value = model.Identity;

            DBUtility.ExecuteNonQuery(sql, paramter);
        }

        public Models.Entities.SysManage GetModel(int ID)
        {
            string sql = "select * from SysManage where Identity=@Identity";

            OleDbParameter[] parameter = { new OleDbParameter("@Identity", OleDbType.Integer, 4) };
            parameter[0].Value = ID;

            DataSet ds = DBUtility.Query(sql, parameter);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Models.Entities.SysManage model = new Models.Entities.SysManage();

                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.Identity = int.Parse(ds.Tables[0].Rows[0]["Identity"].ToString());
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                model.Explain = ds.Tables[0].Rows[0]["Explain"].ToString();
                model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}