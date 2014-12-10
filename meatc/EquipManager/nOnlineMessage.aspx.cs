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

public partial class EquipManager_nOnlineMessage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindMessage();
    }

    /// <summary>
    /// 绑定消息
    /// </summary>
    private void BindMessage()
    {
        String UserId = Session["UserId"].ToString();
        String InfoId = Request.QueryString["r_id"];    //对应的课题
        String sql = "select * from ReservationMsg left join Users on ReservationMsg.FromUserId = Users.UserId where ReservationInfoId = " + InfoId + " order by ReservationMsgTime desc";
        //String sql_2 = "select * from ReservationMsg left join Users on ReservationMsg.FromUserId = Users.UserId where ToUserId = " + UserId + " and ReservationInfoId = " + InfoId + " order by ReservationMsgTime desc";
        DBConnect db = new DBConnect();
        rp_msg.DataSource = db.GetDataSet(sql, null);
        rp_msg.DataBind();
    }


    /// <summary>
    /// 删除消息用
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void rp_msg_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delMessage")
        {
            String sql = "delete from ReservationMsg where ReservationMsgId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            Response.Redirect("ShowMsgOfReservation.aspx?r_id=" + Request.QueryString["r_id"]);
        }

        else if (e.CommandName == "showContact")
        {

            String sql = "select * from Users where UserId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
            {
                DataRowView drv = ds.Tables[0].DefaultView[0];
                lb_name.Text = drv["UserName"].ToString();
                lb_phone.Text = drv["UserPhone"].ToString();
                lb_mobile.Text = drv["MobileTelephone"].ToString();
                lb_email.Text = drv["UserEmail"].ToString();
            }

            panelEquipmentList.Visible = true;
        }
        else if (e.CommandName == "replyMessage")   //回复消息
        {
            hf_reservationMsgId.Value = e.CommandArgument.ToString();
            panel_reply.Visible = true;
        }
    }
    protected void imgBtnEquipmentclose_Click(object sender, ImageClickEventArgs e)
    {
        panelEquipmentList.Visible = false;
    }


    protected void imgBtnCloseMsg_Click(object sender, ImageClickEventArgs e)
    {
        panel_reply.Visible = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSend_Click(object sender, ImageClickEventArgs e)
    {
        String oldMsgId = hf_reservationMsgId.Value;    //要回复的消息
        String getSql = "select * from ReservationMsg where ReservationMsgId = " + oldMsgId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(getSql, null);
        if (ds != null)
        {
            String ReservationInfoId = ds.Tables[0].DefaultView[0]["ReservationInfoId"].ToString();
            String FromUserId = ds.Tables[0].DefaultView[0]["FromUserId"].ToString();
            String ToUserId = ds.Tables[0].DefaultView[0]["ToUserId"].ToString();
            String sql = "insert into ReservationMsg (ReservationInfoId, ReservationMsgContent,FromUserId,ToUserId,ReservationMsgTime) values (@infoId, @content, @fromuser,@touser,@msgtime)";
            SqlParameter[] paras = { 
                                       DBConnect.MakeParameter("@infoId", ReservationInfoId),
                                       DBConnect.MakeParameter("@content", tb_message.Text),
                                       DBConnect.MakeParameter("@fromuser", ToUserId),  //用户交换，因为是回复
                                       DBConnect.MakeParameter("@touser", FromUserId),
                                       DBConnect.MakeParameter("@msgtime", DateTime.Now)
                                   };
            db.ExecuteSql(sql, paras);
            CheckSendMail.EquipManagerSendMail(ReservationInfoId, "设备管理员发来消息", tb_message.Text);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复消息成功，同时以邮件形式发送给申请人！')</script>");
        }
        panel_reply.Visible = false;
        BindMessage();
    }
    protected void bt_sendMessage_Click(object sender, EventArgs e)
    {
        String getToUserIdSql = "select UserId from ReservationInfo where ReservationInfoId = " + Request.QueryString["r_id"];
        DBConnect db = new DBConnect();
        String FromUserId = Session["UserId"].ToString();
        String ToUserId = db.GetDataSet(getToUserIdSql, null).Tables[0].DefaultView[0]["UserId"].ToString();
        String sql = "insert into ReservationMsg (ReservationInfoId, ReservationMsgContent,FromUserId,ToUserId,ReservationMsgTime) values (@infoId, @content, @fromuser,@touser,@msgtime)";
        SqlParameter[] paras = {
                                       DBConnect.MakeParameter("@infoId", Request.QueryString["r_id"]),
                                       DBConnect.MakeParameter("@content", tb_message_new.Text),
                                       DBConnect.MakeParameter("@fromuser", FromUserId), 
                                       DBConnect.MakeParameter("@touser", ToUserId),
                                       DBConnect.MakeParameter("@msgtime", DateTime.Now)
                                   };
        db.ExecuteSql(sql, paras);
        CheckSendMail.EquipManagerSendMail(Request.QueryString["r_id"], "设备管理员发来消息", tb_message_new.Text);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复消息成功，同时以邮件形式发送给申请人！')</script>");
        BindMessage();
    }
}
