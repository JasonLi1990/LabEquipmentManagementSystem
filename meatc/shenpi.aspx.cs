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

public partial class RegisterResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
            BindResult();
    }

    private void BindResult()
    {
        if (Request.QueryString["result"] != null)
        {
            if (Request.QueryString["result"].Equals("no"))
            {
                lb_result.Text = "审批结果：不通过导师审批";
            }
            else if (Request.QueryString["result"].Equals("ok"))
            {
                lb_result.Text = "审批结果：通过导师审批";
            }
        }
        else
        {
            Response.Write("<script>alert('对不起，非法的链接地址！');</script>");
        }
    }

    /// <summary>
    /// 审批，验证密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bt_confirm_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["r_id"] != null)
        {
            String sql = "select PUserId from UserRelationship where CUserId = (select UserId from ReservationInfo where ReservationInfoId = " + Request.QueryString["r_id"] + ")";
            DBConnect db = new DBConnect();            
            String pwdSql = "select LoginPassWord from Users where UserId = " + Request.QueryString["u_id"];
            if (db.GetDataSet(pwdSql, null).Tables[0].DefaultView[0]["LoginPassWord"].ToString().Equals(tb_pwd.Text))
            {
                DataSet ds = db.GetDataSet(sql, null);
                if (ds.Tables[0].DefaultView[0]["PUserId"].ToString().Equals(Request.QueryString["u_id"]))
                {
                    int stateid = 14;
                    if (Request.QueryString["result"].Equals("ok"))
                    {
                        stateid = 13;   //待管理员审批
                    }
                    String updateSql = "update ReservationInfo set StateId = " + stateid + " where ReservationInfoId = " + Request.QueryString["r_id"];
                    db.ExecuteSql(updateSql, null);
                    Response.Write("<script>alert('审批成功！');window.close();</script>");
                }
                else
                {
                    Response.Write("<script>alert('对不起，您不是该申请人的导师！');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('对不起，您输入的密码不正确！');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('对不起，地址栏参数不完全！');</script>");
        }
    }
}
