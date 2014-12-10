<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="nPhotoOfHome.aspx.cs" Inherits="Admin_nPhotoOfHome" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/YuYueInfoList.png"/>
           
           
       </td>  
       <td valign="bottom">
            &nbsp;</td>
       <td valign="bottom">&nbsp;</td> 
       </tr>
       </table>      
       </td>       
   </tr>   
    <tr>
    <td align="center">
    <hr />    
    <span style="font-size:20px">首页显示的设备图片</span>
    <br />
        <asp:GridView ID="gv_showEquip" Width="90%" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
            CellPadding="3" GridLines="Vertical" DataKeyNames="EquipmentId" 
            onpageindexchanging="gv_showEquip_PageIndexChanging" 
            onrowdatabound="gv_showEquip_RowDataBound" AllowPaging="True" PageSize="15">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <Columns>
                <asp:TemplateField HeaderText="选择">
                    <ItemTemplate>
                       <asp:CheckBox ID="CBoxIsCheck" runat="server" />                          
                       <asp:HiddenField ID="hf_ischeck" runat="server" Value='<%# Eval("IsShow") %>' />
                   </ItemTemplate>
                </asp:TemplateField>
                <asp:HyperLinkField DataNavigateUrlFields="EquipmentId" ControlStyle-CssClass="blue" 
                    DataNavigateUrlFormatString="nShowEquipInfo.aspx?e_id={0}" 
                    DataTextField="EquipmentName" HeaderText="设备名称" >
<ControlStyle CssClass="blue"></ControlStyle>
                </asp:HyperLinkField>
                <asp:BoundField DataField="EquipmentTypeName" HeaderText="设备类型" />
                <asp:BoundField DataField="EquipmentModel" HeaderText="设备型号" />
                <asp:BoundField DataField="EquipmentPrice" HeaderText="设备价格" />
            </Columns>
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#DCDCDC" />
            
        </asp:GridView>
    </td></tr>
    <tr>
        <td align="center">
            <asp:ImageButton ID="imgBtnSaveSelect" runat="server" 
           ImageUrl="~/Images/SaveBtn.png" onclick="imgBtnSaveSelect_Click" />  
        </td>
    </tr>
   </table>
</asp:Content>

