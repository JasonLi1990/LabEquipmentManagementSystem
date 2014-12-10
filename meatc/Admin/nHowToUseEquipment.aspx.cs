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

public partial class Admin_nHowToUseEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindTeacherList();
            BindHowToUseEquip();
        }
    }
    private void BindTeacherList()
    {
        String sql = "select * from Users where UserType = 2 order by UserId";
        DBConnect db = new DBConnect();
        ddlTeacher.DataSource = db.GetDataSet(sql, null);
        ddlTeacher.DataTextField = "UserName";
        ddlTeacher.DataValueField = "UserId";
        ddlTeacher.DataBind();
        ddlTeacher.Items.Insert(0, new ListItem("全部", "0"));
    }

    private void BindHowToUseEquip()
    {
        String sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId where Equipment.EquipmentId = " + Request.QueryString["e_id"] + " order by ReservationInfo.ReservationInfoId desc";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            GVReservationInfo.DataSource = ds;
            GVReservationInfo.DataBind();
            CalculateTotle();
        }
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
    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId where Equipment.EquipmentId = " + Request.QueryString["e_id"];
        if (!ddlTeacher.SelectedItem.Value.Equals("0"))
        {
            sql += " and ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + ddlTeacher.SelectedItem.Value + ")";
        }
        if (!ddlShenPiState.SelectedItem.Value.Equals("0"))
        {
            sql += " and ReservationInfo.StateId = " + ddlShenPiState.SelectedItem.Value;
        }
        if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
        {
            sql += " and BeginReservationTime between '" + Convert.ToDateTime(txtBeginTime.Text) + "' and '" + Convert.ToDateTime(txtEndTime.Text).AddDays(1) + "'";
        }
        if (!ddl_type.SelectedItem.Value.Equals("-1"))
        {
            sql += " and UserType = " + ddl_type.SelectedItem.Value;
        }
        sql += " order by ReservationInfo.ReservationInfoId desc";
        //Response.Write(sql);
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        GVReservationInfo.DataSource = ds;
        GVReservationInfo.DataBind();
        CalculateTotle();
    }

    private void CalculateTotle()
    {
        double sum = 0.0;
        int sumYangPin = 0;
        int sumhours = 0, summinutes = 0;
        for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
        {
            sum += Convert.ToDouble(GVReservationInfo.Rows[i].Cells[6].Text);
            sumYangPin += Convert.ToInt32(GVReservationInfo.Rows[i].Cells[5].Text.Trim());
            Label start = (Label)GVReservationInfo.Rows[i].Cells[4].FindControl("lblReservationTime");
            Label end = (Label)GVReservationInfo.Rows[i].Cells[4].FindControl("HFEndTime");
            TimeSpan span =  Convert.ToDateTime(end.Text)- Convert.ToDateTime(start.Text);
            sumhours += span.Hours;
            summinutes += span.Minutes;            
        }
        lb_yangpintotel.Text = sumYangPin.ToString();
        lb_totle.Text = sum.ToString();
        sumhours += summinutes / 60;
        summinutes = summinutes % 60;
        lb_timeTotel.Text = sumhours + "小时" + summinutes + "分钟";
    }
}
