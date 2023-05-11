using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OP2_LAB4_U4_05
{
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Entries"] == null)
                Session["Entries"] = DefaultData.CreateList();

            if (Session["Entries"] is List<Question> entries)
            {
                SuccessSection.Visible = true;
                ErrorSection.Visible = false;

                try
                {
                    AuthorQuestionCount authorWithMostQuestions =
                        AnalyticsQueries.AuthorWithMostQuestions(entries);

                    LabelAuthorWithMostQuestions.Text = string.Format("Author with most questions is <b>{0}</b>, belongs to group <b>{1}</b> and has created <b>{2}</b> questions.",
                        authorWithMostQuestions.Author,
                        authorWithMostQuestions.Group,
                        authorWithMostQuestions.QuestionCount);
                }
                catch (InvalidOperationException)
                {
                    LabelAuthorWithMostQuestions.Text = "Not enough questions to determine an author with most questions.";
                }

                try
                {
                    TableAuthorsWithMostQuestionsInEachGroup.AddTableRowFromStrings(
                        "<b>Author</b>",
                        "<b>Group</b>",
                        "<b>Count</b>");

                    foreach (AuthorQuestionCount author in AnalyticsQueries.AuthorWithMostQuestionsInEachGroup(entries))
                        TableAuthorsWithMostQuestionsInEachGroup.AddTableRowFromStrings(
                            author.Author,
                            author.Group,
                            author.QuestionCount);
                }
                catch (InvalidOperationException)
                {
                    TableAuthorsWithMostMusicQuestionsInEachGroup.AddTableRowFromStrings("Not enough data");
                }

                TableAuthorsWithMostMusicQuestionsInEachGroup.AddTableRowFromStrings(
                    "<b>Author</b>",
                    "<b>Group</b>",
                    "<b>Count</b>");

                foreach (AuthorQuestionCount author in AnalyticsQueries.AuthorWithMostMusicQuestionsInEachGroup(entries))
                    TableAuthorsWithMostMusicQuestionsInEachGroup.AddTableRowFromStrings(
                        author.Author,
                        author.Group,
                        author.QuestionCount);

                TableOrderedTestQuestions.AddTableRowFromStrings(
                    "<b>Subject</b>",
                    "<b>Author group</b>",
                    "<b>Author</b>",
                    "<b>Text</b>",
                    "<b>Answer</b>",
                    "<b>Complexity</b>",
                    "<b>Reward</b>",
                    "<b>Possible answers</b>");

                foreach (TestQuestion testQuestion in AnalyticsQueries.SortTestQuestions(entries))
                    TableOrderedTestQuestions.AddTableRowFromStrings(
                        testQuestion.Subject,
                        testQuestion.AuthorGroup,
                        testQuestion.Author,
                        testQuestion.Text,
                        testQuestion.CorrectAnswer,
                        testQuestion.Complexity,
                        testQuestion.RewardPoints,
                        string.Join(string.Empty,
                            testQuestion.PossibleAnswers.Select(answer => $"<span style=\"display: block;\">{answer}</span>")));

                TableOrderedMusicQuestions.AddTableRowFromStrings(
                    "<b>Subject</b>",
                    "<b>Author group</b>",
                    "<b>Author</b>",
                    "<b>Text</b>",
                    "<b>Answer</b>",
                    "<b>Complexity</b>",
                    "<b>Reward</b>",
                    "<b>Media file path</b>");

                foreach (MusicQuestion musicQuestion in AnalyticsQueries.SortMusicQuestions(entries))
                    TableOrderedMusicQuestions.AddTableRowFromStrings(
                        musicQuestion.Subject,
                        musicQuestion.AuthorGroup,
                        musicQuestion.Author,
                        musicQuestion.Text,
                        musicQuestion.CorrectAnswer,
                        musicQuestion.Complexity,
                        musicQuestion.RewardPoints,
                        musicQuestion.MediaFilePath);

                TableHistoryQuestions.AddTableRowFromStrings(
                    "<b>Subject</b>",
                    "<b>Author group</b>",
                    "<b>Author</b>",
                    "<b>Text</b>",
                    "<b>Answer</b>",
                    "<b>Complexity</b>",
                    "<b>Reward</b>",
                    "<b>Possible answers</b>",
                    "<b>Media file path</b>");

                foreach (Question historyQuestion in AnalyticsQueries.QuestionsBySubject(entries, "History"))
                    TableHistoryQuestions.AddTableRowFromStrings(
                        historyQuestion.Subject,
                        historyQuestion.AuthorGroup,
                        historyQuestion.Author,
                        historyQuestion.Text,
                        historyQuestion.CorrectAnswer,
                        historyQuestion.Complexity,
                        historyQuestion.RewardPoints,
                        historyQuestion is TestQuestion testQuestion ? string.Join(string.Empty,
                            testQuestion.PossibleAnswers.Select(answer => $"<span style=\"display: block;\">{answer}</span>")) : "-",
                        historyQuestion is MusicQuestion musicQuestion ? musicQuestion.MediaFilePath : "-");
            }
        }

        protected void DefaultLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
    }
}