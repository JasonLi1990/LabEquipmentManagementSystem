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

public partial class Admin_nEquipManagerPhotoList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindEquipPhotoList();
        }
    }


    /// <summary>
    /// 显示某个设备管理员所管理的设备列表 
    /// </summary>
    public void BindEquipPhotoList()
    {
        String u_id = Request.QueryString["u_id"];
        String sql = "select * from Equipment left join EquipmentType on Equipment.EquipmentTypeId = EquipmentType.EquipmentTypeID where UserId = " + u_id;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            int pageNum = 0;
            int curPage = Convert.ToInt32(lb_page.Text);
            if (pageNum > 0)
                curPage = pageNum;

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = ds.Tables[0].DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = 6;
            ps.CurrentPageIndex = curPage - 1;
            lb_down.Enabled = true;
            lb_first.Enabled = true;
            lb_last.Enabled = true;
            lb_up.Enabled = true;
            if (curPage == 1)
            {
                lb_first.Enabled = false;
                lb_up.Enabled = false;
            }
            if (curPage == ps.PageCount)
            {
                lb_down.Enabled = false;
                lb_last.Enabled = false;
            }
            lb_totalPage.Text = Convert.ToString(ps.PageCount);

            dl_equipList.DataSource = ps;
            dl_equipList.DataBind();
        }
    }

    protected void lb_first_Click(object sender, EventArgs e)
    {
        lb_page.Text = "1";
        BindEquipPhotoList();
    }

    protected void lb_up_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) - 1);
        BindEquipPhotoList();
    }
    protected void lb_down_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) + 1);
        BindEquipPhotoList();
    }

    protected void lb_last_Click(object sender, EventArgs e)
    {
        lb_page.Text = lb_totalPage.Text;
        BindEquipPhotoList();
    }
}
