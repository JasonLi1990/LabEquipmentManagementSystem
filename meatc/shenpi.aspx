<%@ Page Language="C#" AutoEventWireup="true" CodeFile="shenpi.aspx.cs" Inherits="RegisterResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>您正在通过邮箱链接直接审批</title>
</head>
<script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
<body style="margin-top:0px; background:url(Images/newbg.gif);">
    <form id="form1" runat="server">
    <div>
    <table width=100% border=0 cellpadding=0 cellspacing=0>
    <tr><td colspan=2 class="style1">
       
        </td></tr>
    <tr><td width="1px" class="style2"></td><td width="1020px" class="style2"></td></tr>
    <tr>
      <td class="style3" valign=top align=center><br />
        <br /></td>
      <td class="style3" valign=top align=center><br />
        <table width="99%" border="0" align="left" cellpadding="0" cellspacing="0">
        <tr>
          <td height="46" valign="bottom" align="left" nowrap="nowrap"><table width="100%">
              <tr>
                <td width="100%"  align="left">&nbsp;</td>
              </tr>
          </table></td>
        </tr>
        <tr>
          <td height="396" align="center">
          <asp:Label ID="lb_result" runat="server"></asp:Label>
          <br />
              <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
              请输入您的系统密码：<asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"></asp:TextBox>
              <asp:Button ID="bt_confirm" runat="server" Text="确认审批" 
                  onclick="bt_confirm_Click" />
          </td>
        </tr>
       
      </table></td>
    </tr>
    <tr><td colspan=2 height="25px"></td></tr>    
    </table>
    </div>
    </form>
</body>
</html>
