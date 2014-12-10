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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RequiredFieldValidator1.Enabled = false;
        }
    }

    /// <summary>
    /// 切换不同用户
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtLoginName.Text = "";
        if (ddlUserType.SelectedItem.Value == "1")  //本院学生
        {
            txtName.Enabled = false;            
            ddlSex.Enabled = false;
            lb_schoolNo.Text = "您的学号";
            imgBtnCheckUser.Visible = true;
            lblNameInfo.Visible = false;
            txtLoginName.Enabled = true;
            RequiredFieldValidator1.Enabled = true;
        }
        else if(ddlUserType.SelectedItem.Value == "5")//本校学生
        {
            txtName.Enabled = true;
            ddlSex.Enabled = true;
            lb_schoolNo.Text = "您的学号";
            imgBtnCheckUser.Visible = true;
            lblNameInfo.Visible = false;
            txtLoginName.Enabled = true;
            RequiredFieldValidator1.Enabled = true;
        }
        else//校外用户
        {
            RequiredFieldValidator1.Enabled = false;
            lb_schoolNo.Text = "登录账号";
            txtName.Enabled = true;
            ddlSex.Enabled = true;
            imgBtnCheckUser.Visible = false;
            lblNameInfo.Visible = true;
            lblNameInfo.Text = "用户名将在创建成功后获得，请注意“添加”后的弹出信息。";
            txtLoginName.Enabled = false;
        }
    }


    /// <summary>
    /// 提交注册
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        String loginName = txtLoginName.Text.Trim();
        String password = txtPassword.Text;
        String usertype = ddlUserType.SelectedItem.Value;
        String username = txtName.Text.Trim();
        String usersex = ddlSex.SelectedItem.Value;
        String birthdate = txtBirthDate.Text;
        String phone = txtPhone.Text.Trim();
        String mobile = txtMobileTelephone.Text.Trim();
        String email = txtEmail.Text.Trim();
        String workplace = txtBureau.Text.Trim();
        String zhicheng = txtUserPost.Text.Trim();
        String notes = txtResearch.Text.Trim();
        int stateid = 1;
        DBConnect db = new DBConnect();
        if (ddlUserType.SelectedItem.Value.Equals("0"))
        {
            String getLoginId = "select top 1 LoginName from Users where UserType = 0 order by UserId desc";
            String MaxUserLoginName = db.GetDataSet(getLoginId, null).Tables[0].DefaultView[0]["LoginName"].ToString();
            
            int nextid = Convert.ToInt32(MaxUserLoginName.Substring(1)) + 1;
            loginName = "U" + nextid;            
            stateid = 2;    //待审批用户            
        }
        else if (ddlUserType.SelectedItem.Value.Equals("5"))
        {
            stateid = 2;
            String checkSql = "select * from Users where LoginName = @loginname";
            SqlParameter[] parascheck = { 
                                        DBConnect.MakeParameter("@loginname", loginName)
                                    };            
            if (db.GetDataSet(checkSql, parascheck) != null)    //已经有这个学生了
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('这个学号已经注册了哦！');</script>");
                return;
            }            
        }


        String sql = "insert into Users (LoginName,LoginPassWord,UserName,UserSex,BirthDate,UserPhone,MobileTelephone,UserEmail,UserType,UserApprovalInfo,OutSchoolBureau,UserPost,StateId) values (@loginname,@password,@username,@usersex,@birthdate,@userphone,@mobile,@email,@usertype,@approvalinfo,@outschool,@userpost,@stateid)";
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@loginname", loginName),
                                   DBConnect.MakeParameter("@password", password),
                                   DBConnect.MakeParameter("@username", username),
                                   DBConnect.MakeParameter("@usersex", usersex),
                                   DBConnect.MakeParameter("@birthdate", birthdate),
                                   DBConnect.MakeParameter("@userphone", phone),
                                   DBConnect.MakeParameter("@mobile", mobile),
                                   DBConnect.MakeParameter("@email", email),
                                   DBConnect.MakeParameter("@usertype", ddlUserType.SelectedItem.Value),
                                   DBConnect.MakeParameter("@approvalinfo", notes),
                                   DBConnect.MakeParameter("@outschool", workplace),
                                   DBConnect.MakeParameter("@userpost", zhicheng),
                                   DBConnect.MakeParameter("@stateid", stateid)
                               };
       // Response.Write(sql);
        db.ExecuteSql(sql, paras);
        //Response.Write(sql);
        //return;
        if (ddlUserType.SelectedItem.Value.Equals("0"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的登录账号为:" + loginName + ",请牢记！');window.location.href='RegisterResult.aspx';</script>");
        }
        else if (ddlUserType.SelectedItem.Value.Equals("5"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功，点击确定返回登录页面！');window.location.href='nindex.aspx';</script>");
        }
        else    //本院学生
        {
            String tsql = "select * from Users where UserName in (select Tearther from SchoolInfo where SchoolNo = '" + loginName + "')";
            if (db.GetDataSet(tsql, null) == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功，但数据库中不存在您的导师信息，请登录后修改！');window.location.href='nindex.aspx';</script>");
            }
            else
            {
                DataSet tds = db.GetDataSet(tsql,null);
                String TeacherId = tds.Tables[0].DefaultView[0]["UserId"].ToString();
                String TeacherName = tds.Tables[0].DefaultView[0]["UserName"].ToString();
                String getMyId = "select UserId from Users where LoginName = '" + loginName + "'";
                //Response.Write(getMyId);
                String MyId = db.GetDataSet(getMyId, null).Tables[0].DefaultView[0]["UserId"].ToString();
                String relationSql = "insert into UserRelationship (UserRelationshipName, PUserId, CUserId,StateId) values ('师生关系',"+ TeacherId +","+MyId+",31)";
                //Response.Write(relationSql);
                db.ExecuteSql(relationSql, null);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册成功，您的导师为:" + TeacherName + "，登录后可修改！');window.location.href='nindex.aspx';</script>");
            }

        }
    }


    /// <summary>
    /// 检查用户名，如果是校内用户，则初始化好姓名等信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnCheckUser_Click(object sender, ImageClickEventArgs e)
    {
        String LoginName = txtLoginName.Text;
        if (ddlUserType.SelectedItem.Value.Equals("1"))
        {
            String checkSql = "select * from Users where LoginName = @loginname";
            String checkStudent = "select * from SchoolInfo where SchoolNo =  @loginname";
            SqlParameter[] parascheck = { 
                                        DBConnect.MakeParameter("@loginname", LoginName)
                                    };
            SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@loginname", LoginName)
                               };
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(checkStudent, parascheck);
            if (ds == null)
            {
                lblNameInfo.Text = "对不起，数据库中不存在该学生信息！";
                lblNameInfo.Visible = true;
                return;
            }

            DBConnect ndb = new DBConnect();
            if (ndb.GetDataSet(checkSql, paras) == null)  //是学生，但未注册到系统中
            {
                lblNameInfo.Text = "恭喜您，该学号尚未注册！";
                lblNameInfo.Visible = true;
                DataRowView drv = ds.Tables[0].DefaultView[0];
                txtName.Text = drv["SchoolName"].ToString().Trim();
                ddlSex.SelectedValue = drv["SchoolSex"].ToString();
                // txtBirthDate.Text = Convert.ToDateTime(drv["SchooBirthDate"]).ToLongDateString();
                txtMobileTelephone.Text = drv["MobileTelephone"].ToString().Trim();
                txtEmail.Text = drv["SchoolEmail"].ToString().Trim();
            }
            else//已经注册
            {
                lblNameInfo.Text = "该学号已经注册到系统中";
                txtName.Text = "";
                txtPhone.Text = "";
                txtMobileTelephone.Text = "";
                txtEmail.Text = "";
                lblNameInfo.Visible = true;
                return;
            }
        }
        else if (ddlUserType.SelectedItem.Value.Equals("5"))
        {
            String checkSql = "select * from Users where LoginName = @loginname";
            SqlParameter[] parascheck = { 
                                        DBConnect.MakeParameter("@loginname", LoginName)
                                    };
            DBConnect db = new DBConnect();
            if (db.GetDataSet(checkSql, parascheck) != null)    //已经有这个学生了
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('这个学号已经注册了哦！');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('这个学号可以使用！');</script>");
            }

        }
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/nindex.aspx");
    }
}
