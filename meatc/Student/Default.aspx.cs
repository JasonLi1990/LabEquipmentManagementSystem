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
using System.Drawing;

public partial class Student_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.CheckSession(this.Page);
            BindReservationList();
        }
    }

    /// <summary>
    /// 绑定已经预约的课题列表
    /// </summary>
    private void BindReservationList()
    {
        String UserId = Session["UserId"].ToString();//"821"; 
        String sql = "select * from ReservationInfo left join State on ReservationInfo.StateId = State.StateId where UserId = " + UserId + " order by ReservationInfoId desc";

        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();

        double total = 0.0;
        for (int i = 0; i < GVTeacher.Rows.Count; i++)
        {
            total += (Convert.ToDouble(GVTeacher.Rows[i].Cells[1].Text));
        }
        lblTotal.Text = total.ToString();
        ddl_page.Items.Clear();
        for (int i = 0; i < GVTeacher.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        ddl_page.SelectedIndex = GVTeacher.PageIndex;
    }

    protected void first_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = 0;
        BindReservationList();
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex >= 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex - 1;
        }
        BindReservationList();
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex < GVTeacher.PageCount - 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex + 1;
        }
        BindReservationList();
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = GVTeacher.PageCount - 1;
        BindReservationList();
    }
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = ddl_page.SelectedIndex;
        BindReservationList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F00F'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (e.Row.Cells[2].Text == "通过审批" || e.Row.Cells[2].Text == "未通过管理员审批")
            {
                e.Row.Cells[5].BackColor = Color.Red;
                e.Row.Cells[5].Text = "不能取消预约";
            }
            else if (e.Row.Cells[2].Text == "待管理员审批" && Session["UserType"].ToString().Equals("1"))   //本院学生，已经经过导师审批
            {
                e.Row.Cells[5].BackColor = Color.Red;
                e.Row.Cells[5].Text = "不能取消预约";
            }
            else if (e.Row.Cells[2].Text == "取消预约")
            {
                e.Row.Cells[5].BackColor = Color.Blue;
                e.Row.Cells[5].Text = "已取消预约";
            }
        }
    }


    protected void GVTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DelIssue")
        {
            String sql = "update ReservationInfo set StateId = 16 where ReservationInfoId = " + e.CommandArgument;
            DBConnect db = new DBConnect();
            db.ExecuteSql(sql, null);
            BindReservationList();
        }
    }
    /// <summary>
    /// 进行状态筛选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String StateId = ddlShenPiState.SelectedItem.Value;
        if (StateId.Equals("0"))    //显示全部
        {
            BindReservationList();
            return;
        }
        String sql = "select * from ReservationInfo left join State on ReservationInfo.StateId = State.StateId where UserId = " + UserId + " and ReservationInfo.StateId = " + StateId + " order by ReservationInfoId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();

        double total = 0.0;
        for (int i = 0; i < GVTeacher.Rows.Count; i++)
        {
            total += (Convert.ToDouble(GVTeacher.Rows[i].Cells[1].Text));
        }
        lblTotal.Text = total.ToString();
    }
}
