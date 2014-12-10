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

public partial class Admin_nEquipBroken : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindBrokenEquipmentList();
        }
    }

    /// <summary>
    /// 绑定损坏的设备列表
    /// </summary>
    private void BindBrokenEquipmentList()
    {
        String sql = "select * from Equipment left join State on Equipment.StateId = State.StateId left join Users on Equipment.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId where Equipment.StateId between 22 and 24";
        DBConnect db = new DBConnect();
        GVFaultEquipment.DataSource = db.GetDataSet(sql, null);
        GVFaultEquipment.DataBind();
    }

    protected void GVFaultEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVFaultEquipment.PageIndex = e.NewPageIndex;
        BindBrokenEquipmentList();
    }
}
