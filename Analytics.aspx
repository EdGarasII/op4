<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Analytics.aspx.cs" Inherits="OP2_LAB4_U4_05.Results" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="window title">Question analytics</div>
        <div class="window" runat="server" id="SuccessSection" visible="false">
            
            <asp:Label ID="LabelAuthorWithMostQuestions" runat="server" Text=""></asp:Label>
            <br />
            <br />

            <details>
                <summary>Authors with most questions in each group</summary>
                <asp:Table ID="TableAuthorsWithMostQuestionsInEachGroup" runat="server" GridLines="Both"></asp:Table>
            </details>
            <br />
            
            <details>
                <summary>Authors with most music questions in each group</summary>
                <asp:Table ID="TableAuthorsWithMostMusicQuestionsInEachGroup" runat="server" GridLines="Both"></asp:Table>
            </details>
            <br />

            <details>
                <summary>Ordered list of test questions (ordered by subject, then by complexity)</summary>
                <asp:Table ID="TableOrderedTestQuestions" runat="server" GridLines="Both"></asp:Table>
            </details>
            <br />

            <details>
                <summary>Ordered list of music questions (ordered by media file name)</summary>
                <asp:Table ID="TableOrderedMusicQuestions" runat="server" GridLines="Both"></asp:Table>
            </details>
            <br />

            <details>
                <summary>List of questions from the history subject</summary>
                <asp:Table ID="TableHistoryQuestions" runat="server" GridLines="Both"></asp:Table>
            </details>    
            <br />
        </div>
        <div class="window" runat="server" id="ErrorSection" visible="true">
            No data.
        </div>
        <div class="window">
            <asp:Button ID="DefaultLink" runat="server" Text="Return" OnClick="DefaultLink_Click" />
        </div>
    </form>
</body>
</html>
