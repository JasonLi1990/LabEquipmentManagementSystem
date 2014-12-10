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
using System.Data.SqlClient;

public partial class EquipManager_nReservationDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindReservationDetailList();
    }

    private void BindReservationDetailList()
    {
        String r_id = Request.QueryString["r_id"];
        String sql = "select * from Equipment left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join Reservation on Equipment.EquipmentId = Reservation.EquipmentId where ReservationInfoId = " + r_id;
        DBConnect db = new DBConnect();
        GVEquipment.DataSource = db.GetDataSet(sql, null);
        GVEquipment.DataBind();
        CalculateTotalPrice();
    }

    protected void GVEquipment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox tb_yuchuli = (TextBox)e.Row.Cells[9].FindControl("txtYuChuli");
            TextBox tb_yuchuliNumber = (TextBox)e.Row.Cells[4].FindControl("lblYuChuliNum");
            tb_yuchuli.Text = (Convert.ToDouble(e.Row.Cells[1].Text) * Convert.ToDouble(tb_yuchuliNumber.Text)).ToString();
            TextBox tb_totle = (TextBox)e.Row.Cells[8].FindControl("lblTotle");
            tb_totle.Text = (Convert.ToDouble(((TextBox)e.Row.Cells[8].FindControl("lblTotle")).Text) - Convert.ToDouble(((HiddenField)e.Row.Cells[8].FindControl("HFAdditionalCosts")).Value) - Convert.ToDouble(tb_yuchuli.Text)).ToString();
            TextBox tb_yangpinNum = (TextBox)e.Row.Cells[3].FindControl("lblNum");
            e.Row.Cells[7].Text = (Convert.ToDouble(e.Row.Cells[7].Text)*Convert.ToDouble(tb_yangpinNum.Text)).ToString();   //押金=押金单价*样品数
        }
    }

    /// <summary>
    /// 修改附加费、样品数、测定元素个数、设备总额、附加费说明
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnok_Click(object sender, ImageClickEventArgs e)
    {
        DBConnect db = new DBConnect();
        Double TOTALMONEY = 0.0;
        for (int i = 0; i < GVEquipment.Rows.Count; i++)
        {
            double aCost = Convert.ToDouble(((TextBox)GVEquipment.Rows[i].Cells[10].FindControl("txtAdditionalCosts")).Text);//附加费
            String equipNumber = ((TextBox)GVEquipment.Rows[i].Cells[3].FindControl("lblNum")).Text;  //样品数量
            String elementNumber = ((TextBox)GVEquipment.Rows[i].Cells[5].FindControl("tb_elementNum")).Text;   //测定元素数量
            String yuchuliNumber = ((TextBox)GVEquipment.Rows[i].Cells[4].FindControl("lblYuChuliNum")).Text;   //预处理样品数
            double totle = Convert.ToDouble(((TextBox)GVEquipment.Rows[i].Cells[8].FindControl("lblTotle")).Text);
            String notes = ((TextBox)GVEquipment.Rows[i].Cells[11].FindControl("txtAdditionalCostsExplain")).Text;
            double yuchulifei = Convert.ToDouble(((TextBox)GVEquipment.Rows[i].Cells[9].FindControl("txtYuChuli")).Text);


            String sql_1 = "update Reservation set EquipmentNum=" + equipNumber + ",YuansuNum=" + elementNumber + ",AdditionalCosts = " + aCost + ",Totle=" + (yuchulifei + aCost + totle) + ",AdditionalCostsExplain='" + notes + "',yuchuliNum=" + yuchuliNumber + " where ReservationId = " + GVEquipment.DataKeys[i].Value;
            //Response.Write(sql_1);
            TOTALMONEY += totle + aCost + yuchulifei;
            db.ExecuteSql(sql_1, null);
        }
        String reservationInfoSql = "update ReservationInfo set Total = " + TOTALMONEY + " where ReservationInfoId = " + Request.QueryString["r_id"];
        db.ExecuteSql(reservationInfoSql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！')</script>");
        BindReservationDetailList();
        CalculateTotalPrice();
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nShowIssue.aspx?r_id=" + Request.QueryString["r_id"]);
    }
    protected void GVEquipment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ChangeTime")
        {
            hf_reservationId.Value = e.CommandArgument.ToString();
            panelEquipmentList.Visible = true;
        }
    }

    protected void imgBtnEquipmentclose_Click(object sender, ImageClickEventArgs e)
    {
        panelEquipmentList.Visible = false;
        BindReservationDetailList();
    }

    /// <summary>
    /// 修改预约时间
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEquipmentSave_Click(object sender, ImageClickEventArgs e)
    {
        String starttime = tb_start.Value;
        String endtime = tb_end.Value;
        String reservationId = hf_reservationId.Value;
        String sql = "update Reservation set BeginReservationTime='" + Convert.ToDateTime(starttime) + "',EndReservationTime='" + Convert.ToDateTime(endtime) + "' where ReservationId = " + reservationId;
        String sql_reservationInfo = "Update ReservationInfo set BeginReservationInfoTime = '" + Convert.ToDateTime(starttime) + "',EndReservationInfoTime='" + Convert.ToDateTime(endtime) + "' where ReservationInfoId = " + Request.QueryString["r_id"];
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        db.ExecuteSql(sql_reservationInfo, null);
        //发送邮件及消息
        String msg = "您预约的实验设备时间已调整为：" + starttime + " 至 " + endtime;
        CheckSendMail.EquipManagerSendMail(Request.QueryString["r_id"], "您预约的设备有时间改动", msg);
        sql = "select UserId from ReservationInfo where ReservationInfoId = " + Request.QueryString["r_id"];
        String u_id = db.GetDataSet(sql, null).Tables[0].DefaultView[0]["UserId"].ToString();

        sql = "insert into ReservationMsg (ReservationInfoId, ReservationMsgContent,FromUserId,ToUserId,ReservationMsgTime,IsRead) values (@infoId, @content, @fromuser,@touser,@msgtime,0)";
        SqlParameter[] paras = { 
                                       DBConnect.MakeParameter("@infoId", Request.QueryString["r_id"]),
                                       DBConnect.MakeParameter("@content", msg),
                                       DBConnect.MakeParameter("@fromuser", Session["UserId"].ToString()),  
                                       DBConnect.MakeParameter("@touser",u_id),
                                       DBConnect.MakeParameter("@msgtime", DateTime.Now)
                                   };
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预约时间修改成功，且已发送邮件通知对方！')</script>");

        panelEquipmentList.Visible = false;
        BindReservationDetailList();

    }

    /// <summary>
    /// 点击重新计算价格按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_calculate_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GVEquipment.Rows.Count; i++)
        {
            int equipNumber = Convert.ToInt32(((TextBox)GVEquipment.Rows[i].Cells[3].FindControl("lblNum")).Text);  //样品数量
            int yuchuliNum = Convert.ToInt32(((TextBox)GVEquipment.Rows[i].Cells[4].FindControl("lblYuChuliNum")).Text);   //测定元素数量
            int elementNumber = Convert.ToInt32(((TextBox)GVEquipment.Rows[i].Cells[5].FindControl("tb_elementNum")).Text);   //测定元素数量
            if (yuchuliNum > equipNumber)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预处理样品数量不能多于总样品数量');</script>");
                return;
            }
            double price = Convert.ToDouble(GVEquipment.Rows[i].Cells[2].Text);
            TextBox tb_totle = (TextBox)GVEquipment.Rows[i].Cells[8].FindControl("lblTotle");
            //计算方法
            tb_totle.Text = (equipNumber * elementNumber * price).ToString();
            TextBox tb_yuchuli = (TextBox)GVEquipment.Rows[i].Cells[9].FindControl("txtYuChuli");
            tb_yuchuli.Text = (yuchuliNum * Convert.ToDouble(GVEquipment.Rows[i].Cells[1].Text)).ToString();
        }
        CalculateTotalPrice();
    }

    private void CalculateTotalPrice()
    {
        double total = 0.0;
        for (int i = 0; i < GVEquipment.Rows.Count; i++)
        {
            TextBox tb_totle = (TextBox)GVEquipment.Rows[i].Cells[8].FindControl("lblTotle");
            TextBox tb_yuchuli = (TextBox)GVEquipment.Rows[i].Cells[9].FindControl("txtYuChuli");
            TextBox tb_additionnal = (TextBox)GVEquipment.Rows[i].Cells[10].FindControl("txtAdditionalCosts");

            total += (Convert.ToDouble(tb_totle.Text) + Convert.ToDouble(tb_yuchuli.Text) + Convert.ToDouble(tb_additionnal.Text));
        }

        lb_totalMoney.Text = total.ToString();
    }
}
