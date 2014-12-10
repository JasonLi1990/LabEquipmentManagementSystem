<%@ Page Language="C#" MasterPageFile="~/EquipManager/EM_MasterPage.master" AutoEventWireup="true" CodeFile="nAddEquipment.aspx.cs" Inherits="Admin_nAddEquipment" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="../My97DatePicker/WdatePicker.js"></script>
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
<style type="text/css">
.blue
{
	font-size:11pt;
	color:Blue
}
</style>
<table width=100% cellpadding=0 cellspacing=0 border=0>
   <tr>
   <td height="45px" valign=bottom align=left style="background:url(../Images/Contentback01.png); background-repeat:repeat-x" nowrap>
       <table style="width:400px">
       <tr>
       <td  align="left"> 
           <asp:Image ID="ImgTitle" runat="server" ImageUrl="~/Images/EquipmentEditImg.png" />
           
       </td>
       <td align="left">
        相同设备台数(复制)
        <asp:DropDownList ID="ddl_equipnumber" runat="server" Width="50px">
            <asp:ListItem Value="1">1</asp:ListItem>
            <asp:ListItem Value="2">2</asp:ListItem>
            <asp:ListItem Value="3">3</asp:ListItem>
            <asp:ListItem Value="4">4</asp:ListItem>
            <asp:ListItem Value="5">5</asp:ListItem>
            <asp:ListItem Value="6">6</asp:ListItem>
            <asp:ListItem Value="7">7</asp:ListItem>
            <asp:ListItem Value="8">8</asp:ListItem>
            <asp:ListItem Value="9">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
        </asp:DropDownList>
       </td>       
       </tr>
       </table>      
       </td>
           
   </tr>
   <tr>
   <td align=center>
       
       <table width=90% cellpadding="0" cellspacing="0" class="blue">
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
                   设备类型</td>
               <td width=10px>
                   &nbsp;</td>
                    <td align=left>
                        <asp:DropDownList ID="ddlEquipmentType" runat="server" Width="150px" DataTextField="EquipmentTypeName" DataValueField="EquipmentTypeId">
                        </asp:DropDownList>
               </td>
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   管&nbsp;&nbsp;理&nbsp;&nbsp;员</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:DropDownList ID="ddlEquipmentManager" runat="server" Width="156px" Enabled="false">
                        </asp:DropDownList>
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
               <td align=right height=25px class="blue">
                   设备价格</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtEquipmentPrice" runat="server" Width="135px">0</asp:TextBox>元
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
           ErrorMessage="设备使用次数开始请输入数字" Text="*" ControlToValidate="txtEquipmentPrice" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
                <td align=right class="blue">
                    使用次数</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtFrequencyOfUse" runat="server" Width="150px">0</asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
           ErrorMessage="设备使用次数结束请输入数字" Text="*" ControlToValidate="txtFrequencyOfUse" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   厂家名称</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtManufacturerName" runat="server" Width="150px"></asp:TextBox>
               </td>
                <td align=right class="blue">
                    厂家电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtManufacturerPhone" runat="server" Width="150px"></asp:TextBox>                       
               </td>
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   厂家地址</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:TextBox ID="txtManufacturerAddress" runat="server" Width="90%"></asp:TextBox>
               </td>
                
           </tr>
           <tr>
               <td align=right height=25px class="blue">
                   进货日期</td>
               <td>
                   &nbsp;</td>
                 <td align=left>
                    <asp:TextBox ID="txtPurchaseDate" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
                 </td>
                <td align=right class="blue">
                    质保期限</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                    <asp:TextBox ID="txtWarrantyPeriod" CssClass="Wdate" onClick="WdatePicker()" runat="server" Width="150px"></asp:TextBox>
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
                <td align=right class="blue">
                    质保电话</td>
               <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtWarrantyPhone" runat="server" Width="150px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
           ErrorMessage="质保电话请输入正确的电话号码" Text="*" ControlToValidate="txtWarrantyPhone" ForeColor="Red" 
                            ValidationExpression="(\(\d{3}\)|\d{3}-)?\d{8}"></asp:RegularExpressionValidator>
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
                   校外价格</td>
                   <td>
                   &nbsp;</td>
                    <td align=left>
                        <asp:TextBox ID="txtExternalPrice" runat="server" Width="135px"></asp:TextBox>元
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
           ErrorMessage="校外价格请输入数字" Text="*" ControlToValidate="txtExternalPrice" ForeColor="Red" ValidationExpression="^[-]?\d+[.]?\d*$"></asp:RegularExpressionValidator>
               </td>
                <td align=right class="blue">
                    提前天数
                   </td>
               <td>
                   &nbsp;</td>
                    <td align="left">
                    <asp:DropDownList ID="ddl_startday" runat="server" Width="150px">
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
                   备注</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:TextBox ID="txtRemark" runat="server" Width="90%"></asp:TextBox>
               </td>
                
           </tr>
            <tr>
               <td align=right height=25px class="blue">
                   设备说明</td>
               <td>
                   &nbsp;</td>
                    <td align=left colspan=4>
                        <asp:TextBox ID="txtNodes" runat="server" Width="90%"></asp:TextBox>
               </td>
                
           </tr>
            <tr>
               <td align=right height=110px class="blue">
                   设备图片</td>
               <td>
                   &nbsp;</td>
                    <td align="center" valign="middle">
                        
                        <img id="imgEquipmentPhoto" alt="" width="100px" height="100px" />
                        
               </td>
               <td colspan="2" align="left">
                    
                    <asp:CheckBox ID="cb_changephoto" runat="server" Visible="false" Text="修改设备图片" />
                    
                   <asp:FileUpload ID="FUEquipmentPhoto" runat="server" onchange="imgUpload(this)" />
                </td>
                <td>
                    <asp:Image ID="img_show" runat="server" Width="100px" Height="100px" />
                </td>
           </tr>
       </table>
       
       </td>
   </tr>
   <tr>
   <td align=center height=30px valign=bottom>
       <asp:ImageButton ID="imgBtnEdit" runat="server" 
           ImageUrl="~/Images/BtnAdd.png" onclick="imgBtnEdit_Click"/>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:ImageButton ID="imgBtnBack" runat="server" 
           ImageUrl="~/Images/FanHuiBtn.png" CausesValidation="False" 
           onclick="imgBtnBack_Click" />
       
       </td>
   </tr>
   <tr>
   <td>
       <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
   </td>
   </tr>
   </table>
    <asp:HiddenField ID="HFEquipmentPhoto" runat="server" />
</asp:Content>

