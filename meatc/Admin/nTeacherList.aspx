<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nTeacherList.aspx.cs" Inherits="Admin_nTeacherList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align=right> 
          
           <asp:ImageButton ID="imgTitle" runat="server" 
               ImageUrl="~/Images/TitleBtnTeacherManage.png" onclick="imgTitle_Click" />
       </td>
       <td>
        请输入导师姓名：<asp:TextBox ID="tb_teaName" runat="server"></asp:TextBox>
           <asp:Button Width="60px" ID="bt_search" runat="server" Text="搜索" 
               onclick="bt_search_Click" />
       </td>  
       <td>
        <asp:LinkButton ID="first" runat="server" Text="首页" onclick="first_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="uppage" runat="server" Text="上一页" onclick="uppage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="nextpage" runat="server" Text="下一页" onclick="nextpage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lastpage" runat="server" Text="尾页" onclick="lastpage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        跳至第
        <asp:DropDownList ID="ddl_page" runat="server" Width="45px" AutoPostBack="True" 
               onselectedindexchanged="ddl_page_SelectedIndexChanged"></asp:DropDownList>
        页
       </td>     
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td>
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" 
           Width="100%" AllowPaging="True" BackColor="White" BorderColor="#E7E7FF" 
           BorderStyle="None" BorderWidth="1px" CellPadding="2" 
           GridLines="Horizontal" onpageindexchanging="GVTeacher_PageIndexChanging" 
           onrowcommand="GVTeacher_RowCommand" onrowdatabound="GVTeacher_RowDataBound">
           <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
           <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Font-Size="10pt" HorizontalAlign="Center" />
           <HeaderStyle Font-Size="11pt" HorizontalAlign="Center" />
           <Columns>
               <asp:TemplateField HeaderText="用户名">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnLoginName" CommandArgument='<%#Eval("UserId") %>' CommandName="ShowUser" Text='<%#Eval("LoginName") %>' runat="server" Font-Size="10pt" Font-Underline="False" CssClass="blue"></asp:LinkButton>
                   </ItemTemplate>
                   <HeaderStyle Width="15%" CssClass="blue" Height="30px" />
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="导师姓名">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnUserName" CommandArgument='<%#Eval("UserId") %>' CommandName="ShowUser" Text='<%#Eval("UserName") %>' runat="server" Font-Size="10pt" Font-Underline="False" CssClass="blue"></asp:LinkButton>
                   </ItemTemplate>
                   <HeaderStyle Width="10%" CssClass="blue" />
               </asp:TemplateField>
               <asp:BoundField HeaderText="性别" DataField="UserSex">
               <HeaderStyle Width="10%" CssClass="blue" />
               </asp:BoundField>
               <asp:BoundField HeaderText="年龄" DataField="BirthDate" 
                   DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Width="10%" CssClass="blue" />
               </asp:BoundField> 
               <asp:TemplateField HeaderText="修改">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnUpdate"  CommandArgument='<%#Eval("UserId") %>' CommandName="UserUpdate" runat="server" ImageUrl="~/Images/XiuGaiBtn.png" />
                   </ItemTemplate>
                   <HeaderStyle Width="10%" CssClass="blue" />
               </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnDel" OnClientClick="return confirm('确认删除？')" CommandArgument='<%#Eval("UserId") %>' CommandName="UserDel" runat="server" ImageUrl="~/Images/DELBtn.png" />
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
    <td align="right"> 
        
    </td>
   </tr>
   <tr>
   <td align="center" valign="middle" height=30px>
       <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png" onclick="imgBtnAdd_Click" 
           />
     </td>
   </tr>
   </table>
</asp:Content>

