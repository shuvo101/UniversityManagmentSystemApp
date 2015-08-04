<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentEntry.aspx.cs" Inherits="WebApplication1.StudentEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        Student Name :
        <asp:TextBox ID="StuTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Student ID :&nbsp;
        <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Student Email :
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Department :
        <asp:DropDownList ID="DepartmentDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="StudentButton" runat="server" OnClick="StudentButton_Click" Text="Save" />
    
    </div>
    </form>
</body>
</html>
