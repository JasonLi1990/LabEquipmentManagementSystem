<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="nApplyReservationDetail.aspx.cs" Inherits="Student_nApplyReservationDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width=100% cellpadding=0 cellspacing=0 border=0>
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
   <td valign="top" width="100%">
       <table width=100% cellpadding=0 cellspacing=0 border=0>
       <tr>
       <td align=right width="20%" height=35px class="blue">申请人：</td>
        <td width="10px"></td>
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
       <td align=right height=35px class="blue">课题名称：</td>
        <td></td>
       <td align=left>
           <asp:TextBox ID="txtIssueName" runat="server" Width="150px"></asp:TextBox>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入课题名称" ControlToValidate="txtIssueName" ForeColor="Red">请输入课题名称</asp:RequiredFieldValidator>
       </td>
       <td align=right class="blue">申请人邮箱：</td>
        <td></td>
       <td align=left>
           <asp:Label ID="lblEmail" runat="server"></asp:Label>
       </td>
       </tr>
       <tr runat=server id="TRTeacherInfo1">
       <td align=right height=35px class="blue">导师姓名：</td>
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
       <td align=right height=35px class="blue">导师邮箱：</td>
        <td></td>
       <td align=left>
            <asp:Label ID="lblTeacherEmail" runat="server"></asp:Label>
       </td>
       <td align=right class="blue">经费卡号：</td>
        <td></td>
       <td align=left>
            <asp:TextBox ID="txtFinancialCard" runat="server" Width="150px"></asp:TextBox>
       </td>
       </tr>
       <tr>
       <td align=right height=35px class="blue">课题内容：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:TextBox ID="txtIssueContent" runat="server" Width="90%"></asp:TextBox>
       </td>
       </tr>
        <tr>
       <td align=right height=35px class="blue">仪器及型号：</td>
       <td></td>
       <td colspan=4 align="left" class="blue">
            <asp:Label ID="lblEquipment" runat="server"></asp:Label>
       </td>
       </tr>
        <tr>
       <td align=right height=35px class="blue">实验目的：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:TextBox ID="txtTestPurpose" runat="server" Width="90%"></asp:TextBox>
       </td>
       </tr>
        <tr>
       <td align=right height=35px class="blue">检查指标(必填)：</td>
       <td></td>
       <td colspan=4 align=left>
          <asp:TextBox ID="txtCheckIndicators" runat="server" Width="90%" ></asp:TextBox>
          <asp:RequiredFieldValidator ControlToValidate="txtCheckIndicators" ID="rf_Indicators" runat="server" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       </td>
       </tr>
        <tr>
       <td align=right class="blue">样品性质(必填)：</td>
       <td></td>
       <td colspan=4 align=left>
          <asp:TextBox ID="txtSampleProperties" runat="server" Width="90%" ></asp:TextBox>
          <asp:RequiredFieldValidator ControlToValidate="txtSampleProperties" ID="rf_properties" runat="server" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
       </td>
       </tr>       
        <tr>
       <td align=right height=35px class="blue">预约时间：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:Label ID="lblReservationTime" runat="server"></asp:Label>
       </td>
       </tr>
       <tr runat=server id="TRExperimentalResults">
       <td align=right height=45px class="blue">试验结果：</td>
       <td></td>
       <td colspan=4 align=left>
           <asp:TextBox ID="txtExperimentalResults" runat="server" Width="90%" 
               Height="45px" TextMode="MultiLine"></asp:TextBox>
       </td>
       </tr>
       </table>
       </td>
   </tr>
 
     <tr>
   <td align="center">
       <asp:ImageButton ID="ImgBtnOK" runat="server" 
           ImageUrl="~/Images/ShenQingYuYueBtn.png" onclick="ImgBtnOK_Click" />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="ImgBtnBack" runat="server" ImageUrl="~/Images/FanHuiBtn.png" 
            CausesValidation="False" onclick="ImgBtnBack_Click"/>
     </td>
   </tr>
   </table>
</asp:Content>

