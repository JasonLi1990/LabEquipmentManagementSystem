<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEditStudent.aspx.cs" Inherits="Admin_nEditStudent" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<style type="text/css">
.f1
{
	font-size:11pt;
}
</style>
<center>
<br /><br />
<table width="500px" class="f1">
    <tr>
        <td>登录用户名/学号
        </td>
        <td align="left">
            <asp:TextBox ID="LoginName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <asp:Panel ID="panel_pwd" runat="server" Visible="false" >
    <tr>
        <td>初始密码</td>
        <td align="left">
            <asp:TextBox ID="password_start" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    </asp:Panel>
    <tr>
        <td>姓名
        </td>
        <td align="left">
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>性别
        </td>
        <td align="left">
            <asp:RadioButton ID="boy" runat="server" Text="男" GroupName="sex" Checked="true" />
            <asp:RadioButton ID="girl" runat="server" Text="女" GroupName="sex" />
        </td>
    </tr>
    <tr>
        <td>出生日期
        </td>
        <td align="left">
             <asp:TextBox ID="txtBirthDate" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>固定电话
        </td>
        <td align="left">
            <asp:TextBox ID="tb_telphone" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>手机
        </td>
        <td align="left">
            <asp:TextBox ID="tb_cellphone" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>邮箱
        </td>
        <td align="left">
            <asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td colspan="2">
        <hr />
        默认只修改以上基本信息，若需要修改导师关系或密码，需勾选对应的复选框
        </td>
    </tr>
    <tr>
        <td><asp:CheckBox ID="cb_teacher" runat="server" Text="隶属导师" />
        </td>
        <td align="left">
            <asp:DropDownList ID="ddl_teacher" runat="server" DataTextField="UserName" DataValueField="UserId" Width="100px">
    </asp:DropDownList>
        </td>
    </tr>
    <asp:Panel ID="panel_modify" runat="server" Visible="true">
    <tr>
        <td><asp:CheckBox ID="cb_password" runat="server" Text="修改密码" />
        </td>
        <td align="left">
            <asp:TextBox ID="tb_password" runat="server" TextMode="Password" MaxLength="20"></asp:TextBox>
        </td>
    </tr>
    </asp:Panel>
    <tr>
        <td colspan="2">
        <br />            
            <asp:Button ID="bt_submit" runat="server" Text="保存修改" 
                onclick="bt_submit_Click" />            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" value="返回上一页" onclick="window.history.go(-1);" />
        </td>
    </tr>
</table>
</center>
</asp:Content>

