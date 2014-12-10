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

public partial class Student_nShowIssueOfReservation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            BindReservationInfo();
            if (!Session["UserType"].ToString().Equals("1"))
            {
                TRTeacherInfo1.Visible = false;
                TRTeacherInfo2.Visible = false;
            }
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
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
    protected void lBtnEquipment_Click(object sender, EventArgs e)
    {
        Response.Redirect("nShowEquipOfReservation.aspx?r_id=" + Request.QueryString["r_id"]);
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["UserType"].ToString().Equals("2"))
            Response.Redirect("~/Teacher/nTeacherHome.aspx");
        else
            Response.Redirect("Default.aspx");
    }
}
