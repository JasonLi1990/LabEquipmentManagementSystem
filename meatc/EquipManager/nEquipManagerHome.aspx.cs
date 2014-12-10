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

public partial class EquipManager_nEquipManagerHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null)
            {
                stu_type = Convert.ToInt32(Request.QueryString["type"]);
                BindReservationList(stu_type);
                
            }
            else
            {
                BindReservationList(stu_type);
            }
            //BindWeekPlan();
        }
    }

    private int stu_type = -1;

    /// <summary>
    /// 绑定预约信息
    /// </summary>
    private void BindReservationList(int UserType)
    {
        String UserId = Session["UserId"].ToString();  //设备管理员的UserId
        String sql = "";
        if (UserType == -1)
            sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where ReservationInfoId in(select ReservationInfoId from Reservation where EquipmentId in (select EquipmentId from Equipment where UserId = " + UserId + ")) order by ReservationInfoId desc";
        else
        {
            sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where UserType = " + UserType + " and ReservationInfoId in(select ReservationInfoId from Reservation where EquipmentId in (select EquipmentId from Equipment where UserId = " + UserId + ")) order by ReservationInfoId desc";
        }
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < GVTeacher.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        if (GVTeacher.PageCount > 0)
        {
            ddl_page.SelectedIndex = GVTeacher.PageIndex;
        }
        
    }

    protected void first_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = 0;
        BindReservationList(stu_type);
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex >= 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex - 1;           
        }
        BindReservationList(stu_type);
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex < GVTeacher.PageCount - 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex + 1;            
        }
        BindReservationList(stu_type);
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = GVTeacher.PageCount - 1;
        BindReservationList(stu_type);
    }
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = ddl_page.SelectedIndex;
        BindReservationList(stu_type);
    }

    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F000'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "1")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople03.jpg";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "0")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople02.png";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "5")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople01.png";
            }
            else if (((HiddenField)e.Row.Cells[0].FindControl("HFUserType")).Value == "2")
            {
                ((Image)e.Row.Cells[0].FindControl("imgSchool")).ImageUrl = "~/Images/Pople04.JPG";
            }

            if (e.Row.Cells[6].Text != "待管理员审批")
                e.Row.Cells[7].Text = "";
        }
    }
    protected void GVTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sql = "";
        if (e.CommandName == "ShowIssueName")   //显示课题信息
        {
            Response.Redirect("nShowIssue.aspx?r_id=" + e.CommandArgument);
        }
        else if (e.CommandName == "ReservationOK")  //通过最终审批
        {
            sql = "update ReservationInfo set StateId = 10 where ReservationInfoId = " + e.CommandArgument; //10代表通过审批
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            ReservationEnd.AddEquipmentUserCount(e.CommandArgument.ToString()); //将相关的实验设备使用次数都加1
            //发送邮件通知
            String subject = "您预约的设备通过审批";
            String content = "您好，您预约的设备已经通过审批，请登录网站进行查看。<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "' target='_blanck'>打开</a>";
            CheckSendMail.EquipManagerSendMail(e.CommandArgument.ToString(), subject, content);

            BindReservationList(-1);
        }
        else if (e.CommandName == "ReservationNO")  //未通过审批
        {
            hf_ReservationId.Value = e.CommandArgument.ToString();
            panelApprovalInfo.Visible = true;

            //sql = "update ReservationInfo set StateId = 15 where ReservationInfoId = " + e.CommandArgument; //15代表未通过管理员审批
        }

    }
    protected void GVTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVTeacher.PageIndex = e.NewPageIndex;
        BindReservationList(-1);
    }


    protected void imgBtnApprovalInfoOK_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "update ReservationInfo set StateId = 15 where ReservationInfoId = " + hf_ReservationId.Value; //15代表未通过管理员审批
        String sql_msg = "Insert into ReservationMsg (ReservationInfoID,ReservationMsgContent,FromUserId,ToUserId,ReservationMsgTime) values (@infoId,@content,@fromuserid,@touserid,@msgtime)";

        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        String sql_toUserId = "select UserId from ReservationInfo where ReservationInfoId = " + hf_ReservationId.Value;
        String toUserId = db.GetDataSet(sql_toUserId, null).Tables[0].DefaultView[0]["UserId"].ToString();
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@infoId", hf_ReservationId.Value),
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
        CheckSendMail.EquipManagerSendMail(hf_ReservationId.Value, subject, content);
        BindReservationList(-1);
    }
    protected void imgBtnClose_Click(object sender, ImageClickEventArgs e)
    {
        panelApprovalInfo.Visible = false;
        BindReservationList(-1);
    }
    

    /// <summary>
    /// 筛选校内学生
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSchool_Click(object sender, ImageClickEventArgs e)
    {
        Session["SelectType"] = 5;
        BindReservationList(5);
    }
    protected void imgBtnOutSide_Click(object sender, ImageClickEventArgs e)
    {
        Session["SelectType"] = 0;
        BindReservationList(0);
    }
    protected void imgBtnInner_Click(object sender, ImageClickEventArgs e)
    {
        Session["SelectType"] = 1;
        BindReservationList(1);
    }
    protected void imgBtnTeacher_Click(object sender, ImageClickEventArgs e)
    {
        Session["SelectType"] = 2;
        BindReservationList(2);
    }
    
}
