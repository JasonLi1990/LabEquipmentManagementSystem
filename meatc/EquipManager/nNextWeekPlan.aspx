<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nNextWeekPlan.aspx.cs" Inherits="EquipManager_nNextWeekPlan" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="panelStudentInfo" runat="server" CssClass="d5" Visible="false" Style="position:absolute;
        width: 300px; height:auto; z-index: 100; top: 185px; left: 284px; background-color: White; border:solid">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            
            <tr>
                <td align="center">
                    姓名：<asp:Label ID="lb_name" runat="server" ForeColor="Blue"></asp:Label>
                <hr />                    
                    固定电话：<asp:Label ID="lb_phone" runat="server" ForeColor="Blue"></asp:Label>
                    <br />
                    手机号码：<asp:Label ID="lb_mobile" runat="server" ForeColor="Blue"></asp:Label>
                    <br />
                    电子邮箱：                    
                    <asp:Label ID="lb_email" runat="server" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40px" align="center">
                    <asp:ImageButton ID="imgBtnEquipmentclose" runat="server" 
                        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnEquipmentclose_Click" /><!--关闭按钮-->
                </td>
            </tr>
        </table>
    </asp:Panel>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=500px>
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WeekWorkPlanListImg.png"/>
       </td>       
       <td width="350px">
        <asp:Label ID="lb_nextweek" runat="server"></asp:Label>
       </td>
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td>
    <asp:Panel ID="panel_week" runat="server" ScrollBars="Auto" Height="100%" Width="100%">
        <asp:GridView ID="GVWeekTrial" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
            BorderWidth="1px" CellPadding="3" GridLines="Vertical"
            onrowcommand="GVWeekTrial_RowCommand">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" HorizontalAlign="Center" />
           <Columns>       
               <asp:HyperLinkField DataNavigateUrlFields="EquipmentId" ControlStyle-CssClass="blue" 
                   DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" 
                   DataTextField="EquipmentName" HeaderText="设备名称" >
<ControlStyle CssClass="blue"></ControlStyle>
               </asp:HyperLinkField>
               <asp:BoundField DataField="EquipmentTypeName" HeaderText="设备类型" />
               <asp:HyperLinkField DataNavigateUrlFields="ReservationInfoId"  ControlStyle-CssClass="blue"
                   DataNavigateUrlFormatString="nShowIssue.aspx?r_id={0}" DataTextField="IssueName" 
                   HeaderText="课题名称" >
<ControlStyle CssClass="blue"></ControlStyle>
               </asp:HyperLinkField>
                   <asp:TemplateField HeaderText="预约人">
                    <ItemTemplate>
                        <asp:LinkButton ID="lblUserName" runat="server" CommandName="ShowStudent" CommandArgument='<%#Eval("UserId") %>' CssClass="blue" Text='<%# Eval("UserName") %>'></asp:LinkButton>
                    </ItemTemplate>
               </asp:TemplateField> 
                <asp:TemplateField HeaderText="预约时间">
                   <ItemTemplate>
                       <asp:Label ID="lblReservationTime" runat="server" Text='<%# Eval("BeginReservationTime").ToString() + "至" + Eval("EndReservationTime") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Height="30px"/>
                   <ItemStyle Height="30px" />
               </asp:TemplateField>            
                <asp:TemplateField HeaderText="预约总价">
                    <ItemTemplate>
                        <asp:Label ID="lb_totle" runat="server" Text='<%# Eval("Totle").ToString() + "元" %>'> </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>   
                <asp:BoundField HeaderText="预约状态" DataField="StateName">
               
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
    
   </table>

</asp:Content>

