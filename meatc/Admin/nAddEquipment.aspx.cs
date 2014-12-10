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
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindEquipBasicInfo();
            if (Request.QueryString["e_id"] != null)    //修改设备属性
            {
                imgBtnEdit.ImageUrl = "~/Images/BtnUpdate.png";
                cb_changephoto.Visible = true;
                BindModifyEquipInfo(Request.QueryString["e_id"]);

            }
            else//添加新设备
            {

            }
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
        ddlEquipmentType.Items.Insert(0, new ListItem("请选择","0"));

        ///绑定设备管理员列表
        String sql_equipManager = "select * from Users where UserType = 3 order by UserId";
        ds = db.GetDataSet(sql_equipManager, null);
        ddlEquipmentManager.DataSource = ds;
        ddlEquipmentManager.DataTextField = "UserName";
        ddlEquipmentManager.DataValueField = "UserId";
        ddlEquipmentManager.DataBind();
        ddlEquipmentManager.Items.Insert(0, new ListItem("请选择","0"));

        ///绑定设备单位
        String sql_equipUnit = "select * from EquipmentUnit order by EquipmentUnitId";
        ds = db.GetDataSet(sql_equipUnit, null);
        DDLEquipmentUnit.DataSource = ds;
        DDLEquipmentUnit.DataTextField = "EquipmentUnitName";
        DDLEquipmentUnit.DataValueField = "EquipmentUnitId";
        DDLEquipmentUnit.DataBind();

    }

    /// <summary>
    /// 修改设备信息时，将信息绑定在输入框中
    /// </summary>
    private void BindModifyEquipInfo(String e_id)
    {
        String sql = "select * from Equipment where EquipmentId = " + e_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        DataRowView drv = ds.Tables[0].DefaultView[0];
        txtEquipmentName.Text = drv["EquipmentName"].ToString();
        txtEquipmentModel.Text = drv["EquipmentModel"].ToString();
        txtEquipmentPrice.Text = drv["EquipmentPrice"].ToString();
        txtFrequencyOfUse.Text = drv["FrequencyOfUse"].ToString();
        txtManufacturerName.Text = drv["ManufacturerName"].ToString();
        txtManufacturerPhone.Text = drv["ManufacturerPhone"].ToString();
        txtManufacturerAddress.Text = drv["ManufacturerAddress"].ToString();
        txtPurchaseDate.Text = drv["PurchaseDate"].ToString();
        txtWarrantyPeriod.Text = drv["WarrantyPeriod"].ToString();
        txtInternalPrice.Text = drv["InternalPrice"].ToString();
        txtStudentPrice.Text = drv["StudentPrice"].ToString();
        txtExternalPrice.Text = drv["ExternalPrice"].ToString();
        txtWarrantyPhone.Text = drv["WarrantyPhone"].ToString();
        txtDeposit.Text = drv["Deposit"].ToString();
        txtRemark.Text = drv["EquipmentRemark"].ToString();
        txtNodes.Text = drv["EquipmentNodes"].ToString();
        img_show.ImageUrl = drv["EquipmentPhotoPath"].ToString();
        DDLBilling.SelectedValue = drv["Billing"].ToString();
        ddl_startday.SelectedValue = drv["StartDay"].ToString();
        ddlEquipmentType.SelectedValue = drv["EquipmentTypeId"].ToString();
        ddlEquipmentManager.SelectedValue = drv["UserId"].ToString();
        DDLEquipmentUnit.SelectedValue = drv["EquipmentUnitId"].ToString();

    }

    /// <summary>
    /// 录入设备信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlEquipmentManager.SelectedItem.Value.Equals("0") || ddlEquipmentType.SelectedItem.Value.Equals("0"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('设备管理员或设备类型未选择');</script>");
            return;
        }
        if (Request.QueryString["e_id"] == null)
        {
            String fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            ///文件上传
            String path = Server.MapPath("~/EquipmentPhotos/");
            String savePath = "~/EquipmentPhotos/" + fileName;
            FUEquipmentPhoto.PostedFile.SaveAs(path + fileName);

            ///将信息写入数据库
            String sql = "insert into Equipment (EquipmentName,EquipmentTypeId, EquipmentModel,EquipmentPhotoPath, EquipmentNodes, UserId, EquipmentPrice, ManufacturerName, ManufacturerAddress, ManufacturerPhone, PurchaseDate, FrequencyOfUse, WarrantyPeriod, WarrantyPhone, ExternalPrice, InternalPrice, StudentPrice, Deposit, EquipmentRemark, Billing, EquipmentUnitId, StateId, StartDay,IsCheck) values (@equipName," + ddlEquipmentType.SelectedItem.Value + ", @equipModel, '" + savePath + "', @notes, " + ddlEquipmentManager.SelectedItem.Value + ", @equipPrice, @equipManufactor, @equipManufactorAddress,@equipManufactorPhone, @equipPurchaseDate, @equipFrequency, @equipWarrantyDate,@equipWarrantyPhone, @externalPrice, @internalPrice, @studentPrice, @deposit, @remark, @biling, @equipUnit, 21, @startday, 0)";
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
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('共成功录入" + ddl_equipnumber.SelectedItem.Value + "台设备！');window.location.href='nEquipmentList.aspx';</script>");

        }
        //修改设备信息
        else
        {
            String sql = "";
            if (cb_changephoto.Checked == true && FUEquipmentPhoto.PostedFile.FileName.Length > 0)
            {
                String fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                ///文件上传
                String path = Server.MapPath("~/EquipmentPhotos/");
                String savePath = "~/EquipmentPhotos/" + fileName;
                FUEquipmentPhoto.PostedFile.SaveAs(path + fileName);

                ///将信息写入数据库
                sql = "update Equipment set EquipmentName=@equipName,EquipmentTypeId=" + ddlEquipmentType.SelectedItem.Value + ", EquipmentModel=@equipModel,EquipmentPhotoPath='" + savePath + "', EquipmentNodes=@notes, UserId=" + ddlEquipmentManager.SelectedItem.Value + ", EquipmentPrice=@equipPrice, ManufacturerName=@equipManufactor, ManufacturerAddress=@equipManufactorAddress, ManufacturerPhone=@equipManufactorPhone, PurchaseDate=@equipPurchaseDate, FrequencyOfUse=@equipFrequency, WarrantyPeriod=@equipWarrantyDate, WarrantyPhone=@equipWarrantyPhone, ExternalPrice=@externalPrice, InternalPrice=@internalPrice, StudentPrice=@studentPrice, Deposit=@deposit, EquipmentRemark=@remark, Billing=@biling, EquipmentUnitId=@equipUnit, StartDay=@startday where EquipmentId = " + Request.QueryString["e_id"];
            }
            else
            {
                sql = "update Equipment set EquipmentName=@equipName,EquipmentTypeId=" + ddlEquipmentType.SelectedItem.Value + ", EquipmentModel=@equipModel, EquipmentNodes=@notes, UserId=" + ddlEquipmentManager.SelectedItem.Value + ", EquipmentPrice=@equipPrice, ManufacturerName=@equipManufactor, ManufacturerAddress=@equipManufactorAddress, ManufacturerPhone=@equipManufactorPhone, PurchaseDate=@equipPurchaseDate, FrequencyOfUse=@equipFrequency, WarrantyPeriod=@equipWarrantyDate, WarrantyPhone=@equipWarrantyPhone, ExternalPrice=@externalPrice, InternalPrice=@internalPrice, StudentPrice=@studentPrice, Deposit=@deposit, EquipmentRemark=@remark, Billing=@biling, EquipmentUnitId=@equipUnit,StartDay=@startday where EquipmentId = " + Request.QueryString["e_id"];
            }
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
            db.ExecuteSql(sql, paras);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改设备信息成功！');window.location.href='nEquipmentList.aspx';</script>");

        }
    }
    protected void imgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>window.history.go(-2);</script>");
    }
}
