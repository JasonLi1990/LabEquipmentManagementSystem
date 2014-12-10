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

public partial class Admin_nAdminHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null)
                BindReservationList(Convert.ToInt32(Request.QueryString["type"]));
            else
                BindReservationList(-1);            
        }
    }

    /// <summary>
    /// 绑定预约学生的列表
    /// </summary>
    private void BindReservationList(int UserType)
    {
        String sql= "";
        if (UserType == -1)
        {
            sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId  order by ReservationInfo.ReservationInfoId desc";
        }
        else
        {
            sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId where UserType = "+ UserType +" order by ReservationInfo.ReservationInfoId desc";
        }
        DBConnect db = new DBConnect();
        GVReservationInfo.DataSource = db.GetDataSet(sql, null);
        GVReservationInfo.DataBind();
    }

    

    protected void GVReservationInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVReservationInfo.PageIndex = e.NewPageIndex;
        BindReservationList(-1);
    }
    protected void GVReservationInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "1")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople03.JPG";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "0")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople02.png";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "5")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople01.png";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "2")  //老师
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople04.JPG";
            }
        }
    }

    protected void imgBtnSchool_Click(object sender, ImageClickEventArgs e)
    {
        BindReservationList(5);
    }
    protected void imgBtnOut_Click(object sender, ImageClickEventArgs e)
    {
        BindReservationList(0);
    }
    protected void imgBtnInner_Click(object sender, ImageClickEventArgs e)
    {
        BindReservationList(1);
    }
    protected void imgBtnTeacher_Click(object sender, ImageClickEventArgs e)
    {
        BindReservationList(2);
    }
}
