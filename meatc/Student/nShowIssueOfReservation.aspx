<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="nShowIssueOfReservation.aspx.cs" Inherits="Student_nShowIssueOfReservation" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0 height="500px">
   <tr>
   <td height="45px" valign="top" align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right> <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/TitleBtnYuYueInfo.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td valign=top>
       <table width=100% cellpadding=0 cellspacing=0 border=0>
       <tr>
       <td align=right width="20%" height=30px class="blue">申请人：</td>
        <td width="20px"></td>
       <td align=left width="30%">
           <asp:Label ID="lblName" runat="server"></asp:Label>
       </td>
       <td align=right class="blue" width="20%">申请人电话：</td>
        <td width="10px"></td>
       <td width="30%" align=left>
           <asp:Label ID="lblPhone" runat="server"></asp:Label>
       </td>
       </tr>
       <tr>
       <td align=right height=30px class="blue">课题名称：</td>
        <td></td>
       <td align=left>
           <asp:Label ID="lblIssueName" runat="server"></asp:Label>
       </td>
       <td align=right class="blue">申请人邮箱：</td>
        <td></td>
       <td align=left>
           <asp:Label ID="lblEmail" runat="server"></asp:Label>
       </td>
       </tr>
       <tr runat=server id="TRTeacherInfo1">
       <td align=right height=30px class="blue">导师姓名：</td>
        <td></td>
       <td align=left>
           <asp:Label ID="lblTeacherName" runat="server"></asp:Label>
       </td>
       <td align=right class="blue">导师电话：</td>
        <td></td>
       <td align=left>
           <asp:Label ID="lblTeacherPhone" runat="server"></asp:Label>
       </td>
       </tr>
       <tr runat=server id="TRTeacherInfo2">
       <td align=right height=30px class="blue">导师邮箱：</td>
        <td></td>
       <td align=left>
            <asp:Label ID="lblTeacherEmail" runat="server"></asp:Label>
       </td>
       <td align=right class="blue">经费卡号：</td>
        <td></td>
       <td align=left>
            <asp:Label ID="lblFinancialCard" runat="server"></asp:Label>
       </td>
       </tr>
       <tr>
       <td align=right height=30px class="blue">课题内容：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:Label ID="lblIssueContent" runat="server" Width="90%"></asp:Label>
       </td>
       </tr>
        <tr>
       <td align=right height=30px class="blue">仪器及型号：</td>
       <td></td>
       <td colspan=4 align=left>        
           <asp:LinkButton ID="lBtnEquipment" runat="server" Font-Underline="True" onclick="lBtnEquipment_Click"
               ></asp:LinkButton>
       </td>
       </tr>
        <tr>
       <td align=right height=30px class="blue">实验目的：</td>
       <td></td>
       <td colspan=4 align=left>
            <asp:Label ID="lblTestPurpose" runat="server" Width="90%"></asp:Label>

       </td>
       </tr>
        <tr>
       <td align=right height=30px class="blue">检查指标：</td>
       <td></td>
       <td colspan=4 align=left>
          <asp:Label ID="lblCheckIndicators" runat="server" Width="90%"></asp:Label>
       </td>
       </tr>
        <tr>
       <td align=right height=30px class="blue">样品性质：</td>
       <td></td>
       <td colspan=4 align=left>
         <asp:Label ID="lblSampleProperties" runat="server" Width="90%"></asp:Label>
       </td>
       </tr>       
        <tr>
       <td align=right height=30px class="blue">预约时间：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:Label ID="lblReservationTime" runat="server"></asp:Label>
       </td>
       </tr>
       
       
       </table>
       </td>
   </tr>
    <tr>
        <td align="center" valign="top"><asp:ImageButton ID="imgBtnBack" runat="server" 
                ImageUrl="~/Images/FanHuiBtn.png" onclick="imgBtnBack_Click" /> </td>
    </tr>
   </table>
</asp:Content>

