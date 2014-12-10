<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Student_Default" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/YuYueInfoList.png"/>
           
           
       </td>  
       <td valign="middle">&nbsp;</td>
       <td valign="middle" align="right"><asp:DropDownList ID="ddlShenPiState" runat="server" Width=150px CssClass="SelectCss">
                           <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                           <asp:ListItem Value="10">通过审批</asp:ListItem>
                           <asp:ListItem Value="12">待导师审批</asp:ListItem>
                           <asp:ListItem Value="13">待设备管理员审批</asp:ListItem>
                           <asp:ListItem Value="14">未通过导师审批</asp:ListItem>
                           <asp:ListItem Value="15">未通过最后审批</asp:ListItem>                           
                       </asp:DropDownList><asp:ImageButton ID="imgBtnSelect" 
               runat="server" style="margin-left:10px" ImageUrl="~/Images/SouSuoBtn.png" 
               onclick="imgBtnSelect_Click" />
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
   <td height="10px">
       <hr width="100%" />
       </td>
   </tr>
   <tr>
   <td valign="top" align="left">
      <asp:Panel ID="Panel1" runat="server" Width="100%" Height="480px" ScrollBars="Horizontal">
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" 
           Width="100%" CellPadding="3" GridLines="Vertical" 
              onrowdatabound="GVTeacher_RowDataBound" BackColor="White" 
              BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
              onrowcommand="GVTeacher_RowCommand" AllowPaging="True" PageSize="15">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
           <Columns>
                      
               <asp:HyperLinkField HeaderText="课题名称" ControlStyle-ForeColor="Blue" DataNavigateUrlFields="ReservationInfoId" DataNavigateUrlFormatString="nShowIssueOfReservation.aspx?r_id={0}" DataTextField="IssueName" />
               <asp:BoundField HeaderText="预约总价" DataField="Total">
               
               </asp:BoundField>
                <asp:BoundField HeaderText="审批状态" DataField="StateName">
               
               </asp:BoundField>  
               
               <asp:HyperLinkField DataNavigateUrlFields="ReservationInfoId"  ControlStyle-ForeColor="Blue" DataNavigateUrlFormatString="nShowEquipOfReservation.aspx?r_id={0}"
                 HeaderText="预约设备" 
                   Text="点击查看" >
               
                   <ControlStyle CssClass="blue" />
               </asp:HyperLinkField>
               
               <asp:HyperLinkField HeaderText="查看消息" Text="点击查看"  ControlStyle-ForeColor="Blue"
                   DataNavigateUrlFields="ReservationInfoId" 
                   DataNavigateUrlFormatString="nShowMsgOfReservation.aspx?r_id={0}" >
               
                   <ControlStyle CssClass="blue" />
               </asp:HyperLinkField>
               
               <asp:TemplateField HeaderText="取消预约">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnDelIssue" ForeColor="Red" OnClientClick="return confirm('确认取消该预约吗？')" CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="DelIssue" Text='取消预约' runat="server" Font-Size="10pt" Font-Underline="False"></asp:LinkButton>
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
        <td>
            
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

