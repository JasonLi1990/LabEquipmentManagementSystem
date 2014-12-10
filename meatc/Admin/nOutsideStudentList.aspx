<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nOutsideStudentList.aspx.cs" Inherits="Admin_nOutsideStudentList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.blue
{
	color:Blue
}
</style>
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

   

   
   <table width="100%" cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/RgUsListBtn.jpg"/>
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="center">
       <table cellpadding="0" cellspacing="0" style="width: 100%">
           <tr>
               <td width=150px height=30px>
                   <asp:DropDownList ID="ddlNameType" runat="server" Width=120px CssClass="SelectCss">
                       <asp:ListItem Selected="True" Value="0">登录名称</asp:ListItem>
                       <asp:ListItem Value="1">姓名</asp:ListItem>
                   </asp:DropDownList>
               </td>
               <td width=160px>
                   <asp:TextBox ID="txtNameText" Width=150px runat="server"></asp:TextBox>
               </td>
               <td class="blue" width=110px>
                   审批状态</td>
               <td width=150px>
                   <asp:DropDownList ID="ddlShenPiState" runat="server" Width=100px CssClass="SelectCss">
                       <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>                       
                       <asp:ListItem Value="2">待审批用户</asp:ListItem>
                       <asp:ListItem Value="1">通过审批</asp:ListItem>
                       <asp:ListItem Value="3">未通过审批</asp:ListItem>
                       
                   </asp:DropDownList>
               </td>
               <td align=left>
                   <asp:ImageButton ID="ImgBtnSelect" runat="server" 
                       ImageUrl="~/Images/SouSuoBtn.png" onclick="ImgBtnSelect_Click"/>
               </td>
           </tr>
       </table>
   </td>
   </tr>
   <tr>
   <td height=10px>
       <hr width=95% />
       </td>
   </tr>
     
    <tr>
        <td>
            <asp:GridView ID="gv_student" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="true" 
                PageSize="15" onpageindexchanging="gv_student_PageIndexChanging" 
           onrowdatabound="GVTeacher_RowDataBound" onrowcommand="gv_student_RowCommand"
           >
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" Font-Size="10pt" />
           <HeaderStyle Font-Size="11pt" />
           <Columns>
               <asp:TemplateField HeaderText="用户名">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnLoginName" CssClass="blue" CommandArgument='<%#Eval("UserId") %>' CommandName="ShowUser" Text='<%#Eval("LoginName") %>' runat="server" Font-Size="10pt" Font-Underline="False"></asp:LinkButton>
                   </ItemTemplate>
                   <HeaderStyle Width="15%" Height="30px"/>
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="姓名">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnUserName" CssClass="blue" CommandArgument='<%#Eval("UserId") %>' CommandName="ShowUser" Text='<%#Eval("UserName") %>' runat="server" Font-Size="10pt" Font-Underline="False"></asp:LinkButton>
                   </ItemTemplate>
                  
               </asp:TemplateField>
               <asp:BoundField HeaderText="用户类型" DataField="UserType" />
               <asp:BoundField HeaderText="性别" DataField="UserSex">
               <HeaderStyle Width="10%" />
               </asp:BoundField>
               <asp:BoundField HeaderText="年龄" DataField="BirthDate" DataFormatString="{0:yyyy-MM-dd}">
              
               </asp:BoundField>  
               
                <asp:BoundField HeaderText="当前状态" DataField="StateName">
              
               </asp:BoundField>    
               <asp:TemplateField HeaderText="审批">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnOK"  CommandArgument='<%#Eval("UserId") %>' CommandName="UserOK" runat="server" ImageUrl="~/Images/BtnTongGuo.png" />
                       <asp:ImageButton ID="imgBtnNO"  CommandArgument='<%#Eval("UserId") %>' CommandName="UserNO" runat="server" ImageUrl="~/Images/TongGuoNOBtn.png"/>
                       <asp:HiddenField ID="HFStateId" Value='<%#Eval("StateId") %>' runat="server" />
                   </ItemTemplate>
                   <HeaderStyle Width="15%" />
               </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnDel" CommandArgument='<%#Eval("UserId") %>' OnClientClick="return confirm('确认删除该用户吗？')" CommandName="UserDel" runat="server" ImageUrl="~/Images/DELBtn.png"/>
                   </ItemTemplate>
                   <HeaderStyle Width="5%" />
               </asp:TemplateField>
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
        </td>
    </tr>
   </table>
</asp:Content>

