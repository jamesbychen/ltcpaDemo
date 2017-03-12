using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.API;

namespace WebApplication1
{
    public partial class main : System.Web.UI.Page
    {
        API.DefaultController dc = new DefaultController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["logininfo"] == null)
                    Page.Response.Redirect("login.aspx");
                else
                {
                    pnEdit.Visible = false;
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pnList.Visible = false;
            pnEdit.Visible = true;
            txbSn.Text = "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string rowcount = "";
            Hashtable form = new Hashtable();
            form.Add("firstname", txbFirstname.Text);
            form.Add("lastname", txbLastname.Text);
            form.Add("socialid", txbSocialid.Text);
            form.Add("gender", rblGender.SelectedValue);
            form.Add("birthday", txbBirthday.Text);
            form.Add("telephone1", txbTel1.Text);
            form.Add("telephone2", txbTel2.Text);
            form.Add("telephone3", txbTel3.Text);
            form.Add("address", txbAddr.Text);
            if (txbSn.Text.Equals("") || txbSn.Text.Equals("0"))
            {//add
                rowcount=dc.Add(form);
            }
            else
            {//update
                form.Add("sn", txbSn.Text);
                rowcount = dc.update(form);
            }
            Page.Response.Redirect("main.aspx");
        }

        protected void txbCancel_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("main.aspx");
        }

        private void bindData(string sn)
        {
            Hashtable ht = new Hashtable();
            ht = dc.getData(int.Parse(sn));
            txbFirstname.Text = ht["firstname"].ToString();
            txbLastname.Text = ht["lastname"].ToString();
            txbSocialid.Text = ht["socialid"].ToString();
            txbBirthday.Text = ht["birthday"].ToString();
            rblGender.SelectedIndex = -1;
            rblGender.Items.FindByValue(ht["gender"].ToString()).Selected = true;
            txbTel1.Text = ht["telephone1"].ToString();
            txbTel2.Text = ht["telephone2"].ToString();
            txbTel3.Text = ht["telephone3"].ToString();
            txbAddr.Text = ht["address"].ToString();
        }
        protected void dgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnList.Visible = false;
            pnEdit.Visible = true;
            txbSn.Text = dgList.SelectedItem.Cells[1].Text;
            bindData(txbSn.Text);
        }
    }
}