<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nSelfInfoManage.aspx.cs" Inherits="Admin_nSelfInfoManage" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<asp:Panel ID="panelUpdatePassword" runat="server" Visible=false CssClass="d5" style=" position:absolute;width:400px; height:120px; z-index:100; top: 225px; left: 424px; background-color:White">
<table width=100% cellpadding=0 cellspacing=0 border=0>
<tr>
<td colspan=2 height="10px"></td>
</tr>
<tr>
<td height=30px class="blue" width=150px align=right>登录密码</td>
<td width="10px"></td>
<td align=left><asp:TextBox ID="txtPanelPassword" runat="server" TextMode="Password" Width=150px></asp:TextBox></td>
</tr>
<tr>
<td height=30px class="blue" align="right" >确认密码</td>
<td width="10px"></td>
<td align=left><asp:TextBox ID="txtPanelRepeatPassword" runat="server" TextMode="Password" Width=150px></asp:TextBox></td>
</tr>
<tr>
<td colspan=3>
    <asp:ImageButton ID="imgBtnPasswordOK" runat="server" ImageUrl="~/Images/SaveBtn.png"
         CausesValidation="False" onclick="imgBtnPasswordOK_Click" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="imgBtnPasswordClose" runat="server" ImageUrl="~/Images/CloseBtn.png"
         CausesValidation="False" onclick="imgBtnPasswordClose_Click" />
    </td>
</tr>
</table>
</asp:Panel>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(Images/Contentback01.png) no-repeat;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align="left"> <asp:ImageButton ID="ImageButton5" runat="server" 
               ImageUrl="~/Images/gerenxinxiEdit.png"  />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td height="396" align="center" valign=top><table width="98%" align="left" cellpadding="0" cellspacing="0">                        
              <tr>
                <td height="36" align="right" class="blue"> 姓名</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="请输入姓名" ControlToValidate="txtName" ForeColor="Red">请输入姓名</asp:RequiredFieldValidator>
                </td>
              </tr>
              <tr>
                <td height="37" align="right" class="blue"> 性别</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:DropDownList ID="ddlSex" runat="server" Width="50px">
                    <asp:ListItem Value="0">女</asp:ListItem>
                    <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                  </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td height="35" align="right" class="blue"> 出生日期</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="36" align="right" class="blue"> 固定电话</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>               
                </td>
              </tr>
              <tr>
                <td height="31" align="right" class="blue"> 手机</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle"><asp:TextBox ID="txtMobileTelephone" runat="server" Width="150px"></asp:TextBox>
                </td>
              </tr>
              <tr>
                <td height="37" align="right" class="blue"> 邮箱</td>
                <td>&nbsp;</td>
                <td align="left" valign="middle">
                <asp:TextBox ID="txtEmail" runat="server" Width="70%"></asp:TextBox>               
                </td>
              </tr>              
          </table></td>
   </tr>
   <tr>
   <td align=center height=40px>
      
       <asp:ImageButton ID="imgBtnEditPassword" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="imgBtnEditPassword_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEdit_Click" />       
       </td>
   </tr>
   </table>
</asp:Content>

