<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipmentStatisticInfoSearch.aspx.cs" Inherits="Admin_nEquipmentStatisticInfoSearch" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentUseImg.png"/>
           
           
       </td>  
       <td valign=bottom>
            &nbsp;</td>
       <td valign=bottom>&nbsp;</td> 
       </tr>
       </table>      
       </td>       
   </tr>
   
  
   <tr>
   <td valign=top>
      
       <asp:GridView ID="GVFaultEquipment" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" RowStyle-HorizontalAlign="Center" 
              BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" 
              onpageindexchanging="GVFaultEquipment_PageIndexChanging" 
              onrowcommand="GVFaultEquipment_RowCommand" PageSize="18">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" Height="20px" />
           <Columns>
               <asp:HyperLinkField HeaderText="设备名称" ControlStyle-CssClass="blue" 
                   DataTextField="EquipmentName" DataNavigateUrlFields="EquipmentId" 
                   DataNavigateUrlFormatString="nHowToUseEquipment.aspx?e_id={0}" >
                   <ControlStyle CssClass="blue" />
               </asp:HyperLinkField>
               <asp:BoundField HeaderText="设备类型" DataField="EquipmentTypeName" />
               <asp:TemplateField HeaderText="设备管理员">
                <ItemTemplate>
                    <asp:LinkButton ID="lb_equipManager" runat="server" Text='<%# Eval("UserName") %>' CommandArgument='<%# Eval("UserId") %>' CommandName="ShowEquipManager"></asp:LinkButton>
                </ItemTemplate>
               </asp:TemplateField>               
               <asp:BoundField DataField="FrequencyOfUse" HeaderText="使用次数" />
               <asp:BoundField DataField="ToTalMoney" HeaderText="费用总额" />
               <asp:BoundField DataField="StateName" HeaderText="设备状态" 
                   SortExpression="StateName">
                   <HeaderStyle Width="10%" />
               </asp:BoundField>
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Height="25px" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       
       </td>
   </tr>   
   </table>
</asp:Content>

