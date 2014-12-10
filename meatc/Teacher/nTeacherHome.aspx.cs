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

public partial class Teacher_nTeacherHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoginCheck.CheckSession(this.Page);
            BindReservationOfMe();  //自己所管学生的申请列表
            BindMyStudents();   
        }

    }

    private void BindMyStudents()
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from Users where UserId in (select CUserId from UserRelationship where PUserId = " + UserId + ")";
        DBConnect db = new DBConnect();

        ddlSchool.DataSource = db.GetDataSet(sql,null);
        
        ddlSchool.DataBind();
        ddlSchool.Items.Insert(0, new ListItem("全部", "0"));
    }

    /// <summary>
    /// 绑定该教师所管学生所申请的课题
    /// </summary>
    private void BindReservationOfMe()
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + UserId + ") order by ReservationInfoId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < GVTeacher.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        if(GVTeacher.PageCount > 0)
            ddl_page.SelectedIndex = GVTeacher.PageIndex;
    }
    protected void GVTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String sql = "";
        if (e.CommandName == "ReservationOK")    //通过导师审批
        {
            sql = "update ReservationInfo set StateId = 13 where ReservationInfoId = " + e.CommandArgument; //13表示：待管理员审批
            //在导师将该预约审批通过后，如果此时间段内的其他人有预约申请，要使其他人的申请失效
            ReservationEnd.UpdateOtherReservation(Convert.ToInt32(e.CommandArgument), true);
        }
        else if (e.CommandName == "ReservationNO")
        {
            sql = "update ReservationInfo set StateId = 14 where ReservationInfoId = " + e.CommandArgument; //14表示：未通过导师审批
        }
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预约审批状态修改成功！');</script>");
        BindReservationOfMe();
    }
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onMouseOver", "Color=this.style.backgroundColor;this.style.backgroundColor='#F0F00F'");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor=Color;");
            if (!e.Row.Cells[5].Text.Equals("待导师审批"))
            {
                e.Row.Cells[6].Text = "";
            }
        }
    }

    protected void ImgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId where ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + UserId + ")";
        if (!ddlSchool.SelectedItem.Value.Equals("0"))
        {
            sql += (" and ReservationInfo.UserId = " + ddlSchool.SelectedItem.Value);
        }
        if (!ddlShenPiState.SelectedItem.Value.Equals("0"))
        {
            sql += (" and ReservationInfo.StateId = " + ddlShenPiState.SelectedItem.Value);
        }
        sql +=  " order by ReservationInfoId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
        ddl_page.Items.Clear();
        for (int i = 0; i < GVTeacher.PageCount; i++)
        {
            ddl_page.Items.Add((i + 1).ToString());
        }
        if (GVTeacher.PageCount > 0)
        {
            ddl_page.SelectedIndex = GVTeacher.PageIndex;
        }
        
    }

    protected void first_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = 0;
        BindReservationOfMe();
    }
    protected void uppage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex >= 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex - 1;
        }
        BindReservationOfMe();
    }
    protected void nextpage_Click(object sender, EventArgs e)
    {
        if (GVTeacher.PageIndex < GVTeacher.PageCount - 1)
        {
            GVTeacher.PageIndex = GVTeacher.PageIndex + 1;
        }
        BindReservationOfMe();
    }
    protected void lastpage_Click(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = GVTeacher.PageCount - 1;
        BindReservationOfMe();
    }
    protected void ddl_page_SelectedIndexChanged(object sender, EventArgs e)
    {
        GVTeacher.PageIndex = ddl_page.SelectedIndex;
        BindReservationOfMe();
    }

}
