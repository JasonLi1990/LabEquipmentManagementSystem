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

public partial class EquipManager_nShowEquipInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
        {
            BindEquipmentInfo();
        }
    }

    private void BindEquipmentInfo()
    {
        String e_id = Request.QueryString["e_id"];
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
            lblInternalPrice.Text = drv["InternalPrice"].ToString();
            lblExternalPrice.Text = drv["ExternalPrice"].ToString();
            lblEquipmentManager.Text = drv["UserName"].ToString() + " 点击查看";
            Session["ManagerId"] = drv["UserId"].ToString(); //设备管理员ID
            lblEquipmentPrice.Text = drv["EquipmentPrice"].ToString();
            lblFrequencyOfUse.Text = drv["FrequencyOfUse"].ToString();
            lblManufacturerName.Text = drv["ManufacturerName"].ToString();
            lblManufacturerPhone.Text = drv["ManufacturerPhone"].ToString();
            lblManufacturerAddress.Text = drv["ManufacturerAddress"].ToString();
            lblPurchaseDate.Text = Convert.ToDateTime(drv["PurchaseDate"]).ToLongDateString();
            lblDeposit.Text = drv["Deposit"].ToString();
            lblWarrantyPeriod.Text = Convert.ToDateTime(drv["WarrantyPeriod"]).ToLongDateString();
            lblWarrantyPhone.Text = drv["WarrantyPhone"].ToString();
            lblNodes.Text = drv["EquipmentNodes"].ToString();
            lblSchoolPrice.Text = drv["StudentPrice"].ToString();
            lblYuChuli.Text = drv["yuchuli"].ToString();

        }
    }

    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        if (Session["UserType"].ToString().Equals("3"))
        {
            
            //Response.Redirect("MyEquipList.aspx");
            //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "e", , true);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "0", "<script>window.history.go(-2);</script>");
            
        }
    }
}
