<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClassRoutine.aspx.cs" Inherits="WebApplication1.ClassRoutine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div>
    
        Department :&nbsp;
        <asp:DropDownList ID="DepartmentDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:GridView ID="ClassRoutineGridView" runat="server">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
