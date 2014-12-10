<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true"  CodeFile="index.aspx.cs" Inherits="_Default" Debug="true" %>
<title>欢迎使用市政环境工程学院实验中心网上预约系统</title>
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
        <asp:Panel ID="panel_showEquip" runat="server" Visible="false" CssClass="blue" style=" position:absolute; width:500px; height:auto; z-index:100; top: 225px; left: 125px; background-color:White">
            <table width="100%">
                    <tr>
                       <td align="center" rowspan="6">
                                <asp:Image ID="imgEquipmentPhoto" runat="server" Height="190px" 
                               Width="200px" />
                       </td>
                       <td width="100px" align="right" height="35px" class="blue">
                           设备名称</td>
                       
                            <td align="left" width="200px"  class="blue">
                                <asp:Label ID="lblEquipmentName" runat="server"></asp:Label>
                       </td>
           </tr>
           <tr>
               <td width=100px align=right height="35px" class="blue">
                   设备型号</td>
               
                    <td align="left"  class="blue">
                       <asp:Label ID="lblEquipmentModel" runat="server"></asp:Label> 
               </td>
           </tr>
           <tr>
               <td width=100px align=right height="35px" class="blue">
                   设备类型</td>
               
                    <td align="left"  class="blue">
                        <asp:Label ID="lblEquipmentType" runat="server"></asp:Label>
               </td>
           </tr>
                     
           <tr>
                <td align=right height="35px" class="blue">
                   设备管理员</td>
               
                    <td align="left"  class="blue">
                        <asp:Label ID="lblEquipmentManager" runat="server"></asp:Label>
                        
               </td>
               
               
           </tr>
           <tr>
             <td align=right class="blue">
                    押金</td>
               
                    <td align="left"  class="blue">
                        <asp:Label ID="lblDeposit" runat="server"></asp:Label>
               </td>
           </tr>
                    
           <tr>
               <td align=right height="35px" class="blue">
                   设备说明</td>
               
                    <td align="left"  class="blue">
                        <asp:Label ID="lblNodes" runat="server"></asp:Label>
               </td>                
           </tr>           
                    <tr>
                        <td align="center" colspan="3">
                    <asp:ImageButton ID="imgBtnPasswordClose" runat="server" ImageUrl="~/Images/CloseBtn.png"
                 CausesValidation="False" onclick="imgBtnPasswordClose_Click"  />
                        </td>
                    </tr>
                </table>
   </asp:Panel>
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
                  <td height="198" align="right" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <asp:Repeater ID="rp_notes" runat="server">
                        <ItemTemplate>
                            <tr>
                              <td width="22%">&nbsp;</td>
                              <td height="25" colspan="2" align="left" class="left_txt">
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
                        <td align="right">
                            <a href="SystemInfo.aspx" style="font-size:10pt">
                            >>更多<<</a>
                        </td>
                    </tr>
                    <tr>

                        <td width="90%" height="40" colspan="3" style="padding-left:120px">
	                        <marquee direction="left" behavior="scroll" scrollamount="10" scrolldelay="200" onmouseout="this.start()"  onMouseOver="this.stop()">
                         <asp:DataList ID="dl_photos" runat="server" RepeatColumns="50" onitemcommand="dl_photos_ItemCommand" >
                                                        <ItemTemplate>                                    
                                                            <asp:ImageButton ID="img2" runat="server" Width="180px" Height="150px" ImageUrl='<%# Eval("EquipmentPhotoPath") %>' CommandName="ShowEquipment" CommandArgument='<%# Eval("EquipmentId") %>' CausesValidation="false" />
                                                        </ItemTemplate>
                                                    </asp:DataList></marquee>
                        </td>
                    </tr>
                  </table></td>
                </tr>
              </table></td>
            </tr>
            
        </table></td>
        <td width="1%" >&nbsp;</td>
        <td width="50%" valign="bottom"><table width="100%" height="59" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td width="4%">&nbsp;</td>
              <td width="96%" height="38"><span class="login_txt_bt">请登陆网上预约平台</span></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td height="21"><table cellSpacing="0" cellPadding="0" width="100%" border="0" id="table211" height="328">
                  <tr>
                    <td height="164" colspan="2" align="middle"><form name="myform" action="index.html" method="post">
                        <table cellSpacing="0" cellPadding="0" width="100%" border="0" height="143" id="table212">
                          <tr> 
                            <td width="13%" height="38" class="top_hui_text"><span class="login_txt">账 号：&nbsp;&nbsp; </span></td>
                            <td height="38" colspan="2" class="top_hui_text">
                                <asp:TextBox ID="txtName" CssClass="editbox4" runat="server" 
                        Width="160px" ></asp:TextBox>
                                                     </td>
                          </tr>
                          <tr>
                            <td width="13%" height="35" class="top_hui_text"><span class="login_txt"> 密 码： &nbsp;&nbsp; </span></td>
                            <td height="35" colspan="2" class="top_hui_text"><asp:TextBox ID="txtPw" Width=160px runat="server" TextMode="Password"></asp:TextBox>
                              <img src="images/luck.gif" width="19" height="18"> </td>
                          </tr>                         
                          <tr>
                            <td height="35">&nbsp;</td>
                            <td width="15%" height="35" >
                            <asp:ImageButton ID="bt_login" runat="server" ImageUrl="~/Images/LoginBtn.png" 
                                    onclick="bt_login_Click" />
                            
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                                    ImageUrl="Images/ResetBtn.png"  />
                            </td>
                          </tr>
                          <tr>
                      <td width="15%">&nbsp;</td>
                      <td width="20%" height="40"><img src="images/icon-demo.gif" width="16" height="16">&nbsp;<a href="Images/演示操作脚本流程.doc" target="_blank" style="color:Red">预约流程下载</a> </td>
                      <td ><img src="images/icon-login-seaver.gif" width="16" height="16"><a href="Register.aspx" style="color:Red"> 注册用户</a></td>
                    </tr>
                        </table>
                        <br>
                    </form></td>
                  </tr>
                  <tr>
                    <td width="433" height="164" align="right" valign="bottom"><img src="images/login-wel.gif" width="242" height="138"></td>
                    <td width="57" align="right" valign="bottom">&nbsp;</td>
                  </tr>

              </table></td>
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
