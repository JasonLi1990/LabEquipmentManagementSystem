<%@ Page Language="C#" MasterPageFile="~/Admin/UserManagerMasterPage.master" AutoEventWireup="true" CodeFile="AdminManagerList.aspx.cs" Inherits="AdminSuper_AdminManagerList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
<table width="1024px">
    <tr>
        <td width="220px" align="center">
        <asp:Button ID="bt_exit" runat="server" Text="退出系统" Width="100px" Height="50px" 
                onclick="bt_exit_Click" />
        </td>
        <td align="center" valign="top">
        <br />
            <asp:Label ID="lb_info" runat="server" ForeColor="Blue" Font-Size="X-Large">系统管理员列表</asp:Label>
            <asp:Panel ID="panel_edit" runat="server" Visible="false">
                <asp:HiddenField ID="hf_userId" runat="server" />
                <asp:HiddenField ID="hf_operation" runat="server" />
                <table width="400px">                    
                    <tr>
                        <td align="right">登录名：</td>
                        
                        <td><asp:TextBox ID="tb_loginName" runat="server" Enabled="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">管理员姓名：</td>
                        <td><asp:TextBox ID="tb_username" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr id="tr_pwd" runat="server">
                        <td align="right">登录密码：</td>
                        <td>
                            <asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">性别：</td>
                        <td>
                            <asp:DropDownList ID="ddlSex" runat="server">
                                <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                <asp:ListItem Text="男" Value="1" Selected="True"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">固定电话：</td>
                        <td><asp:TextBox ID="tb_phone" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">手机：</td>
                        <td><asp:TextBox ID="tb_mobile" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">邮箱：</td>
                        <td><asp:TextBox ID="tb_email" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">
                            登录状态：
                        </td>
                        <td align="center">
                            <asp:RadioButton ID="rb_ok" runat="server" Checked="true" Text="正常" GroupName="state" />
                            <asp:RadioButton ID="rb_no" runat="server"  Text="禁用" GroupName="state" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:ImageButton ID="bt_submit" runat="server" ImageUrl="~/Images/SaveBtn.png" 
                                onclick="bt_submit_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="bt_cancel" runat="server" 
                                ImageUrl="~/Images/CloseBtn.png" onclick="bt_cancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        <hr />
            <asp:GridView ID="gv_admin" runat="server" AutoGenerateColumns="False" Width="100%"
                BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3" GridLines="Vertical" onrowcommand="gv_admin_RowCommand" 
                onrowdatabound="gv_admin_RowDataBound">
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" />
                <Columns>
                    <asp:BoundField DataField="LoginName" HeaderText="登录名" />
                    <asp:BoundField DataField="UserName" HeaderText="管理员姓名" />
                    <asp:BoundField DataField="UserSex" HeaderText="性别" />
                    <asp:BoundField DataField="UserPhone" HeaderText="电话" />
                    <asp:BoundField DataField="MobileTelephone" HeaderText="手机" />
                    <asp:BoundField DataField="UserEmail" HeaderText="邮箱" />
                    <asp:BoundField DataField="StateId" HeaderText="当前状态" />
                    <asp:TemplateField HeaderText="编辑">
                        <ItemTemplate>
                            <asp:ImageButton ID="imgBtn_modify" CommandArgument='<%# Eval("UserId") %>' CommandName="ModifyAdmin" runat="server" ImageUrl="~/Images/XiuGaiBtn.png" />                            
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="#DCDCDC" />
            </asp:GridView>
            <br />
            <asp:ImageButton ID="bt_add" runat="server" ImageUrl="~/Images/BtnAdd.png" 
                onclick="bt_add_Click" />
        </td>
        <td style="width:10px">&nbsp;</td>
    </tr>
</table>
</center>
</asp:Content>

