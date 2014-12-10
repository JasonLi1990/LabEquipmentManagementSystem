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

public partial class EquipManager_nShowIssue : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"].ToString().Equals("4"))
        {
            Page.MasterPageFile = "~/Admin/A_MasterPage.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindReservationInfo();
            if (Session["UserType"].ToString().Equals("4"))
            {
                ImgBtnOK.Visible = false;
                ImgBtnNo.Visible = false;
                lBtnEquipment.Enabled = false;
            }
            String checksql = "select stateid from ReservationInfo where reservationinfoId = " + Request.QueryString["r_id"];
            DBConnect db = new DBConnect();
            if (db.GetDataSet(checksql, null).Tables[0].DefaultView[0]["stateid"].ToString().Equals("13"))
            {
                ImgBtnOK.Visible = true;
                ImgBtnNo.Visible = true;
            }
        }
    }

    /// <summary>
    /// 绑定预约所涉及课题的各种信息
    /// </summary>
    private void BindReservationInfo()
    {
        String r_id = Request.QueryString["r_id"];
        String sql = "select * from ReservationInfo left join Users On Users.UserId = ReservationInfo.UserId where ReservationInfoId = " + r_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        String StudentId = "";
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lblIssueName.Text = drv["IssueName"].ToString();
            lblName.Text = drv["UserName"].ToString();
            lblPhone.Text = drv["MobileTelephone"].ToString();
            lblEmail.Text = drv["UserEmail"].ToString();
            StudentId = drv["UserId"].ToString();   //用于查询指导教师的信息
            lblFinancialCard.Text = drv["FinancialCard"].ToString();
            lblIssueContent.Text = drv["IssueContent"].ToString();
            lblTestPurpose.Text = drv["TestPurpose"].ToString();
            lblCheckIndicators.Text = drv["CheckIndicators"].ToString();
            lblSampleProperties.Text = drv["SampleProperties"].ToString();
            lblReservationTime.Text = drv["BeginReservationInfoTime"].ToString() + "至" + drv["EndReservationInfoTime"].ToString();
        }

        sql = "select * from UserRelationship inner join Users on UserRelationship.PUserId = Users.UserId where CUserId = " + StudentId;
        ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lblTeacherName.Text = drv["UserName"].ToString();
            lblTeacherPhone.Text = "固定电话：" + drv["UserPhone"].ToString() + "/手机：" + drv["MobileTelephone"].ToString();
            lblTeacherEmail.Text = drv["UserEmail"].ToString();
        }

        sql = "select EquipmentName from Equipment where EquipmentId in (select EquipmentId from Reservation where ReservationInfoId = " + r_id + ")";
        ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                lBtnEquipment.Text += ds.Tables[0].DefaultView[i]["EquipmentName"].ToString() + "、";
            }
            lBtnEquipment.Text += ds.Tables[0].DefaultView[i]["EquipmentName"].ToString();
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lBtnEquipment_Click(object sender, EventArgs e)
    {
        Response.Redirect("nReservationDetail.aspx?r_id=" + Request.QueryString["r_id"]);
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>window.history.go(-2);</script>");
      /*  if (Session["UserType"].ToString().Equals("4"))
        {
            Response.Redirect("~/Admin/nReservationStatisticsSearch.aspx");
        }
        else
        {
            Response.Redirect("nEquipManagerHome.aspx");
        }*/
    }
    protected void ImgBtnNo_Click(object sender, ImageClickEventArgs e)
    {
        panelApprovalInfo.Visible = true;
    }
    protected void imgBtnApprovalInfoOK_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "update ReservationInfo set StateId = 15 where ReservationInfoId = " + Request.QueryString["r_id"]; //15代表未通过管理员审批
        String sql_msg = "Insert into ReservationMsg (ReservationInfoID,ReservationMsgContent,FromUserId,ToUserId,ReservationMsgTime) values (@infoId,@content,@fromuserid,@touserid,@msgtime)";

        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        String sql_toUserId = "select UserId from ReservationInfo where ReservationInfoId = " + Request.QueryString["r_id"];
        String toUserId = db.GetDataSet(sql_toUserId, null).Tables[0].DefaultView[0]["UserId"].ToString();
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@infoId", Request.QueryString["r_id"]),
                                   DBConnect.MakeParameter("@content", txtApprovalInfo.Text),
                                   DBConnect.MakeParameter("@fromuserid", Session["UserId"].ToString()),
                                   DBConnect.MakeParameter("@touserid", toUserId),
                                   DBConnect.MakeParameter("@msgtime", DateTime.Now)
                               };
        db.ExecuteSql(sql_msg, paras);
        panelApprovalInfo.Visible = false;
        //发送邮件通知
        String subject = "您预约的设备未通过管理员审批";
        String content = "您好，对不起，您预约的设备未通过审批，原因是：" + txtApprovalInfo.Text + "。请登录网站进行查看。<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "' target='_blanck'>打开</a>";
        CheckSendMail.EquipManagerSendMail(Request.QueryString["r_id"], subject, content);
        Response.Redirect("nEquipManagerHome.aspx");
    }
    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        panelApprovalInfo.Visible = false;
    }
    protected void ImgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "update ReservationInfo set StateId = 10 where ReservationInfoId = " + Request.QueryString["r_id"]; //10代表通过审批
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        ReservationEnd.AddEquipmentUserCount(Request.QueryString["r_id"]);  //将所涉及到的设备的使用次数加1
        //发送邮件通知
        //发送邮件通知
        String subject = "您预约的设备通过审批";
        String content = "您好，您预约的设备已经通过审批，请登录网站进行查看。<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "' target='_blanck'>打开</a>";
        CheckSendMail.EquipManagerSendMail(Request.QueryString["r_id"], subject, content);
        Response.Redirect("nEquipManagerHome.aspx");
    }
}
