<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipManagerPhotoList.aspx.cs" Inherits="Admin_nEquipManagerPhotoList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.blue
{
	color:Blue;
	font-size:11pt
}   
</style>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign="bottom" align="left" style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width="150px">
       <tr>
       <td width=150px align="right"> <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/SheBeiListBtn.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td>
    <asp:DataList ID="dl_equipList" runat="server" RepeatColumns="2" Width="100%">
        <ItemTemplate>           
               <table cellpadding="0" cellspacing="0" 
    style="width: 100%" border="1">
                   <tr>
                       <td rowspan="4" style="width:140px">
                           <asp:ImageButton ID="imgBtnPhoto" runat="server" 
                               ImageUrl='<%#Eval("EquipmentPhotoPath") %>'
                               CommandArgument='<%#Eval("EquipmentId") %>' CommandName="ShowEquipment" 
                               Height="150px" Width="200px"/></td>
                       <td height="30px" class="blue" align="right">
                          仪器名称:</td>
                     
                       <td align="left" >
                       <a href="nShowEquipInfo.aspx?e_id=<%#Eval("EquipmentId") %>">
                        <asp:Label ID="LBtnEquipmentName" runat="server" Text='<%#Eval("EquipmentName") %>'></asp:Label>
                       </a>
                          
                       </td>
                   </tr>
                   <tr>
                       <td height="30px" style="width:100px" class="blue" align=right>
                           仪器型号:</td>
                       
                       <td align=left>
                           <asp:Label ID="lblEquipmentModel" runat="server" Text='<%#Eval("EquipmentModel") %>'></asp:Label> 
                       </td>
                   </tr>
                   <tr>
                       <td height="30px" class="blue" align=right>
                          设备类型:</td>
                       
                       <td align="left">
                          <asp:Label ID="lblEquipmentType" runat="server" Text='<%#Eval("EquipmentTypeName") %>'></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td height="30px" class="blue" align="right">
                          设备价格:</td>
                        
                       <td align="left">
                          <asp:Label ID="lblEquipmentPrice" runat="server" Text='<%#Eval("EquipmentPrice") %>'></asp:Label>
                       </td>
                   </tr>
               </table>
        </ItemTemplate>
    </asp:DataList>
    </td>
    </tr>
    <tr>
        <td align="right" style="font-size:10pt;">
            当前页码:
                [<asp:Label ID="lb_page" runat="server" Text="1"></asp:Label>]/共[
                <asp:Label ID="lb_totalPage" runat="server"></asp:Label>]页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_first" runat="server" onclick="lb_first_Click">首页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_up" runat="server" onclick="lb_up_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_down" runat="server" onclick="lb_down_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lb_last" runat="server" onclick="lb_last_Click">尾页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td align="center">
            <input type="button" value="返回上一页" onclick="window.history.go(-1);" />
        </td>
    </tr>
    </table>
</asp:Content>

