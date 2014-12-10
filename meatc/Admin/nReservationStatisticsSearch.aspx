<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nReservationStatisticsSearch.aspx.cs" Inherits="Admin_nReservationStatisticsSearch" Title="无标题页" %>

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
        <td align=right width=150px class="blue" height=30px>导师：</td>
        <td width=10px></td>
        <td align=left  nowrap>
            <asp:DropDownList ID="ddlTeacher" runat="server" Width=150px 
                CssClass="SelectCss">                      
            </asp:DropDownList>
        </td>
        <td align=right width=100px class="blue">申请人类型：</td>
        <td width=10px></td>
        <td align=left width=120px>
        <asp:DropDownList ID="ddl_type" runat="server">
            <asp:ListItem Value="-1">全部</asp:ListItem>
            <asp:ListItem Value="1">院内学生</asp:ListItem>
            <asp:ListItem Value="5">校内学生</asp:ListItem>
            <asp:ListItem Value="0">校外学生</asp:ListItem>
            <asp:ListItem Value="2">院内教师</asp:ListItem>
        </asp:DropDownList>
            &nbsp;</td>
        <td align=left>           
      </tr>
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
                       <asp:ListItem Value="11">完成预约</asp:ListItem>
                       <asp:ListItem Value="17">超时未完成</asp:ListItem>
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
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" 
           Width="98%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
              BorderWidth="1px" CellPadding="3" GridLines="Vertical" DataKeyNames="UserId" 
              onrowdatabound="GVTeacher_RowDataBound" 
              onrowcommand="GVTeacher_RowCommand">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
           <Columns>
               <asp:TemplateField HeaderText="选择">
                <ItemTemplate>
                    <asp:CheckBox ID="cb_select" runat="server" />
                    <asp:HiddenField ID="hf_ReservationInfoId" runat="server" Value='<%# Eval("ReservationInfoId") %>' />
                </ItemTemplate>
               </asp:TemplateField>
               <asp:HyperLinkField HeaderText="实验设备名称" ControlStyle-CssClass="blue" DataTextField="EquipmentName" DataNavigateUrlFields="ReservationInfoId" DataNavigateUrlFormatString="~/EquipManager/nShowIssue.aspx?r_id={0}" />
               <asp:HyperLinkField HeaderText="申请人" ControlStyle-CssClass="blue" DataNavigateUrlFields="UserId" DataNavigateUrlFormatString="nEditStudent.aspx?u_id={0}" DataTextField="UserName" />
               <asp:BoundField HeaderText="用户类型" DataField="UserType" />
               <asp:HyperLinkField HeaderText="导师姓名" ControlStyle-CssClass="blue" />
               <%--<asp:TemplateField HeaderText="导师姓名">
                    <ItemTemplate>
                        <asp:LinkButton ID="lb_teaName" runat="server" CssClass="blue"></asp:LinkButton>
                        <asp:HiddenField ID="lb_teaId" runat="server" />
                    </ItemTemplate>
               </asp:TemplateField>--%>
               <asp:BoundField HeaderText="实验时间" DataField="BeginReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Height="30px" />
               </asp:BoundField>                 
               <asp:BoundField HeaderText="预约价格" DataField="Total">
               <HeaderStyle Width="10%" />
               </asp:BoundField>
                <asp:BoundField HeaderText="当前状态" DataField="StateName">               
               </asp:BoundField>     
               <asp:TemplateField HeaderText="删除该预约">
                <ItemTemplate>
                    <asp:ImageButton ID="imgBtnDelete" runat="server" OnClientClick="return confirm('确认删除该预约？')" ImageUrl="~/Images/ShanChuYuYueBtn.png" CommandArgument='<%# Eval("ReservationInfoId") %>' CommandName="DeleteReservation" />
                </ItemTemplate>
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
      总计：<asp:Label ID="lblTotle" runat="server"></asp:Label>元
      <asp:Button ID="bt_report" runat="server" Text="将选择结果生成报表" 
           onclick="bt_report_Click" />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      
       </td>
   </tr>    
   </table>
</asp:Content>

