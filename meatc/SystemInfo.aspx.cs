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
        if (!IsPostBack)
        {
            ShowInfo();
            BindSystemInfo();
        }
    }

    private void ShowInfo()
    {
        String infoId = Request.QueryString["id"];
        String sql = "";
        DBConnect db = new DBConnect();
        if (infoId == null || infoId.Length == 0)
        {
            sql = "select top 1 * from SystemInfo order by SystemId desc";
        }
        else
        {
            sql = "select * from SystemInfo where SystemId = " + infoId;
        }

        DataSet ds = db.GetDataSet(sql, null);
        lb_systemInfoTime.Text = Convert.ToDateTime(ds.Tables[0].DefaultView[0]["PublishTime"]).ToLongDateString();
        lb_systeminfoContent.Text = ds.Tables[0].DefaultView[0]["SystemBulletin"].ToString();
    }

    private void BindSystemInfo()
    {
        String sql = "select * from SystemInfo order by SystemId desc";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            int curPage = Convert.ToInt32(lb_page.Text);            

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = ds.Tables[0].DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = 10;
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
            rp_notes.DataSource = ps;
            rp_notes.DataBind();
        }

    }

    protected void lb_first_Click(object sender, EventArgs e)
    {
        lb_page.Text = "1";
        BindSystemInfo();
    }

    protected void lb_up_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) - 1);
        BindSystemInfo();
    }
    protected void lb_down_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) + 1);
        BindSystemInfo();
    }

    protected void lb_last_Click(object sender, EventArgs e)
    {
        lb_page.Text = lb_totalPage.Text;
        BindSystemInfo();
    }
}
