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

public partial class Admin_nTeacherShow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindTeacherAndHisStudent();
    }

    /// <summary>
    /// 绑定导师和他的学生列表
    /// </summary>
    private void BindTeacherAndHisStudent()
    {
        String UserId = Request.QueryString["u_id"];
        String sql = "select * from Users where UserId = " + UserId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lblName.Text = drv["UserName"].ToString();
            lblSex.Text = drv["UserSex"].ToString().Equals("1") ? "男" : "女";
            if (drv["BirthDate"].ToString().Length > 0)
                lblBirthDate.Text = Convert.ToDateTime(drv["BirthDate"]).ToLongDateString();
            lblPhone.Text = drv["UserPhone"].ToString();
            lblMobileTelephone.Text = drv["MobileTelephone"].ToString();
            lblEmail.Text = drv["UserEmail"].ToString();
        }


        ///显示该老师所指导的学生列表
        sql = "select * from UserRelationship left join Users on UserRelationship.CUserId = Users.UserId where PUserId = " + UserId;
        GVSchoolList.DataSource = db.GetDataSet(sql, null);
        GVSchoolList.DataBind();
    }
    protected void GVSchoolList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text.Equals("1"))
            {
                e.Row.Cells[2].Text = "男";
            }
            else
            {
                e.Row.Cells[2].Text = "女";
            }
        }
    }
    protected void GVSchoolList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVSchoolList.PageIndex = e.NewPageIndex;
        BindTeacherAndHisStudent();
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        //Response.Redirect("nTeacherList.aspx");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.history.go(-2);</script>");
    }
}
