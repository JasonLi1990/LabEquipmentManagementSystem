using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

/// <summary>
///CheckSendMail 的摘要说明
///在审批过程中，发送邮件
/// </summary>
public class CheckSendMail
{
	public CheckSendMail()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 在审批ReservationInfoId这个课题时，给申请这个课题的人发送邮件
    /// </summary>
    /// <param name="ReservationInfoId"></param>
    /// <param name="Subject"></param>
    /// <param name="Content"></param>
    public static void EquipManagerSendMail(String ReservationInfoId, String Subject, String Content)
    {
        String sql = "select UserEmail from Users where UserId in (select UserId from ReservationInfo where ReservationInfoId = "+ ReservationInfoId +")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        
        if (ds.Tables[0].DefaultView[0]["UserEmail"].ToString().Length > 0)
        {
            MainSend.SendMail(ds.Tables[0].DefaultView[0]["UserEmail"].ToString(), Subject, Content);
        }
    }
}
