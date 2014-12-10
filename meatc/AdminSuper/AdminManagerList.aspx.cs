using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Drawing;

public partial class AdminSuper_AdminManagerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindAdminList();
    }

    private void BindAdminList()
    {
        String sql = "select * from Users where UserType = 4 order by UserId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            gv_admin.DataSource = ds;
            gv_admin.DataBind();
        }
    }
    protected void gv_admin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text.Equals("0"))
                e.Row.Cells[2].Text = "女";
            else
                e.Row.Cells[2].Text = "男";

            if (e.Row.Cells[6].Text.Equals("1"))
                e.Row.Cells[6].Text = "正常";
            else
            {
                e.Row.Cells[6].Text = "禁用";
                e.Row.Cells[6].BackColor = Color.Red;
            }
        }
    }
    protected void gv_admin_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ModifyAdmin")
        {
            panel_edit.Visible = true;
            tr_pwd.Visible = false;
            hf_userId.Value = e.CommandArgument.ToString();
            hf_operation.Value = "modify";
            String sql = "select * from Users where UserId = " + hf_userId.Value;
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
            {
                DataRowView drv = ds.Tables[0].DefaultView[0];
                tb_loginName.Text = drv["LoginName"].ToString();
                tb_username.Text = drv["UserName"].ToString();
                tb_email.Text = drv["UserEmail"].ToString();
                tb_phone.Text = drv["UserPhone"].ToString();
                tb_mobile.Text = drv["MobileTelephone"].ToString();
                ddlSex.SelectedValue = drv["UserSex"].ToString();
                if (drv["StateId"].ToString().Equals("1"))
                    rb_ok.Checked = true;
                else
                    rb_no.Checked = true;
                tr_pwd.Visible = false;
                if (drv["StateId"].ToString().Equals("1"))
                    rb_ok.Checked = true;
                else
                    rb_no.Checked = true;
            }
        }
    }

    /// <summary>
    /// 提交修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_submit_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "";
        int stateid = 1;
        if(rb_no.Checked)
            stateid = 2;
        if (hf_operation.Value.Equals("modify"))
        {
            sql = "update Users set LoginName = @loginname,UserName = @username,UserSex=@usersex,UserPhone=@userphone,MobileTelephone=@mobile,UserEmail=@email,StateId = @stateid where UserId = " + hf_userId.Value;
        }
        else
        {
            sql = "insert into Users (LoginName, LoginPassWord, UserName, UserSex, UserPhone, MobileTelephone, UserEmail, UserType, StateId) values (@loginname,'"+tb_pwd.Text+"',@username,@usersex,@userphone,@mobile,@email,4,@stateid)";
        }
        DBConnect db = new DBConnect();
        SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@loginname", tb_loginName.Text),
                                   DBConnect.MakeParameter("@username", tb_username.Text),
                                   DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                   DBConnect.MakeParameter("@userphone", tb_phone.Text),
                                   DBConnect.MakeParameter("@mobile", tb_mobile.Text),
                                   DBConnect.MakeParameter("@email", tb_email.Text),
                                   DBConnect.MakeParameter("@stateid", stateid)
                               };
        db.ExecuteSql(sql, paras);
        panel_edit.Visible = false;
        BindAdminList();
    }
    protected void bt_add_Click(object sender, ImageClickEventArgs e)
    {
        hf_operation.Value = "add";
        tb_loginName.Enabled = true;
        tb_loginName.Text = tb_email.Text = tb_mobile.Text = tb_phone.Text = tb_username.Text = "";
        rb_ok.Checked = true;
        ddlSex.SelectedValue = "1";
        tr_pwd.Visible = true;
        panel_edit.Visible = true;
    }
    protected void bt_cancel_Click(object sender, ImageClickEventArgs e)
    {
        panel_edit.Visible = false;
    }
    protected void bt_exit_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
    }
}
