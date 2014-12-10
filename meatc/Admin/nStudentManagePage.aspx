<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nStudentManagePage.aspx.cs" Inherits="Admin_nStudentManagePage" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/SchoolListImg.png" />
       </td>
          <td>
            <asp:DropDownList ID="ddl_searchType" runat="server">
                <asp:ListItem Text="按姓名搜索" Value="1" Selected="True"></asp:ListItem>
                <asp:ListItem Text="按学号搜索" Value="2"></asp:ListItem>
                
            </asp:DropDownList>
        <asp:TextBox ID="tb_teaName" runat="server"></asp:TextBox>
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
        <asp:GridView ID="gv_student" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="3" 
            GridLines="Vertical" HorizontalAlign="Center" Width="100%" 
            onpageindexchanging="gv_student_PageIndexChanging" DataKeyNames="UserId" 
            onrowdatabound="gv_student_RowDataBound" 
            onrowdeleting="gv_student_RowDeleting" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" PageSize="15">
            <PagerSettings PageButtonCount="20" />
            <HeaderStyle Height="30px" BackColor="#000084" HorizontalAlign="Center" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" Height="20pt" HorizontalAlign="Center"  />
            <Columns>
                <asp:BoundField DataField="LoginName" HeaderText="登录用户名" />
                <asp:BoundField DataField="UserName" HeaderText="学生姓名" />
                <asp:BoundField DataField="UserSex" HeaderText="性别"  />
                <asp:BoundField DataField="MobileTelephone" HeaderText="联系方式" />
                <asp:BoundField HeaderText="所属导师" />                
                <asp:HyperLinkField HeaderText="编辑/查看" Text="编辑/查看" DataNavigateUrlFields="UserId"  DataNavigateUrlFormatString="nEditStudent.aspx?u_id={0}"/>
                <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True" />
            </Columns>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" 
                BorderStyle="Dotted" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
        </asp:GridView>
    </td>
   </tr>
    <tr>
   <td align=center valign=middle height=30px>
       <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png" 
           onclick="imgBtnAdd_Click" />
     </td>
   </tr>
   </table>
</asp:Content>

