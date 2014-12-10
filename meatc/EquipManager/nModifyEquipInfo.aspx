<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nModifyEquipInfo.aspx.cs" Inherits="EquipManager_nModifyEquipInfo" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/jscript">
    function imageUpdate(vv, ff) { 
        var fileobj = document.getElementById(ff);
        if (fileobj != null) {
            vv.src = fileobj.value;
        }
    }

    function imgUpdate(fileObj, imgobj) { 
        var currentimgobj = document.getElementById(imgobj);
        if (currentimgobj != null) {
            currentimgobj.src = fileObj.value; 
        } 
    }
    function imgUpload(fileObj) { 
        var currentimgobj = document.getElementById("imgEquipmentPhoto");
        
        if (currentimgobj != null) {
            currentimgobj.src = fileObj.value; 
        } 
    }
</script>
<table width="100%"  cellpadding="0" cellspacing="0" bgcolor="#99CCFF">
            <tr>
                <td colspan="6" align="center">
                <br /><br />
                <asp:Image ID="img_show" runat="server" Width="200px" Height="150px" />
                </td>
            </tr>
           <tr>
               <td width=150px align=right height=25px class="blue">
                   设备名称</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtEquipmentName" runat="server" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="请输入设备名称" ControlToValidate="txtEquipmentName" ForeColor="Red">*</asp:RequiredFieldValidator>
               </td>                              
                <td align=right class="blue">
                    设备型号</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtEquipmentModel" runat="server" Width="150px"></asp:TextBox>
               </td>               
           </tr>           
           
           
            <tr>
               <td align=right height=25px class="red">
                   预处理费</td>
                   <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtYuChuliFei" runat="server" Width="70px"></asp:TextBox>元
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
           ErrorMessage="预处理费请输入数字" Text="*" ControlToValidate="txtYuChuliFei" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
                <td align=right class="blue">
                    提前预约天数
                   </td>
               <td>
                   &nbsp;</td>
                    <td align="left">
                    <asp:DropDownList ID="ddl_startday" runat="server" Width="75px">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3" Selected="True">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        
                    </asp:DropDownList>
                    天
               </td>
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   计费方法</td>
                   <td>
                   &nbsp;</td>
                    <td align=left>
                     <asp:DropDownList ID="DDLBilling" runat="server" Width="150px">
                         <asp:ListItem Selected="True" Value="1">时间段计费</asp:ListItem>
                         <asp:ListItem Value="2">数量计费</asp:ListItem>
                        </asp:DropDownList>  
               </td>
                <td align=right class="blue">
                设备单位
                   </td>
               <td>
                   &nbsp;</td>
                    <td align=left>    
                    <asp:DropDownList ID="DDLEquipmentUnit" runat="server" Width="150px">
                        </asp:DropDownList>                   
               </td>
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   院内价格</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtInternalPrice" runat="server" Width="135px"></asp:TextBox>元
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
           ErrorMessage="校内价格请输入数字" Text="*" ControlToValidate="txtInternalPrice" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
               <td align=right height=25px class="blue">
                   校外价格</td>
                   <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtExternalPrice" runat="server" Width="135px"></asp:TextBox>元
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="校外价格请输入数字" Text="*" ControlToValidate="txtExternalPrice" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
               
             </tr> 
           <tr>
               <td align=right height=25px class="blue">
                   校内价格</td>
               <td>
                   &nbsp;</td>
                 <td align=left>
                        <asp:TextBox ID="txtStudentPrice" runat="server" Width="135px"></asp:TextBox>元
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
           ErrorMessage="校外价格请输入数字" Text="*" ControlToValidate="txtStudentPrice" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>   
                <td align=right class="blue">
                    预约押金</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtDeposit" runat="server" Width="135px"></asp:TextBox>元
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
           ErrorMessage="押金请输入数字" Text="*" ControlToValidate="txtDeposit" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
           </tr>
             
           <tr>
               <td align=right height=25px class="blue">
                   备注</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:TextBox ID="txtRemark" runat="server" Width="90%" TextMode="MultiLine" Height="50px"></asp:TextBox>
               </td>
                
           </tr>
            <tr>
               <td align=right height=25px class="blue">
                   设备说明</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:TextBox ID="txtNodes" runat="server" Width="90%" TextMode="MultiLine" Height="50px"></asp:TextBox>
               </td>
                
           </tr>
           <tr>
                <td align="right">设备图片</td>
                <td>&nbsp;</td>
                <td>
                    <img id="imgEquipmentPhoto" alt="" width="100px" height="100px" /><asp:FileUpload ID="FUEquipmentPhoto" runat="server" onchange="imgUpload(this)" />
                     
                </td>
                
                <td>周六周日是否工作：<asp:CheckBox ID="cb_zhoumo" runat="Server" />
                </td>
                <td>&nbsp;</td>
                <td>（选中表示工作）
                    
                    
                </td>
           </tr>    
           <tr>
            <td colspan="6" align="center">
                <asp:ImageButton ID="btSave" runat="server" ImageUrl="~/Images/SaveBtn.png" 
                    onclick="btSave_Click" />
                    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
            </td>
           </tr>        
       </table>
</asp:Content>

