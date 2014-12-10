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

public partial class Teacher_nReservationStatistic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindReservationList(-1);
            //CalculateTotalPrice();
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);        
    }

    /// <summary>
    /// 绑定预约信息
    /// </summary>
    private void BindReservationList()
    {
        String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where ReservationInfo.UserId ="+ Session["UserId"].ToString() +" order by ReservationInfoId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
    }
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
        }
    }

    /// <summary>
    /// 计算总价格
    /// </summary>
    private void CalculateTotalPrice()
    {
        double total = 0.0;
        for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
        {
            total += Convert.ToDouble(GVReservationInfo.Rows[i].Cells[6].Text);
        }
        lblTotle.Text = total.ToString();
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "";
        sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.ReservationInfoId,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId where ReservationInfo.UserId = " + Session["UserId"].ToString();
        if (Convert.ToInt32(ddlShenPiState.SelectedItem.Value) > 0)
        {
            sql += " and ReservationInfo.StateId = " + ddlShenPiState.SelectedItem.Value;            
        }
        if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
        {
            sql += " and BeginReservationInfoTime > '" + Convert.ToDateTime(txtBeginTime.Text).ToLocalTime() + "'";
            sql += " and EndReservationInfoTime < '" + Convert.ToDateTime(txtEndTime.Text).AddDays(1).ToLocalTime() + "'";
        }

        sql += " order by ReservationInfoId desc";

        DBConnect db = new DBConnect();
        GVReservationInfo.DataSource = db.GetDataSet(sql, null);
        GVReservationInfo.DataBind();
        for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GVReservationInfo.Rows[i].Cells[0].FindControl("cb_select");
            cb.Checked = true;
        }
        CalculateTotalPrice();
        //Response.Write(sql);
    }

    /// <summary>
    /// 绑定预约学生的列表
    /// </summary>
    private void BindReservationList(int UserType)
    {
        String sql = "";
        if (UserType == -1)
        {
            sql = "select Equipment.EquipmentId,EquipmentName,ReservationInfo.ReservationInfoId,ReservationInfo.UserId,UserName,UserType,EquipmentTypeName,BeginReservationTime,EndReservationTime,EquipmentNum,EquipmentUnitName,Totle,StateName from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users On ReservationInfo.UserId = Users.UserId left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join State on ReservationInfo.StateId = State.StateId where ReservationInfo.UserId = " + Session["UserId"].ToString() + "  order by ReservationInfo.ReservationInfoId desc";
            DBConnect db = new DBConnect();
            GVReservationInfo.DataSource = db.GetDataSet(sql, null);
            GVReservationInfo.DataBind();
        }
        
        
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
        }
    }

    protected void bt_report_Click(object sender, EventArgs e)
    {        
        String ReservationInfoIds = "";
        bool flag = false;
        for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GVReservationInfo.Rows[i].Cells[0].FindControl("cb_select");
            if (cb.Checked)
            {
                HiddenField hf_ReservationInfoId = (HiddenField)GVReservationInfo.Rows[i].Cells[0].FindControl("hf_ReservationInfoId");
                ReservationInfoIds += (hf_ReservationInfoId.Value + "@");
                flag = true;
            }
        }
        if (flag)
        {
            ReservationInfoIds = ReservationInfoIds.Substring(0, ReservationInfoIds.Length - 1);
            Session["ReservationInfoIds"] = ReservationInfoIds;
            Response.Redirect("~/Admin/ReportToTeacher.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请至少选择一个课题!');</script>");
        }
    }
    protected void cb_selectAll_CheckedChanged(object sender, EventArgs e)
    {
        if (cb_selectAll.Checked)
        {
            for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GVReservationInfo.Rows[i].Cells[0].FindControl("cb_select");
                cb.Checked = true;
            }
            CalculateTotalPrice();
        }
        else
        {
            for (int i = 0; i < GVReservationInfo.Rows.Count; i++)
            {
                CheckBox cb = (CheckBox)GVReservationInfo.Rows[i].Cells[0].FindControl("cb_select");
                cb.Checked = true;
            }
            CalculateTotalPrice();
        }

    }
}
