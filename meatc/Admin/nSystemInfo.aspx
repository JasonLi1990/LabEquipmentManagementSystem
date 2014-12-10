<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nSystemInfo.aspx.cs" Inherits="Admin_nSystemInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/YuYueInfoList.png"/>
           
           
       </td>  
       <td valign="bottom">
            &nbsp;</td>
       <td valign="bottom">&nbsp;</td> 
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
   <td align="left">
   <table width=100% cellpadding=0 cellspacing=0 border=0>   
    <tr>
   <td width=150px align=right class="blue" height=80px>公告信息</td>
   <td width=10px></td>
   <td align=left>
        <asp:HiddenField ID="hd_SystemInfoId" runat="server" />
       <asp:TextBox ID="txtSystemBulletin" runat="server" Height="70px" 
           TextMode="MultiLine" Width="90%"></asp:TextBox></td>
   </tr>
   </table>
   </td>
   </tr>
   <tr>
   <td  align="center" valign="middle" class="txtcolor" height="30px">
        <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png" 
            onclick="imgBtnAdd_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;
      <asp:ImageButton ID="imgBtnSaveSystemInfo" runat="server" 
           ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnSaveSystemInfo_Click" />      
       </td>
   </tr>   
   <tr>
    <td align="center">
        <asp:GridView ID="gv_systemInfo" runat="server" Width="98%" 
            AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
            BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
            AllowPaging="True" onpageindexchanging="gv_systemInfo_PageIndexChanging" 
            onrowcommand="gv_systemInfo_RowCommand">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="SystemId" HeaderText="编号">
                    <HeaderStyle Width="40px" />
                </asp:BoundField>
                <asp:BoundField DataField="SystemBulletin" HeaderText="公告内容">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="PublishTime" DataFormatString="{0:yyyy-MM-dd}" 
                    HeaderText="发布时间">
                    <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="编辑/删除" HeaderStyle-Width="120px">
                    <ItemTemplate>
                        <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/Images/XiuGaiBtn.png" CommandArgument='<%# Eval("SystemId") %>' CommandName="SystemInfoEdit" />
                        &nbsp;&nbsp;
                        <asp:ImageButton ID="imgBtnDelete" runat="server" ImageUrl="~/Images/DELBtn.png" CommandArgument='<%# Eval("SystemId") %>' CommandName="SystemInfoDelete" OnClientClick="return confirm('确认删除该系统公告')" />
                    </ItemTemplate>

<HeaderStyle Width="120px"></HeaderStyle>
                </asp:TemplateField>
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

