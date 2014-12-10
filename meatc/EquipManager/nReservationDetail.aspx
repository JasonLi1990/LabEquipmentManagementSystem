<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nReservationDetail.aspx.cs" Inherits="EquipManager_nReservationDetail" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../My97DatePicker/datapicker.js" type="text/javascript"></script>
<style type="text/css">
.d5
{
	font-size:11pt;
}
</style>
<asp:Panel ID="panelEquipmentList" runat="server" CssClass="d5" Visible="false" 
        Style="position: absolute;
        width: 507px; height: 150px; z-index: 100; top: 185px; left: 284px; background-color: White; border:solid;">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            
            <tr>
                <td align="center">
                    调整该设备预约时间  (<span style="color:Red">11：30~1：30为午休时间，不能做为预约开始时间</span>)
                <hr />
                    <asp:HiddenField ID="hf_reservationId" runat="server" />
                    开始时间：<input type="text" id="tb_start" runat="server" onclick="setDayHM(this);" />
                    ----
                    结束时间：<input type="text" id="tb_end" runat="server" onclick="setDayHM(this)" />
                </td>
            </tr>
            <tr>
                <td height="40px" align="center">
                    <asp:ImageButton ID="imgBtnEquipmentSave" runat="server" 
                        ImageUrl="~/Images/BtnUpdate.png" onclick="imgBtnEquipmentSave_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="imgBtnEquipmentclose" runat="server" 
                        ImageUrl="~/Images/CloseBtn.png" onclick="imgBtnEquipmentclose_Click" /><!--关闭按钮-->
                </td>
            </tr>
        </table>
    </asp:Panel>
<table width=100% cellpadding=0  cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right>
           <asp:Image ID="imgTitle" runat="server" ImageUrl="~/Images/TitleBtnYuYueInfo.png"/>
       </td>       
       </tr>
       </table>      
       </td>       
   </tr>

   <tr height=410px>
   <td valign=top>
       <asp:GridView ID="GVEquipment" runat="server" AutoGenerateColumns="False" 
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" DataKeyNames="ReservationId" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
           onrowdatabound="GVEquipment_RowDataBound" 
           onrowcommand="GVEquipment_RowCommand" 
            >
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="10pt" HorizontalAlign="Center" />
           <HeaderStyle Font-Size="11pt" />
           <Columns> 
                <asp:BoundField HeaderText="设备名称" DataField="EquipmentName">
               
               </asp:BoundField> 
                <asp:BoundField HeaderText="预处理费" DataField="Yuchuli">
               
               </asp:BoundField>    
               <asp:BoundField HeaderText="单价(元)" DataField="Price">
               
               </asp:BoundField>
               <asp:TemplateField HeaderText="样品数量">
                   <ItemTemplate>
                        <asp:TextBox ID="lblNum" runat="server" Text='<%#Eval("EquipmentNum") %>' Width="20px"></asp:TextBox>                       
                       <asp:Label ID="lblEquipmentUnit" runat="server" Text='<%#Eval("EquipmentUnitName") %>'></asp:Label>
                   </ItemTemplate>
                   <HeaderStyle Width="10%" />
               </asp:TemplateField> 
               <asp:TemplateField HeaderText="预处理样品数">
                    <ItemTemplate>
                        <asp:TextBox ID="lblYuChuliNum" runat="server" Width="20px" Text='<%# Eval("YuChuliNum") %>'></asp:TextBox>
                    </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="测定元素数量">
                <ItemTemplate>
                    <asp:TextBox ID="tb_elementNum" Width="40px" runat="server" Text='<%# Eval("YuanSuNum") %>'></asp:TextBox>
                </ItemTemplate>
               </asp:TemplateField>
               <asp:TemplateField HeaderText="预约时间">
                   <ItemTemplate>
                        <asp:LinkButton ID="lbReservationtime" runat="server" CommandName="ChangeTime" CommandArgument='<%#Eval("ReservationId") %>' Text='<%#Eval("BeginReservationTime") + "#" + Eval("EndReservationTime") %>'></asp:LinkButton>                       
                   </ItemTemplate>
                   <HeaderStyle Width="15%" />
               </asp:TemplateField> 
               <asp:BoundField HeaderText="押金" DataField="Deposit">
                 <HeaderStyle Width="10%" />
               </asp:BoundField>
                <asp:TemplateField HeaderText="设备总额">
                   <ItemTemplate>
                        <asp:TextBox ID="lblTotle" runat="server" Text='<%#Eval("Totle") %>' Width="40px"></asp:TextBox>
                       
                       <asp:HiddenField ID="HFAdditionalCosts" runat="server" Value='<%#Eval("AdditionalCosts") %>' />
                   </ItemTemplate>
                   <HeaderStyle Width="10%" />
               </asp:TemplateField>
               <asp:TemplateField HeaderText="预处理总额">
                   <ItemTemplate>
                       <asp:TextBox ID="txtYuChuli" Enabled="false" runat="server" Width="30px"></asp:TextBox>
                   </ItemTemplate>
                   
               </asp:TemplateField>
                                           
               <asp:TemplateField HeaderText="附加费">
                   <ItemTemplate>
                       <asp:TextBox ID="txtAdditionalCosts" runat="server" Text='<%#Eval("AdditionalCosts") %>' Width=30px></asp:TextBox>
                   </ItemTemplate>
                   
               </asp:TemplateField>
               
                <asp:TemplateField HeaderText="附加费说明">
                   <ItemTemplate>
                       <asp:TextBox ID="txtAdditionalCostsExplain" runat="server" 
                           Text='<%#Eval("AdditionalCostsExplain") %>' Width=100px Height="30px" 
                           TextMode="MultiLine"></asp:TextBox>
                       <asp:HiddenField ID="HFReservationId" runat="server" Value='<%#Eval("ReservationId") %>' />
                   </ItemTemplate>
                   
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
   <td align="center" valign="middle" height="40px">
                <asp:Button ID="bt_calculate" runat="server" Text="重新计算" 
                    OnClientClick="return confirm('确认重新计算？计算完成后请点击确认按钮保存计算结果！')" 
                    onclick="bt_calculate_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    总价格：<asp:Label ID="lb_totalMoney" runat="server" ForeColor="Blue"></asp:Label>元
        <hr />
       <asp:ImageButton ID="imgBtnok" runat="server" ImageUrl="~/Images/QueRenBtn.png" 
           CausesValidation="False" onclick="imgBtnok_Click"  />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" onclick="imgBtnBack_Click" 
            />
     </td>
   </tr>  
   </table>
</asp:Content>

