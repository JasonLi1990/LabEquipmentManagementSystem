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

public partial class Admin_nEquipmentStatisticInfoSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindEquipList();
    }

    private void BindEquipList()
    {
        String sql = "select EquipmentId,EquipmentName,EquipmentTypeName,Users.UserId as UserId,UserName,FrequencyOfUse,TotalMoney,StateName from Equipment left join State on Equipment.StateId = State.StateId left join Users on Equipment.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join (select EquipmentId as EId,sum(totle) as TotalMoney from Reservation group by EquipmentId)  as Moneys on Equipment.EquipmentId = Moneys.EId";
        DBConnect db = new DBConnect();
        GVFaultEquipment.DataSource = db.GetDataSet(sql, null);
        GVFaultEquipment.DataBind();
    }
    protected void GVFaultEquipment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowEquipManager")
        {
            Response.Redirect("nEquipManagerInfo.aspx?u_id="+e.CommandArgument);
        }
    }
    protected void GVFaultEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVFaultEquipment.PageIndex = e.NewPageIndex;
        BindEquipList();
    }
}
