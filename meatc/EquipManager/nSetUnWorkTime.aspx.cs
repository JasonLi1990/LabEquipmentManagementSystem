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

public partial class EquipManager_nSetUnWorkTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindUnWorkTime();
    }

    public void BindUnWorkTime()
    {
        String sql = "select * from ReservationTime where UserId = " + Session["UserId"].ToString() + " order by TimeId desc";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        gv_unworkList.DataSource = ds;
        gv_unworkList.DataBind();
    }
    protected void bt_add_Click(object sender, EventArgs e)
    {
        String sql = "insert into ReservationTime (TimeStart,TimeEnd,Reason,UserId) values (@start,@end,@reason,@userid)";
        SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@start", Convert.ToDateTime(txtStartDate.Value)),
                                   DBConnect.MakeParameter("@end", Convert.ToDateTime(txtEndDate.Value)),
                                   DBConnect.MakeParameter("@reason", tb_reason.Text),
                                   DBConnect.MakeParameter("@userid", Session["UserId"])
                               };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        BindUnWorkTime();
    }
    protected void gv_unworkList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_unworkList.PageIndex = e.NewPageIndex;
        BindUnWorkTime();
    }
    protected void gv_unworkList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelUnWork")
        {
            String sql = "delete from ReservationTime where TimeId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindUnWorkTime();
        }
    }
}
