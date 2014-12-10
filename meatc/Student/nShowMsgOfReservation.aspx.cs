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

public partial class Student_nShowMsgOfReservation : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindMessage();
    }

    private void BindMessage()
    {
        String UserId = Session["UserId"].ToString();
        String InfoId = Request.QueryString["r_id"];    //对应的课题
        String sql = "select * from ReservationMsg left join Users on ReservationMsg.FromUserId = Users.UserId where ReservationInfoId = " + InfoId + " order by ReservationMsgTime desc";
        if (InfoId == "0")
        {
            sql = "select * from ReservationMsg left join Users on ReservationMsg.FromUserId = Users.UserId where ToUserId =" + UserId + " and IsRead = 0 order by ReservationMsgTime desc";
            
        }
        DBConnect db = new DBConnect();
        rp_msg.DataSource = db.GetDataSet(sql, null);
        rp_msg.DataBind();
        if (InfoId == "0")
        {
            sql = "update ReservationMsg set IsRead = 1 where ToUserID = " + UserId;
            db.ExecuteSql(sql, null);
        }
        else
        {
            sql = "update ReservationMsg set IsRead = 1 where ReservationInfoId = " + InfoId;
            db.ExecuteSql(sql, null);
        }
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
            MainSend.SendMail(MainSend.getEmail(FromUserId), "您有新消息了", "消息内容：" + tb_message.Text + " <br />请登录网站查看并回复<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "'>点击打开</a>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('回复消息成功，同时以邮件形式通知管理员！')</script>");
        }
        panel_reply.Visible = false;
        BindMessage();
    }
}
