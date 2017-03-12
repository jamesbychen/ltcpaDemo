using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Collections;

namespace WebApplication1.API
{
    public class DefaultController : Controller
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataTable dt;
        private DataRow rows;
        private void getConnection()
        {
            conn = new SqlConnection("Data Source=ltcpa.database.windows.net;Initial Catalog=LTCPA;User id=james;Password=Ltcpa123456789;");
            cmd = new SqlCommand();
            dt = new DataTable();
        }

        private string getPassword(string userID)
        {
            string pw = "";
            getConnection();
            cmd.CommandText = "SELECT [PASSWORD] FROM LOGINUSERS WHERE USERID=@ID";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = userID;
            cmd.Connection = conn;
            conn.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pw = dr.GetString(0);
            }
            conn.Close();
            dr.Close();
            if (pw.Length > 0 || pw != null)
            {
                return pw;
            }
            else
            {
                return "";
            }
        }

        public string checkPassword(string userID, string password)
        {
            string msg = "";
            if (getPassword(userID).Equals(password))
            {
                msg = "success";
            }
            else
            {
                msg = "error";
            }
            return msg;
        }
        public string Add(Hashtable form)
        {
            string msg = "";
            getConnection();
            cmd.CommandText = "sp_insertResident";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = form["firstname"].ToString();
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = form["lastname"].ToString();
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = form["gender"].ToString();
            cmd.Parameters.Add("@socialid", SqlDbType.NVarChar).Value = form["socialid"].ToString();
            cmd.Parameters.Add("@birthday", SqlDbType.NVarChar).Value = form["birthday"].ToString();
            cmd.Parameters.Add("@tel1", SqlDbType.NVarChar).Value = form["telephone1"].ToString();
            cmd.Parameters.Add("@tel2", SqlDbType.NVarChar).Value = form["telephone2"].ToString();
            cmd.Parameters.Add("@tel3", SqlDbType.NVarChar).Value = form["telephone3"].ToString();
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = form["address"].ToString();
            cmd.Connection = conn;
            conn.Open();
            msg=cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return msg;
        }

        public string update(Hashtable form)
        {
            string msg = "";
            getConnection();
            cmd.CommandText = "sp_updateResident";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@sn", SqlDbType.Int).Value = form["sn"];
            cmd.Parameters.Add("@firstname", SqlDbType.NVarChar).Value = form["firstname"].ToString();
            cmd.Parameters.Add("@lastname", SqlDbType.NVarChar).Value = form["lastname"].ToString();
            cmd.Parameters.Add("@gender", SqlDbType.NVarChar).Value = form["gender"].ToString();
            cmd.Parameters.Add("@socialid", SqlDbType.NVarChar).Value = form["socialid"].ToString();
            cmd.Parameters.Add("@birthday", SqlDbType.NVarChar).Value = form["birthday"].ToString();
            cmd.Parameters.Add("@tel1", SqlDbType.NVarChar).Value = form["telephone1"].ToString();
            cmd.Parameters.Add("@tel2", SqlDbType.NVarChar).Value = form["telephone2"].ToString();
            cmd.Parameters.Add("@tel3", SqlDbType.NVarChar).Value = form["telephone3"].ToString();
            cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = form["address"].ToString();
            cmd.Connection = conn;
            conn.Open();
            msg = cmd.ExecuteNonQuery().ToString();
            conn.Close();
            return msg;
        }
        public Hashtable getData(int sn)
        {
            getConnection();
            string cmdStr = "select firstname,lastname,socialid,birthday,gender,telephone1,isnull(telephone2,'') telephone2,isnull(telephone3,'') telephone3,isnull(address,'') address from resident where sn=@sn";
            da = new SqlDataAdapter(cmdStr, conn);
            da.SelectCommand.Parameters.Add("@sn", SqlDbType.Int).Value = sn;
            da.Fill(dt);
            Hashtable ht = new Hashtable();
            rows = dt.Rows[0];
            ht.Add("firstname", rows["firstname"].ToString());
            ht.Add("lastname", rows["lastname"].ToString());
            ht.Add("socialid", rows["socialid"].ToString());
            ht.Add("gender", rows["gender"].ToString());
            ht.Add("birthday", rows["birthday"].ToString());
            ht.Add("address", rows["address"].ToString());
            ht.Add("telephone1", rows["telephone1"].ToString());
            ht.Add("telephone2", rows["telephone2"].ToString());
            ht.Add("telephone3", rows["telephone3"].ToString());

            return ht;
        }
    }
}