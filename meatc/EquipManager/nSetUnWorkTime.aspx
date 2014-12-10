<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nSetUnWorkTime.aspx.cs" Inherits="EquipManager_nSetUnWorkTime" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../My97DatePicker/datapicker.js" type="text/javascript"></script>
<style type="text/css">
.f1
{
	font-size:11pt;
}
</style>
<center>
<br />
<asp:Label ID="lb_notes" runat="server" Font-Size="Medium">设置不工作时间，学生在预约设备时会提示</asp:Label>
<hr />

<table width="500px" class="f1">
    <tr>
        <td align="right">
            开始时间
        </td>
        <td align="left">            
            <input type="text" onclick="setDayHM(this);" runat="server" id="txtStartDate" width="150px" />
        </td>
        <td align="right">
            结束时间
        </td>
        <td>
            <input type="text" onclick="setDayHM(this);" runat="server" id="txtEndDate" width="150px" />
        </td>
    </tr>
    <tr>
        <td align="right">原因：</td>
        <td colspan="2" align="left">
            <asp:TextBox ID="tb_reason" runat="server" TextMode="MultiLine" Height="40px" 
                Width="200px"></asp:TextBox>            
        </td>
        <td align="left">
            <asp:Button ID="bt_add" runat="server" Text="添加" Height="40px" Width="100px" 
                onclick="bt_add_Click" />
        </td>
    </tr>
    
</table>
<asp:GridView ID="gv_unworkList" runat="server" AllowPaging="True" Width="90%" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
        PageSize="6" onpageindexchanging="gv_unworkList_PageIndexChanging" 
        onrowcommand="gv_unworkList_RowCommand">
    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
    <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" />
    <Columns>
        <asp:BoundField DataField="TimeStart" HeaderText="开始时间" />
        <asp:BoundField DataField="TimeEnd" HeaderText="结束时间" />
        <asp:BoundField DataField="Reason" HeaderText="不能预约的原因" />
        <asp:TemplateField HeaderText="删除">
            <ItemTemplate>
                <asp:LinkButton ID="bt_delete" Text="删除" CssClass="blue" CommandName="DelUnWork" CommandArgument='<%# Eval("TimeId") %>' runat="server" OnClientClick="return confirm('确定将该时间段删除？')">
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="#DCDCDC" />
    
</asp:GridView>
</center>
</asp:Content>

