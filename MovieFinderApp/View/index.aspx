<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MovieFinderApp.View.WebForm1" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div style="text-align: center">
            Hello. Enter a movie name to search for it.
    </div>
    <form id="SearchByTitle" runat="server" style="text-align: center" defaultbutton="SubmitButton">
        <asp:TextBox id="SearchKeyword" runat="server" width="200px" placeholder="Search..."></asp:TextBox>
        <asp:Button ID="SubmitButton" runat="server" Text="Find Movies" OnClick="Submitform"/>
    </form>
</body>
</html>
