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
///ReservationCheck 的摘要说明
/// </summary>
public class ReservationCheck
{
	public ReservationCheck()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 检测EquipmentId这个设备如果租用StartDate与EndDate是否合适
    /// </summary>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="EquipmentId"></param>    
    /// <returns>0:无交叉，1：有交叉</returns>
    public static int CheckReservationTime(String StartDate, String EndDate, String EquipmentId)
    {
        int result = 1; ///1：表示有交叉
        ///主要是通过Sql语句检测是否有交叉
        String sql = "select count(*) from Reservation where EndReservationTime > '"+StartDate+"' and BeginReservationTime < '"+EndDate+"' and Equipmentid = "+ EquipmentId +" and ReservationInfoId in (select ReservationInfoId from ReservationInfo where StateId <> 12 and StateId <> 14 and StateId <> 16)";
        DBConnect db = new DBConnect();
        if (db.GetDataSet(sql, null).Tables[0].DefaultView[0][0].ToString().Equals("0"))    //0表示无交叉
            result = 0;
        
        return result;
    }

    /// <summary>
    /// 检查用户所选的时间段中，该设备的管理员是否不工作
    /// </summary>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <param name="EquipmentId"></param>
    /// <returns></returns>
    public static String CheckIfUnWork(String StartDate, String EndDate, String EquipmentId)
    {        
        String reason = "";
        String sql = "select * from ReservationTime where TimeStart < '" + EndDate + "' and TimeEnd > '"+ StartDate +"' and UserId = (select UserId from Equipment where EquipmentId = "+ EquipmentId + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds == null)
        {
            return reason;
        }
        reason = ds.Tables[0].DefaultView[0]["Reason"].ToString() + "【" + ds.Tables[0].DefaultView[0]["TimeStart"].ToString() + "至" + ds.Tables[0].DefaultView[0]["TimeEnd"].ToString() + "】";
        return reason;
    }
}
