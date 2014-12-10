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

public partial class EquipManager_nMyEquipList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindEquipmentList();
            BindEquipmentTypeList();
        }
    }

    /// <summary>
    /// 绑定设备列表
    /// </summary>
    public void BindEquipmentList()
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join State on Equipment.StateId = State.StateId where UserId = " + UserId + " order by EquipmentId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        gv_Equipment.DataSource = ds;
        gv_Equipment.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < gv_Equipment.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        ddl_page.SelectedIndex = gv_Equipment.PageIndex;
    }
    protected void gv_Equipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Equipment.PageIndex = e.NewPageIndex;
        BindEquipmentList();
    }

    public void BindEquipmentTypeList()
    {
        String sql = "select * from EquipmentType order by EquipmentTypeId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        ddlEquipmentType.DataSource = ds;
        ddlEquipmentType.DataBind();
        ddlEquipmentType.Items.Insert(0, new ListItem("全部", "0"));
    }

    /// <summary>
    /// 修改设备状态
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gv_Equipment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sql = "update Equipment set StateId = ";
        int state = 0;
        switch (e.CommandName)
        {
            case "EquipmentZhengChang":
                state = 21;
                break;
            case "EquipmentSunHuai":
                state = 22;
                break;
            case "EquipmentWeiXiu":
                state = 23;
                break;
            case "EquipmentBaoFei":
                state = 24;
                break;
        }

        sql += state;
        sql += " where EquipmentId = " + e.CommandArgument.ToString();
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设备状态修改成功！');window.location.href='nMyEquipList.aspx';</script>");
    }

    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join State on Equipment.StateId = State.StateId where UserId = " + UserId;

        if (!ddlEquipmentType.SelectedItem.Value.Equals("0"))
        {
            sql += " and Equipment.EquipmentTypeId = " + ddlEquipmentType.SelectedItem.Value;
        }
        if (!ddlEquipmentState.SelectedItem.Value.Equals("0"))
            sql += " and Equipment.StateId = " + ddlEquipmentState.SelectedItem.Value;
        sql += " and EquipmentName like '%" + tb_teaName.Text.Trim() + "%'";
        sql += " order by EquipmentId";
        //Response.Write(sql);
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        gv_Equipment.DataSource = ds;
        gv_Equipment.DataBind();
    }

    protected void first_Click(object sender, EventArgs e)
    {
        gv_Equipment.PageIndex = 0;
        BindEquipmentList();
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (gv_Equipment.PageIndex >= 1)
        {
            gv_Equipment.PageIndex = gv_Equipment.PageIndex - 1;
            BindEquipmentList();
        }
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (gv_Equipment.PageIndex < gv_Equipment.PageCount - 1)
        {
            gv_Equipment.PageIndex = gv_Equipment.PageIndex + 1;
            BindEquipmentList();
        }
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        gv_Equipment.PageIndex = gv_Equipment.PageCount - 1;
        BindEquipmentList();
    }
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        gv_Equipment.PageIndex = ddl_page.SelectedIndex;
        BindEquipmentList();
    }
    protected void bt_change_Click(object sender, EventArgs e)
    {
        String sql = "update Equipment set IsZhouMoOpen = 1 where UserId = " + Session["UserId"].ToString();
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功，周六周日正常工作！');</script>");
    }
    protected void bt_sleep_Click(object sender, EventArgs e)
    {
        String sql = "update Equipment set IsZhouMoOpen = 0 where UserId = " + Session["UserId"].ToString();
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功，周六周日不工作！');</script>");
    }
}
