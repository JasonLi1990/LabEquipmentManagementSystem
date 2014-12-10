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

public partial class Student_MyInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.CheckSession(this.Page);
            if (Session["UserType"].ToString().Equals("0") || Session["UserType"].ToString().Equals("5")) //外校及本校学生不用显示导师列表，只有本院学生显示
            {
                panel_school.Visible = false;
                panel_outside.Visible = true;
            }
            else
            {
                BindTeacherList();
                BindRelation();
            }
            BindStudentInfo();
        }
    }

    /// <summary>
    /// 绑定导师列表，以供修改
    /// </summary>
    public void BindTeacherList()
    {
        String sql = "select * from Users where UserType = 2";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        ddl_teacher.DataSource = ds;

        ddl_teacher.DataBind();
        ddl_teacher.Items.Insert(0, new ListItem("请选择"));
    }

    /// <summary>
    /// 绑定学生的信息
    /// </summary>
    public void BindStudentInfo()
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
            if (Session["UserType"].ToString().Equals("0"))
            {
                tb_workplace.Text = ds.Tables[0].DefaultView[0]["OutSchoolBureau"].ToString();
                tb_zhicheng.Text = ds.Tables[0].DefaultView[0]["UserPost"].ToString();
                tb_notes.Text = ds.Tables[0].DefaultView[0]["UserApprovalInfo"].ToString();
            }
        }
    }

    /// <summary>
    /// 绑定学生与老师的对应关系 
    /// </summary>
    public void BindRelation()
    {
        String u_id = Session["UserId"].ToString();
        String sql = "select * from users where UserId in (select PUserId from UserRelationship where CUserId = " + u_id + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            ddl_teacher.SelectedValue = ds.Tables[0].DefaultView[0]["UserId"].ToString();
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
            Response.Write("<script>alert('两次新密码输入不一致！');window.location.href='MyInfo.aspx';</script>");
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
                Response.Write("<script>alert('旧密码输入错误！');window.location.href='MyInfo.aspx';</script>");
                return;
            }

            sql = "update Users set LoginPassWord = @newPwd where UserId = " + UserId;
            SqlParameter[] paras = { 
                                       DBConnect.MakeParameter("@newPwd", newPwd)
                                   };
            db.ExecuteSql(sql, paras);
            Response.Write("<script>alert('密码修改成功！');window.location.href='MyInfo.aspx';</script>");
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
        if (!Session["UserType"].ToString().Equals("0"))
        {
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
            //如果勾选了修改导师关系 

            String T_ID = ddl_teacher.SelectedItem.Value;
            String checkExistSql = "select * from UserRelationship where CUserId = " + UserId;

            String relationSql = "";
            if (db.GetDataSet(checkExistSql, null) != null)
                relationSql = "update UserRelationship set PUserId = " + T_ID + " where CUserId = " + UserId;
            else
                relationSql = "insert into UserRelationship (UserRelationshipName, PUserId, CUserId, StateId) values ('师生关系'," + T_ID + "," + UserId + ",31)";

            db.ExecuteSql(relationSql, null);
        }
        else
        {
            sql = "update Users set LoginName = @loginname, UserName = @username, UserSex = @usersex, BirthDate = '" + Convert.ToDateTime(txtBirthDate.Text) + "', UserPhone = @userphone, MobileTelephone = @telphone, UserEmail = @useremail,OutSchoolBureau=@workplace,UserPost=@zhicheng,UserApprovalInfo=@notes where UserId = " + UserId;
            String sex = "0";
            if (ddlSex.SelectedItem.Value == "1")
                sex = "1";
            SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", txtLoginName.Text),
                                   DBConnect.MakeParameter("@username", txtName.Text),                                   
                                   DBConnect.MakeParameter("@usersex", sex),
                                   DBConnect.MakeParameter("@userphone", txtPhone.Text),
                                   DBConnect.MakeParameter("@telphone",txtMobileTelephone.Text),
                                   DBConnect.MakeParameter("@useremail", txtEmail.Text),
                                   DBConnect.MakeParameter("@workplace", tb_workplace.Text),
                                   DBConnect.MakeParameter("@zhicheng", tb_zhicheng.Text),
                                   DBConnect.MakeParameter("@notes", tb_notes.Text)
                               };
            db.ExecuteSql(sql, paras);
        }

        Response.Write("<script>alert('个人基本信息修改成功');window.location.href='MyInfo.aspx';</script>");
    }

    /// <summary>
    /// 返回首页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["UserType"].ToString().Equals("2"))
            Response.Redirect("~/Teacher/TeacherDefault.aspx");
        Response.Redirect("Default.aspx");
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
