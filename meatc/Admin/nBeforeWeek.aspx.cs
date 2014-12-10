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

public partial class Admin_nBeforeWeek : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindReservationList();
    }

    /// <summary>
    /// 绑定下周的预约信息
    /// </summary>
    private void BindReservationList()
    {
        //Response.Write(DateTime.Today.AddDays(8 - GetDayOfWeek()).ToLocalTime().ToString());
        DateTime nextweekModay = DateTime.Today.AddDays(8 - GetDayOfWeek()).ToLocalTime();
        DateTime nextweekSunday = DateTime.Today.AddDays(15 - GetDayOfWeek()).ToLocalTime();
        DateTime beforeweekMonday = DateTime.Today.AddDays(1 - GetDayOfWeek() - 7).ToLocalTime();
        DateTime beforeweekSunday = DateTime.Today.AddDays(1 - GetDayOfWeek()).ToLocalTime();
        //Response.Write(beforeweekMonday + " --- " + beforeweekSunday);
        //Response.Write(nextweekModay + ":" + nextweekSunday);

        String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where BeginReservationInfoTime > '" + beforeweekMonday + "' and EndReservationInfoTime < '" + beforeweekSunday + "'";
        //Response.Write(sql);
        DBConnect db = new DBConnect();
        GVWithoutApproval.DataSource = db.GetDataSet(sql, null);
        GVWithoutApproval.DataBind();
        lb_weektime.Text = beforeweekMonday.ToLongDateString() + "至" + beforeweekSunday.AddDays(-1).ToLongDateString();
        double total = 0.0; 
        for (int i = 0; i < GVWithoutApproval.Rows.Count; i++)
        {
            total += Convert.ToDouble(GVWithoutApproval.Rows[i].Cells[4].Text);
        }
        lblTotal.Text = total.ToString();
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

    protected void imgBtnCreateWeekPlan_Click(object sender, ImageClickEventArgs e)
    {
        Panel1.Visible = true;
    }

    /// <summary>
    /// 筛选不同的预约结果
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        String state = ddl_state.SelectedItem.Value;
        if (state == "0")
            BindReservationList();
        else
        {
            DateTime nextweekModay = DateTime.Today.AddDays(8 - GetDayOfWeek()).ToLocalTime();
            DateTime nextweekSunday = DateTime.Today.AddDays(15 - GetDayOfWeek()).ToLocalTime();
            DateTime beforeweekMonday = DateTime.Today.AddDays(1 - GetDayOfWeek() - 7).ToLocalTime();
            DateTime beforeweekSunday = DateTime.Today.AddDays(1 - GetDayOfWeek()).ToLocalTime();
            //Response.Write(nextweekModay + ":" + nextweekSunday);

            String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where BeginReservationInfoTime > '" + beforeweekMonday + "' and EndReservationInfoTime < '" + beforeweekSunday + "' and ReservationInfo.StateId = " + state;
            //Response.Write(sql);
            DBConnect db = new DBConnect();
            GVWithoutApproval.DataSource = db.GetDataSet(sql, null);
            GVWithoutApproval.DataBind();
            lb_weektime.Text = beforeweekMonday.ToLongDateString() + "至" + beforeweekSunday.AddDays(-1).ToLongDateString();
            double total = 0.0;
            for (int i = 0; i < GVWithoutApproval.Rows.Count; i++)
            {
                total += Convert.ToDouble(GVWithoutApproval.Rows[i].Cells[4].Text);
            }
            lblTotal.Text = total.ToString();
        }
    }
}
