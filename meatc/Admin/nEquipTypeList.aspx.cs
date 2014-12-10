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

public partial class Admin_nEquipTypeList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindEquipTypeList();
        }
    }

    /// <summary>
    /// 绑定设备类型
    /// </summary>
    private void BindEquipTypeList()
    {
        String sql = "select * from EquipmentType order by EquipmentTypeId";
        DBConnect db = new DBConnect();
        GVEquipmentType.DataSource = db.GetDataSet(sql, null);
        GVEquipmentType.DataBind();
    }

    /// <summary>
    /// 显示输入设备类型的输入框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        hf_type.Value = "add";
        TREdit.Visible = true;
    }
    protected void imgBtnEdit_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "";

        if (hf_type.Value == "add")
        {
            sql = "insert into EquipmentType (EquipmentTypeName,EquipmentTypeRemark) values (@typename,@remark)";
        }
        else
        {
            sql = "update EquipmentType set EquipmentTypeName=@typename, EquipmentTypeRemark=@remark where EquipmentTypeId = " + hf_type.Value;
        }
        SqlParameter[] paras = {
                                       DBConnect.MakeParameter("@typename", txtItemTypeName.Text),
                                       DBConnect.MakeParameter("@remark", txtRemark.Text)
                                   };
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);
        TREdit.Visible = false;
        BindEquipTypeList();
    }
    protected void GVEquipmentType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GVEquipmentType.PageIndex = e.NewPageIndex;
        BindEquipTypeList();
    }
    protected void GVEquipmentType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EquipmentTypeUpdate")
        {
            TREdit.Visible = true;
            imgBtnEdit.ImageUrl = "~/Images/BtnUpdate.png";
            hf_type.Value = e.CommandArgument.ToString();
            String sql = "select * from EquipmentType where EquipmentTypeId = " + hf_type.Value;
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            txtItemTypeName.Text = ds.Tables[0].DefaultView[0]["EquipmentTypeName"].ToString();
            txtRemark.Text = ds.Tables[0].DefaultView[0]["EquipmentTypeRemark"].ToString();
        }
        else if (e.CommandName == "EquipmentTypeDel")
        {
            String sql = "delete from EquipmentType where EquipmentTypeId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindEquipTypeList();
        }

    }
}
