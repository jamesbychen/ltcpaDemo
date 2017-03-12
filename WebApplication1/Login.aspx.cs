using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.API;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["logininfo"] != null)
                {
                    Page.Response.Redirect("main.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DefaultController dc = new DefaultController();
            string msg = dc.checkPassword(txbUsername.Text.Trim(), txbPassword.Text.Trim());
            if (msg.Equals("success"))
            {
                Session["logininfo"] = txbUsername.Text.Trim();
                Page.Response.Redirect("main.aspx");
            }
            else
            {
                txbUsername.Text = "";
                txbPassword.Text = "";
                lbMsg.Text = "帳號或密碼錯誤！請重新輸入！";
            }
        }
    }
}