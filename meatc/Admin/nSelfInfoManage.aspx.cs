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

public partial class Admin_nSelfInfoManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindBasicInfo();
    }

    private void BindBasicInfo()
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from Users where UserId = " + UserId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            txtName.Text = drv["UserName"].ToString();
            txtPhone.Text = drv["UserPhone"].ToString();
            if (drv["BirthDate"].ToString().Length > 0)
                txtBirthDate.Text = Convert.ToDateTime(drv["BirthDate"]).ToLongDateString();
            txtMobileTelephone.Text = drv["MobileTelephone"].ToString();
            txtEmail.Text = drv["UserEmail"].ToString();
            ddlSex.SelectedIndex = Convert.ToInt32(drv["UserSex"]);
        }
    }

    /// <summary>
    /// 提交编辑信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String sql = "update Users set UserName=@username,UserSex=@usersex,UserPhone=@userphone,MobileTelephone=@mobile,UserEmail=@useremail where UserId = " + UserId;
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@username", txtName.Text),
                                   DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                   DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                   DBConnect.MakeParameter("@mobile", txtMobileTelephone.Text),
                                   DBConnect.MakeParameter("@useremail", txtEmail.Text)
                               };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('信息修改成功！');</script>");
    }

    /// <summary>
    /// 显示密码编辑Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEditPassword_Click(object sender, ImageClickEventArgs e)
    {
        panelUpdatePassword.Visible = true;
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPasswordOK_Click(object sender, ImageClickEventArgs e)
    {
        if (!txtPanelPassword.Text.Equals(txtPanelRepeatPassword.Text))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('两次密码输入不一致！');</script>");
            return;
        }
        String UserId = Session["UserId"].ToString();
        String sql = "update Users set LoginPassWord = '" + txtPanelPassword.Text + "' where UserId = " + UserId;
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改成功！');</script>");
        panelUpdatePassword.Visible = false;
    }

    /// <summary>
    /// 关闭密码编辑Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPasswordClose_Click(object sender, ImageClickEventArgs e)
    {
        panelUpdatePassword.Visible = false;
    }
}
