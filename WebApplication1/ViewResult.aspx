<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewResult.aspx.cs" Inherits="WebApplication1.ViewResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Student Registration Number :
        <asp:DropDownList ID="StuReDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StuReDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Student Name : <asp:TextBox ID="StuNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Student Email :
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Department :
        <asp:TextBox ID="DepartTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="MakePdfButton" runat="server" Text="Make PDF" OnClick="MakePdfButton_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <SortedAscendingCellStyle BackColor="#F4F4FD" />
            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
            <SortedDescendingCellStyle BackColor="#D8D8F0" />
            <SortedDescendingHeaderStyle BackColor="#3E3277" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
