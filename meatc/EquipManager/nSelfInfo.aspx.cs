﻿using System;
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

public partial class EquipManager_nSelfInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.CheckSession(this.Page);
            BindEquipManagerInfo();
        }
    }



    /// <summary>
    /// 绑定学生的信息
    /// </summary>
    public void BindEquipManagerInfo()
    {
        String u_id = Session["UserId"].ToString();
        String sql = "select * from Users where UserId = " + u_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            txtLoginName.Text = ds.Tables[0].DefaultView[0]["LoginName"].ToString();
            txtName.Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
            if (ds.Tables[0].DefaultView[0]["UserSex"].ToString().Equals("1"))
                ddlSex.SelectedIndex = 1;
            else
                ddlSex.SelectedIndex = 0;
            txtBirthDate.Text = Convert.ToDateTime(ds.Tables[0].DefaultView[0]["BirthDate"]).ToLongDateString();
            txtPhone.Text = ds.Tables[0].DefaultView[0]["UserPhone"].ToString();
            txtMobileTelephone.Text = ds.Tables[0].DefaultView[0]["MobileTelephone"].ToString();
            txtEmail.Text = ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
        }
    }


    /// <summary>
    /// 修改密码功能
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEditPassword_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String oldPwd = tb_oldPwd.Text;
        String newPwd = tb_newPwd.Text;
        String makesure = tb_makesure.Text;
        if (!newPwd.Equals(makesure))
        {
            Response.Write("<script>alert('两次新密码输入不一致！');window.location.href='nSelfInfo.aspx';</script>");
            return;
        }

        String sql = "select LoginPassWord from Users where UserId = " + UserId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            String oldReal = ds.Tables[0].DefaultView[0]["LoginPassWord"].ToString();
            if (!oldReal.Equals(oldPwd))
            {
                Response.Write("<script>alert('旧密码输入错误！');window.location.href='nSelfInfo.aspx';</script>");
                return;
            }

            sql = "update Users set LoginPassWord = @newPwd where UserId = " + UserId;
            SqlParameter[] paras = { 
                                       DBConnect.MakeParameter("@newPwd", newPwd)
                                   };
            db.ExecuteSql(sql, paras);
            Response.Write("<script>alert('密码修改成功！');window.location.href='nSelfInfo.aspx';</script>");
        }
        panel_pwd.Visible = false;
    }

    /// <summary>
    /// 修改基本信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String sql = "";
        DBConnect db = new DBConnect();
        sql = "update Users set LoginName = @loginname, UserName = @username, UserSex = @usersex, BirthDate = '" + Convert.ToDateTime(txtBirthDate.Text) + "', UserPhone = @userphone, MobileTelephone = @telphone, UserEmail = @useremail where UserId = " + UserId;
        String sex = "0";
        if (ddlSex.SelectedItem.Value == "1")
            sex = "1";
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                   DBConnect.MakeParameter("@username", txtName.Text),                                   
                                   DBConnect.MakeParameter("@usersex", sex),
                                   DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                   DBConnect.MakeParameter("@telphone",txtMobileTelephone.Text),
                                   DBConnect.MakeParameter("@useremail", txtEmail.Text)
                               };
        db.ExecuteSql(sql, paras);


        Response.Write("<script>alert('个人基本信息修改成功');window.location.href='nSelfInfo.aspx';</script>");
    }

    /// <summary>
    /// 返回首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {

        Response.Redirect("nEquipManagerHome.aspx");
    }

    protected void imgBtnPasswordClose_Click(object sender, ImageClickEventArgs e)
    {
        panel_pwd.Visible = false;
    }
    protected void bt_showpanel_Click(object sender, ImageClickEventArgs e)
    {
        panel_pwd.Visible = true;
    }
}
