<%@ Page Language="C#" MasterPageFile="~/Admin/A_MasterPage.master" AutoEventWireup="true" CodeFile="ReportToTeacher.aspx.cs" Inherits="Admin_ReportToTeacher" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    function printdiv(printpage)
    {
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body>";
    var newstr = document.all.item(printpage).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr+newstr+footstr;
    window.print(); 
    document.body.innerHTML = oldstr;
    return false;
    }
</script>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x;" nowrap>
       <table width=150px>
       <tr>
       <td width=150px align=right valign=bottom> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/StatisticsReservationImg.png"/>
           
           
       </td>  
       <td valign=bottom>
            &nbsp;</td>
       <td valign=bottom>&nbsp;</td> 
       </tr>
       </table>      
       </td>       
   </tr>
   <tr>
    <td align="center">
        <div id="report_print">
        <asp:GridView ID="gv_report" runat="server" AutoGenerateColumns="False"  Width="100%"
            BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" onrowdatabound="gv_report_RowDataBound" ShowFooter="True">
            <FooterStyle BackColor="#99FFCC" ForeColor="#003399" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField HeaderText="编号" />
                <asp:BoundField DataField="EquipmentName" HeaderText="设备名称" />
                <asp:TemplateField HeaderText="价格/单位">
                    <ItemTemplate>
                        <asp:Label ID="lb_price" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                        元/
                        <asp:Label ID="lb_unit" runat="server" Text='<%# Eval("EquipmentUnitName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="EquipmentNum" HeaderText="样品个数" />
                <asp:BoundField DataField="UserName" HeaderText="申请人" />
                <asp:BoundField DataField="BeginReservationTime" HeaderText="实验时间" 
                    DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="Totle" HeaderText="总价" />
                
            </Columns>
            
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            
        </asp:GridView>
        </div>
    </td>
   </tr>
   <tr>
    <td align="center">
        <asp:Button ID="bt_excel" runat="server" Height="40px" Text="导出到Excel表格中" 
            onclick="bt_excel_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_print" runat="server" Height="40px" Text="打印报表" OnClientClick="printdiv('report_print');"
             /> &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bt_toTeacher" runat="server" Height="40px" Text="发送邮件给导师" 
            onclick="bt_toTeacher_Click"/>
    </td>
   </tr>
</table>
</asp:Content>

