<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MusicQuestions.aspx.cs" Inherits="OP2_LAB4_U4_05.MusicQuestions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="window title">Music questions</div>
        <div class="window" runat="server" id="EntriesSection" visible="false">
            <asp:Table ID="EntriesTable" runat="server" GridLines="Both"></asp:Table>
            <br />

            <asp:Button ID="ButtonClearEntries" runat="server" Text="Clear entries" OnClick="ButtonClearEntries_Click" CausesValidation="false" />
        </div>
        <div class="window">
            <asp:Label runat="server" Text="Question subject:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionSubject" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputQuestionSubjectValidator" runat="server" ErrorMessage="Question subject is required." ControlToValidate="InputQuestionSubject" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" Text="Question author group:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionAuthorGroup" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputQuestionAuthorGroupValidator" runat="server" ErrorMessage="Question author group is required." ControlToValidate="InputQuestionAuthorGroup" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" Text="Question author:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionAuthor" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputQuestionAuthorValidator" runat="server" ErrorMessage="Question author is required." ControlToValidate="InputQuestionAuthor" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" Text="Question text:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionText" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputQuestionTextValidator" runat="server" ErrorMessage="Question text is required." ControlToValidate="InputQuestionText" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" Text="Correct answer:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputCorrectAnswer" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputCorrectAnswerValidator" runat="server" ErrorMessage="Correct answer is required." ControlToValidate="InputCorrectAnswer" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />

            <asp:Label runat="server" Text="Question complexity (1-10):"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionComplexity" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="InputQuestionComplexityValidator" runat="server" ErrorMessage="Question complexity must be an integer between 1 and 10." ControlToValidate="InputQuestionComplexity" Type="Integer" MinimumValue="1" MaximumValue="10" ForeColor="Red"></asp:RangeValidator>
            <br />

            <asp:Label runat="server" Text="Question reward (1-10):"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputQuestionReward" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="InputQuestionRewardValidator" runat="server" ErrorMessage="Question reward must be an integer between 1 and 10." ControlToValidate="InputQuestionReward" Type="Integer" MinimumValue="1" MaximumValue="10" ForeColor="Red"></asp:RangeValidator>
            <br />

            <asp:Label runat="server" Text="Media file path:"></asp:Label>
            <asp:TextBox style="width: 100%; display: block" ID="InputMediaFilePath" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="InputMediaFilePathValidator" runat="server" ErrorMessage="Media file path is required." ControlToValidate="InputMediaFilePath"></asp:RequiredFieldValidator>
            <br />
            
            <asp:Button ID="SubmitButton" runat="server" Text="Save" OnClick="SubmitButton_Click" />
        </div>
        <div class="window">
            <asp:Button ID="DefaultLink" runat="server" Text="Return" OnClick="DefaultLink_Click" CausesValidation="false" />
        </div>
    </form>
</body>
</html>
