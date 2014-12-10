<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="副本 Default.aspx.cs" Inherits="_Default" Debug="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>哈尔滨工业大学实验室预约系统</title>
    <link href="Admin/Css/default.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top:0px; background-image:url('Images/newbg.gif')">
    <form id="form1" runat="server">
    <center>
        <asp:Panel ID="panel_showEquip" runat="server" Visible="false" CssClass="d5" style=" position:absolute; width:600px; height:auto; z-index:100; top: 225px; left: 125px; background-color:White">
            <table width="100%">
                    <tr>
                       <td align="center" colspan="3" rowspan="6">
                                <asp:Image ID="imgEquipmentPhoto" runat="server" Height="190px" 
                               Width="250px" />
                       </td>
                       <td width="150px" align="right" height="35px" class="blue">
                           设备名称</td>
                       <td width=10px>
                           &nbsp;</td>
                            <td align=left>
                                <asp:Label ID="lblEquipmentName" runat="server"></asp:Label>
                       </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   设备型号</td>
               <td width="10px">
                   &nbsp;</td>
                    <td align=left>
                       <asp:Label ID="lblEquipmentModel" runat="server"></asp:Label> 
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   设备类型</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblEquipmentType" runat="server"></asp:Label>
               </td>
           </tr>
                     
           <tr>
                <td align=right height="35px" class="blue">
                   设备管理员</td>
               <td>
                   &nbsp;</td>
                    <td align="left">
                        <asp:Label ID="lblEquipmentManager" runat="server"></asp:Label>
                        
               </td>
               
               
           </tr>
           <tr>
             <td align=right class="blue">
                    押金</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan="4">
                        <asp:Label ID="lblDeposit" runat="server"></asp:Label>
               </td>
           </tr>
                    
           <tr>
               <td align=right height="35px" class="blue">
                   设备说明</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:Label ID="lblNodes" runat="server"></asp:Label>
               </td>                
           </tr>           
                    <tr>
                        <td align="center" colspan="6">
                    <asp:ImageButton ID="imgBtnPasswordClose" runat="server" ImageUrl="~/Images/CloseBtn.png"
                 CausesValidation="False" onclick="imgBtnPasswordClose_Click" />
                        </td>
                    </tr>
                </table>
   </asp:Panel>
        <table width="1024" align="center" cellpadding="0" cellspacing="0" style="background-image:url(Images/LoginPageBackground.png); height :500px">
            <tr>
              <td width="652" height="185"> &nbsp;             </td>
              <td width="129">              &nbsp;  </td>
              <td width="188">             &nbsp;   </td>
              <td width="53">           &nbsp;     </td>
            </tr>
            <tr>
                <td height="38">                </td>
              <td>                </td>
                <td align="left" ><asp:TextBox ID="txtName" CssClass="input1" runat="server" 
                        Width=140px BackColor="transparent" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ErrorMessage="请输入账号" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
                <td align="left"> &nbsp;
                    </td>
            </tr>
            <tr>
                <td height="15" align="center" style="padding-left:250px; font-size:large">      </td>
              <td>        &nbsp;        </td>
                <td>      &nbsp;           </td>
                <td>       &nbsp;          </td>
            </tr>
            <tr>
                <td height="38" align="left" style="padding-left:300px; font-size:large">               </td>
              <td>             &nbsp;    </td>
                <td align="left">
                    <asp:TextBox ID="txtPw" CssClass="input1" Width=140px runat="server" TextMode="Password" BackColor="transparent"></asp:TextBox>               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPw" ErrorMessage="请输入密码" ForeColor="Red">*</asp:RequiredFieldValidator> </td>
                <td>                </td>
            </tr>
            <tr>
                <td>       &nbsp;          </td>
                <td>      &nbsp;           </td>
                <td>     &nbsp;            </td>
                <td>     &nbsp;            </td>
            </tr>
            <tr>
                <td  rowspan="3" style="height: 344px" valign="bottom" align="center">  
                    <table style="height:235px"><tr><td valign="top">
                       <marquee id="m1" direction="left" width="580px" behavior="scroll" scrollamount="10" scrolldelay="200" onMouseOut="this.start()"  onMouseOver="this.stop()">
                            <asp:DataList ID="dl_photos" runat="server" RepeatColumns="50" 
                                onitemcommand="dl_photos_ItemCommand">
                                <ItemTemplate>                                    
                                    <asp:ImageButton ID="img2" runat="server" Width="200px" Height="180px" ImageUrl='<%# Eval("EquipmentPhotoPath") %>' CommandName="ShowEquipment" CommandArgument='<%# Eval("EquipmentId") %>' CausesValidation="false" />
                                </ItemTemplate>
                            </asp:DataList></marquee> 
                     </td></tr></table>       
                </td>
                <td colspan="2" valign="top" align="center" style="height:150px;">                    
                              <table cellpadding="0" cellspacing="0" style="height:50px;">
                                        <tr>
                                            <td align=center>
                                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                                    ImageUrl="Images/LoginBtn.png" onclick="ImageButton1_Click" />    
                                                                            </td>
                                                <td>&nbsp;                          </td>
                                            <td align=center>
                                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                                    ImageUrl="Images/ResetBtn.png"  
                                                    CausesValidation="False" onclick="ImageButton2_Click" />    
                                                                </td>
                                                <td>&nbsp;                          </td>
                                            <td align=center>
                                                <asp:LinkButton CssClass="red" Font-Bold="True" 
                                                    Font-Names="黑体" Font-Size="11pt" ForeColor="#FF3300" ID="lb_regist" 
                                                    runat="server"  CausesValidation="False" onclick="lb_regist_Click"><span class="STYLE38">注册用户</span></asp:LinkButton>                            </td>
                                        </tr>
                                        <tr>
                                            <td align=center>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="Images/LoginBtnDown.png" />                            </td>
                                            <td align=center>&nbsp;                          </td>
                                            <td align="center">
                                              <asp:Image ID="Image2" runat="server" ImageUrl="Images/LoginBtnDown.png" />                            </td>
                                              <td align=center>&nbsp;                          </td>
                                            <td align="center">
                                              <asp:Image ID="Image3" runat="server" ImageUrl="Images/LoginBtnDown.png" />                            </td>
                                </tr>
                                
                                       
                                  </table> 
                    </td>
                    <td> &nbsp;</td>
            </tr>
            <tr valign="top">
                <td height="50px" colspan="2" valign="top" align="left"> 
                 <asp:Label ID="lb_systemInfo" runat="server"></asp:Label>
                 </td>
                
                <td>     &nbsp;      </td>
            </tr>
            <tr>
            <td colspan="2" valign="top" align="left">
            </td>
                <td>       &nbsp;          </td>
            </tr>
            <tr>
                <td align="left" colspan="4" valign="top">
                <hr />
                <table>
                <tr>
                    <td width="200px">&nbsp;</td>
                    <td align="left">地址：哈尔滨市南岗区黄河路73号 哈尔滨工业大学二校区 &nbsp;&nbsp;&nbsp;&nbsp;<a href="Images/演示操作脚本流程.doc" target="_blank" style="color:Red">预约流程下载</a><br />
                Address: The Second Campus of Harbin Institute of Technology, 73 Huanghe Road, Nanggang District, Harbin, China<br />
                联系电话：(0451)86283067 &nbsp;&nbsp;&nbsp;
                传真：(0451)86283067<br />
                Tel： (0451)86283067 &nbsp;&nbsp;&nbsp;&nbsp;
                Fax： (0451)86283067 
                </td>
                    </tr>
                </table>
                
                </td>
            </tr>
      </table>
      </center>
    </form>
</body>
</html>
