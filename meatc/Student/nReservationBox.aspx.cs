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

public partial class Student_nReservationBox : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindInterestBox();            
        }
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
        LoginCheck.CheckSession(this.Page);
        if (Session["UserType"].ToString().Equals("2"))
        {
            this.MasterPageFile = "~/Teacher/T_MasterPage.master";
        }
    }

    private String[] startTime;
    private String[] endTime;

    private void BasicBind(String sql, int pageNum)
    {
        DBConnect db = new DBConnect();
        DataSet ds = db.GetDataSet(sql, null);
        if (ds != null)
        {
            int curPage = Convert.ToInt32(lb_page.Text);
            if (pageNum > 0)
                curPage = pageNum;

            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = ds.Tables[0].DefaultView;
            ps.AllowPaging = true;
            ps.PageSize = 4;
            ps.CurrentPageIndex = curPage - 1;
            lb_down.Enabled = true;
            lb_first.Enabled = true;
            lb_last.Enabled = true;
            lb_up.Enabled = true;
            if (curPage == 1)
            {
                lb_first.Enabled = false;
                lb_up.Enabled = false;
            }
            if (curPage == ps.PageCount)
            {
                lb_down.Enabled = false;
                lb_last.Enabled = false;
            }
            lb_totalPage.Text = Convert.ToString(ps.PageCount);
            lb_page.Text = curPage.ToString();

            if (ddl_pages.Items.Count == 0)
            {
                for (int i = 1; i <= Convert.ToInt32(lb_totalPage.Text); i++)
                {
                    ddl_pages.Items.Add(i.ToString());
                }
            }
            dListEquipment.DataSource = ps;
            dListEquipment.DataBind();
        }
    }

    /// <summary>
    /// 显示预约箱内的设备
    /// </summary>
    private void BindInterestBox()
    {
        String UserId = Session["UserId"].ToString();
        int StudentType = GetStudentType(UserId); //1本院，2本校他院，3其他学校
        String sql = "";
        if (StudentType == 1 || StudentType == 2)
            sql = "select InterestBox.*,EquipmentName,EquipmentModel,EquipmentPhotoPath,InternalPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuli,EquipmentNodes from InterestBox left join Equipment on InterestBox.EquipmentId = Equipment.EquipmentId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where InterestBox.UserId =" + UserId;
        else if (StudentType == 5)   //本校学生
            sql = "select InterestBox.*,EquipmentName,EquipmentModel,EquipmentPhotoPath,StudentPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuli,EquipmentNodes from InterestBox left join Equipment on InterestBox.EquipmentId = Equipment.EquipmentId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where InterestBox.UserId =" + UserId;
        else if (StudentType == 0)   //其他学校
            sql = "select InterestBox.*,EquipmentName,EquipmentModel,EquipmentPhotoPath,ExternalPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuli,EquipmentNodes from InterestBox left join Equipment on InterestBox.EquipmentId = Equipment.EquipmentId left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where InterestBox.UserId =" + UserId;
        BasicBind(sql, 0);
    }

    protected void ddl_pages_SelectedIndexChanged(object sender, EventArgs e)
    {
        int currentPage = Convert.ToInt32(ddl_pages.SelectedItem.Text);
        String UserId = Session["UserId"].ToString();
        int StudentType = GetStudentType(UserId); //1本院，2本校他院，3其他学校
        String sql = "";
        if (StudentType == 1 || StudentType == 2)
            sql = "select EquipmentId,EquipmentName,EquipmentModel,EquipmentPhotoPath,InternalPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuLi,EquipmentNodes from Equipment left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where IsCheck = 1";
        else if (StudentType == 5)   //本校学生
            sql = "select EquipmentId,EquipmentName,EquipmentModel,EquipmentPhotoPath,StudentPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuLi,EquipmentNodes from Equipment left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where IsCheck = 1";
        else if (StudentType == 0)   //其他学校
            sql = "select EquipmentId,EquipmentName,EquipmentModel,EquipmentPhotoPath,ExternalPrice as ReservationPrice,Deposit,Billing,EquipmentUnitName,YuChuLi,EquipmentNodes from Equipment left join EquipmentUnit on Equipment.EquipmentUnitId = EquipmentUnit.EquipmentUnitId where IsCheck = 1";
        BasicBind(sql, currentPage);
    }

    /// <summary>
    /// 获取学生类型
    /// </summary>
    /// <returns>1本院，5本校他院，0其他学校,2导师 </returns>
    private int GetStudentType(String UserId)
    {
        String sql = "select UserType from Users where UserId = " + UserId;
        DBConnect db = new DBConnect();
        return Convert.ToInt32(db.GetDataSet(sql, null).Tables[0].DefaultView[0]["UserType"]);
    }

    protected void lb_first_Click(object sender, EventArgs e)
    {
        lb_page.Text = "1";
        BindInterestBox();
    }

    protected void lb_up_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) - 1);
        BindInterestBox();
    }
    protected void lb_down_Click(object sender, EventArgs e)
    {
        lb_page.Text = Convert.ToString(Convert.ToInt32(lb_page.Text) + 1);
        BindInterestBox();
    }

    protected void lb_last_Click(object sender, EventArgs e)
    {
        lb_page.Text = lb_totalPage.Text;
        BindInterestBox();
    }

    /// <summary>
    /// 申请预约，通过Session传递到课题填写页面
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImgBtnReservation_Click(object sender, ImageClickEventArgs e)
    {
        ///依次遍历预约箱内设备列表
        String selectedEquipment = "";
        String ReservationTimes = "";
        String EquipNumbers = "";
        String AdditionalCosts = "";
        String EachPrice = "";
        String EachEquipTotalPrice = "";
        String ElementNumber = "";
        String YuChuLiNumber = "";
        int count = 0;  //用户选择的设备个数，如果没选择，是不能预约的
        for (int i = 0; i < dListEquipment.Items.Count; i++)
        {
            CheckBox cb = (CheckBox)dListEquipment.Items[i].FindControl("CBSelectEquipment");
            if (cb.Checked)
            {
                count++;
                Label lb = (Label)dListEquipment.Items[i].FindControl("lblReservationTime");
                if (lb.Text == "未选择预约时间")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('有的设备您选择后未设定预约时间！');</script>");
                    return;
                }
                ReservationTimes += (lb.Text + "@");    //每台设备的预约时间
                HiddenField hf = (HiddenField)dListEquipment.Items[i].FindControl("hd_equipId");
                selectedEquipment += (hf.Value + "@");  //设备ID列表，以@分割
                TextBox tb = (TextBox)dListEquipment.Items[i].FindControl("tb_number");
                EquipNumbers += (tb.Text + "@");    //每台设备需要的数量                
                TextBox tb_additional = (TextBox)dListEquipment.Items[i].FindControl("lblAdditionalCost");
                AdditionalCosts += (tb_additional.Text + "@");  //每个设备的附加费
                Label lb_price = (Label)dListEquipment.Items[i].FindControl("lblReservationPrice");
                EachPrice += (lb_price.Text + "@"); //每台设备的单价
                //hf_money表示除押金外的所有钱，包括使用费+附加费
                HiddenField hf_money = (HiddenField)dListEquipment.Items[i].FindControl("hf_money");
                EachEquipTotalPrice += (hf_money.Value + "@");

                HiddenField hd_elementNum = (HiddenField)dListEquipment.Items[i].FindControl("hd_elementNumber");
                ElementNumber += (hd_elementNum.Value + "@");

                HiddenField hd_yuchuliNum = (HiddenField)dListEquipment.Items[i].FindControl("hd_yuchuliNumber");
                YuChuLiNumber += (hd_yuchuliNum.Value + "@");            
            }
        }
        if (count > 0)
        {
            Session["selectedEquipIds"] = selectedEquipment.Substring(0, selectedEquipment.Length - 1);
            Session["ReservationTimes"] = ReservationTimes.Substring(0, ReservationTimes.Length - 1);
            Session["EquipNumbers"] = EquipNumbers.Substring(0, EquipNumbers.Length - 1);
            Session["AdditionalCosts"] = AdditionalCosts.Substring(0, AdditionalCosts.Length - 1);
            Session["EachPrice"] = EachPrice.Substring(0, EachPrice.Length - 1);
            Session["EachEquipTotalPrice"] = EachEquipTotalPrice.Substring(0, EachEquipTotalPrice.Length - 1);
            Session["ElementNumber"] = ElementNumber.Substring(0, ElementNumber.Length - 1);
            Session["YuChuLiNumber"] = YuChuLiNumber.Substring(0, YuChuLiNumber.Length - 1);
            Response.Redirect("nApplyReservationDetail.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('对不起，你还没有选择设备进行预约');</script>");
        }
    }


    protected void dListEquipment_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ShowEquipment")
        {
            dl_haveReservationTime.DataSource = null;
            dl_haveReservationTime.DataBind();
            lb_reservationTimes.Text = "尚未有人预约此设备";
            hf_1.Value = e.CommandArgument.ToString().Split('#')[0];
            String sql = "select * from Equipment left join Users on Equipment.UserId = Users.UserId where EquipmentId = " + hf_1.Value;
            String haveReservationTimeSql = "select * from Reservation where BeginReservationTime > '" + DateTime.Now + "' and Equipmentid = " + hf_1.Value + " and ReservationInfoId in (select ReservationInfoId from ReservationInfo where StateId <> 12 and StateId <> 14 and StateId <> 16) order by BeginReservationTime ";//12表示待导师审批、14表示未通过审批
            DBConnect db = new DBConnect();
            DataSet ds = db.GetDataSet(sql, null);
            if (ds != null)
            {
                if (ds.Tables[0].DefaultView[0]["IsZhouMoOpen"].ToString().Equals("0"))
                {
                    lb_zhoumo.Text = "周六、周日不能预约";
                }
                else
                {
                    lb_zhoumo.Text = "周六、周日可以预约";
                }
                switch (ds.Tables[0].DefaultView[0]["StateId"].ToString())
                {
                    case "21":
                        lb_equipstate.Text = "设备正常";
                        break;
                    case "22":
                        lb_equipstate.Text = "设备损坏";
                        break;
                    case "23":
                        lb_equipstate.Text = "正在维修";
                        break;
                    case "24":
                        lb_equipstate.Text = "设备报废";
                        break;
                }

                lb_equipManager.Text = ds.Tables[0].DefaultView[0]["UserName"].ToString();
                lb_equipManagerPhone.Text = "固话：" + ds.Tables[0].DefaultView[0]["UserPhone"].ToString() + "/手机：" + ds.Tables[0].DefaultView[0]["MobileTelephone"].ToString();
                lb_reservationNeed.Text = ds.Tables[0].DefaultView[0]["StartDay"].ToString();
                lb_firstday.Text = ("天预约  可预约开始时间:" + DateTime.Now.AddDays(Convert.ToInt32(lb_reservationNeed.Text)).ToLongDateString());
            }
            ds = db.GetDataSet(haveReservationTimeSql, null);
            //Response.Write(haveReservationTimeSql);
            if (ds != null) //显示已经预约的人的时间
            {
                lb_reservationTimes.Text = "以下是他人已预约的时间段，这些时间段已被占用：";
                dl_haveReservationTime.DataSource = ds;
                dl_haveReservationTime.DataBind();
            }
            if (e.CommandArgument.ToString().Split('#')[1] == "1")
                lb_billing.Text = "时间段";
            else
                lb_billing.Text = "设备数量";
            panelEquipmentList.Visible = true;
        }
    }

    /// <summary>
    /// 设定设备所需要的的预约时间及数量
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEquipmentclose_Click(object sender, EventArgs e)
    {
        panelEquipmentList.Visible = false;

    }
    private bool b_isFujia = false;
    /// <summary>
    /// 计算好设备租用总额
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEquipmentOK_Click(object sender, EventArgs e)
    {
        if (CheckSelectedTime() == 0)   //检查选择的时间是否合格
            return;

        for (int i = 0; i < dListEquipment.Items.Count; i++)
        {
            //从GridView中获取设备ID
            HiddenField hf = (HiddenField)dListEquipment.Items[i].FindControl("hd_equipId");
            if (hf.Value == hf_1.Value)
            {
                Label lb = (Label)dListEquipment.Items[i].FindControl("lblReservationTime");
                lb.Text = (tb_start.Value + "/" + tb_end.Value);
                CheckBox cb = (CheckBox)dListEquipment.Items[i].FindControl("CBSelectEquipment");
                cb.Checked = true;

                //租用设备的数量，即样品数量
                TextBox tb = (TextBox)dListEquipment.Items[i].FindControl("tb_number");
                tb.Text = ddl_number.SelectedItem.Text;
                int yangpinNum = Convert.ToInt32(tb.Text);  //样品数
                int elementNum = Convert.ToInt32(ddl_elementNumber.SelectedItem.Text);//测定元素个数
                int yuchuliNum = Convert.ToInt32(ddl_yuchuli.SelectedItem.Text); //需要预处理的样品数
                if (yuchuliNum > yangpinNum)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预处理样品数不能大于总样品数！')</script>");
                    return;
                }

                //每个都有一个测试元素个数
                HiddenField hf_elementNum = (HiddenField)dListEquipment.Items[i].FindControl("hd_elementNumber");
                hf_elementNum.Value = elementNum.ToString();

                //预处理的样品数
                HiddenField hf_yuchuliNum = (HiddenField)dListEquipment.Items[i].FindControl("hd_yuchuliNumber");
                hf_yuchuliNum.Value = yuchuliNum.ToString();

                //hf_money表示除押金外的所有钱，包括使用费+附加费
                HiddenField hf_money = (HiddenField)dListEquipment.Items[i].FindControl("hf_money");


                TimeSpan ts = Convert.ToDateTime(tb_end.Value) - Convert.ToDateTime(tb_start.Value);
                //租用设备的附加费
                TextBox tb_additional = (TextBox)dListEquipment.Items[i].FindControl("lblAdditionalCost");

                //设备单价
                Label lb_price = (Label)dListEquipment.Items[i].FindControl("lblReservationPrice");
                double eachPrice = Convert.ToDouble(lb_price.Text);

                //每台设备的预处理费
                Label lb_yuchulifei = (Label)dListEquipment.Items[i].FindControl("lblYuChuliFei");
                double eachYuchuli = Convert.ToDouble(lb_yuchulifei.Text);

                if (lb_billing.Text == "时间段") //按时间段收费
                {
                    double addtional = CalculateAdditionalCost(Convert.ToDouble(lb_price.Text), Convert.ToInt32(tb.Text), 1);

                    tb_additional.Text = addtional.ToString();
                    //按数量*单价*小时数目+附加费【新公式20120106：样品个数*测定元素个数*单价*小时数 + 需要预处理的样品数*预处理费 + 附加费】
                    hf_money.Value = (yangpinNum * elementNum * eachPrice * (ts.Days * 24 + ts.Hours + ts.Minutes / 60.0) + yuchuliNum * eachYuchuli + addtional).ToString();
                }
                else//按租用设备数量收费
                {
                    if (b_isFujia)
                    {
                        tb_additional.Text = (yangpinNum * elementNum * eachPrice + yuchuliNum * eachYuchuli) * 0.15 + "";
                    }
                    else
                        tb_additional.Text = "0";
                    //double addtional = CalculateAdditionalCost(Convert.ToDouble(lb_price.Text), Convert.ToInt32(tb.Text), 2);
                    //按数量*单价+附加费【新公式20120106：样品个数*测定元素个数*单价 + 需要预处理的样品数*预处理费 + 附加费】
                    hf_money.Value = (yangpinNum * elementNum * eachPrice + yuchuliNum * eachYuchuli + Convert.ToDouble(tb_additional.Text)).ToString();
                }
                break;
            }
        }
        panelEquipmentList.Visible = false;

        CaculatePrice();
    }

    /// <summary>
    /// 计算设备附加费，超过部分加收15%
    /// </summary>
    /// <returns></returns>
    private double CalculateAdditionalCost(double price, int number, int EquipType)
    {
        double result = 0.0;
        DateTime end = Convert.ToDateTime(tb_end.Value);
        DateTime start = Convert.ToDateTime(tb_start.Value);
        double startHour = 1.0 * start.Hour + start.Minute / 60.0;
        double endHour = end.Hour + end.Minute / 60.0;
        if (end.DayOfWeek.ToString() != "Saturday" && end.DayOfWeek.ToString() != "Sunday") //周一至周五
        {
            if (startHour >= 8.5 && endHour <= 17.0)    //在8：30到17：00之间
                result = 0.0;
            else if (startHour >= 8.5 && endHour > 17.0) //结尾部分超过17:00
            {
                result = (endHour - 17.0) * number * price * 0.15;  //超过时长*数量*价格*0.15
            }
            else if (startHour < 8.5 && endHour <= 17.0) //开始部分过早
            {
                result = (8.5 - startHour) * number * price * 0.15;
            }
            else if (startHour < 8.5 && endHour > 17.0)
            {
                result = (8.5 - startHour + endHour - 17.0) * number * price * 0.15;
            }
        }
        else//周六，周日全部加附加费
        {
            result = (endHour - startHour) * price * number * 0.15;
        }

        return result;
    }

    /// <summary>
    /// 检查所选时间的有效性
    /// </summary>
    /// <returns></returns>
    private int CheckSelectedTime()
    {
        if (!lb_equipstate.Text.Equals("设备正常"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('" + lb_equipstate.Text + "');</script>");
            return 0;
        }

        if (tb_start.Value.Length == 0 || tb_end.Value.Length == 0 || tb_end.Value.CompareTo(tb_start.Value) <= 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('时间不能为空，结束时间要晚于开始时间！');</script>");
            return 0;
        }

        String startStr = Convert.ToDateTime(tb_start.Value).DayOfWeek.ToString();
        String endStr = Convert.ToDateTime(tb_end.Value).DayOfWeek.ToString();
        if (startStr.Equals("Saturday") || startStr.Equals("Sunday") || endStr.Equals("Saturday") || endStr.Equals("Sunday"))
        {
            if (lb_zhoumo.Text.Equals("周六、周日不能预约"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('对不起，此设备不能在周六或周日预约！');</script>");
                return 0;
            }
            else
            {
                b_isFujia = true;
            }
        }

        DateTime start_forbid = Convert.ToDateTime(Convert.ToDateTime(tb_start.Value).ToShortDateString() + " 11:30:00");
        DateTime end_forbid = Convert.ToDateTime(Convert.ToDateTime(tb_start.Value).ToShortDateString() + " 13:30:00");
        DateTime earliest_forbid = Convert.ToDateTime(Convert.ToDateTime(tb_start.Value).ToShortDateString() + " 08:30:00");
        if (Convert.ToDateTime(tb_start.Value) > start_forbid && Convert.ToDateTime(tb_start.Value) < end_forbid)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('不能在11:30至13:30之间开始预约！');</script>");
            return 0;
        }

        if (Convert.ToDateTime(tb_start.Value) < earliest_forbid || Convert.ToDateTime(tb_end.Value) < earliest_forbid)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('开始预约时间不能早于8：30！');</script>");
            return 0;
        }

        ///检查所选的时间段内，管理员是否工作
        String reason = ReservationCheck.CheckIfUnWork(tb_start.Value, tb_end.Value, hf_1.Value);
        if (reason.Length > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('此段时间该管理员不工作，原因：" + reason + "！');</script>");
            return 0;
        }

        //检查用户选择的时间是否合适，0表示无交叉，1表示有交叉
        if (ReservationCheck.CheckReservationTime(tb_start.Value, tb_end.Value, hf_1.Value) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('对不起，在您选择的时间段已有人预约，请重新选择时间！');</script>");
            return 0;
        }

        ///需要提前预约
        String beginDay = DateTime.Now.AddDays(Convert.ToInt32(lb_reservationNeed.Text)).ToShortDateString() + " 00:00:00";
        if (Convert.ToDateTime(beginDay).CompareTo(Convert.ToDateTime(tb_start.Value)) > 0)  //如果预约开始时间在指定日期之前，则时间不对
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('此设备需要提前" + lb_reservationNeed.Text + "天预约，请重新选择时间！');</script>");
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////
        //
        //////////////////////////////////////////////////////////////////////////
        DateTime ENDTIME = Convert.ToDateTime(Convert.ToDateTime(tb_start.Value).ToShortDateString() + " 17:00:00");
        if (Convert.ToDateTime(tb_start.Value) < ENDTIME && Convert.ToDateTime(tb_end.Value) > ENDTIME)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预约时间段必须在工作时段，否则需重新预约超出时段');</script>");
            return 0;
        }
        if (Convert.ToDateTime(tb_start.Value) >= ENDTIME && Convert.ToDateTime(tb_end.Value) > ENDTIME)
        {
            b_isFujia = true;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('预约时间段不在工作时段，会收取15%附加费');</script>");
        }
        ///OK，所有检查过关
        return 1;
    }


    /// <summary>
    /// 取消某个设备，需要重新计算价格
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnEquipmentCancel_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < dListEquipment.Items.Count; i++)
        {
            //hd_equipId
            HiddenField hf = (HiddenField)dListEquipment.Items[i].FindControl("hd_equipId");
            if (hf.Value == hf_1.Value)
            {
                CheckBox cb = (CheckBox)dListEquipment.Items[i].FindControl("CBSelectEquipment");
                cb.Checked = false;
                break;
            }
        }
        panelEquipmentList.Visible = false;
        CaculatePrice();
    }

    /// <summary>
    /// 计算价格
    /// </summary>
    private void CaculatePrice()
    {
        double nowTotel = 0.0;
        double nowDeposit = 0.0;
        for (int j = 0; j < dListEquipment.Items.Count; j++)
        {
            CheckBox cb = (CheckBox)dListEquipment.Items[j].FindControl("CBSelectEquipment");
            if (cb.Checked)
            {
                //hf_money代表正常收费价格
                HiddenField hf_money = (HiddenField)dListEquipment.Items[j].FindControl("hf_money");
                nowTotel += Convert.ToDouble(hf_money.Value);

                //lb_deposit代表押金
                Label lb_deposit = (Label)dListEquipment.Items[j].FindControl("lblDeposit");
                TextBox tb = (TextBox)dListEquipment.Items[j].FindControl("tb_number");
                nowDeposit += (Convert.ToDouble(lb_deposit.Text) * Convert.ToInt32(tb.Text));
            }
        }
        lblTotle.Text = nowTotel.ToString();
        lblDeposit.Text = nowDeposit.ToString();
        Session["Totle"] = lblTotle.Text;
        Session["Deposit"] = lblDeposit.Text;
    }
    protected void imgBtnCloseCalculate_Click(object sender, ImageClickEventArgs e)
    {
        panel_howtocalculate.Visible = false;
    }
    protected void lBtnShowHelp_Click(object sender, EventArgs e)
    {
        panel_howtocalculate.Visible = true;
    }

    /// <summary>
    /// 将选中的设备从预约箱中删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void imgBtnDeleteBox_Click(object sender, ImageClickEventArgs e)
    {
        String UserId = Session["UserId"].ToString();
        DBConnect db = new DBConnect();
        Boolean isSelected = false;
        for (int j = 0; j < dListEquipment.Items.Count; j++)
        {
            CheckBox cb = (CheckBox)dListEquipment.Items[j].FindControl("CBSelectEquipment");
            if (cb.Checked)
            {
                HiddenField hf = (HiddenField)dListEquipment.Items[j].FindControl("hd_equipId");
                String sql = "delete from InterestBox where UserId = " + UserId + " and EquipmentId = " + hf.Value;
                db.ExecuteSql(sql, null);
                isSelected = true;
            }
        }
        if (isSelected)
            BindInterestBox();
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您没有选择移除预约箱的设备！')</script>");
        }
    }

}
