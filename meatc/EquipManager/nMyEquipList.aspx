<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nMyEquipList.aspx.cs" Inherits="EquipManager_nMyEquipList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript" src="My97DatePicker/WdatePicker.js"></script>
  <table width=100% cellpadding=0  cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x" nowrap>
       <table width="100%">
       <tr>
       <td width=150px align=right>
           <asp:Image ID="imgTitle" runat="server" ImageUrl="~/Images/SheBeiListBtn.png"/>
           
       </td>  
       <td>
        <asp:LinkButton ID="first" runat="server" Text="首页" onclick="first_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="uppage" runat="server" Text="上一页" onclick="uppage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="nextpage" runat="server" Text="下一页" onclick="nextpage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        <asp:LinkButton ID="lastpage" runat="server" Text="尾页" onclick="lastpage_Click"></asp:LinkButton>
        &nbsp;&nbsp;
        跳至第
        <asp:DropDownList ID="ddl_page" runat="server" Width="45px" AutoPostBack="True" 
               onselectedindexchanged="ddl_page_SelectedIndexChanged"></asp:DropDownList>
        页
       </td>     
       </tr>
       </table>      
       </td>       
   </tr>
   <!--界面修改-->
   <tr>
   <td>
   <table width=100% border=0 cellpadding=0 cellspacing=0>
   <tr>
   <td height=30px width=150px align=right class="blue">
   设备类型
   </td>
   <td width=10px>
   </td>
   <td width=150px align=left>
       <asp:DropDownList ID="ddlEquipmentType" runat="server" Width=180px  CssClass="SelectCss" DataTextField="EquipmentTypeName" DataValueField="EquipmentTypeId">
       </asp:DropDownList>
   </td>
   <td height=30px class="blue" align=right>
   设备状态
   </td>
   <td>
   </td>
   <td align=left>
       <asp:DropDownList ID="ddlEquipmentState" runat="server" Width=120px  CssClass="SelectCss">
           <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
           <asp:ListItem Value="21">设备正常</asp:ListItem>
           <asp:ListItem Value="22">设备损坏</asp:ListItem>
           <asp:ListItem Value="23">设备正在维修</asp:ListItem>
           <asp:ListItem Value="24">设备报废</asp:ListItem>
       </asp:DropDownList>
   </td>
   <td>
        设备名称：<asp:TextBox ID="tb_teaName" runat="server"></asp:TextBox>
           
       </td>
   <td>
       <asp:ImageButton ID="imgBtnSelect" runat="server" OnClick="imgBtnSelect_Click"
           ImageUrl="~/Images/SouSuoBtn.png" />
   </td>
   </tr>  
   </table>
   </td>
   </tr>
   <tr>
    <td height=10px>
       <hr width=95% />
       </td>
   </tr>
   
   <tr>
    <td>
        <asp:GridView ID="gv_Equipment" runat="server" AutoGenerateColumns="False" 
           Width="100%" AllowPaging="True" CellPadding="3" 
            GridLines="Vertical" PageSize="10" 
            onpageindexchanging="gv_Equipment_PageIndexChanging" 
            onrowcommand="gv_Equipment_RowCommand" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
           <Columns>                       
               <asp:HyperLinkField HeaderText="设备名称" DataTextField="EquipmentName" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" />
                <asp:BoundField HeaderText="设备型号" DataField="EquipmentModel">
               
               </asp:BoundField>     
               <asp:BoundField HeaderText="设备类型" DataField="EquipmentTypeName">
               
               </asp:BoundField>                    
               
               <asp:BoundField HeaderText="使用次数" DataField="FrequencyOfUse">                            
               
               </asp:BoundField>          
               <asp:BoundField HeaderText="当前状态" DataField="StateName">
               
               </asp:BoundField>                      
               <asp:TemplateField HeaderText="状态修改">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnUpdate"  CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentZhengChang" runat="server" ImageUrl="~/Images/BtnZhengChang.png" />
                        <asp:ImageButton ID="ImageButton1"  CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentSunHuai" runat="server" ImageUrl="~/Images/BtnSunHuai.png" />
                         <asp:ImageButton ID="ImageButton2"  CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentWeiXiu" runat="server" ImageUrl="~/Images/BtnWeiXiu.png" />
                          <asp:ImageButton ID="ImageButton3"  CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentBaoFei" runat="server" ImageUrl="~/Images/BtnBaoFei.png" />
                   </ItemTemplate>
                   
               </asp:TemplateField>          
               <asp:HyperLinkField HeaderText="修改" Text="修改" ControlStyle-CssClass="blue" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nModifyEquipInfo.aspx?e_id={0}" />
           </Columns>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
    </td>
   </tr>   
   <tr>
    <td align="center">
        <hr />
        <asp:Button ID="bt_change" runat="Server" Text="点击此处使所有设备周六周日正常预约" 
            onclick="bt_change_Click" Height="42px" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_sleep" runat="Server" Text="周六周日不能预约" Height="42px" 
            onclick="bt_sleep_Click" />
    </td>
   </tr>
</table>
</asp:Content>

