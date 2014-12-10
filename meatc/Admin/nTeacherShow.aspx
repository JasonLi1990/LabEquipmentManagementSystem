<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nTeacherShow.aspx.cs" Inherits="Admin_nTeacherShow" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.f1
{
	font-size:11pt;
}
</style>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table style="width: 200px">
       <tr>
       <td  align=right> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/TeacherInfoImg.png"/>
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="center" class="f1">
       
              <table width="90%" cellpadding="0" cellspacing="0" border="1">
           <tr>               
               <td align=left class="blue" height="30px" width="100px">
                   姓名：</td>               
                    <td align=left>
                        <asp:Label ID="lblName" runat="server"></asp:Label>
               </td>
           
               <td align=left class="blue" height=30px width="100px">
                   性别：</td>
               
                    <td align=left>
                        <asp:Label ID="lblSex" runat="server"></asp:Label>
               </td>
           </tr>
           <tr>
               <td align=left class="blue" height=30px>
                  出生日期：</td>
               
                    <td align=left>
                        <asp:Label ID="lblBirthDate" runat="server"></asp:Label>&nbsp;
               </td>
          
               <td align=left class="blue" height=30px>
                  固定电话：</td>
               
                    <td align=left>
                        <asp:Label ID="lblPhone" runat="server"></asp:Label>&nbsp;
               </td>
           </tr>
           <tr>
               <td align=left class="blue" height=30px>
                   手机：</td>
               
                    <td align=left>
                        <asp:Label ID="lblMobileTelephone" runat="server"></asp:Label>&nbsp;
               </td>
           
               <td align="left" class="blue" height=30px>
                  邮箱：</td>
                    <td align=left>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>&nbsp;
               </td>
           </tr>          
            <tr>
               <td align="left" valign="top" class="blue" height=30px>
                   <strong>指导学生：</strong></td>
               
           
               <td align="center" colspan="3">
                  &nbsp;
                   <asp:GridView ID="GVSchoolList" runat="server" AutoGenerateColumns="False" 
                       Width="100%" AllowPaging="True" BackColor="White" BorderColor="#999999" 
                       BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
                       onpageindexchanging="GVSchoolList_PageIndexChanging"  PageSize="12"
                       onrowdatabound="GVSchoolList_RowDataBound">
                       <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                       <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
           <Columns>    
           <asp:BoundField HeaderText="学号" DataField="LoginName">
               <HeaderStyle Width="10%" CssClass="blue" Height="30px" />
               <ItemStyle Height="30px" />
               </asp:BoundField>                
               <asp:BoundField HeaderText="学生姓名" DataField="UserName">
               <HeaderStyle Width="10%" CssClass="blue" Height="30px" />
               <ItemStyle Height="30px" />
               </asp:BoundField>
               <asp:BoundField HeaderText="性别" DataField="UserSex">
               <HeaderStyle Width="5%" CssClass="blue" Height="30px" />
               </asp:BoundField>
               <asp:BoundField HeaderText="年龄" DataField="BirthDate" DataFormatString="{0:yyyy-MM-dd}">
               <HeaderStyle Width="5%" CssClass="blue" Height="30px" />
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
       
       </td>
   </tr>
   <tr>
   <td align="center">
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" onclick="imgBtnBack_Click" />
       
       </td>
   </tr>
   </table>
</asp:Content>

