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

public partial class Teacher_nMyReservationList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if(!IsPostBack)
            BindReservationList();  //教师本身的申请列表
    }

    /// <summary>
    /// 绑定导师自己预约的设备
    /// </summary>
    private void BindReservationList()
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from ReservationInfo left join State on ReservationInfo.StateId = State.StateId where UserId = " + UserId + " order by ReservationInfoId desc";

        DBConnect db = new DBConnect();
        GV_MyList.DataSource = db.GetDataSet(sql, null);
        GV_MyList.DataBind();

        double total = 0.0;
        for (int i = 0; i < GV_MyList.Rows.Count; i++)
        {
            total += Convert.ToDouble(GV_MyList.Rows[i].Cells[1].Text);
        }
        lblTotal.Text = total.ToString();
    }
    protected void GV_MyList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F00F'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (e.Row.Cells[2].Text == "通过审批")
            {
                e.Row.Cells[5].BackColor = Color.Red;
                e.Row.Cells[5].Text = "不能取消预约";
            }
            if (e.Row.Cells[2].Text == "取消预约")
            {
                e.Row.Cells[5].BackColor = Color.Blue;
                e.Row.Cells[5].Text = "已经取消预约";
            }
        }
    }

    protected void GV_MyList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelIssue")
        {
            String sql = "update ReservationInfo set StateId = 16 where ReservationInfoId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindReservationList();
        }
    }
}
