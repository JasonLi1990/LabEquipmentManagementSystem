<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="nReservationBox.aspx.cs" Inherits="Student_nReservationBox" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../My97DatePicker/datapicker.js" type="text/javascript"></script>
<link type="text/css" rel="stylesheet" href="../css/yuding.css"/>
<style type="text/css">
.blue
{
	color:Blue;
}
</style>
<asp:Panel ID="panelEquipmentList" runat="server" Visible="false" Style="position: absolute;
        width: 600px; height:auto; z-index: 100; top: 85px; left: 284px; background-color: White; border:solid">
        <table width="100%" cellpadding="0" cellspacing="0" border="0" id="yuding">
            
            <tr>
                <td align="left" class="container_0">
                    <p style="">
                      <span style="color:Red">
                      1、11：30~13：30为午休时间，不能做为预约开始时间<br />
                      2、工作时间为周一至周五的8:30-17:00（个别设备可以在周六、日预约）<br />
                      3、预约时间段在工作时段，否则需重新预约超出时段，并加收15%附加费</span>
                    </p>
                <hr />
                    <asp:HiddenField ID="hf_1" runat="server" />
                    
                    开始时间：<input type="text" id="tb_start" runat="server" onclick="setDayHM(this);" />
                    ----
                    结束时间：<input type="text" id="tb_end" runat="server" onclick="setDayHM(this)" />
                </td>
            </tr>
            <tr>
                <td align="center">
                        样品数量：                    
                        <asp:DropDownList ID="ddl_number" runat="server" Visible="false">
                            <asp:ListItem Text="1"></asp:ListItem>
                            <asp:ListItem Text="2"></asp:ListItem>
                            <asp:ListItem Text="3"></asp:ListItem>
                            <asp:ListItem Text="4"></asp:ListItem>
                            <asp:ListItem Text="5"></asp:ListItem>
                            <asp:ListItem Text="6"></asp:ListItem>
                            <asp:ListItem Text="7"></asp:ListItem>
                            <asp:ListItem Text="8"></asp:ListItem>
                            <asp:ListItem Text="9"></asp:ListItem>
                            <asp:ListItem Text="10"></asp:ListItem>                                                     

                        </asp:DropDownList>
                        <asp:TextBox ID="tb_number" runat="server" MaxLength="2" Width="40px">1</asp:TextBox>(N)
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        元素个数：
                        <asp:TextBox ID="tb_elementNumber" runat="server" MaxLength="2" Width="40px">1</asp:TextBox>(M)
                        <asp:DropDownList ID="ddl_elementNumber" runat="server" Visible="false">
                            <asp:ListItem Text="1"></asp:ListItem>
                            <asp:ListItem Text="2"></asp:ListItem>
                            <asp:ListItem Text="3"></asp:ListItem>
                            <asp:ListItem Text="4"></asp:ListItem>
                            <asp:ListItem Text="5"></asp:ListItem>
                            <asp:ListItem Text="6"></asp:ListItem>
                            <asp:ListItem Text="7"></asp:ListItem>
                            <asp:ListItem Text="8"></asp:ListItem>
                            <asp:ListItem Text="9"></asp:ListItem>
                            <asp:ListItem Text="10"></asp:ListItem>
                            <asp:ListItem Text="11"></asp:ListItem>
                            <asp:ListItem Text="12"></asp:ListItem>
                            <asp:ListItem Text="13"></asp:ListItem>
                            <asp:ListItem Text="14"></asp:ListItem>
                            <asp:ListItem Text="15"></asp:ListItem>
                            <asp:ListItem Text="16"></asp:ListItem>
                            <asp:ListItem Text="17"></asp:ListItem>
                            <asp:ListItem Text="18"></asp:ListItem>
                            <asp:ListItem Text="19"></asp:ListItem>
                            <asp:ListItem Text="20"></asp:ListItem>                           

                        </asp:DropDownList>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        设备附加费：<asp:TextBox ID="tb_additionalCost" Enabled="false" runat="server" Text="0" Width="40px"></asp:TextBox>
                    </td>
             </tr>
             <tr>
                <td align="center">
                    样品中需预处理的样品数量Y（0<=Y<=N）:
                    <asp:TextBox ID="tb_yuchuli" runat="server" Width="40px">0</asp:TextBox>
                    <asp:DropDownList ID="ddl_yuchuli" runat="server" Visible="false">
                            <asp:ListItem Text="0"></asp:ListItem>
                            <asp:ListItem Text="1"></asp:ListItem>
                            <asp:ListItem Text="2"></asp:ListItem>
                            <asp:ListItem Text="3"></asp:ListItem>
                            <asp:ListItem Text="4"></asp:ListItem>
                            <asp:ListItem Text="5"></asp:ListItem>
                            <asp:ListItem Text="6"></asp:ListItem>
                            <asp:ListItem Text="7"></asp:ListItem>
                            <asp:ListItem Text="8"></asp:ListItem>
                            <asp:ListItem Text="9"></asp:ListItem>
                            <asp:ListItem Text="10"></asp:ListItem>
                    </asp:DropDownList>
                </td>
             </tr>
            <tr>
                <td height="40px" align="center">
                    <asp:Button ID="imgBtnEquipmentOK" runat="server" BackColor="#92B9E2"  Height="30px" Font-Names="幼圆" Width="150px" Text="添加此设备" OnClick="imgBtnEquipmentOK_Click" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" BackColor="#92B9E2" OnClientClick="return confirm('确认取消该设备?')"  Width="150px"  Height="30px" Font-Names="幼圆" Text="取消此设备" OnClick="imgBtnEquipmentCancel_Click" />
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="imgBtnEquipmentclose" runat="server" BackColor="#92B9E2"   Height="30px" Font-Names="幼圆" Text="关闭" Width="150px" OnClick="imgBtnEquipmentclose_Click" />
                    
                    
                </td>
            </tr>
            <tr>
                <td align="left">
                    <hr />
                    <p id="direction">
                    设备说明：按【<asp:Label ID="lb_billing" runat="server" ForeColor="Red" ></asp:Label>】方式收费&nbsp;&nbsp;
                    <asp:Label ID="lb_zhoumo" runat="server" ForeColor="Red"></asp:Label>
                    
                    <br />
                    设备管理员：<asp:Label ID="lb_equipManager" runat="server"  ForeColor="Blue"></asp:Label>【
                    <asp:Label ID="lb_equipManagerPhone" runat="server"  ForeColor="Blue"></asp:Label>】<br />
                    预约时间要求：<asp:Label ID="lb_something" runat="server" ForeColor="Blue">提前</asp:Label>
                    <asp:Label ID="lb_reservationNeed" runat="server" ForeColor="Blue"></asp:Label>
                    <asp:Label ID="lb_firstday" runat="server"  ForeColor="Blue"></asp:Label><br />
                    <asp:Label ID="lb_reservationTimes" runat="server"  ForeColor="Red">其他人已预约的时间段：</asp:Label>
                    【设备状态：<asp:Label ID="lb_equipstate" runat="server" ForeColor="Red"></asp:Label>】
                    </p>
                    <div id="datagrid">

                    <asp:DataList ID="dl_haveReservationTime" runat="server">
                        <ItemTemplate>
                            <asp:Label ID="lb_starttime" runat="server" CssClass="blue" Text='<%# Eval("BeginReservationTime") %>'></asp:Label>至
                            <asp:Label ID="lb_endtime" CssClass="blue" runat="server" Text='<%# Eval("EndReservationTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:DataList>
                    </div>
                </td>
            </tr>
            
        </table>
    </asp:Panel>
    <asp:Panel ID="panel_howtocalculate" runat="server" CssClass="d5" Visible="false" Style="position: absolute;
        width: 600px; height: 340px; z-index: 100; top: 185px; left: 284px; background-color: White; border:solid">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" style="font-size:large">
                    <hr />
                    费用计算说明：
                    <br />
                        设备分为两类，一类是按租用样品数量及测定元素数量进行计费，比如设备租用价格为10元，预处理价格为20元，现假设测定2个样品，其中1个样品需要预处理，每个样品中测定3个元素，
                        则总价格的价格为2*3*10 + 1*20 = 80元。而不乘上租用的时间段长。
                        其计算公式为：【样品数*元素个数*单价 + 预处理样品数*预处理费 + 附加费】<br />
                        另一类是与租用的时长有关，比如设备租用价格为10元，预处理价格为20元，现假设测定2个样品，其中1个样品需要预处理，每个样品测定3个元素，时间从8：00至10：30即2.5个小时，则总价格为2*3*10*2.5 + 1*20 = 170元。
                        其计算公式为：【样品数*元素个数*单价*租用时长 + 预处理样品数*预处理费 + 附加费】<br />
                    <br />
                    押金计算方法：【单个设备押金*样品数量】</td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <asp:ImageButton ID="imgBtnCloseCalculate" runat="server" 
                        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnCloseCalculate_Click"  /><!--关闭按钮-->
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <table width="100%" cellpadding="0" cellspacing="0" border="0" height="500px">
        <tr>
            <td  valign="top" align="left" style="background: url(../Images/Contentback01.png); background-repeat:repeat-x;">
                <table width="100%">
                    <tr>
                        <td width="150px" align="right">
                         
                            <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/ReservationBoxTitleImg.png" />
                        </td>                        
                    </tr>
                </table>
            </td>
        </tr>   
         
        <tr>
            <td valign="top" align="center">
           
                <asp:DataList ID="dListEquipment" runat="server" RepeatColumns="2" Width="100%"
                    onitemcommand="dListEquipment_ItemCommand">
                    <ItemTemplate>
                        <table runat="server" id="EquipmentTable" cellpadding="0" cellspacing="0" style="width:100%" border="1">
                            <tr>
                                <td align="center">
                                    <asp:ImageButton AlternateText='<%# Eval("EquipmentNodes") %>' Width="240px" Height="180px" ID="imgBtnPhoto" runat="server" ImageUrl='<%#Eval("EquipmentPhotoPath") %>'
                                            CommandArgument='<%#Eval("EquipmentId").ToString() + "#" + Eval("Billing").ToString() %>' CommandName="ShowEquipment" />
                                </td>
                                <td align="center">
                                     <table cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td height="25px" class="blue" style="text-align:right">
                                                仪器名称:
                                            </td>
                                            <td align="left">
                                                <asp:LinkButton ID="LBtnEquipmentName" Style="margin-left: 10px" runat="server" Text='<%#Eval("EquipmentName") %>'
                                                    CommandArgument='<%#Eval("EquipmentId").ToString() + "#" + Eval("Billing").ToString() %>' CommandName="ShowEquipment"></asp:LinkButton>
                                                <asp:HiddenField ID="HFTotle" runat="server" />                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25px" class="blue" align="right">
                                                仪器型号:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblEquipmentModel" Style="margin-left: 10px" runat="server" Text='<%#Eval("EquipmentModel") %>'></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td height="25px" class="blue" align="right">
                                                预约价格:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblReservationPrice" Style="margin-left: 10px" runat="server" Text='<%#Eval("ReservationPrice") %>'></asp:Label>元/
                                                <asp:Label ID="lblEquipmentUnit" runat="server" Text='<%# Eval("EquipmentUnitName") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25px" class="blue" align="right"><asp:Label ID="lblYuTxt" runat="server" CssClass="blue">
                                                预处理费:</asp:Label></td>
                                            <td align="left">
                                                
                                                <asp:Label ID="lblYuChuliFei"  Style="margin-left: 10px" runat="server" Text='<%# Eval("YuChuLi") %>'></asp:Label>元
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25px" class="blue" align="right">
                                                押金:
                                            </td>
                                            <td align="left">
                                                <asp:Label ID="lblDeposit" runat="server" Style="margin-left: 10px" Text='<%#Eval("Deposit") %>'></asp:Label>元
                                                
                                            </td>
                                        </tr> 
                                        <tr>
                                            <td height="25px" class="blue" align="right">
                                                样品数量:
                                            </td>
                                            <td align="left">
                                                 <asp:TextBox ID="tb_number" runat="server" Style="margin-left: 10px" Enabled="false" Width="40px" ReadOnly="true">0</asp:TextBox>       
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label1" runat="server" CssClass="blue">附加费:</asp:Label>
                                                <asp:TextBox ID="lblAdditionalCost" Enabled="false" runat="server" Text="0" Width="30px"></asp:TextBox>元
                                            </td>
                                        </tr>    
                                                                    
                                        <tr>                                            
                                            <td colspan="2" class="blue" align="left" style="padding-left:50px;">
                                                            <asp:HiddenField ID="hf_money" runat="server" Value="0" />
                                                            <asp:HiddenField ID="hd_equipId" runat="server" Value='<%#Eval("EquipmentId") %>' />
                                                            <asp:HiddenField ID="hd_equipBilling" runat="server" Value='<%# Eval("Billing") %>' /><%--收费方式--%>
                                                            <asp:HiddenField ID="hd_elementNumber" runat="server" />
                                                            <asp:HiddenField ID="hd_yuchuliNumber" runat="server" />
                                                            <asp:CheckBox ID="CBSelectEquipment" runat="server" />
                                                
                                                            <asp:Label ID="lblReservationTime" Style="margin-left: 10px" runat="server">未选择预约时间</asp:Label>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td height="7px">
                <div align="right">
                跳至第
                <asp:DropDownList ID="ddl_pages" runat="server" Width="40px" AutoPostBack="true" 
                        onselectedindexchanged="ddl_pages_SelectedIndexChanged"></asp:DropDownList>
                        页
                        &nbsp;&nbsp;&nbsp;&nbsp;
        当前页码:
                [<asp:Label ID="lb_page" runat="server" Text="1"></asp:Label>]/共[
                <asp:Label ID="lb_totalPage" runat="server"></asp:Label>]页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_first" runat="server" onclick="lb_first_Click">首页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_up" runat="server" onclick="lb_up_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_down" runat="server" onclick="lb_down_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_last" runat="server" onclick="lb_last_Click">尾页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
            </td>
        </tr>
        <tr>
           <td height="40px" align="left" valign="bottom" style="font-size:13pt">
               <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/YuYueTotle.JPG" /><asp:Label ID="lblTotle" runat="server" style="margin-left:10px"></asp:Label>元&nbsp;&nbsp;&nbsp;&nbsp;
           
               <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/YaJinTotle.JPG" /><asp:Label ID="lblDeposit" runat="server" style="margin-left:10px"></asp:Label>元&nbsp;&nbsp;&nbsp;&nbsp;
               <asp:LinkButton ID="lBtnShowHelp" runat="server" Text="费用计算说明" 
                   onclick="lBtnShowHelp_Click"></asp:LinkButton>
           </td>
        </tr>
        <tr>
            <td align="center" valign="middle">
                <!--预约按钮-->
                <asp:ImageButton ID="ImgBtnReservation" runat="server" 
                    ImageUrl="~/Images/ShenQingYuYueBtn.png" onclick="ImgBtnReservation_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="imgBtnDeleteBox" runat="server" 
                    OnClientClick="return confirm('确认将选中的设备从预约箱移除？')" 
                    ImageUrl="~/Images/ShanChuYuYueBtn.png" onclick="imgBtnDeleteBox_Click" />   
                </td>
        </tr>
    </table>

</asp:Content>

