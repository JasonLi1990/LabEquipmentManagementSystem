<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nTeacherEdit.aspx.cs" Inherits="Admin_nTeacherEdit" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<asp:Panel ID="panelUpdatePassword" runat="server" Visible="false" CssClass="d5" style=" position:absolute;width:400px; height:150px; z-index:100; top: 225px; left: 424px; background-color:White; border:solid">
<table width=100% cellpadding=0 cellspacing=0 border=0>
<tr>
<td colspan=2 height="10px"></td>
</tr>
<tr>
<td height=30px class="blue" width=150px align=right>原始密码</td>
<td width="10px"></td>
<td align=left ><asp:TextBox ID="txtOldPassword" runat="server" 
        TextMode="Password" Width=150px ></asp:TextBox>
        <asp:HiddenField ID="hfOld" runat="server" />
        </td>
</tr>
<tr>
<td height=30px class="blue" width=150px align=right>输入新密码</td>
<td width="10px"></td>
<td align=left ><asp:TextBox ID="txtPanelPassword" runat="server" 
        TextMode="Password" Width=150px ></asp:TextBox></td>
</tr>
<tr>
<td height=30px class="blue" align=right>确认新密码</td>
<td width="10px"></td>
<td align=left><asp:TextBox ID="txtPanelRepeatPassword" runat="server" 
        TextMode="Password" Width="150px"></asp:TextBox></td>
</tr>
<tr>
<td colspan=3 align="center">
    <asp:ImageButton ID="imgBtnPasswordOK" runat="server" 
        ImageUrl="~/Images/SaveBtn.png" 
        CausesValidation="False" onclick="imgBtnPasswordOK_Click"/>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="imgBtnPasswordClose" runat="server" ImageUrl="~/Images/CloseBtn.png"
        CausesValidation="False" onclick="imgBtnPasswordClose_Click" />
    </td>
</tr>
</table>
</asp:Panel>
<table width="100%" cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align=right> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/TitleBtnTeacherManage.png"/>
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align=center>
       
          <table width=90% cellpadding="0" cellspacing="0">
           <tr>
               <td width=200px align=right height=30px class="blue">
                   登录用户名称</td>
               <td width=10px>
                   &nbsp;</td>
                 <td align=left>
                     <asp:TextBox ID="txtLoginName" runat="server" Width=150px></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入登陆用户名称" ControlToValidate="txtLoginName" ForeColor="Red">请输入登陆用户名称</asp:RequiredFieldValidator>
               </td>
           </tr>
           <asp:Panel ID="panel_pwd" runat="server" Visible="true">
           <tr runat=server id="trPassword">
               <td align=right height=30px class="blue">
                   登录密码</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width=150px></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ErrorMessage="请输入密码" ControlToValidate="txtPassword" ForeColor="Red">请输入密码</asp:RequiredFieldValidator>
               </td>
           </tr>
           <tr runat=server id="trRepeatPassword">
               <td align=right height=30px class="blue">
                   确认密码</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" Width=150px></asp:TextBox>
                         
               </td>
           </tr>
           </asp:Panel>
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
               <td align="right" height=30px class="blue">
                  出生日期</td>
               <td>
                   &nbsp;</td>
                  <td align="left">
                    <asp:TextBox ID="txtBirthDate" runat="server" onClick="WdatePicker()" Width="150px"></asp:TextBox>                    
               </td>
           </tr>           
           <tr>
               <td align=right height=30px class="blue">
                  固定电话</td>
               <td>
                   &nbsp;</td>
                  <td align=left>
                    <asp:TextBox ID="txtPhone" runat="server" Width=150px></asp:TextBox>                    
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                   手机</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtMobileTelephone" runat="server" Width=150px></asp:TextBox>
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
   <td align="left" height=40px style="padding-left:100px;">
      <asp:Panel ID="panel_op" runat="server" Visible="false">
       
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEdit_Click"  />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:ImageButton ID="imgBtnBack" runat="server"
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
              onclick="imgBtnBack_Click" />
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:ImageButton ID="imgBtnEditPassword" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="imgBtnEditPassword_Click" />
           
       </asp:Panel>
       <asp:Panel ID="panel_new" runat="server" Visible="false">
            <asp:ImageButton ID="imgBtnAdd" runat="server" 
               ImageUrl="~/Images/BtnAdd.png" onclick="imgBtnAdd_Click"  />
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
               <asp:ImageButton ID="imgBtnBack2" runat="server"
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
                onclick="imgBtnBack2_Click" />
       </asp:Panel>
       
       </td>
   </tr>
   </table>
</asp:Content>

