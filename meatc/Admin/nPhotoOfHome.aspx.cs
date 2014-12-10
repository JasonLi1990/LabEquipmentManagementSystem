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

public partial class Admin_nPhotoOfHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindEquipmentList();
    }

    /// <summary>
    /// 绑定设备列表
    /// </summary>
    public void BindEquipmentList()
    {
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId order by EquipmentId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        gv_showEquip.DataSource = ds;
        gv_showEquip.DataBind();
    }
    protected void gv_showEquip_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (((HiddenField)(e.Row.Cells[0].FindControl("hf_ischeck"))).Value == "1")
            {
                ((CheckBox)e.Row.Cells[0].FindControl("CBoxIsCheck")).Checked = true;
            }
        }
    }
    protected void gv_showEquip_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_showEquip.PageIndex = e.NewPageIndex;
        BindEquipmentList();
    }
    protected void imgBtnSaveSelect_Click(object sender, ImageClickEventArgs e)
    {
        DBConnect db = new DBConnect();
        String sql = "";
        for (int i = 0; i < gv_showEquip.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)gv_showEquip.Rows[i].Cells[0].FindControl("CBoxIsCheck");
            if (cb.Checked)
            {
                sql = "update Equipment set IsShow = 1 where EquipmentId = " + gv_showEquip.DataKeys[i].Value;
            }
            else
                sql = "update Equipment set IsShow = 0 where EquipmentId = " + gv_showEquip.DataKeys[i].Value;
            db.ExecuteSql(sql, null);
        }
        BindEquipmentList();
    }
}
