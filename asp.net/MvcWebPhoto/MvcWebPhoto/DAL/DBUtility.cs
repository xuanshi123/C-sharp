using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

namespace MvcWebPhoto.DAL
{
    public class DBUtility
    {
        private static string connectionStr = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=" + HttpContext.Current.Server.MapPath("~/App_Data/wyq.mdb");

        private static OleDbConnection conn()
        {
            return new OleDbConnection(connectionStr);

        }

        public static void ExecuteNonQuery(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection oledbconn = conn())
            {
                oledbconn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, oledbconn))
                {
                    if (parameters != null)
                    {
                        foreach (OleDbParameter para in parameters)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static DataSet Query(string sql, params OleDbParameter[] parameters)
        {
            using (OleDbConnection oledbconn = conn())
            {
                oledbconn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = oledbconn;
                    cmd.CommandText = sql;

                    if (parameters != null)
                    {
                        foreach (OleDbParameter para in parameters)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }

                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);

                    return ds;
                }
            }
        }

        public static bool Exists(string sql, params OleDbParameter[] parameter)
        {
            object result = ExecuteScalar(sql, parameter);
            if (result == null || result.ToString().Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static object ExecuteScalar(string sql, params OleDbParameter[] parameter)
        {
            using (OleDbConnection oledbconn = conn())
            {
                oledbconn.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = oledbconn;
                    cmd.CommandText = sql;

                    if (parameter != null)
                    {
                        foreach (OleDbParameter para in parameter)
                        {
                            cmd.Parameters.Add(para);
                        }
                    }

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}