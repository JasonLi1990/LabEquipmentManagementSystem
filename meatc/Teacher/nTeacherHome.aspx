<%@ Page Language="C#" MasterPageFile="~/Teacher/T_MasterPage.master" AutoEventWireup="true" CodeFile="nTeacherHome.aspx.cs" Inherits="Teacher_nTeacherHome" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="panelApprovalInfo" runat="server" CssClass="d5" Visible=false style=" position:absolute;width:320px; height:120px; z-index:100; top: 250px; left: 384px; background-color:White">
<table width=100% height=120px cellpadding=0 cellspacing=0 border=0>
<tr>
<td align=left height=25px>
    <asp:Label ID="lblShenPi" style="margin-left:10px; font-weight: 700;" 
        class="blue" runat="server" Text="审批信息"></asp:Label>
</td>
</tr>
<tr>
<td  height="50px" class="blue">
    <asp:TextBox ID="txtApprovalInfo" runat="server" Height="42px" 
        TextMode="MultiLine" Width="300px"></asp:TextBox>
</td>
</tr>

<tr>
<td  height="37px">
    <asp:ImageButton ID="imgBtnApprovalInfoOK" runat="server" ImageUrl="~/Images/QueRenBtn.png" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/Images/CloseBtn.png" />
    </td>
</tr>
</table>
</asp:Panel>
<div style="height:5px"></div>
 <table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign="bottom" align="left" style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/ApprovalRegistration.png"/>
       </td>       
       <td align="right" valign="baseline">
            <table cellpadding="0" cellspacing="0" style="width: 100%">
               <tr>
                   <td class="blue" align="right">
                       选择学生&nbsp;&nbsp;                   
                       <asp:DropDownList ID="ddlSchool" runat="server" Width=100px CssClass="SelectCss" DataTextField="UserName" DataValueField="UserId">                      
                       </asp:DropDownList>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       审批状态&nbsp;&nbsp;
                       <asp:DropDownList ID="ddlShenPiState" runat="server" Width="120px" CssClass="SelectCss">
                           <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                           <asp:ListItem Value="10">通过审批</asp:ListItem>
                           <asp:ListItem Value="12">待导师审批</asp:ListItem>
                           <asp:ListItem Value="13">待设备管理员审批</asp:ListItem>
                           <asp:ListItem Value="14">未通过审批</asp:ListItem>
                           <asp:ListItem Value="11">完成预约</asp:ListItem>
                       </asp:DropDownList>
                       &nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:ImageButton ID="ImgBtnSelect" runat="server" 
                           ImageUrl="~/Images/SouSuoBtn.png" onclick="ImgBtnSelect_Click" />
                       &nbsp;&nbsp;&nbsp;&nbsp;
                   </td>
               </tr>
           </table>
       </td>
       </tr>
       </table>      
       </td>       
   </tr>   
   <tr>
   <td align="center" style="height:500px" valign="top">
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center"
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" RowStyle-HorizontalAlign="Center" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
           onrowcommand="GVTeacher_RowCommand" 
           onrowdatabound="GVTeacher_RowDataBound" AllowPaging="True" PageSize="10">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <HeaderStyle Height="30px" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Height="25px" />
           <Columns>
                <asp:HyperLinkField HeaderText="课题名称" ControlStyle-ForeColor="Blue"
                    DataTextField="IssueName" DataNavigateUrlFields="ReservationInfoId" 
                    DataNavigateUrlFormatString="~/Student/nShowIssueOfReservation.aspx?r_id={0}" >

<ControlStyle CssClass="blue"></ControlStyle>
                </asp:HyperLinkField>

               <asp:BoundField HeaderText="学生" DataField="UserName" >
              
               </asp:BoundField>                       
               <asp:BoundField HeaderText="预约开始时间" DataField="BeginReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
              
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约结束时间" DataField="EndReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
              
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约价格" DataField="Total">
              
               </asp:BoundField>  
                <asp:BoundField HeaderText="预约状态" DataField="StateName">
               
               </asp:BoundField>    
               <asp:TemplateField HeaderText="审批">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnOK" OnClientClick="return confirm('确认通过导师审批？')"  CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="ReservationOK" runat="server" ImageUrl="~/Images/BtnTongGuo.png" />
                       <asp:ImageButton ID="imgBtnNO" OnClientClick="return confirm('确认不通过导师审批？请填写未通过原因。')"  CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="ReservationNO" runat="server" ImageUrl="~/Images/TongGuoNOBtn.png"/>
                       <asp:HiddenField ID="HFStateId" Value='<%#Eval("StateId") %>' runat="server" />
                   </ItemTemplate>
                   <HeaderStyle Width="15%" />
               </asp:TemplateField>              
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       <hr />
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
</asp:Content>

