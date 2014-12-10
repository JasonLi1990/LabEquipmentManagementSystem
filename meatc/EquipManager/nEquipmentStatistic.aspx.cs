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

public partial class EquipManager_nEquipmentStatistic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 3);
        if (!IsPostBack)
            BindEquipList();
    }

    private void BindEquipList()
    {
        String sql = "select EquipmentId,EquipmentName,EquipmentTypeName,Users.UserId as UserId,UserName,FrequencyOfUse,TotalMoney,StateName from Equipment left join State on Equipment.StateId = State.StateId left join Users on Equipment.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join (select EquipmentId as EId,sum(totle) as TotalMoney from Reservation group by EquipmentId) as Moneys on Equipment.EquipmentId = Moneys.EId where Users.UserId = " + Session["UserId"].ToString();
        DBConnect db = new DBConnect();
        GVFaultEquipment.DataSource = db.GetDataSet(sql, null);
        GVFaultEquipment.DataBind();
    }
    protected void GVFaultEquipment_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
    }
    protected void GVFaultEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVFaultEquipment.PageIndex = e.NewPageIndex;
        BindEquipList();
    }
}
