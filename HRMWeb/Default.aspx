<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="bottom.ascx" TagName="bottom" TagPrefix="uc2" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>广州市德珑电子器件有限公司－工资查询</title>
    <style type="text/css">
        .style1
        {
        }
        .style9
        {
            width: 130px;
            height: 36px;
        }
        .style26
        {
            height: 26px;
            font-size: medium;
            background-color:#D4ECFC;
           
        }
        .style28
        {
            width: 760px;
            height: 83px;
        }
        .style29
        {
            width: 188px;
            height: 36px;
        }
        #Text1
        {
            width: 182px;
        }
        </style>

</head>

<Script Language='JavaScript'> 
function s_search1_Click()
{
    window.alert(document.getElementById('HiddenText').value);
}
</Script>
<body style="margin-top: 0px; margin-left: 0px; margin-right: 0px; font-family:宋体; font-size:12px; text-align: center;">    
 
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width:90%" 
            align="center" >
            <tr>
                <td style="height: 80px; background-image: url(Images/top.gif);">
                    <table align="center" class="style28">
                        <tr>
                            <td style="background-image: url('Images/title.gif')">&nbsp;
                                </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 12px" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%">
                        <tr>
                            <td valign="top" class="style1"  height="30" align="center" colspan="8">
                             <asp:Label ID="Label14" runat="server" 
                                    BorderStyle="None" Height="20px" 
                                        Text="姓名："></asp:Label>
                              <asp:Label ID="employeeNameLable" runat="server" Font-Size="12pt" 
                                    ForeColor="#66CCFF" Font-Names="宋体"></asp:Label>
                                     &nbsp;<asp:Label ID="LblCardNo" runat="server" 
                                    BorderStyle="None" Height="20px"  
                                        Text="身份证号码验证：" ></asp:Label><asp:TextBox id="txtCardNo" 
                                    runat="server" Width="189px" AutoCompleteType="Disabled"  ></asp:TextBox>&nbsp;&nbsp;
                                    <asp:Label ID="Label1" runat="server" BorderStyle="None" Height="20px" 
                                        Text="查询月份："></asp:Label>
                                    <asp:DropDownList ID="listYear" runat="server">                                   
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label12" runat="server" BorderStyle="None" Height="20px" 
                                        Text="年"></asp:Label>
                                    &nbsp;<asp:DropDownList ID="listMonth" runat="server">
                                        <asp:ListItem Value="1">1</asp:ListItem>
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label13" runat="server" BorderStyle="None" Height="20px" 
                                        Text="月"></asp:Label>
                                    &nbsp;<asp:Button ID="s_search" runat="server" Text="查询" 
                                        OnClick="s_search_Click" />
                              
                            </td>
                        </tr>

                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                <asp:Label ID="Label7" runat="server" Font-Names="黑体" ForeColor="Black" 
                                    Text="职员基本信息："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td class="style9" valign="middle" align="right">
                                    部&nbsp;&nbsp; 门：</td>
                            <td class="style9" id="laName" align="left">
                                 <asp:Label ID="employeeDept" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" align="right">
                                    入职日期：</td>
                             <td class="style9" id="Td1" align="left">
                                <asp:Label ID="employeeJionDate" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" align="right">
                                    职 位：</td>
                            <td class="style9" id="lableJionDate" align="left">
                                <asp:Label ID="emplpyeePostion" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                                </td>
                            <td class="style9">
                                    试用期：</td>
                            <td class="style9" id="lablePosition" align="left">
                                    <asp:Label ID="employeeProbation" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td class="style9" valign="middle" align="right">
                                    转正日期：</td>
                            <td class="style9" id="labelProbation" align="left">
                                <asp:Label ID="employeeProDate" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" align="right">
                                    薪酬制度：</td>
                            <td class="style9" align="left">
                                <asp:Label ID="salaryType" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" align="right">
                                    &nbsp;</td>
                            <td class="style9" id="lableSalaryType" align="left">
                                &nbsp;</td>
                            <td class="style9">
                                    &nbsp;</td>
                            <td class="style9" align="left">
                                &nbsp;</td>
                        </tr>

                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                <asp:Label ID="Label11" runat="server" Font-Names="黑体" ForeColor="Black" 
                                    Text="绩效考核："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td class="style9" valign="middle" align="left">
                                    绩效基数：</td>
                            <td class="style9" valign="middle" align="left">
                                <asp:Label ID="performanceBase" runat="server" Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" valign="middle" align="left">
                                    个人绩效得分：</td>
                            <td class="style29" valign="middle" align="left">
                                <asp:Label ID="coefMark" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" valign="middle" align="left">
                                    个人绩效系数：</td>
                            <td class="style9" valign="middle" align="left">
                                <asp:Label ID="coeffPerson" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                            <td class="style9" valign="middle" align="left">
                                    绩效工资：</td>
                            <td class="style9" valign="middle" align="left">
                                <asp:Label ID="performanceAllw" runat="server"  Font-Size="15pt" 
                                    ForeColor="#3399FF"></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label8" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="工资明细："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                <asp:Label ID="salaryMessage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                    Text="无工资记录!"></asp:Label>
                                <asp:GridView ID="salaryData" runat="server" CellPadding="4" Width="100%" 
                                    Height="104px" ForeColor="#333333" BorderColor="#666666" ShowHeader="False" 
                                    >
                                    <RowStyle BackColor="#336666" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                                    <PagerStyle BackColor="#336666" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="#F7F7F7" />
                                    <AlternatingRowStyle BackColor="White"  ForeColor="Black" Font-Bold="False" />
                                </asp:GridView>
                            </td>
                        </tr>

                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label16" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="考勤信息："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                    <asp:Label ID="attendMessage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                        Text="无考勤记录！"></asp:Label>
                                    <asp:GridView ID="attendData" runat="server" CellPadding="4"
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" >
                                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                                            VerticalAlign="Middle" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                            </td>
                        </tr>
                          <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label3" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="加班记录："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                    <asp:Label ID="overTimeWageMessage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                        Text="无加班记录！" EnableTheming="False"></asp:Label>
                                    <asp:GridView ID="overTimeWage" runat="server" CellPadding="4"
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" HorizontalAlign="Center" 
                                        >
                                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                                            VerticalAlign="Middle" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                    <asp:GridView ID="overTimeWageTotal" runat="server" CellPadding="4"
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" HorizontalAlign="Center" ShowHeader="False" 
                                        >
                                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                                            VerticalAlign="Middle" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                            </td>
                        </tr>


                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label17" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="请假记录："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                    <asp:Label ID="leaveMessage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                        Text="无请假记录！" EnableTheming="False"></asp:Label>
                                    <asp:GridView ID="leaveData" runat="server" CellPadding="4"
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" 
                                        >
                                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                                            VerticalAlign="Middle" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                            </td>
                        </tr>


                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label2" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="调休记录："></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                    <asp:Label ID="paidLeaveMessage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                        Text="无调休记录！" EnableTheming="False"></asp:Label>
                                    <asp:GridView ID="paidLeave" runat="server" CellPadding="4" 
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" >
                                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                                            VerticalAlign="Middle" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                            </td>
                        </tr>
                        
                        
                        <tr >
                            <td class="style26" valign="middle" align="left" colspan="8">
                                    <asp:Label ID="Label9" runat="server" Font-Names="黑体" ForeColor="Black" 
                                        Text="奖扣记录:"></asp:Label>
                            </td>
                        </tr>

                        <tr >
                            <td valign="middle" align="center" colspan="8">
                                    <asp:GridView ID="reDeduData" runat="server" CellPadding="4" 
                                        Width="100%" BorderColor="#336666" BackColor="White" BorderStyle="Double" 
                                        BorderWidth="3px" 
                                        >
                                        <RowStyle BackColor="White" ForeColor="#333333" />
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    </asp:GridView>
                                    <asp:Label ID="redeuMassage" runat="server" Font-Names="黑体" Font-Size="Large" 
                                        Text="无奖扣记录！"></asp:Label>
                            </td>
                        </tr>

                         

                                    </table>
                    <uc2:bottom ID="Bottom1" runat="server" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

