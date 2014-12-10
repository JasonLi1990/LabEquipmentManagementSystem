using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Net.Mail;
using System.Text;

/// <summary>
///MainSend 的摘要说明
/// </summary>
public class MainSend
{
	public MainSend()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    public static void SendMail(String ToUser, String Subject, String Content)
    {
        String FromUserEmail = ConfigurationManager.AppSettings.Get("FromUserMail");
        String FromUserPwd = ConfigurationManager.AppSettings.Get("FromUserPwd");
        SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient        
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
        smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
        smtp.Host = "smtp.126.com"; //指定 smtp 服务器地址
        smtp.Port = 25;             //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去
        smtp.UseDefaultCredentials = true;//如果需要认证，则用下面的方式
        smtp.Credentials = new NetworkCredential(FromUserEmail, FromUserPwd);
        MailMessage mm = new MailMessage(); //实例化一个邮件类
        mm.Priority = MailPriority.Normal; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
        mm.From = new MailAddress(FromUserEmail, "市政学院实验中心", Encoding.GetEncoding(936));
        mm.To.Add(ToUser);
        mm.IsBodyHtml = true;
        mm.Subject = Subject;
        mm.Body = Content;
        try
        {
            String isSendMail = ConfigurationManager.AppSettings.Get("IsSendMail");
            if (isSendMail.Equals("1"))
            {
                smtp.Send(mm);
            }
            
        }
        catch (Exception e)
        {
            
        }

    }

    /// <summary>
    /// 根据UserId获取其邮箱
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public static String getEmail(String UserId)
    {
        String sql = "select UserEmail from Users where UserId = " + UserId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            return ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
        }
        return "";
    }

    /// <summary>
    /// 根据学生的ID获取教师的邮箱和ID
    /// </summary>
    /// <param name="UserId"></param>
    /// <returns></returns>
    public static String[] getTeacherEmail(String UserId)
    {
        String sql = "select UserId,UserEmail from Users where UserId in (select PUserId from UserRelationship where CUserId = " + UserId + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        String[] result = new String[2];        
        
        
        if (ds != null)
        {
            result[0] = ds.Tables[0].DefaultView[0]["UserId"].ToString();
            result[1] = ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
            return result;
        }
        return null;
    }

    /// <summary>
    /// 根据设备ID获取设备管理员的邮箱
    /// </summary>
    /// <param name="EquipId"></param>
    /// <returns></returns>
    public static String getManagerEmail(String EquipId)
    {
        String sql = "select UserEmail from Users where UserId in (select UserId from Equipment where EquipmentId = " + EquipId + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            return ds.Tables[0].DefaultView[0]["UserEmail"].ToString();
        }
        return "";
    }
    
}
