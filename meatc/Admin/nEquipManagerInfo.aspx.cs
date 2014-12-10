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

public partial class Admin_nEquipManagerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
            BindEquipmentManagerInfo();
    }

    /// <summary>
    /// 显示设备管理员信息
    /// </summary>
    public void BindEquipmentManagerInfo()
    {
        String u_id = Request.QueryString["u_id"];
        String sql = "select * from Users where UserId = " + u_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lblLoginName.Text = drv["LoginName"].ToString();
            lblName.Text = drv["UserName"].ToString();
            lblSex.Text = drv["UserSex"].ToString().Equals("1") ? "男" : "女";
            lblBirthDate.Text = Convert.ToDateTime(drv["BirthDate"]).ToLongDateString();
            lblPhone.Text = drv["UserPhone"].ToString();
            lblMobileTelephone.Text = drv["MobileTelephone"].ToString();
            lblEmail.Text = drv["UserEmail"].ToString();

        }
    }

    /// <summary>
    /// 显示该设备管理员所管理的设备
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnEquipment_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("nEquipManagerPhotoList.aspx?u_id=" + Request.QueryString["u_id"]);
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "0", "<script>window.history.go(-2);</script>");
    }
}
