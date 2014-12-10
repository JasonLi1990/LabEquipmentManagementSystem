<%@ Page Language="C#" MasterPageFile="~/Teacher/T_MasterPage.master" AutoEventWireup="true" CodeFile="nMyReservationList.aspx.cs" Inherits="Teacher_nMyReservationList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/YuYueInfoList.png"/>
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
    <td align="center">
        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="300px" ScrollBars="Auto">
        <asp:GridView ID="GV_MyList" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center"
           Width="100%" CellPadding="3" GridLines="Vertical" RowStyle-HorizontalAlign="Center" 
              onrowdatabound="GV_MyList_RowDataBound" BackColor="White" 
              BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                onrowcommand="GV_MyList_RowCommand">
               <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
               <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
               <Columns>
                          
                   <asp:HyperLinkField HeaderText="课题名称" ControlStyle-ForeColor="Blue" Target="_blank" DataNavigateUrlFields="ReservationInfoId" DataNavigateUrlFormatString="~/Student/nShowIssueOfReservation.aspx?r_id={0}&type=teacher" DataTextField="IssueName" />
                   <asp:BoundField HeaderText="预约总价" DataField="Total">
                   
                   </asp:BoundField>
                    <asp:BoundField HeaderText="审批状态" DataField="StateName">
                   
                   </asp:BoundField>  
                   
                   <asp:HyperLinkField DataNavigateUrlFields="ReservationInfoId" Target="_blank" DataNavigateUrlFormatString="~/Student/nShowEquipOfReservation.aspx?r_id={0}&type=teacher"
                     HeaderText="预约设备"  ControlStyle-ForeColor="Blue"
                       Text="点击查看" >
                   
                       <ControlStyle CssClass="blue" />
                   </asp:HyperLinkField>
                   
                   <asp:HyperLinkField HeaderText="查看消息" Text="点击查看"  ControlStyle-ForeColor="Blue"
                       DataNavigateUrlFields="ReservationInfoId" 
                       DataNavigateUrlFormatString="~/Student/nShowMsgOfReservation.aspx?r_id={0}&type=teacher" >
                   
                       <ControlStyle CssClass="blue" />
                   </asp:HyperLinkField>
                   
                   <asp:TemplateField HeaderText="取消预约">
                       <ItemTemplate>
                           <asp:LinkButton ID="LBtnDelIssue" ForeColor="Blue" OnClientClick="return confirm('确认取消此预约吗？')" CssClass="blue" CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="DelIssue" Text='取消预约' runat="server" Font-Size="10pt" Font-Underline="False"></asp:LinkButton>
                       </ItemTemplate>
                       <HeaderStyle  Height="30px"/>
                       <ItemStyle Height="30px" />
                   </asp:TemplateField>           
               </Columns>
               <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
               <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
               <AlternatingRowStyle BackColor="#DCDCDC" />
           </asp:GridView>
           </asp:Panel>
           </td>
       </tr>
       <tr>
       <td  align="right" valign="middle" class="txtcolor" height="30px">
          总计：<asp:Label ID="lblTotal" runat="server"></asp:Label>元
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
           </td>
       </tr>    
       
    
   </table>
</asp:Content>

