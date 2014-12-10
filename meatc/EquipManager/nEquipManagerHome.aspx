<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipManagerHome.aspx.cs" Inherits="EquipManager_nEquipManagerHome" Title="无标题页" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Panel ID="panelApprovalInfo" runat="server" Visible=false CssClass="d5" style=" position:absolute;width:320px; height:120px; z-index:100; top: 200px; left: 384px; background-color:White; border:solid">
<table width=100% height=120px cellpadding=0 cellspacing=0 border=0>
<tr>
<td align="center" height=25px>
    <asp:Label ID="lblShenPi" style="margin-left:10px; font-weight: 700;" 
        class="blue" runat="server" Text="审批信息"></asp:Label>
</td>
</tr>
<tr>
<td  height="50px" class="blue" align="center">
    <asp:TextBox ID="txtApprovalInfo" runat="server" Height="42px" 
        TextMode="MultiLine" Width="300px"></asp:TextBox>
        <asp:HiddenField ID="hf_ReservationId" runat="server" />
       
</td>
</tr>

<tr>
<td  height="37px" align="center">
    <asp:ImageButton ID="imgBtnApprovalInfoOK" runat="server" 
        ImageUrl="~/Images/QueRenBtn.png" onclick="imgBtnApprovalInfoOK_Click"  />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:ImageButton ID="imgBtnClose" runat="server" 
        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnClose_Click" />
    </td>
</tr>
</table>
</asp:Panel>

 <table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;">
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/ApprovalRegistration.png"/>
           
           
       </td><td valign="middle"><asp:ImageButton ID="imgBtnInner" runat="server" 
               ImageUrl="~/Images/PopleBtn03.jpg" onclick="imgBtnInner_Click"/> </td>   
       <td valign="middle">
        <asp:ImageButton ID="imgBtnSchool" runat="server" 
               ImageUrl="~/Images/PopleBtn01.png" onclick="imgBtnSchool_Click" />
           
               </td>
       <td valign="middle"><asp:ImageButton ID="imgBtnOutSide" runat="server" 
               ImageUrl="~/Images/PopleBtn02.png" onclick="imgBtnOutSide_Click"/> </td> 
       
       <td  valign="middle" style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnTeacher" runat="server" 
                   ImageUrl="~/Images/PopleBtn04.jpg" onclick="imgBtnTeacher_Click"/> 
       </td>
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="left">
       <asp:GridView ID="GVTeacher" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" 
           onpageindexchanging="GVTeacher_PageIndexChanging" HeaderStyle-HorizontalAlign="Center" RowStyle-HorizontalAlign="Center" 
           onrowcommand="GVTeacher_RowCommand" onrowdatabound="GVTeacher_RowDataBound" 
           PageSize="10">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" />
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <asp:Image ID="imgSchool" runat="server" />
                       <asp:HiddenField ID="HFUserType" runat="server" Value='<%#Eval("UserType") %>' />
                   </ItemTemplate>
                   
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="课题名称">
                   <ItemTemplate>
                       <asp:LinkButton ID="LBtnIssueName" CssClass="blue" CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="ShowIssueName" Text='<%#Eval("IssueName") %>' runat="server" Font-Size="10pt" Font-Underline="False"></asp:LinkButton>
                   </ItemTemplate>
                   
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:BoundField HeaderText="学生" DataField="UserName" >
              
               </asp:BoundField>                       
               <asp:BoundField HeaderText="预约开始时间" DataField="BeginReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
               
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约结束时间" DataField="EndReservationInfoTime" DataFormatString="{0:yyyy-MM-dd}">
              
               </asp:BoundField>  
               <asp:BoundField HeaderText="预约总价" DataField="Total" />
               <asp:BoundField HeaderText="审批状态" DataField="StateName" />
               <asp:TemplateField HeaderText="审批">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnOK" OnClientClick="return confirm('确定通过最终审批？')"  CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="ReservationOK" runat="server" ImageUrl="~/Images/BtnTongGuo.png" />
                       <asp:ImageButton ID="imgBtnNO" OnClientClick="return confirm('确定不通过审批？请填写未通过审批原因。')"  CommandArgument='<%#Eval("ReservationInfoId") %>' CommandName="ReservationNO" runat="server" ImageUrl="~/Images/TongGuoNOBtn.png"/>
                       <asp:HiddenField ID="HFStateId" Value='<%#Eval("StateId") %>' runat="server" />
                   </ItemTemplate>
                  
               </asp:TemplateField>              
               <asp:HyperLinkField DataNavigateUrlFields="ReservationInfoId" ControlStyle-CssClass="blue" 
                   DataNavigateUrlFormatString="nOnlineMessage.aspx?r_id={0}" Text="点击进入" 
                   HeaderText="在线对话" />
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       </td>
   </tr>
   <tr>
    <td align="right">
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

