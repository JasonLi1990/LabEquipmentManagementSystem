<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipBroken.aspx.cs" Inherits="Admin_nEquipBroken" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%">
<tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
        <table width=150px>
       <tr>
       <td width=150px align=right> <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/TitleBtnItemGuZhangInfo.png"  />
       </td>
       </tr>
       </table>     
   </td>       
   </tr>
   <tr>
   <td>   
   <asp:GridView ID="GVFaultEquipment" runat="server" AutoGenerateColumns="False" 
           Width="100%" AllowPaging="True" BackColor="White" BorderColor="#999999" 
           BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
           onpageindexchanging="GVFaultEquipment_PageIndexChanging" PageSize="12">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" HorizontalAlign="Center" />
           <Columns>       
                <asp:HyperLinkField HeaderText="设备名称" ControlStyle-CssClass="blue" DataTextField="EquipmentName" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" />
               
                <asp:TemplateField HeaderText="设备类型">
                   <ItemTemplate>
                       <asp:Label ID="lblEquipmentTypeName" runat="server" Text='<%#Eval("EquipmentTypeName") %>' Font-Size="10pt"></asp:Label>                       
                   </ItemTemplate>
                <HeaderStyle Height="30px" />
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:BoundField HeaderText="设备价格" DataField="EquipmentPrice">
               <HeaderStyle Width="10%" />
               </asp:BoundField>           
               <asp:BoundField HeaderText="设备管理员" DataField="UserName">
               <HeaderStyle Width="10%" />
               </asp:BoundField>  
               <asp:BoundField HeaderText="质保期限" DataField="WarrantyPeriod" DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Width="10%" />
               </asp:BoundField>  
               <asp:BoundField HeaderText="使用次数" DataField="FrequencyOfUse">
               <HeaderStyle Width="10%" />
               </asp:BoundField>  
                <asp:BoundField HeaderText="设备状态" DataField="StateName">
               <HeaderStyle Width="10%" />
               </asp:BoundField>
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

