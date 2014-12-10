using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
///LoginCheck 的摘要说明
/// </summary>
public class LoginCheck
{
    DBConnect dbc = new DBConnect();
	public LoginCheck()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}


    /// <summary>
    /// 检查登录用户
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="type"></param>
    /// <returns>0:没有这个用户，非0：用户的ID即UserId</returns>
    public static String CheckUser(String username, String password, int type)
    {
        string sql = "select * from Users where LoginName = @username and LoginPassWord = @password and UserType = " + type;
        if (type == 4)     //4代表管理员，对于禁用的管理员，不能登录    
            sql = "select * from Users where LoginName = @username and LoginPassWord = @password and UserType = " + type + " and StateId = 1";
        
        SqlParameter[] paras = {
                                   DBConnect.MakeParameter("@username",username),
                                   DBConnect.MakeParameter("@password",password)
                               };
        DBConnect db = new DBConnect();
        DataSet ds = null;
        
        if ((ds = db.GetDataSet(sql, paras)) != null)
        {
            return ds.Tables[0].DefaultView[0]["UserId"].ToString();
        }
        return "0";
        
    }

    /// <summary>
    /// 检查页面Session
    /// </summary>
    /// <param name="apage"></param>
    public static void CheckSession(Page apage)
    {
        if (apage.Session["UserId"] == null || apage.Session["UserId"].ToString().Equals(""))
        {
            apage.Response.Redirect("~/nindex.aspx");
        }
        apage.Session.Timeout = 60;
    }

    /// <summary>
    /// 检查页面Session
    /// </summary>
    /// <param name="apage"></param>
    public static void CheckSession(Page apage, int type)
    {
        if (apage.Session["UserId"] == null || apage.Session["UserId"].ToString().Equals("") || !apage.Session["UserType"].ToString().Equals(type.ToString()))
        {
            apage.Response.Redirect("~/nindex.aspx");
        }
        apage.Session.Timeout = 60;
    }
}
