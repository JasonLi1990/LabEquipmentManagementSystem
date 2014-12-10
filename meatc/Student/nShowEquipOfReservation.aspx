<%@ Page Language="C#" MasterPageFile="~/Student/S_MasterPage.master" AutoEventWireup="true" CodeFile="nShowEquipOfReservation.aspx.cs" Inherits="Student_nShowEquipOfReservation" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="../My97DatePicker/datapicker.js" type="text/javascript"></script>
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

   <tr height="350px">
   <td valign=top align="center">
       <asp:GridView ID="GVEquipment" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center"
           Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="None" 
           DataKeyNames="ReservationId" HeaderStyle-HorizontalAlign="Center" 
           BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
           onrowdatabound="GVEquipment_RowDataBound" >
           <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
           <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
           <Columns> 
                <asp:BoundField HeaderText="设备名称" DataField="EquipmentName">
               <HeaderStyle />
               </asp:BoundField> 
               <asp:BoundField HeaderText="预处理费" DataField="YuChuli">
               
               </asp:BoundField>  
               <asp:BoundField HeaderText="单价(元)" DataField="Price">
               
               </asp:BoundField>
                  
               
               
               <asp:TemplateField HeaderText="样品数量">
                   <ItemTemplate>
                       <asp:Label ID="lblNum" runat="server" Text='<%#Eval("EquipmentNum") %>'></asp:Label>
                       <asp:Label ID="lblEquipmentUnit" runat="server" Text='<%#Eval("EquipmentUnitName") %>'></asp:Label>
                   </ItemTemplate>               
               </asp:TemplateField> 
               <asp:BoundField HeaderText="测定元素数" DataField="YuanSuNum" />

               <asp:TemplateField HeaderText="预约时间">
                   <ItemTemplate>
                    <asp:Label ID="lbReservationtime" runat="server" Text='<%#Eval("BeginReservationTime") + "#" + Eval("EndReservationTime") %>'></asp:Label>
                   </ItemTemplate>
               
               </asp:TemplateField> 
               <asp:BoundField HeaderText="押金(元/台)" DataField="Deposit">                            
                 
               </asp:BoundField>
                <asp:TemplateField HeaderText="设备总额">
                   <ItemTemplate>
                       <asp:Label ID="lblTotle" runat="server" Text='<%#Eval("Totle") %>'></asp:Label>
                       <asp:HiddenField ID="HFAdditionalCosts" runat="server" Value='<%#Eval("AdditionalCosts") %>' />
                   </ItemTemplate>
               
               </asp:TemplateField>
               <asp:BoundField HeaderText="预处理费总额">
               
               </asp:BoundField>
               <asp:BoundField HeaderText="预处理样品数" DataField="YuChuliNum" />
               <asp:BoundField HeaderText="附加费" DataField="AdditionalCosts" />
                                                                             
           </Columns>
           <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
           <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
           <AlternatingRowStyle BackColor="#DCDCDC" />
       </asp:GridView>
       </td>
   </tr>   
   <tr>
   <td align=center valign=middle height=40px>       
    设备总额=单价*样品数*测定元素个数（如果按时长计费，还乘以时长）<br />
    预处理费总额=预处理单价*样品数<br />
    
    所有花销=设备总额+预处理费总额
    <hr />
           <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" onclick="imgBtnBack_Click"
            />
     </td>
   </tr>  
   </table>
</asp:Content>

