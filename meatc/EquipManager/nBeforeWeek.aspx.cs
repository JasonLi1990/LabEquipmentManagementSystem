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

public partial class EquipManager_nBeforeWeek : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindTeacherList();
            //BindWeekPlan();
        }
    }

    /// <summary>
    /// 显示下周计划
    /// </summary>
    private void BindWeekPlan()
    {
        DateTime nextweekModay = DateTime.Today.AddDays(8 - GetDayOfWeek()).ToLocalTime();
        DateTime nextweekSunday = DateTime.Today.AddDays(15 - GetDayOfWeek()).ToLocalTime();
        DateTime beforeweekMonday = DateTime.Today.AddDays(1 - GetDayOfWeek() - 7).ToLocalTime();
        DateTime beforeweekSunday = DateTime.Today.AddDays(1 - GetDayOfWeek()).ToLocalTime();
        String sql = "select Reservation.EquipmentId,EquipmentName,EquipmentTypeName,ReservationInfo.ReservationInfoId,IssueName,Users.UserId,UserName,StateName,BeginReservationTime,EndReservationTime from Reservation left join Equipment on Equipment.EquipmentId = Reservation.EquipmentId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateID where Reservation.EquipmentId in (select EquipmentId from Equipment where UserId = " + Session["UserId"].ToString() + ") and BeginReservationTime between '" + beforeweekMonday + "' and '" + beforeweekSunday + "' order by BeginReservationTime";
        DBConnect db = new DBConnect();
        GVWeekTrial.DataSource = db.GetDataSet(sql, null);
        GVWeekTrial.DataBind();
        lb_nextweek.Text = "上周：" + beforeweekMonday.ToLongDateString() + "至" + beforeweekSunday.AddDays(-1).ToLongDateString();
    }
    protected void GVWeekTrial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ShowStudent")
        {
            String sql = "select * from Users where UserId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lb_name.Text = drv["UserName"].ToString();
            lb_phone.Text = drv["UserPhone"].ToString();
            lb_mobile.Text = drv["MobileTelephone"].ToString();
            lb_email.Text = drv["UserEmail"].ToString();
            panelStudentInfo.Visible = true;
        }
    }


    protected void imgBtnEquipmentclose_Click(object sender, ImageClickEventArgs e)
    {
        panelStudentInfo.Visible = false;
    }

    private int GetDayOfWeek()
    {
        int result = 0;
        switch (DateTime.Now.DayOfWeek.ToString())
        {
            case "Monday":
                result = 1;
                break;
            case "Tuesday":
                result = 2;
                break;
            case "Wednesday":
                result = 3;
                break;
            case "Thursday":
                result = 4;
                break;
            case "Friday":
                result = 5;
                break;
            case "Saturday":
                result = 6;
                break;
            case "Sunday":
                result = 7;
                break;
        }
        return result;
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

    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {        
        String sql = "select Reservation.EquipmentId,EquipmentName,EquipmentTypeName,ReservationInfo.ReservationInfoId,IssueName,Users.UserId,UserName,StateName,BeginReservationTime,EndReservationTime,Totle from Reservation left join Equipment on Equipment.EquipmentId = Reservation.EquipmentId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateID where Reservation.EquipmentId in (select EquipmentId from Equipment where UserId = " + Session["UserId"].ToString() + ")";
        if (!ddlTeacher.SelectedItem.Value.Equals("0"))
        {
            sql += " and ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + ddlTeacher.SelectedItem.Value + ")";
        }
        if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
        {
            DateTime startDay = Convert.ToDateTime(txtBeginTime.Text);
            DateTime endDay = Convert.ToDateTime(txtEndTime.Text).AddDays(1);            
            sql += " and BeginReservationTime between '" + startDay + "' and '" + endDay + "' order by BeginReservationTime";  
        }
        if (!ddlShenPiState.SelectedItem.Value.Equals("0"))
        {
            sql += " and ReservationInfo.StateId = " + ddlShenPiState.SelectedItem.Value;
        }
        if (!ddl_type.SelectedItem.Value.Equals("-1"))
        {
            sql += " and Users.UserType = " + ddl_type.SelectedItem.Value;
        }
        DBConnect db = new DBConnect();
        GVWeekTrial.DataSource = db.GetDataSet(sql, null);
        GVWeekTrial.DataBind();
    }
}
