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

public partial class Admin_nReservationStatisticsSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page, 4);
        if (!IsPostBack)
        {
            BindTeacherList();
            BindReservationList();
            CalculateTotalPrice();
        }
    }

    private void BindTeacherList()
    {
        String sql = "select * from Users where UserType = 2 order by UserId";
        DBConnect db = new DBConnect();
        ddlTeacher.DataSource = db.GetDataSet(sql, null);
        ddlTeacher.DataTextField = "UserName";
        ddlTeacher.DataValueField = "UserId";
        ddlTeacher.DataBind();
        ddlTeacher.Items.Insert(0, new ListItem("全部", "0")); 
    }

    /// <summary>
    /// 绑定预约信息
    /// </summary>
    private void BindReservationList()
    {
        //String sql = "select * from ReservationInfo left join Users on ReservationInfo.UserId = Users.UserId left join State on ReservationInfo.StateId = State.StateId order by ReservationInfoId desc";
        String sql = "select * from Reservation left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join State on ReservationInfo.StateId = State.StateId order by ReservationId desc";
        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null); 
        GVTeacher.DataBind();
    }
    protected void GVTeacher_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            ///LinkButton lb = (LinkButton)e.Row.Cells[4].Controls[0];
            if (e.Row.Cells[3].Text == "1")
            {
                e.Row.Cells[3].Text = "院内学生";
                String sql = "select UserId,UserName from UserRelationship  left join Users on PUserId = UserId where CUserId = " + GVTeacher.DataKeys[e.Row.RowIndex].Value;                
                DBConnect db = new DBConnect();
                DataSet ds = db.GetDataSet(sql, null);
                if(ds != null)
                {
                    //..LinkButton lb = (LinkButton)e.Row.Cells[4].Controls[0
                    //LinkButton lb = (LinkButton)e.Row.Cells[4].FindControl("lb_teaName");
                    //HiddenField hf = (HiddenField)e.Row.Cells[4].FindControl("lb_teaId");
                    //lb.Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
                    HyperLink hl = e.Row.Cells[4].Controls[0] as HyperLink;
                    hl.Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
                    hl.NavigateUrl = "nTeacherShow.aspx?u_id=" + ds.Tables[0].DefaultView[0]["UserId"].ToString();
                }
                
            }
            else if (e.Row.Cells[3].Text == "0")
            {
                e.Row.Cells[3].Text = "校外学生";
                e.Row.Cells[4].Text = "无";
            }
            else if (e.Row.Cells[3].Text == "2")
            {
                HyperLink hlf = e.Row.Cells[2].Controls[0] as HyperLink;
                hlf.NavigateUrl = "nTeacherShow.aspx?u_id=" + GVTeacher.DataKeys[e.Row.RowIndex].Value;
                e.Row.Cells[3].Text = "教师";
                e.Row.Cells[4].Text = "无";
            }
            else if (e.Row.Cells[3].Text == "5")
            {
                e.Row.Cells[3].Text = "校内学生";
                e.Row.Cells[4].Text = "无";
            }
            
        }
    }

    /// <summary>
    /// 计算总价格
    /// </summary>
    private void CalculateTotalPrice()
    {
        double total = 0.0;
        for (int i = 0; i < GVTeacher.Rows.Count; i++)
        {
            total += Convert.ToDouble(GVTeacher.Rows[i].Cells[6].Text);
        }
        lblTotle.Text = total.ToString();
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnSelect_Click(object sender, ImageClickEventArgs e)
    {
        String sql = "";
        //select * from Reservation left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join State on ReservationInfo.StateId = State.StateId order by ReservationId desc
        sql = "select * from Reservation left join ReservationInfo on Reservation.ReservationInfoId = ReservationInfo.ReservationInfoId left join Users on ReservationInfo.UserId = Users.UserId left join Equipment on Reservation.EquipmentId = Equipment.EquipmentId left join State on ReservationInfo.StateId = State.StateId ";
        if (Convert.ToInt32(ddlShenPiState.SelectedItem.Value) > 0)
        {
            sql += "where ReservationInfo.StateId = " + ddlShenPiState.SelectedItem.Value;
            if (Convert.ToInt32(ddlTeacher.SelectedItem.Value) > 0)
            {
                sql += " and ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + ddlTeacher.SelectedItem.Value + ")";
            }
            if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
            {
                sql += " and BeginReservationInfoTime > '" + Convert.ToDateTime(txtBeginTime.Text).ToLocalTime() + "'";
                sql += " and EndReservationInfoTime < '" + Convert.ToDateTime(txtEndTime.Text).AddDays(1).ToLocalTime() + "'";
            }
            if (!ddl_type.SelectedItem.Value.Equals("-1"))
            {
                sql += " and UserType = " + ddl_type.SelectedItem.Value;
            }
        }
        else
        {
            if (Convert.ToInt32(ddlTeacher.SelectedItem.Value) > 0)
            {
                sql += " where ReservationInfo.UserId in (select CUserId from UserRelationship where PUserId = " + ddlTeacher.SelectedItem.Value + ")";
                if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
                {
                    sql += " and BeginReservationInfoTime > '" + Convert.ToDateTime(txtBeginTime.Text).ToLocalTime() + "'";
                    sql += " and EndReservationInfoTime < '" + Convert.ToDateTime(txtEndTime.Text).AddDays(1).ToLocalTime() + "'";
                }
                if (!ddl_type.SelectedItem.Value.Equals("-1"))
                {
                    sql += " and UserType = " + ddl_type.SelectedItem.Value;
                }
            }
            else
            {
                if (txtBeginTime.Text.Length > 0 && txtEndTime.Text.Length > 0)
                {
                    sql += " where BeginReservationInfoTime > '" + Convert.ToDateTime(txtBeginTime.Text).ToLocalTime() + "'";
                    sql += " and EndReservationInfoTime < '" + Convert.ToDateTime(txtEndTime.Text).AddDays(1).ToLocalTime() + "'";
                }
                else
                {
                    if (!ddl_type.SelectedItem.Value.Equals("-1"))
                    {
                        sql += " where UserType = " + ddl_type.SelectedItem.Value;
                    }
                }
            }
        }
        sql += " order by ReservationId desc";

        DBConnect db = new DBConnect();
        GVTeacher.DataSource = db.GetDataSet(sql, null);
        GVTeacher.DataBind();
        for (int i = 0; i < GVTeacher.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GVTeacher.Rows[i].Cells[0].FindControl("cb_select");
            cb.Checked = true;
        }
        CalculateTotalPrice();
        //Response.Write(sql);
    }
    protected void bt_report_Click(object sender, EventArgs e)
    {
        //if (ddlTeacher.SelectedValue.Equals("0"))
        //{
          //  Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请至少选择导师进行选择!');</script>");
           // return;
        //}
        String ReservationInfoIds = "";
        bool flag = false;
        for (int i = 0; i < GVTeacher.Rows.Count; i++)
        {
            CheckBox cb = (CheckBox)GVTeacher.Rows[i].Cells[0].FindControl("cb_select");
            if (cb.Checked)
            {
                HiddenField hf_ReservationInfoId = (HiddenField)GVTeacher.Rows[i].Cells[0].FindControl("hf_ReservationInfoId");
                ReservationInfoIds += (hf_ReservationInfoId.Value + "@");
                flag = true;
            }
        }
        if (flag)
        {
            ReservationInfoIds = ReservationInfoIds.Substring(0, ReservationInfoIds.Length - 1);
            Session["ReservationInfoIds"] = ReservationInfoIds;
            Session["TeacherId"] = null;
            if (!ddlTeacher.SelectedValue.Equals("0"))  //选了老师
            {
                Session["TeacherId"] = ddlTeacher.SelectedItem.Value;
            }
            Response.Redirect("ReportToTeacher.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请至少选择一个课题!');</script>");
        }
    }
    protected void GVTeacher_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteReservation")
        {
            DBConnect db = new DBConnect();
            String EquipSql = "select EquipmentId from Reservation where ReservationInfoId = " + e.CommandArgument;
            DataSet ds = db.GetDataSet(EquipSql, null);
            String EquipIds = "";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                EquipIds += ds.Tables[0].DefaultView[i]["EquipmentId"].ToString() + ",";
            }
            EquipIds = EquipIds.Substring(0, EquipIds.Length - 1);
            String sql = "delete from Reservation where ReservationInfoId = " + e.CommandArgument;
            sql += ";";
            sql += "delete from ReservationInfo where ReservationInfoId = " + e.CommandArgument;
            sql += ";";
            sql += "delete from ReservationMsg where ReservationInfoId = " + e.CommandArgument;
            sql += ";";
            sql += "update Equipment set FrequencyOfUse = FrequencyOfUse - 1 where EquipmentId in (" + EquipIds + ")" ;
            //Response.Write(sql);
            db.ExecuteSql(sql, null);
            BindReservationList();
        }
    }
}
