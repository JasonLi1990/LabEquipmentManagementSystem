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

public partial class Student_nApplyReservationDetail : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"] != null && Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ///绑定申请人（学生与教师）的基本信息
            BindBasicInfo();
            ///绑定所需要的设备及预约时间
            BindEquipInfo();
            BindReservationTime();
        }
    }


    /// <summary>
    /// 绑定所需要的设备
    /// </summary>
    private void BindEquipInfo()
    {
        //String e_ids = Request.QueryString["e_ids"];    //设备列表，以#分割
        //String e_num = Request.QueryString["e_num"];    //所需设备数量，以#分割
        //String e_fujia = Request.QueryString["e_fujia"];    //设备附加费，以#分割

        String e_ids = Session["selectedEquipIds"].ToString();

        String[] numbers = Session["EquipNumbers"].ToString().Split('@');
        String[] elementNums = Session["ElementNumber"].ToString().Split('@');
        String[] yuchuliNums = Session["YuChuLiNumber"].ToString().Split('@');

        e_ids = e_ids.Replace('@', ',');

        String sql = "select EquipmentName,EquipmentModel from Equipment where EquipmentId in (" + e_ids + ")";
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        String tmp = "";
        int i;
        if (ds != null)
        {
            //遍历DataSet，将设备名称显示出来
            for (i = 0; i < ds.Tables[0].Rows.Count - 1; i++)
            {
                tmp += ("【" + ds.Tables[0].DefaultView[i]["EquipmentName"].ToString() + "(" + ds.Tables[0].DefaultView[i]["EquipmentModel"].ToString() + ") 样品数量:" + numbers[i] + " 测试元素数量:" + elementNums[i] + " 预处理样品数:" + yuchuliNums[i] +"】，");
            }

            tmp += ("【" + ds.Tables[0].DefaultView[i]["EquipmentName"].ToString() + "(" + ds.Tables[0].DefaultView[i]["EquipmentModel"].ToString() + ") 样品数量:" + numbers[i] + " 测试元素数量:" + elementNums[i] + " 预处理样品数:" + yuchuliNums[i] +"】");
            lblEquipment.Text = tmp;
        }
    }

    /// <summary>
    /// 绑定预约时间
    /// </summary>
    private void BindReservationTime()
    {
        // String e_time = Request.QueryString["e_time"];  //预约时间，以@分割
        String e_time = Session["ReservationTimes"].ToString();
        e_time = e_time.Replace('@', '#');
        lblReservationTime.Text = e_time;
    }

    /// <summary>
    /// 绑定基本信息
    /// </summary>
    private void BindBasicInfo()
    {
        String UserId = Session["UserId"].ToString();
        if (Session["UserType"].ToString().Equals("0") || Session["UserType"].ToString().Equals("2") || Session["UserType"].ToString().Equals("5"))
        {
            TRTeacherInfo1.Visible = false;
            TRTeacherInfo2.Visible = false;
        }
        String sql = "select * from Users where UserId = " + UserId;
        String t_sql = "select * from UserRelationship left join Users as Teacher on PUserId = Teacher.UserId where CUserId = " + UserId;
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        DataSet ds_teacher = db.GetDataSet(t_sql, null);
        if (ds != null)
        {
            DataRowView drv = ds.Tables[0].DefaultView[0];
            lblName.Text = drv["UserName"].ToString();
            lblPhone.Text = drv["MobileTelephone"].ToString();
            lblEmail.Text = drv["UserEmail"].ToString();
        }

        if (ds_teacher != null)
        {
            DataRowView t_drv = ds_teacher.Tables[0].DefaultView[0];
            lblTeacherName.Text = t_drv["UserName"].ToString();
            lblTeacherPhone.Text = t_drv["MobileTelephone"].ToString();
            lblTeacherEmail.Text = t_drv["UserEmail"].ToString();
        }
    }

    /// <summary>
    /// 申请预约
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnOK_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        String stateId = "13";//只有一般学生才是待导师审批
        if (Session["UserType"].ToString().Equals("1"))
            stateId = "12";//待导师审批
        String[] e_time = Session["ReservationTimes"].ToString().Split('@');    //预约时间数组
        String sql = "Insert into ReservationInfo (IssueName,UserId,FinancialCard,IssueContent,TestPurpose,CheckIndicators,SampleProperties, EquipmentResult,BeginReservationInfoTime,EndReservationInfoTime,Total, TotalDeposit, StateId) values (@issuename,@userid,@finacialcard,@issuecontent,@purpose,@checkin,@sample,@result,@begintime,@endtime,@total,@totaldeposit,@stateid)";
        SqlParameter[] paras = { 
                                   DBConnect.MakeParameter("@issuename", txtIssueName.Text),
                                   DBConnect.MakeParameter("@userid", UserId),
                                   DBConnect.MakeParameter("@finacialcard", txtFinancialCard.Text),
                                   DBConnect.MakeParameter("@issuecontent", txtIssueContent.Text),
                                   DBConnect.MakeParameter("@purpose", txtTestPurpose.Text),
                                   DBConnect.MakeParameter("@checkin", txtCheckIndicators.Text),
                                   DBConnect.MakeParameter("@sample", txtSampleProperties.Text),
                                   DBConnect.MakeParameter("@result", txtExperimentalResults.Text),
                                   DBConnect.MakeParameter("@begintime", SplitTime(e_time[0])[0]),
                                   DBConnect.MakeParameter("@endtime", SplitTime(e_time[0])[1]),
                                   DBConnect.MakeParameter("@total", Session["Totle"]),
                                   DBConnect.MakeParameter("@totaldeposit", Session["Deposit"]),
                                   DBConnect.MakeParameter("@stateid",stateId)
                               };
        InsertReservation2(sql, paras);

        if (Session["UserType"].ToString().Equals("2"))
        {
            Response.Redirect("~/Teacher/nTeacherHome.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }


    private bool InsertReservation2(String sql, SqlParameter[] paras)
    {
        String[] e_ids = Session["selectedEquipIds"].ToString().Split('@'); //设备ID数组
        String[] e_time = Session["ReservationTimes"].ToString().Split('@');    //预约时间数组
        String[] numbers = Session["EquipNumbers"].ToString().Split('@');   //每个设备预约数目数组
        String[] additionalCosts = Session["AdditionalCosts"].ToString().Split('@');    //每台设备的附加费
        String[] eachPrice = Session["EachPrice"].ToString().Split('@');
        String[] eachEquipTotalPrice = Session["EachEquipTotalPrice"].ToString().Split('@');
        String[] elementNumber = Session["ElementNumber"].ToString().Split('@');
        String[] yuchuliNumber = Session["YuChuLiNumber"].ToString().Split('@');
        if (e_ids.Length != e_time.Length || e_ids.Length != numbers.Length)
            return false;
        DBConnect db = new DBConnect();
        db.ExecuteSql(sql, paras);   //将Reservation录入ReservationInfo表中

        sql = "select MAX(ReservationInfoId) from ReservationInfo";
        DataSet ds = db.GetDataSet(sql, null);

        int newestId = Convert.ToInt32(ds.Tables[0].DefaultView[0][0]);    //获取刚刚插入的信息的ID
        //Response.Write(e_time[0]);
        //Response.Write(e_time.Length);
        for (int i = 0; i < e_ids.Length; i++)
        {
            ///这里需要改动
            //Double totle = Convert.ToDouble(eachPrice[i]) * Convert.ToDouble(numbers[i]) + Convert.ToDouble(additionalCosts[i]);
            sql = "insert into Reservation (ReservationInfoId,EquipmentId,BeginReservationTime,EndReservationTime,AdditionalCosts, Price,EquipmentNum,Totle,StateId,YuansuNum,YuChuliNum) values (" + newestId + "," + e_ids[i] + ",'" + Convert.ToDateTime(SplitTime(e_time[i])[0]) + "','" + Convert.ToDateTime(SplitTime(e_time[i])[1]) + "'," + additionalCosts[i] + "," + eachPrice[i] + "," + numbers[i] + "," + eachEquipTotalPrice[i] + ",43," + elementNumber[i] + "," + yuchuliNumber[i] + ")";
            db.ExecuteSql(sql, null);

        }

        for (int j = 0; j < e_ids.Length; j++)
        {
            //给相应的设备管理员发邮件
            String ManagerEmail = MainSend.getManagerEmail(e_ids[j]);
            String subject = "有新的预约信息";
            String content = "预约设备：" + lblEquipment.Text + "<br />预约时间：" + lblReservationTime.Text;
            MainSend.SendMail(ManagerEmail, subject, content);
        }
        if (Session["UserType"].ToString().Equals("1")) //本院学生还要给老师发一份
        {
            String ManagerEmail = MainSend.getTeacherEmail(Session["UserId"].ToString())[1];
            String TeacherId = MainSend.getTeacherEmail(Session["UserId"].ToString())[0];
            String subject = "您的学生有新的预约申请信息";
            String content = "预约设备：" + lblEquipment.Text + "<br />预约时间：" + lblReservationTime.Text + "<hr />";
            content += "审批：<br />";
            content += "通过审批：<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "shenpi.aspx?u_id=" + TeacherId + "&r_id=" + newestId + "&result=ok'>点击通过审批</a> <br />";
            content += "不通过审批：<a href='" + ConfigurationManager.AppSettings.Get("WebSiteUrl") + "shenpi.aspx?u_id=" + TeacherId + "&r_id=" + newestId + "&result=no'>点击不通过审批</a>";
            MainSend.SendMail(ManagerEmail, subject, content);
        }
        return true;
    }

    private bool InsertReservation(String sql, SqlParameter[] paras)
    {
        String[] e_ids = Session["selectedEquipIds"].ToString().Split('@'); //设备ID数组
        String[] e_time = Session["ReservationTimes"].ToString().Split('@');    //预约时间数组
        String[] numbers = Session["EquipNumbers"].ToString().Split('@');   //每个设备预约数目数组
        if (e_ids.Length != e_time.Length || e_ids.Length != numbers.Length)
            return false;
        SqlTransaction st;
        DBConnect db = new DBConnect();
        if (db.OpenConnect())
        {
            st = db.getConn().BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = db.getConn();
            cmd.Transaction = st;
            cmd.CommandText = sql;
            foreach (SqlParameter parameter in paras)
                cmd.Parameters.Add(parameter);

            try
            {
                cmd.ExecuteNonQuery();  //将Reservation录入ReservationInfo表中

                sql = "select MAX(ReservationInfoId) from ReservationInfo";
                cmd.CommandText = sql;
                cmd.Parameters.Clear();
                int newestId = Convert.ToInt32(cmd.ExecuteScalar());    //获取刚刚插入的信息的ID
                Response.Write("OK");
                for (int i = 0; i < e_ids.Length; i++)
                {
                    sql = "insert into Reservation (ReservationInfoId,EquipmentId,BeginReservationTime,EndReservationTime,EquipmentNum,StateId) values (" + newestId + "," + e_ids[i] + ",'" + SplitTime(e_time[i])[0] + "','" + SplitTime(e_time[i])[1] + "'," + numbers[i] + ",43)";
                    Response.Write(sql);
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                Response.Write("OK");
                st.Commit();

            }
            catch (Exception e)
            {
                st.Rollback();
            }
            finally
            {
                db.CloseConnect();
            }

        }
        return true;
    }

    private String[] SplitTime(String timeStr)
    {
        return timeStr.Split('/');

    }
    protected void ImgBtnBack_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("~/Student/nStuEquipList.aspx");
    }
}
