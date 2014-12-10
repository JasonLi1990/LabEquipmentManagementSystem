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
///ReservationEnd 的摘要说明
/// </summary>
public class ReservationEnd
{
	public ReservationEnd()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 将ReservationInfoId这次课题所涉及到的设备使用次数都加1
    /// </summary>
    /// <param name="ReservationInfoId"></param>
    public static void AddEquipmentUserCount(String ReservationInfoId)
    {
        String sql = "update Equipment set FrequencyOfUse = FrequencyOfUse + 1 where EquipmentId in (select EquipmentId from Reservation where ReservationInfoId = "+ ReservationInfoId +")";
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, null);
    }

    public static double CalculatePrice(String EquipmentId, String eachPrice, String starttime, String endTime, String yangpinNum, String yuansuNum)
    {
        return 0.0;
    }

    /// <summary>
    /// 当某个老师审批通过后，其他学生如果在此时间段内也有预约，则失效
    /// </summary>
    /// <param name="reservationInfoId"></param>
    /// <param name="isOk">true：导师审批通过</param>
    public static void UpdateOtherReservation(int reservationInfoId, bool isOk)
    {
        String sql_1 = "select BeginReservationTime,EndReservationTime from Reservation where ReservationInfoId = " + reservationInfoId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql_1, null);
        DateTime begin_1 = Convert.ToDateTime(ds.Tables[0].DefaultView[0]["BeginReservationTime"]);
        DateTime end_1 = Convert.ToDateTime(ds.Tables[0].DefaultView[0]["EndReservationTime"]);
        //找到那些与此预约有重叠设备、且待导师审批的申请
        String sql_2 = "select ReservationInfoId from Reservation where EquipmentId in (select EquipmentId from Reservation where ReservationInfoId = " + reservationInfoId +") and ReservationInfoId <> "+ reservationInfoId;

        String sql_3 = "select ReservationInfoId,UserId,BeginReservationInfoTime, EndReservationInfoTime,stateId from ReservationInfo where ReservationInfoId in ("+ sql_2+") and stateId = 12";
        ds = db.GetDataSet(sql_3, null);
        if (ds != null)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                String UpdateId = ds.Tables[0].DefaultView[i]["ReservationInfoId"].ToString();
                String UserId = ds.Tables[0].DefaultView[i]["UserId"].ToString();
                DateTime begin_2 = Convert.ToDateTime(ds.Tables[0].DefaultView[i]["BeginReservationInfoTime"]);
                DateTime end_2 = Convert.ToDateTime(ds.Tables[0].DefaultView[i]["EndReservationInfoTime"]);
                if (begin_1 < end_2 && end_1 > begin_2) //有冲突，且导师未审批
                {
                    String sql = "update ReservationInfo set StateId = 16 where ReservationInfoId = " + UpdateId;
                    db.ExecuteSql(sql, null);
                    //发送一条消息告诉此人
                    sql = "insert into ReservationMsg (ReservationInfoId, ReservationMsgContent,ToUserId, ReservationMsgTime) values (" + UpdateId + ",'由于您的导师未及时审批，而其他占用此设备的预约已经经过导师审批通过，因此您的当前预约失效！',"+ UserId +", '" + DateTime.Now + "')";
                    db.ExecuteSql(sql, null);
                }
            }
        }
    }
}
