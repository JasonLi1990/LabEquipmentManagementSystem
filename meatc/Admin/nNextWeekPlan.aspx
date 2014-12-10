<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nNextWeekPlan.aspx.cs" Inherits="Admin_nNextWeekPlan" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align="left" valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/WithoutApprovalImg.png"/>           
           
       </td>  
       <td valign="bottom">
            &nbsp;</td>
            
       <td valign="middle">
            请选择：<asp:DropDownList ID="ddl_state" runat="server" Width="150px" 
                AutoPostBack="True" onselectedindexchanged="ddl_state_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                       <asp:ListItem Value="10">通过审批</asp:ListItem>
                       <asp:ListItem Value="12">待导师审批</asp:ListItem>
                       <asp:ListItem Value="13">待设备管理员审批</asp:ListItem>
                       <asp:ListItem Value="14">未通过导师审批</asp:ListItem>
                       <asp:ListItem Value="15">未通过最后审批</asp:ListItem>                                              
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;
            总额：<asp:Label ID="lb_total" runat="server" CssClass="blue"></asp:Label>
       </td> 
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td valign=top>
      <asp:Panel ID="Panel1" runat="server" Width="100%" Height="400px" Visible="false" ScrollBars="Auto">
       <asp:GridView ID="GVWithoutApproval" runat="server" AutoGenerateColumns="False" 
           Width="98%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
              BorderWidth="1px" CellPadding="3" GridLines="Vertical">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <HeaderStyle HorizontalAlign="Center" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" Height="20px" HorizontalAlign="Center" />
           <Columns> 
                <asp:HyperLinkField HeaderText="课题名称" ControlStyle-CssClass="blue" DataTextField="IssueName" Target="_blank" DataNavigateUrlFields="ReservationInfoId" DataNavigateUrlFormatString="~/EquipManager/nShowIssue.aspx?r_id={0}&type=admin" />
               <asp:HyperLinkField HeaderText="申请学生" ControlStyle-CssClass="blue" DataNavigateUrlFields="UserId" Target="_blank" DataNavigateUrlFormatString="nEditStudent.aspx?u_id={0}" DataTextField="UserName" />
               
               <asp:BoundField HeaderText="预约开始时间" DataField="BeginReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Height="30px" />
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约结束时间" DataField="EndReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
               
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约价格" DataField="Total">
               <HeaderStyle Width="10%" />
               </asp:BoundField>
                <asp:BoundField HeaderText="当前状态" DataField="StateName">
               
               </asp:BoundField>            
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
   <td height=35px align=center valign=middle>
       <asp:ImageButton ID="imgBtnCreateWeekPlan" runat="server" 
           ImageUrl="~/Images/BtnCreateWeekPlan.png" onclick="imgBtnCreateWeekPlan_Click"/>
       <asp:Label ID="lb_weektime" runat="server"></asp:Label>
       </td>
   </tr>  
   </table>
</asp:Content>

