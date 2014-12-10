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

public partial class EquipManager_nModifyEquipInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindEquipUnit();
            BindEquipInfo();
        }
    }

    private void BindEquipUnit()
    {
        ///绑定设备单位
        DBConnect db = new DBConnect();
        String sql_equipUnit = "select * from EquipmentUnit order by EquipmentUnitId";
        DataSet ds = db.GetDataSet(sql_equipUnit, null);
        DDLEquipmentUnit.DataSource = ds;
        DDLEquipmentUnit.DataTextField = "EquipmentUnitName";
        DDLEquipmentUnit.DataValueField = "EquipmentUnitId";
        DDLEquipmentUnit.DataBind();
    }

    public void BindEquipInfo()
    {

        String e_id = Request.QueryString["e_id"];
        String sql = "select * from Equipment where EquipmentId = " + e_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            txtEquipmentName.Text = drv["EquipmentName"].ToString();
            txtEquipmentModel.Text = drv["EquipmentModel"].ToString();
            txtYuChuliFei.Text = drv["Yuchuli"].ToString();
            ddl_startday.SelectedValue = drv["StartDay"].ToString();
            DDLBilling.SelectedValue = drv["Billing"].ToString();
            DDLEquipmentUnit.SelectedValue = drv["EquipmentUnitId"].ToString();
            txtRemark.Text = drv["EquipmentRemark"].ToString();
            txtNodes.Text = drv["EquipmentNodes"].ToString();
            txtInternalPrice.Text = drv["InternalPrice"].ToString();
            txtStudentPrice.Text = drv["StudentPrice"].ToString();
            txtExternalPrice.Text = drv["ExternalPrice"].ToString();
            txtDeposit.Text = drv["Deposit"].ToString();
            img_show.ImageUrl = drv["EquipmentPhotoPath"].ToString();
            if (drv["IsZhouMoOpen"].ToString().Equals("1"))
                cb_zhoumo.Checked = true;
        }
    }

    protected void btSave_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "update Equipment set YuChuli = @yuchuli,StartDay=@startday,Billing=@billing,EquipmentUnitId=@unitid,EquipmentRemark=@remark,EquipmentNodes=@nodes,EquipmentName=@equipmentName,InternalPrice=@internal,StudentPrice=@studentprice,ExternalPrice=@external,Deposit=@deposit,EquipmentPhotoPath=@photopath,IsZhouMoOpen=@zhoumo where EquipmentId = " + Request.QueryString["e_id"];
        String photoPath = img_show.ImageUrl;
        if (FUEquipmentPhoto.PostedFile.FileName.Length > 0)
        {
            String fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            ///文件上传
            String path = Server.MapPath("~/EquipmentPhotos/");
            photoPath = "~/EquipmentPhotos/" + fileName;
            FUEquipmentPhoto.PostedFile.SaveAs(path + fileName);

        }
        int zhoumo = 0;
        if (cb_zhoumo.Checked)
        {
            zhoumo = 1;
        }
        SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@yuchuli", txtYuChuliFei.Text),
                                   DBConnect.MakeParameter("@startday", ddl_startday.SelectedItem.Value),
                                   DBConnect.MakeParameter("@billing", DDLBilling.SelectedItem.Value),
                                   DBConnect.MakeParameter("@unitid", DDLEquipmentUnit.SelectedItem.Value),
                                   DBConnect.MakeParameter("@remark", txtRemark.Text),
                                   DBConnect.MakeParameter("@nodes", txtNodes.Text),
                                   DBConnect.MakeParameter("@equipmentName", txtEquipmentName.Text),
                                   DBConnect.MakeParameter("@internal", txtInternalPrice.Text),
                                   DBConnect.MakeParameter("@studentprice", txtStudentPrice.Text),
                                   DBConnect.MakeParameter("@external", txtExternalPrice.Text),
                                   DBConnect.MakeParameter("@deposit", txtDeposit.Text),
                                   DBConnect.MakeParameter("@photopath", photoPath),
                                   DBConnect.MakeParameter("@zhoumo", zhoumo)
                               };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('信息修改成功!');window.location.href='nMyEquipList.aspx';</script>");
    }
}
