<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipManagerInfo.aspx.cs" Inherits="Admin_nEquipManagerInfo" Title="无标题页" %>

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
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align=right> 
          <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentManagerInfoImg.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align=center>
       
              <table width=90% cellpadding="0" cellspacing="0">
           <tr>
               <td width=150px align=right height=30px class="blue">
                   登录名</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblLoginName" runat="server"></asp:Label>
               </td>
           </tr>          
           <tr>
               <td align=right height=30px class="blue">
                   姓名</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                   性别</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblSex" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  出生日期</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblBirthDate" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  固定电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                   手机</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblMobileTelephone" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height=30px class="blue">
                  邮箱</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
               </td>
           </tr>               
            <tr>
               <td align=right height=30px class="blue">
                   所管设备</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:ImageButton ID="ImgBtnEquipment" runat="server" 
                            ImageUrl="~/Images/GuanXiaDeSheBeiBtn.png" onclick="ImgBtnEquipment_Click"  />
               </td>
           </tr>       
       </table>
       
       </td>
   </tr>
   <tr>
   <td align=center height=30px>
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" onclick="imgBtnBack_Click"  />
       
       </td>
   </tr>
   </table>
</asp:Content>

