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

public partial class Admin_nAddNewManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindBasicInfo();
    }

    /// <summary>
    /// 绑定基本信息，区别编辑和添加管理员
    /// </summary>
    private void BindBasicInfo()
    {
        if (Request.QueryString["u_id"] != null)    //表示修改用户
        {
            panel_new.Visible = false;
            String sql = "select * from Users where UserId = " + Request.QueryString["u_id"];
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
            {
                DataRowView drv = ds.Tables[0].DefaultView[0];
                txtLoginName.Text = drv["LoginName"].ToString();
                txtName.Text = drv["UserName"].ToString();
                ddlSex.SelectedIndex = Convert.ToInt32(drv["UserSex"]);
                if (drv["BirthDate"].ToString().Length > 0)
                    txtBirthDate.Text = Convert.ToDateTime(drv["BirthDate"]).ToLongDateString();
                txtPhone.Text = drv["UserPhone"].ToString();
                txtMobileTelephone.Text = drv["MobileTelephone"].ToString();
                txtEmail.Text = drv["UserEmail"].ToString();
            }

            sql = "select * from Equipment left join State on Equipment.stateId = State.StateId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId where Equipment.UserId = " + Request.QueryString["u_id"];
            GVEquipmentList.DataSource = db.GetDataSet(sql, null);
            GVEquipmentList.DataBind();
        }
        else
        {
            imgBtnEditPassword.Visible = false;
            imgBtnEdit.ImageUrl = "~/Images/BtnAdd.png";
        }
    }

    /// <summary>
    /// 保存更改（添加及修改）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        DBConnect db = new DBConnect();
        if (Request.QueryString["u_id"] != null)    //修改功能提交
        {
            String sql = "update Users set LoginName=@loginname,UserName=@username,UserSex=@usersex,BirthDate=@birthdate,UserPhone=@userphone,MobileTelephone=@mobile,UserEmail=@useremail where UserId = " + Request.QueryString["u_id"];
            SqlParameter[] paras = { 
                                    DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                    DBConnect.MakeParameter("@username", txtName.Text),
                                    DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                    DBConnect.MakeParameter("@birthdate", Convert.ToDateTime(txtBirthDate.Text)),
                                    DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                    DBConnect.MakeParameter("@mobile", txtMobileTelephone.Text),
                                    DBConnect.MakeParameter("@useremail", txtEmail.Text)
                                };
            db.ExecuteSql(sql, paras);
            Response.Write("<script>alert('信息修改成功！');window.location.href='nEquipManagerList.aspx';</script>");

        }
        else //表示添加新管理员功能
        {
            //2014.03.02新增判断用户名是否存在---by lgq
            Boolean flag = true;
            String sql_getEM = "select * from Users where UserType = 3 order by UserId";
            DataSet dscompare = db.GetDataSet(sql_getEM, null);
            foreach (DataRow dr in dscompare.Tables[0].Rows)
            {
                if (dr["LoginName"].ToString().Equals(txtLoginName.Text))
                {
                    flag = false;
                    Response.Write("<script>alert('此设备管理员用户名已存在！');window.location.href='nEquipManagerList.aspx';</script>");
                }
            }
            if(flag)
            {
                String sql = "insert into Users (LoginName,LoginPassWord,UserName,UserSex,BirthDate,UserPhone,MobileTelephone,UserEmail,UserType,StateId) values (@loginname,@loginpassword,@username,@usersex,@birthdate,@userphone,@mobile,@useremail,3,1)";
                SqlParameter[] paras = { 
                                       DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                       DBConnect.MakeParameter("@loginpassword", txtPassword.Text),
                                       DBConnect.MakeParameter("@username", txtName.Text),
                                       DBConnect.MakeParameter("@usersex", ddlSex.SelectedItem.Value),
                                       DBConnect.MakeParameter("@birthdate", Convert.ToDateTime(txtBirthDate.Text)),
                                       DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                       DBConnect.MakeParameter("@mobile", txtMobileTelephone.Text),
                                       DBConnect.MakeParameter("@useremail", txtEmail.Text)
                                   };
                db.ExecuteSql(sql, paras);
                Response.Write("<script>alert('设备管理员添加成功！');window.location.href='nEquipManagerList.aspx';</script>");
            }
        }
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEditPassword_Click(object sender, ImageClickEventArgs e)
    {
        panelUpdatePassword.Visible = true;
    }

    /// <summary>
    /// 修改设备管理员密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPasswordOK_Click(object sender, ImageClickEventArgs e)
    {
        if (!txtPanelPassword.Text.Equals(txtPanelRepeatPassword.Text)) //两次密码不一致
            return;
        String sql = "update Users set LoginPassWord = '" + txtPanelPassword.Text + "' where UserId = " + Request.QueryString["u_id"];
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('密码修改成功');</script>");
        panelUpdatePassword.Visible = false;
    }

    /// <summary>
    /// 返回管理员管理页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nEquipManagerList.aspx");
    }
    protected void GVEquipmentList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EquipDel")
        {
            String sql = "update Equipment set UserId = NULL where EquipmentId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
        }
    }
    protected void GVEquipmentList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVEquipmentList.PageIndex = e.NewPageIndex;
        BindBasicInfo();
    }

    /// <summary>
    /// 关闭修改密码Panel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnPasswordClose_Click(object sender, ImageClickEventArgs e)
    {
        panelUpdatePassword.Visible = false;
    }
}
