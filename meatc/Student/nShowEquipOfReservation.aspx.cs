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

public partial class Student_nShowEquipOfReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReservationEquip();
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
        }
    }

    /// <summary>
    /// 显示课题相关的设备
    /// </summary>
    private void BindReservationEquip()
    {
        String r_id = Request.QueryString["r_id"];
        String sql = "select * from Equipment left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join Reservation on Equipment.EquipmentId = Reservation.EquipmentId where ReservationInfoId = " + r_id;
        DBConnect db = new DBConnect();
        GVEquipment.DataSource = db.GetDataSet(sql, null);
        GVEquipment.DataBind();
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void GVEquipment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].Text = (Convert.ToDouble(e.Row.Cells[1].Text) * Convert.ToInt32(e.Row.Cells[9].Text)).ToString();
            e.Row.Cells[7].Text = (Convert.ToDouble(((Label)e.Row.Cells[7].FindControl("lblTotle")).Text) - Convert.ToDouble(((HiddenField)e.Row.Cells[7].FindControl("HFAdditionalCosts")).Value) - Convert.ToDouble(e.Row.Cells[8].Text)).ToString();
            e.Row.Cells[7].BackColor = Color.Brown;
            e.Row.Cells[8].BackColor = Color.Blue;
        }
    }
}
