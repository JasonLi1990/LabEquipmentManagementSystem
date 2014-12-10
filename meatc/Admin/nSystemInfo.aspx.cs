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

public partial class Admin_nSystemInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSystemInfo();
            //BindEquipmentList();
        }
    }

    public void BindSystemInfo()
    {
        DBConnect db = new DBConnect();
        String sql = "select * from SystemInfo order by SystemId desc";
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            gv_systemInfo.DataSource = ds;
            gv_systemInfo.DataBind();
        }
    }

    
    protected void imgBtnSaveSystemInfo_Click(object sender, ImageClickEventArgs e)
    {
        if (hd_SystemInfoId.Value != null && hd_SystemInfoId.Value.Length > 0)
        {
            DBConnect db = new DBConnect();
            String sql = "update SystemInfo set SystemBulletin = @systeminfo where SystemId = " + hd_SystemInfoId.Value;
            SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@systeminfo", txtSystemBulletin.Text)
                               };
            db.ExecuteSql(sql, paras);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功！')</script>");
            BindSystemInfo();
        }
    }
    protected void gv_systemInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_systemInfo.PageIndex = e.NewPageIndex;
        BindSystemInfo();
    }
    protected void gv_systemInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sql = "";
        DBConnect db = new DBConnect();
        if (e.CommandName == "SystemInfoEdit")
        {
            sql = "select * from SystemInfo where SystemId = " + e.CommandArgument;
            DataSet ds = db.GetDataSet(sql, null);
            hd_SystemInfoId.Value = e.CommandArgument.ToString();
            txtSystemBulletin.Text = ds.Tables[0].DefaultView[0]["SystemBulletin"].ToString();
        }
        else if (e.CommandName == "SystemInfoDelete")
        {
            sql = "delete from SystemInfo where SystemId = " + e.CommandArgument;
            db.ExecuteSql(sql, null);
            BindSystemInfo();
        }
    }
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        DBConnect db = new DBConnect();
        String sql = "insert into SystemInfo (SystemBulletin,PublishTime) values (@systeminfo,@publishtime)";
        SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@systeminfo", txtSystemBulletin.Text),
                                   DBConnect.MakeParameter("@publishtime", DateTime.Now)
                               };
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('成功发布新的系统公告！')</script>");
        BindSystemInfo();
    }
}
