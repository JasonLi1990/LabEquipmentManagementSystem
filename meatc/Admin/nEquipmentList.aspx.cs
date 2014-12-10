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

public partial class Admin_nEquipmentList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
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
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId order by EquipmentId desc";
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

    public void BindEquipmentTypeList()
    {
        String sql = "select * from EquipmentType order by EquipmentTypeId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        ddlEquipmentType.DataSource = ds;
        ddlEquipmentType.DataBind();
        ddlEquipmentType.Items.Insert(0, new ListItem("全部", "0"));
    }

    protected void gv_Equipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_Equipment.PageIndex = e.NewPageIndex;
        BindEquipmentList();
    }
    protected void gv_Equipment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EquipmentUpdate")
        {
            Response.Redirect("nAddEquipment.aspx?e_id=" + e.CommandArgument);
        }
        else if (e.CommandName == "EquipmentDel")
        {
            String sql = "delete from Equipment where EquipmentId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindEquipmentList();
        }
    }


    protected void gv_Equipment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (((HiddenField)(e.Row.Cells[0].FindControl("HFIsCheck"))).Value == "1")
            {
                ((CheckBox)e.Row.Cells[0].FindControl("CBoxIsCheck")).Checked = true;
            }
        }
    }

    /// <summary>
    /// 保存选择好的设备
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSaveIsCheck_Click(object sender, ImageClickEventArgs e)
    {
        DBConnect db = new DBConnect();
        String sql = "";
        for (int i = 0; i < gv_Equipment.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gv_Equipment.Rows[i].Cells[0].FindControl("CBoxIsCheck");
            if (cb.Checked)
            {
                sql = "update Equipment set IsCheck = 1 where EquipmentId = " + gv_Equipment.DataKeys[i].Value;
            }
            else
                sql = "update Equipment set IsCheck = 0 where EquipmentId = " + gv_Equipment.DataKeys[i].Value;
            db.ExecuteSql(sql, null);
        }
        BindEquipmentList();
    }
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Admin/nAddEquipment.aspx");
    }
    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId where EquipmentId <> 0 ";
        if (!ddlEquipmentType.SelectedItem.Value.Equals("0"))
        {
            sql += " and Equipment.EquipmentTypeId = " + ddlEquipmentType.SelectedItem.Value;
        }
        if(!ddlEquipmentState.SelectedItem.Value.Equals("0"))
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
    protected void cb_selectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_selectAll.Checked)
        {
            for (int i = 0; i < gv_Equipment.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gv_Equipment.Rows[i].Cells[0].FindControl("CBoxIsCheck");
                cb.Checked = true;
            }
        }
        else
        {
            for (int i = 0; i < gv_Equipment.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)gv_Equipment.Rows[i].Cells[0].FindControl("CBoxIsCheck");
                cb.Checked = false;
            }
        }
    }
}
