<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true"  CodeFile="副本 nindex.aspx.cs" Inherits="_Default" Debug="true" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<link type="text/css" rel="stylesheet" href="./css/login.css"/>
<link type="text/css" rel="stylesheet" href="./css/reset-min.css"/>
<script src="js/jquery-1.4.3.min.js"></script>
	<script src="js/jqFancyTransitions.1.8.js"></script>
<title>欢迎使用市政环境工程学院实验中心网上预约系统</title>
</head>
<script type="text/javascript">
		$(function() {			
			$('#slideshowHolder').jqFancyTransitions({ width: 528, height: 329, strips:20,  navigation: true, delay: 500000 });
		});
	</script>
<body>
<form id="form1" runat="server">
    <center>
	<div class="container">	
	    <div class='m-corner'>
		<div id="left">
			<div id="logo_picture"></div>
			<div id="logo_banner">
				<div id="logo_banner_text">&nbsp;请登录网上预约平台&nbsp;</div>
			</div>
			
			<div id="form">
			    
				<table style="margin-top:50px">
					<tr >
						<td style="color:#A1BDD8;">账号</td><td>&nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server" 
                        Width="160px" ></asp:TextBox></td>
					</tr>
					<tr>
					    <td><br /></td>
					</tr>
					<tr>
						<td style="color:#A1BDD8;">密码</td><td>&nbsp;&nbsp;<asp:TextBox ID="txtPw" Width=160px runat="server" TextMode="Password"></asp:TextBox><img id="form_input_lock" alt="lock" src="image/form_input_lock.png" /></td>
					</tr>
				
					<tr>
						<td></td>
						<td><br />
							<asp:ImageButton ID="bt_login" runat="server" ImageUrl="~/Images/LoginBtn.png" 
                                    onclick="bt_login_Click" />
							<asp:ImageButton ID="ImageButton2" runat="server" 
                                                    ImageUrl="Images/ResetBtn.png"  />
						</td>
					</tr>
				</table>	
						<div style="margin-left:45px">
							<a href="Register.aspx" class="form_link">注册用户</a>
							<a href="Images/演示操作脚本流程.doc" class="form_link">预约流程下载</a>
						</div>
				
			</div>
		</div>
		
		<div id="right">
			<div id="news">
			    <h3>站内公告</h3>
			       
			        <asp:Repeater ID="rp_notes" runat="server" >
                        <ItemTemplate>
                                 <div class="news-line"><a href='SystemInfo.aspx?id=<%# Eval("SystemId") %>'>
                                        <asp:Label ID="lb_content" runat="server" Text='<%# Eval("SystemBulletin").ToString().Length>60?Eval("SystemBulletin").ToString().Substring(0,60):Eval("SystemBulletin").ToString() + "..." %>'></asp:Label>
                                        </a><span>
                            
                                        <asp:Label ID="lb_time" runat="server" ForeColor="Black" Text='<%# "●" + Convert.ToDateTime(Eval("PublishTime")).ToLongDateString() %>'></asp:Label>
                                        
                                        </span>
                                  </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    
                            <div class="more">
                            <a href="SystemInfo.aspx" style="font-size:10pt">
                            >>更多<<
                            </a></div>
                        
			</div>
			<div id="gallery">
			    <div id='slideshowHolder'>			        
			    <asp:DataList ID="dl_photos" runat="server" RepeatColumns="50" onitemcommand="dl_photos_ItemCommand" >
                                                        <ItemTemplate>  
                                                        <asp:Image ImageUrl='<%# Eval("EquipmentPhotoPath") %>' runat="Server" />
                                                                
                                                        </ItemTemplate>
                    </asp:DataList>
                </div>                                   
			</div>
		</div>
		<div style="clear:both;"></div>
		</div>
	</div>
	
	<div class="bottom corner">
	
		<div><p>
		地址：哈尔滨市南岗区黄河路73号 哈尔滨工业大学二校区<br />
Address: The Second Campus of Harbin Institute of Technology, 73 Huanghe Road, Nanggang District, Harbin, China<br />
联系电话：(0451)86283067     传真：(0451)86283067<br />
Tel： (0451)86283067      Fax： (0451)86283067
</p>
</div>
	</div>
</center> </form>
</body>
<!--[if IE]>
        <script src="js/jquery.corner.js">
        </script>
        <script src="js/login-corner-ie.js">
        </script>
    <![endif]-->
</html>
