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

public partial class Admin_nTeacherList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindTeacherList();
    }

    /// <summary>
    /// 绑定导师列表
    /// </summary>
    private void BindTeacherList()
    {
        String sql = "select * from Users where UserType = 2 order by UserId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < GVTeacher.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        ddl_page.SelectedIndex = GVTeacher.PageIndex;
    }

    /// <summary>
    /// 导师列表分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVTeacher.PageIndex = e.NewPageIndex;
        BindTeacherList();
    }

    /// <summary>
    /// 对一些行内容的修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (e.Row.Cells[2].Text == "1")
                e.Row.Cells[2].Text = "男";
            else
            {
                e.Row.Cells[2].Text = "女";

            }
        }
    }

    /// <summary>
    /// 绑定一些执行命令
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowUser")
        {
            Response.Redirect("nTeacherShow.aspx?u_id=" + e.CommandArgument);
        }
        else if (e.CommandName == "UserUpdate")
        {
            Response.Redirect("nTeacherEdit.aspx?u_id=" + e.CommandArgument);
        }
        else if (e.CommandName == "UserDel")
        {
            String sql = "delete from Users where UserId = " + e.CommandArgument.ToString();
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindTeacherList();
        }
    }
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nTeacherEdit.aspx");
    }
    protected void bt_search_Click(object sender, EventArgs e)
    {
        String sql = "select * from Users where UserType = 2 and UserName like '%" + tb_teaName.Text.Trim() + "%' order by UserId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
    }
    protected void imgTitle_Click(object sender, ImageClickEventArgs e)
    {
        BindTeacherList();
    }
    protected void first_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = 0;
        BindTeacherList();
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex >= 1)         
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex - 1;
            BindTeacherList();
        }
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex < GVTeacher.PageCount - 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex + 1;
            BindTeacherList();
        }
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = GVTeacher.PageCount - 1;
        BindTeacherList();
}
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = ddl_page.SelectedIndex;
        BindTeacherList();
    }
}
