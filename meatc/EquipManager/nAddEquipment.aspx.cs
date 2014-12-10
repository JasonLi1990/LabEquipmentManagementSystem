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

public partial class Admin_nAddEquipment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 3);
        if (!IsPostBack)
        {
            BindEquipBasicInfo();
        }
    }

    /// <summary>
    /// 绑定设备所需要的一些信息，添加设备与修改设备信息都需要
    /// </summary>
    private void BindEquipBasicInfo()
    {
        ///绑定设备类型
        String sql_equipType = "select * from EquipmentType order by EquipmentTypeId";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql_equipType, null);
        ddlEquipmentType.DataSource = ds;
        ddlEquipmentType.DataBind();
        ddlEquipmentType.Items.Insert(0, new ListItem("请选择", "0"));

        ///绑定设备管理员列表
        String sql_equipManager = "select * from Users where UserType = 3 order by UserId";
        ds = db.GetDataSet(sql_equipManager, null);
        ddlEquipmentManager.DataSource = ds;
        ddlEquipmentManager.DataTextField = "UserName";
        ddlEquipmentManager.DataValueField = "UserId";
        ddlEquipmentManager.DataBind();
        ddlEquipmentManager.Items.Insert(0, new ListItem("请选择", "0"));

        ///绑定设备单位
        String sql_equipUnit = "select * from EquipmentUnit order by EquipmentUnitId";
        ds = db.GetDataSet(sql_equipUnit, null);
        DDLEquipmentUnit.DataSource = ds;
        DDLEquipmentUnit.DataTextField = "EquipmentUnitName";
        DDLEquipmentUnit.DataValueField = "EquipmentUnitId";
        DDLEquipmentUnit.DataBind();

    }
    /// <summary>
    /// 录入设备信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlEquipmentType.SelectedItem.Value.Equals("0"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设备类型未选择');</script>");
            return;
        }
         String fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            ///文件上传
            String path = Server.MapPath("~/EquipmentPhotos/");
            String savePath = "~/EquipmentPhotos/" + fileName;
            FUEquipmentPhoto.PostedFile.SaveAs(path + fileName);

            ///将信息写入数据库
            String sql = "insert into Equipment (EquipmentName,EquipmentTypeId, EquipmentModel,EquipmentPhotoPath, EquipmentNodes, UserId, EquipmentPrice, ManufacturerName, ManufacturerAddress, ManufacturerPhone, PurchaseDate, FrequencyOfUse, WarrantyPeriod, WarrantyPhone, ExternalPrice, InternalPrice, StudentPrice, Deposit, EquipmentRemark, Billing, EquipmentUnitId, StateId, StartDay,IsCheck) values (@equipName," + ddlEquipmentType.SelectedItem.Value + ", @equipModel, '" + savePath + "', @notes, " + Session["UserId"].ToString() + ", @equipPrice, @equipManufactor, @equipManufactorAddress,@equipManufactorPhone, @equipPurchaseDate, @equipFrequency, @equipWarrantyDate,@equipWarrantyPhone, @externalPrice, @internalPrice, @studentPrice, @deposit, @remark, @biling, @equipUnit, 21, @startday, 0)";
            SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@equipName", txtEquipmentName.Text),                                   
                                   DBConnect.MakeParameter("@equipModel", txtEquipmentModel.Text),
                                   DBConnect.MakeParameter("@equipPrice", txtEquipmentPrice.Text),
                                   DBConnect.MakeParameter("@equipFrequency", txtFrequencyOfUse.Text),
                                   DBConnect.MakeParameter("@equipManufactor", txtManufacturerName.Text),   //生产厂家
                                   DBConnect.MakeParameter("@equipManufactorPhone", txtManufacturerPhone.Text),
                                   DBConnect.MakeParameter("@equipManufactorAddress", txtManufacturerAddress.Text),
                                   DBConnect.MakeParameter("@equipPurchaseDate", txtPurchaseDate.Text),
                                   DBConnect.MakeParameter("@equipWarrantyDate", txtWarrantyPeriod.Text),
                                   DBConnect.MakeParameter("@internalPrice", txtInternalPrice.Text),
                                   DBConnect.MakeParameter("@equipWarrantyPhone",txtWarrantyPhone.Text),
                                   DBConnect.MakeParameter("@studentPrice", txtStudentPrice.Text),
                                   DBConnect.MakeParameter("@externalPrice", txtExternalPrice.Text),
                                   DBConnect.MakeParameter("@deposit", txtDeposit.Text),
                                   DBConnect.MakeParameter("@biling", DDLBilling.SelectedItem.Value),
                                   DBConnect.MakeParameter("@equipUnit", DDLEquipmentUnit.SelectedItem.Value),
                                   DBConnect.MakeParameter("@remark", txtRemark.Text),
                                   DBConnect.MakeParameter("@startday", ddl_startday.SelectedItem.Value),
                                   DBConnect.MakeParameter("@notes", txtNodes.Text)    //设备说明                                                                      
                               };
            DBConnect db = new DBConnect();
            for (int i = 0; i < Convert.ToInt32(ddl_equipnumber.SelectedItem.Value); i++)
            {
                db.ExecuteSql(sql, paras);
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('共成功录入" + ddl_equipnumber.SelectedItem.Value + "台设备！');window.location.href='nMyEquipList.aspx';</script>");

        
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>window.history.go(-2);</script>");
    }
}
