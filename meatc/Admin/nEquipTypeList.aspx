<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nEquipTypeList.aspx.cs" Inherits="Admin_nEquipTypeList" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style type="text/css">
.blue
{
	color:Blue;
	font-size:11pt
}
</style>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right> 
           <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/EquipmentTypeManageTitleBtn.png" />
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>
   <tr id="TREdit" runat=server visible=false>
       <td>
       <table width=100% border=0 cellpadding=0 cellspacing=0>
       <tr>
       <td align=right width=250px height=30px class="blue">设备类型</td>
       <td width=10px></td>
       <td align=left>
        <asp:HiddenField ID="hf_type" runat="server" />
           <asp:TextBox ID="txtItemTypeName" runat="server" Width=150px></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="请输入设备类型" ControlToValidate="txtItemTypeName" ForeColor="Red">请输入设备类型</asp:RequiredFieldValidator>
           </td>      
       </tr>
        <tr>  
       <td align=right height=30px class="blue">设备类型说明</td>
       <td width=10px></td>
       <td align=left>
           <asp:TextBox ID="txtRemark" runat="server" Width=150px></asp:TextBox></td>  
       </tr>
        <tr>  
       <td align=center colspan=3  height=30px>
           <asp:ImageButton ID="imgBtnEdit" ImageUrl="~/Images/BtnAdd.png"  runat="server" 
               onclick="imgBtnEdit_Click"  />
         </td>
       </tr>
       <tr>
       <td colspan=3>
       <hr width=90%/>
       </td>
       </tr>
       </table>
       </td>
   </tr>
   <tr>
   <td>
       <asp:GridView ID="GVEquipmentType" runat="server" AutoGenerateColumns="False" AllowPaging="true" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" PageSize="10"
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
           onpageindexchanging="GVEquipmentType_PageIndexChanging" 
           onrowcommand="GVEquipmentType_RowCommand">
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" Font-Size="11pt" />
           <Columns>               
               <asp:BoundField HeaderText="设备类型" DataField="EquipmentTypeName">
               <HeaderStyle Width="60%" CssClass="blue" Height="30px" />
               <ItemStyle Height="30px" />
               </asp:BoundField>                             
               <asp:TemplateField HeaderText="修改">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnUpdate" CausesValidation="False" CommandArgument='<%#Eval("EquipmentTypeId") %>' CommandName="EquipmentTypeUpdate" runat="server" ImageUrl="~/Images/XiuGaiBtn.png"/>
                   </ItemTemplate>
                   <HeaderStyle Width="20%" CssClass="blue" />
               </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                   <ItemTemplate>
                       <asp:ImageButton ID="imgBtnDel" CausesValidation="False" OnClientClick="return confirm('确认删除该类型吗？')" CommandArgument='<%#Eval("EquipmentTypeId") %>' CommandName="EquipmentTypeDel" runat="server" ImageUrl="~/Images/DELBtn.png"/>
                   </ItemTemplate>
                   <HeaderStyle Width="20%" CssClass="blue" />
               </asp:TemplateField>
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       </td>
   </tr>
   
   <tr>
   <td align=center valign=middle height=30px>
       <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/Images/BtnAdd.png" 
            CausesValidation="False" onclick="imgBtnAdd_Click" />
     </td>
   </tr>
   </table>
</asp:Content>

