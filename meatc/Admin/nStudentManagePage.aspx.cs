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

public partial class Admin_nStudentManagePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindStudent();
        }
    }

    public void BindStudent()
    {
        String sql = "select * from Users where userType = 1 order by UserId desc";
        DBConnect db = new DBConnect();
        gv_student.DataSource = db.GetDataSet(sql, null);
        gv_student.DataKeyNames = new String[] { "UserId" };
        gv_student.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < gv_student.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        ddl_page.SelectedIndex = gv_student.PageIndex;
    }
    protected void gv_student_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_student.PageIndex = e.NewPageIndex;
        BindStudent();
    }

    /// <summary>
    /// 绑定导师、学生性别等信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_student_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            ((LinkButton)e.Row.Cells[6].Controls[0]).Attributes.Add("onclick", "return confirm('确认该学生信息删除吗？')");
            if (e.Row.Cells[2].Text == "1")
                e.Row.Cells[2].Text = "男";
            else
            {
                e.Row.Cells[2].Text = "女";
            }
            String sql = "select UserId,UserName from Users left join UserRelationship on Users.UserId = UserRelationship.PUserId where CUserId = " + gv_student.DataKeys[e.Row.RowIndex].Value;
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
                e.Row.Cells[4].Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
            else
            {
                e.Row.Cells[4].Text = "未指定";
                e.Row.Cells[4].BackColor = Color.Red;
            }
        }
    }
    protected void gv_student_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String sql = "delete from Users where UserId = " + gv_student.DataKeys[e.RowIndex].Value;
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        BindStudent();
    }

    /// <summary>
    /// 录入一个新同学
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nEditStudent.aspx");
    }

    protected void first_Click(object sender, EventArgs e)
    {
        gv_student.PageIndex = 0;
        BindStudent();
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (gv_student.PageIndex >= 1)
        {
            gv_student.PageIndex = gv_student.PageIndex - 1;
            BindStudent();
        }
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (gv_student.PageIndex < gv_student.PageCount - 1)
        {
            gv_student.PageIndex = gv_student.PageIndex + 1;
            BindStudent();
        }
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        gv_student.PageIndex = gv_student.PageCount - 1;
        BindStudent();
    }
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_student.PageIndex = ddl_page.SelectedIndex;
        BindStudent();
    }

    protected void bt_search_Click(object sender, EventArgs e)
    {
        String sql = "select * from Users where UserType = 1 and UserName like '%" + tb_teaName.Text.Trim() + "%' order by UserId desc";
        if (ddl_searchType.SelectedItem.Value.Equals("2"))  //按学号
        {
            sql = "select * from Users where UserType = 1 and LoginName like '%" + tb_teaName.Text.Trim() + "%' order by UserId desc";
        }
        
        DBConnect db = new DBConnect();
        gv_student.DataSource = db.GetDataSet(sql, null);
        gv_student.DataBind();
    }
}
