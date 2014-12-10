<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true"  CodeFile="SystemInfo.aspx.cs" Inherits="_Default" Debug="true" %>
<title>系统公告---欢迎使用市政环境工程学院实验中心网上预约系统</title>
<style type="text/css">

body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #1D3647;
}

.blue {
	COLOR: #319eef! important;
	font-size:15px;
	border-style:double
}
</style>
<script language="JavaScript">
function correctPNG()
{
    var arVersion = navigator.appVersion.split("MSIE")
    var version = parseFloat(arVersion[1])
    if ((version >= 5.5) && (document.body.filters)) 
    {
       for(var j=0; j<document.images.length; j++)
       {
          var img = document.images[j]
          var imgName = img.src.toUpperCase()
          if (imgName.substring(imgName.length-3, imgName.length) == "PNG")
          {
             var imgID = (img.id) ? "id='" + img.id + "' " : ""
             var imgClass = (img.className) ? "class='" + img.className + "' " : ""
             var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
             var imgStyle = "display:inline-block;" + img.style.cssText 
             if (img.align == "left") imgStyle = "float:left;" + imgStyle
             if (img.align == "right") imgStyle = "float:right;" + imgStyle
             if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
             var strNewHTML = "<span " + imgID + imgClass + imgTitle
             + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle + ";"
             + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
             + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>" 
             img.outerHTML = strNewHTML
             j = j-1
          }
       }
    }    
}
window.attachEvent("onload", correctPNG);
</script>


<link href="images/skin.css" rel="stylesheet" type="text/css" />
<body>
<form id="form1" runat="server">
        
<table width="100%" height="166" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td height="42" valign="top"><table width="100%" height="42" border="0" cellpadding="0" cellspacing="0" class="login_top_bg">
      <tr>
        <td width="1%" height="21">&nbsp;</td>
        <td height="42">&nbsp;</td>
        <td width="17%">&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td valign="top"><table width="100%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg">
      <tr>
        <td width="49%" align="right"><table width="91%" height="532" border="0" cellpadding="0" cellspacing="0" class="login_bg2">
            <tr>
              <td height="138" valign="top"><table width="95%" height="427" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td height="100">&nbsp;</td>
                </tr>
                <tr>
                  <td height="80" align="right" valign="top"><img src="images/123.png" width="430" height="68"></td>
                </tr>
                <tr>
                  <td height="198" align="right" valign="top">
                    
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="rp_notes" runat="server">
                        <ItemTemplate>
                            <tr>
                              <td width="22%">&nbsp;</td>
                              <td height="25" colspan="2" align="left" class="left_txt" >
                                  <p>
                                        <a href='SystemInfo.aspx?id=<%# Eval("SystemId") %>'>
                                        <asp:Label ID="lb_time" runat="server" Text='<%# "【" + Convert.ToDateTime(Eval("PublishTime")).ToLongDateString() + "】" %>'></asp:Label>
                                        <asp:Label ID="lb_content" runat="server" Text='<%# Eval("SystemBulletin").ToString().Length>25?Eval("SystemBulletin").ToString().Substring(0,25):Eval("SystemBulletin").ToString() + "..." %>'></asp:Label>
                                        </a>
                                  </p>
                              </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr>
                        <td width="22%">&nbsp;</td>
                        <td align="right" style="font-size:10pt;">
                        <br />
                            当前页码:
                            [<asp:Label ID="lb_page" runat="server" Text="1"></asp:Label>]/共[
                            <asp:Label ID="lb_totalPage" runat="server"></asp:Label>]页&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lb_first" runat="server" onclick="lb_first_Click">首页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lb_up" runat="server" onclick="lb_up_Click">上一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lb_down" runat="server" onclick="lb_down_Click">下一页</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lb_last" runat="server" onclick="lb_last_Click">尾页</asp:LinkButton>
                        </td>
                    </tr>
                    
                  </table></td>
                </tr>
              </table></td>
            </tr>
            
        </table></td>
        <td width="1%" >&nbsp;</td>
        <td width="50%" valign="top" align="center" style="padding-top:150px;">
                <table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="4%">&nbsp;</td>
              <td width="96%" height="38" style="padding-left:100px;"><span class="login_txt_bt">系统公告【<asp:Label ID="lb_systemInfoTime" runat="server"></asp:Label>】</span></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td align="left" style="width:400px">
                    <asp:Label ID="lb_systeminfoContent" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td  align="right" style="width:400px">
                    <br /><br /><br /><br />
                    <a href="nindex.aspx">返回首页</a>
                </td>
            </tr>
            </table>
          </td>
      </tr>

    </table></td>
  </tr>

  <tr>
    <td height="20"><table width="100%" border="0" cellspacing="0" cellpadding="0" class="login-buttom-bg">
      <tr>
        <td align="center"><span class="login-buttom-txt">地址：哈尔滨市南岗区黄河路73号 哈尔滨工业大学二校区<br />
                Address: The Second Campus of Harbin Institute of Technology, 73 Huanghe Road, Nanggang District, Harbin, China<br />
                联系电话：(0451)86283067 &nbsp;&nbsp;&nbsp;
                传真：(0451)86283067<br />
                Tel： (0451)86283067 &nbsp;&nbsp;&nbsp;&nbsp;
                Fax： (0451)86283067 </span></td>
      </tr>
    </table></td>
  </tr>
</table>
</form>
</body>
