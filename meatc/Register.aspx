<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<style type="text/css">
        .style1
        {
            height: 90px;
        }
        .style2
        {
            height: 35px;
        }
        .style3
        {
            height: 532px;
        }
        </style>
    <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
    <link href="~/Admin/Css/default.css" rel="stylesheet" type="text/css" />
    <title>无标题页</title>
</head>
<body style="margin-top:0px">
    <form id="form1" runat="server">
    <div style="background:url(Images/ZhuCeBackPageImg.png); background-repeat:no-repeat; background-position:center;"><%--no-repeat;--%>
    <table width=100% border=0 cellpadding=0 cellspacing=0>
    <tr><td colspan=2 class="style1">
       
        </td></tr>
    <tr><td width="230px" class="style2"></td><td width="790px" class="style2"></td></tr>
    <tr>
      <td valign=top align=center><br />
        <br /></td>
      <td class="style3" valign=top align=center><br />
        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
          <td height="46" valign="bottom" align="left" nowrap="nowrap"><table width="100%">
              <tr>
                <td width="100%"  align="left">&nbsp;</td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td height="396" align="left" valign="top"><table width="100%" align="left" cellpadding="0" cellspacing="0">
              <tr>
                <td height="30" width="50px" valign="top" align="right" class="blue">
                <asp:Label ID="lb_schoolNo" runat="server">登录名称</asp:Label>
                </td>
                <td width="10">&nbsp;</td>
                <td width="546" align="left" valign="top"><asp:TextBox ID="txtLoginName" runat="server" Width="150px" Enabled="false"></asp:TextBox>
                  &nbsp;
                  <asp:ImageButton ID="imgBtnCheckUser" runat="server" Visible="false"
                        ImageUrl="Images/JianChaYongHuMingBtn.png" CausesValidation="False" 
                        onclick="imgBtnCheckUser_Click" />
                  &nbsp;
                  <asp:Label ID="lblNameInfo" runat="server" ForeColor="Red">用户名将在创建成功后获得，请注意“添加”后的弹出信息。</asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入登陆用户名称" ControlToValidate="txtLoginName" ForeColor="Red">*</asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr runat="server" id="trPassword" valign="top">
                <td height="30" width="50px" align="right" class="blue">登录密码</td>
                <td>&nbsp;</td>
                <td align="left" valign="top">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="请输入密码" ControlToValidate="txtPassword" ForeColor="Red">请输入密码</asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr runat="server" id="trRepeatPassword">
                <td height="30" width="50px" valign="top" align="right" class="blue"> 确认密码</td>
                <td>&nbsp;</td>
                <td align="left" valign="top"><asp:TextBox ID="txtRepeatPassword" runat="server" 
                        TextMode="Password" Width="150px"></asp:TextBox>
                           <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ErrorMessage="请确认密码输入正确" ControlToCompare="txtPassword" 
                            ControlToValidate="txtRepeatPassword" ForeColor="Red">请确认密码输入正确</asp:CompareValidator>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" valign="top" align="right" class="blue">用户类型</td>
                <td>&nbsp;</td>
                <td align="left" valign="top">
                <asp:DropDownList ID="ddlUserType" runat="server" Width="150px" AutoPostBack="true" 
                        onselectedindexchanged="ddlUserType_SelectedIndexChanged">
                    <asp:ListItem Value="1">本院学生</asp:ListItem>       
                    <asp:ListItem Value="5">本校学生</asp:ListItem>                    
                    <asp:ListItem Selected="True" Value="0">校外用户</asp:ListItem>
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" valign="top" class="blue"> 姓名</td>
                <td>&nbsp;</td>
                <td align="left" valign="top"><asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="请输入姓名" ControlToValidate="txtName" ForeColor="Red">请输入姓名</asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 性别</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:DropDownList ID="ddlSex" runat="server" Width="50px">
                    <asp:ListItem Value="0">女</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 出生日期</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 固定电话</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
           ErrorMessage="请输入正确的电话号码" Text="请输入正确的电话号码" ControlToValidate="txtPhone" ForeColor="Red" 
                            ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}"></asp:RegularExpressionValidator>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 手机</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:TextBox ID="txtMobileTelephone" runat="server" Width="150px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 邮箱</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="请输入正确的邮箱地址" Text="请输入正确的邮箱地址" ControlToValidate="txtEmail" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
                </td>
              </tr>
              <tr>
                <td height="30" width="50px" align="right" class="blue"> 工作单位</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:TextBox ID="txtBureau" runat="server" Width="400px"></asp:TextBox>
                </td>
              </tr>
                <tr>
                <td height="34" width="50px" align="right" class="blue"> 职称</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:TextBox ID="txtUserPost" runat="server" Width="400px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="25" width="50px" align="right" class="blue"> 备注</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                    <asp:TextBox ID="txtResearch" runat="server" 
                        TextMode="MultiLine" Width="400px" Height="50px"></asp:TextBox>
                </td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td align="left" valign=middle height=40px>
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/Images/QueRenBtn.png" onclick="imgBtnEdit_Click" />      
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgBtnBack" runat="server" 
                  ImageUrl="Images/FanHuiBtn.png" CausesValidation="False" 
                  onclick="imgBtnBack_Click" />
          </td>
        </tr>
      </table></td>
    </tr>
    <tr><td colspan=2 height="25px"></td></tr>    
    </table>
    </div>
    </form>
</body>
</html>
