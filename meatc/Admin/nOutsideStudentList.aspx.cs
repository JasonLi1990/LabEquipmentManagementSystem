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
using System.Drawing;

public partial class Admin_nOutsideStudentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindOutsideStudent();
    }

    private void BindOutsideStudent()
    {
        String sql = "select * from Users left join State on Users.StateId = State.StateId where UserType = 0 or UserType = 5 order by Users.StateId desc";
        DBConnect db = new DBConnect();
        //GVTeacher.DataSource = db.GetDataSet(sql, null);
        //GVTeacher.DataBind();
        gv_student.DataSource = db.GetDataSet(sql, null);
        gv_student.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (e.Row.Cells[2].Text.Equals("0"))
                e.Row.Cells[2].Text = "校外用户";
            else
            {
                e.Row.Cells[2].Text = "校内用户";
                e.Row.Cells[2].BackColor = Color.Brown;
            }
            e.Row.Cells[3].Text = e.Row.Cells[3].Text.Equals("1") ? "男" : "女";
            if (e.Row.Cells[5].Text.Equals("注册用户") || e.Row.Cells[5].Text.Equals("未通过审批用户"))
            {
                e.Row.Cells[6].Text = "";
                e.Row.Cells[5].ForeColor = Color.Green;
            }
        }
    }


    protected void gv_student_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_student.PageIndex = e.NewPageIndex;
        BindOutsideStudent();
    }
    protected void gv_student_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sql = "";
        DBConnect db = new DBConnect();
        if (e.CommandName == "UserOK")  //通过审批
        {
            sql = "update Users set StateId = 1 where UserId = " + e.CommandArgument;
            db.ExecuteSql(sql, null);
        }
        else if (e.CommandName == "UserNO")
        {
            sql = "update Users set StateId = 3 where UserId = " + e.CommandArgument;
            db.ExecuteSql(sql, null);
        }
        else if (e.CommandName == "UserDel")
        {
            sql = "delete from Users where UserId = " + e.CommandArgument;
            db.ExecuteSql(sql, null);
        }
        else if (e.CommandName == "ShowUser")
        {
            Response.Redirect("nEditStudent.aspx?u_id=" + e.CommandArgument);
        }


        BindOutsideStudent();
    }
    protected void ImgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "select * from Users left join State on Users.StateId = State.StateId where (UserType = 0 or UserType = 5) ";
        if (!ddlShenPiState.SelectedItem.Value.Equals("0"))
        {
            sql += " and Users.StateId = " + ddlShenPiState.SelectedItem.Value;
        }
        if (ddlNameType.SelectedItem.Value.Equals("0")) //登录名
        {
            sql += " and Users.LoginName like '%" + txtNameText.Text.Trim() + "%'";
        }
        else
        {
            sql += " and Users.UserName like '%" + txtNameText.Text.Trim() + "%'";
        }

        sql += " order by Users.StateId desc";
        
        DBConnect db = new DBConnect();
        //GVTeacher.DataSource = db.GetDataSet(sql, null);
        //GVTeacher.DataBind();
        gv_student.DataSource = db.GetDataSet(sql, null);
        gv_student.DataBind();
    }
}
