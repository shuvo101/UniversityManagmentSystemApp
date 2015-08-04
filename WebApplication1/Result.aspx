<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="WebApplication1.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        Student Registration Number :
        <asp:DropDownList ID="StudDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="StudDropDownList_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        Name :&nbsp; <asp:TextBox ID="StudNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Email&nbsp; :&nbsp;
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Department :&nbsp;
        <asp:TextBox ID="DepartmentTextBox" runat="server"></asp:TextBox>
        <br />
        <br />
        Select Course :&nbsp;
        <asp:DropDownList ID="CourseDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        Select Grade Letter :
        <asp:DropDownList ID="ResultDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem>A+</asp:ListItem>
            <asp:ListItem>A</asp:ListItem>
            <asp:ListItem>A-</asp:ListItem>
            <asp:ListItem>B+</asp:ListItem>
            <asp:ListItem>B</asp:ListItem>
            <asp:ListItem>B-</asp:ListItem>
            <asp:ListItem>C</asp:ListItem>
            <asp:ListItem>D</asp:ListItem>
            <asp:ListItem>F</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="ResultSaveButton" runat="server" OnClick="ResultSaveButton_Click" Text="Save" />
    
    </div>
    </form>
</body>
</html>
