<%@ Page Language="C#" MasterPageFile="~/Teacher/T_MasterPage.master" AutoEventWireup="true" CodeFile="nReservationStatistic.aspx.cs" Inherits="Teacher_nReservationStatistic" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/StatisticsReservationImg.png"/>
           
           
       </td>  
       <td valign=bottom>
            &nbsp;</td>
       <td valign=bottom>&nbsp;</td> 
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td height=30px width="100%">
   <table cellpadding=0 cellspacing=0 border=0 width=100%>   
      <tr>
        <td align=right width=150px class="blue" height=30px>选择时间段：</td>
        <td width=10px></td>
        <td align=left width=480px nowrap>
            <asp:TextBox ID="txtBeginTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
            ---
            <asp:TextBox ID="txtEndTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
        </td>
        <td align=right width=100px class="blue">审批状态：</td>
        <td width=10px></td>
        <td align=left width=120px>
           <asp:DropDownList ID="ddlShenPiState" runat="server" Width=120px CssClass="SelectCss">
                       <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                       <asp:ListItem Value="10">通过审批</asp:ListItem>
                       <asp:ListItem Value="12">待导师审批</asp:ListItem>
                       <asp:ListItem Value="13">待设备管理员审批</asp:ListItem>
                       <asp:ListItem Value="14">未通过导师审批</asp:ListItem>
                       <asp:ListItem Value="15">未通过最后审批</asp:ListItem>                      
                      
                   </asp:DropDownList>
        </td>
        <td align=left>
            <asp:ImageButton ID="imgBtnSelect" runat="server" style="margin-left:10px" 
                ImageUrl="~/Images/SouSuoBtn.png" onclick="imgBtnSelect_Click" /></td>
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
   <td valign=top align="center">
      <asp:Panel ID="Panel1" runat="server" Width=100% Height=500px ScrollBars="Auto">
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" Visible="false" 
           Width="98%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
              BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataKeyNames="UserId" 
              onrowdatabound="GVTeacher_RowDataBound">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
           <Columns>
               <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cb_select" runat="server" />
                    <asp:HiddenField ID="hf_ReservationInfoId" runat="server" Value='<%# Eval("ReservationInfoId") %>' />
                </ItemTemplate>
               </asp:TemplateField>
               <asp:HyperLinkField HeaderText="课题名称" ControlStyle-CssClass="blue" DataTextField="IssueName" Target="_blank" DataNavigateUrlFields="ReservationInfoId" DataNavigateUrlFormatString="~/Student/nShowIssueOfReservation.aspx?r_id={0}" />
               <asp:TemplateField HeaderText="学生姓名">
                <ItemTemplate>
                    <asp:LinkButton ID="lb_userName" runat="server" CommandName="ShowStuInfo" Text='<%# Eval("UserName") %>'></asp:LinkButton>
                </ItemTemplate>
               </asp:TemplateField>               
               <asp:BoundField HeaderText="实验时间" DataField="BeginReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Height="30px" />
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
       
       
       
       <asp:GridView ID="GVReservationInfo" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" 
           onpageindexchanging="GVReservationInfo_PageIndexChanging" 
           onrowdatabound="GVReservationInfo_RowDataBound" PageSize="15">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" />
           <HeaderStyle Font-Size="11pt" />
           <Columns>     
            <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cb_select" runat="server" />
                    <asp:HiddenField ID="hf_ReservationInfoId" runat="server" Value='<%# Eval("ReservationInfoId") %>' />
                </ItemTemplate>
               </asp:TemplateField>          
               <asp:BoundField HeaderText="设备名称" DataField="EquipmentName" ControlStyle-CssClass="blue" />
               
               <asp:BoundField HeaderText="预约用户" DataField="UserName" />
                <asp:TemplateField HeaderText="设备类型" SortExpression="f.EquipmentTypeName">
                   <ItemTemplate>
                       <asp:Label ID="lblEquipmentTypeName" runat="server" Text='<%#Eval("EquipmentTypeName") %>' Font-Size="10pt"></asp:Label>                       
                   </ItemTemplate>
                   
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="预约时间" SortExpression="d.BeginReservationTime">
                   <ItemTemplate>
                       <asp:Label ID="lblReservationTime" runat="server" Text='<%#Eval("BeginReservationTime") %>' Font-Size="10pt"></asp:Label>
                       <asp:HiddenField ID="HFEndTime" runat="server" Value='<%#Eval("EndReservationTime") %>' />
                   </ItemTemplate>
                   
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="预约数量"   SortExpression="d.EquipmentNum">
                   <ItemTemplate>
                       <asp:Label ID="lblReservationNum" runat="server" Text='<%#Eval("EquipmentNum").ToString()+Eval("EquipmentUnitName").ToString() %>' Font-Size="10pt"></asp:Label>                       
                   </ItemTemplate>
                   <HeaderStyle Width="10%" Height="30px"/>
                   <ItemStyle Height="30px" />
               </asp:TemplateField>  
               <asp:BoundField HeaderText="预约总价" DataField="Totle"   SortExpression="d.Totle">
               <HeaderStyle Width="10%" />
               </asp:BoundField>  
                <asp:BoundField HeaderText="预约状态" DataField="StateName"   SortExpression="b.StateName">
               <HeaderStyle Width="10%" />
               </asp:BoundField> 
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       
       <hr />
       <asp:CheckBox ID="cb_selectAll" runat="Server" Text="全选" AutoPostBack="true" 
              oncheckedchanged="cb_selectAll_CheckedChanged" />
       </asp:Panel>
       </td>
   </tr>
   <tr>
   <td  align="right" valign="middle" class="txtcolor" height="30px">
      总计：<asp:Label ID="lblTotle" runat="server"></asp:Label>元
      <asp:Button ID="bt_report" runat="server" Text="将选择结果生成报表" 
           onclick="bt_report_Click" />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
       </td>
   </tr>    
   </table>
</asp:Content>

