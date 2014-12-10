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
using System.Text;
using System.IO;

public partial class Admin_ReportToTeacher : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"] != null && Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
            isShow = false;
            
        }
        else if (Session["UserType"] != null )
        {
            if(Session["UserType"].ToString().Equals("0") || Session["UserType"].ToString().Equals("1") || Session["UserType"].ToString().Equals("5"))
            {
                this.MasterPageFile = "~/Student/S_MasterPage.master";
                
                isShow = false;
            }
        }
        
    }
    private bool isShow = true;
    protected void Page_Load(object sender, EventArgs e)
    {       
        if (!IsPostBack)
        {
            BindReport();
            CalculateSum();
            if(!isShow)
                bt_toTeacher.Visible = false;
        }
    }
    private static String IDs = "";
    private void BindReport()
    {
        String[] ReservationInfoIds = Session["ReservationInfoIds"].ToString().Split('@');
        int i = 0;
        String InfoIds = "";
        for (i = 0; i < ReservationInfoIds.Length - 1; i++)
        {
            InfoIds += (ReservationInfoIds[i] + ",");
        }
        InfoIds += ReservationInfoIds[i];
        IDs = InfoIds;        
        String sql = "select Reservation.EquipmentId,EquipmentName,Price,EquipmentUnitName,EquipmentNum,UserName,BeginReservationTime,Totle from Reservation left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId where ReservationInfo.ReservationInfoId in ("+ InfoIds + ")";
        DBConnect db = new DBConnect();
        gv_report.DataSource = db.GetDataSet(sql, null);
        gv_report.DataBind();
    }


    private void CalculateSum()
    {
        double sum = 0.0;
        for (int i = 0; i < gv_report.Rows.Count; i++)
        {
            sum += Convert.ToDouble(gv_report.Rows[i].Cells[6].Text);
        }
        
        gv_report.FooterRow.Cells[6].Text =  "总和：" +sum.ToString() + "元";
        
    }

    protected void gv_report_RowDataBound(object sender, GridViewRowEventArgs e)
    {        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = (e.Row.RowIndex + 1).ToString();
            
        }
    }
    protected void bt_excel_Click(object sender, EventArgs e)
    {
        Export("application/ms-excel", "申请信息报表.xls");
    }

    public void Export(String fileType, String fileName)
    {
        Response.Charset = "gb2312";
        Response.ContentEncoding = Encoding.UTF7;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, Encoding.UTF8).ToString());
        Response.ContentType = fileType;
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        gv_report.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }
    protected void bt_toTeacher_Click(object sender, EventArgs e)
    {
        if (Session["TeacherId"] != null)
        {
            String sql = "select UserEmail from Users where UserId = " + Session["TeacherId"].ToString();
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            String email = ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
            String content = "预约编号：" + IDs;
            MainSend.SendMail(email, "市政预约系统-预约报表", content);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发送成功,内容：" + content + "')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('此报表不是针对一个老师的报表')</script>");
        }
    }
}
