<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nAdminHome.aspx.cs" Inherits="Admin_nAdminHome" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=100%>
       <tr>
       <td width=150px align=right> <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/TitleBtnYuYueInfo.png" />
       </td>
       <td width=5px>
       </td>
       <td width=120px align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnInner" runat="server" 
                   ImageUrl="~/Images/PopleBtn03.jpg" onclick="imgBtnInner_Click"/> 
       </td>
       <td width=120px align=left style="margin-bottom:10px">
           <asp:ImageButton ID="imgBtnSchool" runat="server" 
               ImageUrl="~/Images/PopleBtn01.png" onclick="imgBtnSchool_Click"/>       
       </td>
       <td  width=120px align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnOut" runat="server" 
                   ImageUrl="~/Images/PopleBtn02.png" onclick="imgBtnOut_Click"/> 
       </td>
       
        <td align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnTeacher" runat="server" 
                   ImageUrl="~/Images/PopleBtn04.jpg" onclick="imgBtnTeacher_Click"/> 
       </td>
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="center">
       <asp:GridView ID="GVReservationInfo" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" AllowPaging="True" 
           onpageindexchanging="GVReservationInfo_PageIndexChanging" 
           onrowdatabound="GVReservationInfo_RowDataBound" PageSize="15">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" />
           <HeaderStyle Font-Size="11pt" />
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                        <asp:Image ID="imgSchool" runat="server" />   
                        <asp:HiddenField ID="HFUserType" runat="server" Value='<%# Eval("UserType") %>' />                    
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:HyperLinkField HeaderText="设备名称" DataTextField="EquipmentName" ControlStyle-CssClass="blue" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" />
               <asp:HyperLinkField HeaderText="预约用户" DataTextField="UserName" ControlStyle-CssClass="blue" DataNavigateUrlFields="UserId" DataNavigateUrlFormatString="nEditStudent.aspx?u_id={0}" />
               
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
       </td>
   </tr>  
   
   </table>

</asp:Content>

