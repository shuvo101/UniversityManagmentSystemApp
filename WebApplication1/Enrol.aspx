<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enrol.aspx.cs" Inherits="WebApplication1.Enrol" %>

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
    
        Student Registration No :&nbsp;
        <asp:DropDownList ID="StudentIDDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StudentIDDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Name : <asp:TextBox ID="StudentNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Email :
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Department :&nbsp;
        <asp:TextBox ID="DepartmentTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Select Course :&nbsp;
        <asp:DropDownList ID="CourseDropDownList" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        Date :&nbsp;
        <asp:TextBox ID="DateTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="EnrollButton" runat="server" OnClick="EnrollButton_Click" Text="Enroll" />
    
    </div>
    </form>
</body>
</html>
