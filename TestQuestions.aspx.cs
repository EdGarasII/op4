using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OP2_LAB4_U4_05
{
    public partial class TestQuestions : System.Web.UI.Page
    {
        private void UpdateTable()
        {
            EntriesTable.Rows.Clear();

            EntriesTable.AddTableRowFromStrings(
                "<b>Subject</b>",
                "<b>Author group</b>",
                "<b>Author</b>",
                "<b>Text</b>",
                "<b>Answer</b>",
                "<b>Complexity</b>",
                "<b>Reward</b>",
                "<b>Possible answers</b>");

            if (Session["Entries"] is List<Question> entries)
            {
                foreach (TestQuestion testQuestion in entries
                    .Where(question => question is TestQuestion)
                    .Select(question => question as TestQuestion))
                    EntriesTable.AddTableRowFromStrings(
                        testQuestion.Subject,
                        testQuestion.AuthorGroup,
                        testQuestion.Author,
                        testQuestion.Text,
                        testQuestion.CorrectAnswer,
                        testQuestion.Complexity,
                        testQuestion.RewardPoints,
                        string.Join(string.Empty,
                            testQuestion.PossibleAnswers
                                .Select(answer => $"<span style=\"display: block;\">{answer}</span>")));

                EntriesSection.Visible = entries.Count > 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Entries"] == null)
                Session["Entries"] = DefaultData.CreateList();

            UpdateTable();
        }

        protected void DefaultLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!InputQuestionSubjectValidator.IsValid ||
                !InputQuestionAuthorGroupValidator.IsValid ||
                !InputQuestionAuthorValidator.IsValid ||
                !InputQuestionTextValidator.IsValid ||
                !InputCorrectAnswerValidator.IsValid ||
                !InputQuestionComplexityValidator.IsValid ||
                !InputQuestionRewardValidator.IsValid ||
                !InputQuestionAnswerChoicesValidator.IsValid) return;

            List<Question> questions;

            if (Session["Entries"] is List<Question> entries)
                questions = entries;
            else
            {
                questions = new List<Question>();
                Session["Entries"] = questions;
            }

            questions.Add(new TestQuestion(
                InputQuestionSubject.Text,
                InputQuestionAuthorGroup.Text,
                InputQuestionAuthor.Text,
                InputQuestionText.Text,
                InputCorrectAnswer.Text,
                int.Parse(InputQuestionComplexity.Text),
                int.Parse(InputQuestionReward.Text),
                InputQuestionAnswerChoices.Text
                .Split('\n').Select(answer => answer.Trim()).ToArray()));

            UpdateTable();
        }

        protected void ButtonClearEntries_Click(object sender, EventArgs e)
        {
            if (Session["Entries"] is List<Question> entries)
            {
                Session["Entries"] = entries.Where(question => !(question is TestQuestion)).ToList();
                UpdateTable();
            }
        }
    }
}