<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nAddNewManager.aspx.cs" Inherits="Admin_nAddNewManager" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

<asp:Panel ID="panelUpdatePassword" runat="server" Visible="false" CssClass="d5" style="position:absolute;width:400px; height:120px; z-index:100; top: 225px; left: 424px; background-color:White; border:solid">
<table width=100% cellpadding=0 cellspacing=0 border=0>
<tr>
<td colspan=2 height=10px></td>
</tr>
<tr>
<td height=30px class="blue" width=150px align=right >登录密码</td>
<td width="10px"></td>
<td  align=left><asp:TextBox ID="txtPanelPassword" runat="server" TextMode="Password" Width=150px></asp:TextBox></td>
</tr>
<tr>
<td height=30px class="blue" align=right >确认密码</td>
<td width="10px"></td>
<td align=left><asp:TextBox ID="txtPanelRepeatPassword" TextMode="Password" runat="server" Width=150px></asp:TextBox></td>
</tr>
<tr>
<td colspan=3 align="center">
    <asp:ImageButton ID="imgBtnPasswordOK" runat="server" 
        ImageUrl="~/Images/SaveBtn.png" CausesValidation="False" 
        onclick="imgBtnPasswordOK_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="imgBtnPasswordClose" runat="server" 
        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnPasswordClose_Click" />
    </td>
</tr>
</table>
</asp:Panel>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="40px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align=right><asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentManagerEditBtn.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="center" valign="top">
       
        <table width="90%" cellpadding="0" cellspacing="0">
           <tr>
               <td width="100px" align="right" height=30px class="blue">
                   登录用户名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtLoginName" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入登陆用户名称" ControlToValidate="txtLoginName" ForeColor="Red">请输入登陆用户名称</asp:RequiredFieldValidator>
               </td>
           </tr>
           <asp:Panel ID="panel_new" runat="server">
           <tr runat=server id="trPassword">
               <td align=right height=30px class="blue">
                   登录密码</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
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
                        <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ErrorMessage="请确认密码输入正确" ControlToCompare="txtPanelPassword" 
                            ControlToValidate="txtPanelRepeatPassword" ForeColor="Red">请确认密码输入正确</asp:CompareValidator>
               </td>
           </tr>
           </asp:Panel>
           <tr>
               <td align=right height=30px class="blue">
                   姓名</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
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
                        <asp:DropDownList ID="ddlSex" runat="server" Width="150px" 
                            CausesValidation="True">
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
                        <asp:TextBox ID="txtPhone" runat="server" Width="150px"></asp:TextBox>
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
                        <asp:TextBox ID="txtMobileTelephone" runat="server" Width="150px"></asp:TextBox>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  邮箱</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtEmail" runat="server" Width="150px"></asp:TextBox>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="请输入正确的邮箱地址" Text="请输入正确的邮箱地址" ControlToValidate="txtEmail" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
               </td>
           </tr>               
            <tr>
               <td align="right" height="30px" valign="top" class="blue">
                   所管设备</td>
               <td>
                   &nbsp;</td>
                    <td align="center" valign="top">
                        <asp:GridView ID="GVEquipmentList" runat="server" AutoGenerateColumns="False" 
                                       Width="100%" PageSize="5" BackColor="White" 
                            BorderColor="#E7E7FF" CellSpacing="1"
                                       BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                            GridLines="Horizontal" onrowcommand="GVEquipmentList_RowCommand" 
                            onpageindexchanging="GVEquipmentList_PageIndexChanging">
                                       <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                       <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                           <Columns>             
                                <asp:HyperLinkField HeaderText="设备名称" DataTextField="EquipmentName" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" Target="_blank" />
                                <asp:BoundField HeaderText="设备型号" DataField="EquipmentModel">
                               <HeaderStyle Width="20%" CssClass="blue" />
                               </asp:BoundField>     
                               <asp:BoundField HeaderText="设备类型" DataField="EquipmentTypeName">
                               <HeaderStyle Width="20%" CssClass="blue" />
                               </asp:BoundField>  
                               <asp:BoundField HeaderText="状态" DataField="StateName">
                               <HeaderStyle Width="15%" CssClass="blue" />
                               </asp:BoundField>   
                                <asp:TemplateField HeaderText="删除">
                                   <ItemTemplate>
                                       <asp:ImageButton ID="ImgBtnDel" OnClientClick="return confirm('确定要删除此关联吗？删除后，此设备所属管理员为空...')" CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipDel" runat="server" ImageUrl="~/Images/DELBtn.png" CausesValidation="False"/>
                                   </ItemTemplate>
                                   <HeaderStyle Width="10%" CssClass="blue" />
                               </asp:TemplateField>
                           </Columns>
                                       <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                       <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                                       <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                                       <AlternatingRowStyle BackColor="#F7F7F7" />
                       </asp:GridView>
               </td>
           </tr>     
           <tr>
            <td align="center" colspan="3">
                
            </td>
           </tr>
                         
       </table>
       
       </td>
   </tr>
   <tr>
   <td align="left" height=35px valign="top">
       <asp:ImageButton ID="imgBtnEditPassword" runat="server" ToolTip="修改密码" ImageUrl="~/Images/UpdatePasswordBtn.png"
            CausesValidation="False" onclick="imgBtnEditPassword_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEdit_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
           onclick="imgBtnBack_Click" />
       
       </td>
   </tr>
   </table>
</asp:Content>

