<%@ Page Language="C#" MasterPageFile="~/Teacher/T_MasterPage.master" AutoEventWireup="true" CodeFile="nSelfInfo.aspx.cs" Inherits="Teacher_nSelfInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" colspan="2" valign=bottom align=left style="background:url(../Images/Contentback01.png) no-repeat;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align="left"> <asp:ImageButton ID="ImageButton5" runat="server" 
               ImageUrl="~/Images/PersonalInfoEditImg.png"  />
       </td>       
       </tr>
       </table>      
       </td>       
       
   </tr>
   <tr>
   <td rowspan="3" valign="top" style="width:300px; padding-left:10px" align="center">
           <asp:GridView ID="gv_student" runat="server" AutoGenerateColumns="False" Width="100%" 
               BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" DataKeyNames="UserId" 
               CellPadding="3" GridLines="Vertical">
               <HeaderStyle Height="30px" />
               <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
               <RowStyle BackColor="#EEEEEE" ForeColor="Black" Height="23px" />
               <Columns>
                   <asp:BoundField HeaderText="学号" DataField="LoginName" />
                   <asp:BoundField HeaderText="姓名" DataField="UserName" />
                   <asp:TemplateField HeaderText="性别">
                        <ItemTemplate>
                            <asp:Label ID="lb_sex" runat="server" Text='<%# Eval("UserSex").ToString().Equals("1")?"男":"女" %>'></asp:Label>
                        </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField HeaderText="选择并审批">
                    <ItemTemplate>
                        <asp:CheckBox ID="cb_select" runat="server" />
                    </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
               <AlternatingRowStyle BackColor="#DCDCDC" />
            
           </asp:GridView>
           <br />
           <asp:CheckBox ID="cb_selectAll" runat="server" Text="全选" AutoPostBack="true" 
               oncheckedchanged="cb_selectAll_CheckedChanged" />
           <asp:ImageButton ID="bt_studentApply" runat="server" 
               OnClientClick="return confirm('您确定要将这些学生的导师设置为自己？')" 
               ImageUrl="~/Images/BtnUpdate.png" onclick="bt_studentApply_Click" />
       </td>
       <td align="left">
        <table width="300px" cellpadding="0" cellspacing="0">
           <tr>
               <td width="150px" align=right height=30px class="blue">
                   登录用户名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtLoginName" runat="server" Width=150px></asp:TextBox>
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
                        <asp:TextBox ID="txtPhone" runat="server" Width=150px></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
           ErrorMessage="请输入正确的电话号码" Text="请输入正确的电话号码" ControlToValidate="txtPhone" ForeColor="Red" 
                            ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}"></asp:RegularExpressionValidator>
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
   <td align="center" style="width:400px" valign="top">
      
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEdit_Click"  />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
           onclick="imgBtnBack_Click" />
       
       </td>
       
   </tr>
   
   <tr>
    <td class="blue" align="center">
        <table width=90%>
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
        </table>
       
        
       
        <asp:ImageButton ID="imgBtnEditPassword" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="imgBtnEditPassword_Click" />
    </td>
   </tr>
   </table>
</asp:Content>

