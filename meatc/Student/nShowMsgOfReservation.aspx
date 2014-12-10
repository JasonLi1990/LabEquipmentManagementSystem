<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="nShowMsgOfReservation.aspx.cs" Inherits="Student_nShowMsgOfReservation" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
<asp:Panel ID="panelEquipmentList" runat="server" CssClass="d5" Visible="false" Style="position:absolute;
        width: 300px; height: 200px; z-index: 100; top: 185px; left: 284px; background-color: White">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            
            <tr>
                <td align="center">
                    姓名：<asp:Label ID="lb_name" runat="server" ForeColor="Blue"></asp:Label>
                <hr />
                    <asp:HiddenField ID="hf_1" runat="server" />
                    固定电话：<asp:Label ID="lb_phone" runat="server" ForeColor="Blue"></asp:Label>
                    <br />
                    手机号码：<asp:Label ID="lb_mobile" runat="server" ForeColor="Blue"></asp:Label>
                    <br />
                    电子邮箱：                    
                    <asp:Label ID="lb_email" runat="server" ForeColor="Blue"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="40px">
                    <asp:ImageButton ID="imgBtnEquipmentclose" runat="server" 
                        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnEquipmentclose_Click" /><!--关闭按钮-->
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="panel_reply" runat="server" CssClass="d5" Visible="false" Style="position:absolute;
        width: 300px; height:auto; z-index: 100; top: 185px; left: 284px; background-color: White; border:solid;">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            
            <tr>
                <td align="center">
                    <asp:HiddenField ID="hf_reservationMsgId" runat="server" />                    
                    消息内容：                    
                    <br />
                    <asp:TextBox ID="tb_message" runat="server" TextMode="MultiLine" Height="80px" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="40px">
                    <asp:ImageButton ID="imgBtnSend" runat="server" 
                        ImageUrl="~/Images/QueRenBtn.png" onclick="imgBtnSend_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnCloseMsg" runat="server" 
                        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnCloseMsg_Click"  /><!--关闭按钮-->
                </td>
            </tr>
        </table>
    </asp:Panel>
    
    <hr />
<asp:Repeater ID="rp_msg" runat="server" onitemcommand="rp_msg_ItemCommand">
    <ItemTemplate>
        <table width="600px" border="1">
            <tr>
                <td>
                    <asp:HiddenField ID="hf_id" runat="server" Value='<%# Eval("ReservationMsgId") %>' />
                    消息来源：
                    <asp:LinkButton ID="lb_userName" CommandName="showContact" CommandArgument='<%# Eval("FromUserId") %>' runat="server" Text='<%# Eval("UserName") %>' ForeColor="Blue"></asp:LinkButton>
                    <%# Eval("UserType").ToString().Equals("3") ? "（管理员）" : "（自已/导师）"%>
                </td>
                <td align="right">
                    发送时间：
                    <%# Eval("ReservationMsgTime") %>
                </td>
                <td align="right">
                    <asp:LinkButton ID="lb_reply" runat="server" ForeColor="Blue" CommandName="replyMessage" CommandArgument='<%# Eval("ReservationMsgId") %>' Text="回复消息"></asp:LinkButton>
                    <asp:LinkButton ID="lb_del" runat="server" OnClientClick="return confirm('确认删除此消息吗？')" ForeColor="Red" CommandName="delMessage" CommandArgument='<%# Eval("ReservationMsgId") %>' Text="删除消息"></asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="left">
                    <%# Eval("ReservationMsgContent") %>
                </td>
            </tr>
        </table>
        
    </ItemTemplate>
</asp:Repeater>
<input type="button" value="返回上一页" onclick="window.history.go(-1);" />
<div style="height:200px"></div>
</center>
</asp:Content>

