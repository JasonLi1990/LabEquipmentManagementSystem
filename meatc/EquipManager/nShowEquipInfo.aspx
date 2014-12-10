<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nShowEquipInfo.aspx.cs" Inherits="EquipManager_nShowEquipInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.f1
{
	font-size:11pt;
}
.blue
{
	color:Blue
}
</style>
  <table width="100%" cellpadding=0 cellspacing=0 border=0 align="center">
   <tr>
   <td height="45px" valign=bottom align="left" style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;">
       <table style="width: 200px">
       <tr>
       <td  align=right> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentInfoImg.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align=center>
       
       <table width=90% cellpadding="0" cellspacing="0" class="f1">
           <tr>
               <td align=center colspan="3" rowspan="6">
                        <asp:Image ID="imgEquipmentPhoto" runat="server" Height="190px" 
                       Width="250px" />
               </td>
               <td width=150px align=right height="35px" class="blue">
                   设备名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblEquipmentName" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   设备型号</td>
               <td width="10px">
                   &nbsp;</td>
                    <td align=left>
                       <asp:Label ID="lblEquipmentModel" runat="server"></asp:Label> 
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   设备类型</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblEquipmentType" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   院内价格</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblInternalPrice" runat="server"></asp:Label>元                   
                   
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   校内价格</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblSchoolPrice" runat="server"></asp:Label>元                   
                   
               </td>
           </tr>
           <tr>
               <td width=150px align=right height="35px" class="blue">
                   校外价格</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblExternalPrice" runat="server"></asp:Label>元
               </td>
           </tr>     
           <tr>
                <td align=right height="35px" class="blue">
                   设备管理员</td>
               <td>
                   &nbsp;</td>
                    <td align="left">
                        <asp:Label ID="lblEquipmentManager" runat="server"></asp:Label>
                       
               </td>
               <td width=150px align=right height="35px" class="blue">
                   预处理费</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblYuChuli" runat="server"></asp:Label>元
               </td>
           </tr>       
          
           <tr>
               <td align=right height="35px" class="blue">
                   设备价格(元)</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblEquipmentPrice" runat="server"></asp:Label>
               </td>
                <td align=right class="blue">
                    使用次数</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblFrequencyOfUse" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height="35px" class="blue">
                   生产厂家名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblManufacturerName" runat="server"></asp:Label>
               </td>
                <td align=right class="blue">
                    生产厂家电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblManufacturerPhone" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height="35px" class="blue">
                   生产厂家地址</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:Label ID="lblManufacturerAddress" runat="server"></asp:Label>
               </td>
                
           </tr>
           <tr>
               <td align=right height="35px" class="blue">
                   进货日期</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblPurchaseDate" runat="server"></asp:Label>
               </td>
                <td align=right class="blue">
                    押金</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblDeposit" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=right height="35px" class="blue">
                    质保期限</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblWarrantyPeriod" runat="server"></asp:Label>
               </td>
                <td align=right class="blue">
                    质保电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:Label ID="lblWarrantyPhone" runat="server"></asp:Label>
               </td>
           </tr>           
            <tr>
               <td align=right height="35px" class="blue">
                   设备说明</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:Label ID="lblNodes" runat="server"></asp:Label>
               </td>                
           </tr>           
       </table>
       
       </td>
   </tr>
   <tr>
   <td align=center height=40px valign=middle>
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" onclick="imgBtnBack_Click"/>
       </td>
   </tr>
   </table>
</asp:Content>

