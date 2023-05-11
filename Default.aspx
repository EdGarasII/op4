<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OP2_LAB4_U4_05.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="window title">Menu</div>
        <div class="window">
            <asp:Button style="display: block; width: 100%" ID="TestQuestionsLink" runat="server" Text="Test questions" OnClick="TestQuestionsLink_Click" />
            <br />
            <asp:Button style="display: block; width: 100%" ID="MusicQuestionsLink" runat="server" Text="Music questions" OnClick="MusicQuestionsLink_Click" />
            <br />
            <asp:Button style="display: block; width: 100%" ID="AnalyticsLink" runat="server" Text="Analytics" OnClick="AnalyticsLink_Click" />
        </div>
    </form>
</body>
</html>
