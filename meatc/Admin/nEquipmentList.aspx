<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipmentList.aspx.cs" Inherits="Admin_nEquipmentList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>

  <table width=100% cellpadding=0  cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
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
       <asp:DropDownList ID="ddlEquipmentType" runat="server" Width=180px  CssClass="SelectCss" DataTextField="EquipmentTypeName" DataValueField="EquipmentTypeID">
       </asp:DropDownList>
   </td>
   <td height=30px class="blue" align=right>
   设备状态
   </td>
   <td>
   </td>
   <td align=left>
       <asp:DropDownList ID="ddlEquipmentState" runat="server" Width="120px"  CssClass="SelectCss">
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
       <asp:ImageButton ID="imgBtnSelect" runat="server" 
           ImageUrl="~/Images/SouSuoBtn.png" onclick="imgBtnSelect_Click" />
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
           Width="100%" AllowPaging="True" CellPadding="3" DataKeyNames="EquipmentId" 
            GridLines="Vertical" PageSize="8" 
            onpageindexchanging="gv_Equipment_PageIndexChanging" 
            onrowcommand="gv_Equipment_RowCommand" BackColor="White" 
            BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            onrowdatabound="gv_Equipment_RowDataBound">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="11pt" HorizontalAlign="Center" />
           <Columns>  
               <asp:TemplateField HeaderText="公开">
                   <ItemTemplate>
                       <asp:CheckBox ID="CBoxIsCheck" runat="server" />   
                       <asp:HiddenField ID="HFIsCheck" runat="server" Value='<%#Eval("IsCheck") %>' />                 
                   </ItemTemplate>
                   
               </asp:TemplateField>             
               <asp:HyperLinkField HeaderText="设备名称" DataTextField="EquipmentName" DataNavigateUrlFields="EquipmentId" DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" />
                <asp:BoundField HeaderText="设备型号" DataField="EquipmentModel">
               <HeaderStyle Width="15%" />
               </asp:BoundField>     
               <asp:BoundField HeaderText="设备类型" DataField="EquipmentTypeName">
               <HeaderStyle Width="15%" />
               </asp:BoundField>   
                 
               <asp:BoundField HeaderText="设备价格(元)" DataField="EquipmentPrice">
               <HeaderStyle Width="10%" />
               </asp:BoundField>   
               <asp:BoundField HeaderText="使用次数" DataField="FrequencyOfUse">                            
               <HeaderStyle Width="10%" />
               </asp:BoundField>                             
               <asp:TemplateField HeaderText="修改">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnUpdate" CausesValidation="False" CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentUpdate" runat="server" ImageUrl="~/Images/XiuGaiBtn.png" />
                   </ItemTemplate>
                   <HeaderStyle Width="10%" />
               </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnDel" CausesValidation="False" OnClientClick="return confirm('确认要删除该设备吗？')" CommandArgument='<%#Eval("EquipmentId") %>' CommandName="EquipmentDel" runat="server" ImageUrl="~/Images/DELBtn.png" />
                   </ItemTemplate>
                   <HeaderStyle Width="10%" />
               </asp:TemplateField>             
           </Columns>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
    </td>
   </tr>
   <tr>
    <td align="center">
    <br />
        <asp:CheckBox ID="cb_selectAll" runat="server" Text="当前页全选" AutoPostBack="true" 
            oncheckedchanged="cb_selectAll_CheckedChanged" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png"
            CausesValidation="False" onclick="imgBtnAdd_Click" Visible="false" />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:ImageButton ID="imgBtnSaveIsCheck" runat="server" 
           ImageUrl="~/Images/SaveXZBtn.JPG" CausesValidation="False" onclick="imgBtnSaveIsCheck_Click" />
           
           
    </td>
   </tr>
</table>
</asp:Content>

