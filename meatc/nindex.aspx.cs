using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.form1.DefaultButton = "ImageButton1";
        if (!IsPostBack)
        {
            BindSystemInfo();
            BindPhotoList();
        }
    }
    /// <summary>
    /// 用户登录 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        String username = txtName.Text;
        String password = txtPw.Text;
        String session_id = null;
        if (!(session_id = LoginCheck.CheckUser(username, password, 1)).Equals("0"))    //院内学生
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 1;
            Response.Redirect("~/Student/Default.aspx");
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, 0)).Equals("0"))   //校外学生
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 0;
            String sql = "select StateId from Users where UserId = " + session_id;
            DBConnect db = new DBConnect();
            String stateid = db.GetDataSet(sql, null).Tables[0].DefaultView[0]["StateId"].ToString();
            if (stateid.Equals("1"))
                Response.Redirect("~/Student/Default.aspx");
            else
            {
                Session["StateId"] = stateid;
                Response.Redirect("~/RegisterResult.aspx");
            }
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, 2)).Equals("0"))   //导师
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 2;
            Response.Redirect("~/Teacher/nTeacherHome.aspx");
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, 3)).Equals("0"))   //设备管理员
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 3;
            Response.Redirect("~/EquipManager/nEquipManagerHome.aspx");
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, 4)).Equals("0"))   //系统管理员
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 4;
            Response.Redirect("~/Admin/nAdminHome.aspx");
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, 5)).Equals("0"))   //本校学生
        {
            Session["UserId"] = session_id;
            Session["UserType"] = 5;
            String sql = "select StateId from Users where UserId = " + session_id;
            DBConnect db = new DBConnect();
            String stateid = db.GetDataSet(sql, null).Tables[0].DefaultView[0]["StateId"].ToString();
            if (stateid.Equals("1"))
                Response.Redirect("~/Student/Default.aspx");
            else
            {
                Session["StateId"] = stateid;
                Response.Redirect("~/RegisterResult.aspx");
            }
        }
        else if (!(session_id = LoginCheck.CheckUser(username, password, -1)).Equals("0"))   //总管理员
        {
            Session["UserId"] = session_id;
            Session["UserType"] = -1;
            Response.Redirect("~/AdminSuper/AdminManagerList.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('账号或密码不正确！');</script>");
        }
    }

    /// <summary>
    /// 绑定系统相关信息
    /// </summary>
    private void BindSystemInfo()
    {
        String sql = "select top 1 * from SystemInfo order by SystemId desc";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            lb_systemInfo.Text = ds.Tables[0].DefaultView[0]["SystemBulletin"].ToString();
        }
    }

    /// <summary>
    /// 绑定展示于前台的照片
    /// </summary>
    private void BindPhotoList()
    {
        String sql = "select * from Equipment where IsShow = 1 and EquipmentPhotoPath is not null";//改动2014.1.08 -- by lgq
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            dl_photos.DataSource = ds;
            dl_photos.DataBind();
        }
    }
    protected void dl_photos_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ShowEquipment")
        {
            BindEquipmentInfo(e.CommandArgument.ToString());
            panel_showEquip.Visible = true;
        }
    }
    protected void lb_regist_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        txtName.Text = "";
        txtPw.Text = "";
    }

    private void BindEquipmentInfo(String e_id)
    {
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeId left join Users on Equipment.UserId = Users.UserId where EquipmentId = " + e_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            imgEquipmentPhoto.ImageUrl = drv["EquipmentPhotoPath"].ToString();
            lblEquipmentName.Text = drv["EquipmentName"].ToString();
            lblEquipmentModel.Text = drv["EquipmentModel"].ToString();
            lblEquipmentType.Text = drv["EquipmentTypeName"].ToString();
            //lblInternalPrice.Text = drv["InternalPrice"].ToString();
            //lblExternalPrice.Text = drv["ExternalPrice"].ToString();
            lblEquipmentManager.Text = drv["UserName"].ToString();
            //lblEquipmentPrice.Text = drv["EquipmentPrice"].ToString();
            //lblFrequencyOfUse.Text = drv["FrequencyOfUse"].ToString();
            //lblManufacturerName.Text = drv["ManufacturerName"].ToString();
            //lblManufacturerPhone.Text = drv["ManufacturerPhone"].ToString();
            //lblManufacturerAddress.Text = drv["ManufacturerAddress"].ToString();
            //lblPurchaseDate.Text = Convert.ToDateTime(drv["PurchaseDate"]).ToLongDateString();
            lblDeposit.Text = drv["Deposit"].ToString();
            //lblWarrantyPeriod.Text = Convert.ToDateTime(drv["WarrantyPeriod"]).ToLongDateString();
            //lblWarrantyPhone.Text = drv["WarrantyPhone"].ToString();
            lblNodes.Text = drv["EquipmentNodes"].ToString();
        }
    }
    protected void imgBtnPasswordClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
