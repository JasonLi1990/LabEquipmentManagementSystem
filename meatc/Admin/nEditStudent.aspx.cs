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

public partial class Admin_nEditStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindTeacherList();
            if (Request.QueryString["u_id"] != null)
            {
                BindStudentInfo();
                BindRelation();
            }
            else
            {
                panel_pwd.Visible = true;
                panel_modify.Visible = false;
                bt_submit.Text = "录入新学生";
            }
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
    }

    public void BindStudentInfo()
    {
        String u_id = Request.QueryString["u_id"];
        String sql = "select * from Users where UserId = " + u_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            LoginName.Text = ds.Tables[0].DefaultView[0]["LoginName"].ToString();
            UserName.Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
            if (ds.Tables[0].DefaultView[0]["UserSex"].ToString().Equals("1"))
                boy.Checked = true;
            else
                girl.Checked = true;
            if (ds.Tables[0].DefaultView[0]["BirthDate"].ToString().Length > 0)
                txtBirthDate.Text = Convert.ToDateTime(ds.Tables[0].DefaultView[0]["BirthDate"]).ToLongDateString();
            tb_telphone.Text = ds.Tables[0].DefaultView[0]["UserPhone"].ToString();
            tb_cellphone.Text = ds.Tables[0].DefaultView[0]["MobileTelephone"].ToString();
            tb_email.Text = ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
        }
    }

    /// <summary>
    /// 绑定学生与老师的对应关系 
    /// </summary>
    public void BindRelation()
    {
        String u_id = Request.QueryString["u_id"];
        String sql = "select * from users where UserId in (select PUserId from UserRelationship where CUserId = " + u_id + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            ddl_teacher.SelectedValue = ds.Tables[0].DefaultView[0]["UserId"].ToString();
        }
        else
        {
            ddl_teacher.Text = "...";
        }
    }

    /// <summary>
    /// 保存修改的信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_submit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["u_id"] != null)
        {
            String sql = "update Users set LoginName = @loginname, UserName = @username, UserSex = @usersex, BirthDate = '" + Convert.ToDateTime(txtBirthDate.Text) + "', UserPhone = @userphone, MobileTelephone = @telphone, UserEmail = @useremail where UserId = " + Request.QueryString["u_id"];
            String sex = "0";
            if (boy.Checked)
                sex = "1";
            SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", LoginName.Text),
                                   DBConnect.MakeParameter("@username", UserName.Text),                                   
                                   DBConnect.MakeParameter("@usersex", sex),
                                   DBConnect.MakeParameter("@userphone", tb_telphone.Text),
                                   DBConnect.MakeParameter("@telphone",tb_cellphone.Text),
                                   DBConnect.MakeParameter("@useremail", tb_email.Text)
                               };
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, paras);
            //如果勾选了修改密码，则同时更新密码
            if (cb_password.Checked)
            {
                sql = "update Users set LoginPassWord = '" + tb_password.Text + "' where UserId = " + Request.QueryString["u_id"];
                db.ExecuteSql(sql, null);
            }
            //如果勾选了修改导师关系 
            if (cb_teacher.Checked)
            {
                String T_ID = ddl_teacher.SelectedItem.Value;
                String checkExistSql = "select * from UserRelationship where CUserId = " + Request.QueryString["u_id"];

                String relationSql = "";
                if (db.GetDataSet(checkExistSql, null) != null)
                    relationSql = "update UserRelationship set PUserId = " + T_ID + " where CUserId = " + Request.QueryString["u_id"];
                else
                    relationSql = "insert into UserRelationship (UserRelationshipName, PUserId, CUserId, StateId) values ('师生关系'," + T_ID + "," + Request.QueryString["u_id"] + ",31)";

                db.ExecuteSql(relationSql, null);
            }
            Response.Write("<script>alert('修改成功');window.history.go(-2);</script>");
        }
        else
        {
            String sql_insert = "Insert into Users (LoginName,UserName,UserSex,BirthDate,UserPhone,MobileTelephone,UserEmail,UserType,StateId) values (@loginname, @username, @usersex, @birthdate, @userphone, @telphone, @useremail , 1,1)";
            String sex = "0";
            if (boy.Checked)
                sex = "1";

            SqlParameter[] paras_insert = { 
                                   DBConnect.MakeParameter("@loginname", LoginName.Text),
                                   DBConnect.MakeParameter("@username", UserName.Text),                                   
                                   DBConnect.MakeParameter("@usersex", sex),
                                   DBConnect.MakeParameter("@birthdate", txtBirthDate.Text),
                                   DBConnect.MakeParameter("@userphone", tb_telphone.Text),
                                   DBConnect.MakeParameter("@telphone",tb_cellphone.Text),
                                   DBConnect.MakeParameter("@useremail", tb_email.Text)
                               };
            DBConnect db_insert = new DBConnect();
            db_insert.ExecuteSql(sql_insert, paras_insert);




            //如果勾选了修改导师关系 
            if (cb_teacher.Checked)
            {
                sql_insert = "select MAX(UserId) from Users";
                DataSet ds = db_insert.GetDataSet(sql_insert, null);
                String T_ID = ddl_teacher.SelectedItem.Value;
                String relationSql = "insert into UserRelationship (UserRelationshipName, PUserId, CUserId, StateId) values ('师生关系'," + T_ID + "," + ds.Tables[0].DefaultView[0][0] + ",31)";
                db_insert.ExecuteSql(relationSql, null);
            }

            Response.Write("<script>alert('添加学生成功');window.history.go(-2);</script>");
        }
    }
}
