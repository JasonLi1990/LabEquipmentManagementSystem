<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nSelfInfo.aspx.cs" Inherits="EquipManager_nSelfInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:Panel ID="panel_pwd" runat="server" Visible="false" CssClass="d5" style=" position:absolute;width:400px; height:120px; z-index:100; top: 225px; left: 424px; background-color:White; border:solid;">
    <table width="100%">
            <tr>
                <td align="right">旧密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="tb_oldPwd" runat="server" TextMode="Password" MaxLength="20" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">新密码：
                </td>
                <td align="left">
                    <asp:TextBox ID="tb_newPwd" runat="server" TextMode="Password" MaxLength="20" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">再输一次：
                </td>
                <td align="left">
                    <asp:TextBox ID="tb_makesure" runat="server" TextMode="Password" MaxLength="20" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:ImageButton ID="imgBtnEditPassword" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="imgBtnEditPassword_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgBtnPasswordClose" runat="server" ImageUrl="~/Images/CloseBtn.png"
         CausesValidation="False" onclick="imgBtnPasswordClose_Click" />
                </td>
            </tr>
        </table>
   </asp:Panel>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align=right> <asp:ImageButton ID="ImageButton5" runat="server" 
               ImageUrl="~/Images/PersonalInfoEditImg.png"  />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="center">
        <table width=90% cellpadding="0" cellspacing="0">
           <tr>
               <td width=250px align=right height=30px class="blue">
                   登录用户名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtLoginName" Enabled="false" runat="server" Width=150px></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入登陆用户名称" ControlToValidate="txtLoginName" ForeColor="Red">请输入登陆用户名称</asp:RequiredFieldValidator>
               </td>
           </tr>
           
           <tr>
               <td align=right height=30px class="blue">
                   姓名</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtName" runat="server" Width=150px></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ErrorMessage="请输入姓名" ControlToValidate="txtName" ForeColor="Red">请输入姓名</asp:RequiredFieldValidator>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                   性别</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:DropDownList ID="ddlSex" runat="server" Width=50px>
                            <asp:ListItem Value="0">女</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                        </asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  出生日期</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  固定电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtPhone" runat="server" Width=150px 
                            ></asp:TextBox>                        
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                   手机</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtMobileTelephone" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="phone" runat="server" Display="Dynamic" ControlToValidate="txtMobileTelephone" ErrorMessage="手机号码必须填写"></asp:RequiredFieldValidator>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  邮箱</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtEmail" runat="server" Width=150px></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="请输入正确的邮箱地址" Text="请输入正确的邮箱地址" ControlToValidate="txtEmail" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
               </td>
           </tr>          
       </table>
       
       </td>
   </tr>
   <tr>
   <td align=center height=40px>
      
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEdit_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
           onclick="imgBtnBack_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="bt_showpanel" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="bt_showpanel_Click" />
       </td>
   </tr>
  
   <tr>
    <td class="blue" align="center">
        
    </td>
   </tr>
   </table>
</asp:Content>

