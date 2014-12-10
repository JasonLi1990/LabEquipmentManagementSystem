<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipManagerList.aspx.cs" Inherits="Admin_nEquipManagerList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png);  background-repeat:repeat-x;">
       <table width=150px>
       <tr>
       <td width=150px align=right>
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentManagerListImg.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td>
        <asp:GridView ID="gv_equipManager" runat="server" HeaderStyle-Height="30px" 
                AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" 
                onrowdatabound="gv_equipManager_RowDataBound" Width="95%" 
            onpageindexchanging="gv_equipManager_PageIndexChanging" OnRowDeleting="gv_equipManager_RowDeleting" BackColor="White"
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" PageSize="15">
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle HorizontalAlign="Center" Font-Size="11pt" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" Height="25px" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="LoginName" HeaderText="用户名">
                        <ItemStyle Height="25px" />
                    </asp:BoundField>
                    
                    <asp:HyperLinkField DataNavigateUrlFields="UserId" ControlStyle-CssClass="blue" 
                        DataNavigateUrlFormatString="nEquipManagerInfo.aspx?u_id={0}" 
                        HeaderText="姓名" DataTextField="UserName" />
                    <asp:BoundField DataField="UserSex" HeaderText="性别" />
                    <asp:BoundField DataField="MobileTelephone" HeaderText="手机" />
                    <asp:HyperLinkField DataNavigateUrlFields="UserId" 
                        DataNavigateUrlFormatString="nAddNewManager.aspx?u_id={0}" 
                        HeaderText="修改" Text="修改" />
                    <asp:CommandField HeaderText="删除" DeleteText="删除" ShowDeleteButton="True" />
                </Columns>
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
         </td>
           </tr>
             <tr>
           <td align=center valign=middle height=30px>
               <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png" onclick="imgBtnAdd_Click" 
                   />
             </td>
           </tr>
   </table>
</asp:Content>

