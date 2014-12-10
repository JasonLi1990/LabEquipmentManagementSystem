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

public partial class Admin_nEquipManagerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindEquipManagerList();
    }

    /// <summary>
    /// 绑定设备管理员列表
    /// </summary>
    public void BindEquipManagerList()
    {
        String sql = "select * from Users where UserType = 3 order by UserId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            gv_equipManager.DataSource = ds;
            gv_equipManager.DataBind();
        }
    }
    protected void gv_equipManager_RowDataBound(object sender, GridViewRowEventArgs e)
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
    protected void gv_equipManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_equipManager.PageIndex = e.NewPageIndex;
        BindEquipManagerList();
    }
    // 2014.03.02 解决删除设备管理员功能不好用问题 --by lgq
    protected void gv_equipManager_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        String sql = "delete from Users where UserType = '3' and LoginName = '" + gv_equipManager.Rows[e.RowIndex].Cells[0].Text.ToString()+"'";
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql,null);
        BindEquipManagerList();
    }
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nAddNewManager.aspx");
    }
}
