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

public partial class Admin_nTeacherEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindTeacherBasicInfo();
        }
    }

    private void BindTeacherBasicInfo()
    {
        //添加用户
        if (Request.QueryString["u_id"] == null)
        {
            panel_new.Visible = true;
            panel_pwd.Visible = true;
            //panel_new.Style["visibility"] = "visible";
        }
        else
        {
            panel_op.Visible = true;
            panel_pwd.Visible = false;
            //将基本信息显示出来
            String sql = "select * from Users where UserId = " + Request.QueryString["u_id"];
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
            {
                DataRowView drv = ds.Tables[0].DefaultView[0];
                txtLoginName.Text = drv["LoginName"].ToString();
                txtName.Text = drv["UserName"].ToString();
                ddlSex.SelectedIndex = drv["UserSex"].ToString().Equals("0") ? 0 : 1;
                if (drv["BirthDate"].ToString().Length > 0)
                    txtBirthDate.Text = Convert.ToDateTime(drv["BirthDate"]).ToLongDateString();
                txtPhone.Text = drv["UserPhone"].ToString();
                hfOld.Value = drv["LoginPassWord"].ToString();
                txtMobileTelephone.Text = drv["MobileTelephone"].ToString();
                txtEmail.Text = drv["UserEmail"].ToString();
            }
        }
    }

    /// <summary>
    /// 提交修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "Update Users set LoginName=@loginname,UserName=@username,UserSex=@usersex,BirthDate=@birthdate,UserPhone=@userphone,MobileTelephone=@mobilephone,UserEmail=@useremail where UserId = " + Request.QueryString["u_id"];
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                   DBConnect.MakeParameter("@username", txtName.Text),
                                   DBConnect.MakeParameter("@birthdate", Convert.ToDateTime(txtBirthDate.Text)),
                                   DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                   DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                   DBConnect.MakeParameter("@mobilephone", txtMobileTelephone.Text),
                                   DBConnect.MakeParameter("@useremail", txtEmail.Text)
                               };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('信息修改成功！');window.history.go(-2);</script>");
    }

    /// <summary>
    /// 显示修改密码Panel
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

        String password = txtPanelPassword.Text;
        if (password.Equals(txtPanelRepeatPassword.Text))
        {
            if (!password.Equals(hfOld.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('旧密码输入错误');</script>");
                return;
            }
            String sql = "update Users set LoginPassWord = @password where UserId = " + Request.QueryString["u_id"];
            SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@password", password)
                               };
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, paras);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改成功');</script>");
            panelUpdatePassword.Visible = false;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('两次密码不一致');</script>");
        }
    }

    /// <summary>
    /// 关闭修改密码的Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPasswordClose_Click(object sender, ImageClickEventArgs e)
    {
        panelUpdatePassword.Visible = false;
    }

    /// <summary>
    /// 添加一个新导师
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "Insert into Users (LoginName,LoginPassWord,UserName,UserSex,BirthDate,UserPhone,MobileTelephone,UserEmail,UserType,StateId) values (@loginname,@loginpassword,@username,@usersex,@birthdate,@userphone,@mobilephone,@useremail,2,1)";
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                   DBConnect.MakeParameter("@loginpassword", txtPassword.Text),
                                   DBConnect.MakeParameter("@username", txtName.Text),
                                   DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                   DBConnect.MakeParameter("@birthdate", txtBirthDate.Text),
                                   DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                   DBConnect.MakeParameter("@mobilephone", txtMobileTelephone.Text),
                                   DBConnect.MakeParameter("@useremail", txtEmail.Text)
                               };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('添加导师成功！点击确定跳至导师列表！');window.location.href='nTeacherList.aspx';</script>");
    }

    /// <summary>
    /// 返回导师列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.history.go(-2);</script>");
    }

    /// <summary>
    /// 返回导师列表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnBack2_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.history.go(-2);</script>");
    }
}
