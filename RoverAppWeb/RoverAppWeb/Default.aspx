<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Mars Rover Query</h1>
            <br />
            <asp:TextBox ID="txtDates" runat="server" Height="300px" TextMode="MultiLine" Width="300px">02/27/17
June 2, 2018
Jul-13-2016
April 31, 2018</asp:TextBox>
            <br />
            <asp:Button ID="cmdLoad" runat="server" OnClick="cmdLoad_Click" Text="Load Images" />
        </div>
        <br />
        <br />
        <div runat="server" id="divMessage">
        </div>
        <br />
        <br />
        <div runat="server" id="divInfo">
        </div>

    </form>
</body>
</html>
