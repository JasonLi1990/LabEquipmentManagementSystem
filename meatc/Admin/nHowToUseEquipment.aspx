<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nHowToUseEquipment.aspx.cs" Inherits="Admin_nHowToUseEquipment" Title="无标题页" %>

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
       <td width=5px>
       </td>
       <td width=120px align=left style="margin-bottom:10px">
           <asp:ImageButton ID="imgBtnSchool" runat="server" 
               ImageUrl="~/Images/PopleBtn01.png" />       
       </td>
       <td  width=120px align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnOut" runat="server" 
                   ImageUrl="~/Images/PopleBtn02.png" /> 
       </td>
       <td width=120px align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnInner" runat="server" 
                   ImageUrl="~/Images/PopleBtn03.jpg"/> 
       </td>
        <td align=left style="margin-bottom:10px">
               <asp:ImageButton ID="imgBtnTeacher" runat="server" 
                   ImageUrl="~/Images/PopleBtn04.jpg"/> 
       </td>
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
                       <asp:ListItem Value="13">待管理员审批</asp:ListItem>
                       <asp:ListItem Value="14">未通过导师审批</asp:ListItem>
                       <asp:ListItem Value="15">未通过审批</asp:ListItem>                       
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
    <td align="center">
        <asp:Panel ID="panel_howtoUse" runat="server" Width="100%" Height="500px" ScrollBars="Auto">
        <asp:GridView ID="GVReservationInfo" runat="server" AutoGenerateColumns="False" 
           Width="99%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical"
           
           onrowdatabound="GVReservationInfo_RowDataBound">
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
                       至
                       <asp:Label ID="HFEndTime" runat="server" Text='<%#Eval("EndReservationTime") %>' />
                   </ItemTemplate>                   
                   <ItemStyle Height="30px" />
               </asp:TemplateField>
               <asp:BoundField HeaderText="样品数量" DataField="EquipmentNum"   SortExpression="d.EquipmentNum">
                   </asp:BoundField>
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
       </asp:Panel>
       
    </td>
   </tr>
   <tr>
    <td align="right" style="padding-right:100px;">
        设备预约时间总长：<asp:Label ID="lb_timeTotel" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        测试样品总和：<asp:Label ID="lb_yangpintotel" runat="Server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        总共：<asp:Label ID="lb_totle" runat="server"></asp:Label>元
    </td>
   </tr>
</table>
</asp:Content>

