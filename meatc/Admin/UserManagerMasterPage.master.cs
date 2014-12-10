using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_UserManagerMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (!IsPostBack)
            BindSelfInfo();
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
    }

    /// <summary>
    /// 所有人的公共母版页，绑定姓名、日期、星期几等信息
    /// </summary>
    private void BindSelfInfo()
    {
        String sql = "select UserName,UserType from Users where UserId = " + Session["UserId"].ToString();
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            int UserType = Convert.ToInt32(ds.Tables[0].DefaultView[0]["UserType"]);
            String UserName = ds.Tables[0].DefaultView[0]["UserName"].ToString();
            String ShowTxt = "";
            switch (UserType)
            {
                case 0:
                    ShowTxt = "校外用户 ";
                    break;
                case 1:
                    ShowTxt = "本院学生 ";
                    break;
                case 2:
                    ShowTxt = "导师 ";
                    break;
                case 3:
                    ShowTxt = "设备管理员 ";
                    break;
                case 4:
                    ShowTxt = "系统管理员 ";
                    break;
                case 5:
                    ShowTxt = "本校用户 ";
                    break;
                case -1:
                    ShowTxt = "超级管理员";
                    break;
            }
            lblUserInfo.Text = ShowTxt + ":" + UserName;            
        }
        lblDateTime.Text = DateTime.Now.ToLongDateString() + " " + GetChineseName();
    }

    private String GetChineseName()
    {
        String result = "";
        
        switch (DateTime.Today.DayOfWeek.ToString().ToLower())
        {
            case "monday":
                result = "星期一";
                break;
            case "tuesday":
                result = "星期二";
                break;
            case "wednesday":
                result = "星期三";
                break;
            case "thursday":
                result = "星期四";
                break;
            case "friday":
                result = "星期五";
                break;
            case "saturday":
                result = "星期六";
                break;
            case "sunday":
                result = "星期日";
                break;
        }
        return result;
    }

}
